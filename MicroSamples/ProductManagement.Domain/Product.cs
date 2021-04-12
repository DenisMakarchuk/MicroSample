using System;
using System.Collections.Generic;

namespace ProductManagement.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Coast { get; private set; }

        private HashSet<Order> _orders = new HashSet<Order>();
        public IReadOnlyCollection<Order> Orders => _orders;

        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }

        private Product()
        { }

        public Product(string name)
        {
            Update(name);
            CreatedDate = DateTime.UtcNow;
        }

        public void Update(string name)
        {
            Name = name;
            UpdatedDate = DateTime.UtcNow;
        }

        public void Delete()
        {
            DeletedDate = DateTime.UtcNow;
        }
    }
}
