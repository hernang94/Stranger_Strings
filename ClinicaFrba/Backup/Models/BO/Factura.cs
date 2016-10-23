using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Generic;

using PagoElectronico.Models.DAO;

namespace PagoElectronico.Models.BO
{
    public partial class Factura : IBO<Factura>
    {

        public Factura() { }

        public Factura(DataRow dr)
        {
            initialize(dr);
        }

        public DateTime? fecha { get; set; }
        public long? idCliente { get; set; }
        public long? idFactura { get; set; }

        public Factura initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("id_factura"))
                idFactura = (dr["id_factura"] == DBNull.Value) ? null : (long?)Convert.ToInt64(dr["id_factura"]);
            if (dcc.Contains("id_cliente"))
                idCliente = (dr["id_cliente"] == DBNull.Value) ? null : (long?)Convert.ToInt64(dr["id_cliente"]);
            if (dcc.Contains("fecha"))
                fecha = (dr["fecha"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dr["fecha"]);
            return this;
        }

        private DataRow dr;

        public Factura setData(DataRow dr)
        {
            initialize(dr);
            return this;
        }

     
        public void setById(object _id)
        {
            initialize(new DAOFactura().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Factura aux = obj as Factura;
            if ((object)aux == null)
                return false;

            return aux.idFactura == idFactura;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}