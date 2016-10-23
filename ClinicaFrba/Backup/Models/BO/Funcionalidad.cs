using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Generic;

using PagoElectronico.Models.DAO;
using System.Data.SqlClient;
using PagoElectronico.Models.DataBase;

namespace PagoElectronico.Models.BO
{
    public partial class Funcionalidad : IBO<Funcionalidad>
    {

        public Funcionalidad() { }

        public Funcionalidad(DataRow dr)
        {
            initialize(dr);
        }

        public int? id { get; set; }
        public string nombre { get; set; }

        public Funcionalidad initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("id"))
                id = (dr["id"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["id"]);
            if (dcc.Contains("nombre"))
                nombre = (dr["nombre"] == DBNull.Value) ? null : dr["nombre"].ToString();
            
            return this;
        }

        private DataRow dr;

        public Funcionalidad setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public void setById(object _id)
        {
            initialize(new DAOFuncionalidad().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Funcionalidad aux = obj as Funcionalidad;
            if ((object)aux == null)
                return false;

            return aux.id == id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static List<Funcionalidad> ObtenerFuncionalidades(int id)
        {
            List<Funcionalidad> l = new List<Funcionalidad>();

            SqlDataReader lector = DBAcess.GetDataReader(
                "SELECT f.id, f.nombre from VIDA_ESTATICA.Funcionalidad f INNER JOIN VIDA_ESTATICA.Funcionalidad_Rol fr ON f.id = fr.funcionalidad AND fr.rol =" + id, "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad f = new Funcionalidad();
                    f.id = (int)(decimal)lector["id"];
                    f.nombre = (string)lector["nombre"];
                    l.Add(f);
                }
            }
            return l;
        }


        public static List<Funcionalidad> ObtenerFuncionalidades()
        {
            List<Funcionalidad> l = new List<Funcionalidad>();

            SqlDataReader lector = DBAcess.GetDataReader("SELECT * from VIDA_ESTATICA.Funcionalidad", "T", new List<SqlParameter>());

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad f = new Funcionalidad();
                    f.id = (int)(decimal)lector["id"];
                    f.nombre = (string)lector["nombre"];
                    l.Add(f);
                }
            }
            return l;
        }

        public static List<Funcionalidad> DependeDe(int id)
        {
            List<Funcionalidad> l = new List<Funcionalidad>();
            SqlDataReader lector = DBAcess.GetDataReader("SELECT * from VIDA_ESTATICA.Funcionalidad_Rol WHERE rol = " + id, "T", new List<SqlParameter>());

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad f = new Funcionalidad();
                    l.Add(f);
                }
            }
            return l;
        }

        public static bool AgregarFuncionalidadEnRol(int idRol, Funcionalidad unaFunc)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idRol", idRol));
            ListaParametros.Add(new SqlParameter("@idFunc", (int)unaFunc.id));

            return DBAcess.WriteInBase("INSERT INTO VIDA_ESTATICA.Funcionalidad_Rol (rol, funcionalidad) VALUES (@idRol, @idFunc)", "T", ListaParametros);
        }

        public override string ToString()
        {
            return this.nombre;
        }
    }
}