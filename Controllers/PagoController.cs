using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadabraMVC.Controllers
{
    public class PagoController : Controller
    {
        private readonly KadabraHCContext _context;

        public PagoController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
