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
        public List<BD.Entidades.Especialidad> especialidades = new List<BD.Entidades.Especialidad>();
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
            obtenerYMostrarProfesionales();
        }
 
        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProfesionales.Items.Clear();
            obtenerYMostrarFechas();
        }

        private void cbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFecha.Items.Clear();
            obtenerYMostrarEspecialidades();
        }

        private void cbFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHorariosDisp.Items.Clear();
            obtenerYMostrarHorarios();
        }
       
        public void obtenerYMostrarEspecialidades()
        {
            BD.Entidades.Profesional profElegido = new BD.Entidades.Profesional();
            profElegido = obtenerProfesionalDeString(cbProfesionales.SelectedItem.ToString());

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
                    cbProfesionales.Items.Add(prof.Nombre+" "+prof.Apellido);
                    profesionales.Add(prof);
                }
            }
        }

        public void obtenerYMostrarFechas()
        {
            BD.Entidades.Profesional prof= obtenerProfesionalDeString(cbProfesionales.Text);
            decimal codigo = obtenerCodigoEspecialidad();

            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Num_Doc", prof.Dni));
            listParam.Add(new SqlParameter("@Especialidad_Codigo", codigo));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FECHAS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbFecha.Items.Add((DateTime)lector["Turno_Fecha"]);
}
            }
        }

        public void obtenerYMostrarHorarios()
        {
            BD.Entidades.Profesional prof = obtenerProfesionalDeString(cbProfesionales.Text);
            decimal codigo = obtenerCodigoEspecialidad();

            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@Num_Doc", prof.Dni));
            listParam.Add(new SqlParameter("@Especialidad_Codigo",codigo));
            listParam.Add(new SqlParameter("@Turno_Fecha", cbFecha.SelectedItem));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_HORARIOS", "SP", listParam);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cbHorariosDisp.Items.Add((DateTime)lector["Turno_Fecha"]);
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

        public decimal obtenerCodigoEspecialidad()
        { 
            return especialidades[cbEspecialidad.SelectedIndex].Especialidad_Cod;
        }
    }
}