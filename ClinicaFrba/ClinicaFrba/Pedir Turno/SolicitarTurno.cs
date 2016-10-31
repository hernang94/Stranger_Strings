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
        public List<BD.Entidades.Profesional> profesionales = new List<BD.Entidades.Profesional>();
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
                BD.Entidades.Profesional prof = obtenerProfesionalDeString(cbProfesionales.Text);
                List<SqlParameter> listParam = new List<SqlParameter>();
                listParam.Add(new SqlParameter("@Fecha", cbFecha.Text+cbHorariosDisp.Text));
                listParam.Add(new SqlParameter("@Num_Doc_Paciente", int.Parse(fun.user.Nombre)));
                listParam.Add(new SqlParameter("@Nombre", prof.Dni));
                listParam.Add(new SqlParameter("@Especialidad_Descripcion", cbEspecialidad.SelectedItem));

                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_SOLICITAR_TURNO", "SP", listParam);
               
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
            cbEspecialidad.Items.Clear();
            obtenerYMostrarEspecialidades();
        }
 
        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProfesionales.Items.Clear();
            obtenerYMostrarProfesionales();
        }

        private void cbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFecha.Items.Clear();
            obtenerYMostrarFechas();
        }

        private void cbHorariosDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHorariosDisp.Items.Clear();
            obtenerYMostrarHorarios();
        }
       
        public void obtenerYMostrarEspecialidades()
        {
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_ESPECIALIDADES", "SP", null);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbEspecialidad.Items.Add((string)lector["Especialidad_Descripcion"]);
                }
            }
        }

        public void obtenerYMostrarProfesionales()
        {
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Especialidad_Descripcion", cbEspecialidad.SelectedItem));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_MEDICOS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Profesional prof = new BD.Entidades.Profesional();
                    prof.Nombre = (string)lector["Nombre"];
                    prof.Apellido = (string)lector["Apellido"];
                    prof.Dni = (decimal)lector["Num_Doc"];
                    cbProfesionales.Items.Add(prof.Nombre+" "+prof.Apellido);
                    profesionales.Add(prof);
                }
            }
        }

        public void obtenerYMostrarFechas()
        {
            BD.Entidades.Profesional prof= obtenerProfesionalDeString(cbProfesionales.Text);
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Num_Doc", prof.Dni));
            listParam.Add(new SqlParameter("@Especialidad_Descripcion", cbEspecialidad.SelectedItem));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FECHAS", "SP", listParam);
            List<decimal> dias = new List<decimal>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    dias.Add((decimal)lector["Dia"]);
                }
            }
            for (int i = 0; i < dias.Count(); i++)
            {
 
            }
        }

        public void obtenerYMostrarHorarios()
        {
            BD.Entidades.Profesional prof = obtenerProfesionalDeString(cbProfesionales.Text);
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Num_Doc", prof.Dni));
            listParam.Add(new SqlParameter("@Especialidad_Descripcion",cbEspecialidad.SelectedItem));
            listParam.Add(new SqlParameter("@Fecha", cbFecha.SelectedItem));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_HORARIOS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbHorariosDisp.Items.Add((DateTime)lector["Horarios"]);
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
            profNuevo.Apellido = profesional.Substring(i + 1, (profesional.Length - i-1));
            for (int j = 0; j < profesionales.Count(); j++)
            {
                if (profesionales[j].Apellido == profNuevo.Apellido && profesionales[j].Nombre == profNuevo.Nombre)
                {
                    return profesionales[j];
                }
            }
            return null;
        }
    }
}
