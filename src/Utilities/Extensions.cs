namespace AsaSavegameToolkit.Extensions
{
    public static class Extensions
    {
        private static readonly Dictionary<int, int> ArkGuidTranslation = new()
        {
            { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 },
            { 4, 6 }, { 5, 7 }, { 6, 4 }, { 7, 5 },
            { 8, 11 }, { 9, 10 }, { 10, 9 }, { 11, 8 },
            { 12, 15 }, { 13, 14 }, { 14, 13 }, { 15, 12 }
        };

        public static byte[] ToArkByteArray(this Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            byte[] result = new byte[16];

            foreach (var (key, value) in ArkGuidTranslation)
            {
                result[key] = bytes[value];
            }

            return result;
        }

        public static Guid ToArkGuid(this byte[] bytes)
        {
            ArgumentNullException.ThrowIfNull(bytes);
            if (bytes.Length != 16)
            {
                throw new ArgumentException("Byte array must be exactly 16 bytes", nameof(bytes));
            }

            byte[] temp = new byte[16];

            foreach (var (key, value) in ArkGuidTranslation)
            {
                temp[value] = bytes[key];
            }

            return new Guid(temp);
        }

        public static string ToHexString(this int value, string separator = "-") => BitConverter.GetBytes(value).ToHexString(separator, !BitConverter.IsLittleEndian);

        public static string ToHexString(this IEnumerable<byte> bytes, string separator = "-", bool reverse = false) => bytes.ToArray().ToHexString(separator, reverse);

        public static string ToHexString(this byte[] bytes, string separator = "-", bool reverse = false)
        {
            if (reverse)
            {
                var newBytes = new byte[bytes.Length];
                bytes.CopyTo(newBytes, 0);
                Array.Reverse(newBytes);
                bytes = newBytes;
            }

            var hexString = BitConverter.ToString(bytes);
            return separator == "-" ? hexString : hexString.Replace("-", separator);
        }
    }
}
