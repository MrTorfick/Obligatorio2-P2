using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class AgendaController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.msg = "No se encontraron agendas";
            ViewBag.idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Huesped")
            {
                ViewBag.Huesped = s.GetHuesped(ViewBag.idLogueado);
                return View(s.GetAgendas(ViewBag.idLogueado));
            }
            else if (ViewBag.Rol == "Operador")
            {
                ViewBag.flag = false;
                return View(s.GetAgendas());
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Create(int id)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");

            if (ViewBag.Rol == "Huesped")
            {
                ViewBag.Actividad = s.GetActividad(id);

                ViewBag.Huesped = s.GetHuesped(idLogueado);


                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(Agenda agenda, bool Check, int idActividad)
        {
            if (Check)
            {
                try
                {
                    Actividad actividad = s.GetActividad(idActividad);
                    int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
                    Huesped huesped = s.GetHuesped(idLogueado);
                    agenda.Actividad = actividad;
                    agenda.Huesped = huesped;
                    agenda.FechaCreacion = DateTime.Now;
                    s.AgendarHuespedActividad(agenda);
                    ViewBag.msg = $"Se agendo correctamente al huesped {huesped.Nombre} a la actividad {actividad.Nombre}";
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                }
            }

            return View();
        }


        public IActionResult SearchH()
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Operador")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");


        }

        [HttpPost]
        public IActionResult SearchH(int nroDocumento, TipoDocumento slcTipoDocumento)
        {
            IEnumerable<Agenda> agenda = s.GetAgendas(nroDocumento, slcTipoDocumento);
            if (agenda.Count() == 0)
            {
                ViewBag.msg = "No se encontraron agenda/s";
            }

            return View(agenda);
        }

        public IActionResult SearchF()
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Operador")
            {
                return View(s.GetAgendas());
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public IActionResult SearchF(DateTime fecha)
        {
            IEnumerable<Agenda> agendas = s.GetAgendas(fecha);
            if (agendas.Count() == 0)
            {
                ViewBag.msg = "No se encontraron agenda/s";
                ViewBag.Flag = false;
            }
            else
            {
                ViewBag.Flag = true;/*Se agrega este ViewBag, para cuando en la vista se muestren las agendas, aunque la fecha actual
                                     no sea la misma que la de ahora, entre igual a listar, ya que se realizo una busqueda para una fecha
                                     en especifico*/
            }
            return View(agendas);
        }




        public IActionResult Edit(int id)
        {
            ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            if (ViewBag.Rol == "Operador")
            {
                Agenda agenda = s.GetAgendaId(id);
                ViewBag.Id = agenda.Id;
                return View(agenda);
            }
            return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        public IActionResult Edit(int idAgenda, Agenda agenda, bool Check)
        {
            if (Check)
            {
                agenda = s.GetAgendaId(idAgenda);
                try
                {
                    agenda.EstadoAgenda = EstadoAgenda.Confirmada;
                    s.ConfirmarAgenda(agenda);
                    ViewBag.msg = "Agenda confirmada correctamente";
                }
                catch (Exception e)
                {

                    ViewBag.msg = e.Message;
                }
            }
            else
            {
                ViewBag.msg = "La agenda no ha sido confirmada";
            }
            return View();
        }
    }
}
