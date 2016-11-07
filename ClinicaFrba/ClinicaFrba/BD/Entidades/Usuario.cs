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
        public Int16 Cantidad_Intentos { get; set; }

        public Usuario() { }

        public Usuario(string user)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userName", user));

            SqlDataReader lector = BDStranger_Strings.GetDataReader("SELECT Cantidad_Intentos FROM STRANGER_STRINGS.Usuario WHERE Usuario=@userName", "T", paramList);
            if (lector.HasRows)
            {
                lector.Read();
                Apellido = user;
                Cantidad_Intentos = (Int16)lector["Cantidad_Intentos"];
            }
            Inicio i = new Inicio();
        }


        public void DescontarIntento()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Usuario", Apellido));
            paramlist.Add(new SqlParameter("@Password", Dni));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_ACTUALIZAR_INTENTOS","SP", paramlist);
        }

        public void ReiniciarCantidadIntentos(String dni)
        {
            this.Dni = dni;
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Usuario", Apellido));
            paramlist.Add(new SqlParameter("@Password", Dni));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_REINICIAR_INTENTOS","SP", paramlist);
        }

    }
}
