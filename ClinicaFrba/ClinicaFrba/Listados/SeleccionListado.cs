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
            dtgListado.DataSource = null;
        }

        private void cbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgListado.DataSource = null;
            
        }

        private void crearGrillaTOP5Cancelaciones()
        {
            DataGridViewTextBoxColumn colCantCancelaciones = new DataGridViewTextBoxColumn();
            colCantCancelaciones.DataPropertyName = "cantidad";
            colCantCancelaciones.HeaderText = "Cant. Cancelaciones";
            colCantCancelaciones.Width = 60;
            DataGridViewTextBoxColumn colEspDescripcion = new DataGridViewTextBoxColumn();
            colEspDescripcion.DataPropertyName = "especialidad";
            colEspDescripcion.HeaderText = "Especialidad";
            colEspDescripcion.Width = 200;

            dtgListado.Columns.Add(colCantCancelaciones);
            dtgListado.Columns.Add(colEspDescripcion);
        }

        private void crearGrillaTOP5Consultados()
        {
            DataGridViewTextBoxColumn colCantConsultas = new DataGridViewTextBoxColumn();
            colCantConsultas.DataPropertyName = "cantidad";
            colCantConsultas.HeaderText = "CantidadConsultas";
            colCantConsultas.Width = 60;
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre";
            colNombre.HeaderText = "Nombre Prof.";
            colNombre.Width = 75;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido Prof.";
            colApellido.Width = 75;
            DataGridViewTextBoxColumn colPlan = new DataGridViewTextBoxColumn();
            colPlan.DataPropertyName = "plan";
            colPlan.HeaderText = "Tipo de Plan";
            colPlan.Width = 120;
            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.DataPropertyName = "especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.Width = 120;

            dtgListado.Columns.Add(colCantConsultas);
            dtgListado.Columns.Add(colNombre);
            dtgListado.Columns.Add(colApellido);
            dtgListado.Columns.Add(colPlan);
            dtgListado.Columns.Add(colEspecialidad);
        }

        private void crearGrillaTOP5ProfMenosHoras()
        {
            DataGridViewTextBoxColumn colCantConsultas = new DataGridViewTextBoxColumn();
            colCantConsultas.DataPropertyName = "cantidad";
            colCantConsultas.HeaderText = "Horas Trabajadas";
            colCantConsultas.Width = 70;
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre";
            colNombre.HeaderText = "Nombre Prof.";
            colNombre.Width = 75;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido Prof.";
            colApellido.Width = 75;
            DataGridViewTextBoxColumn colPlan = new DataGridViewTextBoxColumn();
            colPlan.DataPropertyName = "plan";
            colPlan.HeaderText = "Tipo de Plan";
            colPlan.Width = 120;
            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.DataPropertyName = "especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.Width = 120;

            dtgListado.Columns.Add(colCantConsultas);
            dtgListado.Columns.Add(colNombre);
            dtgListado.Columns.Add(colApellido);
            dtgListado.Columns.Add(colPlan);
            dtgListado.Columns.Add(colEspecialidad);
        }

        private void crearGrillaTOP5BonosComprados()
        {
            DataGridViewTextBoxColumn colCantBonos = new DataGridViewTextBoxColumn();
            colCantBonos.DataPropertyName = "cantidad";
            colCantBonos.HeaderText = "Cant. Bonos";
            colCantBonos.Width = 60;
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 200;
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 200;
            DataGridViewTextBoxColumn colPertenece = new DataGridViewTextBoxColumn();
            colPertenece.DataPropertyName = "pertenece_grupo_familiar";
            colPertenece.HeaderText = "Grupo Familiar";
            colPertenece.Width = 60;

            dtgListado.Columns.Add(colCantBonos);
            dtgListado.Columns.Add(colApellido);
            dtgListado.Columns.Add(colNombre);
            dtgListado.Columns.Add(colPertenece);
        }

        private void crearGrillaTOP5EspecialidadMasBonos()
        {
            DataGridViewTextBoxColumn colCantCancelaciones = new DataGridViewTextBoxColumn();
            colCantCancelaciones.DataPropertyName = "cantidad";
            colCantCancelaciones.HeaderText = "Cant. Bonos";
            colCantCancelaciones.Width = 60;
            DataGridViewTextBoxColumn colEspDescripcion = new DataGridViewTextBoxColumn();
            colEspDescripcion.DataPropertyName = "especialidad";
            colEspDescripcion.HeaderText = "Especialidad";
            colEspDescripcion.Width = 200;

            dtgListado.Columns.Add(colCantCancelaciones);
            dtgListado.Columns.Add(colEspDescripcion);
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
            if (cbSemestre.SelectedIndex == 0)
            {
                return Convert.ToDateTime("30/" + obtenerFinSemestre() + cbAño.SelectedItem + " 00:00");
            }
            else
            {
                return Convert.ToDateTime("31/" + obtenerFinSemestre() + cbAño.SelectedItem + " 00:00");
            }
            
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
            switch(cbListado.SelectedIndex)
            {
                case 0: 
                    crearGrillaTOP5Cancelaciones();
                    BD.Entidades.TOP5Cancelaciones cancelaciones = new BD.Entidades.TOP5Cancelaciones();
                    List<BD.Entidades.TOP5Cancelaciones> listaTOP5Cancelaciones = cancelaciones.obtenerLista(this);
                    dtgListado.DataSource = listaTOP5Cancelaciones;
                    break;
                case 1:
                    crearGrillaTOP5Consultados();
                    BD.Entidades.TOP5ProfConsultados consultados = new BD.Entidades.TOP5ProfConsultados();
                    List<BD.Entidades.TOP5ProfConsultados> listaTOP5Consultados = consultados.obtenerLista(this);
                    dtgListado.DataSource = listaTOP5Consultados;
                    break;
                case 2:
                    crearGrillaTOP5ProfMenosHoras();
                    BD.Entidades.TOP5ProfMenosHoras menosHoras = new BD.Entidades.TOP5ProfMenosHoras();
                    List<BD.Entidades.TOP5ProfMenosHoras> listaTOP5menosHoras = menosHoras.obtenerLista(this);
                    dtgListado.DataSource = listaTOP5menosHoras;
                    break;
                case 3:
                    crearGrillaTOP5BonosComprados();
                    BD.Entidades.TOP5BonosComprados bonosComprados = new BD.Entidades.TOP5BonosComprados();
                    List<BD.Entidades.TOP5BonosComprados> listaTOP5bonosComprados = bonosComprados.obtenerLista(this);
                    dtgListado.DataSource = listaTOP5bonosComprados;
                    break;
                case 4:
                    crearGrillaTOP5EspecialidadMasBonos();
                    BD.Entidades.TOP5EspecialidadMasBonos especialidadMasBonos = new BD.Entidades.TOP5EspecialidadMasBonos();
                    List<BD.Entidades.TOP5EspecialidadMasBonos> listaTOP5especialidadMasBonos = especialidadMasBonos.obtenerLista(this);
                    dtgListado.DataSource = listaTOP5especialidadMasBonos;
                    break;
            }
        }

        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgListado.DataSource = null;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.fun.Show();
            this.Close();
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
