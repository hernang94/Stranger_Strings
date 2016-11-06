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
    public partial class HabilitarRol : Form
    {
        
        List<BD.Entidades.Rol> roles = new List<BD.Entidades.Rol>();
        Principal principal;
        public HabilitarRol(Principal principal)
        {
            this.principal = principal;
            InitializeComponent();
            cargarRoles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaParamAux = new List<SqlParameter>();
            listaParamAux.Add(new SqlParameter("@Rol", comboBox1.Text));
            BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_HABILITAR_ROL", listaParamAux);
            {
                MessageBox.Show("El Rol fue habilitado exitosamente", "Mensaje", MessageBoxButtons.OK);
                this.Close();
                principal.Show();

           
             }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
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
                if (roles[i].Estado == "D" && roles[i].Nombre != "Administrador")
                {
                    comboBox1.Items.Add(roles[i].Nombre);
                }
            }
        }

        private void HabilitarRol_Load(object sender, EventArgs e)
        {

        }
    }
}
