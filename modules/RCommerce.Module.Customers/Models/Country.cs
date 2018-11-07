using Infrastructures.RepositoryEntities.Models;
using System.Collections.Generic;

namespace RCommerce.Module.Customers.Models
{
    public class Country : EntityBase
    {
        public string CountryIsoCode { set; get; }
        public string Name { get; set; }

        public string Code3 { get; set; }

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        public bool IsCityEnabled { get; set; } = true;

        public bool IsZipCodeEnabled { get; set; } = true;

        public bool IsDistrictEnabled { get; set; } = true;

        public IList<StateOrProvince> StatesOrProvinces { get; set; } = new List<StateOrProvince>();

    }
}
