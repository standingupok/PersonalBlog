using Microsoft.AspNetCore.Mvc;

namespace PerBlog.Controllers
{
    public class IntroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
