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
        public string apellido_Prof { get; set; }
        public string especialidad { get; set; }
    }
}
