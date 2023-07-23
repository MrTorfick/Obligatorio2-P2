using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class OperadorController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Operador")
            {
                int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
                return View(s.GetOperador(idLogueado));
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
