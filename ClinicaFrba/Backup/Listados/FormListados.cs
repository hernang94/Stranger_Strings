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
using PagoElectronico.Models.BO;
using PagoElectronico.Models.DAO;

namespace PagoElectronico.Listados
{
    public partial class FormListados : Form
    {
        DAOCliente daoCl = new DAOCliente();
        DAOPais daoP = new DAOPais();
        DAOTipoCuenta daoTc = new DAOTipoCuenta();
        List<Cliente> listaClientes = new List<Cliente>();
        List<Pais> listaPaises = new List<Pais>();
        List<TipoCuenta> listaTiposCuentas = new List<TipoCuenta>();

        public FormListados()
        {
            InitializeComponent();

            dgResult.AllowUserToAddRows = false;
            dgResult.AllowUserToDeleteRows = false;
            dgResult.ReadOnly = true;
        }

        private void FormListados_Load(object sender, EventArgs e)
        {
            for (int i = 2020; i >= 2010; i--)
            {
                cbAnio.Items.Add(i);
            }
            for (int i = 1; i < 5; i++)
            {
                cbTrimestre.Items.Add(i);
            }

            cbListado.Items.Add("Clientes con cuentas inhabilitadas por no pago");
            cbListado.Items.Add("Cliente con mayor cantidad de comisiones facturadas en sus cuentas");
            cbListado.Items.Add("Clientes con mayor cantidad de transacciones entre sus cuentas");
            cbListado.Items.Add("Paises con mayor cantidad de movimientos");
            cbListado.Items.Add("Total facturado para los distintos tipos de cuentas");

            dgResult.AutoGenerateColumns = false;
            dgResult.MultiSelect = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            limpiarGrilla();

            if (cbListado.SelectedIndex < 0 || cbAnio.SelectedIndex < 0 || cbTrimestre.SelectedIndex < 0) {
                MessageBox.Show("Seleccione todos los campos para realizar la busqueda");
                return;
            }

            int ano = (int)cbAnio.SelectedItem;
            int trimestre = (int)cbTrimestre.SelectedItem;
            switch (cbListado.SelectedIndex)
            {
                case 0:
                    clientesConCuentasSinPagar(ano, trimestre);
                    break;
                case 1:
                    clientesConMasComisionesEntreCuentas(ano, trimestre);
                    break;
                case 2:
                    clientesConMasTransaccionesEntreSusCuentas(ano, trimestre);
                    break;
                case 3:
                    PaisesConMasMovimientos(ano, trimestre);
                    break;
                case 4:
                    TotalFacturadoTiposDeCuentas(ano, trimestre);
                    break;
                default:
                    MessageBox.Show("Listado no reconocido");
                    break;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbAnio.SelectedIndex = -1;
            cbListado.SelectedIndex = -1;
            cbTrimestre.SelectedIndex = -1;
            limpiarGrilla();            
        }

        private void limpiarGrilla()
        {
            dgResult.Columns.Clear();
            dgResult.DataSource = null;
        }

        private int minimoMesTrimestre(int trimestre)
        {
            switch (trimestre)
            {
                case 1: return 1;
                case 2: return 4;
                case 3: return 7;
                case 4: return 10;
                default: return -1;
            }
        }

        private int maximoMesTrimestre(int trimestre)
        {
            switch (trimestre)
            {
                case 1: return 3;
                case 2: return 6;
                case 3: return 9;
                case 4: return 12;
                default: return -1;
            }
        }

        private void cargarGrillaFormatoCliente()
        {
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 90;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 90;
            DataGridViewTextBoxColumn colMail = new DataGridViewTextBoxColumn();
            colMail.DataPropertyName = "mail";
            colMail.HeaderText = "Email";
            colMail.Width = 100;
            DataGridViewTextBoxColumn colDoc = new DataGridViewTextBoxColumn();
            colDoc.DataPropertyName = "documento";
            colDoc.HeaderText = "Documento";
            colDoc.Width = 90;

            dgResult.Columns.Add(colNombre);
            dgResult.Columns.Add(colApellido);
            dgResult.Columns.Add(colMail);
            dgResult.Columns.Add(colDoc);
        }

        private void cargarGrillaFormatoPais()
        {
            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.DataPropertyName = "descripcion";
            colDescripcion.HeaderText = "Pais";
            colDescripcion.Width = 120;
            DataGridViewTextBoxColumn colMovimientos = new DataGridViewTextBoxColumn();
            colMovimientos.DataPropertyName = "movimiento";
            colMovimientos.HeaderText = "Movimientos";
            colMovimientos.Width = 120;

            dgResult.Columns.Add(colDescripcion);
            dgResult.Columns.Add(colMovimientos);
        }

        private void cargarGrillaFormatoCuenta()
        {
            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.DataPropertyName = "descripcion";
            colDescripcion.HeaderText = "Tipo Cuenta";
            colDescripcion.Width = 120;
            DataGridViewTextBoxColumn colMonto = new DataGridViewTextBoxColumn();
            colMonto.DataPropertyName = "monto";
            colMonto.HeaderText = "Monto";
            colMonto.Width = 120;

            dgResult.Columns.Add(colDescripcion);
            dgResult.Columns.Add(colMonto);
        }

        public void asociarCamposCompletosCliente()
        {
            Cliente client = new Cliente();
            List<Cliente> lstC = new List<Cliente>();
            if (listaClientes.Count != 0)
            {
                foreach (Cliente c in listaClientes)
                {
                    lstC.Add(daoCl.retrieveBy_id(c.id));
                }
                listaClientes = lstC;
                client = listaClientes[0];
            }
            else
            {
                return;
            }
        }


        public void clientesConCuentasSinPagar(int ano, int trimestre) 
        {
            cargarGrillaFormatoCliente();
            try { listaClientes = daoCl.topInhabilitados(ano, minimoMesTrimestre(trimestre), maximoMesTrimestre(trimestre)); }
            catch { MessageBox.Show("No existe cliente con esas caracteristicas", "Error!", MessageBoxButtons.OK); }
            
            asociarCamposCompletosCliente();
            
            dgResult.DataSource = listaClientes;
        }

        public void clientesConMasComisionesEntreCuentas(int ano, int trimestre)
        {
            cargarGrillaFormatoCliente();
            try { listaClientes = daoCl.topFacturadores(ano, minimoMesTrimestre(trimestre), maximoMesTrimestre(trimestre)); }
            catch { MessageBox.Show("No existe cliente con esas caracteristicas", "Error!", MessageBoxButtons.OK); }

            asociarCamposCompletosCliente();

            dgResult.DataSource = listaClientes;
        }

        public void clientesConMasTransaccionesEntreSusCuentas(int ano, int trimestre)
        {
            cargarGrillaFormatoCliente();
            try { listaClientes = daoCl.topTransaccionales(ano, minimoMesTrimestre(trimestre), maximoMesTrimestre(trimestre)); }
            catch { MessageBox.Show("No existe cliente con esas caracteristicas", "Error!", MessageBoxButtons.OK); }

            asociarCamposCompletosCliente();

            dgResult.DataSource = listaClientes;
        }

        public void PaisesConMasMovimientos(int ano, int trimestre)
        {
            cargarGrillaFormatoPais();

            try { listaPaises = daoP.topMovimientos(ano, minimoMesTrimestre(trimestre), maximoMesTrimestre(trimestre)); }
            catch { MessageBox.Show("No existe pais con esas caracteristicas", "Error!", MessageBoxButtons.OK); }

            dgResult.DataSource = listaPaises;
        }

        public void TotalFacturadoTiposDeCuentas(int ano, int trimestre)
        {
            cargarGrillaFormatoCuenta();

            try { listaTiposCuentas = daoTc.topFacturadores(ano, minimoMesTrimestre(trimestre), maximoMesTrimestre(trimestre)); }
            catch { MessageBox.Show("No existen cuentas con esas caracteristicas", "Error!", MessageBoxButtons.OK); }

            dgResult.DataSource = listaTiposCuentas;
        }
    }
}
