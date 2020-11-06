using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models
{
    public class Rutina { 
    
        public int Id { get; set; }
    public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public string Dificultad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<DetalleEjercicioRutina>detalleEjercicioRutina { get; set; }

        public Usuario usuario { get; set; }

    }
}
