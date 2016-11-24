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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cbDiaCompleto = new System.Windows.Forms.ComboBox();
            this.lbFechaHasta = new System.Windows.Forms.Label();
            this.lbFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.gbMotivo = new System.Windows.Forms.GroupBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTurnosCancelados = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbMotivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(11, 56);
            this.monthCalendar1.MinDate = new System.DateTime(2000, 10, 27, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaDesde);
            this.groupBox1.Controls.Add(this.cbDiaCompleto);
            this.groupBox1.Controls.Add(this.lbFechaHasta);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.lbFechaDesde);
            this.groupBox1.Controls.Add(this.dtpFechaHasta);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 235);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione fecha y/o período a cancelar";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "";
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(125, 89);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaDesde.TabIndex = 48;
            this.dtpFechaDesde.Visible = false;
            // 
            // cbDiaCompleto
            // 
            this.cbDiaCompleto.AllowDrop = true;
            this.cbDiaCompleto.FormattingEnabled = true;
            this.cbDiaCompleto.Items.AddRange(new object[] {
            "Fecha a cancelar",
            "Período a cancelar"});
            this.cbDiaCompleto.Location = new System.Drawing.Point(45, 22);
            this.cbDiaCompleto.Name = "cbDiaCompleto";
            this.cbDiaCompleto.Size = new System.Drawing.Size(147, 21);
            this.cbDiaCompleto.TabIndex = 5;
            this.cbDiaCompleto.Text = "Tipo de cancelación";
            this.cbDiaCompleto.SelectedIndexChanged += new System.EventHandler(this.cbDiaCompleto_SelectedIndexChanged);
            // 
            // lbFechaHasta
            // 
            this.lbFechaHasta.AutoSize = true;
            this.lbFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaHasta.Location = new System.Drawing.Point(19, 172);
            this.lbFechaHasta.Name = "lbFechaHasta";
            this.lbFechaHasta.Size = new System.Drawing.Size(74, 15);
            this.lbFechaHasta.TabIndex = 47;
            this.lbFechaHasta.Text = "Fecha hasta";
            this.lbFechaHasta.Visible = false;
            // 
            // lbFechaDesde
            // 
            this.lbFechaDesde.AutoSize = true;
            this.lbFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaDesde.Location = new System.Drawing.Point(19, 93);
            this.lbFechaDesde.Name = "lbFechaDesde";
            this.lbFechaDesde.Size = new System.Drawing.Size(78, 15);
            this.lbFechaDesde.TabIndex = 46;
            this.lbFechaDesde.Text = "Fecha desde";
            this.lbFechaDesde.Visible = false;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "";
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(125, 168);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaHasta.TabIndex = 45;
            this.dtpFechaHasta.Visible = false;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(6, 19);
            this.txtMotivo.MaxLength = 250;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(238, 134);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // gbMotivo
            // 
            this.gbMotivo.Controls.Add(this.txtMotivo);
            this.gbMotivo.Location = new System.Drawing.Point(12, 248);
            this.gbMotivo.Name = "gbMotivo";
            this.gbMotivo.Size = new System.Drawing.Size(250, 159);
            this.gbMotivo.TabIndex = 4;
            this.gbMotivo.TabStop = false;
            this.gbMotivo.Text = "Ingrese el motivo de su cancelación";
            this.gbMotivo.Enter += new System.EventHandler(this.gbMotivo_Enter);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(165, 453);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 43;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(19, 453);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 42;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTurnosCancelados
            // 
            this.lbTurnosCancelados.AutoSize = true;
            this.lbTurnosCancelados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosCancelados.ForeColor = System.Drawing.Color.Green;
            this.lbTurnosCancelados.Location = new System.Drawing.Point(6, 419);
            this.lbTurnosCancelados.Name = "lbTurnosCancelados";
            this.lbTurnosCancelados.Size = new System.Drawing.Size(258, 15);
            this.lbTurnosCancelados.TabIndex = 44;
            this.lbTurnosCancelados.Text = "Turno/s cancelado/s satisfactoriamente";
            this.lbTurnosCancelados.Visible = false;
            this.lbTurnosCancelados.Click += new System.EventHandler(this.lbTurnosCancelados_Click);
            // 
            // CancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 487);
            this.Controls.Add(this.lbTurnosCancelados);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.gbMotivo);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelarAtencionMedico";
            this.Text = "Cancelar atenciones";
            this.Load += new System.EventHandler(this.CancelarAtencionMedico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMotivo.ResumeLayout(false);
            this.gbMotivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.GroupBox gbMotivo;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTurnosCancelados;
        private System.Windows.Forms.ComboBox cbDiaCompleto;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lbFechaDesde;
        private System.Windows.Forms.Label lbFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;

    }
}