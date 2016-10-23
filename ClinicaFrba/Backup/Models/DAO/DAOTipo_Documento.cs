using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOTipoDocumento: DAOBase<TipoDocumento>
    {
        public DAOTipoDocumento()
            : base("VIDA_ESTATICA.Tipo_Documento", "id")
        {
        }

        public TipoDocumento update(TipoDocumento _Tipo_Documento)
        {
            DB.ExecuteNonQuery("UPDATE"); //FIXIT
            return DB.ExecuteReaderSingle<TipoDocumento>("SELECT * FROM Tipo_Documento WHERE id = @1", _Tipo_Documento.id);
        }

        public TipoDocumento create(TipoDocumento _Tipo_Documento)
        {
            if (_Tipo_Documento.id == null || !_Tipo_Documento.id.HasValue)
            {
                int id = DB.ExecuteCastable<int>("INSERT INTO Tipo_Documento () values (); SELECT SCOPE_IDENTITY();"); //FIXIT
                return DB.ExecuteReaderSingle<TipoDocumento>("SELECT * FROM Tipo_Documento WHERE id = @1", id);
            }
            else
                return update(_Tipo_Documento);
        }

        public void delete(int Tipo_Documento_id)
        {
            DB.ExecuteNonQuery("DELETE FROM" + tabla + " WHERE tipo = @1", Tipo_Documento_id);
        }
        public TipoDocumento retrieveBy_id(object _value)
        {
            string comando = "SELECT * FROM " + tabla + " WHERE tipo = @1" + _value;
            return DB.ExecuteReaderSingle<TipoDocumento>("SELECT * FROM " + tabla + " WHERE id = @1", _value);

        }

        public TipoDocumento retrieveBy_desc(string _value)
        {

            return DB.ExecuteReaderSingle<TipoDocumento>("SELECT * FROM " + tabla + " WHERE descripcion = @1", _value);

        }
    }
}
