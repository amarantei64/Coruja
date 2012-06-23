namespace Coruja
{
    partial class frmControlVentana
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlVentana));
            this.tlpAyuda = new System.Windows.Forms.ToolTip(this.components);
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.spcContenedor = new System.Windows.Forms.SplitContainer();
            this.btnMOLista = new System.Windows.Forms.Button();
            this.flpListaDis = new System.Windows.Forms.FlowLayoutPanel();
            this.ltvGrabaciones = new System.Windows.Forms.ListView();
            this.fswInspector = new System.IO.FileSystemWatcher();
            this.spcContenedor.Panel1.SuspendLayout();
            this.spcContenedor.Panel2.SuspendLayout();
            this.spcContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswInspector)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyuda.BackgroundImage = global::Coruja.Properties.Resources.ayuda;
            this.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Location = new System.Drawing.Point(740, 8);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(28, 28);
            this.btnAyuda.TabIndex = 4;
            this.btnAyuda.TabStop = false;
            this.tlpAyuda.SetToolTip(this.btnAyuda, "Ayuda de Coruja");
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnOpciones
            // 
            this.btnOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpciones.BackgroundImage = global::Coruja.Properties.Resources.config;
            this.btnOpciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpciones.FlatAppearance.BorderSize = 0;
            this.btnOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpciones.Location = new System.Drawing.Point(686, 8);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(28, 28);
            this.btnOpciones.TabIndex = 2;
            this.btnOpciones.TabStop = false;
            this.tlpAyuda.SetToolTip(this.btnOpciones, "Opciones");
            this.btnOpciones.UseVisualStyleBackColor = true;
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackgroundImage = global::Coruja.Properties.Resources.actualizar;
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(623, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(28, 28);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.TabStop = false;
            this.tlpAyuda.SetToolTip(this.btnActualizar, "Actualizar lista de dispositivos");
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // spcContenedor
            // 
            this.spcContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcContenedor.Location = new System.Drawing.Point(1, 50);
            this.spcContenedor.Name = "spcContenedor";
            this.spcContenedor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcContenedor.Panel1
            // 
            this.spcContenedor.Panel1.Controls.Add(this.btnMOLista);
            this.spcContenedor.Panel1.Controls.Add(this.flpListaDis);
            this.spcContenedor.Panel1MinSize = 140;
            // 
            // spcContenedor.Panel2
            // 
            this.spcContenedor.Panel2.Controls.Add(this.ltvGrabaciones);
            this.spcContenedor.Panel2MinSize = 70;
            this.spcContenedor.Size = new System.Drawing.Size(783, 511);
            this.spcContenedor.SplitterDistance = 403;
            this.spcContenedor.TabIndex = 0;
            // 
            // btnMOLista
            // 
            this.btnMOLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMOLista.FlatAppearance.BorderSize = 0;
            this.btnMOLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMOLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMOLista.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMOLista.Location = new System.Drawing.Point(0, 380);
            this.btnMOLista.Name = "btnMOLista";
            this.btnMOLista.Size = new System.Drawing.Size(783, 23);
            this.btnMOLista.TabIndex = 2;
            this.btnMOLista.Text = "Ocultar lista de grabación";
            this.btnMOLista.UseVisualStyleBackColor = true;
            this.btnMOLista.Click += new System.EventHandler(this.btnMOLista_Click);
            // 
            // flpListaDis
            // 
            this.flpListaDis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpListaDis.AutoScroll = true;
            this.flpListaDis.Location = new System.Drawing.Point(3, 3);
            this.flpListaDis.Name = "flpListaDis";
            this.flpListaDis.Size = new System.Drawing.Size(753, 263);
            this.flpListaDis.TabIndex = 1;
            // 
            // ltvGrabaciones
            // 
            this.ltvGrabaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltvGrabaciones.Location = new System.Drawing.Point(0, 0);
            this.ltvGrabaciones.MultiSelect = false;
            this.ltvGrabaciones.Name = "ltvGrabaciones";
            this.ltvGrabaciones.Size = new System.Drawing.Size(783, 104);
            this.ltvGrabaciones.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ltvGrabaciones.TabIndex = 3;
            this.ltvGrabaciones.UseCompatibleStateImageBehavior = false;
            this.ltvGrabaciones.DoubleClick += new System.EventHandler(this.ltvGrabaciones_DoubleClick);
            this.ltvGrabaciones.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ltvGrabaciones_KeyUp);
            // 
            // fswInspector
            // 
            this.fswInspector.EnableRaisingEvents = true;
            this.fswInspector.SynchronizingObject = this;
            this.fswInspector.Created += new System.IO.FileSystemEventHandler(this.fswInspector_Created);
            this.fswInspector.Deleted += new System.IO.FileSystemEventHandler(this.fswInspector_Deleted);
            this.fswInspector.Renamed += new System.IO.RenamedEventHandler(this.fswInspector_Renamed);
            // 
            // frmControlVentana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.spcContenedor);
            this.Controls.Add(this.btnOpciones);
            this.Controls.Add(this.btnActualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmControlVentana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coruja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControlVentana_FormClosing);
            this.Load += new System.EventHandler(this.cargaFormulario);
            this.spcContenedor.Panel1.ResumeLayout(false);
            this.spcContenedor.Panel2.ResumeLayout(false);
            this.spcContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fswInspector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnOpciones;
        private System.Windows.Forms.ToolTip tlpAyuda;
        private System.Windows.Forms.SplitContainer spcContenedor;
        private System.Windows.Forms.FlowLayoutPanel flpListaDis;
        private System.Windows.Forms.Button btnMOLista;
        private System.Windows.Forms.Button btnAyuda;
        private System.IO.FileSystemWatcher fswInspector;
        private System.Windows.Forms.ListView ltvGrabaciones;
    }
}

