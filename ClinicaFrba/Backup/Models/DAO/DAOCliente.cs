using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagoElectronico.Models;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.Utils;
using System.Data.SqlClient;
using PagoElectronico.Models.DataBase;
using System.Windows;

namespace PagoElectronico.Models.DAO
{
    public partial class DAOCliente: DAOBase<Cliente>
    {
        public DAOCliente()
            : base("VIDA_ESTATICA.Cliente", "id")
        {
        }

        private string stringQuereable(string cadena)
        {
            return "'" + cadena + "'";
        }

        public bool create(Cliente _Cliente)
        {
            try
            {
                int bit = 0;
                string comando = "INSERT INTO VIDA_ESTATICA.Cliente(nombre, apellido, documento, dom_calle, dom_nro, dom_piso, dom_dpto, fecha_nac, mail, nacionalidad, tipo_documento, usuario, activo)"
                                    + "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12});"
                                    + "SELECT SCOPE_IDENTITY();";
                if (_Cliente.usuario == null || _Cliente.usuario == "")
                {
                    _Cliente.usuario = "NULL";
                }
                else
                {
                    if (!existsUser(_Cliente.usuario)) { MessageBox.Show("Usuario ingresado incorrecto"); return false;};
                    _Cliente.usuario = stringQuereable(_Cliente.usuario);
                }

                if (_Cliente.activo == true)
                {
                    bit = 1;
                }
                comando = String.Format(comando, stringQuereable(_Cliente.nombre), stringQuereable(_Cliente.apellido), _Cliente.documento, stringQuereable(_Cliente.dom_calle), _Cliente.dom_nro, _Cliente.dom_piso, stringQuereable(_Cliente.dom_dpto), fechaQuereable(_Cliente.fecha_nac), stringQuereable(_Cliente.mail), _Cliente.nacionalidad, _Cliente.tipo_documento, _Cliente.usuario, bit);
                int insertado = DB.ExecuteCardinal(comando);
                return true;

            }
            catch { return false; }

        }

        public bool update(Cliente cliente)
        {
            try
            {                
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@id", (int)cliente.id));
                ListaParametros.Add(new SqlParameter("@nombre", cliente.nombre));
                ListaParametros.Add(new SqlParameter("@apellido", cliente.apellido));                
                ListaParametros.Add(new SqlParameter("@documento", cliente.documento));
                ListaParametros.Add(new SqlParameter("@dom_calle", cliente.dom_calle));                
                ListaParametros.Add(new SqlParameter("@dom_nro", cliente.dom_nro));
                ListaParametros.Add(new SqlParameter("@dom_piso", cliente.dom_piso));
                ListaParametros.Add(new SqlParameter("@dom_dpto", cliente.dom_dpto));
                ListaParametros.Add(new SqlParameter("@fecha_nac", cliente.fecha_nac));
                ListaParametros.Add(new SqlParameter("@mail", cliente.mail));
                ListaParametros.Add(new SqlParameter("@nacionalidad", cliente.nacionalidad));
                ListaParametros.Add(new SqlParameter("@tipo_documento", cliente.tipo_documento));
                ListaParametros.Add(new SqlParameter("@activo", cliente.activo));
              
                
                return DBAcess.WriteInBase("update VIDA_ESTATICA.Cliente set nombre =@nombre, apellido=@apellido, documento=@documento," +
                    "dom_calle=@dom_calle,dom_nro=@dom_nro,dom_piso=@dom_piso,dom_dpto=@dom_dpto,fecha_nac=@fecha_nac," +
                    "mail=@mail, nacionalidad=@nacionalidad, activo=@activo where id=@id", "T", ListaParametros);
            }
            catch { return false; }
        }

        public void delete(int Cliente_id)
        {
            string update = String.Format("UPDATE " + tabla + " SET activo = 0 WHERE id = {0}", Cliente_id);
            DB.ExecuteNonQuery(update);
        }

        public Cliente retrieveBy_id(object _value)
        {
            return DB.ExecuteReaderSingle<Cliente>("SELECT * FROM " + tabla + " WHERE id = @1", _value);
        }

        public List<Cliente> retrieveByInfo(string id, string numeroDoc, string nombre, string apellido)
        {

            if (String.IsNullOrEmpty(id) && String.IsNullOrEmpty(nombre) &&
                String.IsNullOrEmpty(numeroDoc) && String.IsNullOrEmpty(apellido))
            {
                return retrieveBase();
            }

            string baseQuery = String.Format("SELECT * FROM {0} WHERE", tabla);

            if (!String.IsNullOrEmpty(id))
            {
                baseQuery += String.Format(" id = {0} AND", id);
            }
            if (!String.IsNullOrEmpty(numeroDoc))
            {
                baseQuery += String.Format(" documento = {0} AND", numeroDoc);
            }
            if (!String.IsNullOrEmpty(nombre))
            {
                baseQuery += String.Format(" nombre LIKE '{0}%' AND", nombre);
            }
            if (!String.IsNullOrEmpty(apellido))
            {
                baseQuery += String.Format(" apellido LIKE '{0}%'", apellido);
            }

            baseQuery = baseQuery.Substring(0, baseQuery.Length - 3);
            
            return DB.ExecuteReader<Cliente>(baseQuery);
        }


        public Cliente retrieveBy_user(string userId)
        {
            return DB.ExecuteReaderSingle<Cliente>("SELECT * FROM " + tabla + " WHERE usuario = @1", userId);
        }

