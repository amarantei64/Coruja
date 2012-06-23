namespace Coruja
{
    partial class Opciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opciones));
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCodec = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRutaAlmacen = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.ttpAyuda = new System.Windows.Forms.ToolTip(this.components);
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.nudFPS = new System.Windows.Forms.NumericUpDown();
            this.cbxResolucion = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombreForm
            // 
            this.lblNombreForm.AutoSize = true;
            this.lblNombreForm.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreForm.Location = new System.Drawing.Point(12, 9);
            this.lblNombreForm.Name = "lblNombreForm";
            this.lblNombreForm.Size = new System.Drawing.Size(251, 29);
            this.lblNombreForm.TabIndex = 0;
            this.lblNombreForm.Text = "Configuración de Coruja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Codec de video";
            // 
            // cbxCodec
            // 
            this.cbxCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCodec.FormattingEnabled = true;
            this.cbxCodec.Items.AddRange(new object[] {
            "Sin compresión",
            "MPEG4",
            "Windows Media Video",
            "Flash Player Video"});
            this.cbxCodec.Location = new System.Drawing.Point(189, 3);
            this.cbxCodec.Name = "cbxCodec";
            this.cbxCodec.Size = new System.Drawing.Size(217, 21);
            this.cbxCodec.TabIndex = 5;
            this.ttpAyuda.SetToolTip(this.cbxCodec, "Seleccione el formato de grabación.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Imágenes por segundo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ruta de almacenamiento";
            // 
            // txtRutaAlmacen
            // 
            this.txtRutaAlmacen.Location = new System.Drawing.Point(189, 3);
            this.txtRutaAlmacen.Name = "txtRutaAlmacen";
            this.txtRutaAlmacen.Size = new System.Drawing.Size(217, 20);
            this.txtRutaAlmacen.TabIndex = 7;
            this.ttpAyuda.SetToolTip(this.txtRutaAlmacen, "Establezca la ruta en donde se guardarán las grabaciones");
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(356, 280);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(275, 280);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ttpAyuda
            // 
            this.ttpAyuda.AutoPopDelay = 10000;
            this.ttpAyuda.InitialDelay = 500;
            this.ttpAyuda.ReshowDelay = 100;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackgroundImage = global::Coruja.Properties.Resources.actualizar2;
            this.btnRestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Location = new System.Drawing.Point(396, 44);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(27, 24);
            this.btnRestaurar.TabIndex = 9;
            this.ttpAyuda.SetToolTip(this.btnRestaurar, "Restaurar valores predeterminados");
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.SystemColors.Window;
            this.btnExaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Image = global::Coruja.Properties.Resources.Search;
            this.btnExaminar.Location = new System.Drawing.Point(382, 4);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(22, 18);
            this.btnExaminar.TabIndex = 8;
            this.btnExaminar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ttpAyuda.SetToolTip(this.btnExaminar, "Haga clic para buscar una carpeta en el equipo");
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // nudFPS
            // 
            this.nudFPS.Location = new System.Drawing.Point(189, 3);
            this.nudFPS.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFPS.Name = "nudFPS";
            this.nudFPS.Size = new System.Drawing.Size(217, 20);
            this.nudFPS.TabIndex = 6;
            this.nudFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ttpAyuda.SetToolTip(this.nudFPS, resources.GetString("nudFPS.ToolTip"));
            this.nudFPS.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // cbxResolucion
            // 
            this.cbxResolucion.DisplayMember = "VGA        (600x480)";
            this.cbxResolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolucion.FormattingEnabled = true;
            this.cbxResolucion.Items.AddRange(new object[] {
            "VGA        (600x480)",
            "SVGA      (800x600)",
            "XGA        (1024x768)"});
            this.cbxResolucion.Location = new System.Drawing.Point(189, 3);
            this.cbxResolucion.Name = "cbxResolucion";
            this.cbxResolucion.Size = new System.Drawing.Size(217, 21);
            this.cbxResolucion.TabIndex = 8;
            this.ttpAyuda.SetToolTip(this.cbxResolucion, "Establezca cual será el tamaño del vídeo grabado en la pantalla.");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudFPS);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(14, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 27);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbxCodec);
            this.panel2.Location = new System.Drawing.Point(14, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 27);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExaminar);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtRutaAlmacen);
            this.panel3.Location = new System.Drawing.Point(14, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 27);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cbxResolucion);
            this.panel4.Location = new System.Drawing.Point(14, 200);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(417, 27);
            this.panel4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Resolución del vídeo grabado";
            // 
            // Opciones
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(444, 312);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNombreForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 340);
            this.Name = "Opciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.Opciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCodec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRutaAlmacen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ToolTip ttpAyuda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxResolucion;
        private System.Windows.Forms.NumericUpDown nudFPS;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnRestaurar;
    }
}