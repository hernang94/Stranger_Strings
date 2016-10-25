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
                DialogResult resultadomge1 = DialogResult.No;
                DialogResult resultadomge2 = DialogResult.No;

                int num_raiz=cargar_Datos_Afiliados();
                //Si esta casado o en concubinato --------------------------------------------------
                if (cbEstadoCivil.SelectedIndex == 1 || cbEstadoCivil.SelectedIndex == 2)
                {
                    resultadomge1 = MessageBox.Show("¿Desea asociar a su conyugue/concubinato?", "Consulta", MessageBoxButtons.YesNo);
                }

                //Si tiene familiares a cargo ------------------------------------------------------
                if (int.Parse(nupCantFamilia.Text)>0)
                {
                    resultadomge2 = MessageBox.Show("¿Desea asociar a sus familiares a cargo?", "Consulta", MessageBoxButtons.YesNo);
                }
                
                if (resultadomge1 == DialogResult.Yes && resultadomge2 == DialogResult.Yes)
                {
                    A_Familia af = new A_Familia(int.Parse(nupCantFamilia.Text)+1,num_raiz);
                    af.Show();
                }
                else if (resultadomge1 == DialogResult.Yes && resultadomge2 == DialogResult.No)
                {
                    A_Familia af = new A_Familia(1,num_raiz);
                    af.Show();
                }
                else if (resultadomge1 == DialogResult.No && resultadomge2 == DialogResult.Yes)
                {
                    A_Familia af = new A_Familia(int.Parse(nupCantFamilia.Text),num_raiz);
                    af.Show();
                }
            
            
        }

        private int cargar_Datos_Afiliados()
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
            lista.Add(new SqlParameter("@num_resto", 1));
            BDStranger_Strings.WriteInBase("INSERT INTO STRANGER_STRINGS.Paciente (Nombre, Apellido, Tipo_Doc, Num_Doc, Direccion, Telefono, Mail, Fecha_Nac, Sexo, Estado_Civil, Familiares_A_Cargo, Codigo_Plan, Num_Afiliado_Resto) VALUES (@nombre,@apellido,@tipo_doc, @nro_doc,@direccion,@tel, @mail, @fecha_Nac,@sexo,@estado_Civil,@cant_Familiares,@plan_Med, @num_resto","T", lista);
            lista.Clear();
            lista.Add(new SqlParameter("@nro_Doc", int.Parse(txtNroDoc.Text)));
            int num_raiz=0;
            SqlDataReader lector = BDStranger_Strings.GetDataReader("SELECT * FROM STRANGER_STRINGS.Paciente WHERE Num_Doc=@nro_Doc", "T", lista);
            if (lector.HasRows)
            {
                num_raiz = (int)lector["Num_Afiliado_Raiz"];
            }
            return num_raiz;
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
