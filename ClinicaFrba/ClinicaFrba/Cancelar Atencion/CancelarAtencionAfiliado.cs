﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.BD;
using System.Data.SqlClient;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencionAfiliado : Form
    {
        public Funcionalidades fun;
        public List<BD.Entidades.Turno> listaTurnos = new List<BD.Entidades.Turno>();

        public CancelarAtencionAfiliado(Funcionalidades fun)
        {
            InitializeComponent();
            this.fun = fun;
            crearGrilla();
            actualizarGrilla();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
           DialogResult msge = MessageBox.Show("¿Esta seguro que desea cancelar el turno seleccionado?", "Confirmar cancelación", MessageBoxButtons.YesNo);
           if (msge == DialogResult.Yes)
           {
               cancelarTurno((BD.Entidades.Turno)dtgTurnos.CurrentRow.DataBoundItem);
               actualizarGrilla();
               lbTurnoCancelado.Visible = true;
               timer1.Enabled = true;

           }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lbTurnoCancelado.Visible = false;
            }
        }

        private void dtgTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void crearGrilla()
        {
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "fecha";
            colFecha.HeaderText = "Fecha";
            colFecha.Width = 110;
            DataGridViewTextBoxColumn colProfesional = new DataGridViewTextBoxColumn();
            colProfesional.DataPropertyName = "apellido_prof";
            colProfesional.HeaderText = "Profesional";
            colProfesional.Width = 75;
            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.DataPropertyName = "especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.Width = 210;
            
            dtgTurnos.Columns.Add(colFecha);
            dtgTurnos.Columns.Add(colProfesional);
            dtgTurnos.Columns.Add(colEspecialidad);
            }

        private void actualizarGrilla()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@num_Doc", 72215288 /*int.Parse(fun.user.Nombre)*/));//72215288
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_PEDIR_TURNOS_AFILIADO", "SP", paramList);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    BD.Entidades.Turno turno = new BD.Entidades.Turno();
                    turno.fecha = (DateTime)lector["Turno_Fecha"];
                    turno.apellido_Prof = (string)lector["Apellido"];
                    turno.especialidad = (string)lector["Especialidad_Descripcion"];
                    listaTurnos.Add(turno);
                }
            }
            dtgTurnos.DataSource = listaTurnos;
        }

        private void cancelarTurno(BD.Entidades.Turno Turno)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Turno_Fecha", Turno.fecha));
            paramList.Add(new SqlParameter("@Num_Doc", 72215288 /*int.Parse(fun.user.Nombre)*/));
            paramList.Add(new SqlParameter("@Apellido_Profesional", Turno.apellido_Prof));
            paramList.Add(new SqlParameter("@Especialidad", Turno.especialidad));
            paramList.Add(new SqlParameter("@Tipo_Cancelacion", 'A'));
            paramList.Add(new SqlParameter("@Motivo", tbMotivo.Text));
            BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_CANCELAR_TURNO_AFILIADO", "SP", paramList);
            listaTurnos.Clear();
            dtgTurnos.DataSource = null;
            crearGrilla();
        }

        private void lbMotivo_Click(object sender, EventArgs e)
        {

        }

        private void tbMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void CancelarAtencionAfiliado_Load(object sender, EventArgs e)
        {

        }
    }
}
