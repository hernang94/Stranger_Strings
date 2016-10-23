using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Generic;

using PagoElectronico.Models.DAO;

namespace PagoElectronico.Models.BO
{
    public partial class Cuenta : IBO<Cuenta>
    {

        public Cuenta() { }

        public Cuenta(DataRow dr)
        {
            initialize(dr);
        }
        
        public long? id { get; set; }
        public long? numCuenta { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public int? estado { get; set; }
        public int? pais { get; set; }
        public DateTime? fechaCierre { get; set; }
        public double saldo { get; set; }
        public int? tipoMoneda { get; set; }
        public int? tipoCuenta { get; set; }
        public int? codigoCliente { get; set; }

        // Atributos extra que se necesitan para presentar
        public string Visualize { get { return numCuenta + " - "  + cPais.descripcion; } }
        public Banco banco { get; set; }
        public Pais cPais { get; set; }

        public Cuenta initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("id"))
                id = (dr["id"] == DBNull.Value) ? null : (long?)Convert.ToInt64(dr["id"]);
            if (dcc.Contains("num_cuenta"))
                numCuenta = (dr["num_cuenta"] == DBNull.Value) ? null : (long?)Convert.ToInt64(dr["num_cuenta"]);
            if (dcc.Contains("fecha_creacion"))
                fechaCreacion = (dr["fecha_creacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_creacion"]);
            if (dcc.Contains("estado"))
                estado = (dr["estado"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["estado"]);
            if (dcc.Contains("pais"))
                pais = (dr["pais"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["pais"]);
            if (dcc.Contains("fecha_cierre"))
                fechaCierre = (dr["fecha_cierre"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_cierre"]);
            if (dcc.Contains("saldo"))
                saldo = Convert.ToDouble(dr["saldo"]);
            if (dcc.Contains("tipo_moneda"))
                tipoMoneda = (dr["tipo_moneda"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["tipo_moneda"]);
            if (dcc.Contains("tipo_cuenta"))
                tipoCuenta = (dr["tipo_cuenta"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["tipo_cuenta"]);
            if (dcc.Contains("cod_cli"))
                codigoCliente = (dr["cod_cli"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["cod_cli"]);
            // Buscar y componer banco y país para tenerlos a mano
            DAOPais daoPais = new DAOPais();
            cPais = daoPais.retrieveBy_id(pais);
            return this;
        }

        private DataRow dr;

        public Cuenta setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public void setById(object _id)
        {
            initialize(new DAOCuenta().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Cuenta aux = obj as Cuenta;
            if ((object)aux == null)
                return false;

            return aux.id == id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}