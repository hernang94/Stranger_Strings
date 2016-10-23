using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PagoElectronico.Models.BO
{
    public partial class Emisor : IBO<Emisor>
    {
        public int? id { get; set; }
        public string nombre { get; set; }

        private DataRow dr;

        public Emisor() {}

          public Emisor(DataRow dr)
        {
            initialize(dr);
        }

          public Emisor setData(DataRow dr)
          {
              initialize(dr);

              return this;
          }

        public Emisor initialize(DataRow _dr) {
            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;
            if (dcc.Contains("id"))
                id = (dr["id"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["id"]);
            if (dcc.Contains("nombre"))
                nombre = dr["nombre"].ToString();
            return this;
        }
    }
}
