using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Registro_Llegada : Form
    {
        public Registro_Llegada()
        {
            InitializeComponent();
        }

        private void Registro_Llegada_Load(object sender, EventArgs e)
        {
            obtenerProfesionales();
            obtenerBonos();
        }
    }
}
