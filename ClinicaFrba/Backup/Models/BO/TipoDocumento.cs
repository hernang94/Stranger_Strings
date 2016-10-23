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
    public partial class TipoDocumento : IBO<TipoDocumento>
    {

        public TipoDocumento() { }

        public TipoDocumento(DataRow dr)
        {
            initialize(dr);
        }

        public int? id { get; set; }
        public string descripcion { get; set; }

        public TipoDocumento initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("id"))
                id = (dr["id"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["id"]);
            if (dcc.Contains("descripcion"))
                descripcion = (dr["descripcion"] == DBNull.Value) ? null : dr["descripcion"].ToString();

            return this;
        }

        private DataRow dr;

        public TipoDocumento setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public void setById(object _id)
        {
            initialize(new DAOTipoDocumento().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            TipoDocumento aux = obj as TipoDocumento;
            if ((object)aux == null)
                return false;

            return aux.id == id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static List<TipoDocumento> ObtenerTiposDocumento()
        {
            List<TipoDocumento> l = new List<TipoDocumento>();
            
            SqlDataReader lector = DBAcess.GetDataReader("SELECT DISTINCT * FROM VIDA_ESTATICA.Tipo_Documento", "T");

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    TipoDocumento unTipoDocumento = new TipoDocumento();
                    
                    unTipoDocumento.descripcion = (string)lector["descripcion"];

                    l.Add(unTipoDocumento);
                }
            }
            else
            {
            }

            return l;
        }
    }
}