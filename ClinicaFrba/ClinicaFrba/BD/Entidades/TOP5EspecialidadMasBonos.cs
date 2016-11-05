using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.BD.Entidades
{
    class TOP5EspecialidadMasBonos
    {
        public int cantidad { set; get; }
        public string especialidad { set; get; }

        public TOP5EspecialidadMasBonos() { }

        public List<BD.Entidades.TOP5EspecialidadMasBonos> obtenerLista(Listados.SeleccionListado seleccionListado)
        {
            List<BD.Entidades.TOP5EspecialidadMasBonos> listaTOP5 = new List<TOP5EspecialidadMasBonos>();

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Fecha_Inicio_Semestre", seleccionListado.construirFechaInicioSemestre()));
            paramlist.Add(new SqlParameter("@Fecha_Fin_Semestre", seleccionListado.construirFechaFinSemestre()));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_TOP5_BONOS_ESPECIALIDAD", "SP", paramlist);
            if (lector.HasRows)
            {
                int i = 0;
                while (lector.Read() && i<5)
                {
                    BD.Entidades.TOP5EspecialidadMasBonos top5 = new TOP5EspecialidadMasBonos();
                    top5.cantidad = (int)lector["Cant"];
                    top5.especialidad = (string)lector["Especialidad_Descripcion"];

                    listaTOP5.Add(top5);

                    i++;
                }
            }
            return listaTOP5;
        }
    }
}
