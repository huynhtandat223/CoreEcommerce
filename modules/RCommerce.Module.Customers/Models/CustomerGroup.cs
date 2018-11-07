using Infrastructures.RepositoryEntities.Models;
using System.Collections.Generic;

namespace RCommerce.Module.Customers.Models
{
    public class CustomerGroup : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public IList<CustomerGroupUser> Users { get; set; } = new List<CustomerGroupUser>();
    }
}
