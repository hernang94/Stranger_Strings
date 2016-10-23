using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Form1 : Form
    {
        public Funcionalidades fun;

        public Form1(Funcionalidades fun)
        {
            this.fun=fun;
            InitializeComponent();
        }

        private void tpModificacion_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tpAlta_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbFechNac_Click(object sender, EventArgs e)
        {

        }

        private void dateFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Si esta casado o en concubinato o tiene familiares a cargo
            if (cbEstadoCivil.SelectedIndex == 1 || cbEstadoCivil.SelectedIndex == 2 || int.Parse(txtCantFamilia.Text) > 0)
            {
                DialogResult resultadomge= MessageBox.Show("¿Desea asociar a su conyugue/concubinato o familiares a cargo?", "Consulta", MessageBoxButtons.YesNo);
                if (resultadomge == DialogResult.Yes)
                {
                    A_Familia af = new A_Familia(int.Parse(txtCantFamilia.Text)+1);
                    af.Show();

                }

            }

            //Codigo magico donde se guardan los datos del afiliado original.
        }

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
        }
    }
}
