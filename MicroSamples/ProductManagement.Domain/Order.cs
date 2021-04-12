using System;
using System.Collections.Generic;

namespace ProductManagement.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }
        public string Description { get; private set; }

        private HashSet<Product> _products = new HashSet<Product>();
        public IReadOnlyCollection<Product> Products => _products;

        public decimal? TotalCoast { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }

        public Order() { }
        public Order(Guid accountId, IEnumerable<Product> products, string description)
        {
            AccountId = accountId;
            Update(products, description);
            CreatedDate = DateTime.UtcNow;
        }

        public void Update(IEnumerable<Product> products, string description)
        {
            foreach (var item in products)
            {
                _products.Add(item);
                TotalCoast += item.Coast;
            }
            Description = description;
            UpdatedDate = DateTime.UtcNow;
        }

        public void Delete()
        {
            DeletedDate = DateTime.UtcNow;
        }
    }
}
