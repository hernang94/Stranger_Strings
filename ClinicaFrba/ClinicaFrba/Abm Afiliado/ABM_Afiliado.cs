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
        public BD.Entidades.Paciente paciente = new BD.Entidades.Paciente();

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
            dateFechaNac.Value = ArchivoConfiguracion.Default.FechaActual;
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
                if (num_raiz != -1)
                {
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
                    MessageBox.Show("Afiliado agregado exitosamente", "", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Afiliado ya existente", "Error", MessageBoxButtons.OK);
                }
               
            }
        }

        private decimal cargar_Datos_Afiliados()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@Nombre", txtNombre.Text));
            lista.Add(new SqlParameter("@Apellido", txtApellido.Text));
            lista.Add(new SqlParameter("@Tipo_Doc", txtTipoDoc.Text));
            lista.Add(new SqlParameter("@Num_Doc", int.Parse(txtNroDoc.Text)));
            lista.Add(new SqlParameter("@Direccion", txtDirec.Text));
            lista.Add(new SqlParameter("@Telefono", int.Parse(txtTel.Text)));
            lista.Add(new SqlParameter("@Mail",txtMail.Text));
            lista.Add(new SqlParameter("@Fecha_Nac", dateFechaNac.Value));
            lista.Add(new SqlParameter("@Sexo", cbSexo.Text.Substring(0,1)));
            lista.Add(new SqlParameter("@Estado_Civil", cbEstadoCivil.Text));
            lista.Add(new SqlParameter("@Familiares_A_Cargo", int.Parse(nupCantFamilia.Text)));
            lista.Add(new SqlParameter("@Plan", "Plan Medico "+cbPlanMedico.Text));
            lista.Add(new SqlParameter("@Num_Afiliado_Raiz", DBNull.Value));
            SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Decimal);
            paramRetAux.Direction = ParameterDirection.Output;
            lista.Add(paramRetAux);
            return BDStranger_Strings.ExecStoredProcedureAlta("STRANGER_STRINGS.SP_ALTA_AFILIADO", lista);
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
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 100;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 100;
            DataGridViewTextBoxColumn colTipoDoc = new DataGridViewTextBoxColumn();
            colTipoDoc.DataPropertyName = "Tipo_Doc";
            colTipoDoc.HeaderText = "Tipo_de_documento";
            colTipoDoc.Width = 100;
            DataGridViewTextBoxColumn colNumDoc = new DataGridViewTextBoxColumn();
            colNumDoc.DataPropertyName = "Num_Doc";
            colNumDoc.HeaderText = "Nro_de_documento";
            colNumDoc.Width = 100;
            DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn();
            colDireccion.DataPropertyName = "Direccion";
            colDireccion.HeaderText = "Direccion";
            colDireccion.Width = 100;
            DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
            colTelefono.DataPropertyName = "Telefono";
            colTelefono.HeaderText = "Telefono";
            colTelefono.Width = 100;
            DataGridViewTextBoxColumn colMail = new DataGridViewTextBoxColumn();
            colMail.DataPropertyName = "Mail";
            colMail.HeaderText = "Mail";
            colMail.Width = 100;
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "Fecha_Nac";
            colFecha.HeaderText = "Fecha_de_Nacimiento";
            colFecha.Width = 100;
            DataGridViewTextBoxColumn colSexoo = new DataGridViewTextBoxColumn();
            colSexoo.DataPropertyName = "Sexo";
            colSexoo.HeaderText = "Sexo";
            colSexoo.Width = 100;
            DataGridViewTextBoxColumn colEstadoCivil = new DataGridViewTextBoxColumn();
            colEstadoCivil.DataPropertyName = "Estado_Civil";
            colEstadoCivil.HeaderText = "Estado_civil";
            colEstadoCivil.Width = 100;
            DataGridViewTextBoxColumn colPlanMedico = new DataGridViewTextBoxColumn();
            colPlanMedico.DataPropertyName = "PlanMedico";
            colPlanMedico.HeaderText = "Plan_medico";
            colPlanMedico.Width = 100;
            DataGridViewTextBoxColumn colFamiliaresACargo = new DataGridViewTextBoxColumn();
            colFamiliaresACargo.DataPropertyName = "Familiares_A_Cargo";
            colFamiliaresACargo.HeaderText = "Familiares_a_cargo";
            colFamiliaresACargo.Width = 100;

            dtgCliente.Columns.Add(colNombre);
            dtgCliente.Columns.Add(colApellido);
            dtgCliente.Columns.Add(colTipoDoc);
            dtgCliente.Columns.Add(colNumDoc);
            dtgCliente.Columns.Add(colDireccion);
            dtgCliente.Columns.Add(colTelefono);
            dtgCliente.Columns.Add(colMail);
            dtgCliente.Columns.Add(colFecha);
            dtgCliente.Columns.Add(colSexoo);
            dtgCliente.Columns.Add(colEstadoCivil);
            dtgCliente.Columns.Add(colPlanMedico);
            dtgCliente.Columns.Add(colFamiliaresACargo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<BD.Entidades.Paciente> listaPaciente = new List<BD.Entidades.Paciente>();
            if (txtBMDoc.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de documento.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                dtgCliente.DataSource = null;
                crearGrilla();
                List<SqlParameter> paramlist = new List<SqlParameter>();
                paramlist.Add(new SqlParameter("@Num_Doc", int.Parse(txtBMDoc.Text)));
                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_BUSCAR_AFILIADO", "SP", paramlist);
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        paciente.Nombre = (string)lector["Nombre"];
                        paciente.Apellido = (string)lector["Apellido"];
                        paciente.Tipo_Doc = (string)lector["Tipo_Doc"];
                        paciente.Num_Doc = (decimal)lector["Num_Doc"];
                        paciente.Direccion = (string)lector["Direccion"];
                        paciente.Telefono = (decimal) lector["Telefono"];
                        paciente.Mail = (string)lector["Mail"];
                        paciente.Fecha_Nac = (DateTime)lector["Fecha_Nac"];
                        paciente.Sexo = (string)lector["Sexo"];
                        paciente.Estado_Civil = (string)lector["Estado_Civil"];
                        paciente.Familiares_A_Cargo = (decimal)lector["Familiares_A_Cargo"];
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

       private void label2_Click(object sender, EventArgs e)
        {

        }

       private void button2_Click(object sender, EventArgs e)
       {
           if (dtgCliente.SelectedRows == null)
           {
               MessageBox.Show("Debe seleccionar un afiliado.", "Error", MessageBoxButtons.OK);
           }
           else
           {
               List<SqlParameter> paramlist = new List<SqlParameter>();
               paramlist.Add(new SqlParameter("@Num_Doc", txtBMDoc.Text));
               paramlist.Add(new SqlParameter("@Fecha_Baja", ArchivoConfiguracion.Default.FechaActual));
               SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
               paramRetAux.Direction = ParameterDirection.Output;
               paramlist.Add(paramRetAux);
               Int32 retorno=BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_BAJA_AFILIADO", paramlist);
               if ( retorno== -1)
               {
                   MessageBox.Show("No existe este Afiliado", "Error", MessageBoxButtons.OK);
               }
               else if (retorno == -2)
               {
                   MessageBox.Show("Este Afiliado ya fue dado de baja", "Error", MessageBoxButtons.OK);
               }
               else 
               {
                   paramlist.Clear();
                   paramlist.Add(new SqlParameter("@Num_Doc", txtBMDoc.Text));
                   paramlist.Add(new SqlParameter("@Fecha_Baja", ArchivoConfiguracion.Default.FechaActual));
                   paramlist.Add(paramRetAux);
                   BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_BAJA_AFILIADO", "SP", paramlist);
                   dtgCliente.DataSource = null;
                   lbBorradoModificado.Visible = true;
                   timer1.Enabled = true;
               }

           }
       }

       private void lbBorradoModificado_Click(object sender, EventArgs e)
       {

       }

       private void timer1_Tick(object sender, EventArgs e)
       {
           if (timer1.Enabled == true)
           {
               lbBorradoModificado.Visible = false;
           }
       }

       private void button7_Click(object sender, EventArgs e)
       {
           Abm_Afiliado.ModificacionAfiliado mod = new Abm_Afiliado.ModificacionAfiliado(fun, paciente, lbBorradoModificado, timer1, dtgCliente);
           mod.Show();

           //MessageBox.Show("Modifique el campo que desee y luego haga 'Enter' para realizar la modificación.", "Instrucciones de modificado", MessageBoxButtons.OK);
           //dtgCliente.EditMode = DataGridViewEditMode.EditOnEnter;

       }

       private void txtNroDoc_TextChanged(object sender, EventArgs e)
       {

       }
    }
}
