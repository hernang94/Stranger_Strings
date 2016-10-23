﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class A_Familia : Form
    {
        public int cantFamilia;

        public A_Familia(int cantFamilia)
        {
            this.cantFamilia = cantFamilia;
            InitializeComponent();
        }

        private void A_Familia_Load(object sender, EventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btIngresar_Click(object sender, EventArgs e)
        {
            this.cantFamilia--;
            if (cantFamilia > 0)
            {
                A_Familia af = new A_Familia(cantFamilia);
                af.Show();
                
            }
            this.Hide();
            //Se cargan los datos del familiar
        }
    }
}
