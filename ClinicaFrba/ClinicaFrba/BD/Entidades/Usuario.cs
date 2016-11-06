using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ClinicaFrba.BD
{
    public class Usuario
    {
        public string Apellido { get; set; }
        public string Dni { set; get; }
        public byte[] Contrasena_Hash { get; set; }
        public Int16 Cantidad_Intentos { get; set; }
        public string Contrasena { get; set; }

        public Usuario() { }

        public Usuario(string user)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userName", user));

            SqlDataReader lector = BDStranger_Strings.GetDataReader("SELECT * FROM STRANGER_STRINGS.Usuario WHERE Usuario=@userName", "T", paramList);
            if (lector.HasRows)
            {
                lector.Read();
                Apellido = user;
                Cantidad_Intentos = (Int16)lector["Cantidad_Intentos"];
                Contrasena_Hash = (Byte[])lector["Pasword"];
            }
            Inicio i = new Inicio();
            Contrasena = i.bytesDeHasheoToString(Contrasena_Hash);
        }


        public void DescontarIntento()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Usuario", Apellido));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_ACTUALIZAR_INTENTOS","SP", paramlist);
        }

        public void ReiniciarCantidadIntentos(String dni)
        {
            this.Dni = dni;
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Usuario", Apellido));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_REINICIAR_INTENTOS","SP", paramlist);
        }

    }
}
