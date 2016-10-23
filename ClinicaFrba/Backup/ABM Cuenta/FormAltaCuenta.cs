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

namespace PagoElectronico.ABM_Cuenta
{
    public partial class FormAltaCuenta : Form
    {
        long? id = null;
        int? codCli;
        bool update = false;

        public FormAltaCuenta(Cliente cli, bool esCliente)
        {
            InitializeComponent();
            tbCliente.Text = String.Format("{0} {1}", cli.nombre,cli.apellido);
            dtFechaApertura.Value = DateTime.Today;
            tbNroCuenta.Text = new DAOCuenta().proximoNumeroDeCuenta().ToString();
            cargarCombos();
            cbEstado.SelectedIndex = 0;
            codCli = cli.id;
            cbEstado.Enabled = !esCliente;
            dtFechaApertura.Enabled = !esCliente;
            tbSaldo.Visible = false;
            lblSaldo.Visible = false;
        }

        public FormAltaCuenta(Cliente cli, Cuenta cuenta, bool esCliente):this(cli, esCliente)
        {
            this.Text = "Modificar Cuenta";
            btnGuardar.Text = "Modificar";
            volcarDatosCliente(cuenta);
            id = cuenta.id;
            dtFechaApertura.Enabled = false;
            tbSaldo.Visible = true;
            lblSaldo.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!sonDatosValidos())
                return;

            Cuenta c = new Cuenta();
            c.id = id;
            c.pais = ((Pais)cbPais.SelectedItem).id;
            c.numCuenta = Convert.ToInt64(tbNroCuenta.Text.Trim());
            c.tipoCuenta = ((TipoCuenta)cbTipoCuenta.SelectedItem).id;
            c.tipoMoneda = ((Moneda)cbMoneda.SelectedItem).id;
            c.fechaCreacion = dtFechaApertura.Value.Date;
            c.estado = ((EstadoCuenta)cbEstado.SelectedItem).id;
            c.codigoCliente = codCli;

            Cuenta result = null;
            if (update)
            {
                try
                {
                    result = new DAOCuenta().update(c);
                    MessageBox.Show(String.Format("Cuenta Numero:{0} Tipo:{1}", result.numCuenta, result.tipoCuenta), "Operacion Exitosa", MessageBoxButtons.OK);
                }
                catch (MyException exc)
                {
                    MessageBox.Show(exc.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    result = new DAOCuenta().create(c);
                    MessageBox.Show(String.Format("Cuenta Numero:{0} Tipo:{1}", result.numCuenta, result.tipoCuenta), "Operacion Exitosa", MessageBoxButtons.OK);
                }
                catch (MyException exc)
                {
                    MessageBox.Show(exc.Message);
                    return;
                }
            }
            this.Close();
        }

        private void cargarCombos()
        {
            cbPais.Items.AddRange(new DAOPais().retrieveBase().ToArray());
            cbTipoCuenta.Items.AddRange(new DAOTipoCuenta().retrieveBase().ToArray());
            cbMoneda.Items.AddRange(new DAOMoneda().retrieveBase().ToArray());
            cbEstado.Items.Add(new DAOEstadoCuenta().retrieveBase().ToArray()[0]);
        }

        private void volcarDatosCliente(Cuenta cuenta)
        {
            update = true;
            cbEstado.Items.Clear();
            cbEstado.Items.AddRange(new DAOEstadoCuenta().retrieveBase().ToArray());
            tbNroCuenta.Text = cuenta.numCuenta.ToString();
            dtFechaApertura.Value = (DateTime)cuenta.fechaCreacion;
            cbEstado.SelectedItem = new DAOEstadoCuenta().retrieveBase().Find(e => e.id == cuenta.estado);
            cbPais.SelectedItem = new DAOPais().retrieveBase().Find(p => p.id == cuenta.pais);
            cbMoneda.SelectedItem = new DAOMoneda().retrieveBase().Find(m => m.id == cuenta.tipoMoneda);
            cbTipoCuenta.SelectedItem = new DAOTipoCuenta().retrieveBase().Find(c => c.id == cuenta.tipoCuenta);
            tbSaldo.Text = cuenta.saldo.ToString();
        }

        private bool sonDatosValidos()
        {
            if (cbPais.SelectedIndex < 0)
            {
                MessageBox.Show("no hay un pais seleccionado"); return false;
            }
            if (cbMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("no hay un tipo de moneda seleccionado"); return false;
            }
            if (cbTipoCuenta.SelectedIndex < 0)
            {
                MessageBox.Show("no hay un tipo de cuenta seleccionado"); return false;
            }
            return true;
        }
    }
}
