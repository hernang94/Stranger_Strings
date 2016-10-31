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
    public partial class CompraBono : Form
    {
        Funcionalidades fun;
        decimal precio = 0;
        decimal unidades;
        BD.Entidades.Paciente paciente = new BD.Entidades.Paciente(); 


        public CompraBono(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CompraBono_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btCalcularPrecio_Click(object sender, EventArgs e)
        {
            obtenerPlan();
            obtenerPrecioBonoSegunPlan();
            unidades = nudCantidadBonos.Value;
            lbPrecioTotal.Text = "$ " + (precio*unidades);
            lbPrecioTotal.Visible = true;
        }

        private void obtenerPlan() 
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_Doc", int.Parse(fun.user.Nombre)));
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
                paramlist.Add(new SqlParameter("@Num_Doc", int.Parse(fun.user.Nombre)));
                paramlist.Add(new SqlParameter("@Fecha_Compra", System.DateTime.Now.ToString()));
                paramlist.Add(new SqlParameter("@Cantidad_Bonos", System.Convert.ToString(unidades)));
                paramlist.Add(new SqlParameter("@Importe_Total", System.Convert.ToString(precio)));

                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_COMPRA_BONOS", "SP", paramlist);
            }
            else
            {
                nudCantidadBonos.Value = 0;
                lbPrecioTotal.Visible = false;
            }
        }
    }
}
