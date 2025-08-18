namespace MSN.Domain.Domains.Catalog.ValueObjects
{
    public readonly record struct Sku
    {
        public string Value { get; }
        public Sku(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("SKU required");
            Value = value.Trim().ToUpperInvariant();
        }
        public override string ToString() => Value;
    }
}
