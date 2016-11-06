namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBonoAdmin
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btVerificarAfiliado = new System.Windows.Forms.Button();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCompraExito = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbPrecioTotal = new System.Windows.Forms.Label();
            this.btComprar = new System.Windows.Forms.Button();
            this.btCalcularPrecio = new System.Windows.Forms.Button();
            this.nudCantidadBonos = new System.Windows.Forms.NumericUpDown();
            this.lbSeleccion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBonos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btVerificarAfiliado);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Validación de afiliado";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btVerificarAfiliado
            // 
            this.btVerificarAfiliado.Location = new System.Drawing.Point(100, 58);
            this.btVerificarAfiliado.Name = "btVerificarAfiliado";
            this.btVerificarAfiliado.Size = new System.Drawing.Size(95, 23);
            this.btVerificarAfiliado.TabIndex = 17;
            this.btVerificarAfiliado.Text = "Verificar Afiliado";
            this.btVerificarAfiliado.UseVisualStyleBackColor = true;
            this.btVerificarAfiliado.Click += new System.EventHandler(this.btVerificarAfiliado_Click);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(167, 25);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ingrese DNI de Afiliado";
            // 
            // lbCompraExito
            // 
            this.lbCompraExito.AutoSize = true;
            this.lbCompraExito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompraExito.ForeColor = System.Drawing.Color.Green;
            this.lbCompraExito.Location = new System.Drawing.Point(49, 113);
            this.lbCompraExito.Name = "lbCompraExito";
            this.lbCompraExito.Size = new System.Drawing.Size(197, 16);
            this.lbCompraExito.TabIndex = 14;
            this.lbCompraExito.Text = "Compra realizada con éxito";
            this.lbCompraExito.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(61, 268);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 13;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbPrecioTotal
            // 
            this.lbPrecioTotal.AutoSize = true;
            this.lbPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioTotal.ForeColor = System.Drawing.Color.Blue;
            this.lbPrecioTotal.Location = new System.Drawing.Point(114, 112);
            this.lbPrecioTotal.Name = "lbPrecioTotal";
            this.lbPrecioTotal.Size = new System.Drawing.Size(74, 20);
            this.lbPrecioTotal.TabIndex = 12;
            this.lbPrecioTotal.Text = "$ 10000";
            this.lbPrecioTotal.Visible = false;
            // 
            // btComprar
            // 
            this.btComprar.Location = new System.Drawing.Point(183, 268);
            this.btComprar.Name = "btComprar";
            this.btComprar.Size = new System.Drawing.Size(75, 23);
            this.btComprar.TabIndex = 11;
            this.btComprar.Text = "Comprar";
            this.btComprar.UseVisualStyleBackColor = true;
            this.btComprar.Click += new System.EventHandler(this.btComprar_Click);
            // 
            // btCalcularPrecio
            // 
            this.btCalcularPrecio.Location = new System.Drawing.Point(139, 56);
            this.btCalcularPrecio.Name = "btCalcularPrecio";
            this.btCalcularPrecio.Size = new System.Drawing.Size(93, 23);
            this.btCalcularPrecio.TabIndex = 10;
            this.btCalcularPrecio.Text = "Calcular Precio";
            this.btCalcularPrecio.UseVisualStyleBackColor = true;
            this.btCalcularPrecio.Click += new System.EventHandler(this.btCalcularPrecio_Click);
            // 
            // nudCantidadBonos
            // 
            this.nudCantidadBonos.Location = new System.Drawing.Point(75, 59);
            this.nudCantidadBonos.Name = "nudCantidadBonos";
            this.nudCantidadBonos.Size = new System.Drawing.Size(49, 20);
            this.nudCantidadBonos.TabIndex = 9;
            this.nudCantidadBonos.ValueChanged += new System.EventHandler(this.nudCantidadBonos_ValueChanged);
            // 
            // lbSeleccion
            // 
            this.lbSeleccion.AutoSize = true;
            this.lbSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccion.Location = new System.Drawing.Point(35, 22);
            this.lbSeleccion.Name = "lbSeleccion";
            this.lbSeleccion.Size = new System.Drawing.Size(224, 15);
            this.lbSeleccion.TabIndex = 8;
            this.lbSeleccion.Text = "Indique la cantidad de bonos a comprar";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSeleccion);
            this.groupBox2.Controls.Add(this.lbCompraExito);
            this.groupBox2.Controls.Add(this.nudCantidadBonos);
            this.groupBox2.Controls.Add(this.btCalcularPrecio);
            this.groupBox2.Controls.Add(this.lbPrecioTotal);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 142);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // CompraBonoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 308);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btComprar);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompraBonoAdmin";
            this.Text = "Comprar bono";
            this.Load += new System.EventHandler(this.CompraBonoAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBonos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btVerificarAfiliado;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCompraExito;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lbPrecioTotal;
        private System.Windows.Forms.Button btComprar;
        private System.Windows.Forms.Button btCalcularPrecio;
        private System.Windows.Forms.NumericUpDown nudCantidadBonos;
        private System.Windows.Forms.Label lbSeleccion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}