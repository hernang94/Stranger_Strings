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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class SeleccionBono : Form
    {
        BD.Entidades.Paciente pac = new BD.Entidades.Paciente();
        List<BD.Entidades.Bono> bonos = new List<BD.Entidades.Bono>();
        public SeleccionBono(BD.Entidades.Paciente pac)
        {
            this.pac = pac;
            InitializeComponent();
        }

        private void SeleccionBono_Load(object sender, EventArgs e)
        {
            crearGrilla();
            actualizarGrilla();
        }
        private void crearGrilla()
        {
            DataGridViewTextBoxColumn colNroBono = new DataGridViewTextBoxColumn();
            colNroBono.DataPropertyName = "id_Bono";
            colNroBono.HeaderText = "Nro Bono";
            colNroBono.Width = 200;
            DataGridViewTextBoxColumn colCodPlan = new DataGridViewTextBoxColumn();
            colCodPlan.DataPropertyName = "codigo_plan ";
            colCodPlan.HeaderText = "Codigo de Plan";
            colCodPlan.Width = 200;
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "fecha_compra";
            colFecha.HeaderText = "Fecha de Compra";
            colFecha.Width = 100;

            dtgBono.Columns.Add(colNroBono);
            dtgBono.Columns.Add(colFecha);
            dtgBono.Columns.Add(colCodPlan);

        }

        private void actualizarGrilla()
        {
            int retorno;
            List<SqlParameter> listaParam = new List<SqlParameter>();
            listaParam.Add(new SqlParameter("@Num_Doc", pac.Num_Doc));
            SqlParameter paramRet = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            listaParam.Add(paramRet);
           // retorno = (int)BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE", listaParam);
           
                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE","SP", listaParam);
                if (Convert.ToInt32(paramRet.Value) == 1)
                {
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                        BD.Entidades.Bono bono = new BD.Entidades.Bono();
                        bono.fecha_compra = (DateTime)lector["Fecha_Compra"];
                        bono.codigo_plan = (int)lector["Codigo_Plan"];
                        bono.id_Bono = (int)lector["Id_Bono"];
                        bonos.Add(bono);
                    }
                   

                }
                dtgBono.DataSource = bonos;
            }
            else
            {
                MessageBox.Show("Este afiliado no posee bono", "Error", MessageBoxButtons.OK);
                this.Close();
            }

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
