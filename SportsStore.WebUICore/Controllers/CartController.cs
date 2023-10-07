using SportsStore.WebUICore.Models;
using Microsoft.AspNetCore.Mvc;
using SportsStore.WebUICore.Infrastructure;

namespace SportsStore.WebUICore.Controllers {

    public class CartController : Controller {
        public IProductRepository repository;

        // public object Session { get; private set; }
        public Cart? Cart { get; set; }
        // private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repo) {
            this.repository = repo;
            // orderProcessor = proc;
        }


        public ViewResult Index(string returnUrl) {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return View(new CartIndexViewModel {
                ReturnUrl = returnUrl,
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart()
        });
        }

        public IActionResult AddToCart(int productId,  string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.RemoveLine(product);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart) {
            return PartialView(cart);
        }

        public ViewResult Checkout() {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
                return View("Completed");
            }

            if (ModelState.IsValid) {
                // orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            } else {
                return View(shippingDetails);
            }
        }
    }
}
