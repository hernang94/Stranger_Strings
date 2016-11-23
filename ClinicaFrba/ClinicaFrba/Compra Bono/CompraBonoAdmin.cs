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

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBonoAdmin : Form
    {
        public Funcionalidades fun;
        decimal precio = 0;
        decimal unidades;
        BD.Entidades.Paciente paciente = new BD.Entidades.Paciente(); 

        public CompraBonoAdmin(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
        }

        private void CompraBonoAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void btVerificarAfiliado_Click(object sender, EventArgs e)
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_Doc",decimal.Parse(txtDNI.Text)));
            paramlist.Add(new SqlParameter("@Tipo_Doc", cbTipoDoc.SelectedItem));
            SqlParameter paramRet = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRet.Direction = ParameterDirection.Output;
            paramlist.Add(paramRet);
            if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_VALIDAR_AFILIADO", paramlist) == 0)
            {
                MessageBox.Show("Ingrese un DNI válido.", "Error", MessageBoxButtons.OK);
                txtDNI.Clear();
            }
            else
            {
                MessageBox.Show("Usuario Valido", "", MessageBoxButtons.OK);
                paciente.Num_Doc = decimal.Parse(txtDNI.Text);
                paciente.Tipo_Doc = cbTipoDoc.SelectedItem.ToString();
                obtenerPlan();
                obtenerPrecioBonoSegunPlan();
            }
        }

        private void nudCantidadBonos_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void obtenerPlan()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_Doc", paciente.Num_Doc));
            paramlist.Add(new SqlParameter("@Tipo_Doc", paciente.Tipo_Doc));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_BUSCAR_AFILIADO", "SP", paramlist);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    paciente.PlanMedico = (string)lector["Descripcion"];
                }
            }
        }

        private void obtenerPrecioBonoSegunPlan()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Descripcion", paciente.PlanMedico));

            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_PRECIO_BONO", "SP", paramlist);
            if (lector.HasRows)
            {
                lector.Read();
                precio = (decimal)lector["Precio_Bono_Consulta"];
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.fun.Show();
            this.Close();
        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            DialogResult mge = MessageBox.Show("¿Está seguro que quiere realizar la compra?", "Confirmación de operación", MessageBoxButtons.YesNo);
            if (mge == DialogResult.Yes)
            {
                List<SqlParameter> paramlist = new List<SqlParameter>();
                paramlist.Add(new SqlParameter("@Num_Doc", paciente.Num_Doc));
                paramlist.Add(new SqlParameter("@Tipo_Doc", paciente.Tipo_Doc));
                paramlist.Add(new SqlParameter("@Fecha_Compra", ArchivoConfiguracion.Default.FechaActual));
                paramlist.Add(new SqlParameter("@Cantidad_Bonos", System.Convert.ToString(nudCantidadBonos.Value)));

                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_COMPRA_BONOS", "SP", paramlist);

                nudCantidadBonos.Value = 0;
                lbPrecioTotal.Visible = false;
                lbCompraExito.Visible = true;
                timer1.Enabled = true;
                txtDNI.Clear();
                cbTipoDoc.ResetText();
            }
            else
            {
                nudCantidadBonos.Value = 0;
                lbPrecioTotal.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbCompraExito.Visible = false;
            }
        }

        private void btCalcularPrecio_Click(object sender, EventArgs e)
        {
            unidades = nudCantidadBonos.Value;
            lbPrecioTotal.Text = "$ " + (precio * unidades);
            lbPrecioTotal.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
