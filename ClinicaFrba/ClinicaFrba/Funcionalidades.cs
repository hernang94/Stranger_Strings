
using ClinicaFrba.BD;
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
    public partial class Funcionalidades : Form
    {

        public Usuario user { get; set; }
       // private Rol rol { get; set; }
       // private List<Rol> lstRoles = new List<Rol>();


        public Funcionalidades(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void btABMRol_Click(object sender, EventArgs e)
        { 
        }


        private void btABMProfesional_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad no disponible", "Error!", MessageBoxButtons.OK);
        }

        private void btEspMedicas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad no disponible", "Error!", MessageBoxButtons.OK);
        }

        private void btPlan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad no disponible", "Error!", MessageBoxButtons.OK);
        }

        private void cbSeleccionRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selecciono Admin
            if (cbSeleccionRol.SelectedIndex == 0)
            {
                btABMRol.Visible = true;
                btABMAfiliado.Visible = true;
                btRegistroUsuario.Visible = true;
                btABMProfesional.Visible = true;
                btPlan.Visible = true;
                btRegAgendaProf.Visible = true;
                btRegAgendaProf.Visible = true;
                btRegistroLlegada.Visible = true;
                btEspMedicas.Visible = true;

                btCancelarAtencion.Visible = false;
                btRegistrarResultado.Visible = false;

                btPedirTurno.Visible = false;
                btCompraBono.Visible = false;

            }
            //Selecciono Afiliado
            else if (cbSeleccionRol.SelectedIndex == 1)
            {
                btPedirTurno.Visible = true;
                btCancelarAtencion.Visible = true;
                btCompraBono.Visible = true;

                btEspMedicas.Visible = false;
                btABMRol.Visible = false;
                btABMAfiliado.Visible = false;
                btRegistroUsuario.Visible = false;
                btABMProfesional.Visible = false;
                btPlan.Visible = false;
                btRegAgendaProf.Visible = false;
                btRegAgendaProf.Visible = false;
                btRegistroLlegada.Visible = false;

                btRegistrarResultado.Visible = false;
            }
            //Selecciono Profesional
            else if (cbSeleccionRol.SelectedIndex == 2)
            {
                btCancelarAtencion.Visible = true;
                btRegistrarResultado.Visible = true;

                btEspMedicas.Visible = false;
                btPedirTurno.Visible = false;
                btCompraBono.Visible = false;

                btABMRol.Visible = false;
                btABMAfiliado.Visible = false;
                btRegistroUsuario.Visible = false;
                btABMProfesional.Visible = false;
                btPlan.Visible = false;
                btRegAgendaProf.Visible = false;
                btRegAgendaProf.Visible = false;
                btRegistroLlegada.Visible = false;
            }
        }

        private void btRegAgendaProf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad no disponible", "Error!", MessageBoxButtons.OK);
        }

        private void btRegistroLlegada_Click(object sender, EventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Inicio fminicio = new Inicio();
            fminicio.Show();
            this.Close();
        }

        private void btABMProfesional_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad no disponible", "Error!", MessageBoxButtons.OK);
        }

        private void btABMAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Form1 abmAfil = new Abm_Afiliado.Form1(this);
            abmAfil.Show();
            this.Hide();
        }
    }
}
