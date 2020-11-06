using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamenT3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenT3.Controllers
{
    public class AuthController : Controller
    {
        private HttpContext httpContext;

        private AppEjerciciosContext context;


        public AuthController(AppEjerciciosContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = context.usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();



            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal);



                return RedirectToAction("Index", "AppEjercicio");
            }

            ViewBag.Validation = "Usuario o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult RegistrarUsuario() {


            return View();
        }

        public IActionResult GuardarUsuario(Usuario usuario)
        {
            Usuario usuarioNuevo = new Usuario();
            usuarioNuevo = usuario; 
            context.usuarios.Add(usuarioNuevo);
            context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}