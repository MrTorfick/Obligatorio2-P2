using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda : IValidable, IComparable<Agenda>
    {
        public int Id { get; }
        public static int UltimoId { get; set; } = 1;
        public Huesped Huesped { get; set; }
        public Actividad Actividad { get; set; }
        public EstadoAgenda EstadoAgenda { get; set; }
        public double Costo { get; set; }
        public DateTime FechaCreacion { get; set; }


        public Agenda()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Agenda(Huesped huesped, Actividad actividad, EstadoAgenda estadoAgenda)
        {
            Id = UltimoId;
            UltimoId++;
            Huesped = huesped;
            Actividad = actividad;
            EstadoAgenda = estadoAgenda;
            Costo = 0;
            FechaCreacion = DateTime.Now;
        }

        public void Validar()
        {
            try
            {
                ValidarHuesped();
                CostoFinal();
                ValidarActividad();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ValidarActividad()
        {
            if (Actividad == null)
            {
                throw new Exception("La actividad no puede ser nula");
            }
            if (Actividad.CantMaxPersonas <= 0)
            {
                throw new Exception("No hay cupos disponibles para la actividad deseada");
            }
            Actividad.CantMaxPersonas--;
        }

        private void ValidarHuesped()
        {
            if (Huesped == null)
            {
                throw new Exception("El huesped no puede ser nulo");
            }

            if (Huesped.Edad < Actividad.EdadMinima)
            {
                throw new Exception("La edad minima del huesped, es menor a la edad minima permitida de la actividad");
            }

        }

        private void CostoFinal()
        {
            if (Costo.Equals(0))
            {
                if (Actividad.GetTipo() == "Hostal")
                {
                    if (Huesped.Nivel == 2)
                    {
                        Costo = Actividad.Costo * 0.90;
                    }
                    else if (Huesped.Nivel == 3)
                    {
                        Costo = Actividad.Costo * 0.85;
                    }
                    else if (Huesped.Nivel == 4)
                    {
                        Costo = Actividad.Costo * 0.80;
                    }
                }
                else
                {
                    Costo = Actividad.Costo;


                }

                if (Costo == 0)
                {
                    EstadoAgenda = EstadoAgenda.Confirmada;
                }
                else
                {
                    EstadoAgenda = EstadoAgenda.PendientePago;
                }
            }


        }

        public int CompareTo(Agenda? other)
        {
            if (Actividad.Fecha.CompareTo(other.Actividad.Fecha) < 0)
            {
                return -1;
            }
            else if (Actividad.Fecha.CompareTo(other.Actividad.Fecha) > 0)
            {
                return 1;
            }
            else if (Actividad.Nombre.CompareTo(other.Actividad.Nombre) > 0)
            {
                return 1;

            }
            else if(Actividad.Nombre.CompareTo(other.Actividad.Nombre)<0){
                return -1;
            }
            else
            {
                return 0;
            }
        }






        public override string ToString()
        {

            string resultado = $"Nombre: {Huesped.Nombre}\nApellido: {Huesped.Apellido}\nNombre de la actividad: {Actividad.Nombre}\nFecha de la actividad: {Actividad.Fecha}\nLugar de la actividad: " +
             $"{Actividad.Fecha}\n";
            if (Actividad.Costo == 0)
            {
                resultado += $"Costo: Actividad Gratuita\n";
            }
            else
            {
                resultado += $"Costo: {Actividad.Costo}\n";
            }
            resultado += $"Estado de la agenda: {EstadoAgenda}\n";
            return resultado;
        }

        public override bool Equals(object? obj)
        {
            return obj is Agenda agenda &&
                   EqualityComparer<Huesped>.Default.Equals(Huesped, agenda.Huesped) &&
                   EqualityComparer<Actividad>.Default.Equals(Actividad, agenda.Actividad);
        }
    }
}
