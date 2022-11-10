using Microsoft.AspNetCore.Mvc;

namespace Broker.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
