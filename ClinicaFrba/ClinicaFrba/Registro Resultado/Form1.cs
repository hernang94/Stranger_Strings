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
    public partial class Form1 : Form
    {
        public Funcionalidades fun;
        public string Especialidad;
        public string fecha;

        public Form1(Funcionalidades fun, string esp, string fecha)
        {
            this.fecha = fecha;
            this.Especialidad = esp;
            this.fun = fun;
            InitializeComponent();
            dtFechaHora.Format = DateTimePickerFormat.Time;
        
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            fun.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerTurnos();
        }

        public void obtenerTurnos()
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_doc", int.Parse(fun.user.Nombre)));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_TURNOS", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Especialidad esp = new BD.Entidades.Especialidad();
                    esp.Especialidad_Descr = (string)lector["Especialidad_Descripcion"];

                    //this.especXmedico.Add(esp);
                }
            }
        }
    }
}
    