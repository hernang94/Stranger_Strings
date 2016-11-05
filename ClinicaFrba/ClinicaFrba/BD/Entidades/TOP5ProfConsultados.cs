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
    public class TOP5ProfConsultados
    {
        public int cantidad { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string plan { set; get; }
        public string especialidad { set; get; }
    
        public TOP5ProfConsultados() { }

        public List<BD.Entidades.TOP5ProfConsultados> obtenerLista(Listados.SeleccionListado seleccionListado)
        {
            List<BD.Entidades.TOP5ProfConsultados> listaTOP5 = new List<TOP5ProfConsultados>();

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Fecha_Inicio_Semestre", seleccionListado.construirFechaInicioSemestre()));
            paramlist.Add(new SqlParameter("@Fecha_Fin_Semestre", seleccionListado.construirFechaFinSemestre()));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_TOP5_PROFESIONALES_CONSULTADOS", "SP", paramlist);
            if (lector.HasRows)
            {
                for (int i = 0; i < 5; i++)
                {
                    lector.Read();

                    BD.Entidades.TOP5ProfConsultados top5 = new TOP5ProfConsultados();
                    top5.cantidad = (int)lector["Cantidad"];
                    top5.nombre = (string)lector["Nombre"];
                    top5.apellido = (string)lector["Apellido"];
                    top5.plan = (string)lector["Tipo_De_Plan"];
                    top5.especialidad = (string)lector["Especialidad_Descripcion"];

                    listaTOP5.Add(top5);
                }
            }
            return listaTOP5;
        }
    }
}
