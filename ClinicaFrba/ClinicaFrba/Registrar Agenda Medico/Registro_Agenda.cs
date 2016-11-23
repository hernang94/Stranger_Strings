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

namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public partial class Registro_Agenda : Form
    {
        public Funcionalidades fun;
        public List<BD.Entidades.Profesional> profesionales = new List<BD.Entidades.Profesional>();
        public List<BD.Entidades.Especialidad> especialidades = new List<BD.Entidades.Especialidad>();


        public Registro_Agenda(Funcionalidades fun)
        {
            this.fun = fun;
            InitializeComponent();
        }

        private void Registro_Agenda_Load(object sender, EventArgs e)
        {
            obtenerYMostrarProfesionales();
            dtpFechaDesde.Value = ArchivoConfiguracion.Default.FechaActual;
            dtpFechaHasta.Value = ArchivoConfiguracion.Default.FechaActual;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDia.SelectedIndex == 5)
            {
                dtpHoraDesde.MinDate = new DateTime(1753, 01, 01, 10, 00, 00);
                dtpHoraDesde.Value = new DateTime(1754, 01, 01, 10, 00, 00);
                dtpHoraDesde.MaxDate = new DateTime(2020, 01, 01, 14, 30, 00);

                dtpHoraHasta.MinDate = new DateTime(1753, 01, 01, 10, 30, 00);
                dtpHoraHasta.Value = new DateTime(1754, 01, 01, 10, 30, 00);
                dtpHoraHasta.MaxDate = new DateTime(2020, 01, 01, 15, 00, 00);
            }
            else
            {
                dtpHoraDesde.MinDate = new DateTime(1753, 01, 01, 07, 00, 00);
                dtpHoraDesde.Value = new DateTime(1754, 01, 01, 07, 00, 00);
                dtpHoraDesde.MaxDate = new DateTime(2020, 01, 01, 19, 30, 00);

                dtpHoraHasta.MinDate = new DateTime(1753, 01, 01, 07, 30, 00);
                dtpHoraHasta.Value = new DateTime(1754, 01, 01, 07, 30, 00);
                dtpHoraHasta.MaxDate = new DateTime(2020, 01, 01, 20, 00, 00);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
        }

        private void cbHoraDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string minDesde = dtpHoraDesde.Text.Substring(3, 2);
            string minHasta = dtpHoraHasta.Text.Substring(3, 2);

            if ((minDesde != "00" && minDesde != "30") || (minHasta != "00" && minHasta != "30"))
            {
                MessageBox.Show("El formato del rango horario deber ser 'HH:00' ó 'HH:30'", "Error formato minutos", MessageBoxButtons.OK);
            }
            else if (dtpFechaHasta.Value < dtpFechaDesde.Value || dtpHoraHasta.Value < dtpHoraDesde.Value)
            {
                MessageBox.Show("La hora/fecha hasta debe ser mayor a hora/fecha desde", "Error", MessageBoxButtons.OK);
            }
            else
            {
                BD.Entidades.Profesional prof = obtenerProfesionalDeString(cbProfesionales.Text);
                List<SqlParameter> paramlist = new List<SqlParameter>();
                paramlist.Add(new SqlParameter("@Num_Doc", prof.Dni));
                paramlist.Add(new SqlParameter("@Tipo_Doc", prof.Tipo_Doc));
                paramlist.Add(new SqlParameter("@Especialidad_Codigo", obtenerCodigoEspecialidad()));
                paramlist.Add(new SqlParameter("@Dia_Semana", cbDia.SelectedIndex + 1));
                paramlist.Add(new SqlParameter("@Fecha_Desde", dtpFechaDesde.Value));
                paramlist.Add(new SqlParameter("@Fecha_Hasta", dtpFechaHasta.Value));
                paramlist.Add(new SqlParameter("@Hora_Desde", dtpHoraDesde.Value));
                paramlist.Add(new SqlParameter("@Hora_Hasta", dtpHoraHasta.Value));
                SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
                paramRetAux.Direction = ParameterDirection.Output;
                paramlist.Add(paramRetAux);

                switch (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_ALTA_AGENDA", paramlist))
                {
                    case 0:
                        cbEspecialidad.Items.Clear();
                        cbEspecialidad.Refresh();
                        cbEspecialidad.ResetText();
                        cbDia.SelectedIndex = -1;
                        reestrablecerHoras();
                        cbProfesionales.Items.Clear();
                        cbProfesionales.Refresh();
                        cbProfesionales.ResetText();
                        obtenerYMostrarProfesionales();

                        lbAgendaRegistrada.Visible = true;
                        timer1.Enabled = true;
                        break;
                    case -1:
                        MessageBox.Show("El profesional ya posee sus 48hs semanales de trabajo ocupadas", "Error", MessageBoxButtons.OK);
                        break;
                    case -2:
                        MessageBox.Show("El profesional ya atiende otra especialidad en esa franja horaria y dia seleccionado", "Error", MessageBoxButtons.OK);
                        break;
                }
            }
        }

        public decimal obtenerCodigoEspecialidad()
        {
            return especialidades[cbEspecialidad.SelectedIndex].Especialidad_Cod;
        }

        public void obtenerYMostrarProfesionales()
        {
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_MEDICOS", "SP", null);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Profesional prof = new BD.Entidades.Profesional();
                    prof.Nombre = (string)lector["Nombre"];
                    prof.Apellido = (string)lector["Apellido"];
                    prof.Dni = (decimal)lector["Num_Doc"];
                    prof.Tipo_Doc = (string)lector["Tipo_Doc"];
                    cbProfesionales.Items.Add(prof.Nombre + " " + prof.Apellido);
                    profesionales.Add(prof);
                }
            }
        }

        public void obtenerYMostrarEspecialidades()
        {
            BD.Entidades.Profesional profElegido = new BD.Entidades.Profesional();
            profElegido = obtenerProfesionalDeString(cbProfesionales.SelectedItem.ToString());

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_Doc", profElegido.Dni));
            paramlist.Add(new SqlParameter("@Tipo_Doc", profElegido.Tipo_Doc));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_ESPECIALIDADES", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Especialidad especialidad = new BD.Entidades.Especialidad();
                    especialidad.Especialidad_Descr = (string)lector["Especialidad_Descripcion"];
                    especialidad.Especialidad_Cod = (decimal)lector["Especialidad_Codigo"];
                    cbEspecialidad.Items.Add(especialidad.Especialidad_Descr);
                    especialidades.Add(especialidad);
                }
            }
        }

        public BD.Entidades.Profesional obtenerProfesionalDeString(string profesional)
        {
            int i = 0;
            while (profesional.Substring(i, 1) != " ")
            {
                i++;
            }
            BD.Entidades.Profesional profNuevo = new BD.Entidades.Profesional();
            profNuevo.Nombre = profesional.Substring(0, i);
            profNuevo.Apellido = profesional.Substring(i + 1, (profesional.Length - i - 1));
            for (int j = 0; j < profesionales.Count(); j++)
            {
                if (profesionales[j].Apellido == profNuevo.Apellido && profesionales[j].Nombre == profNuevo.Nombre)
                {
                    return profesionales[j];
                }
            }
            return null;
        }

        private void cbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEspecialidad.Items.Clear();
            cbEspecialidad.SelectedIndex = -1;
            cbDia.SelectedIndex = -1;
            reestrablecerHoras();
            obtenerYMostrarEspecialidades();
            if (cbEspecialidad.Items.Count == 1)
            {
                cbEspecialidad.SelectedIndex = 0;
            }
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDia.SelectedIndex = -1;
            reestrablecerHoras();
        }

        public void reestrablecerHoras()
        {
            if (cbDia.SelectedIndex == 5)
            {
                dtpHoraDesde.MinDate = new DateTime(1753, 01, 01, 10, 00, 00);
                dtpHoraDesde.Value = new DateTime(1754, 01, 01, 10, 00, 00);
                dtpHoraDesde.MaxDate = new DateTime(2020, 01, 01, 14, 30, 00);

                dtpHoraHasta.MinDate = new DateTime(1753, 01, 01, 10, 30, 00);
                dtpHoraHasta.Value = new DateTime(1754, 01, 01, 10, 30, 00);
                dtpHoraHasta.MaxDate = new DateTime(2020, 01, 01, 15, 00, 00);
            }
            else
            {
                dtpHoraDesde.MinDate = new DateTime(1753, 01, 01, 07, 00, 00);
                dtpHoraDesde.Value = new DateTime(1754, 01, 01, 07, 00, 00);
                dtpHoraDesde.MaxDate = new DateTime(2020, 01, 01, 19, 30, 00);

                dtpHoraHasta.MinDate = new DateTime(1753, 01, 01, 07, 30, 00);
                dtpHoraHasta.Value = new DateTime(1754, 01, 01, 07, 30, 00);
                dtpHoraHasta.MaxDate = new DateTime(2020, 01, 01, 20, 00, 00);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbAgendaRegistrada.Visible = false;
            }
        }
    }
}
