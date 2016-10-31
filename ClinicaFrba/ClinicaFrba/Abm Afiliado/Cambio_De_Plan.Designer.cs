namespace ClinicaFrba.Abm_Afiliado
{
    partial class Cambio_De_Plan
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
            this.lbMotivo = new System.Windows.Forms.Label();
            this.tbMotivo = new System.Windows.Forms.TextBox();
            this.lbTurnoCancelado = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMotivo
            // 
            this.lbMotivo.AutoSize = true;
            this.lbMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMotivo.Location = new System.Drawing.Point(-7, 37);
            this.lbMotivo.Name = "lbMotivo";
            this.lbMotivo.Size = new System.Drawing.Size(260, 20);
            this.lbMotivo.TabIndex = 49;
            this.lbMotivo.Text = "Ingrese el motivo de su cancelación";
            // 
            // tbMotivo
            // 
            this.tbMotivo.Location = new System.Drawing.Point(12, 147);
            this.tbMotivo.MaxLength = 225;
            this.tbMotivo.Multiline = true;
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(256, 34);
            this.tbMotivo.TabIndex = 48;
            // 
            // lbTurnoCancelado
            // 
            this.lbTurnoCancelado.AutoSize = true;
            this.lbTurnoCancelado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnoCancelado.ForeColor = System.Drawing.Color.Green;
            this.lbTurnoCancelado.Location = new System.Drawing.Point(20, 194);
            this.lbTurnoCancelado.Name = "lbTurnoCancelado";
            this.lbTurnoCancelado.Size = new System.Drawing.Size(244, 15);
            this.lbTurnoCancelado.TabIndex = 47;
            this.lbTurnoCancelado.Text = "Su turno ha sido cancelado con éxito";
            this.lbTurnoCancelado.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(222, 224);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(10, 15);
            this.btAceptar.TabIndex = 46;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(57, 224);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(10, 15);
            this.btVolver.TabIndex = 45;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            // 
            // Cambio_De_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbMotivo);
            this.Controls.Add(this.tbMotivo);
            this.Controls.Add(this.lbTurnoCancelado);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Name = "Cambio_De_Plan";
            this.Text = "Cambio de Plan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMotivo;
        private System.Windows.Forms.TextBox tbMotivo;
        private System.Windows.Forms.Label lbTurnoCancelado;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btVolver;
    }
}