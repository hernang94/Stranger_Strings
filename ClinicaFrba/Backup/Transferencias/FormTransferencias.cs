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

namespace PagoElectronico.Transferencias
{
    public partial class FormTransferencias : Form
    {
        private Cliente cliente { get; set; }
        private List<Cuenta> cuentas { get; set; }
        private List<Moneda> monedas = new DAOMoneda().retrieveBase();
        private DAOCuenta daoCuenta = new DAOCuenta();
        private DAOEstadoCuenta daoEstado = new DAOEstadoCuenta();
        private DAOBanco daoBanco = new DAOBanco();
        private DAOTransferencia daoTransferencia = new DAOTransferencia();

        public FormTransferencias(Cliente cli)
        {
            cliente = cli;
            cuentas = daoCuenta
                .retrieveByClientId(cliente.id)
                .FindAll(c =>
                    c.estado == daoEstado.habilitado().id &&
                    c.saldo > 0.0);
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTransferencias_Load(object sender, EventArgs e)
        {
            cmbMoneda.DataSource = monedas;
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "id";

            if (cuentas.Count() == 0)
            {
                MessageBox.Show("No posee cuentas habilitadas o con saldo disponible. Esta ventana se cerrará.");
                this.Close();
            }
            else
            {
                cmbCuentaOrigen.DataSource = cuentas;
                cmbCuentaOrigen.ValueMember = "id";
                cmbCuentaOrigen.DisplayMember = "Visualize";
            }

        }

        private void cmbCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSaldo.Text = ((Cuenta)cmbCuentaOrigen.SelectedItem).saldo.ToString();
        }

        private void txtCuentaDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shared.UIUtils.aceptarSoloNumero(sender, e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shared.UIUtils.aceptarSoloNumero(sender, e);
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                Double saldo = Convert.ToDouble(lblSaldo.Text);
                Double aRetirar = Convert.ToDouble(txtImporte.Text);
                if (aRetirar > saldo)
                {
                    MessageBox.Show("A retirar mayor a saldo actual!");
                }
                else {
                   Cuenta destino = daoCuenta
                   .retrieveBy_Numero(
                   Convert.ToInt64(txtCuentaDestino.Text));
                   if (daoTransferencia.create(CreateTransferencia(destino)).importe == aRetirar) {
                       MessageBox.Show("Transferencia exitosa! Consulte su saldo para ver los cambios");
                   } 
                }
            }
            catch
            {
                MessageBox.Show("La cuenta destino no existe!");
            }
        }

        private Transferencia CreateTransferencia(Cuenta destino)
        {
            Transferencia trans = new Transferencia();
            trans.tipo_moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            trans.fecha = Utils.fechaSistema;
            trans.cuenta_origen = Convert.ToInt64(cmbCuentaOrigen.SelectedValue);
            trans.cuenta_destino = (long)destino.id;
            trans.costo = (destino.codigoCliente == cliente.id) ? 0 :new DAOTipoCuenta().costo_transaccion(Convert.ToInt64(cmbCuentaOrigen.SelectedValue));
            trans.importe = Convert.ToDouble(txtImporte.Text);
            return trans;
        }
    }
}
