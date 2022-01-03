namespace educatec.CapaPresentacion
{
    partial class formPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPersonal));
            this.dataListadoPersonal = new System.Windows.Forms.DataGridView();
            this.btnNuevoPersonal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalPersonal = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnMarcarAsistencia = new System.Windows.Forms.Button();
            this.btnBuscarPersonal = new System.Windows.Forms.Button();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataListadoPersonal
            // 
            this.dataListadoPersonal.AllowUserToAddRows = false;
            this.dataListadoPersonal.AllowUserToDeleteRows = false;
            this.dataListadoPersonal.AllowUserToResizeColumns = false;
            this.dataListadoPersonal.AllowUserToResizeRows = false;
            this.dataListadoPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoPersonal.Location = new System.Drawing.Point(118, 63);
            this.dataListadoPersonal.Name = "dataListadoPersonal";
            this.dataListadoPersonal.Size = new System.Drawing.Size(661, 517);
            this.dataListadoPersonal.TabIndex = 2;
            this.dataListadoPersonal.SelectionChanged += new System.EventHandler(this.dataListadoPersonal_SelectionChanged);
            // 
            // btnNuevoPersonal
            // 
            this.btnNuevoPersonal.Location = new System.Drawing.Point(527, 6);
            this.btnNuevoPersonal.Name = "btnNuevoPersonal";
            this.btnNuevoPersonal.Size = new System.Drawing.Size(99, 31);
            this.btnNuevoPersonal.TabIndex = 3;
            this.btnNuevoPersonal.Text = "Agregar personal";
            this.btnNuevoPersonal.UseVisualStyleBackColor = true;
            this.btnNuevoPersonal.Click += new System.EventHandler(this.btnNuevoPersonal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(615, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total del personal : ";
            // 
            // lblTotalPersonal
            // 
            this.lblTotalPersonal.AutoSize = true;
            this.lblTotalPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPersonal.Location = new System.Drawing.Point(757, 40);
            this.lblTotalPersonal.Name = "lblTotalPersonal";
            this.lblTotalPersonal.Size = new System.Drawing.Size(18, 20);
            this.lblTotalPersonal.TabIndex = 5;
            this.lblTotalPersonal.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(741, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(34, 31);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnMarcarAsistencia
            // 
            this.btnMarcarAsistencia.Location = new System.Drawing.Point(632, 6);
            this.btnMarcarAsistencia.Name = "btnMarcarAsistencia";
            this.btnMarcarAsistencia.Size = new System.Drawing.Size(103, 31);
            this.btnMarcarAsistencia.TabIndex = 7;
            this.btnMarcarAsistencia.Text = "Marcar asistencia";
            this.btnMarcarAsistencia.UseVisualStyleBackColor = true;
            this.btnMarcarAsistencia.Click += new System.EventHandler(this.btnMarcarAsistencia_Click);
            // 
            // btnBuscarPersonal
            // 
            this.btnBuscarPersonal.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPersonal.Image")));
            this.btnBuscarPersonal.Location = new System.Drawing.Point(267, 12);
            this.btnBuscarPersonal.Name = "btnBuscarPersonal";
            this.btnBuscarPersonal.Size = new System.Drawing.Size(34, 25);
            this.btnBuscarPersonal.TabIndex = 8;
            this.btnBuscarPersonal.UseVisualStyleBackColor = true;
            this.btnBuscarPersonal.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(118, 17);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(143, 20);
            this.txtDNI.TabIndex = 9;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Busqueda por DNI";
            // 
            // formPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 592);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.btnBuscarPersonal);
            this.Controls.Add(this.btnMarcarAsistencia);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblTotalPersonal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNuevoPersonal);
            this.Controls.Add(this.dataListadoPersonal);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formPersonal";
            this.Text = "Listado del personal";
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataListadoPersonal;
        private System.Windows.Forms.Button btnNuevoPersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPersonal;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnMarcarAsistencia;
        private System.Windows.Forms.Button btnBuscarPersonal;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label2;
    }
}