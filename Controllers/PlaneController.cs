using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadabraMVC.Controllers
{
    public class PlaneController : Controller
    {
        private readonly KadabraHCContext _context;

        public PlaneController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
