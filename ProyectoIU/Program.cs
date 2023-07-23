using Dominio;

namespace ProyectoIU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia;

            int opcion = -1;

            while (opcion != 0)
            {

                Console.WriteLine("--Menu--");
                Console.WriteLine("1-Listar todas las actividades");
                Console.WriteLine("2-Listar todos los proveedores ordenados por nombre alfabeticamente");
                Console.WriteLine("3-Listar las actividades que tengan un costo mayor al solicitado, y esten comprendidas entre determinado rango de fechas");
                Console.WriteLine("4-Establecer el valor de promocion para actividades de un proveedor");
                Console.WriteLine("5-Alta de huespedes");
                Console.WriteLine("6-Limpiar consola");
                Console.WriteLine("0-Salir");
                try
                {
                    opcion = Int32.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            List<Actividad> Actividad = s.GetActividades();
                            foreach (Actividad act in Actividad)
                            {
                                Console.WriteLine(act);
                            }
                            break;

                        case 2:
                            List<Proveedor> Proveedores = s.GetProveedores();
                            foreach (Proveedor proveedor in Proveedores)
                            {
                                Console.WriteLine(proveedor);
                            }

                            break;

                        case 3:
                            Console.WriteLine("Usando formato dd/MM/yyyy");
                            Console.WriteLine("Ingrese la primera fecha: ");
                            string fecha1Aux = Console.ReadLine();
                            DateTime fecha1;
                            Console.WriteLine("Ingrese la segunda fecha: ");
                            string fecha2Aux = Console.ReadLine();
                            DateTime fecha2;
                            fecha1 = s.FechaStringATipoDateTime(fecha1Aux);
                            fecha2 = s.FechaStringATipoDateTime(fecha2Aux);

                            Console.WriteLine("Ingrese el costo: ");
                            int costo = Int32.Parse(Console.ReadLine());
                            List<Actividad> actividad = s.GetActividadesPorRangoFechas(fecha1, fecha2, costo);

                            foreach (Actividad act in actividad)
                            {
                                Console.WriteLine(act);
                            }

                            break;

                        case 4:
                            Console.WriteLine("Ingrese el nombre de proveedor el cual desea establecer un valor de promocion");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el valor de promocion: ");
                            int descuento = Int32.Parse(Console.ReadLine());
                            s.AplicarPromocionProveedor(nombre, descuento);
                            Console.WriteLine("Se establecio del valor de promocion correctamente");
                            break;

                        case 5:
                            Console.WriteLine("Ingrese el tipo de documento\n1-CI\n2-Pasaporte\n3-Otros ");
                            int numIngresado = Int32.Parse(Console.ReadLine());
                            s.ValidarEnumDocumento(numIngresado);

                            TipoDocumento tipoDoc = (TipoDocumento)numIngresado;//tipoDoc, va a tener el valor del enum correspondiente al valor que ingreso el usuario
                            Console.WriteLine("Ingrese el numero de documento (sin puntos ni guiones): ");
                            int numeroDocumento = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese el nombre: ");
                            string nombreHuesped = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido: ");
                            string apellidoHuesped = Console.ReadLine();
                            Console.WriteLine("Ingrese la habitacion: ");
                            string habitacion = Console.ReadLine();
                            Console.WriteLine("Usando formato dd/MM/yyyy");
                            Console.WriteLine("Ingrese la fecha de nacimiento: ");
                            string fecha1AuxHuespeed = Console.ReadLine();
                            DateTime fechaNacHuesped = s.FechaStringATipoDateTime(fecha1AuxHuespeed);
                            Console.WriteLine("Ingrese el nivel de fidelidad");
                            int nivelFidelidad = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese un email: ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Ingrese una contraseña: ");
                            string contrasenia = Console.ReadLine();
                            Console.WriteLine("Ingrese una edad: ");
                            int edad = Int32.Parse(Console.ReadLine());
                            s.AltaUsuario(new Huesped(tipoDoc, numeroDocumento, nombreHuesped, apellidoHuesped, habitacion, edad, fechaNacHuesped, nivelFidelidad, email, contrasenia));
                            Console.WriteLine("Huesped ingresado correctamente");
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.Clear();
                            break;

                        default:
                            if (opcion != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La opcion ingresada no existe");
                                Console.ReadKey();
                                Console.ResetColor();
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + e.Message);
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();
                }
            }
        }
    }
}