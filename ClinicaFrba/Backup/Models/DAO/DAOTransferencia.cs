using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOTransferencia : DAOBase<Transferencia>
    {
        public DAOTransferencia(): base("VIDA_ESTATICA.Transferencia", "id") 
        {
        }

        public Transferencia retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Transferencia>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
        }

        public List<Transferencia> ultimasTransferenciasDeCuenta(Cuenta c)
        {
            string query = String.Format("SELECT TOP 10 * FROM {0} WHERE cuenta_destino = {1} ORDER BY fecha DESC", tabla, c.id);
            return DB.ExecuteReader<Transferencia>(query);
        }

         private static string columns = "fecha,importe,costo,cuenta_origen,cuenta_destino,tipo_moneda";

         internal Transferencia create(Transferencia transferencia)
         {
             long id = DB.ExecuteCastable<long>("INSERT INTO " + tabla + " (" + columns + ") values (" + CreateValues(transferencia) + "); SELECT SCOPE_IDENTITY();"); //FIXIT
             return DB.ExecuteReaderSingle<Transferencia>("SELECT * FROM " + tabla + " WHERE id = @1", id);
         }

         private string CreateValues(Transferencia tran)
         {
             string[] imp = tran.importe.ToString().Split(',');
             string sqlDouble = "";
             if (imp.Length == 2) sqlDouble = imp[0] + "." + imp[1];
             else sqlDouble = imp[0];
             return "CAST('" + tran.fecha.ToString("dd/MM/yyyy")+"' AS DATE)" + "," +
                    sqlDouble + "," +
                    tran.costo.ToString() + "," +
                    tran.cuenta_origen.ToString() + "," +
                    tran.cuenta_destino.ToString() + "," +
                    tran.tipo_moneda.ToString();
         }
    }
}
