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

namespace PagoElectronico.Shared
{
    public partial class BuscadorCliente : Form
    {
        private List<Cliente> clientes;
        private DAOCliente daoCliente;
        private Cliente clienteSeleccionado;

        public BuscadorCliente()
        {
            InitializeComponent();
            clientes = new List<Cliente>();
            daoCliente = new DAOCliente();
            cargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clientes = daoCliente
                .retrieveByInfo(tbNroCli.Text, tbNumeroDoc.Text, tbNombre.Text, tbApellido.Text);
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Documento");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");

            DataRow newRow;

            foreach (Cliente cli in clientes)
            {
                newRow = table.NewRow();
                newRow["ID"] = cli.id;
                newRow["Documento"] = cli.documento;
                newRow["Nombre"] = cli.nombre;
                newRow["Apellido"] = cli.apellido;

                table.Rows.Add(newRow);
            }

            grillaClientes.DataSource = table;
            grillaClientes.Columns["ID"].Width = 40;
        }

        private void tbNroCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIUtils.aceptarSoloNumero(sender, e);
        }

        private void tbNumeroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIUtils.aceptarSoloNumero(sender, e);
        }

        public Cliente getCliente()
        {
            return clienteSeleccionado;
        }

        private void grillaClientes_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            try
            {
                row = grillaClientes.Rows[grillaClientes.SelectedCells[0].RowIndex];
            }
            catch (Exception exp)
            {
                MessageBox.Show("No hay ningun cliente en ese lugar" + exp.ToString());
                return;
            }
            string selectedID = row.Cells["ID"].Value.ToString();
            if (String.IsNullOrEmpty(selectedID))
            {
                MessageBox.Show("No hay ningun cliente seleccionado");
            }
            else
            {
                clienteSeleccionado = daoCliente.retrieveBy_id(Int32.Parse(selectedID));
                this.Close();
            }
        }

    }
}
