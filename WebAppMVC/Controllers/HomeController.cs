using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string clave)
        {
            Usuario uBuscado = s.Login(correo, clave);

            if (uBuscado != null)
            {
                HttpContext.Session.SetInt32("LogueadoID", uBuscado.Id);
                HttpContext.Session.SetString("LogueadoRol", uBuscado.GetTipo());
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.msg = "Datos incorrectos";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}