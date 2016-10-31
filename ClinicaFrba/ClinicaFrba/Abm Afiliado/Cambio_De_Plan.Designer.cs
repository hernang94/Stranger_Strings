namespace ClinicaFrba.Abm_Afiliado
{
    partial class Cambio_De_Plan
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
            this.lbMotivo = new System.Windows.Forms.Label();
            this.tbMotivo = new System.Windows.Forms.TextBox();
            this.lbPlanMod = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.cbPlanMedico = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbMotivo
            // 
            this.lbMotivo.AutoSize = true;
            this.lbMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMotivo.Location = new System.Drawing.Point(26, 73);
            this.lbMotivo.Name = "lbMotivo";
            this.lbMotivo.Size = new System.Drawing.Size(243, 18);
            this.lbMotivo.TabIndex = 49;
            this.lbMotivo.Text = "Ingrese el motivo de su cancelación";
            // 
            // tbMotivo
            // 
            this.tbMotivo.Location = new System.Drawing.Point(23, 104);
            this.tbMotivo.MaxLength = 225;
            this.tbMotivo.Multiline = true;
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(256, 60);
            this.tbMotivo.TabIndex = 48;
            // 
            // lbPlanMod
            // 
            this.lbPlanMod.AutoSize = true;
            this.lbPlanMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlanMod.ForeColor = System.Drawing.Color.Green;
            this.lbPlanMod.Location = new System.Drawing.Point(35, 179);
            this.lbPlanMod.Name = "lbPlanMod";
            this.lbPlanMod.Size = new System.Drawing.Size(244, 15);
            this.lbPlanMod.TabIndex = 47;
            this.lbPlanMod.Text = "Su plan ha sido modificado con éxito";
            this.lbPlanMod.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(188, 202);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(81, 25);
            this.btAceptar.TabIndex = 46;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(38, 202);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(80, 25);
            this.btVolver.TabIndex = 45;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
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
            this.cbPlanMedico.Location = new System.Drawing.Point(160, 30);
            this.cbPlanMedico.Name = "cbPlanMedico";
            this.cbPlanMedico.Size = new System.Drawing.Size(100, 21);
            this.cbPlanMedico.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nuevo plan :";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Cambio_De_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 246);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPlanMedico);
            this.Controls.Add(this.lbMotivo);
            this.Controls.Add(this.tbMotivo);
            this.Controls.Add(this.lbPlanMod);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btVolver);
            this.Name = "Cambio_De_Plan";
            this.Text = "Cambio de Plan";
            this.Load += new System.EventHandler(this.Cambio_De_Plan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMotivo;
        private System.Windows.Forms.TextBox tbMotivo;
        private System.Windows.Forms.Label lbPlanMod;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.ComboBox cbPlanMedico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}