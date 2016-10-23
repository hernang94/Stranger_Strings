namespace PagoElectronico.ABM_Cuenta
{
    partial class FormAltaCuenta
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
            this.lblEstado = new System.Windows.Forms.Label();
            this.dtFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.tbNroCuenta = new System.Windows.Forms.TextBox();
            this.cbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.lblNroCuenta = new System.Windows.Forms.Label();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.tbSaldo = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(242, 85);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 24;
            this.lblEstado.Text = "Estado";
            // 
            // dtFechaApertura
            // 
            this.dtFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaApertura.Location = new System.Drawing.Point(333, 166);
            this.dtFechaApertura.Name = "dtFechaApertura";
            this.dtFechaApertura.Size = new System.Drawing.Size(144, 20);
            this.dtFechaApertura.TabIndex = 5;
            // 
            // tbNroCuenta
            // 
            this.tbNroCuenta.Location = new System.Drawing.Point(335, 34);
            this.tbNroCuenta.Name = "tbNroCuenta";
            this.tbNroCuenta.ReadOnly = true;
            this.tbNroCuenta.Size = new System.Drawing.Size(151, 20);
            this.tbNroCuenta.TabIndex = 13;
            this.tbNroCuenta.TabStop = false;
            // 
            // cbTipoCuenta
            // 
            this.cbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCuenta.FormattingEnabled = true;
            this.cbTipoCuenta.Location = new System.Drawing.Point(333, 120);
            this.cbTipoCuenta.Name = "cbTipoCuenta";
            this.cbTipoCuenta.Size = new System.Drawing.Size(144, 21);
            this.cbTipoCuenta.TabIndex = 3;
            // 
            // lblNroCuenta
            // 
            this.lblNroCuenta.AutoSize = true;
            this.lblNroCuenta.Location = new System.Drawing.Point(332, 18);
            this.lblNroCuenta.Name = "lblNroCuenta";
            this.lblNroCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblNroCuenta.TabIndex = 14;
            this.lblNroCuenta.Text = "Numero Cuenta";
            // 
            // cbMoneda
            // 
            this.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(71, 123);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(146, 21);
            this.cbMoneda.TabIndex = 2;
            // 
            // cbPais
            // 
            this.cbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPais.FormattingEnabled = true;
            this.cbPais.Location = new System.Drawing.Point(71, 82);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(146, 21);
            this.cbPais.TabIndex = 0;
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Location = new System.Drawing.Point(242, 168);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(80, 13);
            this.lblFechaApertura.TabIndex = 18;
            this.lblFechaApertura.Text = "Fecha Apertura";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(242, 123);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(65, 13);
            this.lblTipoCuenta.TabIndex = 17;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(19, 126);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 16;
            this.lblMoneda.Text = "Moneda";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(19, 85);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(27, 13);
            this.lblPais.TabIndex = 15;
            this.lblPais.Text = "Pais";
            // 
            // tbCliente
            // 
            this.tbCliente.Location = new System.Drawing.Point(22, 34);
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.ReadOnly = true;
            this.tbCliente.Size = new System.Drawing.Size(270, 20);
            this.tbCliente.TabIndex = 25;
            this.tbCliente.TabStop = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(26, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 26;
            this.lblCliente.Text = "Cliente";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(323, 208);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(414, 208);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Crear";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(333, 82);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(144, 21);
            this.cbEstado.TabIndex = 1;
            // 
            // tbSaldo
            // 
            this.tbSaldo.BackColor = System.Drawing.Color.White;
            this.tbSaldo.Enabled = false;
            this.tbSaldo.Location = new System.Drawing.Point(102, 166);
            this.tbSaldo.Name = "tbSaldo";
            this.tbSaldo.Size = new System.Drawing.Size(115, 20);
            this.tbSaldo.TabIndex = 32;
            this.tbSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(17, 168);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(79, 13);
            this.lblSaldo.TabIndex = 33;
            this.lblSaldo.Text = "Saldo Actual";
            // 
            // FormAltaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 245);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.tbSaldo);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.tbCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.dtFechaApertura);
            this.Controls.Add(this.tbNroCuenta);
            this.Controls.Add(this.cbTipoCuenta);
            this.Controls.Add(this.lblNroCuenta);
            this.Controls.Add(this.cbMoneda);
            this.Controls.Add(this.cbPais);
            this.Controls.Add(this.lblFechaApertura);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblPais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAltaCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Cuenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DateTimePicker dtFechaApertura;
        private System.Windows.Forms.TextBox tbNroCuenta;
        private System.Windows.Forms.ComboBox cbTipoCuenta;
        private System.Windows.Forms.Label lblNroCuenta;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.ComboBox cbPais;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox tbSaldo;
        private System.Windows.Forms.Label lblSaldo;
    }
}