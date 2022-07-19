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


        public async Task<IActionResult> AdminClasesIndex()
        {
            var Clases = _context.Clases;
            return View(await Clases.ToListAsync());
        }
        public IActionResult FormAdminAddClase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormAdminAddClase(int a)
        {
            ViewData["Profesores"] = new SelectList(_context.Usuarios.Where(b => b.Tipo == "Profesor"), "IdUsuario", "Apellido"); //Para cargar el select
            return View();
        }

        public async Task<IActionResult> NuevaClase(Clase model)
        {
            ViewData["Profesores"] = new SelectList(_context.Usuarios.Where(b => b.Tipo == "Profesor"), "IdUsuario", "Apellido"); //Para recargar el Select cuando envían algo

            if (!ModelState.IsValid)
            {
                return RedirectToAction("_NegativoVistaDePrueba", "Usuario");
            }
            else
            {
                var NuevaClase = new Clase()
                {
                    HorarioClase = model.HorarioClase,
                    IdProfesorNavigation = model.IdProfesorNavigation
                };

                _context.Add(NuevaClase);
                await _context.SaveChangesAsync();

                int a = 1;
                return View(nameof(FormAdminAddClase));
            }

        }

    }
}



