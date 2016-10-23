using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO {
    public partial class DAOMoneda: DAOBase<Moneda> {
        public DAOMoneda()
            : base("VIDA_ESTATICA.Moneda", "id") {
        }

        public Moneda update(Moneda _Moneda)
        {
			DB.ExecuteNonQuery("UPDATE"); 
			return DB.ExecuteReaderSingle<Moneda>("SELECT * FROM Moneda WHERE id = @1", _Moneda.id);
        }

        public Moneda create(Moneda _Moneda)
        {
            if (_Moneda.id == null || !_Moneda.id.HasValue) {
                int id = DB.ExecuteCastable<int>("INSERT INTO Moneda () values (); SELECT SCOPE_IDENTITY();"); //FIXIT
                return DB.ExecuteReaderSingle<Moneda>("SELECT * FROM Moneda WHERE id = @1", id);
			} else
				return update(_Moneda);
        }
		
		public void delete(int Moneda_id) {
			DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE tipo = @1", Moneda_id);
        }
        
        public Moneda retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Moneda>("SELECT * FROM " + tabla + " WHERE tipo = @1", _value);
		}
    }
}
