using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Generic;

using PagoElectronico.Models.DAO;

namespace PagoElectronico.Models.BO
{
    public partial class EstadoCuenta : IBO<EstadoCuenta>
    {

        public EstadoCuenta() { }

        public EstadoCuenta(DataRow dr)
        {
            initialize(dr);
        }

        public enum EstadosCuenta { PendienteActivacion = 1, Cerrada, Inhabilitada, Habilitada };
        public int? id { get; set; }
        public string descripcion { get; set; }

        public EstadoCuenta initialize(DataRow _dr)
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

        public EstadoCuenta setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public void setById(object _id)
        {
            initialize(new DAOEstadoCuenta().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            EstadoCuenta aux = obj as EstadoCuenta;
            if ((object)aux == null)
                return false;

            return aux.id == id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
