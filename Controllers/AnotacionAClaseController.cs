using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadabraMVC.Controllers
{
    public class AnotacionAClaseController : Controller
    {
        private readonly KadabraHCContext _context;

        public AnotacionAClaseController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
