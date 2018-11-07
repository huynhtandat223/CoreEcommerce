namespace RCommerce.Module.Products.Models
{
    public class ProductCategory
    {
        public int ProductId { set; get; }
        public int CategoryId { set; get; }
        public Product Product { set; get; }
        public Category Category { set; get; }
    }
}
