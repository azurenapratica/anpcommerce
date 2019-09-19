using Microsoft.EntityFrameworkCore;

namespace ANPCommerce.Web.Models
{
    public class ANPCommerceWebContext : DbContext
    {
        public ANPCommerceWebContext(DbContextOptions<ANPCommerceWebContext> options)
            : base(options)
        {
        }

        public DbSet<ANPCommerce.Web.Models.Product> Product { get; set; }
        public DbSet<ANPCommerce.Web.Models.Banner> Banner { get; set; }
    }
}
