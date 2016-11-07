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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class RegistroResultado : Form
    {
        public Funcionalidades fun;
        public BD.Entidades.Turno turno;
        public SeleccionTurno sel;

        public RegistroResultado(Funcionalidades fun, SeleccionTurno sel, BD.Entidades.Turno turno)
        {
            this.sel = sel;
            this.turno = turno;
            this.fun = fun;
            InitializeComponent();
            dtFechaHora.Format = DateTimePickerFormat.Time;

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            sel.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            lbConsultaRegistrada.Visible = true;
            timer1.Enabled = true;
            if (ckPresento.Checked)
            {

                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@Id_Consulta", turno.id_Consulta));
                paramList.Add(new SqlParameter("@Fecha_Y_Hora_Atencion", DBNull.Value));
                paramList.Add(new SqlParameter("@Sintomas", DBNull.Value));
                paramList.Add(new SqlParameter("@Diagnostico", DBNull.Value));
                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_REGISTRAR_RESULTADO_CONSULTA", "SP", paramList);
            }
            else
            {
                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@Id_Consulta", turno.id_Consulta));
                paramList.Add(new SqlParameter("@Fecha_Y_Hora_Atencion", dtFechaHora.Value.ToString()));
                paramList.Add(new SqlParameter("@Sintomas", txtSintomas.Text));
                paramList.Add(new SqlParameter("@Diagnostico", txtEnfermedades.Text));
                BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_REGISTRAR_RESULTADO_CONSULTA", "SP", paramList);
            }
            fun.Show();
            sel.Close();
            sel.selecEsp.Close();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbConsultaRegistrada.Visible = false;
            }
        }

        private void btVolver_Click_1(object sender, EventArgs e)
        {
            sel.Show();
            this.Close();
        }
    }
}
    