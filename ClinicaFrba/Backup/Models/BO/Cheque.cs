using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PagoElectronico.Models.BO
{
    public partial class Cheque : IBO<Cheque>
    {
        public Cheque() { }

        private DataRow dr;

        public long id { get; set; }
        public long id_egreso { get; set; }
        public DateTime retiro_fecha { get; set; }
        public double importe { get; set; }
        public long? cuenta_destino { get; set; }
        public int? tipo_moneda { get; set; }
        public int? cod_banco { get; set; }

        public Cheque initialize(DataRow _dr)
        {
            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;
            if (dcc.Contains("id"))
                id = Convert.ToInt64(dr["id"]);
            if (dcc.Contains("id_egreso"))
                id_egreso = Convert.ToInt64(dr["id_egreso"]);
            if (dcc.Contains("fecha"))
                retiro_fecha = Convert.ToDateTime(dr["fecha"]);
            if (dcc.Contains("importe"))
                importe = Convert.ToDouble(dr["importe"]);
            if (dcc.Contains("cuenta_destino"))
                cuenta_destino = (dr["cuenta_destino"] == DBNull.Value) ? null : (long?)Convert.ToInt64(dr["cuenta_destino"]);
            if (dcc.Contains("tipo_moneda"))
                tipo_moneda = (dr["tipo_moneda"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["tipo_moneda"]);
            if (dcc.Contains("cod_banco"))
                cod_banco = (dr["cod_banco"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["cod_banco"]);

            return this;
        }

        public Cheque(DataRow dr)
        {
            initialize(dr);
        }


        public Cheque setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }
    }
}
