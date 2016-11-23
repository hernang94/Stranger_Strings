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
    public partial class DeshabilitarRol : Form
    {
        List<BD.Entidades.Rol> roles = new List<BD.Entidades.Rol>();
        Principal principal;
        public DeshabilitarRol(Principal principal)
        {
            this.principal = principal;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaParamAux = new List<SqlParameter>();
            listaParamAux.Add(new SqlParameter("@Rol", cbRoles.Text));
            SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
            paramRetAux.Direction = ParameterDirection.Output;
            listaParamAux.Add(paramRetAux);
            if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_ELIMINAR_ROL", listaParamAux) == 1)
            {
                MessageBox.Show("El Rol fue deshabilitado exitosamente", "Mensaje", MessageBoxButtons.OK);
                this.Close();
                principal.Show();

            }
            else
            {
                MessageBox.Show("Este Rol ya esta deshabilitado", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }

        private void DeshabilitarRol_Load(object sender, EventArgs e)
        {
            cargarRoles();
        }
        public void cargarRoles()
        {
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_ESPECIALIDADES_ABM_ROL", "SP", null);
            if(lector.HasRows)
            {
                while(lector.Read())
                {
                    BD.Entidades.Rol rol = new BD.Entidades.Rol();
                    rol.Nombre=(string)lector["Descripcion"];
                    rol.Estado=(string)lector["Estado"];

                    roles.Add(rol);
                }
            }
            for (int i=0;i<roles.Count;i++)
            {
                if (roles[i].Estado=="E"&& roles[i].Nombre!="Administrador General")
                {
                    cbRoles.Items.Add(roles[i].Nombre);
                }
            }

        }
    }
}