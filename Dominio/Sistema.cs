using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dominio
{
    public class Sistema
    {

        private List<Usuario> _usuarios { get; } = new List<Usuario>();
        private List<Actividad> _actividades { get; } = new List<Actividad>();
        private List<Agenda> _agendas { get; } = new List<Agenda>();
        private List<Proveedor> _proveedores { get; } = new List<Proveedor>();
        private static Sistema _instancia;



        #region Singleton
        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }
        #endregion

        private Sistema()
        {
            PrecargarUsuarios();
            PrecargarProveedores();
            PrecargarActividades();
            PrecargarAgendas();

        }

        #region Precargas
        private void PrecargarUsuarios()
        {
            //Huesped
            Huesped huesped1 = new Huesped(TipoDocumento.Ci, 53085035, "NombreHuesped1", "ApellidoHuesped1", "102", 50, new DateTime(1973, 05, 01), 2, "correo@huesped1.com", "contraseniahuesped1");
            AltaUsuario(huesped1);

            //Operador
            Operador operador1 = new Operador("correo1@operador1.com", "contraseniaoperador1", "ApellidoOperador1", "NombreOperador1", new DateTime(2022, 03, 05));
            Operador operador2 = new Operador("correo2@operador2.com", "contraseniaoperador2", "ApellidoOperador2", "NombrreOperador2", new DateTime(2021, 05, 15));
            AltaUsuario(operador1);
            AltaUsuario(operador2);
            huesped1.ValidarCedula();


        }
        private void PrecargarProveedores()
        {
            AltaProveedor(new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10));
            AltaProveedor(new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7));
            AltaProveedor(new Proveedor("TravelFun", "29152020", "Misiones 1140", 9));
            AltaProveedor(new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 21));
            AltaProveedor(new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10));
            AltaProveedor(new Proveedor("Electric Blue", "26018945", "Cooper 678", 5));
            AltaProveedor(new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4));
            AltaProveedor(new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 30));
            AltaProveedor(new Proveedor("Proveedor1", "22041120", "Agraciada 2512 Apto. 1", 8));
            AltaProveedor(new Proveedor("Norberto Molina", "22001189", "Paraguay 2100", 9));
        }

        private void PrecargarActividades()                                                                                                                 //yyyy/mm/dd
        {
            //Actividades Hostal
            ActividadHostal actividadHostal1 = new ActividadHostal("PersonaResponsable1", "Lugar1", true, "NombreActHostal1", "DescripcionActividadHostal1", new DateTime(2024, 10, 15), 75, 18, 200);
            ActividadHostal actividadHostal2 = new ActividadHostal("PersonaResponsable2", "Lugar2", false, "NombreActHostal2", "DescripcionActividadHostal2", new DateTime(2023, 08, 25), 30, 18, 750);
            ActividadHostal actividadHostal3 = new ActividadHostal("PersonaResponsable3", "Lugar3", true, "NombreActHostal3", "DescripcionActividadHostal3", new DateTime(2023, 07, 20), 22, 18);
            ActividadHostal actividadHostal4 = new ActividadHostal("PersonaResponsable4", "Lugar4", true, "NombreActHostal4", "DescripcionActividadHostal4", new DateTime(2023, 07, 14), 33, 12, 170);
            ActividadHostal actividadHostal5 = new ActividadHostal("PersonaResponsable5", "Lugar5", true, "NombreActHostal5", "DescripcionActividadHostal5", DateTime.Now, 52, 14, 150);
            ActividadHostal actividadHostal6 = new ActividadHostal("PersonaResponsable6", "Lugar6", false, "NombreActHostal6", "DescripcionActividadHostal6", new DateTime(2023, 06, 30), 15, 21, 50);
            ActividadHostal actividadHostal7 = new ActividadHostal("PersonaResponsable7", "Lugar7", false, "NombreActHostal7", "DescripcionActividadHostal7", new DateTime(2024, 10, 08), 64, 22, 150);
            ActividadHostal actividadHostal8 = new ActividadHostal("PersonaResponsable8", "Lugar8", false, "NombreActHostal8", "DescripcionActividadHostal8", DateTime.Now, 43, 16, 1500);
            ActividadHostal actividadHostal9 = new ActividadHostal("PersonaResponsable9", "Lugar9", true, "NombreActHostal9", "DescripcionActividadHostal9", new DateTime(2024, 10, 08), 90, 18);
            ActividadHostal actividadHostal10 = new ActividadHostal("PersonaResponsable10", "Lugar10", true, "NombreActHostal10", "DescripcionActividadHostal10", new DateTime(2024, 12, 29), 75, 8);

            AltaActividad(actividadHostal1);
            AltaActividad(actividadHostal2);
            AltaActividad(actividadHostal3);
            AltaActividad(actividadHostal4);
            AltaActividad(actividadHostal5);
            AltaActividad(actividadHostal6);
            AltaActividad(actividadHostal7);
            AltaActividad(actividadHostal8);
            AltaActividad(actividadHostal9);
            AltaActividad(actividadHostal10);

            //Actividades Tercerizadas

            ActividadTercerizada actividadTercerizada1 = new ActividadTercerizada(GetProveedorPorNombre("DreamWorks S.R.L."), true, new DateTime(2024, 08, 20), "NombreActTercerizada1", "DescripcionActividadTercerizada1", new DateTime(2023, 10, 02), 1, 18, 300);
            ActividadTercerizada actividadTercerizada2 = new ActividadTercerizada(GetProveedorPorNombre("DreamWorks S.R.L."), true, new DateTime(2023, 06, 24), "NombreActTercerizada2", "DescripcionActividadTercerizada2", new DateTime(2023, 10, 05), 15, 18, 350);
            ActividadTercerizada actividadTercerizada3 = new ActividadTercerizada(GetProveedorPorNombre("DreamWorks S.R.L."), true, new DateTime(2023, 12, 28), "NombreActTercerizada3", "DescripcionActividadTercerizada3", new DateTime(2023, 11, 15), 56, 18, 320);
            ActividadTercerizada actividadTercerizada4 = new ActividadTercerizada(GetProveedorPorNombre("Estela Umpierrez S.A."), true, DateTime.Now, "NombreActTercerizada4", "DescripcionActividadTercerizada4", new DateTime(2024, 01, 15), 33, 12, 420);
            ActividadTercerizada actividadTercerizada5 = new ActividadTercerizada(GetProveedorPorNombre("Estela Umpierrez S.A."), true, new DateTime(2023, 07, 22), "NombreActTercerizada5", "DescripcionActividadTercerizada5", new DateTime(2023, 07, 20), 47, 21, 500);
            ActividadTercerizada actividadTercerizada6 = new ActividadTercerizada(GetProveedorPorNombre("Estela Umpierrez S.A."), true, new DateTime(2024, 06, 10), "NombreActTercerizada6", "DescripcionActividadTercerizada6", new DateTime(2023, 10, 02), 120, 15, 250);
            ActividadTercerizada actividadTercerizada7 = new ActividadTercerizada(GetProveedorPorNombre("Rekreation S.A."), true, DateTime.Now, "NombreActTercerizada7", "DescripcionActividadTercerizada7", new DateTime(2023, 10, 02), 99, 30, 270);
            ActividadTercerizada actividadTercerizada8 = new ActividadTercerizada(GetProveedorPorNombre("Rekreation S.A."), true, new DateTime(2024, 06, 10), "NombreActTercerizada8", "DescripcionActividadTercerizada8", new DateTime(2023, 10, 02), 34, 22, 275);
            ActividadTercerizada actividadTercerizada9 = new ActividadTercerizada(GetProveedorPorNombre("Rekreation S.A."), true, new DateTime(2024, 06, 10), "NombreActTercerizada9", "DescripcionActividadTercerizada9", new DateTime(2023, 10, 02), 101, 15, 870);
            ActividadTercerizada actividadTercerizada10 = new ActividadTercerizada(GetProveedorPorNombre("Alonso & Umpierrez"), true, new DateTime(2024, 06, 10), "NombreActTercerizada10", "DescripcionActividadTercerizada10", new DateTime(2023, 10, 02), 18, 18, 1500);
            ActividadTercerizada actividadTercerizada11 = new ActividadTercerizada(GetProveedorPorNombre("Alonso & Umpierrez"), true, new DateTime(2024, 06, 10), "NombreActTercerizada11", "DescripcionActividadTercerizada11", new DateTime(2023, 10, 02), 160, 18, 210);
            ActividadTercerizada actividadTercerizada12 = new ActividadTercerizada(GetProveedorPorNombre("Alonso & Umpierrez"), true, new DateTime(2024, 06, 10), "NombreActTercerizada12", "DescripcionActividadTercerizada12", new DateTime(2023, 10, 02), 30, 21, 620);
            ActividadTercerizada actividadTercerizada13 = new ActividadTercerizada(GetProveedorPorNombre("Norberto Molina"), true, new DateTime(2024, 06, 10), "NombreActTercerizada13", "DescripcionActividadTercerizada13", new DateTime(2023, 10, 02), 99, 32, 430);
            ActividadTercerizada actividadTercerizada14 = new ActividadTercerizada(GetProveedorPorNombre("Norberto Molina"), true, new DateTime(2024, 06, 10), "NombreActTercerizada14", "DescripcionActividadTercerizada14", new DateTime(2023, 10, 02), 66, 40, 520);
            ActividadTercerizada actividadTercerizada15 = new ActividadTercerizada(GetProveedorPorNombre("Norberto Molina"), true, new DateTime(2024, 06, 10), "NombreActTercerizada15", "DescripcionActividadTercerizada15", new DateTime(2023, 10, 02), 44, 19, 675);

            AltaActividad(actividadTercerizada1);
            AltaActividad(actividadTercerizada2);
            AltaActividad(actividadTercerizada3);
            AltaActividad(actividadTercerizada4);
            AltaActividad(actividadTercerizada5);
            AltaActividad(actividadTercerizada6);
            AltaActividad(actividadTercerizada7);
            AltaActividad(actividadTercerizada8);
            AltaActividad(actividadTercerizada9);
            AltaActividad(actividadTercerizada10);
            AltaActividad(actividadTercerizada11);
            AltaActividad(actividadTercerizada12);
            AltaActividad(actividadTercerizada13);
            AltaActividad(actividadTercerizada14);
            AltaActividad(actividadTercerizada15);
        }


        private void PrecargarAgendas()
        {
            AgendarHuespedActividad(new Agenda(GetHuesped(1), GetActividadTercerizada(11), EstadoAgenda.PendientePago));
            AgendarHuespedActividad(new Agenda(GetHuesped(1), GetActividadTercerizada(15), EstadoAgenda.PendientePago));
            AgendarHuespedActividad(new Agenda(GetHuesped(1), GetActividadHostal(3), EstadoAgenda.PendientePago));
        }
        #endregion

        private Proveedor GetProveedorPorNombre(string nombre)
        {
            foreach (Proveedor proveedor in _proveedores)
            {
                if (proveedor.Nombre.Equals(nombre))
                {
                    return proveedor;
                }
            }
            throw new Exception("No se encontro un proveedor con el nombre ingresado");
        }

        public void AplicarPromocionProveedor(string proveedor, int descuento)
        {
            if (descuento < 0 || descuento > 100)
            {
                throw new Exception("El valor de descuento tiene que estar entre 0 y 100");

            }
            try
            {
                Proveedor p = GetProveedorPorNombre(proveedor);
                p.Descuento = descuento;
                p.Validar();
                ActualizarActividadesDeUnProveedor(p.Id);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void ActualizarActividadesDeUnProveedor(int id)
        {
            try
            {
                foreach (Actividad actividad in _actividades)
                {
                    if (actividad.GetTipo() == "Tercerizada")
                    {
                        if (actividad.GetIdProveedor() == id)
                        {
                            actividad.Validar();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AltaProveedor(Proveedor proveedor)
        {
            if (_proveedores.Contains(proveedor))
            {
                throw new Exception("El proveedor ya existe");
            }
            try
            {
                proveedor.Validar();
                _proveedores.Add(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AltaUsuario(Usuario usuario)
        {
            if (_usuarios.Contains(usuario))
            {
                throw new Exception("El huesped ya existe");
            }

            try
            {
                usuario.Validar();
                _usuarios.Add(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AltaActividad(Actividad actividad)
        {
            if (!_actividades.Contains(actividad))
            {
                try
                {
                    actividad.Validar();
                    _actividades.Add(actividad);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                throw new Exception("La actividad ya existe");
            }
        }

        public void AgendarHuespedActividad(Agenda agenda)
        {
            if (!_agendas.Contains(agenda))
            {
                try
                {
                    ActividadTercerizada actividad = GetActividadTercerizada(agenda.Actividad.Id);
                    if (actividad != null)
                    {
                        if (!actividad.Confirmada)
                        {
                            throw new Exception("La actividad no esta confirmada por el proveedor");
                        }
                    }
                    agenda.Validar();
                    _agendas.Add(agenda);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                throw new Exception("Ya existe una agenda con esos datos");
            }

        }



        public List<Agenda> GetAgendas()
        {
            return _agendas;
        }

        public List<Proveedor> GetProveedores()
        {
            _proveedores.Sort();
            return _proveedores;
        }


        public List<Proveedor> GetProveedoresDescuento()
        {
            List<Proveedor> listaAux = new List<Proveedor>();
            foreach (Proveedor proveedor in _proveedores)
            {
                if (proveedor.Descuento >= 20)
                {
                    listaAux.Add(proveedor);
                }
            }

            listaAux.Sort();
            return listaAux;
        }
        public List<Actividad> GetActividades()
        {
            return _actividades;
        }
        public ActividadTercerizada GetActividadTercerizada(int? idAct)
        {
            foreach (Actividad p in _actividades)
            {
                if (p.Id.Equals(idAct))
                {
                    if (p.GetTipo() == "Tercerizada")
                    {
                        return p as ActividadTercerizada;
                    }
                }
            }
            return null;
        }

        public ActividadHostal GetActividadHostal(int? idAct)
        {
            foreach (Actividad p in _actividades)
            {
                if (p.Id.Equals(idAct))
                {
                    if (p.GetTipo() == "Hostal")
                    {
                        return p as ActividadHostal;
                    }
                }
            }
            return null;
        }
        public List<Usuario> GetUsuarios()
        {
            return _usuarios;
        }


        public List<Actividad> GetActividadesFecha(DateTime fecha)
        {
            List<Actividad> listaActividad = new List<Actividad>();

            foreach (Actividad actividad in _actividades)
            {
                if (actividad.Fecha.ToString("d") == fecha.ToString("d"))
                {
                    listaActividad.Add(actividad);
                }

            }
            return listaActividad;
        }
        public List<Actividad> GetActividadesPorRangoFechas(DateTime fecha1, DateTime fecha2, int costo)
        {
            List<Actividad> actividadAux = new List<Actividad>();
            foreach (Actividad actividad in _actividades)
            {
                if (actividad.Fecha > fecha1 && actividad.Fecha < fecha2 && actividad.Costo > costo)
                {
                    actividadAux.Add(actividad);
                }
            }
            if (actividadAux.Count == 0)
            {
                throw new Exception("No se encontro actividades que coincidan con los datos requeridos");
            }
            actividadAux.Sort();
            return actividadAux;
        }

        public DateTime FechaStringATipoDateTime(string fechaS) //Convierte las fechas ingresadas en string, a tipo DateTime
        {
            DateTime Fecha;
            if (DateTime.TryParse(fechaS, out Fecha))
            {
                return Fecha;
            }
            else
            {
                throw new Exception("El formato ingresado en la/s fecha/s no es correcto");
            }
        }

        public void ValidarEnumDocumento(int numIngresado)
        {
            bool flag = false;
            foreach (int resultado in Enum.GetValues(typeof(TipoDocumento)))
            {
                if (resultado == numIngresado)
                {
                    flag = true;
                    break;

                }
            }
            if (!flag)
            {
                throw new Exception("El tipo de documento ingresado, no existe.");
            }
        }

        public Usuario Login(string correo, string clave)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Email.Equals(correo) && usuario.Contrasenia.Equals(clave))
                {
                    return usuario;
                }
            }
            return null;
        }

        public Huesped GetHuesped(int? idLogueado)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Id.Equals(idLogueado))
                {
                    if (u.GetTipo() == "Huesped")
                    {
                        return u as Huesped;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public Actividad GetActividad(int actividadId)
        {
            foreach (Actividad a in _actividades)
            {
                if (a.Id.Equals(actividadId))
                {
                    if (a.GetTipo() == "Tercerizada")
                    {
                        return a as ActividadTercerizada;
                    }
                    else
                    {
                        return a as ActividadHostal;
                    }

                }
            }
            return null;
        }

        public List<Agenda> GetAgendas(int idLogueado)
        {
            List<Agenda> agendaAux = new List<Agenda>();

            foreach (Agenda agenda in _agendas)
            {
                if (agenda.Huesped.Id == idLogueado)
                {
                    agendaAux.Add(agenda);
                }
            }
            agendaAux.Sort();
            return agendaAux;
        }

        public Agenda GetAgendaId(int idAgenda)
        {
            foreach (Agenda agenda in _agendas)
            {
                if (agenda.Id == idAgenda)
                {
                    return agenda;
                }
            }
            return null;
        }

        public IEnumerable<Agenda> GetAgendas(int nroDocumento, TipoDocumento slcTipoDocumento)
        {
            List<Agenda> agendaAux = new List<Agenda>();
            foreach (Agenda agenda in _agendas)
            {
                if (agenda.Huesped.NumeroDocumento == nroDocumento && agenda.Huesped.TipoDocumento == slcTipoDocumento)
                {
                    agendaAux.Add(agenda);
                }
            }
            agendaAux.Sort();
            return agendaAux;
        }

        public IEnumerable<Agenda> GetAgendas(DateTime fecha)
        {
            List<Agenda> agendaAux = new List<Agenda>();

            foreach (Agenda agenda in _agendas)
            {
                if (agenda.FechaCreacion.ToString("d") == fecha.ToString("d"))
                {
                    agendaAux.Add(agenda);
                }
            }
            agendaAux.Sort();
            return agendaAux;
        }

        public void ConfirmarAgenda(Agenda agendaEditada)
        {

            Agenda agendaOriginal = GetAgendaId(agendaEditada.Id);
            try
            {
                if (agendaOriginal != null)
                {
                    agendaOriginal.EstadoAgenda = agendaEditada.EstadoAgenda;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Proveedor GetProveedor(int id)
        {
            foreach (Proveedor proveedor in _proveedores)
            {
                if (proveedor.Id == id)
                {
                    return proveedor;
                }
            }
            return null;

        }

        public Operador? GetOperador(int? idLogueado)
        {

            foreach (Usuario user in _usuarios)
            {
                if (user.Id.Equals(idLogueado))
                {
                    if (user.GetTipo() == "Operador")
                    {
                        return user as Operador;
                    }
                }

            }
            return null;
        }
    }
}

