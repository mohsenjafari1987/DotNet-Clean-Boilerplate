using MSN.Domain.Domains.Catalog.Aggregates;

namespace MSN.Domain.Domains.Catalog.ValueObjects
{
    public sealed record SelectedOption
    {
        public Guid OptionDefinitionId { get; }
        public string Value { get; } // normalized

        public SelectedOption(Guid optionDefinitionId, string value)
        {
            if (optionDefinitionId == Guid.Empty) throw new ArgumentException(nameof(optionDefinitionId));
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));
            OptionDefinitionId = optionDefinitionId;
            Value = value.Trim().ToUpperInvariant();
        }
    }
}
