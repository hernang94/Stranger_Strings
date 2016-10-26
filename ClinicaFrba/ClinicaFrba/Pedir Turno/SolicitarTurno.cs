using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.BD;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class formSolicitarTurno : Form
    {
        public Funcionalidades fun;

        public formSolicitarTurno(Funcionalidades fun)
        {
            this.fun = fun;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            fun.Show();
        }
    }
}
