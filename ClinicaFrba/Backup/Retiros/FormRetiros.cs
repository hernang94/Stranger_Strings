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

namespace PagoElectronico.Retiros
{
    public partial class FormRetiros : Form
    {
        private Cliente cliente { get; set; }
        private List<Cuenta> cuentas { get; set; }
        private DAOEstadoCuenta daoEstado = new DAOEstadoCuenta();
        private DAOCliente daoCliente = new DAOCliente();
        private DAOCuenta daoCuenta = new DAOCuenta();
        private DAOCheque daoCheque = new DAOCheque();

        public FormRetiros(Cliente cli)
        {
            cliente = cli;
            cuentas = daoCuenta
                .retrieveByClientId(cliente.id)
                .FindAll(c =>
                    c.estado == daoEstado.habilitado().id &&
                    c.saldo > 0.0);
            InitializeComponent();
        }

        private void ValidarCuentas()
        {
            if (cuentas.Count() == 0) {
                MessageBox.Show("No posee cuentas habilitadas o ninguna tiene saldo. Esta ventana se cerrará");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRetiros_Load(object sender, EventArgs e)
        {
            cmbCuenta.DataSource = cuentas;
            cmbCuenta.DisplayMember = "Visualize";
            cmbCuenta.ValueMember = "id";

            if (cuentas.Count() != 0)
                lblSaldo.Text = cuentas[0].saldo.ToString();
            else {
                MessageBox.Show("No tiene cuentas habilitadas. Deposite dinero en alguna de sus cuentas y vuelva a intentarlo. Esta ventana se cerrará.");
                this.Close();
            }
            
        }

        private void txtRetirar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shared.UIUtils.aceptarSoloNumero(sender, e);
        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSaldo.Text = ((Cuenta)cmbCuenta.SelectedItem).saldo.ToString();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            // Verificar que lo ingresado sea correcto y parseable
            try
            {
                Double aRetirar = Convert.ToDouble(txtRetirar.Text);
                Double saldoActual = Convert.ToDouble(lblSaldo.Text);
                if (aRetirar > saldoActual)
                    MessageBox.Show("A retirar mayor a saldo actual!");
                else {
                    // Ingresar dni con el potencial cheque
                    IngresarDNI ingDNI = new IngresarDNI(cliente, (Cheque)CrearPotencialCheque());
                    ingDNI.ShowDialog(this);
                }
            }
            catch {
                MessageBox.Show("Saldo inválido. Ingrese un número");
                return;
            }
        }

        private object CrearPotencialCheque()
        {
            Cuenta cuentaSeleccionada = ((Cuenta)cmbCuenta.SelectedItem);
            Cheque cheque = new Cheque();
            cheque.cuenta_destino = cuentaSeleccionada.id;
            cheque.importe = Convert.ToDouble(txtRetirar.Text);
            cheque.retiro_fecha = Utils.fechaSistema;
            cheque.id_egreso = daoCheque.generarEgreso();
            cheque.tipo_moneda = cuentaSeleccionada.tipoMoneda;
            cheque.cod_banco = DAOBanco.generarBanco();
            return cheque;
        }

    }
}
