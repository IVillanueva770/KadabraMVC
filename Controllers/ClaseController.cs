using KadabraMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KadabraMVC.Controllers;

namespace KadabraMVC.Controllers
{
    public class ClaseController : Controller
    {
        private readonly KadabraHCContext _context;

        public ClaseController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult FormAdminAddClase()
        {
            
            ViewData["Profesores"] = new SelectList(_context.Usuarios, "idUsuario", "apellido");
            return View();
            
        }
        public ActionResult NuevaClase()
        {
            //aca seria el guardado nomas 

            return RedirectToAction(nameof(UsuarioController.AdminClasesIndex));
        }


    }
}
