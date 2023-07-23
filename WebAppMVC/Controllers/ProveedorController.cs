using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class ProveedorController : Controller
    {

        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");

            if (ViewBag.Rol == "Operador")
            {
                return View(s.GetProveedores());
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult IndexDescuento()
        {

            int? id = HttpContext.Session.GetInt32("LogueadoID");
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Operador")
            {
                ViewBag.Operador = s.GetOperador(id);

                return View(s.GetProveedoresDescuento());
            }
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Edit(int id)
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");

            if (ViewBag.Rol == "Operador")
            {
                Proveedor p = s.GetProveedor(id);
                return View(p);
            }

            return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        public IActionResult Edit(Proveedor p, bool check)
        {

            if (check)
            {
                try
                {
                    s.AplicarPromocionProveedor(p.Nombre, p.Descuento);
                    ViewBag.msg = "Se aplico la promocion correctamente";
                }
                catch (Exception e)
                {

                    ViewBag.msg = e.Message;
                }
            }
            else
            {
                ViewBag.msg = "La promocion no ha sido aplicada";
            }

            return View();
        }
    }
}
