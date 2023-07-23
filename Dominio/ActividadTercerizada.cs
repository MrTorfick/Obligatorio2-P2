using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadTercerizada : Actividad
    {
        public Proveedor Proveedor { get; set; }
        public bool Confirmada { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public double CostoOriginal { get; set; }


        public ActividadTercerizada()
        {

        }

        public ActividadTercerizada(Proveedor proveedor, bool confirmada, DateTime fecha, string nombre, string descripcion, DateTime fechaConfirmacion, int cantMaxPersonas, int edadMinima, int costo) : base(nombre, descripcion, fecha, cantMaxPersonas, edadMinima, costo)
        {
            Proveedor = proveedor;
            Confirmada = confirmada;
            if (confirmada)
            {
                FechaConfirmacion = fechaConfirmacion;
            }
            else
            {
                FechaConfirmacion = null;
            }
            CostoOriginal = Costo;
            

        }

        public override void Validar()
        {

            try
            {
                base.Validar();
                ValidarProveedor();
                ValidarFecha();
                AplicarDescuento();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void AplicarDescuento()
        {
            if (Proveedor.Descuento > 0 && Confirmada)
            {
                Costo= CostoOriginal;
                Costo = (100 - Proveedor.Descuento) * Costo / 100;
            }
        }

        private void ValidarProveedor()
        {
            if (Proveedor == null)
            {
                throw new Exception("Debe ingresar un proveedor");
            }
        }

        private void ValidarFecha()
        {
            if (FechaConfirmacion < DateTime.Now && Confirmada)
            {
                throw new Exception("La fecha de confirmacion no puede ser menor que la fecha actual.");
            }
        }

        public override string GetTipo()
        {
            return "Tercerizada";
        }

        public override string ObtenerNombreProveedor()
        {
            return Proveedor.Nombre;
        }

        public override string ObtenerLugar()
        {
            return null;
        }

        public override int GetIdProveedor()
        {
            return Proveedor.Id;
        }
    }
}
