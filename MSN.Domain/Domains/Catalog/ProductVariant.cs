using MSN.Framework.BaseModel;

namespace MSN.Domain.Domains.Catalog
{
    public class ProductVariant : BaseModel
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; } = default!;
        public decimal PriceDelta { get; private set; }
        public int StockDelta { get; private set; }
        public string? Description { get; private set; }

        public static ProductVariant Create(int id, string title, int productId, decimal priceDelta, int stockDelta, string? description, Product product)
        {
            if (priceDelta < 0)
                throw new ArgumentException("Price delta cannot be negative.");
            if (stockDelta < 0)
                throw new ArgumentException("Stock delta cannot be negative.");

            return new ProductVariant
            {
                Id = id,
                Title = title,
                ProductId = productId,
                PriceDelta = priceDelta,
                StockDelta = stockDelta,
                Description = description,
                Product = product
            };
        }

        public void UpdatePriceDelta(decimal newDelta)
        {
            if (newDelta < 0)
                throw new ArgumentException("Price delta cannot be negative.");
            PriceDelta = newDelta;
        }

        public void UpdateStockDelta(int newDelta)
        {
            if (newDelta < 0)
                throw new ArgumentException("Stock delta cannot be negative.");
            StockDelta = newDelta;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
        }
    }
}