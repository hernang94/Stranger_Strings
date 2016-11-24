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
    public partial class AgregarFuncionalidad : Form
    {
        ModificarRol principal;
        string nombre;
        List<string> funcionalidades = new List<string>();
        public AgregarFuncionalidad(ModificarRol principal,string nombre)
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
            SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRetAux.Direction = ParameterDirection.Output;
            listaParamAux.Add(paramRetAux);
            if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_AGREGAR_FUNCIONALIDAD_ROL", listaParamAux) == 1)
            {
                MessageBox.Show("Esta funcionalidad ha sido agregada exitosamente, puede agregar más", "Mensaje", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Esta funcionalidad ya se encontro", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }

        private void AgregarFuncionalidad_Load(object sender, EventArgs e)
        {
            cargarFuncionalidades();
        }
        public void cargarFuncionalidades()
        {
            List<string> funcionalidadesPropias = new List<string>();
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@Rol", nombre));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FUNCIONALIDADES_DEL_ROL", "SP", lista);
            if (lector.HasRows)
            {
                while (lector.Read())
                {

                    funcionalidadesPropias.Add((string)lector["Descripcion"]);
                }
            }
            SqlDataReader lector2 = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FUNCIONALIDADES", "SP", null);
            if (lector2.HasRows)
            {
                while (lector2.Read())
                {

                    funcionalidades.Add((string)lector2["Descripcion"]);
                }
            }
            for (int i = 0; i < funcionalidades.Count; i++)
            {
                if( !funcionalidadesPropias.Contains(funcionalidades[i]))
                {
                    comboBox1.Items.Add(funcionalidades[i]);

                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
