using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PagoElectronico.Models.DataBase;
using PagoElectronico.Models.BO;

namespace PagoElectronico.Models
{
    public class Usuario
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public decimal CantFallidos { get; set; }

        public Usuario() { }
        
        public Usuario(string userName)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userName", userName));

            SqlDataReader lector = DBAcess.GetDataReader("SELECT * FROM VIDA_ESTATICA.Usuario WHERE name=@userName", "T", paramList);
            if (lector.HasRows) {
                lector.Read();
                Name = userName;
                Password = ((string)lector["pass"]).ToUpper();
                Activo = (bool)lector["activo"];
                CantFallidos = (decimal)lector["intentos_login"];
            }
        }

        public decimal ActualizarFallidos()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@intentos_login", CantFallidos + 1));
            paramList.Add(new SqlParameter("@nombre", Name));
            return DBAcess.ExecStoredProcedure("VIDA_ESTATICA.updateIntentos", paramList);
        }

        public bool ReiniciarFallidos()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@nombre", Name));
            return DBAcess.WriteInBase("UPDATE VIDA_ESTATICA.Usuario SET intentos_login=0 WHERE name=@nombre", "T", paramList);
        }


        public static List<Rol> ObtenerRoles(Usuario user)
        {
            List<Rol> l = new List<Rol>();

            List<SqlParameter> lParameters = new List<SqlParameter>();
            lParameters.Add(new SqlParameter("@nombre", user.Name));
            SqlDataReader lector = DBAcess.GetDataReader("SELECT * from VIDA_ESTATICA.roles_usuario(@nombre)", "T", lParameters);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.nombre = (string)lector["nombre"];
                    unRol.id = (int)lector["rol"];
                    unRol.activo = true;
                    l.Add(unRol);
                }
            }
            return l;
        }
    }
}
