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
    public partial class FormAltaCliente : Form
    {
        private Cliente cliente { get; set; }       
        private DAOCliente daoCliente = new DAOCliente();
        private DAOTarjeta daoTarjeta = new DAOTarjeta();
        private DAOPais daoPais = new DAOPais();
        private DAOTipoDocumento daoTipoDoc = new DAOTipoDocumento();
        private List<Tarjeta> lstTarjetas { get; set; }
        private bool update;
        private List<TipoDocumento> lstTipos;

        public FormAltaCliente(Cliente cli)
        {
            cliente = cli;
            InitializeComponent();
            lstTarjetas = new List<Tarjeta>();
        }

        private void cargarDatosClientes()
        {
                txtUsuario.Text = cliente.usuario;
                txtNombre.Text = cliente.nombre;
                txtApellido.Text = cliente.apellido;
                txtCalle.Text = cliente.dom_calle;
                txtDepto.Text = cliente.dom_dpto.ToString();
                txtPiso.Text = cliente.dom_piso.ToString();
                txtMail.Text = cliente.mail;
                txtNumero.Text = cliente.dom_nro.ToString();
                txtNumID.Text = cliente.documento.ToString();                
                dateNacimiento.Value = (DateTime)cliente.fecha_nac;
                string pa = (string)cliente.get_pais().Substring(1);            
                cbNacionalidad.SelectedIndex = cbNacionalidad.FindStringExact(pa); 
                string tip = ((TipoDocumento)daoTipoDoc.retrieveBy_id(cliente.tipo_documento)).descripcion;
                cmbTipo.SelectedIndex = cmbTipo.FindStringExact(tip);
                checkActivo.Checked = (bool)cliente.activo;
        }


        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utils.isCaracterInvalido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool validateCamps()
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCalle.Text == "" || txtDepto.Text == "" || txtMail.Text == ""
                || txtNumero.Text == "" || txtPiso.Text == "")
            {
                MessageBox.Show("Hay campos vacios");
                return false;
            }
            return true;
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            if (validateCamps())
            {
                cliente.nombre = txtNombre.Text;
                cliente.apellido = txtApellido.Text;
                cliente.mail = txtMail.Text;
                cliente.fecha_nac = dateNacimiento.Value.Date;
                cliente.dom_calle = txtCalle.Text;
                cliente.dom_nro = (int?)Convert.ToInt32(txtNumero.Text);
                cliente.dom_piso = (int?)Convert.ToInt32(txtPiso.Text);
                cliente.dom_dpto = txtDepto.Text;
                TipoDocumento tip = (TipoDocumento)daoTipoDoc.retrieveBy_desc(cmbTipo.Text);
                cliente.tipo_documento = (int?)tip.id;
                cliente.documento = Convert.ToInt32(txtNumID.Text);
                cliente.nacionalidad = ((Pais)cbNacionalidad.SelectedItem).id;
                cliente.usuario = txtUsuario.Text;
                cliente.activo = (bool)checkActivo.Checked;
                if (update)
                {
                    if (daoCliente.update(cliente))
                    {
                        MessageBox.Show("Cliente actualizado correctamente");
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
                    if (daoCliente.create(cliente))
                    {
                        MessageBox.Show("Cliente creado correctamente");
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Datos no se cargaron correctamente");
                        return;
                    }
                }
            }
             
        }

        private void cargarGrilla()
        {

            DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn();
            colNumero.DataPropertyName = "numeroMostrable";
            colNumero.HeaderText = "Numero";
            colNumero.Width = 120;
            DataGridViewTextBoxColumn colEmision = new DataGridViewTextBoxColumn();
            colEmision.DataPropertyName = "fecha_emision";
            colEmision.HeaderText = "Fecha Emision";
            colEmision.Width = 120;
            DataGridViewTextBoxColumn colVencimiento = new DataGridViewTextBoxColumn();
            colVencimiento.DataPropertyName = "fecha_vencimiento";
            colVencimiento.HeaderText = "Fecha de Vencimiento";
            colVencimiento.Width = 120;
            DataGridViewTextBoxColumn colSeguridad = new DataGridViewTextBoxColumn();
            colSeguridad.DataPropertyName = "cod_seguridad";
            colSeguridad.HeaderText = "Codigo de Seguridad";
            colSeguridad.Width = 120;

            dtgTarjetas.Columns.Add(colNumero);
            dtgTarjetas.Columns.Add(colEmision);
            dtgTarjetas.Columns.Add(colVencimiento);
            dtgTarjetas.Columns.Add(colSeguridad);
        }

        public void actualizarGrilla()
        {
            if (txtNombre.Text != "")
                lstTarjetas = cliente.get_tarjetas();
            if (lstTarjetas.Count == 0)
            {
            }
            else {
                Tarjeta tarjeta = new Tarjeta();
                tarjeta = lstTarjetas[0];
            }

            dtgTarjetas.DataSource = lstTarjetas;

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarCombos()
        {
            cbNacionalidad.Items.AddRange(daoPais.retrieveBase().ToArray());
            
            lstTipos = TipoDocumento.ObtenerTiposDocumento();

            if (lstTipos.Count > 0)
            {
                cmbTipo.Visible = true;
                cmbTipo.DataSource = lstTipos;
                cmbTipo.DisplayMember = "descripcion";
                cmbTipo.ValueMember = "id";
                cmbTipo.SelectedIndex = -1;

            }
        }

        private void FormAltaCliente_Load(object sender, EventArgs e)
        {                       
            cargarCombos();
            if (cliente.id != null)
            {
                txtUsuario.Enabled = false;
                update = true;
                cargarDatosClientes();
                dtgTarjetas.AutoGenerateColumns = false;
                dtgTarjetas.MultiSelect = false;
                cargarGrilla();
                actualizarGrilla();
                btnCrear.Text = "Modificar";
                this.Text = "FormModifCliente";
            }
        }

        private void btnDesvinc_Click(object sender, EventArgs e)
        {
            if (dtgTarjetas.CurrentRow != null) {
                Tarjeta delete = (Tarjeta)dtgTarjetas.CurrentRow.DataBoundItem;
                daoTarjeta.delete((long)(decimal)delete.numero);
            } 
            
            actualizarGrilla();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            Tarjeta tarjeta = (Tarjeta)dtgTarjetas.CurrentRow.DataBoundItem;
            FormModifTarjet fmt = new FormModifTarjet(tarjeta);
            fmt.Show();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Tarjeta tarjeta = new Tarjeta();
            if (cliente.id == null) { MessageBox.Show("El cliente al que quiere vincular tarjetas no existe"); return; }
            else tarjeta.cli_cod = cliente.id;
            FormModifTarjet fmt = new FormModifTarjet(tarjeta);
            fmt.Show();
        }

    }

    
}
