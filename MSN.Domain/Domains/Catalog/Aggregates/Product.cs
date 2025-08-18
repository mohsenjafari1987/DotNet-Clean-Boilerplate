using MSN.Domain.Domains.Catalog.ValueObjects;
using MSN.Domain.Domains.Shared.ValueObjects;

namespace MSN.Domain.Domains.Catalog.Aggregates
{
    public sealed class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        private readonly List<OptionDefinition> _options = new();
        private readonly List<ProductVariant> _variants = new();

        public IReadOnlyCollection<OptionDefinition> OptionDefinitions => _options;
        public IReadOnlyCollection<ProductVariant> Variants => _variants;

        private Product() { }
        public Product(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            Name = name.Trim();
        }
        
        public OptionDefinition DefineOption(string name, bool required, IEnumerable<string> allowedValues)
        {
            var def = new OptionDefinition(Id, name, required, allowedValues);
            _options.Add(def);
            return def;
        }

        public ProductVariant AddVariant(Sku sku, Money price, int stock, IEnumerable<(Guid optionDefId, string value)> selections)
        {
            var selected = selections.Select(s => new SelectedOption(s.optionDefId, s.value)).ToList();

            if (selected.GroupBy(x => x.OptionDefinitionId).Any(g => g.Count() > 1))
                throw new InvalidOperationException("Duplicate option per definition.");

            foreach (var def in _options)
            {
                var pick = selected.FirstOrDefault(x => x.OptionDefinitionId == def.Id);
                if (def.IsRequired && pick is null)
                    throw new InvalidOperationException($"Missing required option: {def.Name}");
                if (pick is not null && !def.IsAllowed(pick.Value))
                    throw new InvalidOperationException($"Invalid value '{pick.Value}' for option '{def.Name}'");
            }

            if (_variants.Any(v => v.Sku.Equals(sku)))
                throw new InvalidOperationException($"SKU '{sku}' already exists.");

            var variant = new ProductVariant(Id, sku, price, stock, selected);
            _variants.Add(variant);
            return variant;
        }
    }
}