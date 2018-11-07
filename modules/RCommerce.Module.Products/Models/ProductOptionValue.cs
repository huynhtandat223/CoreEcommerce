namespace RCommerce.Module.Products.Models
{
    public class ProductOptionValue
    {
        public int OptionId { get; set; }

        public ProductOption Option { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Value { get; set; }
        public int ProductOptionValudeDefaultId { set; get; }

    }
}
