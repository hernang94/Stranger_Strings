using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO {
    public partial class DAOTipoCuenta: DAOBase<TipoCuenta> {
        public DAOTipoCuenta()
            : base("VIDA_ESTATICA.Tipo_Cuenta", "id") {
        }
        
        public TipoCuenta update(TipoCuenta _Tipo_Cuenta) {
			DB.ExecuteNonQuery("UPDATE"); //FIXIT
			return DB.ExecuteReaderSingle<TipoCuenta>("SELECT * FROM Tipo_Cuenta WHERE id = @1", _Tipo_Cuenta.id);
        }

        public TipoCuenta create(TipoCuenta _Tipo_Cuenta) {
            if (_Tipo_Cuenta.id == null || !_Tipo_Cuenta.id.HasValue) {
                int id = DB.ExecuteCastable<int>("INSERT INTO Tipo_Cuenta () values (); SELECT SCOPE_IDENTITY();"); //FIXIT
                return DB.ExecuteReaderSingle<TipoCuenta>("SELECT * FROM Tipo_Cuenta WHERE id = @1", id);
			} else
				return update(_Tipo_Cuenta);
        }
		
		public void delete(int Tipo_Cuenta_id) {
			DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE tipo = @1", Tipo_Cuenta_id);
        }
		public TipoCuenta retrieveBy_id(object _value){
			
            return DB.ExecuteReaderSingle<TipoCuenta>("SELECT * FROM " + tabla + " WHERE tipo = @1", _value);
			
		}

        internal int costo_transaccion(long p)
        {
            return DB.ExecuteCardinal("SELECT costo_transaccion FROM " + tabla + " t INNER JOIN VIDA_ESTATICA.Cuenta c ON c.tipo_cuenta = t.id WHERE c.id = " + p);
        }

        public List<TipoCuenta> topFacturadores(int anio, int min, int max)
        {
            string comando = "SELECT TOP 5 tc.descripcion "
                                + "FROM VIDA_ESTATICA.Tipo_Cuenta tc "
                                + "INNER JOIN VIDA_ESTATICA.Cuenta c "
                                + "ON tc.id = c.id "
                                + "INNER JOIN VIDA_ESTATICA.Item_Factura i "
                                + "ON i.num_cuenta = c.id "
                                + "WHERE YEAR(i.fecha) = " + anio + " "
                                + "AND MONTH(i.fecha) IN (" + min + "," + max + ") "
                                + "GROUP BY tc.descripcion";
            List<TipoCuenta> tc = DB.ExecuteReader<TipoCuenta>(comando);

            foreach (TipoCuenta t in tc)
            {
                comando = "SELECT ISNULL(SUM(i.monto), 0) "
                                + "FROM VIDA_ESTATICA.Tipo_Cuenta tc "
                                + "INNER JOIN VIDA_ESTATICA.Cuenta c "
                                + "ON tc.id = c.id "
                                + "INNER JOIN VIDA_ESTATICA.Item_Factura i "
                                + "ON i.num_cuenta = c.id "
                                + "WHERE YEAR(i.fecha) = " + anio + " "
                                + "AND MONTH(i.fecha) IN (" + min + "," + max + ") "
                                + "AND tc.descripcion = '"+ t.descripcion + "' "
                                + "GROUP BY tc.descripcion";
                t.monto = (double)DB.ExecuteDecimal(comando);

            }

            return tc;
        }
    }
}
