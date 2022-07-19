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

        #region LoginYRegistro
        public IActionResult IndexLogin()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult ConsultarCredenciales(LoginViewModel model)
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

            return Redirect(nameof(IndexLogin));
        }

        #region Login_VistasSegunTipoUsuario
        public IActionResult InicioAdministrativo()
        {
            return View();
        }

        public IActionResult InicioAlumno()
        {
            return View();
        }

        public IActionResult InicioProfesor()
        {
            return View();
        }
        public IActionResult UsuarioSinTipo()
        {
            return View();
        }
        #endregion
        public IActionResult IndexRegistro(LoginViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> RegistrarAlumno(RegistroViewModel model) //esto es lo que pasa cuando aprieta el botón Registrarme
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

        #endregion

        //#region DiasSemana
        //public void Lunes()
        //{
        //    ViewBag.Prueba = "Lunes";
        //}

        //public void Martes()
        //{
        //    ViewBag.Prueba = "Martes";
        //}

        //public void Miercoles()
        //{
        //    ViewBag.Prueba = "Miercoles";
        //}

        //public void Jueves()
        //{
        //    ViewBag.Prueba = "Jueves";
        //}

        //public void Viernes()
        //{
        //    ViewBag.Prueba = "Viernes";
        //}
        //#endregion

        //#region VistasDePrueba
        //public IActionResult NegativoVistaDePrueba()
        //{
        //    return View();
        //}

        //public IActionResult PositivoVistaDePrueba()
        //{
        //    return View();
        //}
        //#endregion

        #region AdminProfesores
        public async Task<IActionResult> AdminProfesoresIndex()
        {
            var Profesores = await _context.Usuarios.Where(m => m.Tipo == "Profesor").ToListAsync();
            return View(Profesores);
        }

        public IActionResult formNuevoProfesor()
        {
            return View();
        }

        public async Task<IActionResult> RegistrarProfesor(RegistroViewModel model) //esto es lo que pasa cuando aprieta el botón Registrar nuevo profesor
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
                Tipo = "Profesor"
            };

            _context.Add(NuevoUsuario);
            await _context.SaveChangesAsync();
            return Redirect(nameof(AdminProfesoresIndex));

        }
        #endregion

        public async Task<IActionResult> AdminAlumnosIndex()
        {
            var Alumnos = await _context.Usuarios.Where(m => m.Tipo == "Alumno").ToListAsync();
            return View(Alumnos);
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