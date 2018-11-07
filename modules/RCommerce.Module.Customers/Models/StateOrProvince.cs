using Infrastructures.RepositoryEntities.Models;

namespace RCommerce.Module.Customers.Models
{
    public class StateOrProvince : EntityBase
    {
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
