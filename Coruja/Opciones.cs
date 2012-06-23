using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using Coruja.Properties; /* Configuración de la aplicación */
using Coruja.Algoritmos;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Coruja
{
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();
        }
        
        private Herramientas her = new Herramientas();

        #region [EVENTOS]

        /// <summary>
        /// Botón aceptar que escribe los cambios del programa en el archivo XML, antes de hacerlo verifica que la ruta donde guardará los
        /// vídeos es válida, de lo contrario muestra un mensaje notificándolo y no te deja salir.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (her.verificarRuta(this.txtRutaAlmacen.Text))
            {
                if (this.txtRutaAlmacen.Text[this.txtRutaAlmacen.Text.Length - 1] != '\\')
                    this.txtRutaAlmacen.Text += '\\';

                Settings.Default.Almacenamiento = this.txtRutaAlmacen.Text;
                Settings.Default.Resolucion = this.cbxResolucion.SelectedIndex;
                Settings.Default.Codec = this.cbxCodec.SelectedIndex;
                Settings.Default.FPS = (int)this.nudFPS.Value;

                Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("La dirección no debe contener los siguientes caracteres:\n" + @"\\" + ", //, *, ?, ¿ , \", |, <, >", "Ruta inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// El botón cancelar, no necesita de validaciones.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Opciones_Load(object sender, EventArgs e)
        {
            this.cbxCodec.SelectedIndex = Settings.Default.Codec;
            this.cbxResolucion.SelectedIndex = Settings.Default.Resolucion;
            this.nudFPS.Value = Settings.Default.FPS;
            this.txtRutaAlmacen.Text = Settings.Default.Almacenamiento;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog examinar = new FolderBrowserDialog())
            {
                examinar.Description = "Directorio en donde se guardarán los vídeos";

                if (examinar.ShowDialog() == DialogResult.OK)
                    this.txtRutaAlmacen.Text = examinar.SelectedPath;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.txtRutaAlmacen.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Coruja\Grababión\";
            this.cbxCodec.SelectedIndex = 2;
            this.cbxResolucion.SelectedIndex = 1;
            this.nudFPS.Value = 10;
        }
        #endregion
    }
}