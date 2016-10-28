using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.BD.Entidades
{
    public class Paciente
    {
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Tipo_Doc {get; set;}
        public decimal Num_Doc {get; set;}
        public string Direccion {get; set;}
        public decimal Telefono { get; set; }
        public string Mail {get; set;}
        public DateTime Fecha_Nac {get; set;}
        public string Sexo { get; set; }
        public string Estado_Civil { get; set; }
        public decimal Familiares_A_Cargo { get; set; }
        public string PlanMedico { get; set; }

        public Paciente() { }
    }
}
