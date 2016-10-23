using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOCheque : DAOBase<Cheque>
    {
         public DAOCheque()
            : base("VIDA_ESTATICA.Cheque", "id") {
        }

         private static string columns = "id_egreso,fecha,importe,cuenta_destino,tipo_moneda,cod_banco";

         public int generarEgreso()
         {
             return DB.ExecuteCardinal("SELECT ISNULL(MAX(id_egreso), 0) + 20 FROM VIDA_ESTATICA.Cheque;");
         }

         public Cheque create(Cheque cheque)
         {
             long id = DB.ExecuteCastable<long>("INSERT INTO " + tabla + " (" + columns + ") values (" + CreateValues(cheque) + "); SELECT SCOPE_IDENTITY();"); //FIXIT
             return DB.ExecuteReaderSingle<Cheque>("SELECT * FROM " + tabla + " WHERE id = @1", id);
         }

         private string CreateValues(Cheque cheque)
         {
             // Adapt to sql server
             string[] imp = cheque.importe.ToString().Split(',');
             string sqlDouble = "";
             if (imp.Length == 2) sqlDouble = imp[0] + "." + imp[1];
             else sqlDouble = imp[0];
             return cheque.id_egreso.ToString() + "," +
                    cheque.retiro_fecha.ToString("dd/MM/yyyy") + "," +
                    sqlDouble + "," +
                    cheque.cuenta_destino.ToString() + "," +
                    cheque.tipo_moneda.ToString() + "," +
                    cheque.cod_banco.ToString();
         }

    }
}
