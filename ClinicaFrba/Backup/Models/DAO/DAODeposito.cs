using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAODeposito : DAOBase<Deposito>
    {
        public DAODeposito()
            : base("VIDA_ESTATICA.Deposito", "id")
        {
        }

        private static string columns = "fecha,importe,tipo_moneda,tarjeta,cuenta_destino,emisor";

        public Deposito create(Deposito depo)
        {
            long id = DB.ExecuteCastable<long>("INSERT INTO " + tabla + " (" + columns + ") values (" + CreateValues(depo) + "); SELECT SCOPE_IDENTITY();"); //FIXIT
            return DB.ExecuteReaderSingle<Deposito>("SELECT * FROM "+ tabla +" WHERE id = @1", id);
        }

        private string CreateValues(Deposito depo)
        {
            string[] imp = depo.importe.ToString().Split(',');
            string sqlDouble = "";
            if (imp.Length == 2) sqlDouble = imp[0] + "." + imp[1];
            else sqlDouble = imp[0];
            return depo.fecha.ToString("dd/MM/yyyy") + "," +
                   sqlDouble + "," +
                   depo.tipo_moneda.ToString() + "," +
                   depo.tarjeta_numero.ToString() + "," +
                   depo.cuenta_destino.ToString() + "," + 
                   depo.emisor.ToString();
        }


        public List<Deposito> ultimosDepositosDeCuenta(Cuenta c)
        {
            string query = String.Format("SELECT TOP 5 * FROM {0} WHERE cuenta_destino = {1} ORDER BY id DESC", tabla, c.id);
            return DB.ExecuteReader<Deposito>(query);
        }

        
    }
}
