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

namespace PagoElectronico.ABM_Rol
{
    public partial class AltaRol : Form
    {
        private Rol rol { get; set; }
        private DAORol dao = new DAORol();
        public AltaRol(Rol aRol)
        {
            rol = aRol;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            List<Funcionalidad> l = new List<Funcionalidad>();
            l = Funcionalidad.ObtenerFuncionalidades();
            grillaFuncionalidades.DataSource = l;
            grillaFuncionalidades.ValueMember = "Id";
            grillaFuncionalidades.DisplayMember = "Nombre";
            // Si es mod, checkeo las funcionalidades del rol
            if (rol.id != null) {
                txtNombre.Text = rol.nombre;
                chkActivo.Checked = (bool)rol.activo;
                List<Funcionalidad> actuales = Funcionalidad.ObtenerFuncionalidades((int)rol.id);
                for (int i = 0; i <= (grillaFuncionalidades.Items.Count - 1); i++)
                {
                    if (actuales.Contains((Funcionalidad)grillaFuncionalidades.Items[i]))
                        grillaFuncionalidades.SetItemCheckState(i, CheckState.Checked);
                    else grillaFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "" || grillaFuncionalidades.CheckedItems.Count == 0)
            {MessageBox.Show("Texto no puede ser vacío y debe elegir funcionalidad/es"); return;}

            rol.nombre = txtNombre.Text;
            rol.activo = chkActivo.Checked;

            List<Funcionalidad> lf = new List<Funcionalidad>();
            foreach (Funcionalidad unaFunc in grillaFuncionalidades.CheckedItems)
            {
                lf.Add(unaFunc);
            }
            // Alta o modificación
            if (rol.id == null)
            {
                if (dao.create(rol, lf)) MessageBox.Show("Rol creado correctamente");
            }
            else {
                if (dao.update(rol, lf)) MessageBox.Show("Rol modificado correctamente");
            }
        }
    }
}
