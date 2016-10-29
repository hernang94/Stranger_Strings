
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
        public List<BD.Entidades.Rol> rolesXusuario = new List<BD.Entidades.Rol>();


        public Funcionalidades(Usuario usuario, List<BD.Entidades.Rol> rolesXusuario)
        {
            InitializeComponent();
            user = usuario;
            this.rolesXusuario = rolesXusuario;
        }

        private void Funcionalidades_Load(object sender, EventArgs e)
        {
            if (rolesXusuario.Count == 1)
            {
                if (rolesXusuario[0].Nombre == "Administrador")
                {
                    cbSeleccionRol.Items.Add("Administrador");
                    cbSeleccionRol.SelectedIndex = 0;
                }
                if (rolesXusuario[0].Nombre == "Afiliado")
                {
                    cbSeleccionRol.Items.Add("Afiliado");
                    cbSeleccionRol.SelectedIndex = 0;
                }
                if (rolesXusuario[0].Nombre == "Profesional")
                {
                    cbSeleccionRol.Items.Add("Profesional");
                    cbSeleccionRol.SelectedIndex = 0;
                }
            }
            else
            {
                for (int i = 0; i < rolesXusuario.Count(); i++)
                {
                    if (rolesXusuario[i].Nombre == "Administrador")
                    {
                        cbSeleccionRol.Items.Add("Administrador");
                    }
                    if (rolesXusuario[i].Nombre == "Afiliado")
                    {
                        cbSeleccionRol.Items.Add("Afiliado");
                    }
                    if (rolesXusuario[i].Nombre == "Profesional")
                    {
                        cbSeleccionRol.Items.Add("Profesional");
                    }
                }
            }
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

                btCancelarAtencionMedico.Visible = false;
                btRegistrarResultado.Visible = false;

                btCancelarAtencionAfiliado.Visible = false;
                btPedirTurno.Visible = false;
                btCompraBono.Visible = false;

            }
            //Selecciono Afiliado
            else if (cbSeleccionRol.SelectedIndex == 1)
            {
                btPedirTurno.Visible = true;
                btCancelarAtencionAfiliado.Visible = true;
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
                btCancelarAtencionMedico.Visible = false;
            }
            //Selecciono Profesional
            else if (cbSeleccionRol.SelectedIndex == 2)
            {
                btCancelarAtencionMedico.Visible = true;
                btRegistrarResultado.Visible = true;

                btEspMedicas.Visible = false;
                btPedirTurno.Visible = false;
                btCompraBono.Visible = false;
                btCancelarAtencionAfiliado.Visible = false;

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

        private void btPedirTurno_Click(object sender, EventArgs e)
        {
            Pedir_Turno.formSolicitarTurno pedir_Turno = new Pedir_Turno.formSolicitarTurno(this);
            pedir_Turno.Show();
            this.Hide();
        }

        private void btCancelarAtencionAfiliado_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelarAtencionAfiliado cancelar_Afiliado = new Cancelar_Atencion.CancelarAtencionAfiliado(this);
            cancelar_Afiliado.Show();
            this.Hide();
        }

        private void btCancelarAtencionMedico_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelarAtencionMedico cancelar_Medico = new Cancelar_Atencion.CancelarAtencionMedico(this);
            cancelar_Medico.Show();
            this.Hide();
        }

    }
}
