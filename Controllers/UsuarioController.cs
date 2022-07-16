using Microsoft.AspNetCore.Mvc;

namespace KadabraMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
