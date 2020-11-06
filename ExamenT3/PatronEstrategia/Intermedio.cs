using ExamenT3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.PatronEstrategia
{
    public class Intermedio : IEstrategiaPatron
    {
        private AppEjerciciosContext context;

        public Intermedio(AppEjerciciosContext context)
        {
            this.context = context;
        }
        public void EjerciciosParaRutina(int IdRutina)
        {
            var random = new Random();

            List<int> numerosAleatorios = new List<int>();

            do
            {
                var numeroNuevo = random.Next(1, 21);
                if (!numerosAleatorios.Contains(numeroNuevo))
                {
                    numerosAleatorios.Add(numeroNuevo);
                    DetalleEjercicioRutina nuevoDetalle = new DetalleEjercicioRutina();
                    nuevoDetalle.IdEjercicio = numeroNuevo;
                    nuevoDetalle.IdRutina = IdRutina;
                    context.detalleEjercicioRutinas.Add(nuevoDetalle);
                    context.SaveChanges();
                }
            } while (numerosAleatorios.Count < 10);

        }
    }
}