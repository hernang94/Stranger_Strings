using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOFuncionalidad : DAOBase<Funcionalidad>
    {
        public DAOFuncionalidad()
            : base("VIDA_ESTATICA.Funcionalidad", "id")
        {
        }

        public Funcionalidad update(Funcionalidad _Funcionalidad)
        {
            DB.ExecuteNonQuery("UPDATE"); //FIXIT
            return DB.ExecuteReaderSingle<Funcionalidad>("SELECT * FROM Funcionalidad WHERE id = @1", _Funcionalidad.id);
        }

        public Funcionalidad create(Funcionalidad _Funcionalidad)
        {
            if (_Funcionalidad.id == null || !_Funcionalidad.id.HasValue)
            {
                int id = DB.ExecuteCastable<int>("INSERT INTO Funcionalidad () values (); SELECT SCOPE_IDENTITY();"); //FIXIT
                return DB.ExecuteReaderSingle<Funcionalidad>("SELECT * FROM Funcionalidad WHERE id = @1", id);
            }
            else
                return update(_Funcionalidad);
        }

        public void delete(int Funcionalidad_id)
        {
            DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE id = @1", Funcionalidad_id);
        }

        public Funcionalidad retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Funcionalidad>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
        }
    }
}
