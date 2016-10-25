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
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public Int16 Cantidad_Intentos { get; set; }

        public Usuario() { }

        public Usuario(string user)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userName", user));

            SqlDataReader lector = BDStranger_Strings.GetDataReader("SELECT * FROM STRANGER_STRINGS.Usuario WHERE Usuario=@userName", "T", paramList);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Inicio i = new Inicio();
                    Nombre = user;
                    Cantidad_Intentos = lector.GetInt16(3);
                    Contrasena = i.bytesDeHasheoToString(lector.GetByte(2));
;
                }
                
            }
            else
            {
                Nombre = null;
            }
        }


        public void DescontarIntento()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@intentos_login", Cantidad_Intentos - 1));
            paramList.Add(new SqlParameter("@nombre", Nombre));
            BDStranger_Strings.WriteInBase("UPDATE STRANGER_STRINGS.Usuario SET Cantidad_Intentos=@intentos_login WHERE Usuario=@nombre", "T", paramList);
        }

        public void ReiniciarCantidadIntentos()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@nombre", Nombre));
            BDStranger_Strings.WriteInBase("UPDATE STRANGER_STRINGS.Usuario SET Cantidad_Intentos=3 WHERE Usuario=@nombre", "T", paramList);
        }

    }
}
