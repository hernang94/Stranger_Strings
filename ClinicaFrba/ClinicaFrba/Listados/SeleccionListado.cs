using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
