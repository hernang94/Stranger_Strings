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
        BD.Entidades.Paciente pac;
        BD.Entidades.Turno turno;
        Registro_Llegada registroLlegada;
        List<BD.Entidades.Bono> bonos = new List<BD.Entidades.Bono>();

        public SeleccionBono(BD.Entidades.Paciente pac,BD.Entidades.Turno turno, Registro_Llegada registroLlegada)
        {
            this.pac = pac;
            this.turno = turno;
            this.registroLlegada = registroLlegada;
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
            colCodPlan.DataPropertyName = "Codigo_Plan";
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
            List<SqlParameter> listaParamAux = new List<SqlParameter>();
            listaParamAux.Add(new SqlParameter("@Num_Doc", pac.Num_Doc));
            listaParamAux.Add(new SqlParameter("@Tipo_Doc", pac.Tipo_Doc));
            SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRetAux.Direction = ParameterDirection.Output;
            listaParamAux.Add(paramRetAux);
            if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE", listaParamAux) == 1)
            {
                List<SqlParameter> listaParam = new List<SqlParameter>();
                listaParam.Add(new SqlParameter("@Num_Doc", pac.Num_Doc));
                listaParam.Add(new SqlParameter("@Tipo_Doc", pac.Tipo_Doc));
                SqlParameter paramRet = new SqlParameter("@Retorno", SqlDbType.Int);
                paramRet.Direction = ParameterDirection.Output;
                listaParam.Add(paramRet);
                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE", "SP", listaParam);
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
            BD.Entidades.Bono bonoSeleccionado = (BD.Entidades.Bono)dtgBono.CurrentRow.DataBoundItem;
            List<SqlParameter> listaParam = new List<SqlParameter>();
            listaParam.Add(new SqlParameter("@Fecha", turno.fecha));
            listaParam.Add(new SqlParameter("@Num_Doc", pac.Num_Doc));
            listaParam.Add(new SqlParameter("@Tipo_Doc", pac.Tipo_Doc));
            listaParam.Add(new SqlParameter("@Nro_Turno", turno.nro));
            listaParam.Add(new SqlParameter("@Id_Bono", bonoSeleccionado.id_Bono));
            SqlParameter paramRet = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRet.Direction = ParameterDirection.Output;
            listaParam.Add(paramRet);
            Int32 retorno = BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_CREAR_CONSULTA", listaParam);
            if (retorno == 0)
            {
                MessageBox.Show("Ha ocurrido un error, la llegada no se pudo registrar. Vuevla a intentarlo.", "Error", MessageBoxButtons.OK);
                actualizarGrilla();
            }
            else
            {
                MessageBox.Show("Registro de llegada realizado con éxito.", "Éxito", MessageBoxButtons.OK);
                registroLlegada.obtenerTurnos();
                this.Close();
            }
        }
    }

}
