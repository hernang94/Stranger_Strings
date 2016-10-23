using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.BD
{
    public class Usuario
    {
        public Int64 Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public decimal Cantidad_Intentos { get; set; }

        public Usuario() { }

        public Usuario(string user)
        {
        }

    }
}
