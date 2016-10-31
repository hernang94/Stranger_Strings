using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.BD;
using System.Data.SqlClient;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class formSolicitarTurno : Form
    {
        public Funcionalidades fun;

        public formSolicitarTurno(Funcionalidades fun)
        {
            this.fun = fun;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbEspecialidad.Text != "" && cbFecha.Text != "" && cbProfesionales.Text != "" && cbHorariosDisp.Text != "")
            {
                BD.Entidades.Profesional prof = obtenerProfesionalDeString(cbEspecialidad.Text);
                List<SqlParameter> listParam = new List<SqlParameter>();
                listParam.Add(new SqlParameter("@Fecha", cbFecha));
                listParam.Add(new SqlParameter("@Num_Doc_Paciente", int.Parse(fun.user.Nombre)));
                listParam.Add(new SqlParameter("@Nombre", cbEspecialidad));
                listParam.Add(new SqlParameter("@Especialidad", cbEspecialidad));

                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_HORARIOS", "SP", listParam);
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        cbHorariosDisp.Items.Add((DateTime)lector["Horarios"]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK);
            }
   
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            fun.Show();
        }

        private void formSolicitarTurno_Load(object sender, EventArgs e)
        {
            obtenerYMostrarEspecialidades();
        }
 
        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerYMostrarProfesionales(cbEspecialidad.Text);
        }

        private void cbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerYMostrarFechas(cbProfesionales.Text,cbEspecialidad.Text);
        }

        private void cbHorariosDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerYMostrarHorarios(cbFecha.Text,cbProfesionales.Text,cbEspecialidad.Text);
        }
       
        public void obtenerYMostrarEspecialidades()
        {
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_ESPECIALIDADES", "SP", null);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbEspecialidad.Items.Add((string)lector["Especialidad"]);
                }
            }
        }

        public void obtenerYMostrarProfesionales(string especialidad)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Especialidad", especialidad));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_MEDICOS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Profesional prof = new BD.Entidades.Profesional();
                    prof.Nombre = (string)lector["Nombre"];
                    prof.Apellido = (string)lector["Apellido"];
                    cbProfesionales.Items.Add(prof.Nombre+" "+prof.Apellido);
                }
            }
        }

        public void obtenerYMostrarFechas(string profesional, string especialidad)
        {
            BD.Entidades.Profesional prof= obtenerProfesionalDeString(profesional);
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Nombre", prof.Nombre));
            listParam.Add(new SqlParameter("@Apellido", prof.Apellido));
            listParam.Add(new SqlParameter("@Especialidad",especialidad));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FECHAS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbFecha.Items.Add((DateTime)lector["Fecha"]);
                }
            }
        }
        public BD.Entidades.Profesional obtenerProfesionalDeString(string profesional)
        {
            int i = 0;
            while(profesional.Substring(i,1)!=" ")
            {
                i++;
            }
            BD.Entidades.Profesional profNuevo = new BD.Entidades.Profesional();
            profNuevo.Nombre = profesional.Substring(0, i);
            profNuevo.Apellido = profesional.Substring(i + 1, (profesional.Length-(i)));
            return profNuevo;
        }

        public void obtenerYMostrarHorarios(string fecha, string profesional, string especialidad)
        {
            BD.Entidades.Profesional prof = obtenerProfesionalDeString(profesional);
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Nombre", prof.Nombre));
            listParam.Add(new SqlParameter("@Apellido",prof.Apellido));
            listParam.Add(new SqlParameter("@Especialidad",especialidad));
            listParam.Add(new SqlParameter("@Fecha", fecha));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_HORARIOS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbHorariosDisp.Items.Add((DateTime)lector["Horarios"]);
                }
            }
        }
    }
}
