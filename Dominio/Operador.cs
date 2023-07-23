using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Operador : Usuario
    {
        public string Apellido { get; set; }
        public DateTime FechaTrabajo { get; set; }
        public string Nombre { get; set; }

        public Operador(string email, string contrasenia, string apellido, string nombre, DateTime fechaTrabajo) : base(email, contrasenia)
        {
            Apellido = apellido;
            FechaTrabajo = fechaTrabajo;
            Nombre = nombre;

        }
        

        public Operador()
        {

        }

        public override void Validar()
        {
            try
            {
                base.ValidarEmail();
                base.ValidarContrasenia();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public override string GetTipo()
        {
            return "Operador";
        }
    }
}
