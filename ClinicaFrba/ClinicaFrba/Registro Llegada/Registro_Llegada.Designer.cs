namespace ClinicaFrba.Registro_Llegada
{
    partial class Registro_Llegada
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
            this.lbLlegada = new System.Windows.Forms.Label();
            this.lbProfesional = new System.Windows.Forms.Label();
            this.cbProfesional = new System.Windows.Forms.ComboBox();
            this.lbBono = new System.Windows.Forms.Label();
            this.cbBono = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbDoc = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.lbFecha = new System.Windows.Forms.Label();
            this.btVolver = new System.Windows.Forms.Button();
            this.btRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLlegada
            // 
            this.lbLlegada.AutoSize = true;
            this.lbLlegada.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLlegada.Location = new System.Drawing.Point(29, 9);
            this.lbLlegada.Name = "lbLlegada";
            this.lbLlegada.Size = new System.Drawing.Size(294, 23);
            this.lbLlegada.TabIndex = 36;
            this.lbLlegada.Text = "Registre la llegada de un paciente";
            // 
            // lbProfesional
            // 
            this.lbProfesional.AutoSize = true;
            this.lbProfesional.Location = new System.Drawing.Point(42, 52);
            this.lbProfesional.Name = "lbProfesional";
            this.lbProfesional.Size = new System.Drawing.Size(115, 13);
            this.lbProfesional.TabIndex = 37;
            this.lbProfesional.Text = "Seleccione Profesional";
            // 
            // cbProfesional
            // 
            this.cbProfesional.FormattingEnabled = true;
            this.cbProfesional.Location = new System.Drawing.Point(181, 49);
            this.cbProfesional.Name = "cbProfesional";
            this.cbProfesional.Size = new System.Drawing.Size(121, 21);
            this.cbProfesional.TabIndex = 38;
            // 
            // lbBono
            // 
            this.lbBono.AutoSize = true;
            this.lbBono.Location = new System.Drawing.Point(42, 88);
            this.lbBono.Name = "lbBono";
            this.lbBono.Size = new System.Drawing.Size(88, 13);
            this.lbBono.TabIndex = 39;
            this.lbBono.Text = "Seleccione Bono";
            // 
            // cbBono
            // 
            this.cbBono.FormattingEnabled = true;
            this.cbBono.Location = new System.Drawing.Point(181, 85);
            this.cbBono.Name = "cbBono";
            this.cbBono.Size = new System.Drawing.Size(121, 21);
            this.cbBono.TabIndex = 40;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 41;
            // 
            // lbDoc
            // 
            this.lbDoc.AutoSize = true;
            this.lbDoc.Location = new System.Drawing.Point(42, 125);
            this.lbDoc.Name = "lbDoc";
            this.lbDoc.Size = new System.Drawing.Size(101, 26);
            this.lbDoc.TabIndex = 42;
            this.lbDoc.Text = "Ingrese documento \r\ndel paciente";
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateFecha.Location = new System.Drawing.Point(181, 164);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(121, 20);
            this.dateFecha.TabIndex = 43;
            this.dateFecha.Value = new System.DateTime(2016, 11, 4, 12, 0, 0, 0);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(42, 171);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(72, 13);
            this.lbFecha.TabIndex = 44;
            this.lbFecha.Text = "Ingrese fecha";
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(68, 214);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 45;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            // 
            // btRegistrar
            // 
            this.btRegistrar.Location = new System.Drawing.Point(194, 214);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btRegistrar.TabIndex = 46;
            this.btRegistrar.Text = "Registrar";
            this.btRegistrar.UseVisualStyleBackColor = true;
            // 
            // Registro_Llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 262);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.lbDoc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbBono);
            this.Controls.Add(this.lbBono);
            this.Controls.Add(this.cbProfesional);
            this.Controls.Add(this.lbProfesional);
            this.Controls.Add(this.lbLlegada);
            this.Name = "Registro_Llegada";
            this.Text = "Registrar_ Llegada";
            this.Load += new System.EventHandler(this.Registro_Llegada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLlegada;
        private System.Windows.Forms.Label lbProfesional;
        private System.Windows.Forms.ComboBox cbProfesional;
        private System.Windows.Forms.Label lbBono;
        private System.Windows.Forms.ComboBox cbBono;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbDoc;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btRegistrar;
    }
}