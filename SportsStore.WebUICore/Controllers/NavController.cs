using SportsStore.WebUICore.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.WebUICore.Controllers {

    public class NavController : Controller {
        private IProductRepository repository;

        public NavController(IProductRepository repo) {
            repository = repo;
        }

        public ViewResult Menu(string category = null) {

            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
                                    .Select(x => x.Category)
                                    .Distinct()
                                    .OrderBy(x => x);

            return View(categories);
        }
    }
}
