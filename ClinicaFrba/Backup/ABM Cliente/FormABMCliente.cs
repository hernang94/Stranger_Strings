using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.DAO;
using PagoElectronico.Models.Utils;

namespace PagoElectronico.ABM_Cliente
{
    public partial class FormABMCliente : Form
    {
        public FormABMCliente()
        {
            InitializeComponent();
            lstClientes = new List<Cliente>();
            dao = new DAOCliente();
            lstTipos = new List<TipoDocumento>();
            
        }

        private DAOCliente dao;
        private List<Cliente> lstClientes { get; set; }
        private List<TipoDocumento> lstTipos;

        private void frmABMCliente_Load(object sender, EventArgs e)
        {
            lstTipos = TipoDocumento.ObtenerTiposDocumento();

            if (lstTipos.Count > 0)
            {
                cmbTipoID.Visible = true;
                cmbTipoID.DataSource = lstTipos;
                cmbTipoID.DisplayMember = "descripcion";
                cmbTipoID.ValueMember = "id";
                cmbTipoID.SelectedIndex = -1;

            }

            dtgCliente.AutoGenerateColumns = false;
            dtgCliente.MultiSelect = false;

            cargarGrilla();
            actualizarGrilla();
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNumID.Text = "";
            txtEmail.Text = "";
            actualizarGrilla();
        }

        private void txtNumID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utils.isCaracterInvalido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FormAltaCliente ac = new FormAltaCliente(new Cliente());
            ac.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente clien = (Cliente)dtgCliente.CurrentRow.DataBoundItem;
            FormAltaCliente fac = new FormAltaCliente(clien);
            fac.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { actualizarGrilla(); }
            catch { MessageBox.Show("No existe cliente con esas caracteristicas", "Error!", MessageBoxButtons.OK); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente delete = (Cliente)dtgCliente.CurrentRow.DataBoundItem;
            dao.delete((int)(decimal)delete.id);
            actualizarGrilla(); 
        }

        private void cargarGrilla()
        {
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 120;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 120;
            DataGridViewTextBoxColumn colMail = new DataGridViewTextBoxColumn();
            colMail.DataPropertyName = "mail";
            colMail.HeaderText = "Email";
            colMail.Width = 120;
            DataGridViewTextBoxColumn colDoc= new DataGridViewTextBoxColumn();
            colDoc.DataPropertyName = "documento";
            colDoc.HeaderText = "Numero Documento";
            colDoc.Width = 120;

            dtgCliente.Columns.Add(colNombre);
            dtgCliente.Columns.Add(colApellido);
            dtgCliente.Columns.Add(colMail);
            dtgCliente.Columns.Add(colDoc);
        }

        public void actualizarGrilla()
        {
            if (txtNombre.Text != "" || txtApellido.Text != "" || txtNumID.Text != "" || txtEmail.Text != "")
                lstClientes = dao.search(txtNombre.Text, txtApellido.Text, cmbTipoID.SelectedText, txtNumID.Text, txtEmail.Text);
            else
                lstClientes = dao.retrieveAll();
            Cliente client = new Cliente();
            client = lstClientes[0];
            dtgCliente.DataSource = lstClientes;
        }


        private void cmbTipoID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
