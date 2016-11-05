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
    public partial class Registro_Llegada : Form
    {
        public List<BD.Entidades.Profesional> profesionales = new List<BD.Entidades.Profesional>();
        public List<BD.Entidades.Turno> turnos = new List<BD.Entidades.Turno>();
        public List<BD.Entidades.Especialidad> especialidades = new List<BD.Entidades.Especialidad>();
        public List<BD.Entidades.Bono> bonos = new List<BD.Entidades.Bono>();
        public List<BD.Entidades.Paciente> pacientes = new List<BD.Entidades.Paciente>();

        public Funcionalidades fun;

        public Registro_Llegada(Funcionalidades fun)
        {
            this.fun = fun;
            InitializeComponent();
        }

        private void Registro_Llegada_Load(object sender, EventArgs e)
        {
            obtenerProfesionales();
        }


        public void obtenerProfesionales()
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
                    cbProfesional.Items.Add(prof.Nombre + " " + prof.Apellido);
                    profesionales.Add(prof);
                }
            }
        }


        public void obtenerEspecialidades()
        {
            BD.Entidades.Profesional profElegido = new BD.Entidades.Profesional();
            profElegido = obtenerProfesionalDeString(cbProfesional.SelectedItem.ToString());

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_Doc", profElegido.Dni));
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

        public void obtenerTurnos()
        {
            BD.Entidades.Profesional prof = obtenerProfesionalDeString(cbProfesional.Text);
            List<SqlParameter> listaParam = new List<SqlParameter>();
            listaParam.Add(new SqlParameter("@Num_Doc", prof.Dni));
            listaParam.Add(new SqlParameter("@Especialidad_Codigo", obtenerCodigoEspecialidad()));
            listaParam.Add(new SqlParameter("@Fecha", dateFecha.Value));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_LISTAR_TURNOS_MEDICO", "SP", listaParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Turno turno = new BD.Entidades.Turno();
                    BD.Entidades.Paciente pac = new BD.Entidades.Paciente();
                    turno.nro = (int)lector["Turno_Numero"];
                    turno.nombre_Pac = (string)lector["Nombre"];
                    turno.apellido_Pac = (string)lector["Apellido"];
                    pac.Nombre = turno.nombre_Pac;
                    pac.Apellido = turno.apellido_Pac;
                    pac.Num_Doc = (decimal)lector["Num_Doc"];
                    turno.fecha = (DateTime)lector["Turno_Fecha"];
                    turnos.Add(turno);
                    pacientes.Add(pac);
                
                }
                dtgTurno.DataSource = turnos;
                dtgTurno.Columns["apellido_Prof"].Visible = false;
                dtgTurno.Columns["especialidad"].Visible = false;
                dtgTurno.Columns["id_Consulta"].Visible = false;
                dtgTurno.Columns["nro"].Visible = false;
            }

        }
        private void crearGrilla()
        {
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre_Pac";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 200;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido_Pac";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 200;
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "fecha";
            colFecha.HeaderText = "Fecha";
            colFecha.Width = 100;
            
            dtgTurno.Columns.Add(colFecha);
            dtgTurno.Columns.Add(colNombre);
            dtgTurno.Columns.Add(colApellido);
            
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
            for (int j = 0; j < profesionales.Count(); j
                ++)
            {
                if (profesionales[j].Apellido == profNuevo.Apellido && profesionales[j].Nombre == profNuevo.Nombre)
                {
                    return profesionales[j];
                }
            }
            return null;
        }

        public decimal obtenerCodigoEspecialidad()
        {
            return especialidades[cbEspecialidad.SelectedIndex].Especialidad_Cod;
        }

        private void cbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEspecialidad.Items.Clear();
            obtenerEspecialidades();
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            dtgTurno.Rows.Clear();
            crearGrilla();
            obtenerTurnos();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
           
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbEspecialidad_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private BD.Entidades.Paciente obtenerPaciente()
        {
            BD.Entidades.Turno turnoSeleccionado =(BD.Entidades.Turno)dtgTurno.CurrentRow.DataBoundItem;
            for(int i=0; i<pacientes.Count;i++)
            {
                if (pacientes[i].Nombre == turnoSeleccionado.nombre_Pac && pacientes[i].Apellido == turnoSeleccionado.apellido_Pac)
                {
                    return pacientes[i];
                }
            }
            return null;
        }
        private void btRegistrar_Click(object sender, EventArgs e)
        {
            SeleccionBono sel = new SeleccionBono(obtenerPaciente());
            sel.Show();
        }
    }
}