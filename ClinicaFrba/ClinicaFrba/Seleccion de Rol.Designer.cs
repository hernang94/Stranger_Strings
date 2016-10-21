namespace ClinicaFrba
{
    partial class Seleccion_de_Rol
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
            this.btAfiliado = new System.Windows.Forms.Button();
            this.btAdministrativo = new System.Windows.Forms.Button();
            this.btProfesional = new System.Windows.Forms.Button();
            this.picAfiliado = new System.Windows.Forms.PictureBox();
            this.picAdmin = new System.Windows.Forms.PictureBox();
            this.picProfesional = new System.Windows.Forms.PictureBox();
            this.lbSeleccionRol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAfiliado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfesional)).BeginInit();
            this.SuspendLayout();
            // 
            // btAfiliado
            // 
            this.btAfiliado.Location = new System.Drawing.Point(128, 91);
            this.btAfiliado.Name = "btAfiliado";
            this.btAfiliado.Size = new System.Drawing.Size(82, 23);
            this.btAfiliado.TabIndex = 0;
            this.btAfiliado.Text = "Afiliado";
            this.btAfiliado.UseVisualStyleBackColor = true;
            // 
            // btAdministrativo
            // 
            this.btAdministrativo.Location = new System.Drawing.Point(128, 141);
            this.btAdministrativo.Name = "btAdministrativo";
            this.btAdministrativo.Size = new System.Drawing.Size(82, 23);
            this.btAdministrativo.TabIndex = 1;
            this.btAdministrativo.Text = "Administrativo";
            this.btAdministrativo.UseVisualStyleBackColor = true;
            // 
            // btProfesional
            // 
            this.btProfesional.Location = new System.Drawing.Point(128, 188);
            this.btProfesional.Name = "btProfesional";
            this.btProfesional.Size = new System.Drawing.Size(82, 23);
            this.btProfesional.TabIndex = 2;
            this.btProfesional.Text = "Profesional";
            this.btProfesional.UseVisualStyleBackColor = true;
            // 
            // picAfiliado
            // 
            this.picAfiliado.Location = new System.Drawing.Point(50, 87);
            this.picAfiliado.Name = "picAfiliado";
            this.picAfiliado.Size = new System.Drawing.Size(37, 31);
            this.picAfiliado.TabIndex = 3;
            this.picAfiliado.TabStop = false;
            // 
            // picAdmin
            // 
            this.picAdmin.Location = new System.Drawing.Point(50, 135);
            this.picAdmin.Name = "picAdmin";
            this.picAdmin.Size = new System.Drawing.Size(37, 31);
            this.picAdmin.TabIndex = 4;
            this.picAdmin.TabStop = false;
            // 
            // picProfesional
            // 
            this.picProfesional.Location = new System.Drawing.Point(50, 182);
            this.picProfesional.Name = "picProfesional";
            this.picProfesional.Size = new System.Drawing.Size(37, 31);
            this.picProfesional.TabIndex = 5;
            this.picProfesional.TabStop = false;
            // 
            // lbSeleccionRol
            // 
            this.lbSeleccionRol.AutoSize = true;
            this.lbSeleccionRol.Font = new System.Drawing.Font("Gabriola", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccionRol.Location = new System.Drawing.Point(45, 20);
            this.lbSeleccionRol.Name = "lbSeleccionRol";
            this.lbSeleccionRol.Size = new System.Drawing.Size(184, 54);
            this.lbSeleccionRol.TabIndex = 6;
            this.lbSeleccionRol.Text = "Seleccione su rol";
            // 
            // Seleccion_de_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbSeleccionRol);
            this.Controls.Add(this.picProfesional);
            this.Controls.Add(this.picAdmin);
            this.Controls.Add(this.picAfiliado);
            this.Controls.Add(this.btProfesional);
            this.Controls.Add(this.btAdministrativo);
            this.Controls.Add(this.btAfiliado);
            this.Name = "Seleccion_de_Rol";
            this.Text = "Seleccion_de_Rol";
            ((System.ComponentModel.ISupportInitialize)(this.picAfiliado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfesional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAfiliado;
        private System.Windows.Forms.Button btAdministrativo;
        private System.Windows.Forms.Button btProfesional;
        private System.Windows.Forms.PictureBox picAfiliado;
        private System.Windows.Forms.PictureBox picAdmin;
        private System.Windows.Forms.PictureBox picProfesional;
        private System.Windows.Forms.Label lbSeleccionRol;
    }
}