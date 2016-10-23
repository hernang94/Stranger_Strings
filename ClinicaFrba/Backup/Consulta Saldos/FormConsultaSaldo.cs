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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class FormConsultaSaldo : Form
    {

        public FormConsultaSaldo(Cuenta c)
        {
            InitializeComponent();
            llenarDepositos(c);
            llenarRetiros(c);
            llenarTransferencias(c);
            lblID.Text = c.id.ToString();
            lblNum.Text = c.numCuenta.ToString();
            
        }

        private void llenarTransferencias(Cuenta c)
        {
            List<Transferencia> transferencias = new DAOTransferencia().ultimasTransferenciasDeCuenta(c);

            DataTable table = new DataTable();
            table.Columns.Add("Fecha");
            table.Columns.Add("Importe");
            table.Columns.Add("Costo");
            table.Columns.Add("Moneda");


            DataRow newRow;

            foreach (Transferencia t in transferencias)
            {
                newRow = table.NewRow();
                newRow["Fecha"] = t.fecha.ToString("yyyy-MM-dd"); ;
                newRow["Importe"] = t.importe;
                newRow["Moneda"] = (Moneda.Monedas)t.tipo_moneda;
                newRow["Costo"] = t.costo;


                table.Rows.Add(newRow);
            }

            dgTransferencias.DataSource = table;
        }

        private void llenarDepositos(Cuenta c)
        {
            List<Deposito> depositos = new DAODeposito().ultimosDepositosDeCuenta(c);

            DataTable table = new DataTable();
            table.Columns.Add("Fecha");
            table.Columns.Add("Importe");
            table.Columns.Add("Moneda");
            table.Columns.Add("Tarjeta");

            DataRow newRow;

            foreach (Deposito d in depositos)
            {
                newRow = table.NewRow();
                newRow["Fecha"] = d.fecha.ToString("yyyy-MM-dd"); ;
                newRow["Importe"] = d.importe;
                newRow["Moneda"] = (Moneda.Monedas)d.tipo_moneda;
                newRow["Tarjeta"] = d.tarjeta_numero;

                table.Rows.Add(newRow);
            }

            dgDepositos.DataSource = table;
        }

        private void llenarRetiros(Cuenta c)
        {
            List<Retiro> retiros = new DAORetiro().ultimosRetirosDeCuenta(c);

            DataTable table = new DataTable();
            table.Columns.Add("Fecha");
            table.Columns.Add("Importe");
            table.Columns.Add("Moneda");

            DataRow newRow;

            foreach (Retiro r in retiros)
            {
                newRow = table.NewRow();
                newRow["Fecha"] = r.fecha.ToString("yyyy-MM-dd"); ;
                newRow["Importe"] = r.importe;
                newRow["Moneda"] = (Moneda.Monedas)r.moneda;

                table.Rows.Add(newRow);
            }

            dgRetiros.DataSource = table;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConsultaSaldo_Load(object sender, EventArgs e)
        {

        }
    }
}
