using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models
{
    public class DetalleEjercicioRutina
    {
        public int Id { get; set; }
        public int IdEjercicio { get; set; }
        public int IdRutina { get; set; }

        public Rutina rutina { get; set; }
        public Ejercicios ejercicio{ get; set; }
    }
}
