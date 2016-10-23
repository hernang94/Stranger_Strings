namespace PagoElectronico.Shared
{
    partial class BuscadorCliente
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
            this.tbNumeroDoc = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNroCli = new System.Windows.Forms.TextBox();
            this.grillaClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grillaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumeroDoc
            // 
            this.tbNumeroDoc.Location = new System.Drawing.Point(15, 81);
            this.tbNumeroDoc.Name = "tbNumeroDoc";
            this.tbNumeroDoc.Size = new System.Drawing.Size(138, 20);
            this.tbNumeroDoc.TabIndex = 1;
            this.tbNumeroDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumeroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeroDoc_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(15, 215);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(138, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nro Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(15, 130);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(138, 20);
            this.tbNombre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apellido";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(15, 181);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(138, 20);
            this.tbApellido.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Numero Cliente";
            // 
            // tbNroCli
            // 
            this.tbNroCli.Location = new System.Drawing.Point(15, 35);
            this.tbNroCli.Name = "tbNroCli";
            this.tbNroCli.Size = new System.Drawing.Size(138, 20);
            this.tbNroCli.TabIndex = 0;
            this.tbNroCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNroCli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroCli_KeyPress);
            // 
            // grillaClientes
            // 
            this.grillaClientes.AllowUserToAddRows = false;
            this.grillaClientes.AllowUserToDeleteRows = false;
            this.grillaClientes.AllowUserToResizeColumns = false;
            this.grillaClientes.AllowUserToResizeRows = false;
            this.grillaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaClientes.Location = new System.Drawing.Point(167, 15);
            this.grillaClientes.MultiSelect = false;
            this.grillaClientes.Name = "grillaClientes";
            this.grillaClientes.ReadOnly = true;
            this.grillaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaClientes.Size = new System.Drawing.Size(385, 223);
            this.grillaClientes.TabIndex = 9;
            this.grillaClientes.DoubleClick += new System.EventHandler(this.grillaClientes_DoubleClick);
            // 
            // BuscadorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 248);
            this.Controls.Add(this.grillaClientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNroCli);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbNumeroDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BuscadorCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.grillaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumeroDoc;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNroCli;
        private System.Windows.Forms.DataGridView grillaClientes;
    }
}