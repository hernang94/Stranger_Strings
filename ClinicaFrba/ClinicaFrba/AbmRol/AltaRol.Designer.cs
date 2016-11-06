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
            this.ckListaFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(201, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 231);
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
            // ckListaFuncionalidades
            // 
            this.ckListaFuncionalidades.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ckListaFuncionalidades.FormattingEnabled = true;
            this.ckListaFuncionalidades.Location = new System.Drawing.Point(27, 114);
            this.ckListaFuncionalidades.Name = "ckListaFuncionalidades";
            this.ckListaFuncionalidades.Size = new System.Drawing.Size(265, 94);
            this.ckListaFuncionalidades.TabIndex = 7;
            this.ckListaFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.ckListaFuncionalidades_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Seleccione las funcionalidades";
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 278);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckListaFuncionalidades);
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
        private System.Windows.Forms.CheckedListBox ckListaFuncionalidades;
        private System.Windows.Forms.Label label2;
    }
}