﻿namespace ClinicaFrba.Abm_Afiliado
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
            this.components = new System.ComponentModel.Container();
            this.tbABMAfiliado = new System.Windows.Forms.TabControl();
            this.tpAlta = new System.Windows.Forms.TabPage();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.nupCantFamilia = new System.Windows.Forms.NumericUpDown();
            this.cbPlanMedico = new System.Windows.Forms.ComboBox();
            this.btVolver = new System.Windows.Forms.Button();
            this.btIngresar = new System.Windows.Forms.Button();
            this.dateFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtDirec = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbConjunto = new System.Windows.Forms.Label();
            this.tpBajaModif = new System.Windows.Forms.TabPage();
            this.cbBMTipoDoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBorradoModificado = new System.Windows.Forms.Label();
            this.lbIngreseNroDoc = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.dtgCliente = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtBMDoc = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbABMAfiliado.SuspendLayout();
            this.tpAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantFamilia)).BeginInit();
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
            this.tpAlta.Controls.Add(this.cbTipoDoc);
            this.tpAlta.Controls.Add(this.nupCantFamilia);
            this.tpAlta.Controls.Add(this.cbPlanMedico);
            this.tpAlta.Controls.Add(this.btVolver);
            this.tpAlta.Controls.Add(this.btIngresar);
            this.tpAlta.Controls.Add(this.dateFechaNac);
            this.tpAlta.Controls.Add(this.cbEstadoCivil);
            this.tpAlta.Controls.Add(this.cbSexo);
            this.tpAlta.Controls.Add(this.txtMail);
            this.tpAlta.Controls.Add(this.txtTel);
            this.tpAlta.Controls.Add(this.txtDirec);
            this.tpAlta.Controls.Add(this.txtNroDoc);
            this.tpAlta.Controls.Add(this.txtApellido);
            this.tpAlta.Controls.Add(this.txtNombre);
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
            // cbTipoDoc
            // 
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Items.AddRange(new object[] {
            "DNI",
            "LC",
            "LE"});
            this.cbTipoDoc.Location = new System.Drawing.Point(291, 96);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(100, 21);
            this.cbTipoDoc.TabIndex = 22;
            // 
            // nupCantFamilia
            // 
            this.nupCantFamilia.Location = new System.Drawing.Point(291, 278);
            this.nupCantFamilia.Name = "nupCantFamilia";
            this.nupCantFamilia.Size = new System.Drawing.Size(100, 20);
            this.nupCantFamilia.TabIndex = 21;
            // 
            // cbPlanMedico
            // 
            this.cbPlanMedico.FormattingEnabled = true;
            this.cbPlanMedico.Items.AddRange(new object[] {
            "110",
            "120",
            "130",
            "140",
            "150"});
            this.cbPlanMedico.Location = new System.Drawing.Point(291, 304);
            this.cbPlanMedico.Name = "cbPlanMedico";
            this.cbPlanMedico.Size = new System.Drawing.Size(100, 21);
            this.cbPlanMedico.TabIndex = 20;
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
            // cbEstadoCivil
            // 
            this.cbEstadoCivil.FormattingEnabled = true;
            this.cbEstadoCivil.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Concubinato",
            "Viudo/a",
            "Divorciado/a"});
            this.cbEstadoCivil.Location = new System.Drawing.Point(291, 252);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(100, 21);
            this.cbEstadoCivil.TabIndex = 16;
            // 
            // cbSexo
            // 
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbSexo.Location = new System.Drawing.Point(291, 226);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(100, 21);
            this.cbSexo.TabIndex = 15;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(291, 174);
            this.txtMail.MaxLength = 250;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 8;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(291, 148);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 7;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            // 
            // txtDirec
            // 
            this.txtDirec.Location = new System.Drawing.Point(291, 122);
            this.txtDirec.MaxLength = 250;
            this.txtDirec.Name = "txtDirec";
            this.txtDirec.Size = new System.Drawing.Size(100, 20);
            this.txtDirec.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(291, 70);
            this.txtNroDoc.MaxLength = 17;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(100, 20);
            this.txtNroDoc.TabIndex = 4;
            this.txtNroDoc.TextChanged += new System.EventHandler(this.txtNroDoc_TextChanged);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(291, 44);
            this.txtApellido.MaxLength = 250;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(291, 18);
            this.txtNombre.MaxLength = 250;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lbConjunto
            // 
            this.lbConjunto.AutoSize = true;
            this.lbConjunto.Location = new System.Drawing.Point(92, 21);
            this.lbConjunto.Name = "lbConjunto";
            this.lbConjunto.Size = new System.Drawing.Size(149, 299);
            this.lbConjunto.TabIndex = 1;
            this.lbConjunto.Text = "Nombre\r\n\r\nApellido\r\n\r\nNro. Documento\r\n\r\nTipo Documento\r\n\r\nDirección\r\n\r\nTeléfono\r\n" +
    "\r\nMail\r\n\r\nFecha de Nacimiento\r\n\r\nSexo\r\n\r\nEstado Civil\r\n\r\nCantidad de familiares " +
    "a cargo\r\n\r\nPlan Médico\r\n";
            this.lbConjunto.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // tpBajaModif
            // 
            this.tpBajaModif.Controls.Add(this.cbBMTipoDoc);
            this.tpBajaModif.Controls.Add(this.label1);
            this.tpBajaModif.Controls.Add(this.lbBorradoModificado);
            this.tpBajaModif.Controls.Add(this.lbIngreseNroDoc);
            this.tpBajaModif.Controls.Add(this.button7);
            this.tpBajaModif.Controls.Add(this.dtgCliente);
            this.tpBajaModif.Controls.Add(this.btnBuscar);
            this.tpBajaModif.Controls.Add(this.btnLimpiar);
            this.tpBajaModif.Controls.Add(this.button1);
            this.tpBajaModif.Controls.Add(this.button2);
            this.tpBajaModif.Controls.Add(this.txtBMDoc);
            this.tpBajaModif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpBajaModif.Location = new System.Drawing.Point(4, 22);
            this.tpBajaModif.Name = "tpBajaModif";
            this.tpBajaModif.Padding = new System.Windows.Forms.Padding(3);
            this.tpBajaModif.Size = new System.Drawing.Size(514, 384);
            this.tpBajaModif.TabIndex = 1;
            this.tpBajaModif.Text = "Baja/Modificación";
            this.tpBajaModif.UseVisualStyleBackColor = true;
            // 
            // cbBMTipoDoc
            // 
            this.cbBMTipoDoc.FormattingEnabled = true;
            this.cbBMTipoDoc.Items.AddRange(new object[] {
            "DNI",
            "LC",
            "LE"});
            this.cbBMTipoDoc.Location = new System.Drawing.Point(264, 27);
            this.cbBMTipoDoc.Name = "cbBMTipoDoc";
            this.cbBMTipoDoc.Size = new System.Drawing.Size(100, 23);
            this.cbBMTipoDoc.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 15);
            this.label1.TabIndex = 48;
            this.label1.Text = "Seleccione el tipo de documento del afiliado";
            // 
            // lbBorradoModificado
            // 
            this.lbBorradoModificado.AutoSize = true;
            this.lbBorradoModificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBorradoModificado.ForeColor = System.Drawing.Color.Green;
            this.lbBorradoModificado.Location = new System.Drawing.Point(105, 251);
            this.lbBorradoModificado.Name = "lbBorradoModificado";
            this.lbBorradoModificado.Size = new System.Drawing.Size(273, 16);
            this.lbBorradoModificado.TabIndex = 47;
            this.lbBorradoModificado.Text = "Afiliado Borrado/Modificado con éxito.";
            this.lbBorradoModificado.Visible = false;
            this.lbBorradoModificado.Click += new System.EventHandler(this.lbBorradoModificado_Click);
            // 
            // lbIngreseNroDoc
            // 
            this.lbIngreseNroDoc.AutoSize = true;
            this.lbIngreseNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIngreseNroDoc.Location = new System.Drawing.Point(8, 70);
            this.lbIngreseNroDoc.Name = "lbIngreseNroDoc";
            this.lbIngreseNroDoc.Size = new System.Drawing.Size(232, 15);
            this.lbIngreseNroDoc.TabIndex = 46;
            this.lbIngreseNroDoc.Text = "Ingrese el Nro. de documento del afiliado";
            this.lbIngreseNroDoc.Click += new System.EventHandler(this.label2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(45, 209);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 23);
            this.button7.TabIndex = 45;
            this.button7.Text = "Modificar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dtgCliente
            // 
            this.dtgCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCliente.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgCliente.Location = new System.Drawing.Point(3, 114);
            this.dtgCliente.Name = "dtgCliente";
            this.dtgCliente.Size = new System.Drawing.Size(505, 64);
            this.dtgCliente.TabIndex = 37;
            this.dtgCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCliente_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(400, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 23);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(364, 209);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 23);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Borrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBMDoc
            // 
            this.txtBMDoc.Location = new System.Drawing.Point(264, 69);
            this.txtBMDoc.MaxLength = 15;
            this.txtBMDoc.Name = "txtBMDoc";
            this.txtBMDoc.Size = new System.Drawing.Size(100, 21);
            this.txtBMDoc.TabIndex = 24;
            this.txtBMDoc.TextChanged += new System.EventHandler(this.txtBMDoc_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            ((System.ComponentModel.ISupportInitialize)(this.nupCantFamilia)).EndInit();
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
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtDirec;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbConjunto;
        private System.Windows.Forms.Button btIngresar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBMDoc;
        private System.Windows.Forms.DataGridView dtgCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox cbPlanMedico;
        private System.Windows.Forms.NumericUpDown nupCantFamilia;
        private System.Windows.Forms.Label lbIngreseNroDoc;
        private System.Windows.Forms.Label lbBorradoModificado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbTipoDoc;
        private System.Windows.Forms.ComboBox cbBMTipoDoc;
        private System.Windows.Forms.Label label1;
    }
}