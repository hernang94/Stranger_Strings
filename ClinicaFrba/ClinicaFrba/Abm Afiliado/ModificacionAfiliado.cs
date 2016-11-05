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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificacionAfiliado : Form
    {
        public Funcionalidades fun;
        public BD.Entidades.Paciente paciente = new BD.Entidades.Paciente();
        public Label lbModificado;
        public Timer timer1;
        public DataGridView dtgCliente;

        public ModificacionAfiliado(Funcionalidades fun, BD.Entidades.Paciente pac, Label lbModificado, Timer timer1, DataGridView dtgCliente)
        {
            InitializeComponent();
            this.fun = fun;
            this.paciente = pac;
            this.lbModificado = lbModificado;
            this.timer1 = timer1;
            this.dtgCliente = dtgCliente;
        }

        private void ModificacionAfiliado_Load(object sender, EventArgs e)
        {
            txtDireccion.Text = paciente.Direccion;
            txtMail.Text = paciente.Mail;
            txtTelefono.Text = System.Convert.ToString(paciente.Telefono);
            dtpFechaNac.Value = paciente.Fecha_Nac;
            cbEstadoCivi.Text = paciente.Estado_Civil;
            dtpFechaNac.Value = ArchivoConfiguracion.Default.FechaActual;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Nombre", paciente.Nombre));
            paramlist.Add(new SqlParameter("@Apellido", paciente.Apellido));
            paramlist.Add(new SqlParameter("@Tipo_Doc", paciente.Tipo_Doc));
            paramlist.Add(new SqlParameter("@Num_Doc", paciente.Num_Doc));
            paramlist.Add(new SqlParameter("@Direccion", txtDireccion.Text));
            paramlist.Add(new SqlParameter("@Telefono", int.Parse(txtTelefono.Text)));
            paramlist.Add(new SqlParameter("@Mail", txtMail.Text));
            paramlist.Add(new SqlParameter("@Fecha_Nac", dtpFechaNac.Value));
            paramlist.Add(new SqlParameter("@Sexo", paciente.Sexo));
            paramlist.Add(new SqlParameter("@Estado_Civil", cbEstadoCivi.SelectedItem));
            paramlist.Add(new SqlParameter("@Familiares_A_Cargo", paciente.Familiares_A_Cargo));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_MODIFICAR_AFILIADO", "SP", paramlist);

            lbModificado.Visible = true;
            timer1.Enabled=true;
            dtgCliente.DataSource=null;
            this.Close();
        }

        private void btCambioPlan_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Cambio_De_Plan cp = new Abm_Afiliado.Cambio_De_Plan(fun,paciente);
            cp.Show();
        }
    }
}
