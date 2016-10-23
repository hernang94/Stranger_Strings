using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Generic;

using PagoElectronico.Models.DAO;

namespace PagoElectronico.Models.BO
{
    public partial class Banco : IBO<Banco>
    {

        public Banco() { }

        public Banco(DataRow dr)
        {
            initialize(dr);
        }

        public int? cod { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }

        public Banco initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("cod"))
                cod = (dr["cod"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["cod"]);
            if (dcc.Contains("nombre"))
                nombre = (dr["nombre"] == DBNull.Value) ? null : dr["nombre"].ToString();
            if (dcc.Contains("direccion"))
                direccion = (dr["direccion"] == DBNull.Value) ? null : dr["direccion"].ToString();

            return this;
        }

        private DataRow dr;

        public Banco setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public void setById(object _id)
        {
            initialize(new DAOBanco().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Banco aux = obj as Banco;
            if ((object)aux == null)
                return false;

            return aux.cod == cod;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.nombre.Trim() + " | " + this.cod;
        }

    }
}