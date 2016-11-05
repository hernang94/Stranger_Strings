using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.BD.Entidades
{
    class TOP5BonosComprados
    {
        public int cantidad { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }

        public TOP5BonosComprados() { }

        public List<BD.Entidades.TOP5BonosComprados> obtenerLista(Listados.SeleccionListado seleccionListado)
        {
            List<BD.Entidades.TOP5BonosComprados> listaTOP5 = new List<TOP5BonosComprados>();

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Fecha_Inicio_Semestre", seleccionListado.construirFechaInicioSemestre()));
            paramlist.Add(new SqlParameter("@Fecha_Fin_Semestre", seleccionListado.construirFechaFinSemestre()));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_TOP5_AFILIDOS_BONOS", "SP", paramlist);
            if (lector.HasRows)
            {
                int i = 0;
                while (lector.Read() && i<5)
                {
                    BD.Entidades.TOP5BonosComprados top5 = new TOP5BonosComprados();
                    top5.cantidad = (int)lector["Cant"];
                    top5.apellido = (string)lector["Apellido"];
                    top5.nombre = (string)lector["Nombre"];

                    listaTOP5.Add(top5);

                    i++;
                }
            }
            return listaTOP5;
        }
    }
}
