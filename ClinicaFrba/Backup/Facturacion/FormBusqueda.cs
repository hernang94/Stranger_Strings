using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoElectronico.Models.DataBase;
using PagoElectronico.Facturacion;

namespace PagoElectronico.Facturacion
{
    public partial class FormBusqueda : Form
    {

         public string user;
         public FormBusqueda(string usuario)
        {
            InitializeComponent();
            user = usuario;
            SqlConnection con1 = DBAcess.GetConnection();
            // CARGO EL COMBO BOX ITEMS
            string query = "SELECT descripcion FROM VIDA_ESTATICA.Items";
            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader lector1 = command.ExecuteReader();
            while (lector1.Read())
            {
                // Cargo la descripciones en la lista
                cbItems.Items.Add(lector1.GetString(0));
            }
            con1.Close();
        }
        private decimal getIdItem()
        {
            SqlConnection con = DBAcess.GetConnection();
            //OBTENGO ID ITEM
            if (cbItems.SelectedItem!=null)
            {

                string query = "SELECT id_item FROM VIDA_ESTATICA.Items WHERE descripcion = '" + cbItems.SelectedItem.ToString() + "'";
                SqlCommand command = new SqlCommand(query, con);
                decimal id_item = Convert.ToDecimal(command.ExecuteScalar());
                con.Close();
                return id_item;
            }
            return -1;
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void FormBusqueda_Load(object sender, EventArgs e)
        {

        }

        private void btTodosPendientes_Click(object sender, EventArgs e)
        {
            FormFacturacion formF = new FormFacturacion(0, user);
            formF.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            decimal id_item = getIdItem();
            if (cbItems.Text == "")
            {
                MessageBox.Show("Ingrese un tipo de item pendiente");
            }
            else
            {
                FormFacturacion formF = new FormFacturacion(id_item, user);
                formF.Show();
                this.Close();
            }
        }

        private void cbItems_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        
      

    }
}
