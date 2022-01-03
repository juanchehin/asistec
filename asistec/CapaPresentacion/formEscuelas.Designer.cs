namespace asistec.CapaPresentacion
{
    partial class formEscuelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEscuelas));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataListadoEscuelas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalEscuelas = new System.Windows.Forms.Label();
            this.btnAgregarEscuela = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoEscuelas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dataListadoEscuelas
            // 
            this.dataListadoEscuelas.AllowUserToAddRows = false;
            this.dataListadoEscuelas.AllowUserToDeleteRows = false;
            this.dataListadoEscuelas.AllowUserToResizeRows = false;
            this.dataListadoEscuelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoEscuelas.Location = new System.Drawing.Point(121, 95);
            this.dataListadoEscuelas.Name = "dataListadoEscuelas";
            this.dataListadoEscuelas.Size = new System.Drawing.Size(438, 334);
            this.dataListadoEscuelas.TabIndex = 2;
            this.dataListadoEscuelas.SelectionChanged += new System.EventHandler(this.dataListadoEscuelas_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total de escuelas : ";
            // 
            // lblTotalEscuelas
            // 
            this.lblTotalEscuelas.AutoSize = true;
            this.lblTotalEscuelas.Location = new System.Drawing.Point(227, 75);
            this.lblTotalEscuelas.Name = "lblTotalEscuelas";
            this.lblTotalEscuelas.Size = new System.Drawing.Size(13, 13);
            this.lblTotalEscuelas.TabIndex = 4;
            this.lblTotalEscuelas.Text = "0";
            // 
            // btnAgregarEscuela
            // 
            this.btnAgregarEscuela.Location = new System.Drawing.Point(261, 69);
            this.btnAgregarEscuela.Name = "btnAgregarEscuela";
            this.btnAgregarEscuela.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarEscuela.TabIndex = 5;
            this.btnAgregarEscuela.Text = "Agregar";
            this.btnAgregarEscuela.UseVisualStyleBackColor = true;
            this.btnAgregarEscuela.Click += new System.EventHandler(this.btnAgregarEscuela_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(342, 69);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(521, 60);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(38, 32);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // formEscuelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 450);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregarEscuela);
            this.Controls.Add(this.lblTotalEscuelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataListadoEscuelas);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formEscuelas";
            this.Text = "Escuelas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoEscuelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataListadoEscuelas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalEscuelas;
        private System.Windows.Forms.Button btnAgregarEscuela;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
    }
}