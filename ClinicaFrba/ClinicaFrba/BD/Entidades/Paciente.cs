using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.BD.Entidades
{
    class Paciente
    {
        public string lNombre {get; set;}
        public string Apellido {get; set;}
        public string TipoDoc {get; set;}
        public int NumDoc {get; set;}
        public string Direccion {get; set;}
        public int Telefono {get; set;}
        public string Mail {get; set;}
        public DateTime Fecha {get; set;}
        public string Sexo {get; set;}
        public string EstadoCivil {get; set;}
        public int PlanMedico{get; set;}
        public int FamiliaresACargo { get; set; }
    }
}