        public bool existsUser(string userId)
        {
            List<Cliente> cl = DB.ExecuteReader<Cliente>("SELECT DISTINCT usuario FROM " + tabla);
            List<string> users = new List<string>();
            foreach (Cliente c in cl)
            {
                users.Add(c.usuario);
            }
            if (users.Contains(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Cliente> search(string first_name, string last_name, string identification_type, string identification_number, string email) { 
            List<Cliente> lc = new List<Cliente>();

            if (String.IsNullOrEmpty(first_name) && String.IsNullOrEmpty(last_name) && String.IsNullOrEmpty(identification_number)
                && String.IsNullOrEmpty(identification_number) && String.IsNullOrEmpty(email)) {
                    String query = String.Format("SELECT * FROM VIDA_ESTATICA.CLiente");
                    return DB.ExecuteReader<Cliente>(query);
            }


            String base_query = String.Format("SELECT * FROM VIDA_ESTATICA.Cliente WHERE");
            if (!String.IsNullOrEmpty(first_name))
            {
                base_query += String.Format(" nombre like '{0}%' AND", first_name);
            }
            if (!String.IsNullOrEmpty(last_name))
            {
                base_query += String.Format(" apellido like '{0}%' AND", last_name);
            }
            if (!String.IsNullOrEmpty(identification_type))
            {
                base_query += String.Format(" tipo_documento = ( select top 1 id from VIDA_ESTATICA.Tipo_Documento where descripcion = '{0}') AND", identification_type);
            }
            if (!String.IsNullOrEmpty(identification_number))
            {
                base_query += String.Format(" documento = '{0}' AND", identification_number);
            }
            if (!String.IsNullOrEmpty(email))
            {
                base_query += String.Format(" mail LIKE '{0}%' AND", email);
            }

            base_query = base_query.Substring(0, base_query.Length - 3);

            return DB.ExecuteReader<Cliente>(base_query);
        }

        public List<Cliente> retrieveAll()
        {
            List<Cliente> l = new List<Cliente>();
            SqlDataReader lector = DBAcess.GetDataReader("SELECT * from VIDA_ESTATICA.Cliente", "T", new List<SqlParameter>());

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Cliente unCliente = new Cliente();
                    unCliente.nombre = (string)lector["nombre"];
                    unCliente.id = (int)(decimal)lector["id"];
                    unCliente.apellido = (string)lector["apellido"];
                    unCliente.documento = (int)(decimal)lector["documento"];
                    unCliente.dom_calle = (string)lector["dom_calle"];
                    unCliente.dom_dpto = (string)lector["dom_dpto"];
                    unCliente.dom_nro = (int)(decimal)lector["dom_nro"];
                    unCliente.dom_piso = (int)(decimal)lector["dom_piso"];
                    unCliente.mail = (string)lector["mail"];
                    unCliente.nacionalidad = (int)(decimal)lector["nacionalidad"];
                    unCliente.fecha_nac = (DateTime?)lector["fecha_nac"];
                    unCliente.activo = (bool?)lector["activo"];
                    try
                    {
                        unCliente.usuario = (string)lector["usuario"];
                    }
                    catch
                    {
                        unCliente.usuario = "";
                    }
                    unCliente.tipo_documento = (int)(decimal)lector["tipo_documento"];
                    l.Add(unCliente);
                }
            }
            return l;
        }

        public List<Cliente> topInhabilitados(int anio, int min, int max)
        {
            string comando = "SELECT TOP 5 c.id "
                                + "FROM VIDA_ESTATICA.Cliente c "
                                + "INNER JOIN VIDA_ESTATICA.Cuenta cue "
                                + "ON c.id = cue.cod_cli "
                                + "JOIN VIDA_ESTATICA.Item_Factura i_f "
                                + "ON cue.id = i_f.num_cuenta "
                                + "WHERE YEAR(i_f.fecha) = "+ anio + " "
                                + "AND MONTH(i_f.fecha) IN (" + min + "," + max + ") "
                                + "GROUP BY c.id, i_f.id_factura "
                                + "HAVING COUNT(*) > 5 "
                                + "ORDER BY COUNT(*) DESC ";
            List<Cliente> cl = DB.ExecuteReader<Cliente>(comando);   
            
            return cl;
        }

        public List<Cliente> topFacturadores(int anio, int min, int max)
        {
            string comando = "SELECT TOP 5 c.id FROM VIDA_ESTATICA.Cliente c "
                                +"INNER JOIN VIDA_ESTATICA.Cuenta cue ON cue.cod_cli = c.id "
                                +"INNER JOIN VIDA_ESTATICA.Item_Factura i_f ON cue.id = i_f.num_cuenta "
                                +"WHERE i_f.facturado = 1 "
                                +"AND YEAR(i_f.fecha) = " + anio + " "
                                +"AND MONTH(i_f.fecha) IN (" + min + "," + max + ") "
                                +"GROUP BY c.id "
                                +"ORDER BY COUNT(*) DESC ";
            List<Cliente> cl = DB.ExecuteReader<Cliente>(comando);

            return cl;
        }

        public List<Cliente> topTransaccionales(int anio, int min, int max)
        {
            string comando = "SELECT TOP 5 c.id FROM VIDA_ESTATICA.Cliente c "
                                + "INNER JOIN VIDA_ESTATICA.Cuenta cue ON cue.cod_cli = c.id "
                                + "INNER JOIN VIDA_ESTATICA.Transferencia t ON cue.id = t.cuenta_origen "
                                + "WHERE t.cuenta_destino IN (SELECT cuenta.id FROM VIDA_ESTATICA.Cuenta cuenta WHERE cuenta.cod_cli = c.id) "
                                + "AND YEAR(t.fecha) = " + anio + " "
                                + "AND MONTH(t.fecha) IN (" + min + "," + max + ") "
                                + "GROUP BY c.id "
                                + "ORDER BY COUNT(*) DESC ";
            List<Cliente> cl = DB.ExecuteReader<Cliente>(comando);

            return cl;
        }
    }
}