using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.BD.Entidades
{
    public class Turno
    {
        public DateTime fecha { get; set; }
        public int nro { get; set; }
        public string apellido_Prof { get; set; }
        public string especialidad { get; set; }
        public decimal codigo { set; get; }
        public string nombre_Pac { get; set; }
        public string apellido_Pac { get; set; }
        public int id_Consulta { get; set; }
    }
}
