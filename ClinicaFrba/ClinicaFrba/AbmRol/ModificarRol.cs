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
    public partial class ModificarRol : Form
    {
        Principal principal;
        public ModificarRol(Principal principal)
        {
            this.principal = principal;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarFuncionalidad agregar = new AgregarFuncionalidad(this);
            agregar.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EliminarFuncionalidad eliminar = new EliminarFuncionalidad(this);
            eliminar.Show();
            this.Hide();
        }
    }
}
