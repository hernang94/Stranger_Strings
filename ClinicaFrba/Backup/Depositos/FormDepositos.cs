using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Models.Utils;
using PagoElectronico.Models.BO;
using PagoElectronico.Models.DAO;

namespace PagoElectronico.Depositos
{
    public partial class FormDepositos : Form
    {
        private Cliente cliente { get; set; }
        private double importe { get; set; }
        private List<Cuenta> cuentas { get; set; }
        private List<Moneda> monedas { get; set; }
        private List<Tarjeta> tarjetas { get; set; }
        private DAOTarjeta daoTarjeta = new DAOTarjeta();
        private DAOCuenta daoCuenta = new DAOCuenta();
        private DAOMoneda daoMoneda = new DAOMoneda();
        private DAOEstadoCuenta daoEstado = new DAOEstadoCuenta();
        private DAODeposito daoDeposito = new DAODeposito();

        public FormDepositos(Cliente cli)
        {
            cliente = cli;
            // Traer cuentas validadas para este cliente. Si no hay habilitadas, cerrar el form.
            cuentas = daoCuenta
                .retrieveByClientId(cliente.id)
                .FindAll(cuenta => cuenta.estado == daoEstado.habilitado().id);
            tarjetas = daoTarjeta
                .retrieveByClientId(cliente.id)
                .FindAll(t => Utils.fechaSistema < t.fecha_vencimiento);
            InitializeComponent();
        }


        private void FormDepositos_Load(object sender, EventArgs e)
        {
            // Popular combos
            monedas = daoMoneda.retrieveBase();

            if (tarjetas.Count() == 0)
            {
                MessageBox.Show("No posee tarjetas vigentes, esta ventana se cerrará");
                this.Close();
            }
            else
            {
                cmbTarjeta.DataSource = tarjetas;
                cmbTarjeta.DisplayMember = "Visualize";
                cmbTarjeta.ValueMember = "numero";
            }
            if (cuentas.Count() == 0)
            {
                MessageBox.Show("No posee cuentas habilitadas, esta ventana se cerrará");
                this.Close();
            }
            else
            {

                cmbCuenta.DataSource = cuentas;
                cmbCuenta.DisplayMember = "Visualize";
                cmbCuenta.ValueMember = "id";
            }

            cmbMoneda.DataSource = monedas;
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "id";
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (!Utils.isNumeric(keypress))
            {
                MessageBox.Show(" Solo puede ingresar un número o .!");
                txtImporte.Text = "";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (!ValidarImporte()) return ;
            try
            {
                Deposito d = daoDeposito.create(CrearDeposito());
                // Out of the box validation.
                if(d.importe == importe)
                    MessageBox.Show("Creación exitosa!");
            }
            catch
            {
                MessageBox.Show("Hubo un error al registrar su depósito. Reintente.");
                return;
            }
        }

        private Deposito CrearDeposito()
        {
            Deposito depo = new Deposito();
            depo.fecha = Utils.fechaSistema;
            depo.importe = importe;
            depo.tarjeta_numero = Convert.ToInt64(cmbTarjeta.SelectedValue);
            depo.tipo_moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            depo.cuenta_destino = Convert.ToInt64(cmbCuenta.SelectedValue);
            depo.emisor = ((Tarjeta)cmbTarjeta.SelectedItem).emisor;
            return depo;
        }

        private bool ValidarImporte()
        {
            if (txtImporte.Text == "") { MessageBox.Show("Ingrese un número no vacío"); return false; }
            try
            {
                importe = Double.Parse(txtImporte.Text);
                return true;
            }
            catch {
                MessageBox.Show("Formato incorrecto de importe! Debe ser números con una sola ,");
                txtImporte.Text = "";
                return false;
            }
        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
