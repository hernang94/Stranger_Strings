using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Listados
{
    public partial class SeleccionListado : Form
    {
        public Funcionalidades fun;

        public SeleccionListado(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
        }

        private void cbAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgListado.DataSource = null;
            
        }

        private void crearGrillaTOP5Cancelaciones()
        {
            DataGridViewTextBoxColumn colCantCancelaciones = new DataGridViewTextBoxColumn();
            colCantCancelaciones.DataPropertyName = "cantidad";
            colCantCancelaciones.HeaderText = "Cantidad Cancelaciones";
            colCantCancelaciones.Width = 60;
            DataGridViewTextBoxColumn colEspDescripcion = new DataGridViewTextBoxColumn();
            colEspDescripcion.DataPropertyName = "especialidad";
            colEspDescripcion.HeaderText = "Especialidad";
            colEspDescripcion.Width = 200;

            dtgListado.Columns.Add(colCantCancelaciones);
            dtgListado.Columns.Add(colEspDescripcion);
        }

        public void Top5Cancelaciones()
        {
            crearGrillaTOP5Cancelaciones();
            
        }

        public DateTime construirFechaInicioSemestre()
        {
            return Convert.ToDateTime("01/" + obtenerInicioSemestre() + cbAño.SelectedItem + " 00:00");
        }

        public string obtenerInicioSemestre()
        {
            if (cbSemestre.SelectedIndex == 0)
            {
                return "01/";
            }
            else
            {
                return "07/";
            }
        }

        public DateTime construirFechaFinSemestre()
        {
            return Convert.ToDateTime("01/" + obtenerFinSemestre() + cbAño.SelectedItem + " 00:00");
        }

        public string obtenerFinSemestre()
        {
            if (cbSemestre.SelectedIndex == 0)
            {
                return "06/";
            }
            else
            {
                return "12/";
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            switch(cbListado.SelectedIndex){
                case 0: 
                    crearGrillaTOP5Cancelaciones();
                    BD.Entidades.TOP5Cancelaciones cancelaciones = new BD.Entidades.TOP5Cancelaciones();
                    List<BD.Entidades.TOP5Cancelaciones> listaTOP5Cancelaciones = cancelaciones.obtenerLista(this);
                    dtgListado.DataSource = listaTOP5Cancelaciones;
                break;
            }
        }
    }
}
