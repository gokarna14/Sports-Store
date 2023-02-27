using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            this.repository = repo;
        }

        // public IActionResult Index() => View(repository.Products);

        public ViewResult Index(int productPage = 1) 
        => View(repository.Products
        .OrderBy(p => p.ProductID)
        .Skip((productPage<=0 ? 1 : productPage - 1) * PageSize)
        .Take(PageSize)
        );
        
    }
}