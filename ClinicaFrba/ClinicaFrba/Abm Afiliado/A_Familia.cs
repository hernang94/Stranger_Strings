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
        public int num_raiz;

        public A_Familia(int cantFamilia, int num_raiz)
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
            int numero = 2;
            this.cantFamilia--;
            if (cantFamilia > 0)
            {
                A_Familia af = new A_Familia(cantFamilia,num_raiz);
                af.Show();
                cargar_Datos(numero);
                numero++;
            }

            this.Hide();
        }
        private void cargar_Datos(int numero)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@nombre", txtNombre.Text));
            lista.Add(new SqlParameter("@apellido", txtApellido.Text));
            lista.Add(new SqlParameter("@tipo_Doc", txtTipoDoc.Text));
            lista.Add(new SqlParameter("@nro_Doc", int.Parse(txtNroDoc.Text)));
            lista.Add(new SqlParameter("@direccion", txtDirec.Text));
            lista.Add(new SqlParameter("@tel", int.Parse(txtTel.Text)));
            lista.Add(new SqlParameter("@mail", txtMail.Text));
            lista.Add(new SqlParameter("@fecha_Nac", dateFechaNac.Value));
            lista.Add(new SqlParameter("@sexo", cbSexo.Text.Substring(0, 1)));
            lista.Add(new SqlParameter("@estado_Civil", cbEstadoCivil.Text));
            lista.Add(new SqlParameter("@plan_Med", cbPlanMedico.SelectedIndex));
            lista.Add(new SqlParameter("@num_raiz", num_raiz));
            lista.Add(new SqlParameter("@num_resto",numero));
            BDStranger_Strings.WriteInBase("INSERT INTO STRANGER_STRINGS.Paciente (Nombre, Apellido, Tipo_Doc, Num_Doc, Direccion, Telefono, Mail, Fecha_Nac, Sexo, Estado_Civil, Familiares_A_Cargo, Codigo_Plan, Num_Afiliado_Raiz, Num_Afiliado_Resto) VALUES (@nombre,@apellido,@tipo_doc, @nro_doc,@direccion,@tel, @mail, @fecha_Nac,@sexo,@estado_Civil, NULL ,@plan_Med,@num_raiz, @num_resto", "T", lista);
        }
    }
}
