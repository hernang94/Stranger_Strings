using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.BD.Entidades
{
    class TOP5ProfMenosHoras
    {
        public decimal cantidad { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string plan { set; get; }
        public string especialidad { set; get; }

        public TOP5ProfMenosHoras() { }

        public List<BD.Entidades.TOP5ProfMenosHoras> obtenerLista(Listados.SeleccionListado seleccionListado)
        {
            List<BD.Entidades.TOP5ProfMenosHoras> listaTOP5 = new List<TOP5ProfMenosHoras>();

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Fecha_Inicio_Semestre", seleccionListado.construirFechaInicioSemestre()));
            paramlist.Add(new SqlParameter("@Fecha_Fin_Semestre", seleccionListado.construirFechaFinSemestre()));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_TOP5_PROFESIONALES_POCAS_HORAS", "SP", paramlist);
            if (lector.HasRows)
            {
                for(int i = 0; i<5; i++)
                {
                    lector.Read();

                    BD.Entidades.TOP5ProfMenosHoras top5 = new TOP5ProfMenosHoras();
                    top5.cantidad = (decimal)lector["Horas_Trabajadas"];
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
