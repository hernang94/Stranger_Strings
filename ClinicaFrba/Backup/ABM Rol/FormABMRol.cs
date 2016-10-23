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

namespace PagoElectronico.ABM_Rol
{
    public partial class FormABMRol : Form
    {
        public FormABMRol()
        {
            InitializeComponent();
        }
        private DAORol dao = new DAORol();
        private List<Rol> lstRoles { get; set; }
        public string operacion { get; set; }

        private void frmABMRol_Load(object sender, EventArgs e)
        {
            dtgRol.AutoGenerateColumns = false;
            dtgRol.MultiSelect = false;

            cargarGrilla();
            actualizarGrilla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkActivo.Checked = true;
            txtNombre.Text = "";
            actualizarGrilla();
        }

        public void actualizarGrilla()
        {
            // TODO: Evaluar las combinaciones y popular la grid
            if (txtNombre.Text != "")
                lstRoles = dao.retrieve(txtNombre.Text, chkActivo.Checked);
            else
                lstRoles = dao.retrieveAll();
            dtgRol.DataSource = lstRoles;
        }

        private void cargarGrilla()
        {
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre Rol";
            colNombre.Width = 120;
            DataGridViewTextBoxColumn colActivo = new DataGridViewTextBoxColumn();
            colActivo.DataPropertyName = "Activo";
            colActivo.HeaderText = "Activo?";
            colActivo.Width = 120;

            dtgRol.Columns.Add(colNombre);
            dtgRol.Columns.Add(colActivo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { actualizarGrilla(); }
            catch { MessageBox.Show("No existe rol con esas caracteristicas", "Error!", MessageBoxButtons.OK); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Rol delete = (Rol)dtgRol.CurrentRow.DataBoundItem;
            if (Funcionalidad.DependeDe((int)delete.id).Count > 0)
                MessageBox.Show("No puede eliminarse el rol por estar asociado a una funcionalidad");
            else { 
                if(dao.delete((int)(decimal)delete.id))
                    MessageBox.Show("Rol seteado a inactivo correctamente");
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaRol ar = new AltaRol(new Rol());
            ar.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Rol rol = (Rol)dtgRol.CurrentRow.DataBoundItem;
            AltaRol ar = new AltaRol(rol);
            ar.Show();
        }


    }
}
