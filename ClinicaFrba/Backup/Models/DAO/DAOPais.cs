using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;
using PagoElectronico.Models.DataBase;
using System.Data.SqlClient;

namespace PagoElectronico.Models.DAO {
    public partial class DAOPais: DAOBase<Pais> {
        public DAOPais()
            : base("VIDA_ESTATICA.Pais", "id") {
        }
        
        public Pais update(Pais _Pais) {
			DB.ExecuteNonQuery("UPDATE"); //FIXIT
			return DB.ExecuteReaderSingle<Pais>("SELECT * FROM Pais WHERE id = @1", _Pais.id);
        }

        public Pais create(Pais _Pais) {
            if (_Pais.id == null || !_Pais.id.HasValue) {
                int id = DB.ExecuteCastable<int>("INSERT INTO Vida_Estatica.Pais (descripcion) values ('"+ _Pais.descripcion+ "'); SELECT SCOPE_IDENTITY();"); //FIXIT
                return DB.ExecuteReaderSingle<Pais>("SELECT * FROM Pais WHERE id = @1", id);
			} else
				return update(_Pais);
        }
		
		public void delete(int Pais_id) {
			DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE id = @1", Pais_id);
        }

		public Pais retrieveBy_id(object _value){
            return DB.ExecuteReaderSingle<Pais>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
		}

        public int retrieveBy_name(String name)
        {
            int id = -1;
            SqlDataReader lector = DBAcess.GetDataReader("SELECT id FROM VIDA_ESTATICA.Pais where descripcion like '%" + name + "'", "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    id = (int)(decimal)lector["id"];
                }
            }
            return id;
        }

        public List<Pais> topMovimientos(int anio, int min, int max)
        {
            string comando = "SELECT TOP 5 "
                                + "p.descripcion, "
                                + "COUNT(d.id) + COUNT(r.id) AS MOVIMIENTOS "
                                + "FROM VIDA_ESTATICA.Pais p "
                                + "INNER JOIN VIDA_ESTATICA.Cliente cli "
                                + "ON p.id = cli.nacionalidad "
                                + "INNER JOIN VIDA_ESTATICA.Cuenta cue "
                                + "ON cue.cod_cli = cli.id "
                                + "INNER JOIN VIDA_ESTATICA.Deposito d "
                                + "ON cue.id = d.cuenta_destino "
                                + "INNER JOIN VIDA_ESTATICA.Retiro r "
                                + "ON cue.id = r.cuenta_destino "
                                + "WHERE (YEAR(r.fecha) = " + anio + " "
                                + "AND MONTH(r.fecha) IN (" + min + "," + max + ")) "
                                + "AND (YEAR(d.fecha) = " + anio + " "
                                + "AND MONTH(d.fecha) IN (" + min + "," + max + ")) "
                                + "GROUP BY p.descripcion "
                                + "ORDER BY MOVIMIENTOS DESC ";
            List<Pais> cp = DB.ExecuteReader<Pais>(comando);

            foreach (Pais p in cp)
            {
                comando = "SELECT TOP 5 "
                                + "COUNT(d.id) + COUNT(r.id) AS MOVIMIENTOS "
                                + "FROM VIDA_ESTATICA.Pais p "
                                + "INNER JOIN VIDA_ESTATICA.Cliente cli "
                                + "ON p.id = cli.nacionalidad "
                                + "INNER JOIN VIDA_ESTATICA.Cuenta cue "
                                + "ON cue.cod_cli = cli.id "
                                + "INNER JOIN VIDA_ESTATICA.Deposito d "
                                + "ON cue.id = d.cuenta_destino "
                                + "INNER JOIN VIDA_ESTATICA.Retiro r "
                                + "ON cue.id = r.cuenta_destino "
                                + "WHERE (YEAR(r.fecha) = " + anio + " "
                                + "AND MONTH(r.fecha) IN (" + min + "," + max + ")) "
                                + "AND (YEAR(d.fecha) = " + anio + " "
                                + "AND MONTH(d.fecha) IN (" + min + "," + max + ")) "
                                + "AND p.descripcion = '" + p.descripcion + "' "
                                + "GROUP BY p.descripcion "
                                + "ORDER BY MOVIMIENTOS DESC ";
                p.movimiento = (int)DB.ExecuteCardinal(comando);
            }


            return cp;
        }
    }
}
