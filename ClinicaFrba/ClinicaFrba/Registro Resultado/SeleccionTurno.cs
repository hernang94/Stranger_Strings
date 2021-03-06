﻿using System;
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
    public partial class SeleccionTurno : Form
    {
        public SeleccionEspecialidad selecEsp;
        public string Especialidad;
        public string fecha;
        public Funcionalidades fun;
        public List<BD.Entidades.Turno> listaTurnos = new List<BD.Entidades.Turno>();

        public SeleccionTurno(Funcionalidades fun, SeleccionEspecialidad selecEsp, string esp, string fecha)
        {
            this.fun = fun;
            this.fecha = fecha;
            this.Especialidad = esp;
            this.selecEsp = selecEsp;
            InitializeComponent();
            crearGrilla();
            actualizarGrilla();
        }
        private void crearGrilla()
        {
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "fecha";
            colFecha.HeaderText = "Fecha";
            colFecha.Width = 110;
            DataGridViewTextBoxColumn colPaciente = new DataGridViewTextBoxColumn();
            colPaciente.DataPropertyName = "apellido_Pac";
            colPaciente.HeaderText = "Paciente";
            colPaciente.Width = 210;
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre_Pac";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 210;

            dtgTurnos.Columns.Add(colFecha);
            dtgTurnos.Columns.Add(colPaciente);
            dtgTurnos.Columns.Add(colNombre);
        }

        private void actualizarGrilla()
        {
            BD.Entidades.Especialidad espSeleccionada=obtenerCodigoEspecialidad();
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (this.selecEsp.funFake == null)
            {
                paramList.Add(new SqlParameter("@Num_Doc", fun.user.Dni));
                paramList.Add(new SqlParameter("@Tipo_Doc", fun.user.Tipo_Doc));
            }
            else 
            {
                paramList.Add(new SqlParameter("@Num_Doc", this.selecEsp.funFake.user.Dni));
                paramList.Add(new SqlParameter("@Tipo_Doc", this.selecEsp.funFake.user.Tipo_Doc));
            }
            paramList.Add(new SqlParameter("@Especialidad_Codigo", espSeleccionada.Especialidad_Cod));
            paramList.Add(new SqlParameter("@Fecha", Convert.ToDateTime(fecha)));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_PEDIR_TURNO_MEDICO_FECHA", "SP", paramList);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Turno turno = new BD.Entidades.Turno();
                    turno.fecha = (DateTime)lector["Turno_Fecha"];
                    turno.nombre_Pac = (string)lector["Nombre"];
                    turno.apellido_Pac = (string)lector["Apellido"];
                    turno.id_Consulta = (int)lector["Id_Consulta"];
                    listaTurnos.Add(turno);
                }
            }
            dtgTurnos.DataSource= listaTurnos;
            dtgTurnos.Columns["apellido_Prof"].Visible = false;
            dtgTurnos.Columns["especialidad"].Visible = false;
            dtgTurnos.Columns["id_Consulta"].Visible = false;
            dtgTurnos.Columns["nro"].Visible = false;
            //dtgTurnos.Columns["tipo_Doc"].Visible = false;
            dtgTurnos.Columns["Codigo"].Visible = false;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            RegistroResultado reg = new RegistroResultado(fun,this, (BD.Entidades.Turno)dtgTurnos.CurrentRow.DataBoundItem);
            reg.Show();
            this.Hide();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            selecEsp.Show();
        }

        private void SeleccionTurno_Load(object sender, EventArgs e)
        {

        }
        private BD.Entidades.Especialidad obtenerCodigoEspecialidad()
        {
            for (int i = 0; i < selecEsp.espXmedico.Count(); i++)
            {
                if (selecEsp.espXmedico[i].Especialidad_Descr == Especialidad)
                {
                    return selecEsp.espXmedico[i];
                }
            }
            return null;
        }

        private void dtgTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
