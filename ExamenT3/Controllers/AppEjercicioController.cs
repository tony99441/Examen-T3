using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenT3.Models;
using ExamenT3.PatronEstrategia;
using Microsoft.AspNetCore.Mvc;

namespace ExamenT3.Controllers
{
    public class AppEjercicioController : Controller
    {
        private AppEjerciciosContext context;
        patron _patron1 = new patron();

        public AppEjercicioController(AppEjerciciosContext context)
        {
            this.context = context;
         
        }
        // GET
        public IActionResult Index()
        {
            // Todas las rutinas del usuario
            var sesion = LoggedUser();
            var rutinas = context.rutinas.Where(o => o.IdUsuario == sesion.Id).ToList();
            return View(rutinas);
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
        public IActionResult CrearRutina()
        {
            var dificultades = Dificultad();
            ViewBag.Dificultades = dificultades;
            return View();
        }
        public IActionResult GuardarRutina(Rutina rutina)
        {
            var sesion = LoggedUser();
            Rutina nuevaRutina = new Rutina();
            nuevaRutina = rutina;
            nuevaRutina.FechaCreacion = DateTime.Now;
            nuevaRutina.IdUsuario = sesion.Id;
            context.rutinas.Add(nuevaRutina);
            context.SaveChanges();
            var rutina1 = context.rutinas.Where(o => o.IdUsuario == sesion.Id && o.Nombre == rutina.Nombre).FirstOrDefault();
            if (nuevaRutina.Dificultad == "Principiante")
            {
                _patron1.SetStrategy(new Principiante(context), rutina1.Id);
            }
            if (nuevaRutina.Dificultad == "Intermedio")
            {
                _patron1.SetStrategy(new Intermedio(context), rutina1.Id);
            }
            if (nuevaRutina.Dificultad == "Avanzado")
            {
                _patron1.SetStrategy(new Avanzado(context), rutina1.Id);
            }


            return RedirectToAction("Index");
        }

        private List<string> Dificultad()
        {
            List<string> dificultades = new List<string>();
            dificultades.Add("Principiante");
            dificultades.Add("Intermedio");
            dificultades.Add("Avanzado");
            return dificultades;
        }

        public IActionResult DetalleEjercicios(int IdRutina)
        {
            var rutina = context.rutinas.Where(o => o.Id == IdRutina).FirstOrDefault();
            var random = new Random();
            var mensaje = "";
            var aleatorio = random.Next(60,121);
            if (rutina.Dificultad == "Principiante")
            {
                 mensaje = "Principiante: El timpo de cada ejercicio es de:  " + aleatorio + "segundos";
            }
            if (rutina.Dificultad == "Intermedio")
            {
                 mensaje = "Intermedio: El timpo de cada ejercicio es de:  " + aleatorio + "segundos";
            }
            if (rutina.Dificultad == "Avanzado")
            {
                 mensaje = "Anvanzado: El timpo de cada ejercicio es de 120 segundos ";
            }
            ViewBag.Mensaje = mensaje; 
            var detalle = context.detalleEjercicioRutinas.Where(o => o.IdRutina == IdRutina).ToList();
                var detallesId = detalle.Select(o => o.Id).ToList();
            List<Ejercicios> NuevaLista = new List<Ejercicios>();
            var ejercicios = context.ejercicios.ToList();
            foreach (var item in ejercicios) {
                if (detallesId.Contains(item.Id)) {
                    NuevaLista.Add(item);
                }
            }
            return View(NuevaLista);
        }
        


    }
}