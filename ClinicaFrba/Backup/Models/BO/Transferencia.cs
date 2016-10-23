using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PagoElectronico.Models.BO
{
    public partial class Transferencia : IBO<Transferencia>
    {
        
        public Transferencia() { }

        public Transferencia(DataRow dr)
        {
            initialize(dr);
        }

        public Transferencia setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }
        private DataRow dr;
  
        public long id {get; set;}
        public DateTime fecha {get; set;}
        public double costo {get; set;}
        public double importe { get; set; }
        public long cuenta_origen {get; set;}
        public long cuenta_destino {get; set;}
        public int tipo_moneda {get; set;}

        public Transferencia initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("id"))
                id = Convert.ToInt64(dr["id"]);
            if (dcc.Contains("fecha"))
                fecha = Convert.ToDateTime(dr["fecha"]);
            if (dcc.Contains("costo"))
                costo = Convert.ToInt32(dr["costo"]);
            if (dcc.Contains("cuenta_origen"))
                cuenta_origen = Convert.ToInt64(dr["cuenta_origen"]);
            if (dcc.Contains("cuenta_destino"))
                cuenta_destino = Convert.ToInt64(dr["cuenta_destino"]);
            if (dcc.Contains("tipo_moneda"))
                tipo_moneda = Convert.ToInt32(dr["tipo_moneda"]);
            if (dcc.Contains("importe"))
                importe = Convert.ToDouble(dr["importe"]);
            
            return this;
        }


    }
}
