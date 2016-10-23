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
                    if (txtUsuario.Text == "admin" && txtContraseña.Text == "123")
                    {

                        //Encontro usuario? ------------------------------------------------------------
                        if (user.Nombre != null)
                        {
                            // Pass hashing
                            UTF8Encoding encoderHash = new UTF8Encoding();
                            SHA256Managed hasher = new SHA256Managed();
                            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtContraseña.Text));
                            string pass = bytesDeHasheoToString(bytesDeHasheo);

                            if (!user.Contrasena.Equals(pass))
                            {
                                //Descontar Cantidad_Intentos--------------------------------------------
                                user.DescontarIntento();
                                MessageBox.Show("Usuario y contraseña no validos", "Error!", MessageBoxButtons.OK);
                                txtContraseña.Text = "";
                            }
                            else
                            {
                                // Está activo?
                                if (user.Cantidad_Intentos == 0)
                                    MessageBox.Show("Usuario inactivo para acceder al sistema", "Error!", MessageBoxButtons.OK);
                                else
                                {

                                    user.ReiniciarCantidadIntentos();

                                    // Pasa al form Funcionalidades ------------------------------------
                                    Funcionalidades fmFuncionalidades = new Funcionalidades(user);
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
            }
            catch
            {
                MessageBox.Show("Usuario y contraseña no validos", "Error!", MessageBoxButtons.OK);
                txtContraseña.Text = "";
            }
        }
        // Transformar lo hasheado a string
        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
                salida.Append(array[i].ToString("X2"));
            return salida.ToString();
        }
    }
}
