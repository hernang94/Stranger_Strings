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
            this.btVolver = new System.Windows.Forms.Button();
            this.btRegistrar = new System.Windows.Forms.Button();
            this.lbTurno = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.lbFecha = new System.Windows.Forms.Label();
            this.dtgTurno = new System.Windows.Forms.DataGridView();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lbEspecialidad = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurno)).BeginInit();
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
            this.lbProfesional.Location = new System.Drawing.Point(53, 51);
            this.lbProfesional.Name = "lbProfesional";
            this.lbProfesional.Size = new System.Drawing.Size(115, 13);
            this.lbProfesional.TabIndex = 37;
            this.lbProfesional.Text = "Seleccione Profesional";
            // 
            // cbProfesional
            // 
            this.cbProfesional.FormattingEnabled = true;
            this.cbProfesional.Location = new System.Drawing.Point(246, 51);
            this.cbProfesional.Name = "cbProfesional";
            this.cbProfesional.Size = new System.Drawing.Size(121, 21);
            this.cbProfesional.TabIndex = 38;
            this.cbProfesional.SelectedIndexChanged += new System.EventHandler(this.cbProfesional_SelectedIndexChanged);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(94, 308);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 45;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btRegistrar
            // 
            this.btRegistrar.Location = new System.Drawing.Point(278, 308);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btRegistrar.TabIndex = 46;
            this.btRegistrar.Text = "Registrar";
            this.btRegistrar.UseVisualStyleBackColor = true;
            // 
            // lbTurno
            // 
            this.lbTurno.AutoSize = true;
            this.lbTurno.Location = new System.Drawing.Point(30, 152);
            this.lbTurno.Name = "lbTurno";
            this.lbTurno.Size = new System.Drawing.Size(91, 13);
            this.lbTurno.TabIndex = 48;
            this.lbTurno.Text = "Seleccione Turno";
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(246, 103);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(121, 20);
            this.dateFecha.TabIndex = 43;
            this.dateFecha.Value = new System.DateTime(2016, 11, 4, 12, 0, 0, 0);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(53, 109);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(116, 13);
            this.lbFecha.TabIndex = 44;
            this.lbFecha.Text = "Ingrese fecha del turno";
            // 
            // dtgTurno
            // 
            this.dtgTurno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTurno.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgTurno.Location = new System.Drawing.Point(33, 168);
            this.dtgTurno.Name = "dtgTurno";
            this.dtgTurno.Size = new System.Drawing.Size(398, 117);
            this.dtgTurno.TabIndex = 49;
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(246, 76);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cbEspecialidad.TabIndex = 50;
            this.cbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidad_SelectedIndexChanged);
            // 
            // lbEspecialidad
            // 
            this.lbEspecialidad.AutoSize = true;
            this.lbEspecialidad.Location = new System.Drawing.Point(53, 79);
            this.lbEspecialidad.Name = "lbEspecialidad";
            this.lbEspecialidad.Size = new System.Drawing.Size(123, 13);
            this.lbEspecialidad.TabIndex = 51;
            this.lbEspecialidad.Text = "Seleccione Especialidad";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(192, 139);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 52;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // Registro_Llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 343);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.lbEspecialidad);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.dtgTurno);
            this.Controls.Add(this.lbTurno);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.cbProfesional);
            this.Controls.Add(this.lbProfesional);
            this.Controls.Add(this.lbLlegada);
            this.Name = "Registro_Llegada";
            this.Text = "Registrar_ Llegada";
            this.Load += new System.EventHandler(this.Registro_Llegada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLlegada;
        private System.Windows.Forms.Label lbProfesional;
        private System.Windows.Forms.ComboBox cbProfesional;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btRegistrar;
        private System.Windows.Forms.Label lbTurno;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.DataGridView dtgTurno;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.Label lbEspecialidad;
        private System.Windows.Forms.Button btBuscar;
    }
}