using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PagoElectronico.Models.DAO;

namespace PagoElectronico.Models.BO
{
    public partial class Tarjeta: IBO<Tarjeta>
    {
        public Tarjeta() { }

        public Tarjeta(DataRow dr) { initialize(dr); }

        public long? numero { get; set; }
        public string numeroMostrable { get; set; }
        public DateTime? fecha_emision { get; set; }
        public DateTime? fecha_vencimiento { get; set; }
        public int? cod_seguridad { get; set; }
        public int? emisor { get; set; }
        public int? cli_cod { get; set; }

        private DataRow dr;

        // Data de visualización
        public string Visualize { get { return ShowLastFourDigits() + " - " + tEmisor.nombre; } }
        public string numberVisualize { get { return ShowLastFourDigits(); } }

        private string ShowLastFourDigits()
        {
            return "*" + numero.ToString().Substring(numero.ToString().Length - 4);
        }

        public Emisor tEmisor { get; set; }

        public Tarjeta initialize(DataRow _dr)
        {
            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;


            if (dcc.Contains("numero"))
                numero = (dr["numero"] == DBNull.Value) ? null : (long?)Convert.ToInt64(dr["numero"]);
            if (dcc.Contains("fecha_emision"))
                fecha_emision = (dr["fecha_emision"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(dr["fecha_emision"]);
            if (dcc.Contains("fecha_vencimiento"))
                fecha_vencimiento = (dr["fecha_vencimiento"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(dr["fecha_vencimiento"]);
            if (dcc.Contains("cod_seguridad"))
                cod_seguridad = (dr["cod_seguridad"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["cod_seguridad"]);
            if (dcc.Contains("emisor"))
                emisor = (dr["emisor"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["emisor"]);
            if (dcc.Contains("cli_cod"))
                cli_cod = (dr["cli_cod"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["cli_cod"]);

            numeroMostrable = this.numberVisualize;

            DAOEmisor daoEmisor = new DAOEmisor();
            tEmisor = daoEmisor.retrieveBy_id(emisor);
            return this;
        }

        public string nombre_emisor()
        {
            DAOEmisor dao = new DAOEmisor();
            Emisor emiso = dao.retrieveBy_id(this.emisor);
            return emiso.nombre;
        }

        public Tarjeta setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Tarjeta aux = obj as Tarjeta;
            if ((object)aux == null)
                return false;

            return aux.numero == numero;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
