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
    public partial class A_Familia : Form
    {
        public int cantFamilia;
        public decimal num_raiz;

        public A_Familia(int cantFamilia, decimal num_raiz)
        {
            this.cantFamilia = cantFamilia;
            this.num_raiz = num_raiz;
            InitializeComponent();
        }

        private void A_Familia_Load(object sender, EventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btIngresar_Click(object sender, EventArgs e)
        {
            if (cantFamilia == 1) 
            {
                cargar_Datos(); 
            }
            else
            {
                this.cantFamilia--;
                if (cantFamilia > 0)
                {
                    A_Familia af = new A_Familia(cantFamilia, num_raiz);
                    af.Show();
                    cargar_Datos();
                }
            }
            this.Hide();
        }

        private void cargar_Datos()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@Nombre", txtNombre.Text));
            lista.Add(new SqlParameter("@Apellido", txtApellido.Text));
            lista.Add(new SqlParameter("@Tipo_Doc", cbTipoDoc.SelectedItem));
            lista.Add(new SqlParameter("@Num_Doc", int.Parse(txtNroDoc.Text)));
            lista.Add(new SqlParameter("@Direccion", txtDirec.Text));
            lista.Add(new SqlParameter("@Telefono", int.Parse(txtTel.Text)));
            lista.Add(new SqlParameter("@Mail", txtMail.Text));
            lista.Add(new SqlParameter("@Fecha_Nac", dateFechaNac.Value));
            lista.Add(new SqlParameter("@Sexo", cbSexo.Text.Substring(0, 1)));
            lista.Add(new SqlParameter("@Estado_Civil", cbEstadoCivil.Text));
            lista.Add(new SqlParameter("@Familiares_A_Cargo", DBNull.Value));
            lista.Add(new SqlParameter("@Plan", "Plan Medico "+ cbPlanMedico.Text));
            lista.Add(new SqlParameter("@Num_Afiliado_Raiz", num_raiz));
            SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Decimal);
            paramRetAux.Direction = ParameterDirection.Output;
            lista.Add(paramRetAux);
            decimal retorno= BDStranger_Strings.ExecStoredProcedureAlta("STRANGER_STRINGS.SP_ALTA_AFILIADO", lista);
            if (retorno == -1)
            {
                MessageBox.Show("Afiliado ya existente", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
