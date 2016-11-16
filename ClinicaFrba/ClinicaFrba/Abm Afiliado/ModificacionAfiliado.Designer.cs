namespace ClinicaFrba.Abm_Afiliado
{
    partial class ModificacionAfiliado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEstadoCivi = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lbDireccion = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.btCambioPlan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEstadoCivi);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.lbDireccion);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos para modificar";
            // 
            // cbEstadoCivi
            // 
            this.cbEstadoCivi.FormattingEnabled = true;
            this.cbEstadoCivi.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Concubinato",
            "Viudo/a",
            "Divorciado/a"});
            this.cbEstadoCivi.Location = new System.Drawing.Point(131, 122);
            this.cbEstadoCivi.Name = "cbEstadoCivi";
            this.cbEstadoCivi.Size = new System.Drawing.Size(99, 21);
            this.cbEstadoCivi.TabIndex = 5;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(130, 70);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(130, 44);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(130, 18);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // lbDireccion
            // 
            this.lbDireccion.AutoSize = true;
            this.lbDireccion.Location = new System.Drawing.Point(16, 21);
            this.lbDireccion.Name = "lbDireccion";
            this.lbDireccion.Size = new System.Drawing.Size(108, 117);
            this.lbDireccion.TabIndex = 0;
            this.lbDireccion.Text = "Dirección\r\n\r\nTeléfono\r\n\r\nMail\r\n\r\nFecha de Nacimiento\r\n\r\nEstado Civil";
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(8, 155);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 36);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(185, 155);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 36);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(138, 96);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaNac.TabIndex = 4;
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // btCambioPlan
            // 
            this.btCambioPlan.Location = new System.Drawing.Point(90, 155);
            this.btCambioPlan.Name = "btCambioPlan";
            this.btCambioPlan.Size = new System.Drawing.Size(88, 36);
            this.btCambioPlan.TabIndex = 5;
            this.btCambioPlan.Text = "Cambio de Plan";
            this.btCambioPlan.UseVisualStyleBackColor = true;
            this.btCambioPlan.Click += new System.EventHandler(this.btCambioPlan_Click);
            // 
            // ModificacionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 199);
            this.Controls.Add(this.btCambioPlan);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificacionAfiliado";
            this.Text = "Modificacion de afiliado";
            this.Load += new System.EventHandler(this.ModificacionAfiliado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbDireccion;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.ComboBox cbEstadoCivi;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Button btCambioPlan;
    }
}