using AsaSavegameToolkit.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Types
{
    public class AsaObjectReference
    {
        private const int _typeUnknown = -1;
        private const int _typeId = 0;
        private const int _typePath = 1;
        private const int _typePathNoType = 2;
        private const int _typeName = 3;
        private const int _typeUuid = 4;

        private readonly int _type;
        private readonly object _value;

        public string Value => _value.ToString() ?? string.Empty;

        public AsaObjectReference(string objectValue)
        {
            ArgumentNullException.ThrowIfNull(objectValue);
            _type = _typePath;
            _value = objectValue;
        }

        public AsaObjectReference(Guid guid)
        {
            _type = _typeUuid;
            _value = guid.ToString();
        }

        private AsaObjectReference(int type, object value)
        {
            _type = type;
            _value = value;
        }

        public static bool TryRead(AsaArchive archive, bool useNameTable, [NotNullWhen(true)] out AsaObjectReference? result)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                if (useNameTable && archive.NameTable.Count > 0)
                {
                    bool isName = archive.ReadInt16("is name") == 1;
                    if (isName)
                    {
                        if (archive.TryReadName("name", out var name))
                        {
                            result = new AsaObjectReference(_typePath, name.ToString());
                            return true;
                        }
                    }
                    else
                    {
                        var guid = GuidExtensions.ToGuid(archive.ReadBytes(16, "guid"));
                        result = new AsaObjectReference(_typeUuid, guid);
                        return true;
                    }

                    result = null;
                    return false;
                }

                int objectType = archive.ReadInt32("type");

                if (objectType == -1)
                {
                    result = new AsaObjectReference(_typeUnknown, string.Empty);
                    return true;
                }
                else if (objectType == 0)
                {
                    int id = archive.ReadInt32("id");
                    result = new AsaObjectReference(_typeId, id);
                    return true;
                }
                else if (objectType == 1)
                {
                    if (archive.TryReadString("path", out var path))
                    {
                        result = new AsaObjectReference(_typePath, path);
                        return true;
                    }
                }
                else
                {
                    archive.SkipBytes(-4);
                    if (archive.TryReadString("path no type", out var path))
                    {
                        result = new AsaObjectReference(_typePathNoType, path);
                        return true;
                    }
                }

                result = null;
                return false;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
