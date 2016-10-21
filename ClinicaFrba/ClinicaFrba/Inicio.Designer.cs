namespace ClinicaFrba
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbBienvenido = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbContraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btIniciarSesión = new System.Windows.Forms.Button();
            this.lbContraseñaIncorrecta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbBienvenido
            // 
            this.lbBienvenido.AutoSize = true;
            this.lbBienvenido.BackColor = System.Drawing.SystemColors.Control;
            this.lbBienvenido.Font = new System.Drawing.Font("Gabriola", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBienvenido.Location = new System.Drawing.Point(202, 18);
            this.lbBienvenido.Name = "lbBienvenido";
            this.lbBienvenido.Size = new System.Drawing.Size(382, 68);
            this.lbBienvenido.TabIndex = 0;
            this.lbBienvenido.Text = "Bienvenido a la Clínica FRBA";
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(240, 144);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbUsuario.Size = new System.Drawing.Size(79, 24);
            this.lbUsuario.TabIndex = 1;
            this.lbUsuario.Text = "Usuario:";
            this.lbUsuario.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbContraseña
            // 
            this.lbContraseña.AutoSize = true;
            this.lbContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContraseña.Location = new System.Drawing.Point(236, 191);
            this.lbContraseña.Name = "lbContraseña";
            this.lbContraseña.Size = new System.Drawing.Size(111, 24);
            this.lbContraseña.TabIndex = 2;
            this.lbContraseña.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtUsuario.Location = new System.Drawing.Point(394, 148);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsuario.Size = new System.Drawing.Size(145, 20);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtContraseña
            // 
            this.txtContraseña.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtContraseña.Location = new System.Drawing.Point(394, 191);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(145, 20);
            this.txtContraseña.TabIndex = 4;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // btIniciarSesión
            // 
            this.btIniciarSesión.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btIniciarSesión.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIniciarSesión.Location = new System.Drawing.Point(315, 281);
            this.btIniciarSesión.Name = "btIniciarSesión";
            this.btIniciarSesión.Size = new System.Drawing.Size(142, 43);
            this.btIniciarSesión.TabIndex = 6;
            this.btIniciarSesión.Text = "Iniciar Sesión";
            this.btIniciarSesión.UseVisualStyleBackColor = false;
            this.btIniciarSesión.Click += new System.EventHandler(this.btIniciarSesión_Click);
            // 
            // lbContraseñaIncorrecta
            // 
            this.lbContraseñaIncorrecta.AutoSize = true;
            this.lbContraseñaIncorrecta.ForeColor = System.Drawing.Color.Red;
            this.lbContraseñaIncorrecta.Location = new System.Drawing.Point(290, 241);
            this.lbContraseñaIncorrecta.Name = "lbContraseñaIncorrecta";
            this.lbContraseñaIncorrecta.Size = new System.Drawing.Size(196, 13);
            this.lbContraseñaIncorrecta.TabIndex = 8;
            this.lbContraseñaIncorrecta.Text = "El usuario o la contraseña es incorrecta.";
            this.lbContraseñaIncorrecta.Visible = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(804, 366);
            this.Controls.Add(this.lbContraseñaIncorrecta);
            this.Controls.Add(this.btIniciarSesión);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lbContraseña);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.lbBienvenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Inicio";
            this.Text = "Clínica FRBA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBienvenido;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btIniciarSesión;
        private System.Windows.Forms.Label lbContraseñaIncorrecta;
    }
}

