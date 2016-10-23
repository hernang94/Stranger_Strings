namespace PagoElectronico
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSeleccionRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.groupAdmin = new System.Windows.Forms.GroupBox();
            this.btnBuscarFacturas = new System.Windows.Forms.Button();
            this.btnListados = new System.Windows.Forms.Button();
            this.btnConSaldoAdm = new System.Windows.Forms.Button();
            this.btnABMCuentas = new System.Windows.Forms.Button();
            this.btnABMCliente = new System.Windows.Forms.Button();
            this.btnABMRol = new System.Windows.Forms.Button();
            this.groupCliente = new System.Windows.Forms.GroupBox();
            this.btnConSaldo = new System.Windows.Forms.Button();
            this.btnTransferencias = new System.Windows.Forms.Button();
            this.btnCuentasCliente = new System.Windows.Forms.Button();
            this.btnRetiros = new System.Windows.Forms.Button();
            this.btnDepositos = new System.Windows.Forms.Button();
            this.groupAdmin.SuspendLayout();
            this.groupCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSeleccionRol
            // 
            this.lblSeleccionRol.AutoSize = true;
            this.lblSeleccionRol.Location = new System.Drawing.Point(13, 13);
            this.lblSeleccionRol.Name = "lblSeleccionRol";
            this.lblSeleccionRol.Size = new System.Drawing.Size(23, 13);
            this.lblSeleccionRol.TabIndex = 0;
            this.lblSeleccionRol.Text = "Rol";
            this.lblSeleccionRol.Visible = false;
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(61, 10);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(177, 21);
            this.cmbRol.TabIndex = 1;
            this.cmbRol.Visible = false;
            this.cmbRol.SelectedIndexChanged += new System.EventHandler(this.cmbRol_SelectedIndexChanged);
            // 
            // groupAdmin
            // 
            this.groupAdmin.Controls.Add(this.btnBuscarFacturas);
            this.groupAdmin.Controls.Add(this.btnListados);
            this.groupAdmin.Controls.Add(this.btnConSaldoAdm);
            this.groupAdmin.Controls.Add(this.btnABMCuentas);
            this.groupAdmin.Controls.Add(this.btnABMCliente);
            this.groupAdmin.Controls.Add(this.btnABMRol);
            this.groupAdmin.Location = new System.Drawing.Point(16, 37);
            this.groupAdmin.Name = "groupAdmin";
            this.groupAdmin.Size = new System.Drawing.Size(470, 95);
            this.groupAdmin.TabIndex = 3;
            this.groupAdmin.TabStop = false;
            this.groupAdmin.Text = "Funciones Administrador";
            this.groupAdmin.Visible = false;
            // 
            // btnBuscarFacturas
            // 
            this.btnBuscarFacturas.Location = new System.Drawing.Point(348, 19);
            this.btnBuscarFacturas.Name = "btnBuscarFacturas";
            this.btnBuscarFacturas.Size = new System.Drawing.Size(92, 23);
            this.btnBuscarFacturas.TabIndex = 6;
            this.btnBuscarFacturas.Text = "Facturar";
            this.btnBuscarFacturas.UseVisualStyleBackColor = true;
            this.btnBuscarFacturas.Click += new System.EventHandler(this.btnBuscarFacturas_Click_1);
            // 
            // btnListados
            // 
            this.btnListados.Location = new System.Drawing.Point(324, 49);
            this.btnListados.Name = "btnListados";
            this.btnListados.Size = new System.Drawing.Size(116, 23);
            this.btnListados.TabIndex = 6;
            this.btnListados.Text = "Listados Estadisticos";
            this.btnListados.UseVisualStyleBackColor = true;
            this.btnListados.Click += new System.EventHandler(this.btnListados_Click);
            // 
            // btnConSaldoAdm
            // 
            this.btnConSaldoAdm.Location = new System.Drawing.Point(250, 20);
            this.btnConSaldoAdm.Name = "btnConSaldoAdm";
            this.btnConSaldoAdm.Size = new System.Drawing.Size(92, 23);
            this.btnConSaldoAdm.TabIndex = 5;
            this.btnConSaldoAdm.Text = "Consulta Saldos";
            this.btnConSaldoAdm.UseVisualStyleBackColor = true;
            this.btnConSaldoAdm.Click += new System.EventHandler(this.btnConSaldoAdm_Click);
            // 
            // btnABMCuentas
            // 
            this.btnABMCuentas.Location = new System.Drawing.Point(169, 20);
            this.btnABMCuentas.Name = "btnABMCuentas";
            this.btnABMCuentas.Size = new System.Drawing.Size(75, 23);
            this.btnABMCuentas.TabIndex = 2;
            this.btnABMCuentas.Text = "ABM Cuenta";
            this.btnABMCuentas.UseVisualStyleBackColor = true;
            this.btnABMCuentas.Click += new System.EventHandler(this.btnABMCuentas_Click);
            // 
            // btnABMCliente
            // 
            this.btnABMCliente.Location = new System.Drawing.Point(88, 20);
            this.btnABMCliente.Name = "btnABMCliente";
            this.btnABMCliente.Size = new System.Drawing.Size(75, 23);
            this.btnABMCliente.TabIndex = 1;
            this.btnABMCliente.Text = "ABM Cliente";
            this.btnABMCliente.UseVisualStyleBackColor = true;
            this.btnABMCliente.Click += new System.EventHandler(this.btnABMCliente_Click);
            // 
            // btnABMRol
            // 
            this.btnABMRol.Location = new System.Drawing.Point(7, 20);
            this.btnABMRol.Name = "btnABMRol";
            this.btnABMRol.Size = new System.Drawing.Size(75, 23);
            this.btnABMRol.TabIndex = 0;
            this.btnABMRol.Text = "ABM Rol";
            this.btnABMRol.UseVisualStyleBackColor = true;
            this.btnABMRol.Click += new System.EventHandler(this.btnABMRol_Click);
            // 
            // groupCliente
            // 
            this.groupCliente.Controls.Add(this.btnConSaldo);
            this.groupCliente.Controls.Add(this.btnTransferencias);
            this.groupCliente.Controls.Add(this.btnCuentasCliente);
            this.groupCliente.Controls.Add(this.btnRetiros);
            this.groupCliente.Controls.Add(this.btnDepositos);
            this.groupCliente.Location = new System.Drawing.Point(16, 138);
            this.groupCliente.Name = "groupCliente";
            this.groupCliente.Size = new System.Drawing.Size(470, 100);
            this.groupCliente.TabIndex = 4;
            this.groupCliente.TabStop = false;
            this.groupCliente.Text = "Funciones Cliente";
            this.groupCliente.Visible = false;
            // 
            // btnConSaldo
            // 
            this.btnConSaldo.Location = new System.Drawing.Point(250, 20);
            this.btnConSaldo.Name = "btnConSaldo";
            this.btnConSaldo.Size = new System.Drawing.Size(92, 23);
            this.btnConSaldo.TabIndex = 4;
            this.btnConSaldo.Text = "Consulta Saldos";
            this.btnConSaldo.UseVisualStyleBackColor = true;
            this.btnConSaldo.Click += new System.EventHandler(this.btnConSaldo_Click);
            // 
            // btnTransferencias
            // 
            this.btnTransferencias.Location = new System.Drawing.Point(7, 49);
            this.btnTransferencias.Name = "btnTransferencias";
            this.btnTransferencias.Size = new System.Drawing.Size(88, 23);
            this.btnTransferencias.TabIndex = 4;
            this.btnTransferencias.Text = "Transferencias";
            this.btnTransferencias.UseVisualStyleBackColor = true;
            this.btnTransferencias.Click += new System.EventHandler(this.btnTransferencias_Click);
            // 
            // btnCuentasCliente
            // 
            this.btnCuentasCliente.Location = new System.Drawing.Point(169, 19);
            this.btnCuentasCliente.Name = "btnCuentasCliente";
            this.btnCuentasCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCuentasCliente.TabIndex = 3;
            this.btnCuentasCliente.Text = "Cuentas";
            this.btnCuentasCliente.UseVisualStyleBackColor = true;
            this.btnCuentasCliente.Click += new System.EventHandler(this.btnCuentasCliente_Click);
            // 
            // btnRetiros
            // 
            this.btnRetiros.Location = new System.Drawing.Point(88, 19);
            this.btnRetiros.Name = "btnRetiros";
            this.btnRetiros.Size = new System.Drawing.Size(75, 23);
            this.btnRetiros.TabIndex = 1;
            this.btnRetiros.Text = "Retiros";
            this.btnRetiros.UseVisualStyleBackColor = true;
            this.btnRetiros.Click += new System.EventHandler(this.btnRetiros_Click);
            // 
            // btnDepositos
            // 
            this.btnDepositos.Location = new System.Drawing.Point(7, 20);
            this.btnDepositos.Name = "btnDepositos";
            this.btnDepositos.Size = new System.Drawing.Size(75, 23);
            this.btnDepositos.TabIndex = 0;
            this.btnDepositos.Text = "Depósitos";
            this.btnDepositos.UseVisualStyleBackColor = true;
            this.btnDepositos.Click += new System.EventHandler(this.btnDepositos_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 273);
            this.Controls.Add(this.groupCliente);
            this.Controls.Add(this.groupAdmin);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.lblSeleccionRol);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Funcionalidad";
            this.Load += new System.EventHandler(this.frmPrincipal_Load_1);
            this.groupAdmin.ResumeLayout(false);
            this.groupCliente.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccionRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.GroupBox groupAdmin;
        private System.Windows.Forms.GroupBox groupCliente;
        private System.Windows.Forms.Button btnABMRol;
        private System.Windows.Forms.Button btnABMCliente;
        private System.Windows.Forms.Button btnABMCuentas;
        private System.Windows.Forms.Button btnDepositos;
        private System.Windows.Forms.Button btnCuentasCliente;
        private System.Windows.Forms.Button btnRetiros;
        private System.Windows.Forms.Button btnConSaldoAdm;
        private System.Windows.Forms.Button btnConSaldo;
        private System.Windows.Forms.Button btnTransferencias;

        private System.Windows.Forms.Button btnBuscarFacturas;

        private System.Windows.Forms.Button btnListados;

    }
}