using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class SeleccionEspecialidad : Form
    { 
        public Funcionalidades fun;
        public List<BD.Entidades.Especialidad> espXmedico = new List<BD.Entidades.Especialidad>();

        public SeleccionEspecialidad(Funcionalidades fun,List<BD.Entidades.Especialidad> espXmedico)
        {
            InitializeComponent();
            this.fun = fun;
            this.espXmedico = espXmedico;
        }
        private void SeleccionEspecialidad_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < espXmedico.Count(); i++)
            {
                cbEspecialidades.Items.Add(espXmedico[i].Especialidad_Descr);
            }
        }

        private void btAceptar_Click_1(object sender, EventArgs e)
        {
            Registro_Resultado.SeleccionTurno turno = new Registro_Resultado.SeleccionTurno(fun,this, cbEspecialidades.Text, dtFecha.Value.ToString());
            turno.Show();
            this.Hide();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            fun.Show();
        }
    }
}
