namespace MSN.Domain.Domains.Catalog.Aggregates
{
    public sealed class OptionDefinition
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public bool IsRequired { get; private set; }
        private readonly List<string> _allowed = new();
        public IReadOnlyCollection<string> AllowedValues => _allowed;

        private OptionDefinition() { }
        public OptionDefinition(Guid productId, string name, bool required, IEnumerable<string> allowedValues)
        {
            if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            ProductId = productId;
            Name = name.Trim();
            IsRequired = required;
            _allowed.AddRange((allowedValues ?? Enumerable.Empty<string>())
                              .Select(v => v.Trim().ToUpperInvariant())
                              .Where(v => v.Length > 0)
                              .Distinct());
        }

        public bool IsAllowed(string value)
            => !_allowed.Any() || _allowed.Contains(value.Trim().ToUpperInvariant());
    }

}
