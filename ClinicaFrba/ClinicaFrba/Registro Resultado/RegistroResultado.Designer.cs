namespace ClinicaFrba.Registro_Resultado
{
    partial class RegistroResultado
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
            this.components = new System.ComponentModel.Container();
            this.btAceptar = new System.Windows.Forms.Button();
            this.gbMotivo = new System.Windows.Forms.GroupBox();
            this.txtSintomas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnfermedades = new System.Windows.Forms.TextBox();
            this.btVolver = new System.Windows.Forms.Button();
            this.gbFechayHora = new System.Windows.Forms.GroupBox();
            this.dtFechaHora = new System.Windows.Forms.DateTimePicker();
            this.lbRegistro = new System.Windows.Forms.Label();
            this.ckPresento = new System.Windows.Forms.CheckBox();
            this.lbConsultaRegistrada = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbMotivo.SuspendLayout();
            this.gbFechayHora.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(259, 436);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 49;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // gbMotivo
            // 
            this.gbMotivo.Controls.Add(this.txtSintomas);
            this.gbMotivo.Controls.Add(this.label2);
            this.gbMotivo.Controls.Add(this.label1);
            this.gbMotivo.Controls.Add(this.txtEnfermedades);
            this.gbMotivo.Location = new System.Drawing.Point(9, 119);
            this.gbMotivo.Name = "gbMotivo";
            this.gbMotivo.Size = new System.Drawing.Size(421, 261);
            this.gbMotivo.TabIndex = 48;
            this.gbMotivo.TabStop = false;
            this.gbMotivo.Text = "Ingrese el diagnóstico del paciente";
            // 
            // txtSintomas
            // 
            this.txtSintomas.Location = new System.Drawing.Point(27, 158);
            this.txtSintomas.Multiline = true;
            this.txtSintomas.Name = "txtSintomas";
            this.txtSintomas.Size = new System.Drawing.Size(368, 87);
            this.txtSintomas.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Síntomas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diagnóstico";
            // 
            // txtEnfermedades
            // 
            this.txtEnfermedades.Location = new System.Drawing.Point(27, 43);
            this.txtEnfermedades.Multiline = true;
            this.txtEnfermedades.Name = "txtEnfermedades";
            this.txtEnfermedades.Size = new System.Drawing.Size(368, 87);
            this.txtEnfermedades.TabIndex = 3;
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(107, 436);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 47;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click_1);
            // 
            // gbFechayHora
            // 
            this.gbFechayHora.Controls.Add(this.dtFechaHora);
            this.gbFechayHora.Location = new System.Drawing.Point(9, 45);
            this.gbFechayHora.Name = "gbFechayHora";
            this.gbFechayHora.Size = new System.Drawing.Size(421, 68);
            this.gbFechayHora.TabIndex = 46;
            this.gbFechayHora.TabStop = false;
            this.gbFechayHora.Text = "Ingrese Fecha y Hora de atención";
            // 
            // dtFechaHora
            // 
            this.dtFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtFechaHora.Location = new System.Drawing.Point(98, 28);
            this.dtFechaHora.MaxDate = new System.DateTime(2170, 12, 31, 0, 0, 0, 0);
            this.dtFechaHora.MinDate = new System.DateTime(1990, 12, 31, 0, 0, 0, 0);
            this.dtFechaHora.Name = "dtFechaHora";
            this.dtFechaHora.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtFechaHora.Size = new System.Drawing.Size(200, 20);
            this.dtFechaHora.TabIndex = 0;
            this.dtFechaHora.Value = new System.DateTime(2016, 10, 20, 12, 30, 0, 0);
            // 
            // lbRegistro
            // 
            this.lbRegistro.AutoSize = true;
            this.lbRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistro.Location = new System.Drawing.Point(59, 9);
            this.lbRegistro.Name = "lbRegistro";
            this.lbRegistro.Size = new System.Drawing.Size(285, 20);
            this.lbRegistro.TabIndex = 45;
            this.lbRegistro.Text = "Registre resultado de atención médica:";
            // 
            // ckPresento
            // 
            this.ckPresento.AutoSize = true;
            this.ckPresento.Location = new System.Drawing.Point(152, 386);
            this.ckPresento.Name = "ckPresento";
            this.ckPresento.Size = new System.Drawing.Size(155, 17);
            this.ckPresento.TabIndex = 50;
            this.ckPresento.Text = "El paciente no se presentó ";
            this.ckPresento.UseVisualStyleBackColor = true;
            // 
            // lbConsultaRegistrada
            // 
            this.lbConsultaRegistrada.AutoSize = true;
            this.lbConsultaRegistrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConsultaRegistrada.ForeColor = System.Drawing.Color.Green;
            this.lbConsultaRegistrada.Location = new System.Drawing.Point(105, 406);
            this.lbConsultaRegistrada.Name = "lbConsultaRegistrada";
            this.lbConsultaRegistrada.Size = new System.Drawing.Size(254, 15);
            this.lbConsultaRegistrada.TabIndex = 51;
            this.lbConsultaRegistrada.Text = "Consulta registrada satisfactoriamente";
            this.lbConsultaRegistrada.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 474);
            this.Controls.Add(this.lbConsultaRegistrada);
            this.Controls.Add(this.ckPresento);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.gbMotivo);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.gbFechayHora);
            this.Controls.Add(this.lbRegistro);
            this.Name = "RegistroResultado";
            this.Text = "Registro_Resultado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbMotivo.ResumeLayout(false);
            this.gbMotivo.PerformLayout();
            this.gbFechayHora.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.GroupBox gbMotivo;
        private System.Windows.Forms.TextBox txtSintomas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnfermedades;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.GroupBox gbFechayHora;
        private System.Windows.Forms.DateTimePicker dtFechaHora;
        private System.Windows.Forms.Label lbRegistro;
        private System.Windows.Forms.CheckBox ckPresento;
        private System.Windows.Forms.Label lbConsultaRegistrada;
        private System.Windows.Forms.Timer timer1;
    }
}