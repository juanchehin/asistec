namespace asistec.CapaPresentacion
{
    partial class formNuevaEditarEscuela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formNuevaEditarEscuela));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEscuela = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.RichTextBox();
            this.txtEscuela = new System.Windows.Forms.TextBox();
            this.lblEditarNuevo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(122, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(318, 257);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEscuela);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.lblObservaciones);
            this.groupBox1.Controls.Add(this.lblEscuela);
            this.groupBox1.Location = new System.Drawing.Point(122, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 195);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la escuela";
            // 
            // lblEscuela
            // 
            this.lblEscuela.AutoSize = true;
            this.lblEscuela.Location = new System.Drawing.Point(17, 39);
            this.lblEscuela.Name = "lblEscuela";
            this.lblEscuela.Size = new System.Drawing.Size(54, 13);
            this.lblEscuela.TabIndex = 0;
            this.lblEscuela.Text = "Escuela : ";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(17, 84);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(87, 13);
            this.lblObservaciones.TabIndex = 1;
            this.lblObservaciones.Text = "Observaciones : ";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(101, 84);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(261, 96);
            this.txtObservaciones.TabIndex = 2;
            this.txtObservaciones.Text = "";
            // 
            // txtEscuela
            // 
            this.txtEscuela.Location = new System.Drawing.Point(101, 39);
            this.txtEscuela.Name = "txtEscuela";
            this.txtEscuela.Size = new System.Drawing.Size(261, 20);
            this.txtEscuela.TabIndex = 1;
            // 
            // lblEditarNuevo
            // 
            this.lblEditarNuevo.AutoSize = true;
            this.lblEditarNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditarNuevo.Location = new System.Drawing.Point(118, 12);
            this.lblEditarNuevo.Name = "lblEditarNuevo";
            this.lblEditarNuevo.Size = new System.Drawing.Size(51, 20);
            this.lblEditarNuevo.TabIndex = 5;
            this.lblEditarNuevo.Text = "label1";
            // 
            // formNuevaEditarEscuela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 295);
            this.Controls.Add(this.lblEditarNuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formNuevaEditarEscuela";
            this.Text = "Nueva Escuela";
            this.Load += new System.EventHandler(this.formNuevaEditarEscuela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblEscuela;
        private System.Windows.Forms.TextBox txtEscuela;
        private System.Windows.Forms.RichTextBox txtObservaciones;
        private System.Windows.Forms.Label lblEditarNuevo;
    }
}