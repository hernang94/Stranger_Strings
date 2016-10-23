namespace ClinicaFrba.Abm_Afiliado
{
    partial class Form1
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
            this.tbABMAfiliado = new System.Windows.Forms.TabControl();
            this.tpAlta = new System.Windows.Forms.TabPage();
            this.btVolver = new System.Windows.Forms.Button();
            this.btIngresar = new System.Windows.Forms.Button();
            this.dateFechaNac = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbConjunto = new System.Windows.Forms.Label();
            this.tpBajaModif = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.dtgCliente = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbABMAfiliado.SuspendLayout();
            this.tpAlta.SuspendLayout();
            this.tpBajaModif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // tbABMAfiliado
            // 
            this.tbABMAfiliado.Controls.Add(this.tpAlta);
            this.tbABMAfiliado.Controls.Add(this.tpBajaModif);
            this.tbABMAfiliado.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbABMAfiliado.Location = new System.Drawing.Point(0, -1);
            this.tbABMAfiliado.Name = "tbABMAfiliado";
            this.tbABMAfiliado.SelectedIndex = 0;
            this.tbABMAfiliado.Size = new System.Drawing.Size(522, 410);
            this.tbABMAfiliado.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbABMAfiliado.TabIndex = 0;
            // 
            // tpAlta
            // 
            this.tpAlta.Controls.Add(this.btVolver);
            this.tpAlta.Controls.Add(this.btIngresar);
            this.tpAlta.Controls.Add(this.dateFechaNac);
            this.tpAlta.Controls.Add(this.comboBox2);
            this.tpAlta.Controls.Add(this.comboBox1);
            this.tpAlta.Controls.Add(this.textBox10);
            this.tpAlta.Controls.Add(this.textBox11);
            this.tpAlta.Controls.Add(this.textBox7);
            this.tpAlta.Controls.Add(this.textBox6);
            this.tpAlta.Controls.Add(this.textBox5);
            this.tpAlta.Controls.Add(this.textBox4);
            this.tpAlta.Controls.Add(this.textBox3);
            this.tpAlta.Controls.Add(this.textBox2);
            this.tpAlta.Controls.Add(this.textBox1);
            this.tpAlta.Controls.Add(this.lbConjunto);
            this.tpAlta.Location = new System.Drawing.Point(4, 22);
            this.tpAlta.Name = "tpAlta";
            this.tpAlta.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlta.Size = new System.Drawing.Size(514, 384);
            this.tpAlta.TabIndex = 0;
            this.tpAlta.Text = "Alta";
            this.tpAlta.UseVisualStyleBackColor = true;
            this.tpAlta.Click += new System.EventHandler(this.tpAlta_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(144, 343);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 19;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btIngresar
            // 
            this.btIngresar.Location = new System.Drawing.Point(291, 343);
            this.btIngresar.Name = "btIngresar";
            this.btIngresar.Size = new System.Drawing.Size(75, 23);
            this.btIngresar.TabIndex = 18;
            this.btIngresar.Text = "Ingresar";
            this.btIngresar.UseVisualStyleBackColor = true;
            this.btIngresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateFechaNac
            // 
            this.dateFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaNac.Location = new System.Drawing.Point(291, 200);
            this.dateFechaNac.Name = "dateFechaNac";
            this.dateFechaNac.Size = new System.Drawing.Size(100, 20);
            this.dateFechaNac.TabIndex = 17;
            this.dateFechaNac.Value = new System.DateTime(2016, 10, 21, 16, 15, 55, 0);
            this.dateFechaNac.ValueChanged += new System.EventHandler(this.dateFechaNac_ValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Viudo/a",
            "Concubinato",
            "Divorciado/a"});
            this.comboBox2.Location = new System.Drawing.Point(291, 252);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.comboBox1.Location = new System.Drawing.Point(291, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(291, 304);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 13;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(291, 278);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 20);
            this.textBox11.TabIndex = 12;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(291, 174);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(291, 148);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(291, 122);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(291, 96);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(291, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(291, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(291, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lbConjunto
            // 
            this.lbConjunto.AutoSize = true;
            this.lbConjunto.Location = new System.Drawing.Point(92, 21);
            this.lbConjunto.Name = "lbConjunto";
            this.lbConjunto.Size = new System.Drawing.Size(150, 299);
            this.lbConjunto.TabIndex = 1;
            this.lbConjunto.Text = "Nombre\r\n\r\nApellido\r\n\r\nNro. Documento\r\n\r\nTipo Documento\r\n\r\nDirección\r\n\r\nTeléfono\r\n" +
    "\r\nMail\r\n\r\nFecha de Nacimiento\r\n\r\nSexo\r\n\r\nEstado Civil\r\n\r\nCantidad de familiares " +
    "a Cargo\r\n\r\nPlan Médico\r\n";
            this.lbConjunto.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // tpBajaModif
            // 
            this.tpBajaModif.Controls.Add(this.button7);
            this.tpBajaModif.Controls.Add(this.dtgCliente);
            this.tpBajaModif.Controls.Add(this.btnBuscar);
            this.tpBajaModif.Controls.Add(this.btnLimpiar);
            this.tpBajaModif.Controls.Add(this.button1);
            this.tpBajaModif.Controls.Add(this.button2);
            this.tpBajaModif.Controls.Add(this.textBox14);
            this.tpBajaModif.Controls.Add(this.textBox15);
            this.tpBajaModif.Controls.Add(this.textBox16);
            this.tpBajaModif.Controls.Add(this.textBox17);
            this.tpBajaModif.Controls.Add(this.textBox18);
            this.tpBajaModif.Controls.Add(this.label1);
            this.tpBajaModif.Location = new System.Drawing.Point(4, 22);
            this.tpBajaModif.Name = "tpBajaModif";
            this.tpBajaModif.Padding = new System.Windows.Forms.Padding(3);
            this.tpBajaModif.Size = new System.Drawing.Size(514, 384);
            this.tpBajaModif.TabIndex = 1;
            this.tpBajaModif.Text = "Baja/Modificación";
            this.tpBajaModif.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(400, 292);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 23);
            this.button7.TabIndex = 45;
            this.button7.Text = "Modificar";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dtgCliente
            // 
            this.dtgCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCliente.Location = new System.Drawing.Point(30, 168);
            this.dtgCliente.Name = "dtgCliente";
            this.dtgCliente.Size = new System.Drawing.Size(345, 149);
            this.dtgCliente.TabIndex = 37;
            this.dtgCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCliente_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(400, 166);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 23);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(400, 209);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 23);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Borrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(242, 128);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 20);
            this.textBox14.TabIndex = 25;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(242, 102);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 20);
            this.textBox15.TabIndex = 24;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(242, 76);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 20);
            this.textBox16.TabIndex = 23;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(242, 50);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 20);
            this.textBox17.TabIndex = 22;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(242, 24);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 20);
            this.textBox18.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 117);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombre\r\n\r\nApellido\r\n\r\nNro. Afiliado\r\n\r\nNro. Documento\r\n\r\nPlan Médico\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 412);
            this.Controls.Add(this.tbABMAfiliado);
            this.Name = "Form1";
            this.Text = "ABM Afiliado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbABMAfiliado.ResumeLayout(false);
            this.tpAlta.ResumeLayout(false);
            this.tpAlta.PerformLayout();
            this.tpBajaModif.ResumeLayout(false);
            this.tpBajaModif.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbABMAfiliado;
        private System.Windows.Forms.TabPage tpBajaModif;
        private System.Windows.Forms.TabPage tpAlta;
        private System.Windows.Forms.DateTimePicker dateFechaNac;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbConjunto;
        private System.Windows.Forms.Button btIngresar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button7;
    }
}