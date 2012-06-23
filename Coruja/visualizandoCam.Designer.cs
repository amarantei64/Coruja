namespace Coruja
{
    partial class visualizandoCam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(visualizandoCam));
            this.pbxGrabando = new System.Windows.Forms.PictureBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.pbxReproductor = new System.Windows.Forms.PictureBox();
            this.tlpAyuda = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrabando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxGrabando
            // 
            this.pbxGrabando.Image = global::Coruja.Properties.Resources.grabando;
            this.pbxGrabando.Location = new System.Drawing.Point(5, 5);
            this.pbxGrabando.Name = "pbxGrabando";
            this.pbxGrabando.Size = new System.Drawing.Size(62, 22);
            this.pbxGrabando.TabIndex = 2;
            this.pbxGrabando.TabStop = false;
            this.tlpAyuda.SetToolTip(this.pbxGrabando, "Grabando");
            this.pbxGrabando.Visible = false;
            // 
            // btnDetener
            // 
            this.btnDetener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetener.BackgroundImage = global::Coruja.Properties.Resources.grabar;
            this.btnDetener.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetener.FlatAppearance.BorderSize = 0;
            this.btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetener.Location = new System.Drawing.Point(398, 292);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(29, 27);
            this.btnDetener.TabIndex = 1;
            this.tlpAyuda.SetToolTip(this.btnDetener, "Grabar / Detener");
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // pbxReproductor
            // 
            this.pbxReproductor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxReproductor.Location = new System.Drawing.Point(0, 0);
            this.pbxReproductor.Name = "pbxReproductor";
            this.pbxReproductor.Size = new System.Drawing.Size(439, 331);
            this.pbxReproductor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxReproductor.TabIndex = 0;
            this.pbxReproductor.TabStop = false;
            // 
            // visualizandoCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 331);
            this.Controls.Add(this.pbxGrabando);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.pbxReproductor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 320);
            this.Name = "visualizandoCam";
            this.Text = "Cuadro de vigilancia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.visualizandoCam_FormClosing);
            this.Load += new System.EventHandler(this.visualizandoCam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrabando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReproductor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxReproductor;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.PictureBox pbxGrabando;
        private System.Windows.Forms.ToolTip tlpAyuda;
    }
}