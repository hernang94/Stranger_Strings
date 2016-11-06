namespace ClinicaFrba.AbmRol
{
    partial class AltaRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.cbProfesional = new System.Windows.Forms.CheckBox();
            this.cbAfiliado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el nombre del nuevo Rol";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(41, 55);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(235, 20);
            this.txtRol.TabIndex = 3;
            this.txtRol.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Location = new System.Drawing.Point(121, 81);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(89, 17);
            this.cbAdmin.TabIndex = 4;
            this.cbAdmin.Text = "Administrador";
            this.cbAdmin.UseVisualStyleBackColor = true;
            // 
            // cbProfesional
            // 
            this.cbProfesional.AutoSize = true;
            this.cbProfesional.Location = new System.Drawing.Point(121, 104);
            this.cbProfesional.Name = "cbProfesional";
            this.cbProfesional.Size = new System.Drawing.Size(78, 17);
            this.cbProfesional.TabIndex = 5;
            this.cbProfesional.Text = "Profesional";
            this.cbProfesional.UseVisualStyleBackColor = true;
            // 
            // cbAfiliado
            // 
            this.cbAfiliado.AutoSize = true;
            this.cbAfiliado.Location = new System.Drawing.Point(121, 127);
            this.cbAfiliado.Name = "cbAfiliado";
            this.cbAfiliado.Size = new System.Drawing.Size(60, 17);
            this.cbAfiliado.TabIndex = 6;
            this.cbAfiliado.Text = "Afiliado";
            this.cbAfiliado.UseVisualStyleBackColor = true;
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 225);
            this.Controls.Add(this.cbAfiliado);
            this.Controls.Add(this.cbProfesional);
            this.Controls.Add(this.cbAdmin);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "AltaRol";
            this.Text = "AltaRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.CheckBox cbProfesional;
        private System.Windows.Forms.CheckBox cbAfiliado;
    }
}