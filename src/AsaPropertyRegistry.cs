using AsaSavegameToolkit.Properties;
using AsaSavegameToolkit.Structs;
using AsaSavegameToolkit.Types;
using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    public static class AsaPropertyRegistry
    {
        public static bool TryReadProperty(AsaArchive archive, [NotNullWhen(true)] out AsaProperty<dynamic>? property)
        {
            return TryReadProperty(archive, false, out property);
        }

        public static bool TryReadProperty(AsaArchive archive, bool inArray, [NotNullWhen(true)] out AsaProperty<dynamic>? property)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                if (!archive.TryReadName("property name", out var keyName) || keyName.Equals(AsaName.NameNone))
                {
                    property = null;
                    return false;
                }

                // UE5.5 generic type format (SaveVersion 14+)
                return TryReadPropertyUE55(archive, keyName, inArray, out property);
            }
            catch
            {
                property = null;
                return false;
            }
        }

        private static bool TryReadPropertyUE55(AsaArchive archive, AsaName keyName, bool inArray, [NotNullWhen(true)] out AsaProperty<dynamic>? property)
        {
            try
            {
                // Read generic type (type name + subtypes recursively)
                if (!AsaGenericType.TryRead(archive, out var genericType) || genericType == null)
                {
                    property = null;
                    return false;
                }

                var dataSize = archive.ReadInt32("data size");
                
                // Read flags and position (if not boolean)
                byte flags = 0;
                int position = 0;
                if (genericType.TypeName.Name != "BoolProperty")
                {
                    flags = archive.ReadByte("flags");
                    if ((flags & 0x01) == 1)
                    {
                        position = archive.ReadInt32("position");
                    }
                }

                var startPosition = archive.Position;
                var valueTypeName = genericType.TypeName.Name;

                switch (valueTypeName)
                {
                    case "BoolProperty":
                    case "ByteProperty":
                    case "FloatProperty":
                    case "IntProperty":
                    case "Int8Property":
                    case "DoubleProperty":
                    case "UInt32Property":
                    case "UInt64Property":
                    case "UInt16Property":
                    case "Int16Property":
                    case "Int64Property":
                    case "StrProperty":
                    case "NameProperty":
                    case "SoftObjectProperty":
                    case "ObjectProperty":
                        if (TryReadPropertyValue(genericType.TypeName, archive, out var simpleValue))
                        {
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName, position, simpleValue);
                            return true;
                        }
                        break;

                    case "StructProperty":
                        // In UE5.5, struct type is in subtypes[0]
                        if (genericType.SubTypes.Count > 0)
                        {
                            var structType = genericType.SubTypes[0].TypeName;
                            if (TryReadStructPropertyValue(archive, dataSize, structType, inArray, out var structValue))
                            {
                                property = new AsaProperty<dynamic>(keyName.Name, valueTypeName, position, structValue);
                                return true;
                            }
                        }
                        break;

                    case "ArrayProperty":
                        if (genericType.SubTypes.Count > 0)
                        {
                            var arrayElementType = genericType.SubTypes[0];
                            if (TryReadArrayPropertyUE55(keyName, archive, arrayElementType, out var arrayProp))
                            {
                                property = new AsaProperty<dynamic>(keyName.Name, valueTypeName, position, arrayProp.Value);
                                return true;
                            }
                        }
                        break;

                    case "MapProperty":
                        try
                        {
                            if (TryReadMapProperty(archive, out var mapValue))
                            {
                                property = new AsaProperty<dynamic>(keyName.Name, valueTypeName, position, mapValue);
                                return true;
                            }
                        }
                        catch
                        {
                            archive.Position = startPosition;
                            archive.SkipBytes(dataSize);
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName, position, 0);
                            return true;
                        }
                        break;
                }

                property = null;
                return false;
            }
            catch
            {
                property = null;
                return false;
            }
        }

        private static bool TryReadPropertyValue(AsaName valueTypeName, AsaArchive archive, [NotNullWhen(true)] out dynamic? value)
        {
            try
            {
                switch (valueTypeName.Name)
                {
                    case "ByteProperty":
                    case "Int8Property":
                        value = archive.ReadByte("byte");
                        return true;
                        
                    case "DoubleProperty":
                        value = archive.ReadDouble("double");
                        return true;
                        
                    case "FloatProperty":
                        value = archive.ReadSingle("float");
                        return true;
                        
                    case "IntProperty":
                        value = archive.ReadInt32("int");
                        return true;
                        
                    case "ObjectProperty":
                        if (AsaObjectReference.TryRead(archive, true, out var objRef))
                        {
                            value = objRef;
                            return true;
                        }
                        value = null;
                        return false;
                        
                    case "StrProperty":
                        if (archive.TryReadString("string", out var strVal))
                        {
                            value = strVal;
                            return true;
                        }
                        value = null;
                        return false;
                        
                    case "NameProperty":
                        if (archive.TryReadName("name", out var name))
                        {
                            value = name.ToString();
                            return true;
                        }
                        value = null;
                        return false;
                        
                    case "UInt32Property":
                        value = (uint)archive.ReadInt32("uint32");
                        return true;
                        
                    case "UInt64Property":
                        value = (ulong)archive.ReadInt64("uint64");
                        return true;
                        
                    case "UInt16Property":
                        value = (ushort)archive.ReadInt16("uint16");
                        return true;
                        
                    case "Int16Property":
                        value = archive.ReadInt16("int16");
                        return true;
                        
                    case "Int64Property":
                        value = archive.ReadInt64("int64");
                        return true;
                        
                    case "BoolProperty":
                        value = archive.ReadByte("bool") > 0;
                        return true;
                        
                    case "SoftObjectProperty":
                        return TryReadSoftObjectPropertyValue(archive, out value);
                        
                    default:
                        value = null;
                        return false;
                }
            }
            catch
            {
                value = null;
                return false;
            }
        }

        private static bool TryReadSoftObjectPropertyValue(AsaArchive archive, [NotNullWhen(true)] out dynamic? value)
        {
            if (archive.TryReadName("soft obj name", out var objectName) && archive.TryReadName("soft obj value", out var objectValue))
            {
                value = new AsaProperty<dynamic>(objectName.ToString(), "Propertiestr", 0, objectValue);
                return true;
            }
            
            value = null;
            return false;
        }

        private static bool TryReadStructPropertyValue(AsaArchive archive, int dataSize, AsaName structType, bool inArray, [NotNullWhen(true)] out dynamic? value)
        {
            if (!inArray)
            {
                archive.SkipBytes(16);
            }

            try
            {
                switch (structType.Name)
                {
                    case "LinearColor":
                        value = new AsaLinearColor(archive);
                        return true;
                        
                    case "Quat":
                        value = new AsaQuat(archive);
                        return true;
                        
                    case "Vector":
                        value = new AsaVector(archive);
                        return true;
                        
                    case "Rotator":
                        value = new AsaRotator(archive);
                        return true;
                        
                    case "UniqueNetIdRepl":
                        if (AsaUniqueNetIdRepl.TryRead(archive, out var netId))
                        {
                            value = netId;
                            return true;
                        }
                        value = null;
                        return false;
                        
                    case "Color":
                        value = new AsaColor(archive);
                        return true;
                        
                    default:
                        // Not a known struct, read properties
                        var position = archive.Position;
                        var properties = new List<object>();
                        
                        while (TryReadProperty(archive, out var prop))
                        {
                            properties.Add(prop);
                        }

                        if (!inArray && archive.Position != position + dataSize)
                        {
                            // Size mismatch, might be an error
                        }

                        value = properties;
                        return true;
                }
            }
            catch
            {
                value = null;
                return false;
            }
        }

        private static bool TryReadArrayPropertyUE55(AsaName key, AsaArchive archive, AsaGenericType arrayElementType, [NotNullWhen(true)] out AsaPropertyArray? result)
        {
            try
            {
                var startPosition = archive.Position;
                var arrayLength = archive.ReadInt32("array length");
                var arrayTypeName = arrayElementType.TypeName.Name;

                if (arrayTypeName == "StructProperty")
                {
                    return TryReadStructArrayUE55(archive, key, arrayElementType, arrayLength, out result);
                }

                // Read simple array
                var array = new List<dynamic>();

                for (int i = 0; i < arrayLength; i++)
                {
                    if (TryReadPropertyValue(arrayElementType.TypeName, archive, out var item))
                    {
                        array.Add(item);
                    }
                    else
                    {
                        result = null;
                        return false;
                    }
                }

                result = new AsaPropertyArray(key.Name, array);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        private static bool TryReadStructArrayUE55(AsaArchive archive, AsaName key, AsaGenericType arrayElementType, int arrayLength, [NotNullWhen(true)] out AsaPropertyArray? result)
        {
            try
            {
                var structArray = new List<dynamic>();
                
                // In UE5.5, the struct type information is in the generic type subtypes
                // arrayElementType is StructProperty with subtypes
                AsaName structType = arrayElementType.SubTypes.Count > 0 
                    ? arrayElementType.SubTypes[0].TypeName 
                    : AsaName.NameNone;

                for (int i = 0; i < arrayLength; i++)
                {
                    if (TryReadStructPropertyValue(archive, 0, structType, true, out var structProperties))
                    {
                        structArray.Add(structProperties);
                    }
                    else
                    {
                        result = null;
                        return false;
                    }
                }

                result = new AsaPropertyArray(key.Name, structArray);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        private static bool TryReadMapProperty(AsaArchive archive, [NotNullWhen(true)] out dynamic? value)
        {
            try
            {
                if (!archive.TryReadName("key type", out var keyType) || !archive.TryReadName("value type", out var valueType))
                {
                    value = null;
                    return false;
                }

                var byteUnknown = archive.ReadByte("flags");
                var skipCount = archive.ReadInt32("skip count");
                var mapCount = archive.ReadInt32("entry count");

                var property = new List<AsaProperty<dynamic>>();

                for (int mapIndex = 0; mapIndex < mapCount; mapIndex++)
                {
                    switch (keyType.Name)
                    {
                        case "NameProperty":
                            if (TryReadStructMap(archive, keyType, valueType, out var structMapProp))
                            {
                                property.Add(structMapProp);
                            }
                            else
                            {
                                value = null;
                                return false;
                            }
                            break;

                        case "ObjectProperty":
                            if (AsaObjectReference.TryRead(archive, true, out var mapObjectRef))
                            {
                                archive.SkipBytes(1);
                            }
                            else
                            {
                                value = null;
                                return false;
                            }
                            break;

                        default:
                            if (!archive.TryReadName("property name", out var propertyName))
                            {
                                value = null;
                                return false;
                            }

                            var unknown0 = archive.ReadInt32("flags"); // 0
                            var propertyValues = new List<AsaProperty<dynamic>>();

                            while (true)
                            {
                                if (!archive.TryReadName("subkey name", out var subKeyName) || subKeyName.Equals(AsaName.NameNone))
                                {
                                    break;
                                }

                                if (!archive.TryReadName("subkey type", out var dataType))
                                {
                                    break;
                                }

                                var unknown1 = archive.ReadInt32("unknown1");
                                var unknown2 = archive.ReadInt32("size");
                                archive.SkipBytes(1);

                                if (TryReadPropertyValue(dataType, archive, out var keyValue))
                                {
                                    propertyValues.Add(new AsaProperty<dynamic>(subKeyName.Name, dataType.Name, 0, keyValue));
                                }
                            }

                            if (propertyValues.Count > 0)
                            {
                                property.Add(new AsaProperty<dynamic>(propertyName.Name, "PropertyList", 0, propertyValues));
                            }
                            break;
                    }
                }

                value = property;
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        private static bool TryReadStructMap(AsaArchive archive, AsaName keyType, AsaName valueType, [NotNullWhen(true)] out AsaProperty<dynamic>? result)
        {
            try
            {
                var propertyValues = new List<AsaProperty<dynamic>>();

                if (!TryReadPropertyValue(keyType, archive, out var keyName))
                {
                    result = null;
                    return false;
                }

                while (true)
                {
                    string? valueKeyName = null;

                    if (keyType.Name == "NameProperty")
                    {
                        if (!archive.TryReadName("value name", out var valueName) || valueName.Equals(AsaName.NameNone))
                        {
                            break;
                        }
                        valueKeyName = valueName.Name;
                    }
                    else
                    {
                        break;
                    }

                    if (!archive.TryReadName("value type", out var mapType))
                    {
                        break;
                    }

                    switch (mapType.Name)
                    {
                        case "SetProperty":
                            if (TryReadSetProperty(archive, out var mapValue))
                            {
                                propertyValues.Add(new AsaProperty<dynamic>(valueKeyName, mapType.Name, 0, mapValue));
                            }
                            break;
                    }
                }

                result = new AsaProperty<dynamic>(keyName, valueType.Name, 0, propertyValues);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        private static bool TryReadSetProperty(AsaArchive archive, [NotNullWhen(true)] out dynamic? value)
        {
            try
            {
                var values = new List<dynamic>();

                var setUnknownInt = archive.ReadInt32("size");
                var shouldBeZero = archive.ReadInt32("flags");
                
                if (!archive.TryReadName("element type", out var setType))
                {
                    value = null;
                    return false;
                }

                archive.SkipBytes(1);

                var objectSkipCount = archive.ReadInt32("skip count");
                var objectCount = archive.ReadInt32("count");

                for (int x = 0; x < objectCount; x++)
                {
                    if (TryReadPropertyValue(setType, archive, out var item))
                    {
                        values.Add(item);
                    }
                    else
                    {
                        value = null;
                        return false;
                    }
                }

                value = values;
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
}
