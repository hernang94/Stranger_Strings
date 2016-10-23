using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Generic;

using PagoElectronico.Models.DAO;

namespace PagoElectronico.Models.BO
{
    public partial class Cliente : IBO<Cliente>
    {

        public Cliente() { }

        public Cliente(DataRow dr)
        {
            initialize(dr);
        }

        public int? id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fecha_nac { get; set; }
        public int? documento { get; set; }
        public int? tipo_documento { get; set; }
        public string dom_calle { get; set; }
        public int? dom_piso { get; set; }
        public string dom_dpto { get; set; }
        public int? dom_nro { get; set; }
        public string mail { get; set; }
        public int? nacionalidad { get; set; }
        public string usuario { get; set; }
        public bool? activo { get; set; }
        

        public Cliente initialize(DataRow _dr)
        {

            dr = _dr;
            DataColumnCollection dcc = dr.Table.Columns;

            if (dcc.Contains("id"))
                id = (dr["id"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["id"]);
            if (dcc.Contains("nombre"))
                nombre = (dr["nombre"] == DBNull.Value) ? null : dr["nombre"].ToString();
            if (dcc.Contains("apellido"))
                apellido = (dr["apellido"] == DBNull.Value) ? null : dr["apellido"].ToString();
            if (dcc.Contains("documento"))
                documento = (dr["documento"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["documento"]);
            if (dcc.Contains("tipo_documento"))
                tipo_documento = (dr["tipo_documento"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["tipo_documento"]);
            if (dcc.Contains("dom_calle"))
                dom_calle = (dr["dom_calle"] == DBNull.Value) ? null : dr["dom_calle"].ToString();
            if (dcc.Contains("dom_piso"))
                dom_piso = (dr["dom_piso"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["dom_piso"]);
            if (dcc.Contains("dom_dpto"))
                dom_dpto = (dr["dom_dpto"] == DBNull.Value) ? null :  dr["dom_dpto"].ToString();
            if (dcc.Contains("dom_nro"))
                dom_nro = (dr["dom_nro"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["dom_nro"]);
            if (dcc.Contains("mail"))
                mail = (dr["mail"] == DBNull.Value) ? null : dr["mail"].ToString();
            if (dcc.Contains("nacionalidad"))
                nacionalidad = (dr["nacionalidad"] == DBNull.Value) ? null : (int?)Convert.ToInt32(dr["nacionalidad"]);
            if (dcc.Contains("fecha_nac"))
                fecha_nac = (dr["fecha_nac"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(dr["fecha_nac"]);
            if (dcc.Contains("activo"))
                activo = (dr["activo"] == DBNull.Value) ? null : (bool?)dr["activo"];
            if (dcc.Contains("usuario"))
                usuario = (dr["usuario"] == DBNull.Value) ? null : dr["usuario"].ToString();


            return this;
        }

        private DataRow dr;

        public Cliente setData(DataRow dr)
        {
            initialize(dr);

            return this;
        }

        public string get_pais()
        {
            DAOPais dao = new DAOPais();
            Pais pais = dao.retrieveBy_id(this.nacionalidad);
            return pais.descripcion;
        }

        public List<Tarjeta> get_tarjetas()
        {
            DAOTarjeta dao = new DAOTarjeta();
            List<Tarjeta> tarjetas = dao.retrieveByClientId(this.id);
            return tarjetas;
        }

        public void setById(object _id)
        {
            initialize(new DAOCliente().retrieveBy_id(_id).dr);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Cliente aux = obj as Cliente;
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