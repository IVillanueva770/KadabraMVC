using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadabraMVC.Controllers
{
    public class RegistroDeClaseController : Controller
    {
        private readonly KadabraHCContext _context;

        public RegistroDeClaseController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
