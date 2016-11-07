namespace ClinicaFrba.Registro_Resultado
{
    partial class SeleccionTurno
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
            this.lbSeleccionTurno = new System.Windows.Forms.Label();
            this.dtgTurnos = new System.Windows.Forms.DataGridView();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSeleccionTurno
            // 
            this.lbSeleccionTurno.AutoSize = true;
            this.lbSeleccionTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccionTurno.Location = new System.Drawing.Point(12, 18);
            this.lbSeleccionTurno.Name = "lbSeleccionTurno";
            this.lbSeleccionTurno.Size = new System.Drawing.Size(219, 20);
            this.lbSeleccionTurno.TabIndex = 41;
            this.lbSeleccionTurno.Text = "Seleccione el turno a registrar";
            // 
            // dtgTurnos
            // 
            this.dtgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTurnos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgTurnos.Location = new System.Drawing.Point(12, 51);
            this.dtgTurnos.Name = "dtgTurnos";
            this.dtgTurnos.Size = new System.Drawing.Size(456, 149);
            this.dtgTurnos.TabIndex = 40;
            this.dtgTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTurnos_CellContentClick);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(275, 230);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 43;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(129, 230);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 42;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // SeleccionTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 267);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.lbSeleccionTurno);
            this.Controls.Add(this.dtgTurnos);
            this.Name = "SeleccionTurno";
            this.Text = "SeleccionTurno";
            this.Load += new System.EventHandler(this.SeleccionTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSeleccionTurno;
        private System.Windows.Forms.DataGridView dtgTurnos;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btVolver;
    }
}