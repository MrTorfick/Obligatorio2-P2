using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class ActividadController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.flag = false;
            ViewBag.msg = "No hay actividades para la fecha de hoy";
            return View(s.GetActividades());


        }


        public IActionResult Search()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Search(DateTime fechaBuscar)
        {
            List<Actividad> listaFiltrada = s.GetActividadesFecha(fechaBuscar);
            if (listaFiltrada.Count == 0)
            {
                ViewBag.msg = "No se encontraron actividades";
            }

            return View(listaFiltrada);

        }



    }
}
