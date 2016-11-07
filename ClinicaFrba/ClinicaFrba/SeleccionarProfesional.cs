using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class SeleccionarProfesional : Form
    {
        public Funcionalidades fun;
        public string tipo;

        public SeleccionarProfesional(string tipo, Funcionalidades fun)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.fun = fun;
        }

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void cbSeleccionProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
