using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Domain
{
    public class Account
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Description { get; private set; }

        private HashSet<Order> _orders = new HashSet<Order>();
        public IReadOnlyCollection<Order> Orders => _orders;

        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }

        public Account() { }

        public Account(Guid userId, string description)
        {
            UserId = userId;
            Update(description);
            CreatedDate = DateTime.UtcNow;
        }

        public void Update(string description)
        {
            Description = description;
            UpdatedDate = DateTime.UtcNow;
        }

        public void Delete()
        {
            DeletedDate = DateTime.UtcNow;
        }
    }
}
