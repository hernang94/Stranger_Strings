using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ClinicaFrba.BD;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btIniciarSesión_Click(object sender, EventArgs e)
        {
           try
            {
                if (txtUsuario.Text != "" && txtContraseña.Text != "")
                {
                    Usuario user = new Usuario(txtUsuario.Text);
                    List<SqlParameter> paramlist = new List<SqlParameter>();
                    paramlist.Add(new SqlParameter("@Usuario", txtUsuario.Text));
                    paramlist.Add(new SqlParameter("@Pass", txtContraseña.Text));
                    SqlParameter paramRetAux = new SqlParameter("@Retorno", SqlDbType.Int);
                    paramRetAux.Direction = ParameterDirection.Output;
                    paramlist.Add(paramRetAux);
                    //Encontro usuario? ------------------------------------------------------------
                    if (user.Apellido != null)
                    {
                        if (BDStranger_Strings.ExecStoredProcedure("STRANGER_STRINGS.SP_LOGIN",paramlist)==0)
                        {
                            //Descontar Cantidad_Intentos--------------------------------------------
                            user.DescontarIntento();
                            lbContraseñaIncorrecta.Visible = true;
                            txtContraseña.Text = "";
                            
                            if (user.Cantidad_Intentos == 0)
                            {
                                MessageBox.Show("Usuario inactivo para acceder al sistema", "Error!", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            // Está activo?
                            if (user.Cantidad_Intentos <= 0)
                                MessageBox.Show("Usuario inactivo para acceder al sistema", "Error!", MessageBoxButtons.OK);
                            else
                            {
                                user.Dni = txtContraseña.Text;
                                user.ReiniciarCantidadIntentos(txtContraseña.Text);
                                List<SqlParameter> paramlistaux = new List<SqlParameter>();
                                paramlistaux.Add(new SqlParameter("@Usuario", user.Apellido));
                                paramlistaux.Add(new SqlParameter("@Pass", user.Dni));
                                SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_GET_ROLES", "SP", paramlistaux);

                                List<BD.Entidades.Rol> rolesXusario = new List<BD.Entidades.Rol>();
                                obtenerRoles(lector, rolesXusario);
                                
                                // Pasa al form Funcionalidades ------------------------------------
                                Funcionalidades fmFuncionalidades = new Funcionalidades(user,rolesXusario);
                                this.Hide();
                                fmFuncionalidades.Show();
                            }

                        }
                    }
                    else
                    {
                        lbContraseñaIncorrecta.Visible = true;
                        txtContraseña.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Complete todos los campos", "Error!", MessageBoxButtons.OK);
                }
             }

            catch
            {
                MessageBox.Show("Ups, ha ocurrido un problema", "Error!", MessageBoxButtons.OK);
                txtContraseña.Text = "";
            }
        }

        public void obtenerRoles(SqlDataReader lector, List<BD.Entidades.Rol> rolesXusuario)
        {
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Rol rol = new BD.Entidades.Rol();
                    rol.Nombre=((string)lector["Descripcion"]);
                    rolesXusuario.Add(rol);
                }
            }
        }
        
        // Transformar lo hasheado a string
        public string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
                salida.Append(array[i].ToString("X2"));
            return salida.ToString();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
