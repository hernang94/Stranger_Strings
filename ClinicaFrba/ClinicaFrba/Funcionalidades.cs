
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
using System.Data.SqlClient;

namespace ClinicaFrba
{
    public partial class Funcionalidades : Form
    {

        public Usuario user { get; set; }
        public List<BD.Entidades.Rol> rolesXusuario = new List<BD.Entidades.Rol>();
        public List<BD.Entidades.Especialidad> especXmedico = new List<BD.Entidades.Especialidad>();


        public Funcionalidades(Usuario usuario, List<BD.Entidades.Rol> rolesXusuario)
        {
            InitializeComponent();
            user = usuario;
            this.rolesXusuario = rolesXusuario;
        }

        public Funcionalidades(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
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
                    pedir_Especilidades_Profesional();
                }
                if (rolesXusuario[0].Nombre == "Administrador General")
                {
                    cbSeleccionRol.Items.Add("Administrador General");
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
            AbmRol.Principal principal = new AbmRol.Principal(this, cbSeleccionRol.SelectedItem.ToString());
            principal.Show();
            this.Hide();
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
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Rol", cbSeleccionRol.SelectedItem));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FUNCIONALIDADES_DEL_ROL", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string funcionalidad = (string)lector["Descripcion"];
                    
                    if (funcionalidad == "ABM de Afiliado")
                    {
                        btABMAfiliado.Visible = true;
                    }
                    if (funcionalidad == "ABM de Rol")
                    {
                        btABMRol.Visible = true;
                    }
                    if (funcionalidad == "Compra de Bonos" && cbSeleccionRol.SelectedItem=="Afiliado")
                    {
                        btCompraBonoAfiliado.Visible = true;
                    }
                    if (funcionalidad == "Compra de Bonos" && (cbSeleccionRol.SelectedItem == "Administrador" ||cbSeleccionRol.SelectedItem == "Administrador General"))
                    {
                        btComprarBonoAdmin.Visible = true;
                    }
                    if (funcionalidad == "Solicitar Turno")
                    {
                        btPedirTurno.Visible = true;
                    }
                    if (funcionalidad == "Registro de Llegada")
                    {
                        btRegistroLlegada.Visible = true;
                    }
                    if (funcionalidad == "Registro de Resultado")
                    {
                        btRegistrarResultado.Visible = true;
                    }
                    if (funcionalidad == "Cancelar Atención Médica" && cbSeleccionRol.SelectedItem == "Afiliado")
                    {
                        btCancelarAtencionAfiliado.Visible = true;
                    }
                    if (funcionalidad == "Cancelar Atención Médica" && cbSeleccionRol.SelectedItem == "Profesional")
                    {
                        btCancelarAtencionMedico.Visible = true;
                    }
                    if (funcionalidad == "Listado Estadístico")
                    {
                        btListadoEstadistico.Visible = true;
                    }
                }
            }
            //Selecciono Admin General
            if (cbSeleccionRol.SelectedItem == "Administrador General")
            {
                btRegistroUsuario.Visible = true;
                btABMProfesional.Visible = true;
                btPlan.Visible = true;
                btRegAgendaProf.Visible = true;
                btRegAgendaProf.Visible = true;
                btEspMedicas.Visible = true;

                btCancelarAtencionMedico.Visible = true;

                btCancelarAtencionAfiliado.Visible = true;
                btCompraBonoAfiliado.Visible = true;
            }
            //Selecciono Admin
            if (cbSeleccionRol.SelectedItem=="Administrador")
            {
                btRegistroUsuario.Visible = true;
                btABMProfesional.Visible = true;
                btPlan.Visible = true;
                btRegAgendaProf.Visible = true;
                btRegAgendaProf.Visible = true;
                btEspMedicas.Visible = true;
            }
        }

        private void btRegAgendaProf_Click(object sender, EventArgs e)
        {
            Registrar_Agenda_Medico.Registro_Agenda registro = new Registrar_Agenda_Medico.Registro_Agenda(this);
            registro.Show();
            this.Hide();
        }

        private void btRegistroLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Registro_Llegada reg = new Registro_Llegada.Registro_Llegada(this);
            reg.Show();
            this.Hide();
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
            if (cbSeleccionRol.SelectedItem == "Administrador General")
            {
                SeleccionAfiliado selecAfiliado = new SeleccionAfiliado("pedir_Turno", this);
                selecAfiliado.Show();
                this.Hide();
            }
            else
            {
                Pedir_Turno.formSolicitarTurno pedir_Turno = new Pedir_Turno.formSolicitarTurno(this);
                pedir_Turno.Show();
                this.Hide();
            }
        }

        private void btCancelarAtencionAfiliado_Click(object sender, EventArgs e)
        {
            if (cbSeleccionRol.SelectedItem == "Administrador General")
            {
                SeleccionAfiliado selecAfiliado = new SeleccionAfiliado("cancelar_Afiliado", this);
                selecAfiliado.Show();
                this.Hide();
            }
            else
            {
                Cancelar_Atencion.CancelarAtencionAfiliado cancelar_Afiliado = new Cancelar_Atencion.CancelarAtencionAfiliado(this);
                cancelar_Afiliado.Show();
                this.Hide();
            }
        }

        private void btCancelarAtencionMedico_Click(object sender, EventArgs e)
        {
            if (cbSeleccionRol.SelectedItem == "Administrador General")
            {
                SeleccionProfesional seleccionar_profesional = new SeleccionProfesional("cancelar_Atencion_Medico", this);
                seleccionar_profesional.Show();
                this.Hide();
            }
            else
            {
                Cancelar_Atencion.CancelarAtencionMedico cancelar_Medico = new Cancelar_Atencion.CancelarAtencionMedico(this);
                cancelar_Medico.Show();
                this.Hide();
            }
          
        }

        private void pedir_Especilidades_Profesional()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_doc", this.user.Dni));
            paramlist.Add(new SqlParameter("@Tipo_Doc", this.user.Tipo_Doc));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_ESPECIALIDADES", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Especialidad esp = new BD.Entidades.Especialidad();
                    esp.Especialidad_Descr = (string)lector["Especialidad_Descripcion"];
                    esp.Especialidad_Cod = (decimal)lector["Especialidad_Codigo"];
                    this.especXmedico.Add(esp);
                }
            }
        }

        private void btRegistrarResultado_Click(object sender, EventArgs e)
        {
            if (cbSeleccionRol.SelectedItem == "Administrador General")
            {
                SeleccionProfesional seleccionar_profesional = new SeleccionProfesional("seleccion_Especialidad", this);
                seleccionar_profesional.Show();
                this.Hide();
            }
            else
            {
                Registro_Resultado.SeleccionEspecialidad seleccion_Especialidad = new Registro_Resultado.SeleccionEspecialidad(this, especXmedico);
                seleccion_Especialidad.Show();
                this.Hide();
            }
            
        }

        private void btCompraBono_Click(object sender, EventArgs e)
        {
            if (cbSeleccionRol.SelectedItem == "Administrador General")
            {
                SeleccionAfiliado selecAfiliado = new SeleccionAfiliado("compraBono",this);
                selecAfiliado.Show();
                this.Hide();
            }
            else
            {
                Compra_Bono.CompraBonoAfiliado compraBono = new Compra_Bono.CompraBonoAfiliado(this);
                compraBono.Show();
                this.Hide();
            }
        }

        private void btListadoEstadistico_Click(object sender, EventArgs e)
        {
            Listados.SeleccionListado seleccionListado = new Listados.SeleccionListado(this);
            seleccionListado.Show();
            this.Hide();
        }

        private void btComprarBonoAdmin_Click(object sender, EventArgs e)
        {
            Compra_Bono.CompraBonoAdmin compraBono = new Compra_Bono.CompraBonoAdmin(this);
            compraBono.Show();
            this.Hide();
        }

        private void btRegistroUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad no disponible", "Error!", MessageBoxButtons.OK);
        }
    }
}
