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
                if (!archive.TryReadName(out var keyName) || keyName.Equals(AsaName.NameNone))
                {
                    property = null;
                    return false;
                }

                if (!archive.TryReadName(out var valueTypeName))
                {
                    property = null;
                    return false;
                }

                var dataSize = archive.ReadInt32();
                var position = archive.ReadInt32();
                var startPosition = archive.Position;

                switch (valueTypeName.Name)
                {
                    case "BoolProperty":
                        if (TryReadPropertyValue(valueTypeName, archive, out var boolValue))
                        {
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, 0, boolValue);
                            return true;
                        }
                        break;

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
                        var unknownByte = archive.ReadByte();
                        if (TryReadPropertyValue(valueTypeName, archive, out var simpleValue))
                        {
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, unknownByte, simpleValue);
                            return true;
                        }
                        break;

                    case "StructProperty":
                        if (archive.TryReadName(out var structType))
                        {
                            var structUnknownByte = archive.ReadByte();
                            if (TryReadStructPropertyValue(archive, dataSize, structType, inArray, out var structValue))
                            {
                                property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, structUnknownByte, structValue);
                                return true;
                            }
                        }
                        else
                        {
                            archive.Position = startPosition;
                            archive.SkipBytes(dataSize);
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, 0, 0);
                            return true;
                        }
                        break;

                    case "ArrayProperty":
                        if (TryReadArrayProperty(keyName, position, archive, dataSize, out var arrayProp))
                        {
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, 0, arrayProp.Value);
                            return true;
                        }
                        break;

                    case "MapProperty":
                        try
                        {
                            if (TryReadMapProperty(archive, out var mapValue))
                            {
                                property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, 0, mapValue);
                                return true;
                            }
                        }
                        catch
                        {
                            archive.Position = startPosition;
                            archive.SkipBytes(dataSize);
                            property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, 0, 0);
                            return true;
                        }
                        break;

                    case "ByteProperty":
                        if (archive.TryReadName(out var byteType))
                        {
                            if (byteType.Equals(AsaName.NameNone))
                            {
                                property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, archive.ReadByte(), archive.ReadByte());
                            }
                            else
                            {
                                if (archive.TryReadName(out var byteValue))
                                {
                                    property = new AsaProperty<dynamic>(keyName.Name, valueTypeName.Name, position, archive.ReadByte(), byteValue);
                                }
                                else
                                {
                                    property = null;
                                    return false;
                                }
                            }
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
                        value = archive.ReadByte();
                        return true;
                        
                    case "DoubleProperty":
                        value = archive.ReadDouble();
                        return true;
                        
                    case "FloatProperty":
                        value = archive.ReadSingle();
                        return true;
                        
                    case "IntProperty":
                        value = archive.ReadInt32();
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
                        if (archive.TryReadString(out var strVal))
                        {
                            value = strVal;
                            return true;
                        }
                        value = null;
                        return false;
                        
                    case "NameProperty":
                        if (archive.TryReadName(out var name))
                        {
                            value = name.ToString();
                            return true;
                        }
                        value = null;
                        return false;
                        
                    case "UInt32Property":
                        value = (uint)archive.ReadInt32();
                        return true;
                        
                    case "UInt64Property":
                        value = (ulong)archive.ReadInt64();
                        return true;
                        
                    case "UInt16Property":
                        value = (ushort)archive.ReadInt16();
                        return true;
                        
                    case "Int16Property":
                        value = archive.ReadInt16();
                        return true;
                        
                    case "Int64Property":
                        value = archive.ReadInt64();
                        return true;
                        
                    case "BoolProperty":
                        value = archive.ReadInt16() == 1;
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
            if (archive.TryReadName(out var objectName) && archive.TryReadName(out var objectValue))
            {
                value = new AsaProperty<dynamic>(objectName.ToString(), "Propertiestr", 0, 0, objectValue);
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

        private static bool TryReadArrayProperty(AsaName key, int position, AsaArchive archive, int dataSize, [NotNullWhen(true)] out AsaPropertyArray? result)
        {
            try
            {
                if (!archive.TryReadName(out var arrayType))
                {
                    result = null;
                    return false;
                }

                var endOfStruct = archive.ReadByte();
                var arrayLength = archive.ReadInt32();
                var startOfArrayValuesPosition = archive.Position;

                if (arrayType.Name == "StructProperty")
                {
                    return TryReadStructArray(archive, arrayType, arrayLength, out result);
                }

                // Read simple array
                var expectedEndOfArrayPosition = startOfArrayValuesPosition + dataSize - 4;
                var array = new List<dynamic>();

                try
                {
                    for (int i = 0; i < arrayLength; i++)
                    {
                        if (TryReadPropertyValue(arrayType, archive, out var item))
                        {
                            array.Add(item);
                        }
                        else
                        {
                            // Failed to read item
                            break;
                        }
                    }

                    if (expectedEndOfArrayPosition != archive.Position)
                    {
                        var skipBytes = expectedEndOfArrayPosition - archive.Position;
                        archive.SkipBytes((int)skipBytes);
                    }
                }
                catch (Exception)
                {
                    archive.Position = startOfArrayValuesPosition;
                    string content = Convert.ToHexString(archive.ReadBytes(dataSize - 4));
                    array.Add(content);
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

        private static bool TryReadStructArray(AsaArchive archive, AsaName arrayType, int arrayLength, [NotNullWhen(true)] out AsaPropertyArray? result)
        {
            try
            {
                var structArray = new List<dynamic>();

                if (!archive.TryReadName(out var name) || !archive.TryReadName(out var type))
                {
                    result = null;
                    return false;
                }

                var dataSize = archive.ReadInt32();
                var position = archive.ReadInt32();
                
                if (!archive.TryReadName(out var structType))
                {
                    result = null;
                    return false;
                }

                var unknownByte = archive.ReadByte();
                archive.SkipBytes(16);

                for (int i = 0; i < arrayLength; i++)
                {
                    if (TryReadStructPropertyValue(archive, dataSize, type, true, out var structProperties))
                    {
                        structArray.Add(structProperties);
                    }
                    else
                    {
                        result = null;
                        return false;
                    }
                }

                result = new AsaPropertyArray(name.Name, structArray);
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
                if (!archive.TryReadName(out var keyType) || !archive.TryReadName(out var valueType))
                {
                    value = null;
                    return false;
                }

                var byteUnknown = archive.ReadByte();
                var skipCount = archive.ReadInt32();
                var mapCount = archive.ReadInt32();

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
                            if (!archive.TryReadName(out var propertyName))
                            {
                                value = null;
                                return false;
                            }

                            var unknown0 = archive.ReadInt32(); // 0
                            var propertyValues = new List<AsaProperty<dynamic>>();

                            while (true)
                            {
                                if (!archive.TryReadName(out var subKeyName) || subKeyName.Equals(AsaName.NameNone))
                                {
                                    break;
                                }

                                if (!archive.TryReadName(out var dataType))
                                {
                                    break;
                                }

                                var unknown1 = archive.ReadInt32();
                                var unknown2 = archive.ReadInt32();
                                archive.SkipBytes(1);

                                if (TryReadPropertyValue(dataType, archive, out var keyValue))
                                {
                                    propertyValues.Add(new AsaProperty<dynamic>(subKeyName.Name, dataType.Name, 0, 0, keyValue));
                                }
                            }

                            if (propertyValues.Count > 0)
                            {
                                property.Add(new AsaProperty<dynamic>(propertyName.Name, "PropertyList", 0, 0, propertyValues));
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
                        if (!archive.TryReadName(out var valueName) || valueName.Equals(AsaName.NameNone))
                        {
                            break;
                        }
                        valueKeyName = valueName.Name;
                    }
                    else
                    {
                        break;
                    }

                    if (!archive.TryReadName(out var mapType))
                    {
                        break;
                    }

                    switch (mapType.Name)
                    {
                        case "SetProperty":
                            if (TryReadSetProperty(archive, out var mapValue))
                            {
                                propertyValues.Add(new AsaProperty<dynamic>(valueKeyName, mapType.Name, 0, 0, mapValue));
                            }
                            break;
                    }
                }

                result = new AsaProperty<dynamic>(keyName, valueType.Name, 0, 0, propertyValues);
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

                var setUnknownInt = archive.ReadInt32();
                var shouldBeZero = archive.ReadInt32();
                
                if (!archive.TryReadName(out var setType))
                {
                    value = null;
                    return false;
                }

                archive.SkipBytes(1);

                var objectSkipCount = archive.ReadInt32();
                var objectCount = archive.ReadInt32();

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
