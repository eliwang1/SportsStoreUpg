using Microsoft.EntityFrameworkCore;

namespace SportsStore.WebUICore.Models {

    public class EFDbContext : DbContext {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}