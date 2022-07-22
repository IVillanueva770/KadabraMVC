using KadabraMVC.Models;
using KadabraMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Net;
using System.Net.Mail;

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
                var UsuarioLogin = new Usuario() //paso de LoginViewModel a Usuario
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
                    Response.Cookies.Append("UsuarioActual", UsuarioLogin.IdUsuario.ToString());

                    Thread.Sleep(500); //TODO: Aca falta terminar de acomodar la vista modal.
                    if (UsuarioLogin.Tipo.ToString() == "Administrativo")
                    {

                        Response.Cookies.Append("Usuario", UsuarioLogin.IdUsuario.ToString());

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

        public async Task<IActionResult> InicioProfesor()
        {
            int idProfesor = 23; //aca meto el id del usuario actual
            ViewBag.TipoUsuarioActual = idProfesor;
            var Clases = _context.Clases.Where(c => c.IdProfesor == idProfesor).ToListAsync();
            return View(await Clases);
        }

        public async Task<IActionResult> ProfesorHistorial()
        {
            int idProfesor = 23; //aca meto el id del usuario actual
            ViewBag.TipoUsuarioActual = idProfesor;
            var Clases = _context.Clases.Where(c => c.IdProfesor == idProfesor)
                .Where(c => c.HorarioClase.Day > DateTime.Today.Day)
                .ToListAsync();
            return View(await Clases);
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

            //Crea el mail
            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress("ignavillanueva961@saltacompra.gob.ar");
            mensaje.To.Add(NuevoUsuario.Mail);
            mensaje.Subject = "Confirmación";
            Random generator = new Random();
            String rnd = generator.Next(0, 1000000).ToString("D6");
            mensaje.Body = "Su código de verificacion es: " + rnd;
            mensaje.IsBodyHtml = false;

            //Manda el mail de confirmacion
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            NetworkCredential credenciales = new NetworkCredential();
            credenciales.UserName = "ignavillanueva961@gmail.com";
            credenciales.Password = "jeofohjxnwgdmsyj";
            smtp.Credentials = credenciales;
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.Send(mensaje);

            return Redirect(nameof(InicioAlumno));

        }

        #endregion








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


        public IActionResult UsuarioPerfil()
        {
            var id = 21; //acá tengo que hacer aparecer el id del usuario actual 
            Usuario userAMostrar = _context.Usuarios.Where(b => b.IdUsuario == id).First();

            return View(userAMostrar);
        }

        public IActionResult UsuarioClasesIndex()
        {

            return View();
        }
        public IActionResult SuscripcionAlumnos()
        {
            int id = 21; //acá tengo que hacer aparecer el id del usuario actual 
            var pagoaux = _context.Pagos.Where(b => b.IdAlumno == id).FirstOrDefault();
            if (pagoaux == null)
            {
                ViewBag.EstadoSuscripcion = "No existe un ultimo pago registrado";
                ViewBag.UltimoPagoRegistrado = "No existe un ultimo pago registrado";
                ViewBag.UltimoMesActivo = "No existe un ultimo pago registrado";
            }
            else
            {

                var DiasTranscurridos = (DateTime.Now - pagoaux.FyHRegistro).Days;

                if (DiasTranscurridos > 30 * pagoaux.CantidadMesesPagados)
                {
                    ViewBag.EstadoSuscripcion = "Vencido";
                }
                else if (DiasTranscurridos > 25 * pagoaux.CantidadMesesPagados && DiasTranscurridos < 30 * pagoaux.CantidadMesesPagados)
                {
                    ViewBag.EstadoSuscripcion = "Proximo a vencer";
                }
                else
                {
                    ViewBag.EstadoSuscripcion = "Activo";
                }

                ViewBag.UltimoPagoRegistrado = pagoaux.FyHRegistro;
                ViewBag.UltimoMesActivo = pagoaux.MesPagado;
            }
            return View(pagoaux);
        }

        public async Task<IActionResult> UsuarioAsistencias()
        {
            int idUsuario = 21;
            var Asistencias = _context.Asistencias
                .Where(c => c.IdAsistencia == idUsuario)
                //.Include(c => c.IdClaseNavigation.HorarioClase)
                .ToListAsync();
            return View(await Asistencias);
        }

        public async Task<IActionResult> AdminPagosIndex()
        {
            var pagos = _context.Pagos.ToListAsync();
            return View(await pagos);
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