namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBono
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
            this.lbSeleccion = new System.Windows.Forms.Label();
            this.nudCantidadBonos = new System.Windows.Forms.NumericUpDown();
            this.btCalcularPrecio = new System.Windows.Forms.Button();
            this.btComprar = new System.Windows.Forms.Button();
            this.lbPrecioTotal = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSeleccion
            // 
            this.lbSeleccion.AutoSize = true;
            this.lbSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccion.Location = new System.Drawing.Point(28, 9);
            this.lbSeleccion.Name = "lbSeleccion";
            this.lbSeleccion.Size = new System.Drawing.Size(224, 15);
            this.lbSeleccion.TabIndex = 0;
            this.lbSeleccion.Text = "Indique la cantidad de bonos a comprar";
            // 
            // nudCantidadBonos
            // 
            this.nudCantidadBonos.Location = new System.Drawing.Point(68, 46);
            this.nudCantidadBonos.Name = "nudCantidadBonos";
            this.nudCantidadBonos.Size = new System.Drawing.Size(49, 20);
            this.nudCantidadBonos.TabIndex = 1;
            this.nudCantidadBonos.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btCalcularPrecio
            // 
            this.btCalcularPrecio.Location = new System.Drawing.Point(132, 43);
            this.btCalcularPrecio.Name = "btCalcularPrecio";
            this.btCalcularPrecio.Size = new System.Drawing.Size(93, 23);
            this.btCalcularPrecio.TabIndex = 2;
            this.btCalcularPrecio.Text = "Calcular Precio";
            this.btCalcularPrecio.UseVisualStyleBackColor = true;
            this.btCalcularPrecio.Click += new System.EventHandler(this.btCalcularPrecio_Click);
            // 
            // btComprar
            // 
            this.btComprar.Location = new System.Drawing.Point(164, 150);
            this.btComprar.Name = "btComprar";
            this.btComprar.Size = new System.Drawing.Size(75, 23);
            this.btComprar.TabIndex = 3;
            this.btComprar.Text = "Comprar";
            this.btComprar.UseVisualStyleBackColor = true;
            this.btComprar.Click += new System.EventHandler(this.btComprar_Click);
            // 
            // lbPrecioTotal
            // 
            this.lbPrecioTotal.AutoSize = true;
            this.lbPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioTotal.ForeColor = System.Drawing.Color.Blue;
            this.lbPrecioTotal.Location = new System.Drawing.Point(97, 99);
            this.lbPrecioTotal.Name = "lbPrecioTotal";
            this.lbPrecioTotal.Size = new System.Drawing.Size(74, 20);
            this.lbPrecioTotal.TabIndex = 5;
            this.lbPrecioTotal.Text = "$ 10000";
            this.lbPrecioTotal.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(42, 150);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.lbPrecioTotal);
            this.Controls.Add(this.btComprar);
            this.Controls.Add(this.btCalcularPrecio);
            this.Controls.Add(this.nudCantidadBonos);
            this.Controls.Add(this.lbSeleccion);
            this.Name = "CompraBono";
            this.Text = "Comprar Bonos";
            this.Load += new System.EventHandler(this.CompraBono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSeleccion;
        private System.Windows.Forms.NumericUpDown nudCantidadBonos;
        private System.Windows.Forms.Button btCalcularPrecio;
        private System.Windows.Forms.Button btComprar;
        private System.Windows.Forms.Label lbPrecioTotal;
        private System.Windows.Forms.Button btCancelar;
    }
}