namespace RCommerce.Module.Products.Models
{
    public class ProductImage
    {
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int ImageId { set; get; }
        public Image Image { set; get; }
    }
}
