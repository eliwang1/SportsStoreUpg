namespace SportsStore.WebUICore.Models {
    public interface IProductRepository {

        IEnumerable<Product> Products { get; }
    }
}