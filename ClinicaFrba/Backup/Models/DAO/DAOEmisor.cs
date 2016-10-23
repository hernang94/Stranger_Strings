using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;
using System.Data.SqlClient;
using PagoElectronico.Models.DataBase;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOEmisor : DAOBase<Emisor>
    {
        public DAOEmisor()
            : base("VIDA_ESTATICA.Emisor", "id")
        {
        }

        public Emisor retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Emisor>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
        }

        public List<Emisor> retrieveAll()
        {
            List<Emisor> e = new List<Emisor>();
            SqlDataReader lector = DBAcess.GetDataReader("SELECT * from VIDA_ESTATICA.Emisor", "T", new List<SqlParameter>());

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Emisor unEmisor = new Emisor();
                    unEmisor.nombre = (string)lector["nombre"];
                    unEmisor.id = (int)(decimal)lector["id"];
                    e.Add(unEmisor);
                }
            }
            return e;
        }
    }
}
