namespace AsaSavegameToolkit.Properties
{
    public class AsaProperty<T>
    {
        public string Name { get; }
        public string Type { get; }
        public int Position { get; }
        public byte UnknownByte { get; }
        public T Value { get; }
        public long FileOffset { get; init; }
        public long FileLength { get; init; }

        public AsaProperty(string name, string type, int position, byte unknownByte, T value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Position = position;
            UnknownByte = unknownByte;
            Value = value;
        }

        public override string ToString()
        {
            var name = Position == 0 ? Name : $"{Name}[{Position}]";
            return $"Type: {Type}, Name: {name}, Value: {Value?.ToString() ?? "null"} [@{FileOffset:X8}+{FileLength}]";
        }
    }
}
