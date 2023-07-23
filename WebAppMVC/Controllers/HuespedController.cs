using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class HuespedController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Huesped")
            {
                return View(s.GetHuesped(idLogueado));
            }

            return RedirectToAction("Index", "Home");

        }



        public IActionResult Register()
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Register(Huesped h, int slcTipoDocumento)
        {
            try
            {
                TipoDocumento tipoDoc = (TipoDocumento)slcTipoDocumento;
                h.TipoDocumento = tipoDoc;
                h.Nivel = 1;
                s.AltaUsuario(h);
                ViewBag.msg = "Registro correcto";
            }
            catch (Exception e)
            {

                ViewBag.msg = e.Message;
            }

            return View();

        }

    }
}
