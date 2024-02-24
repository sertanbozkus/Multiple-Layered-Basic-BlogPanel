using Microsoft.AspNetCore.Mvc;

namespace BilgeBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List" , "Post");

            // Home/Index bizi Post Controller içerisindeki List Action'a yönlendiriyor.
        }
    }
}
