using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Huesped : Usuario
    {
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Habitacion { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nivel { get; set; }


        public Huesped()
        {
        }

        public Huesped(TipoDocumento tipoDocumento, int numeroDocumento, string nombre, string apellido, string habitacion, int edad, DateTime fechaNacimiento, int nivel, string email, string contrasenia) : base(email, contrasenia)
        {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Nombre = nombre;
            Apellido = apellido;
            Habitacion = habitacion;
            Edad = edad;
            FechaNacimiento = fechaNacimiento;
            Nivel = nivel;
        }


        public override void Validar()
        {
            try
            {
                ValidarCedula();
                ValidarApellido();
                ValidarNombre();
                ValidarHabitacion();
                ValidarNivel();
                ValidarFechaNacimiento();
                base.ValidarEmail();
                base.ValidarContrasenia();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ValidarFechaNacimiento()
        {
            if (FechaNacimiento > DateTime.Now)
            {
                throw new Exception("La fecha de nacimiento, no puede ser mayor que la fecha actual.");
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede estar vacio");
            }
        }

        public void ValidarCedula()
        {


            if (NumeroDocumento.ToString().Length == 8 || NumeroDocumento.ToString().Length == 7)
            {
                int aux = 0;
                if (NumeroDocumento.ToString().Length == 7)
                {
                    aux = 1;
                }
                string Ci = NumeroDocumento.ToString();
                int[] array = { 8, 1, 2, 3, 4, 7, 6 };
                int resultado = 0;
                int guion = int.Parse(Ci[Ci.Length - 1].ToString());
                for (int i = 0; i < Ci.Length - 1; i++)
                {
                    int num = int.Parse(Ci.Substring(i, 1));
                    resultado += num * array[aux];//Si la cedula es de 7 digito(incluyendo guion), la variable aux va a ser igual a 1. Entonces en el array, va a empezar por la posicion 1
                    aux++;

                }
                resultado = resultado % 10;
                if (resultado != guion)
                {
                    throw new Exception("La cedula no es valida");
                }
            }
            else
            {
                throw new Exception("La cedula ingresada debe ser de ocho o siete numeros (incluyendo el guion)");
            }
        }

        private void ValidarHabitacion()
        {
            if (string.IsNullOrEmpty(Habitacion))
            {
                throw new Exception("La habitacion no puede estar vacia");
            }
        }

        private void ValidarNivel()
        {
            if (Nivel < 1 || Nivel > 4)
            {
                throw new Exception("El valor numerico de fidelizacion debe estar entre 1 y 4");
            }
        }


        public override bool Equals(object? obj)
        {
            return obj is Huesped huesped &&
                   TipoDocumento == huesped.TipoDocumento &&
                   NumeroDocumento == huesped.NumeroDocumento;
        }

        public override string GetTipo()
        {
            return "Huesped";
        }
    }
}
