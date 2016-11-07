namespace ClinicaFrba.Registrar_Agenda_Medico
{
    partial class Registro_Agenda
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpHoraDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraHasta = new System.Windows.Forms.DateTimePicker();
            this.lbAgendaRegistrada = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Profesional";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione Especialidad";
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(166, 13);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(121, 21);
            this.cbProfesionales.TabIndex = 2;
            this.cbProfesionales.SelectedIndexChanged += new System.EventHandler(this.cbProfesionales_SelectedIndexChanged);
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(166, 40);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cbEspecialidad.TabIndex = 3;
            this.cbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidad_SelectedIndexChanged);
            // 
            // cbDia
            // 
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado"});
            this.cbDia.Location = new System.Drawing.Point(166, 67);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(121, 21);
            this.cbDia.TabIndex = 4;
            this.cbDia.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seleccione dia";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hora desde";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hora hasta";
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.CustomFormat = "HH:mm";
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraDesde.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dtpHoraDesde.Location = new System.Drawing.Point(166, 94);
            this.dtpHoraDesde.MaxDate = new System.DateTime(2020, 1, 1, 19, 30, 0, 0);
            this.dtpHoraDesde.MinDate = new System.DateTime(1753, 1, 1, 7, 0, 0, 0);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.ShowUpDown = true;
            this.dtpHoraDesde.Size = new System.Drawing.Size(53, 20);
            this.dtpHoraDesde.TabIndex = 17;
            this.dtpHoraDesde.Value = new System.DateTime(2016, 11, 6, 7, 0, 0, 0);
            this.dtpHoraDesde.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.CustomFormat = "HH:mm";
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraHasta.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dtpHoraHasta.Location = new System.Drawing.Point(166, 120);
            this.dtpHoraHasta.MaxDate = new System.DateTime(2020, 1, 1, 20, 0, 0, 0);
            this.dtpHoraHasta.MinDate = new System.DateTime(1753, 1, 1, 7, 30, 0, 0);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.ShowUpDown = true;
            this.dtpHoraHasta.Size = new System.Drawing.Size(53, 20);
            this.dtpHoraHasta.TabIndex = 18;
            this.dtpHoraHasta.Value = new System.DateTime(2016, 11, 6, 7, 30, 0, 0);
            // 
            // lbAgendaRegistrada
            // 
            this.lbAgendaRegistrada.AutoSize = true;
            this.lbAgendaRegistrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgendaRegistrada.ForeColor = System.Drawing.Color.Green;
            this.lbAgendaRegistrada.Location = new System.Drawing.Point(40, 154);
            this.lbAgendaRegistrada.Name = "lbAgendaRegistrada";
            this.lbAgendaRegistrada.Size = new System.Drawing.Size(233, 16);
            this.lbAgendaRegistrada.TabIndex = 19;
            this.lbAgendaRegistrada.Text = "Agenda registrada exitosamente";
            this.lbAgendaRegistrada.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Registro_Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 220);
            this.Controls.Add(this.lbAgendaRegistrada);
            this.Controls.Add(this.dtpHoraHasta);
            this.Controls.Add(this.dtpHoraDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDia);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.cbProfesionales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registro_Agenda";
            this.Text = "Registrar agenda profesional";
            this.Load += new System.EventHandler(this.Registro_Agenda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpHoraDesde;
        private System.Windows.Forms.DateTimePicker dtpHoraHasta;
        private System.Windows.Forms.Label lbAgendaRegistrada;
        private System.Windows.Forms.Timer timer1;
    }
}