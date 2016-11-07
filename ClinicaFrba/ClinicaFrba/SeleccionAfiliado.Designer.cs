namespace ClinicaFrba
{
    partial class SeleccionAfiliado
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
            this.lbTipoDoc = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.btVolver = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.lbNumDoc = new System.Windows.Forms.Label();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbTipoDoc
            // 
            this.lbTipoDoc.AutoSize = true;
            this.lbTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoDoc.Location = new System.Drawing.Point(28, 17);
            this.lbTipoDoc.Name = "lbTipoDoc";
            this.lbTipoDoc.Size = new System.Drawing.Size(98, 15);
            this.lbTipoDoc.TabIndex = 0;
            this.lbTipoDoc.Text = "Tipo Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(141, 43);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(49, 84);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 2;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(156, 84);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 3;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // lbNumDoc
            // 
            this.lbNumDoc.AutoSize = true;
            this.lbNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumDoc.Location = new System.Drawing.Point(28, 44);
            this.lbNumDoc.Name = "lbNumDoc";
            this.lbNumDoc.Size = new System.Drawing.Size(104, 15);
            this.lbNumDoc.TabIndex = 4;
            this.lbNumDoc.Text = "Núm. Documento";
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Items.AddRange(new object[] {
            "DNI",
            "LC",
            "LE"});
            this.cbTipoDoc.Location = new System.Drawing.Point(141, 16);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(100, 21);
            this.cbTipoDoc.TabIndex = 23;
            // 
            // SeleccionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 133);
            this.Controls.Add(this.cbTipoDoc);
            this.Controls.Add(this.lbNumDoc);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lbTipoDoc);
            this.Name = "SeleccionAfiliado";
            this.Text = "Seleccion Afiliado";
            this.Load += new System.EventHandler(this.SeleccionAfiliado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTipoDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label lbNumDoc;
        private System.Windows.Forms.ComboBox cbTipoDoc;
    }
}