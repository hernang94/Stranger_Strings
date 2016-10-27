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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencionMedico : Form
    {
        Funcionalidades fun;
        List<DateTime> lista_turnos = new List<DateTime>();

        public CancelarAtencionMedico(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun=fun;
            PedirTurnosMedico();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            DialogResult msge = MessageBox.Show("¿Esta seguro que desea cancelar fecha o período seleccionado?", "Confirmar cancelación", MessageBoxButtons.YesNo);
            if (msge == DialogResult.Yes)
            {
                lbTurnosCancelados.Visible = true;
                timer1.Enabled = true;
                cancelarTurnos();
            }
        }

        private void cancelarTurnos()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (cbDiaCompleto.SelectedIndex==0)
            {
                paramList.Add(new SqlParameter("@Fecha", monthCalendar1.SelectionRange));
                paramList.Add(new SqlParameter("@num_Doc", int.Parse(fun.user.Nombre)));
                //Hacer el SP ----------------------------------------------------------------
                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_CANCELAR_TURNOS_FECHA", "SP", paramList);
            }
            else
            {
                paramList.Add(new SqlParameter("@Fecha", monthCalendar1.SelectionRange));
                paramList.Add(new SqlParameter("@Hora_Desde", nudDesde.Value));
                paramList.Add(new SqlParameter("@Hora_Hasta", nudHasta.Value));
                paramList.Add(new SqlParameter("@num_Doc", int.Parse(fun.user.Nombre)));
                //HACER EL SP------------------------------------------------------------------
                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_CANCELAR_TURNOS_PERIODO", "SP", paramList);
            }

        }

        private void PedirTurnosMedico()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@num_Doc", int.Parse(fun.user.Nombre)));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_PEDIR_TURNOS_MEDICO","SP",paramList);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    lista_turnos.Add((DateTime)lector["Fecha"]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbTurnosCancelados.Visible = false;
            }
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Hide();
        }

        private void lbHoraHasta_Click(object sender, EventArgs e)
        {

        }

        private void nudHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ldHoraDesde_Click(object sender, EventArgs e)
        {

        }

        private void CancelarAtencionMedico_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbDiaCompleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiaCompleto.SelectedIndex == 1)
            {
                cbDiaCompleto.Visible = false;
                lbDiaCompleto.Visible = false;

                lbHoraDesde.Visible = true;
                lbHoraHasta.Visible = true;
                nudDesde.Visible = true;
                nudHasta.Visible = true;
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
