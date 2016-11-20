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
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public int Dni { set; get; }
        public string Tipo_Doc { set; get; }
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
                UserName = user;
                Cantidad_Intentos = (Int16)lector["Cantidad_Intentos"];
            }
            if(UserName!="admin" && UserName!="administrativo")
            {
                Dni = getNumeroDoc();
                Tipo_Doc = getTipoDoc();
            }
            Inicio i = new Inicio();
        }


        public void DescontarIntento()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Usuario", UserName));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_ACTUALIZAR_INTENTOS","SP", paramlist);
        }

        public void ReiniciarCantidadIntentos()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Usuario", UserName));
            paramlist.Add(new SqlParameter("@Password", Contraseña));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_REINICIAR_INTENTOS","SP", paramlist);
        }

        public int getNumeroDoc()
        {
            int tamanioUser = this.UserName.Length;
            return int.Parse(this.UserName.Substring(0, (tamanioUser - 3)));
        }

        public string getTipoDoc()
        {
            int tamanioUser = this.UserName.Length;
            return this.UserName.Substring((tamanioUser - 3), 3);
        }
    }
}
