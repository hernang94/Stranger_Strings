﻿namespace ClinicaFrba.Listados
{
    partial class SeleccionListado
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
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.cbListado = new System.Windows.Forms.ComboBox();
            this.cbAño = new System.Windows.Forms.ComboBox();
            this.gbConfiguracionListado = new System.Windows.Forms.GroupBox();
            this.lbSeleccionListado = new System.Windows.Forms.Label();
            this.lbSeleccionAño = new System.Windows.Forms.Label();
            this.lbSeleccionSemestre = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btVolver = new System.Windows.Forms.Button();
            this.gbConfiguracionListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSemestre
            // 
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.Items.AddRange(new object[] {
            "Ene - Jun",
            "Jul - Dic"});
            this.cbSemestre.Location = new System.Drawing.Point(313, 34);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(134, 21);
            this.cbSemestre.TabIndex = 0;
            // 
            // cbListado
            // 
            this.cbListado.FormattingEnabled = true;
            this.cbListado.Location = new System.Drawing.Point(9, 34);
            this.cbListado.Name = "cbListado";
            this.cbListado.Size = new System.Drawing.Size(121, 21);
            this.cbListado.TabIndex = 1;
            // 
            // cbAño
            // 
            this.cbAño.FormatString = "N0";
            this.cbAño.FormattingEnabled = true;
            this.cbAño.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018"});
            this.cbAño.Location = new System.Drawing.Point(171, 34);
            this.cbAño.Name = "cbAño";
            this.cbAño.Size = new System.Drawing.Size(102, 21);
            this.cbAño.TabIndex = 2;
            // 
            // gbConfiguracionListado
            // 
            this.gbConfiguracionListado.Controls.Add(this.btAceptar);
            this.gbConfiguracionListado.Controls.Add(this.lbSeleccionSemestre);
            this.gbConfiguracionListado.Controls.Add(this.cbSemestre);
            this.gbConfiguracionListado.Controls.Add(this.lbSeleccionAño);
            this.gbConfiguracionListado.Controls.Add(this.cbAño);
            this.gbConfiguracionListado.Controls.Add(this.lbSeleccionListado);
            this.gbConfiguracionListado.Controls.Add(this.cbListado);
            this.gbConfiguracionListado.Location = new System.Drawing.Point(12, 12);
            this.gbConfiguracionListado.Name = "gbConfiguracionListado";
            this.gbConfiguracionListado.Size = new System.Drawing.Size(455, 110);
            this.gbConfiguracionListado.TabIndex = 3;
            this.gbConfiguracionListado.TabStop = false;
            // 
            // lbSeleccionListado
            // 
            this.lbSeleccionListado.AutoSize = true;
            this.lbSeleccionListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccionListado.Location = new System.Drawing.Point(6, 16);
            this.lbSeleccionListado.Name = "lbSeleccionListado";
            this.lbSeleccionListado.Size = new System.Drawing.Size(124, 15);
            this.lbSeleccionListado.TabIndex = 2;
            this.lbSeleccionListado.Text = "Seleccione el Listado";
            // 
            // lbSeleccionAño
            // 
            this.lbSeleccionAño.AutoSize = true;
            this.lbSeleccionAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccionAño.Location = new System.Drawing.Point(168, 16);
            this.lbSeleccionAño.Name = "lbSeleccionAño";
            this.lbSeleccionAño.Size = new System.Drawing.Size(105, 15);
            this.lbSeleccionAño.TabIndex = 3;
            this.lbSeleccionAño.Text = "Seleccione el Año";
            // 
            // lbSeleccionSemestre
            // 
            this.lbSeleccionSemestre.AutoSize = true;
            this.lbSeleccionSemestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccionSemestre.Location = new System.Drawing.Point(310, 16);
            this.lbSeleccionSemestre.Name = "lbSeleccionSemestre";
            this.lbSeleccionSemestre.Size = new System.Drawing.Size(137, 15);
            this.lbSeleccionSemestre.TabIndex = 4;
            this.lbSeleccionSemestre.Text = "Seleccione el Semestre";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(184, 77);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 4;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(441, 189);
            this.dataGridView1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 214);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(196, 364);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 6;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            // 
            // SeleccionListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 402);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbConfiguracionListado);
            this.Name = "SeleccionListado";
            this.Text = "Listados Estadísticos";
            this.gbConfiguracionListado.ResumeLayout(false);
            this.gbConfiguracionListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.ComboBox cbListado;
        private System.Windows.Forms.ComboBox cbAño;
        private System.Windows.Forms.GroupBox gbConfiguracionListado;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label lbSeleccionSemestre;
        private System.Windows.Forms.Label lbSeleccionAño;
        private System.Windows.Forms.Label lbSeleccionListado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btVolver;
    }
}