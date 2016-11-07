namespace ClinicaFrba
{
    partial class SeleccionarProfesional
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
            this.lbSelUser = new System.Windows.Forms.Label();
            this.cbSeleccionProfesional = new System.Windows.Forms.ComboBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSelUser
            // 
            this.lbSelUser.AutoSize = true;
            this.lbSelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelUser.Location = new System.Drawing.Point(30, 18);
            this.lbSelUser.Name = "lbSelUser";
            this.lbSelUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSelUser.Size = new System.Drawing.Size(227, 24);
            this.lbSelUser.TabIndex = 2;
            this.lbSelUser.Text = "Seleccione al Profesional:";
            this.lbSelUser.Click += new System.EventHandler(this.lbUsuario_Click);
            // 
            // cbSeleccionProfesional
            // 
            this.cbSeleccionProfesional.FormattingEnabled = true;
            this.cbSeleccionProfesional.Location = new System.Drawing.Point(49, 63);
            this.cbSeleccionProfesional.Name = "cbSeleccionProfesional";
            this.cbSeleccionProfesional.Size = new System.Drawing.Size(186, 21);
            this.cbSeleccionProfesional.TabIndex = 5;
            this.cbSeleccionProfesional.SelectedIndexChanged += new System.EventHandler(this.cbSeleccionProfesional_SelectedIndexChanged);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(97, 102);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 6;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // SeleccionarProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 137);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.cbSeleccionProfesional);
            this.Controls.Add(this.lbSelUser);
            this.Name = "SeleccionarProfesional";
            this.Text = "SeleccionarProfesional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSelUser;
        private System.Windows.Forms.ComboBox cbSeleccionProfesional;
        private System.Windows.Forms.Button btAceptar;
    }
}