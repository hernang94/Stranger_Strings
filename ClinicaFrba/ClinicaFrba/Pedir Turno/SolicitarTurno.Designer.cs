namespace ClinicaFrba.Pedir_Turno
{
    partial class formSolicitarTurno
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
            this.lbEspecialidad = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.gbBuscarMedico = new System.Windows.Forms.GroupBox();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.lbProfesionales = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHorariosDisp = new System.Windows.Forms.ComboBox();
            this.lbHorariosDisp = new System.Windows.Forms.Label();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.lbFechasDisp = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.gbBuscarMedico.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEspecialidad
            // 
            this.lbEspecialidad.AutoSize = true;
            this.lbEspecialidad.Location = new System.Drawing.Point(20, 27);
            this.lbEspecialidad.Name = "lbEspecialidad";
            this.lbEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lbEspecialidad.TabIndex = 0;
            this.lbEspecialidad.Text = "Especialidad";
            this.lbEspecialidad.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(153, 24);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cbEspecialidad.TabIndex = 1;
            this.cbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidad_SelectedIndexChanged);
            // 
            // gbBuscarMedico
            // 
            this.gbBuscarMedico.Controls.Add(this.cbProfesionales);
            this.gbBuscarMedico.Controls.Add(this.lbProfesionales);
            this.gbBuscarMedico.Controls.Add(this.lbEspecialidad);
            this.gbBuscarMedico.Controls.Add(this.cbEspecialidad);
            this.gbBuscarMedico.Location = new System.Drawing.Point(12, 12);
            this.gbBuscarMedico.Name = "gbBuscarMedico";
            this.gbBuscarMedico.Size = new System.Drawing.Size(312, 108);
            this.gbBuscarMedico.TabIndex = 3;
            this.gbBuscarMedico.TabStop = false;
            this.gbBuscarMedico.Text = "Seleccione el profesional";
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(153, 63);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(121, 21);
            this.cbProfesionales.TabIndex = 3;
            this.cbProfesionales.SelectedIndexChanged += new System.EventHandler(this.cbProfesionales_SelectedIndexChanged);
            // 
            // lbProfesionales
            // 
            this.lbProfesionales.AutoSize = true;
            this.lbProfesionales.Location = new System.Drawing.Point(20, 66);
            this.lbProfesionales.Name = "lbProfesionales";
            this.lbProfesionales.Size = new System.Drawing.Size(70, 13);
            this.lbProfesionales.TabIndex = 2;
            this.lbProfesionales.Text = "Profesionales";
            this.lbProfesionales.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHorariosDisp);
            this.groupBox1.Controls.Add(this.lbHorariosDisp);
            this.groupBox1.Controls.Add(this.cbFecha);
            this.groupBox1.Controls.Add(this.lbFechasDisp);
            this.groupBox1.Location = new System.Drawing.Point(12, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el turno";
            // 
            // cbHorariosDisp
            // 
            this.cbHorariosDisp.FormattingEnabled = true;
            this.cbHorariosDisp.Location = new System.Drawing.Point(153, 61);
            this.cbHorariosDisp.Name = "cbHorariosDisp";
            this.cbHorariosDisp.Size = new System.Drawing.Size(121, 21);
            this.cbHorariosDisp.TabIndex = 6;
            this.cbHorariosDisp.SelectedIndexChanged += new System.EventHandler(this.cbHorariosDisp_SelectedIndexChanged);
            // 
            // lbHorariosDisp
            // 
            this.lbHorariosDisp.AutoSize = true;
            this.lbHorariosDisp.Location = new System.Drawing.Point(20, 64);
            this.lbHorariosDisp.Name = "lbHorariosDisp";
            this.lbHorariosDisp.Size = new System.Drawing.Size(101, 13);
            this.lbHorariosDisp.TabIndex = 5;
            this.lbHorariosDisp.Text = "Horarios disponibles";
            this.lbHorariosDisp.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // cbFecha
            // 
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(153, 23);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(121, 21);
            this.cbFecha.TabIndex = 4;
            this.cbFecha.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // lbFechasDisp
            // 
            this.lbFechasDisp.AutoSize = true;
            this.lbFechasDisp.Location = new System.Drawing.Point(20, 26);
            this.lbFechasDisp.Name = "lbFechasDisp";
            this.lbFechasDisp.Size = new System.Drawing.Size(97, 13);
            this.lbFechasDisp.TabIndex = 0;
            this.lbFechasDisp.Text = "Fechas disponibles";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(193, 266);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 5;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(68, 266);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(79, 23);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // formSolicitarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 301);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbBuscarMedico);
            this.Name = "formSolicitarTurno";
            this.Text = "Solicitar Turno";
            this.Load += new System.EventHandler(this.formSolicitarTurno_Load);
            this.gbBuscarMedico.ResumeLayout(false);
            this.gbBuscarMedico.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbEspecialidad;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.GroupBox gbBuscarMedico;
        private System.Windows.Forms.Label lbProfesionales;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.Label lbFechasDisp;
        private System.Windows.Forms.Label lbHorariosDisp;
        private System.Windows.Forms.ComboBox cbHorariosDisp;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
    }
}