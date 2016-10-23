using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOFactura : DAOBase<Factura>
    {
        public DAOFactura()
            : base("VIDA_ESTATICA.Factura", "id_factura")
        {
        }

        public void delete(int Factura_cod)
        {
            DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE id_factura = @1", Factura_cod);
        }

        public Factura retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Factura>("SELECT * FROM " + tabla + " WHERE id_factura = @1", _value);
        }

        internal List<Factura> retrieveAll()
        {
            return DB.ExecuteReader<Factura>("SELECT * FROM " + tabla);
        }

        internal List<Factura> obtenerFacturaCliFecha(string fecha, string cod_cli)
        {
            return DB.ExecuteReader<Factura>("SELECT * FROM " + tabla + " WHERE CAST(fecha as DATE) = CAST( " + fecha + " as DATE) AND id_cliente = " + cod_cli);
        }
    }
}
