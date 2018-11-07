namespace RCommerce.Module.Customers.Models
{
    public class CustomerGroupUser
    {
        public long UserId { get; set; }
        public long CustomerGroupId { get; set; }
        public CustomerGroup CustomerGroup { get; set; }
    }
}
