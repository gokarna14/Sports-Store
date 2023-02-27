using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index() => View();
    }
}