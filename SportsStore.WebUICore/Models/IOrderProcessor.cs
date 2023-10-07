namespace SportsStore.WebUICore.Models {

    public interface IOrderProcessor {

        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
