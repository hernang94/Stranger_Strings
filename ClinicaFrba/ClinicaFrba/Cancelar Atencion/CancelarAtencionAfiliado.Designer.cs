namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelarAtencionAfiliado
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
            this.dtgTurnos = new System.Windows.Forms.DataGridView();
            this.lbSeleccionTurno = new System.Windows.Forms.Label();
            this.btVolver = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.lbTurnoCancelado = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbMotivo = new System.Windows.Forms.TextBox();
            this.lbMotivo = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTurnos
            // 
            this.dtgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTurnos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgTurnos.Location = new System.Drawing.Point(41, 42);
            this.dtgTurnos.Name = "dtgTurnos";
            this.dtgTurnos.Size = new System.Drawing.Size(456, 149);
            this.dtgTurnos.TabIndex = 38;
            this.dtgTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTurnos_CellContentClick);
            // 
            // lbSeleccionTurno
            // 
            this.lbSeleccionTurno.AutoSize = true;
            this.lbSeleccionTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeleccionTurno.Location = new System.Drawing.Point(37, 19);
            this.lbSeleccionTurno.Name = "lbSeleccionTurno";
            this.lbSeleccionTurno.Size = new System.Drawing.Size(221, 20);
            this.lbSeleccionTurno.TabIndex = 39;
            this.lbSeleccionTurno.Text = "Seleccione el turno a cancelar";
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(152, 393);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 23);
            this.btVolver.TabIndex = 40;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(298, 393);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 41;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // lbTurnoCancelado
            // 
            this.lbTurnoCancelado.AutoSize = true;
            this.lbTurnoCancelado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnoCancelado.ForeColor = System.Drawing.Color.Green;
            this.lbTurnoCancelado.Location = new System.Drawing.Point(142, 363);
            this.lbTurnoCancelado.Name = "lbTurnoCancelado";
            this.lbTurnoCancelado.Size = new System.Drawing.Size(244, 15);
            this.lbTurnoCancelado.TabIndex = 42;
            this.lbTurnoCancelado.Text = "Su turno ha sido cancelado con éxito";
            this.lbTurnoCancelado.Visible = false;
            this.lbTurnoCancelado.Click += new System.EventHandler(this.lbTurnoCancelado_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbMotivo
            // 
            this.tbMotivo.Location = new System.Drawing.Point(41, 229);
            this.tbMotivo.MaxLength = 225;
            this.tbMotivo.Multiline = true;
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(456, 120);
            this.tbMotivo.TabIndex = 43;
            this.tbMotivo.TextChanged += new System.EventHandler(this.tbMotivo_TextChanged);
            // 
            // lbMotivo
            // 
            this.lbMotivo.AutoSize = true;
            this.lbMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMotivo.Location = new System.Drawing.Point(37, 206);
            this.lbMotivo.Name = "lbMotivo";
            this.lbMotivo.Size = new System.Drawing.Size(260, 20);
            this.lbMotivo.TabIndex = 44;
            this.lbMotivo.Text = "Ingrese el motivo de su cancelación";
            this.lbMotivo.Click += new System.EventHandler(this.lbMotivo_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // CancelarAtencionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 437);
            this.Controls.Add(this.lbMotivo);
            this.Controls.Add(this.tbMotivo);
            this.Controls.Add(this.lbTurnoCancelado);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.lbSeleccionTurno);
            this.Controls.Add(this.dtgTurnos);
            this.Name = "CancelarAtencionAfiliado";
            this.Text = "Cancelar atención";
            this.Load += new System.EventHandler(this.CancelarAtencionAfiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTurnos;
        private System.Windows.Forms.Label lbSeleccionTurno;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label lbTurnoCancelado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbMotivo;
        private System.Windows.Forms.Label lbMotivo;
        private System.Windows.Forms.Timer timer2;

    }
}