using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor : IValidable, IComparable<Proveedor>
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string NumeroContacto { get; set; }
        public string Direccion { get; set; }
        public int Descuento { get; set; }

        public Proveedor()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Proveedor(string nombre, string numeroContacto, string direccion, int descuento)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            NumeroContacto = numeroContacto;
            Direccion = direccion;
            Descuento = descuento;
        }

        public void Validar()
        {
            try
            {
                ValidarNombre();
                ValidarNumeroContacto();
                ValidarDireccion();
                ValidarDescuento();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ValidarDescuento()
        {
            if (Descuento < 0)
            {
                throw new Exception("El numero de descuento debe ser igual o mayor a cero");
            }
        }

        private void ValidarDireccion()
        {
            if (string.IsNullOrEmpty(Direccion))
            {
                throw new Exception("La direccion no puede estar vacia");
            }
        }

        private void ValidarNumeroContacto()
        {
            if (string.IsNullOrEmpty(NumeroContacto))
            {
                throw new Exception("El numero de contacto no puede estar vacio");
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Proveedor proveedor &&
                   Nombre == proveedor.Nombre;
        }

        public int CompareTo(Proveedor? other)
        {


            if (Nombre.CompareTo(other.Nombre) > 0)
            {
                return 1;
            }
            else if (Nombre.CompareTo(other.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}\nNumero de contacto: {NumeroContacto}\nDireccion: {Direccion}\nDescuento: {Descuento}%\n";
        }


    }
}
