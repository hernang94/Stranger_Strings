using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PagoElectronico.Models.BO
{
    public partial class Retiro : IBO<Retiro>
    {
        public Retiro() { }
        private DataRow dr;

        public long id { get; set; }
        public DateTime fecha { get; set; }
        public double importe { get; set; }
        public long cuenta_destino { get; set; }
        public int moneda { get; set; }

        public Retiro initialize(DataRow _dr)
        {
            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;
            if (dcc.Contains("id"))
                id = Convert.ToInt64(dr["id"]);
            if (dcc.Contains("fecha"))
                fecha = Convert.ToDateTime(dr["fecha"]);
            if (dcc.Contains("importe"))
                importe = Convert.ToDouble(dr["importe"]);
            if (dcc.Contains("cuenta_destino"))
                cuenta_destino = Convert.ToInt64(dr["cuenta_destino"]);
            if (dcc.Contains("moneda"))
                moneda = Convert.ToInt32(dr["moneda"]);

            return this;
        }

         public Retiro(DataRow dr)
        {
            initialize(dr);
        }


        public Retiro setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }
    }
}
