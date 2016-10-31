using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
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

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Registro_Resultado.Form1 reg = new Registro_Resultado.Form1(this.fun, cbEspecialidades.Text, dtFecha.Text);
            reg.Show();
            this.Hide();
        }

        private void SeleccionEspecialidad_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < espXmedico.Count(); i++)
            {
                cbEspecialidades.Items.Add(espXmedico[i].Especialidad_Descr);
            }
        }
    }
}
