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
    public partial class ModificarRol : Form
    {
        List<BD.Entidades.Rol> roles = new List<BD.Entidades.Rol>();
        Principal principal;
        public ModificarRol(Principal principal)
        {
            this.principal = principal;
            InitializeComponent();
            cargarRoles();
        }
        public void cargarRoles()
        {
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_ESPECIALIDADES_ABM_ROL", "SP", null);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Rol rol = new BD.Entidades.Rol();
                    rol.Nombre = (string)lector["Descripcion"];
                    rol.Estado = (string)lector["Estado"];

                    roles.Add(rol);
                }
            }
            for (int i = 0; i < roles.Count; i++)
            {
                if (roles[i].Nombre != "Administrador")
                {
                    comboBox1.Items.Add(roles[i].Nombre);
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txNombre.Text == " ")
            {
                AgregarFuncionalidad agregar = new AgregarFuncionalidad(this,comboBox1.Text);
                agregar.Show();
                this.Hide();
            }
            else
            {
                AgregarFuncionalidad agregar = new AgregarFuncionalidad(this,txNombre.Text);
                agregar.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txNombre.Text == " ")
            {
                EliminarFuncionalidad eliminar = new EliminarFuncionalidad(this, comboBox1.Text);
                eliminar.Show();
                this.Hide();
            }
            else
            {
                EliminarFuncionalidad eliminar = new EliminarFuncionalidad(this, txNombre.Text);
                eliminar.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             List<SqlParameter> listaParamAux = new List<SqlParameter>();
             listaParamAux.Add(new SqlParameter("@Nombre", txNombre.Text));
             listaParamAux.Add(new SqlParameter("@Rol_Descripcion", comboBox1.Text));
             BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_MODIFICAR_NOMBRE_ROL", "SP", listaParamAux);
             MessageBox.Show("El nombre ha sido modificado existosamente", "Mensaje", MessageBoxButtons.OK);
             roles.Clear();
             comboBox1.Items.Clear();
             comboBox1.Text = txNombre.Text;
             cargarRoles();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
