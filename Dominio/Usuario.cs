using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {

        public int Id { get; }
        public static int UltimoId { get; set; } = 1;
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public Usuario()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Usuario(string email, string contrasenia)
        {
            Id = UltimoId;
            UltimoId++;
            Email = email;
            Contrasenia = contrasenia;
        }

        public abstract void Validar();
        public abstract string GetTipo();
        public virtual void ValidarEmail()
        {
            if (Email.IndexOf("@") == 0 || Email.IndexOf("@") == Email.Length - 1 || Email.IndexOf("@") == -1)
            {
                throw new Exception("El email debe tener un arroba. Ademas, no puede estar al principio ni al final");
            }
        }
        public virtual void ValidarContrasenia()
        {
            if (Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe tener un minimo de 8 caracteres");
            }
        }






    }
}
