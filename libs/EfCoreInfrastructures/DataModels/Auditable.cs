using System;

namespace EfCoreInfrastructures.DataModels
{
    public abstract class Auditable
    {
        public DateTime CreatedDate { set; get; }
        public DateTime ModifiedDate { set; get; }
        public string CreatedBy { set; get; }
        public string ModifiedBy { set; get; }
    }
}
