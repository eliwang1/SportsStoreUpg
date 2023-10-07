namespace SportsStore.WebUICore.Models {

    public class EFProductRepository : IProductRepository {
        private EFDbContext context;
        public EFProductRepository(EFDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products {
            get { return context.Products; }
        }
    }
}