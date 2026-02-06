using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaUniqueNetIdRepl
    {
        public string ValueType { get; init; }
        public string Value { get; init; }

        private AsaUniqueNetIdRepl(string valueType, string value)
        {
            ValueType = valueType;
            Value = value;
        }

        public static bool TryRead(AsaArchive archive, [NotNullWhen(true)] out AsaUniqueNetIdRepl? result)
        {
            try
            {
                using var _ = archive.Track("repl", "Unique net id replication");
                byte unknown = archive.ReadByte("flags");
                
                if (!archive.TryReadString("type", out var valueType))
                {
                    result = null;
                    return false;
                }

                int length = archive.ReadByte("length");
                byte[] bytes = archive.ReadBytes(length, "value");
                string value = Convert.ToHexString(bytes);

                result = new AsaUniqueNetIdRepl(valueType, value);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
