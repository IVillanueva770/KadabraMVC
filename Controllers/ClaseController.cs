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


        public async Task<IActionResult> AdminClasesIndex(DayOfWeek filtro)
        {


            var Clases = _context.Clases //aca tengo todas las clases
                                         //.Where(c => c.HorarioClase.DayOfWeek.ToString() == filtro.ToString()) //aca tengo las clases del día que me piden
                            .Where(c => c.HorarioClase.Day > DateTime.Today.Day)
                            .ToListAsync(); //aca me encargo de que no muestre clases que ya pasaron
            var dia = DateTime.Today.DayOfWeek.ToString();




            return View(await Clases);
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

        #region DiasSemana
        public async void Lunes()
        {

            await AdminClasesIndex(DayOfWeek.Monday);
        }

        public async void Martes()
        {
            await AdminClasesIndex(DayOfWeek.Tuesday);
        }

        public async void Miercoles()
        {

            await AdminClasesIndex(DayOfWeek.Wednesday);
        }

        public async void Jueves()
        {

            await AdminClasesIndex(DayOfWeek.Thursday);
        }

        public async void Viernes()
        {

            await AdminClasesIndex(DayOfWeek.Friday);
        }
        #endregion

        #region VistasDePrueba
        public IActionResult NegativoVistaDePrueba()
        {
            return View();
        }

        public IActionResult PositivoVistaDePrueba()
        {
            return View();
        }
        #endregion


    }
}



