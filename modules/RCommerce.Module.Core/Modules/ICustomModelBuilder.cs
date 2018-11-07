using Microsoft.EntityFrameworkCore;

namespace RCommerce.Module.Core
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
