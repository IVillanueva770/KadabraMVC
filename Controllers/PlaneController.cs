using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        public async Task<IActionResult> AdminPlanesIndex()
        {
            var Planes = await _context.Planes.ToListAsync();

            return View(Planes);
        }
    }
}
