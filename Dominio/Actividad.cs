using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Actividad : IValidable, IComparable<Actividad>
    {

        public int Id { get; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EdadMinima { get; set; }
        public DateTime Fecha { get; set; }
        public int CantMaxPersonas { get; set; }
        public double Costo { get; set; }
        public Actividad()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Actividad(string nombre, string descripcion, DateTime fecha, int cantMaxPersonas, int edadMinima, double costo)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
            CantMaxPersonas = cantMaxPersonas;
            Costo = costo;
            EdadMinima = edadMinima;
        }

        public abstract string GetTipo();
        public abstract string ObtenerNombreProveedor();
        public abstract string ObtenerLugar();
        public abstract int GetIdProveedor();
        public virtual void Validar()
        {
            try
            {
                ValidarDescripcion();
                //ValidarFecha();
                ValidarNombre();
                ValidarLongitudNombre();
                ValidarCosto();
                ValidarCantMaxPersonas();
                ValidarEdadMinima();
            }
            catch (Exception)
            {

                throw;
            }

        }



        private void ValidarEdadMinima()
        {
            if (EdadMinima < 0)
            {
                throw new Exception("La edad minima, no puede ser menor a 0");
            }
        }
        private void ValidarCantMaxPersonas()
        {
            if (CantMaxPersonas < 0)
            {
                throw new Exception("La cantidad maxima de personas, no puede ser menor a 0");
            }
        }
        private void ValidarCosto()
        {
            if (Costo < 0)
            {
                throw new Exception("El costo no puede ser menor a 0");
            }
        }
        //private void ValidarFecha()
        //{
        //    if (Fecha < DateTime.Now)
        //    {
        //        throw new Exception("La fecha no puede ser menor que la fecha actual.");
        //    }
        //}

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcion no puede estar vacia");
            }
        }
        private void ValidarLongitudNombre()
        {
            if (Nombre.Length > 25)
            {
                throw new Exception("El nombre no puede tener mas de 25 caracteres");
            }
        }

        public override string ToString()
        {
            return $"ID:{Id}\nNombre:{Nombre}\nDescripcion:{Descripcion}\nFecha:{Fecha.ToString("d")}\nCantidad maxima de personas:{CantMaxPersonas}\nEdad minima para la realizacion:{EdadMinima}\n";
        }

        public int CompareTo(Actividad? other)
        {
            if (Costo.CompareTo(other.Costo) < 0)
            {
                return 1;
            }
            else if (Costo.CompareTo(other.Costo) > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
