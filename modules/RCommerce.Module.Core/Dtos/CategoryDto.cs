using System.Collections.Generic;

namespace RCommerce.Module.Core.Dtos
{
    public class CategoryWrapperDto
    {
        public IEnumerable<CategoryDto> Grouped { set; get; }
        public IEnumerable<CategoryDto> UnGrouped { set; get; }
    }
    public class CategoryDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int ParentId { set; get; }
        public string SKUPrefix { set; get; }
        public string ParentId_Id { set; get; }
        public IEnumerable<CategoryDto> Children { set; get; }
    }
}
