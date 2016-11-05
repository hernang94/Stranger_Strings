namespace ClinicaFrba.Listados
{
    partial class Form1
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
            this.dtgCliente = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBMDoc = new System.Windows.Forms.TextBox();
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.cbTipoListado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCliente
            // 
            this.dtgCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCliente.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgCliente.Location = new System.Drawing.Point(2, 117);
            this.dtgCliente.Name = "dtgCliente";
            this.dtgCliente.Size = new System.Drawing.Size(350, 132);
            this.dtgCliente.TabIndex = 50;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(127, 76);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 23);
            this.btnBuscar.TabIndex = 49;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtBMDoc
            // 
            this.txtBMDoc.Location = new System.Drawing.Point(146, 39);
            this.txtBMDoc.Name = "txtBMDoc";
            this.txtBMDoc.Size = new System.Drawing.Size(58, 20);
            this.txtBMDoc.TabIndex = 47;
            // 
            // cbSemestre
            // 
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbSemestre.Location = new System.Drawing.Point(225, 39);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(120, 21);
            this.cbSemestre.TabIndex = 51;
            // 
            // cbTipoListado
            // 
            this.cbTipoListado.FormattingEnabled = true;
            this.cbTipoListado.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbTipoListado.Location = new System.Drawing.Point(8, 39);
            this.cbTipoListado.Name = "cbTipoListado";
            this.cbTipoListado.Size = new System.Drawing.Size(119, 21);
            this.cbTipoListado.TabIndex = 52;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 305);
            this.Controls.Add(this.cbTipoListado);
            this.Controls.Add(this.cbSemestre);
            this.Controls.Add(this.dtgCliente);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBMDoc);
            this.Name = "Form1";
            this.Text = "Listados_Estadisticos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBMDoc;
        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.ComboBox cbTipoListado;
    }
}