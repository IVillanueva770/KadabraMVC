using KadabraMVC.Models;
using KadabraMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace KadabraMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly KadabraHCContext _context;

        public UsuarioController(KadabraHCContext context)
        {
            _context = context;
        }
        public IActionResult IndexLogin()
        {
            return View();
        }



        [ValidateAntiForgeryToken]
        public ActionResult ConsultarCredenciales(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UsuarioLogin = new Usuario()
                {
                    Mail = model.Mail,
                    Contraseña = model.Contraseña,
                };

                var UsuariosQueCoinciden = from q in _context.Usuarios
                                           where q.Mail == UsuarioLogin.Mail && q.Contraseña == UsuarioLogin.Contraseña
                                           select q;

                if (UsuariosQueCoinciden.Any()) //Si devolvió algún usuario, Establezco ese usuario como mi usuario actual global.
                {

                    UsuarioLogin = UsuariosQueCoinciden.First();
                    ViewBag.UsuarioActual = UsuarioLogin;


                    Thread.Sleep(500); //TODO: Aca falta terminar de acomodar la vista modal.
                    if (UsuarioLogin.Tipo.ToString() == "Administrativo")
                    {
                        return Redirect(nameof(InicioAdministrativo));
                    }
                    else if (UsuarioLogin.Tipo.ToString() == "Profesor")
                    {
                        return Redirect(nameof(InicioProfesor));
                    }
                    else if (UsuarioLogin.Tipo.ToString() == "Alumno")
                    {
                        return Redirect(nameof(InicioAlumno));
                    }
                    else
                    {
                        return Redirect(nameof(UsuarioSinTipo));
                    }



                }
                else
                {

                }
            }
            @ViewBag.UsuariosLoggeados = 0;
            return Redirect(nameof(Index));
        }

        public ActionResult IndexRegistro(LoginViewModel model)
        {
            return View();
        }

        public async Task<ActionResult> RegistrarAlumno(RegistroViewModel model) //esto es lo que pasa cuando aprieta el botón Registrarme
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var NuevoUsuario = new Usuario()
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Dni = model.Dni,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                Mail = model.Mail,
                Contraseña = model.Contraseña,
                ClasesRestantes = 0,
                Tipo = "Alumno"
            };

            _context.Add(NuevoUsuario);
            await _context.SaveChangesAsync();
            return Redirect(nameof(InicioAlumno));

        }

        #region VistasSegunTipoUsuario
        public ActionResult InicioAdministrativo()
        {
            return View();
        }

        public ActionResult InicioAlumno()
        {
            return View();
        }

        public ActionResult InicioProfesor()
        {
            return View();
        }
        public ActionResult UsuarioSinTipo()
        {
            return View();
        }
        #endregion

        #region DiasSemana
        public void Lunes()
        {
            ViewBag.Prueba = "Lunes";
        }

        public void Martes()
        {
            ViewBag.Prueba = "Martes";
        }

        public void Miercoles()
        {
            ViewBag.Prueba = "Miercoles";
        }

        public void Jueves()
        {
            ViewBag.Prueba = "Jueves";
        }

        public void Viernes()
        {
            ViewBag.Prueba = "Viernes";
        }
        #endregion

        #region VistasDePrueba
        public ActionResult NegativoVistaDePrueba()
        {
            return View();
        }

        public ActionResult PositivoVistaDePrueba()
        {
            return View();
        }
        #endregion

        public async Task<ActionResult> AdminProfesoresIndex()
        {
            var Profesores = await _context.Usuarios.Where(m => m.Tipo == "Profesor").ToListAsync();
            return View(Profesores);
        }

        public async Task<ActionResult> AdminClasesIndex()
        {
            var Clases = await _context.Clases.ToListAsync();
            return View(Clases);
        }
        public ActionResult AdminAlumnosIndex()
        {
            return View();
        }
        public ActionResult AdminArancelesIndex()
        {
            return View();
        }
    }




}



//Estaba en AdminClasesIndex
//Esto es un intento de hacer que en la tabla de Clases aparezca el nombre del profesor y no el ID. 
            //foreach (var clase in Clases)
            //{
            //    int? idProf = clase.IdProfesor;
            //    var profesor = from p in _context.Usuarios
            //                     where p.IdUsuario == idProf
            //                     select p;
            //    string NombreProf = profesor.First().Nombre;

            //} 