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
    public partial class Form1 : Form
    {
        public Funcionalidades fun;
        

        public Form1(Funcionalidades fun)
        {
            this.fun=fun;
            InitializeComponent();
            crearGrilla();
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
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtDirec.Text == "" || txtMail.Text == "" || txtNroDoc.Text == "" || txtTel.Text == "" || txtTipoDoc.Text == "" || cbEstadoCivil.Text == "" || cbPlanMedico.Text == "" || cbSexo.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                decimal num_raiz = cargar_Datos_Afiliados();

                DialogResult resultadomge1 = DialogResult.No;
                DialogResult resultadomge2 = DialogResult.No;

                //Si esta casado o en concubinato --------------------------------------------------
                if (cbEstadoCivil.SelectedIndex == 1 || cbEstadoCivil.SelectedIndex == 2)
                {
                    resultadomge1 = MessageBox.Show("¿Desea asociar a su conyugue/concubinato?", "Consulta", MessageBoxButtons.YesNo);
                }

                //Si tiene familiares a cargo ------------------------------------------------------
                if (int.Parse(nupCantFamilia.Text) > 0)
                {
                    resultadomge2 = MessageBox.Show("¿Desea asociar a sus familiares a cargo?", "Consulta", MessageBoxButtons.YesNo);
                }

                if (resultadomge1 == DialogResult.Yes && resultadomge2 == DialogResult.Yes)
                {
                    A_Familia af = new A_Familia(int.Parse(nupCantFamilia.Text) + 1, num_raiz);
                    af.Show();
                }
                else if (resultadomge1 == DialogResult.Yes && resultadomge2 == DialogResult.No)
                {
                    A_Familia af = new A_Familia(1, num_raiz);
                    af.Show();
                }
                else if (resultadomge1 == DialogResult.No && resultadomge2 == DialogResult.Yes)
                {
                    A_Familia af = new A_Familia(int.Parse(nupCantFamilia.Text), num_raiz);
                    af.Show();
                }
            }
        }

        private decimal cargar_Datos_Afiliados()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@nombre", txtNombre.Text));
            lista.Add(new SqlParameter("@apellido", txtApellido.Text));
            lista.Add(new SqlParameter("@tipo_Doc", txtTipoDoc.Text));
            lista.Add(new SqlParameter("@nro_Doc", int.Parse(txtNroDoc.Text)));
            lista.Add(new SqlParameter("@direccion", txtDirec.Text));
            lista.Add(new SqlParameter("@tel", int.Parse(txtTel.Text)));
            lista.Add(new SqlParameter("@mail",txtMail.Text));
            lista.Add(new SqlParameter("@fecha_Nac", dateFechaNac.Value));
            lista.Add(new SqlParameter("@sexo", cbSexo.Text.Substring(0,1)));
            lista.Add(new SqlParameter("@estado_Civil", cbEstadoCivil.Text));
            lista.Add(new SqlParameter("@cant_Familiares", int.Parse(nupCantFamilia.Text)));
            lista.Add(new SqlParameter("@plan_Med", cbPlanMedico.SelectedIndex));
            lista.Add(new SqlParameter("@num_Raiz", null));
            lista.Add(new SqlParameter("@num_resto", 1));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_ALTA_AFILIADO", "SP", lista);
            decimal num_afiliado_raiz=0;
            if (lector.HasRows)
            {
                lector.Read();
                num_afiliado_raiz = (decimal)lector["num_afiliado_resto"];
            }
            return num_afiliado_raiz;
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

        private void crearGrilla()
        {
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 75;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 75;
            DataGridViewTextBoxColumn colTipoDoc = new DataGridViewTextBoxColumn();
            colTipoDoc.DataPropertyName = "tipo_doc";
            colTipoDoc.HeaderText = "Tipo Doc";
            colTipoDoc.Width = 10;
            DataGridViewTextBoxColumn colNumDoc = new DataGridViewTextBoxColumn();
            colNumDoc.DataPropertyName = "num_doc";
            colNumDoc.HeaderText = "Nro. Doc";
            colNumDoc.Width = 25;
            DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn();
            colDireccion.DataPropertyName = "direccino";
            colDireccion.HeaderText = "Direccion";
            colDireccion.Width = 100;
            DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
            colTelefono.DataPropertyName = "telefono";
            colTelefono.HeaderText = "Telefono";
            colTelefono.Width = 20;
            DataGridViewTextBoxColumn colMail = new DataGridViewTextBoxColumn();
            colMail.DataPropertyName = "mail";
            colMail.HeaderText = "Mail";
            colMail.Width = 100;
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "fecha";
            colFecha.HeaderText = "Fecha Nac.";
            colFecha.Width = 25;
            /*DataGridViewTextBoxColumn colSexoo = new DataGridViewTextBoxColumn();
            colSexoo.DataPropertyName = "sexo";
            colSexoo.HeaderText = "Sexo";
            colSexoo.Width = 15;
            DataGridViewTextBoxColumn colEstadoCivil = new DataGridViewTextBoxColumn();
            colEstadoCivil.DataPropertyName = "estado_Civil";
            colEstadoCivil.HeaderText = "Estado civil";
            colEstadoCivil.Width = 30;*/
            DataGridViewTextBoxColumn colPlanMedico = new DataGridViewTextBoxColumn();
            colPlanMedico.DataPropertyName = "plan_Medico";
            colPlanMedico.HeaderText = "Plan medico";
            colPlanMedico.Width = 20;
            DataGridViewTextBoxColumn colFamiliaresACargo = new DataGridViewTextBoxColumn();
            colFamiliaresACargo.DataPropertyName = "fam_Cargo";
            colFamiliaresACargo.HeaderText = "Familiares a cargo";
            colFamiliaresACargo.Width = 20;

            dtgCliente.Columns.Add(colNombre);
            dtgCliente.Columns.Add(colApellido);
            dtgCliente.Columns.Add(colTipoDoc);
            dtgCliente.Columns.Add(colNumDoc);
            dtgCliente.Columns.Add(colDireccion);
            dtgCliente.Columns.Add(colTelefono);
            dtgCliente.Columns.Add(colMail);
            dtgCliente.Columns.Add(colFecha);
            //dtgCliente.Columns.Add(colSexoo);
            //dtgCliente.Columns.Add(colEstadoCivil);
            dtgCliente.Columns.Add(colPlanMedico);
            dtgCliente.Columns.Add(colFamiliaresACargo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<BD.Entidades.Paciente> listaPaciente = new List<BD.Entidades.Paciente>();
            if (txtBMDoc.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                List<SqlParameter> paramlist = new List<SqlParameter>();
                paramlist.Add(new SqlParameter("@Num_Doc", txtBMDoc.Text));
                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_BUSCAR_AFILIADO", "SP", paramlist);
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        BD.Entidades.Paciente paciente = new BD.Entidades.Paciente();

                        paciente.Nombre = (string)lector["Nombre"];
                        paciente.Apellido = (string)lector["Apellido"];
                        paciente.Tipo_Doc = (string)lector["Tipo_Doc"];
                        paciente.Num_Doc = (decimal)lector["Num_Doc"];
                        paciente.Direccion = (string)lector["Direccion"];
                        paciente.Telefono = (decimal) lector["Telefono"];
                        paciente.Mail = (string)lector["Mail"];
                        paciente.Fecha_Nac = (DateTime)lector["Fecha_Nac"];
                        //paciente.Sexo = (string)lector["Sexo"];
                        //paciente.Estado_Civil = (string)lector["Estado_Civil"];
                        //paciente.Familiares_A_Cargo = (decimal)lector["Familiares_A_Cargo"];
                        paciente.PlanMedico = (string)lector["Descripcion"];
                       
                        listaPaciente.Add(paciente);
                    }
                }
                dtgCliente.DataSource = listaPaciente;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBMDoc.Clear();
            dtgCliente.DataSource = null;
        }
    }
}
