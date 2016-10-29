namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelarAtencionMedico
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.nudHasta = new System.Windows.Forms.NumericUpDown();
            this.nudDesde = new System.Windows.Forms.NumericUpDown();
            this.lbHoraHasta = new System.Windows.Forms.Label();
            this.lbHoraDesde = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDiaCompleto = new System.Windows.Forms.ComboBox();
            this.lbDiaCompleto = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.gbMotivo = new System.Windows.Forms.GroupBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTurnosCancelados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesde)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbMotivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(27, 27);
            this.monthCalendar1.MinDate = new System.DateTime(2000, 10, 27, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // nudHasta
            // 
            this.nudHasta.Location = new System.Drawing.Point(143, 234);
            this.nudHasta.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHasta.Name = "nudHasta";
            this.nudHasta.Size = new System.Drawing.Size(42, 20);
            this.nudHasta.TabIndex = 3;
            this.nudHasta.Visible = false;
            this.nudHasta.ValueChanged += new System.EventHandler(this.nudHasta_ValueChanged);
            // 
            // nudDesde
            // 
            this.nudDesde.Location = new System.Drawing.Point(143, 198);
            this.nudDesde.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudDesde.Name = "nudDesde";
            this.nudDesde.Size = new System.Drawing.Size(42, 20);
            this.nudDesde.TabIndex = 2;
            this.nudDesde.Visible = false;
            this.nudDesde.ValueChanged += new System.EventHandler(this.nudDesde_ValueChanged);
            // 
            // lbHoraHasta
            // 
            this.lbHoraHasta.AutoSize = true;
            this.lbHoraHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraHasta.Location = new System.Drawing.Point(56, 234);
            this.lbHoraHasta.Name = "lbHoraHasta";
            this.lbHoraHasta.Size = new System.Drawing.Size(67, 15);
            this.lbHoraHasta.TabIndex = 1;
            this.lbHoraHasta.Text = "Hora hasta";
            this.lbHoraHasta.Visible = false;
            this.lbHoraHasta.Click += new System.EventHandler(this.lbHoraHasta_Click);
            // 
            // lbHoraDesde
            // 
            this.lbHoraDesde.AutoSize = true;
            this.lbHoraDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraDesde.Location = new System.Drawing.Point(56, 198);
            this.lbHoraDesde.Name = "lbHoraDesde";
            this.lbHoraDesde.Size = new System.Drawing.Size(71, 15);
            this.lbHoraDesde.TabIndex = 0;
            this.lbHoraDesde.Text = "Hora desde";
            this.lbHoraDesde.Visible = false;
            this.lbHoraDesde.Click += new System.EventHandler(this.ldHoraDesde_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDiaCompleto);
            this.groupBox1.Controls.Add(this.lbDiaCompleto);
            this.groupBox1.Controls.Add(this.nudHasta);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.nudDesde);
            this.groupBox1.Controls.Add(this.lbHoraHasta);
            this.groupBox1.Controls.Add(this.lbHoraDesde);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 267);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione fecha y/o período a cancelar";
            // 
            // cbDiaCompleto
            // 
            this.cbDiaCompleto.AllowDrop = true;
            this.cbDiaCompleto.FormattingEnabled = true;
            this.cbDiaCompleto.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cbDiaCompleto.Location = new System.Drawing.Point(172, 215);
            this.cbDiaCompleto.Name = "cbDiaCompleto";
            this.cbDiaCompleto.Size = new System.Drawing.Size(47, 21);
            this.cbDiaCompleto.TabIndex = 5;
            this.cbDiaCompleto.SelectedIndexChanged += new System.EventHandler(this.cbDiaCompleto_SelectedIndexChanged);
            // 
            // lbDiaCompleto
            // 
            this.lbDiaCompleto.AutoSize = true;
            this.lbDiaCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiaCompleto.Location = new System.Drawing.Point(24, 215);
            this.lbDiaCompleto.Name = "lbDiaCompleto";
            this.lbDiaCompleto.Size = new System.Drawing.Size(144, 15);
            this.lbDiaCompleto.TabIndex = 4;
            this.lbDiaCompleto.Text = "¿Cancelar día completo?";
            this.lbDiaCompleto.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(6, 19);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(238, 134);
            this.txtMotivo.TabIndex = 3;
            // 
            // gbMotivo
            // 
            this.gbMotivo.Controls.Add(this.txtMotivo);
            this.gbMotivo.Location = new System.Drawing.Point(12, 279);
            this.gbMotivo.Name = "gbMotivo";
            this.gbMotivo.Size = new System.Drawing.Size(250, 159);
            this.gbMotivo.TabIndex = 4;
            this.gbMotivo.TabStop = false;
            this.gbMotivo.Text = "Ingrese el motivo de su cancelación";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(165, 484);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 43;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(19, 484);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 42;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTurnosCancelados
            // 
            this.lbTurnosCancelados.AutoSize = true;
            this.lbTurnosCancelados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosCancelados.ForeColor = System.Drawing.Color.Green;
            this.lbTurnosCancelados.Location = new System.Drawing.Point(4, 450);
            this.lbTurnosCancelados.Name = "lbTurnosCancelados";
            this.lbTurnosCancelados.Size = new System.Drawing.Size(258, 15);
            this.lbTurnosCancelados.TabIndex = 44;
            this.lbTurnosCancelados.Text = "Turno/s cancelado/s satisfactoriamente";
            this.lbTurnosCancelados.Visible = false;
            // 
            // CancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 523);
            this.Controls.Add(this.lbTurnosCancelados);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.gbMotivo);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelarAtencionMedico";
            this.Text = "Cancelar atenciones";
            this.Load += new System.EventHandler(this.CancelarAtencionMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesde)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMotivo.ResumeLayout(false);
            this.gbMotivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown nudHasta;
        private System.Windows.Forms.NumericUpDown nudDesde;
        private System.Windows.Forms.Label lbHoraHasta;
        private System.Windows.Forms.Label lbHoraDesde;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.GroupBox gbMotivo;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTurnosCancelados;
        private System.Windows.Forms.Label lbDiaCompleto;
        private System.Windows.Forms.ComboBox cbDiaCompleto;

    }
}