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
    public partial class CompraBonoAfiliado : Form
    {
        Funcionalidades fun;
        Funcionalidades funFake;
        decimal precio = 0;
        decimal unidades;
        BD.Entidades.Paciente paciente = new BD.Entidades.Paciente(); 


        public CompraBonoAfiliado(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
        }

        public CompraBonoAfiliado(Funcionalidades fun, Funcionalidades funFake)
        {
            InitializeComponent();
            this.fun = fun;
            this.funFake = funFake;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
            obtenerPlan();
            obtenerPrecioBonoSegunPlan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fun.Show();
            this.Close();
        }

        private void btCalcularPrecio_Click(object sender, EventArgs e)
        {
            unidades = nudCantidadBonos.Value;
            lbPrecioTotal.Text = "$ " + (precio*unidades);
            lbPrecioTotal.Visible = true;
        }

        private void obtenerPlan() 
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            if (funFake == null)
            {
                paramlist.Add(new SqlParameter("@Num_Doc", fun.user.Dni));
            }
            else
            {
                paramlist.Add(new SqlParameter("@Num_Doc", funFake.user.Dni));
            }
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
                precio=(decimal)lector["Precio_Bono_Consulta"];
            }
        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            DialogResult mge = MessageBox.Show("¿Está seguro que quiere realizar la compra?", "Confirmación de operación", MessageBoxButtons.YesNo);
            if (mge == DialogResult.Yes)
            {
                List<SqlParameter> paramlist = new List<SqlParameter>();
                if (funFake == null)
                {
                    paramlist.Add(new SqlParameter("@Num_Doc", fun.user.Dni));
                }
                else
                {
                    paramlist.Add(new SqlParameter("@Num_Doc", funFake.user.Dni));
                }
                paramlist.Add(new SqlParameter("@Fecha_Compra", ArchivoConfiguracion.Default.FechaActual));
                paramlist.Add(new SqlParameter("@Cantidad_Bonos", System.Convert.ToString(nudCantidadBonos.Value)));

                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_COMPRA_BONOS", "SP", paramlist);

                nudCantidadBonos.Value = 0;
                lbPrecioTotal.Visible = false;
                lbCompraExito.Visible = true;
                timer1.Enabled = true;
            }
            else
            {
                nudCantidadBonos.Value = 0;
                lbPrecioTotal.Visible = false;
            }
        }

        private void lbCompraExito_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbCompraExito.Visible = false;
            }
        }
    }
}
