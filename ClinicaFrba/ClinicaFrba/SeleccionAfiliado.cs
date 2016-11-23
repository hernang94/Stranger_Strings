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

namespace ClinicaFrba
{
    public partial class SeleccionAfiliado : Form
    {
        public Funcionalidades fun;
        public Funcionalidades funFake;
        public string tipo;

        public SeleccionAfiliado(string tipo, Funcionalidades fun)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.fun = fun;
        }

        private void SeleccionAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.fun.Show();
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            BD.Usuario user = new BD.Usuario();
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@Num_Doc", int.Parse(txtDocumento.Text)));
            paramlist.Add(new SqlParameter("@Tipo_Doc", cbTipoDoc.Text));
            SqlDataReader lector = BDStranger_Strings.GetDataReader("STRANGER_STRINGS.SP_OBTENER_AFILIADO", "SP", paramlist);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    user.UserName = (string)lector["Apellido"];
                    user.Dni = (decimal)lector["Num_Doc"];
                    user.Tipo_Doc = (string)lector["Tipo_Doc"];
                    user.Cantidad_Intentos = (Int16)lector["Cantidad_Intentos"];
                }
            }

            funFake = new Funcionalidades(user);

            if (this.tipo == "pedir_Turno")
            {
                Pedir_Turno.formSolicitarTurno pedir_Turno = new Pedir_Turno.formSolicitarTurno(this.fun,this.funFake);

                pedir_Turno.Show();
                this.Hide();
            }
            if (this.tipo == "cancelar_Afiliado")
            {
                Cancelar_Atencion.CancelarAtencionAfiliado cancelar_Afiliado = new Cancelar_Atencion.CancelarAtencionAfiliado(this.fun,this.funFake);

                cancelar_Afiliado.Show();
                this.Hide();
            }
            if (this.tipo == "compraBono")
            {
                Compra_Bono.CompraBonoAfiliado compraBono = new Compra_Bono.CompraBonoAfiliado(this.fun,this.funFake);
                compraBono.Show();
                this.Hide();
            }
        }

        private void cbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
