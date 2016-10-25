using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{
    public class BDStranger_Strings
    {
        public static SqlConnection ObtenerConexion()
        {
            //Cambiar respecto del servidor: Mica y Mauro ABM-PC\SQL....
            SqlConnection con = new SqlConnection(@"Data source=TOMÁS-PC\SQLSERVER2012; Initial Catalog=GD2C2016; User Id=gd; Password=gd2016");
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
        public static decimal ExecStoredProcedure(string commandText, List<SqlParameter> parameters)
        {
            try {
                SqlCommand sqlCommand = BuildSQLCommand(commandText, parameters);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                return (decimal)sqlCommand.Parameters["@ret"].Value;
            } catch { return 0;}
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

