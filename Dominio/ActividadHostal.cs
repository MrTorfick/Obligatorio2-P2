using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadHostal : Actividad
    {
        public string PersonaResponsable { get; set; }
        public string Lugar { get; set; }
        public bool AireLibre { get; set; }

        public ActividadHostal()
        {

        }
        public ActividadHostal(string personaResponsable, string lugar, bool aireLibre, string nombre, string descripcion, DateTime fecha, int cantMaxPersonas, int edadMinima, int costo = 0) : base(nombre, descripcion, fecha, cantMaxPersonas, edadMinima, costo)
        {
            PersonaResponsable = personaResponsable;
            Lugar = lugar;
            AireLibre = aireLibre;
        }

        public override void Validar()
        {
            try
            {
                base.Validar();
                ValidarPersonaResponsable();
                ValidarLugar();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ValidarPersonaResponsable()
        {
            if (string.IsNullOrEmpty(PersonaResponsable))
            {
                throw new Exception("El nombre de la persona responsable no puede ser vacio");
            }
        }

        private void ValidarLugar()
        {
            if (string.IsNullOrEmpty(Lugar))
            {
                throw new Exception("El lugar no puede estar vacio");
            }
        }

        public override string GetTipo()
        {
            return "Hostal";
        }

        public override string ObtenerNombreProveedor()
        {
            return null;
        }

        public override string ObtenerLugar()
        {
            return Lugar;
        }

        public override int GetIdProveedor()
        {
            return -1;
        }
    }
}
