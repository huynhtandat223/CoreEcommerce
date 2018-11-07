using Infrastructures.RepositoryEntities.Models;
using RCommerce.Module.Customers.Entities;
using System;

namespace RCommerce.Module.Customers.Models
{
    public class UserAddress : EntityBase
    {
        public long UserId { get; set; }
        public long AddressId { get; set; }

        public virtual Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public DateTimeOffset? LastUsedOn { get; set; }
    }
}
