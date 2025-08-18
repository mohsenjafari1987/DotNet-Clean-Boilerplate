using MSN.Domain.Domains.Catalog.ValueObjects;
using MSN.Domain.Domains.Shared.ValueObjects;

namespace MSN.Domain.Domains.Catalog.Aggregates
{
    public sealed class ProductVariant
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public Sku Sku { get; private set; }
        public Money Price { get; private set; }
        public int Stock { get; private set; }

        private readonly List<SelectedOption> _options = new();
        public IReadOnlyCollection<SelectedOption> SelectedOptions => _options;

        private ProductVariant() { }
        internal ProductVariant(Guid productId, Sku sku, Money price, int stock,
                                IEnumerable<SelectedOption> options)
        {
            if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));
            if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock));

            ProductId = productId; Sku = sku; Price = price; Stock = stock;
            var list = (options ?? Enumerable.Empty<SelectedOption>()).ToList();

            if (list.GroupBy(o => o.OptionDefinitionId).Any(g => g.Count() > 1))
                throw new InvalidOperationException("Duplicate option per definition.");
            _options.AddRange(list);
        }

        public void AdjustStock(int delta)
        {
            var next = Stock + delta;
            if (next < 0) throw new InvalidOperationException("Stock cannot be negative.");
            Stock = next;
        }
    }
}