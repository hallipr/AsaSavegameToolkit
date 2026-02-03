using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AsaSavegameToolkit.Types
{
    public sealed class AsaName : IComparable<AsaName>, IComparable, IEquatable<AsaName>
    {
        private readonly string _content;

        public string Name { get; }
        public int Instance { get; }

        private static readonly Regex NameIndexPattern = new(@"^(.*)_([0-9]+)$");
        
        private static ThreadLocal<IDictionary<string, AsaName>> _nameCache = new(() => new Dictionary<string, AsaName>());
        private static readonly Dictionary<string, AsaName> _constantNameCache = [];

        public static readonly AsaName NameNone = ConstantPlain("None");

        private AsaName(string content)
        {
            _content = content;

            Match matcher = NameIndexPattern.Match(_content);
            if (matcher.Success)
            {
                Name = matcher.Groups[1].Value;
                Instance = int.Parse(matcher.Groups[2].Value) + 1;
            }
            else
            {
                Name = _content;
                Instance = 0;
            }
        }

        private AsaName(string name, int instance, string content)
        {
            Name = name;
            Instance = instance;
            _content = content;
        }

        #region Factory Methods

        public static AsaName From(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            var cache = _nameCache.Value!;
            if (!cache.TryGetValue(name, out var value))
            {
                value = new AsaName(name);
                cache.Add(name, value);
            }
            return value;
        }

        public static AsaName From(string name, int instance)
        {
            ArgumentNullException.ThrowIfNull(name);
            
            string instanceName = instance == 0 ? name : $"{name}_{instance - 1}";

            var cache = _nameCache.Value!;
            if (!cache.TryGetValue(instanceName, out var value))
            {
                value = new AsaName(name, instance, instanceName);
                cache.Add(instanceName, value);
            }
            return value;
        }

        public static AsaName FromPlain(string name) => From(name, 0);

        public static AsaName Constant(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            
            var cache = _nameCache.Value!;
            if (!cache.TryGetValue(name, out var value))
            {
                value = new AsaName(name);
                cache.Add(name, value);
            }
            _constantNameCache[name] = value;
            return value;
        }

        public static AsaName Constant(string name, int instance)
        {
            ArgumentNullException.ThrowIfNull(name);
            
            string instanceName = instance == 0 ? name : $"{name}_{instance - 1}";
            
            var cache = _nameCache.Value!;
            if (!cache.TryGetValue(instanceName, out var value))
            {
                value = new AsaName(name, instance, instanceName);
                cache.Add(instanceName, value);
            }
            _constantNameCache[instanceName] = value;
            return value;
        }

        public static AsaName ConstantPlain(string name) => Constant(name, 0);

        public static bool TryFrom(string? name, [NotNullWhen(true)] out AsaName? result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result = null;
                return false;
            }

            result = From(name);
            return true;
        }

        public static bool TryFrom(string? name, int instance, [NotNullWhen(true)] out AsaName? result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result = null;
                return false;
            }

            result = From(name, instance);
            return true;
        }

        #endregion

        public static void ClearCache()
        {
            _nameCache = new ThreadLocal<IDictionary<string, AsaName>>(() => new Dictionary<string, AsaName>());
        }

        public override string ToString() => _content;

        #region Equality

        public override int GetHashCode() => _content.GetHashCode();

        public override bool Equals(object? other)
        {
            return other is AsaName name && Equals(name);
        }

        public bool Equals(AsaName? other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || string.Equals(_content, other._content);
        }

        public static bool operator ==(AsaName? left, AsaName? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AsaName? left, AsaName? right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Comparison

        public int CompareTo(AsaName? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            return string.Compare(_content, other._content, StringComparison.Ordinal);
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is AsaName other 
                ? CompareTo(other) 
                : throw new ArgumentException($"Object must be of type {nameof(AsaName)}");
        }

        public static bool operator <(AsaName? left, AsaName? right)
        {
            return Comparer<AsaName>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(AsaName? left, AsaName? right)
        {
            return Comparer<AsaName>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(AsaName? left, AsaName? right)
        {
            return Comparer<AsaName>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(AsaName? left, AsaName? right)
        {
            return Comparer<AsaName>.Default.Compare(left, right) >= 0;
        }

        #endregion
    }
}
