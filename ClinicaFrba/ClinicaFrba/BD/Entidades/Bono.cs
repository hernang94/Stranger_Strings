using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.BD.Entidades
{
    public class Bono
    {
        public int id_Bono{get;set;}
        public DateTime fecha_compra{get;set;}
        public int codigo_plan{get;set;}
    }
}
