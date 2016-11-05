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
            this.fun = fun;
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
                paramList.Add(new SqlParameter("@Turno_Fecha", monthCalendar1.SelectionRange.Start));
                paramList.Add(new SqlParameter("@Num_Doc", int.Parse(fun.user.Nombre)));
                paramList.Add(new SqlParameter("@Tipo_Cancelacion", 'M'));
                paramList.Add(new SqlParameter("@Motivo", txtMotivo.Text));
                
                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL", "SP", paramList);
            }
            else
            {
                paramList.Add(new SqlParameter("@Tipo_Cancelacion", 'M'));
                paramList.Add(new SqlParameter("@Motivo", txtMotivo.Text));
                paramList.Add(new SqlParameter("@Num_Doc", int.Parse(fun.user.Nombre)));
                paramList.Add(new SqlParameter("@Fecha_Desde", dtpFechaDesde.Value));
                paramList.Add(new SqlParameter("@Fecha_Hasta", dtpFechaHasta.Value));

                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL", "SP", paramList);
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
                    lista_turnos.Add((DateTime)lector["Turno_Fecha"]);
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
            monthCalendar1.SelectionStart = ArchivoConfiguracion.Default.FechaActual;
            monthCalendar1.SelectionEnd = ArchivoConfiguracion.Default.FechaActual;
            dtpFechaDesde.Value = ArchivoConfiguracion.Default.FechaActual;
            dtpFechaHasta.Value = ArchivoConfiguracion.Default.FechaActual;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbDiaCompleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiaCompleto.SelectedIndex == 1)
            {
                lbFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                dtpFechaDesde.Visible = true;
                dtpFechaHasta.Visible = true;

                monthCalendar1.Visible = false;
            }
            if(cbDiaCompleto.SelectedIndex == 0)
            {
                monthCalendar1.Visible = true;

                lbFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                dtpFechaDesde.Visible = false;
                dtpFechaHasta.Visible = false;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            int i = 0;
            int acierto = 0;
            while (i<lista_turnos.Count() && acierto==0)
            {
                if (lista_turnos[i].Date.ToString() == monthCalendar1.SelectionRange.Start.ToString())
                {
                    acierto = 1;
                }
                i++;
            }
            if (acierto != 1)
            {
                MessageBox.Show("Seleccione una fecha valida de atención.", "Error", MessageBoxButtons.OK);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTurnosCancelados_Click(object sender, EventArgs e)
        {

        }

        private void gbMotivo_Enter(object sender, EventArgs e)
        {

        }
    }
}
