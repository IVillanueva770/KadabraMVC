using KadabraMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace KadabraMVC.ViewModels
{
    public class NuevaClaseViewModel
    {
        public int IdClase { get; set; }

        public int? IdProfesor { get; set; }

        public DateTime HorarioClase { get; set; }

        public string? Estado { get; set; }

        public int Capacidad { get; set; }
    }
}
