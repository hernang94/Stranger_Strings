using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ClinicaFrba.BD.Entidades
{
    public class TOP5Cancelaciones
    {
        public int cantidad { set; get; }
        public string especialidad { set; get; }

        public TOP5Cancelaciones() { }

        public List<BD.Entidades.TOP5Cancelaciones> obtenerLista(Listados.SeleccionListado seleccionListado)
        {
            List<BD.Entidades.TOP5Cancelaciones> listaTOP5 = new List<TOP5Cancelaciones>();

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Fecha_Inicio_Semestre", seleccionListado.construirFechaInicioSemestre()));
            paramlist.Add(new SqlParameter("@Fecha_Fin_Semestre", seleccionListado.construirFechaFinSemestre()));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_TOP5_CANCELACIONES", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.TOP5Cancelaciones top5 = new TOP5Cancelaciones();
                    top5.cantidad = (int)lector["Cant"];
                    top5.especialidad = (string)lector["Especialidad_Descripcion"];

                    listaTOP5.Add(top5);
                }
            }
            return listaTOP5;
        }
    }

}
