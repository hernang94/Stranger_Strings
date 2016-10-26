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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencionAfiliado : Form
    {
        public Funcionalidades fun;
        public CancelarAtencionAfiliado(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            fun.Show();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
           DialogResult msge = MessageBox.Show("¿Esta seguro que desea cancelar el turno seleccionado?", "Confirmar cancelación", MessageBoxButtons.YesNo);
           if (msge == DialogResult.Yes)
           {
               
               //Llamar al stored procedure que cancele el turno
               lbTurnoCancelado.Visible = true;
               timer1.Enabled = true;

           }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbTurnoCancelado.Visible = false;
            }
        }
    }
}
