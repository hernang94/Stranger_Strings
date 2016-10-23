using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOEstadoCuenta : DAOBase<EstadoCuenta>
    {
        private static string HABILITADA = "Habilitada";
        public DAOEstadoCuenta()
            : base("VIDA_ESTATICA.Estado_Cuenta", "id")
        {
        }

        public EstadoCuenta update(EstadoCuenta _Estado_Cuenta)
        {
            DB.ExecuteNonQuery("UPDATE"); //FIXIT
            return DB.ExecuteReaderSingle<EstadoCuenta>("SELECT * FROM Estado_Cuenta WHERE id = @1", _Estado_Cuenta.id);
        }

        public EstadoCuenta create(EstadoCuenta _Estado_Cuenta)
        {
            if (_Estado_Cuenta.id == null || !_Estado_Cuenta.id.HasValue)
            {
                int id = DB.ExecuteCastable<int>("INSERT INTO Estado_Cuenta () values (); SELECT SCOPE_IDENTITY();"); //FIXIT
                return DB.ExecuteReaderSingle<EstadoCuenta>("SELECT * FROM Estado_Cuenta WHERE id = @1", id);
            }
            else
                return update(_Estado_Cuenta);
        }

        public void delete(int Estado_Cuenta_id)
        {
            DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE id = @1", Estado_Cuenta_id);
        }
        public EstadoCuenta retrieveBy_id(object _value)
        {

            return DB.ExecuteReaderSingle<EstadoCuenta>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
        }

        public EstadoCuenta habilitado() {
            return DB.ExecuteReaderSingle<EstadoCuenta>("SELECT * FROM " + tabla +" WHERE descripcion = @1", HABILITADA);
        }
    }
}