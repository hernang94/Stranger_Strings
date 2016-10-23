using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOCuenta: DAOBase<Cuenta>
    {
        public DAOCuenta()
            : base("VIDA_ESTATICA.Cuenta", "id")
        {
        }

        public Cuenta update(Cuenta _Cuenta)
        {
            int tipoViejo = (int)retrieveBy_id(_Cuenta.id).tipoCuenta;
            string update = String.Format("UPDATE " + tabla + " SET pais={0},tipo_moneda={1},tipo_cuenta={2}, estado={3} WHERE id = {4}", _Cuenta.pais, _Cuenta.tipoMoneda, _Cuenta.tipoCuenta, _Cuenta.estado, _Cuenta.id);
            DB.ExecuteNonQuery(update);
            if (tipoViejo != _Cuenta.tipoCuenta)
                DB.ExecuteNonQuery(String.Format("EXEC VIDA_ESTATICA.modificarTipoCuenta @fecha=  {0}, @idCliente = {1}, @numCuenta= {2}", fechaQuereable(Utils.Utils.fechaSistema), _Cuenta.codigoCliente,_Cuenta.id));
            return DB.ExecuteReaderSingle<Cuenta>("SELECT * FROM " +tabla+ " WHERE id = @1", _Cuenta.id);
        }

        public Cuenta create(Cuenta c)
        {
            if (c.id == null || !c.id.HasValue)
            {
                if (existeNumeroBanco(c.numCuenta))
                {
                    throw new MyException("ya existe una cuenta con ese numero y banco");
                }

                string comando = "INSERT INTO VIDA_ESTATICA.Cuenta(num_cuenta,fecha_creacion,estado,pais,fecha_cierre,tipo_moneda,tipo_cuenta,cod_cli)"
                                    + "VALUES ({0},{1},{2},{3},{4},{5},{6},{7});"
                                    + "SELECT SCOPE_IDENTITY();";
                comando = String.Format(comando,c.numCuenta,fechaQuereable(c.fechaCreacion), c.estado, c.pais, "NULL", c.tipoMoneda,c.tipoCuenta,c.codigoCliente);
                int insertado = DB.ExecuteCardinal(comando);
                DB.ExecuteNonQuery(String.Format("EXEC VIDA_ESTATICA.altaCuenta @fecha=  {0}, @idCliente = {1}, @numCuenta= {2}", fechaQuereable(Utils.Utils.fechaSistema), c.codigoCliente, insertado));
                return retrieveBy_id(insertado);
            }
            else
                return update(c);
        }

        public void delete(long cuentaID)
        {
            string update = String.Format("UPDATE " + tabla + " SET fecha_cierre={0},estado=2 WHERE id = {1}", fechaQuereable(DateTime.Today), cuentaID);
            DB.ExecuteNonQuery(update);
            return;
        }

        public List<Cuenta> retrieveByClientId(object _value)
        {
            return DB.ExecuteReader<Cuenta>("SELECT * FROM " + tabla + " WHERE cod_cli = @1", _value);
        }

        public Cuenta retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Cuenta>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
        }

        public List<Cuenta> retrieveBy_Cliente(object cliID)
        {
            return DB.ExecuteReader<Cuenta>("SELECT * FROM " + tabla + " WHERE cod_cli = @1 and fecha_cierre is NULL", cliID);
        }
        // SELECT MAX(num_cuenta) FROM VIDA_ESTATICA.Cuenta

        public long proximoNumeroDeCuenta()
        {
            return DB.ExecuteBigCardinal("SELECT MAX(num_cuenta) FROM "+ tabla) + 1;
        }

        public bool existeNumeroBanco(object numero)
        {
            return DB.ExecuteCardinal("SELECT Count(*) FROM " + tabla + " WHERE num_cuenta = @1", numero) > 0;
        }


        internal Cuenta retrieveBy_Banco_Numero(int banco, long numero)
        {
            return DB.ExecuteReaderSingle<Cuenta>("SELECT * FROM " + tabla + " WHERE cod_banco = " + banco + " AND num_cuenta= " + numero);
        }

        internal Cuenta retrieveBy_Numero(long numero)
        {
            return DB.ExecuteReaderSingle<Cuenta>("SELECT * FROM " + tabla + " WHERE num_cuenta= " + numero);
        }
    }
}