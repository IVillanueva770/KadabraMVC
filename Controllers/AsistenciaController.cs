using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadabraMVC.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly KadabraHCContext _context;

        public AsistenciaController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
