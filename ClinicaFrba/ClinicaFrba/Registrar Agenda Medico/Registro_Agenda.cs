using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public partial class Registro_Agenda : Form
    {
        public Registro_Agenda(Funcionalidades fun)
        {
            this.fun = fun;
            InitializeComponent();
            dateTimePicker1.CustomFormat = "hh:mm tt";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
            mPrevDate = dateTimePicker1.Value;
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            dateTimePicker2.CustomFormat = "hh:mm tt";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
            mPrevDate2 = dateTimePicker2.Value;
            dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
            comboBox3.Items.Add("Lunes");
            comboBox3.Items.Add("Martes");
            comboBox3.Items.Add("Miercoles");
            comboBox3.Items.Add("Jueves");
            comboBox3.Items.Add("Viernes");
            comboBox3.Items.Add("Sabado");
        }
        Funcionalidades fun;
        private DateTime mPrevDate;
        private DateTime mPrevDate2;
        private bool mBusy;
        private bool mBusy2;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mBusy = true;
            DateTime dt = dateTimePicker1.Value;
            if ((dt.Minute * 60 + dt.Second) % 300 != 0)
            {
                TimeSpan diff = dt - mPrevDate;
                if (diff.Ticks < 0) dateTimePicker1.Value = mPrevDate.AddMinutes(-30);
                else dateTimePicker1.Value = mPrevDate.AddMinutes(30);
            }
            mBusy = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            mBusy = true;
            DateTime dt = dateTimePicker2.Value;
            if ((dt.Minute * 60 + dt.Second) % 300 != 0)
            {
                TimeSpan diff = dt - mPrevDate;
                if (diff.Ticks < 0) dateTimePicker2.Value = mPrevDate.AddMinutes(-30);
                else dateTimePicker2.Value = mPrevDate.AddMinutes(30);
            }
            mBusy = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fun.Show();
            this.Close();
        }
    }
}
