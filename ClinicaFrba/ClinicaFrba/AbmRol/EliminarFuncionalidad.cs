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

namespace ClinicaFrba.AbmRol
{
    public partial class EliminarFuncionalidad : Form
    {
        string nombre;
        List<string> funcionalidades = new List<string>();
        ModificarRol principal;
        public EliminarFuncionalidad(ModificarRol principal,string nombre)
        {
            this.nombre = nombre;
            this.principal = principal;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaParamAux = new List<SqlParameter>();
            listaParamAux.Add(new SqlParameter("@Rol", nombre));
            listaParamAux.Add(new SqlParameter("@Funcionalidad_Descripcion", comboBox1.Text));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_ELIMINAR_FUNCIONALIDAD_ROL", "SP", listaParamAux);
            MessageBox.Show("La funcionalidad fue eliminada exitosamente, puede eliminar más", "Mensaje", MessageBoxButtons.OK);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }

        private void EliminarFuncionalidad_Load(object sender, EventArgs e)
        {

            cargarFuncionalidades();
        }
        public void cargarFuncionalidades()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@Rol", nombre));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FUNCIONALIDADES_DEL_ROL", "SP", lista);
            if (lector.HasRows)
            {
                while (lector.Read())
                {

                    funcionalidades.Add((string)lector["Descripcion"]);
                }
            }
            for (int i = 0; i < funcionalidades.Count; i++)
            {

                comboBox1.Items.Add(funcionalidades[i]);
            }

        }
    }
}
