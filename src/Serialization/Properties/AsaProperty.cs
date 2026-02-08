namespace AsaSavegameToolkit.Serialization.Properties
{
    public class AsaProperty<T>
    {
        public string Name { get; }
        public string Type { get; }
        public int Index { get; }
        public T Value { get; }

        public AsaProperty(string name, string type, int index, T value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Index = index;
            Value = value;
        }

        public override string ToString()
        {
            var name = Index == 0 ? Name : $"{Name}[{Index}]";
            return $"Type: {Type}, Name: {name}, Value: {Value?.ToString() ?? "null"}";
        }
    }
}
