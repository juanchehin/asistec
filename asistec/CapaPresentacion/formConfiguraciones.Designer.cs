namespace asistec.CapaPresentacion
{
    partial class formConfiguraciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConfiguraciones));
            this.label7 = new System.Windows.Forms.Label();
            this.btnBackEnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ejecutar backend";
            // 
            // btnBackEnd
            // 
            this.btnBackEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnBackEnd.Image")));
            this.btnBackEnd.Location = new System.Drawing.Point(12, 12);
            this.btnBackEnd.Name = "btnBackEnd";
            this.btnBackEnd.Size = new System.Drawing.Size(173, 157);
            this.btnBackEnd.TabIndex = 15;
            this.btnBackEnd.UseVisualStyleBackColor = true;
            this.btnBackEnd.Click += new System.EventHandler(this.btnBackEnd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Obtener IP";
            // 
            // btnIP
            // 
            this.btnIP.Image = ((System.Drawing.Image)(resources.GetObject("btnIP.Image")));
            this.btnIP.Location = new System.Drawing.Point(191, 12);
            this.btnIP.Name = "btnIP";
            this.btnIP.Size = new System.Drawing.Size(173, 157);
            this.btnIP.TabIndex = 17;
            this.btnIP.UseVisualStyleBackColor = true;
            this.btnIP.Click += new System.EventHandler(this.btnIP_Click);
            // 
            // formConfiguraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBackEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formConfiguraciones";
            this.Text = "Configuraciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBackEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIP;
    }
}