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

namespace PagoElectronico.ABM_Cliente
{
    public partial class FormModifTarjet : Form
    {

        private Tarjeta tarjeta { get; set; }
        private DAOTarjeta daoTarjeta = new DAOTarjeta();
        private DAOEmisor daoEmisor = new DAOEmisor();
        private bool update { get; set; }
        private List<Emisor> lstEmisores = new List<Emisor>();

        public FormModifTarjet(Tarjeta tar)
        {
            tarjeta = tar;
            InitializeComponent();
            
        }

        private void FormModifTarjeta_Load(object sender, EventArgs e)
        {
            cargarCombos();
            if (tarjeta.numero != null)
            {
                this.Text = "Modificar Tarjeta";
                btnCrear.Text = "Modificar";
                update = true;
                txtNumero.Enabled = false;
                txtNumero.Text = tarjeta.Visualize;
                dateEmision.Value = (DateTime)tarjeta.fecha_emision;
                dateVencimiento.Value = (DateTime)tarjeta.fecha_vencimiento;
                txtCodigo.Text = tarjeta.cod_seguridad.ToString();
                string emi = (string)tarjeta.nombre_emisor();
                cmbEmisor.SelectedIndex = cmbEmisor.FindStringExact(emi);
            }
            else
            {
                this.Text = "Crear Tarjeta";
            }
            


        }

        private void cargarCombos()
        {
            lstEmisores = daoEmisor.retrieveAll();

            if (lstEmisores.Count > 0)
            {
                cmbEmisor.Visible = true;
                cmbEmisor.DataSource = lstEmisores;
                cmbEmisor.DisplayMember = "nombre";
                cmbEmisor.ValueMember = "id";
                cmbEmisor.SelectedIndex = -1;

            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            tarjeta.fecha_emision = dateEmision.Value.Date;
            tarjeta.fecha_vencimiento = dateVencimiento.Value.Date;
            tarjeta.cod_seguridad = (int?)Convert.ToInt32(txtCodigo.Text);
            tarjeta.emisor = ((Emisor)cmbEmisor.SelectedItem).id;
            tarjeta.tEmisor = (Emisor)daoEmisor.retrieveBy_id(((Emisor)cmbEmisor.SelectedItem).id);
            if (update)
            {
                if (daoTarjeta.update(tarjeta))
                {
                    MessageBox.Show("Tarjeta actualizada correctamente");
                    this.Close();
                    return;
                }
                else
                {
                    throw new Exception("Datos no se cargaron correctamente");
                }
            }
            else
            {
                tarjeta.numero = (long)Convert.ToInt64(txtNumero.Text);
                if (daoTarjeta.create(tarjeta))
                {
                    MessageBox.Show("Tarjeta actualizada correctamente");
                    this.Close();
                    return;
                }
                else
                {
                    throw new Exception("Datos no se cargaron correctamente");
                }
            }

        }
    }
}
