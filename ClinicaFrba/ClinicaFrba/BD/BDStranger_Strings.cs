using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;

namespace ClinicaFrba
{
    public class BDStranger_Strings
    {
        public static SqlConnection ObtenerConexion()
        {
            //Obtengo datos de coneccion de ArchivoConfiguacion.settings ---------------------
            string dataSource = ArchivoConfiguracion.Default.DataSource;
            string initialCatalog = ArchivoConfiguracion.Default.InitialCatalog;
            string user = ArchivoConfiguracion.Default.User;
            string password = ArchivoConfiguracion.Default.Password;

            SqlConnection con = new SqlConnection(@dataSource+initialCatalog+user+password);
            con.Open();
            return con;
        }


        //----------------------------VER ------------------------------------

         public static SqlDataReader GetDataReader(string commandtext, string commandtype, List<SqlParameter> parameters)
        {
            SqlCommand sqlCommand = BuildSQLCommand(commandtext, parameters);
            SetCommandType(commandtype, sqlCommand);
            return sqlCommand.ExecuteReader();
        }

        public static bool WriteInBase(string commandtext, string commandtype, List<SqlParameter> parameters)
        {
            SqlCommand sqlCommand = BuildSQLCommand(commandtext, parameters);
            SetCommandType(commandtype, sqlCommand);
            try {
                sqlCommand.ExecuteNonQuery();
                return true;
            } catch { return false; }
        }

        // En @ret va el output
        public static Int32 ExecStoredProcedure(string commandText, List<SqlParameter> parameters)
        {
            try
            {
                SqlCommand sqlCommand = BuildSQLCommand(commandText, parameters);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader lectorAux = sqlCommand.ExecuteReader();
                lectorAux.Close();
                Int32 retorno = (Int32)parameters.Find(x => x.ParameterName == "@Retorno").Value;
                sqlCommand.Parameters.Clear();
                return retorno;
            }
            catch { return 0; }
        }

        private static SqlCommand BuildSQLCommand(string commandtext, List<SqlParameter> parameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = ObtenerConexion();
            sqlCommand.CommandText = commandtext;
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters) { sqlCommand.Parameters.Add(param); }
            }
            return sqlCommand;
        }

        private static void SetCommandType(string commandtype, SqlCommand sqlCommand)
        {
            switch (commandtype)
            {
                case "T":
                    sqlCommand.CommandType = CommandType.Text;
                    break;
                case "TD":
                    sqlCommand.CommandType = CommandType.TableDirect;
                    break;
                case "SP":
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    break;
            }
        }
    }
}

