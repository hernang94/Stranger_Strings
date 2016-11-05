using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Principal : Form
    {
        Funcionalidades fun;
        public Principal(Funcionalidades fun)
        {
            this.fun = fun;
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaRol alta = new AltaRol(this);
            alta.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModificarRol modificar = new ModificarRol(this);
            modificar.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeshabilitarRol deshab = new DeshabilitarRol(this);
            deshab.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HabilitarRol habilitar = new HabilitarRol(this);
            habilitar.Show();
            this.Hide();
        }

    }
}
