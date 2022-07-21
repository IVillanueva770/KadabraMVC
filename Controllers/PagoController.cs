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

        //FormAdminAddPago

        public IActionResult FormAdminAddPago(int a)
        {
            //ViewData["Profesores"] = new SelectList(_context.Usuarios.Where(b => b.Tipo == "Profesor"), "IdUsuario", "Apellido"); //Para cargar el select
            return View();
        }




        //public async Task<IActionResult> NuevaClase(Clase model)
        //{
        //    ViewData["Profesores"] = new SelectList(_context.Usuarios.Where(b => b.Tipo == "Profesor"), "IdUsuario", "Apellido"); //Para recargar el Select cuando envían algo

        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("_NegativoVistaDePrueba", "Usuario");
        //    }
        //    else
        //    {
        //        var NuevaClase = new Clase()
        //        {
        //            HorarioClase = model.HorarioClase,
        //            IdProfesorNavigation = model.IdProfesorNavigation
        //        };

        //        _context.Add(NuevaClase);
        //        await _context.SaveChangesAsync();

        //        int a = 1;
        //        return View(nameof(FormAdminAddClase));
        //    }

        //}

    }
}
