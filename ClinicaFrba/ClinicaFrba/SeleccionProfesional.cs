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

namespace ClinicaFrba
{
    public partial class SeleccionProfesional : Form
    {
        public Funcionalidades fun;
        public Funcionalidades funFake;
        public string tipo;
        public List<BD.Entidades.Profesional> profesionales = new List<BD.Entidades.Profesional>();
        public List<BD.Entidades.Especialidad> espXmedico = new List<BD.Entidades.Especialidad>();
        BD.Usuario user = new BD.Usuario();


        public SeleccionProfesional(string tipo, Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
            this.tipo = tipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fun.Show();
            this.Close();
        }

        private void SeleccionProfesional_Load(object sender, EventArgs e)
        {
            obtenerYMostrarProfesionales();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            BD.Entidades.Profesional profesional = new BD.Entidades.Profesional();
            profesional = obtenerProfesionalDeString(cbProfesionales.Text);

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Nombre", profesional.Nombre));
            paramlist.Add(new SqlParameter("@Apellido", profesional.Apellido));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_PROFESIONAL", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    user.Apellido = (string)lector["Usuario"];
                    user.Dni = ((decimal)lector["Num_Doc"]).ToString();
                    user.Cantidad_Intentos = (Int16)lector["Cantidad_Intentos"];
                }
            }

            funFake = new Funcionalidades(user);

            if (this.tipo == "seleccion_Especialidad")
            {
                this.pedir_Especilidades_Profesional();
                Registro_Resultado.SeleccionEspecialidad seleccion_Especialidad = new Registro_Resultado.SeleccionEspecialidad(this.fun, this.funFake, this.espXmedico);

                seleccion_Especialidad.Show();
                this.Hide();
            }
            if (this.tipo == "cancelar_Atencion_Medico")
            {
                Cancelar_Atencion.CancelarAtencionMedico cancelar_Atencion_Medico = new Cancelar_Atencion.CancelarAtencionMedico(this.fun, this.funFake);

                cancelar_Atencion_Medico.Show();
                this.Hide();
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
                    cbProfesionales.Items.Add(prof.Nombre + " " + prof.Apellido);
                    profesionales.Add(prof);
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

        private void pedir_Especilidades_Profesional()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_doc", int.Parse(user.Dni)));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_ESPECIALIDADES", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Especialidad esp = new BD.Entidades.Especialidad();
                    esp.Especialidad_Descr = (string)lector["Especialidad_Descripcion"];
                    esp.Especialidad_Cod = (decimal)lector["Especialidad_Codigo"];
                    this.espXmedico.Add(esp);
                }
            }
        }
    }
}
