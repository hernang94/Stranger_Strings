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

namespace PagoElectronico.Retiros
{
    public partial class IngresarDNI : Form
    {
        private Cliente cliente {get; set;}
        private Cheque cheque { get; set; }
        private DAOCheque daoCheque = new DAOCheque();
        private DAORetiro daoRetiro = new DAORetiro();
        private DAOBanco daoBanco = new DAOBanco();

        public IngresarDNI(Cliente cli, Cheque cheq)
        {
            cliente = cli;
            cheque = cheq;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (!Utils.isNumeric(keypress))
            {
                MessageBox.Show(" Solo puede ingresar un número o ,!");
                textBox1.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt64(textBox1.Text) == cliente.documento){
                Cheque inserted = daoCheque.create(cheque);
                Retiro ret = daoRetiro.create(CopyCheque(cheque));
                if (inserted.id_egreso == cheque.id_egreso && ret.cuenta_destino == cheque.cuenta_destino)
                {
                    MessageBox.Show("Su cheque tiene número de egreso: " + cheque.id_egreso + " por el banco " + daoBanco.retrieveBy_id(cheque.cod_banco).nombre);
                    this.Close();
                }
            }
            else {
                MessageBox.Show("El DNI no coincide con el del cliente logueado. Esta ventana se cerrará.");
                this.Close();
            }
        }

        private Retiro CopyCheque(Cheque cheque)
        {
            Retiro ret = new Retiro();
            ret.cuenta_destino = Convert.ToInt64(cheque.cuenta_destino);
            ret.fecha = cheque.retiro_fecha;
            ret.importe = cheque.importe;
            ret.moneda = Convert.ToInt32(cheque.tipo_moneda);
            return ret;

        }
    }
}
