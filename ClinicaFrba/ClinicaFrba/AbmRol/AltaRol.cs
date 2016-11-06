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
    public partial class AltaRol : Form
    {
        Principal principal;
        List<string> funcionalidades = new List<string>();
        public AltaRol(Principal principal)
        {
            this.principal = principal;
            InitializeComponent();
            cargarFuncionalidades();
        }

        public void cargarFuncionalidades()
        {
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_FUNCIONALIDADES", "SP", null);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    funcionalidades.Add((string)lector["Descripcion"]);
                }

            }
            ((ListBox)ckListaFuncionalidades).DataSource = funcionalidades;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaParamAux = new List<SqlParameter>();
            listaParamAux.Add(new SqlParameter("@Rol", txtRol.Text));
            SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRetAux.Direction = ParameterDirection.Output;
            listaParamAux.Add(paramRetAux);
            if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_AGREGAR_ROL", listaParamAux) == 1)
            {
                MessageBox.Show("El Rol fue creado exitosamente", "Mensaje", MessageBoxButtons.OK);
                agregarFuncionalidades();
                this.Close();
                principal.Show();

            }
            else
            {
                MessageBox.Show("Este Rol ya existe", "Error", MessageBoxButtons.OK);
            }

        }
        public void agregarFuncionalidades()
        {
            foreach (string descripcion in ckListaFuncionalidades.CheckedItems)
            {
                List<SqlParameter> listaParamAux = new List<SqlParameter>();
                listaParamAux.Add(new SqlParameter("@Rol", txtRol.Text));
                listaParamAux.Add(new SqlParameter("@Funcionalidad_Descripcion", descripcion));
                SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
                paramRetAux.Direction = ParameterDirection.Output;
                listaParamAux.Add(paramRetAux);
                if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_AGREGAR_FUNCIONALIDAD_ROL", listaParamAux) == 0)
                {
                    MessageBox.Show("Selecciono una funcionalidad existente", "Error", MessageBoxButtons.OK);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ckListaFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
