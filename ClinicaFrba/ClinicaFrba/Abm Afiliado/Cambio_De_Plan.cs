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
    public partial class Cambio_De_Plan : Form
    {
        Funcionalidades fun;
        BD.Entidades.Paciente paciente;

        public Cambio_De_Plan(Funcionalidades fun, BD.Entidades.Paciente paciente)
        {
            InitializeComponent();
            this.fun=fun;
            this.paciente = paciente;
        }

        private void Cambio_De_Plan_Load(object sender, EventArgs e)
        {
            string plan;
            plan = paciente.PlanMedico.Substring(12, 3);
            if(cbPlanMedico.Items.Contains(plan))
            {
                cbPlanMedico.Items.Remove(plan);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                lbPlanMod.Visible = false;
                this.Close();
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Num_Doc", paciente.Num_Doc));
            listParam.Add(new SqlParameter("@Tipo_Doc", paciente.Tipo_Doc));
            listParam.Add(new SqlParameter("@Motivo", lbMotivo.Text));
            listParam.Add(new SqlParameter("@Descripcion_Plan_Viejo", paciente.PlanMedico));
            listParam.Add(new SqlParameter("@Descripcion_Plan_Nuevo", "Plan Medico "+cbPlanMedico.Text));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_CAMBIO_PLAN", "SP", listParam);

            lbPlanMod.Visible = true;
            timer1.Enabled = true;
            
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbMotivo_Click(object sender, EventArgs e)
        {

        }
    }
}
