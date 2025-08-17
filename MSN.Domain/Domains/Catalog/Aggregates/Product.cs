using MSN.Domain.Exceptions;
using MSN.Framework.BaseModel;

namespace MSN.Domain.Domains.Catalog.Aggregates
{
    public class Product : BaseModel
    {
        public decimal Price { get; private set; }
        public string? Description { get; private set; }
        public int Stock { get; private set; }
        public int CreatedById { get; private set; }
        

        public static Product Create(int id, string title, decimal price, int stock, string? description)
        {
            if (price < 0)
                throw new DomainException("Price cannot be negative.");
            
            if (stock < 0)
                throw new DomainException("Stock cannot be negative.");

            var product = new Product
            {
                Id = id,
                Title = title,
                Price = price,
                Stock = stock,
                Description = description,
            };

            return product;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new DomainException("Price cannot be negative.");

            Price = newPrice;
        }

        public void UpdateStock(int quantity)
        {
            if (Stock + quantity < 0)
                throw new DomainException("Cannot reduce stock below zero.");

            Stock += quantity;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
        }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title cannot be null or empty.");

            Title = title;
        }
    }
}