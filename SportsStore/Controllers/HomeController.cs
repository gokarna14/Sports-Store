using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

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

        public ViewResult Index(string? category, int productPage = 1)
          => View(new ProductsListViewModel
          {
              Products = repository.Products
            .Where(p => p.Category == category || category == null) 
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),

            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            },
            CurrentCategory = category
          });

    }
}