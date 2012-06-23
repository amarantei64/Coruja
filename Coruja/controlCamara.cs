using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Drawing;
using Coruja.Properties;
using Coruja.Algoritmos;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Coruja
{
    public partial class frmControlVentana : Form
    {
        public frmControlVentana()
        {
            InitializeComponent();
        }

        #region[MIEMBROS DE DATOS]
        private ManipulaDis mpl = new ManipulaDis();
        private Estructura rep = new Estructura();
        private Herramientas f = new Herramientas();
        #endregion

        #region [MÉTODOS PARA LA CARGA]
        /// <summary>
        /// Comprueba que las librerías necesarias están dentro de la carpeta, de lo contrario muestra un mensaje indicando que no puede continuar.
        /// </summary>
        /// <returns>Retorna falso si no las encuentra.</returns>
        private bool comprobarLibrerías()
        {
            string[] librerías = new string[] { "AForge.Video.DirectShow.dll", "AForge.Video.FFMPEG.dll",
                "AForge.Video.dll", "avcodec-52.dll", "avformat-52.dll", "avutil-50.dll", "swscale-0.dll"};

            foreach(string lib in librerías)
            {
                if (!File.Exists(lib))
                {
                    MessageBox.Show("La aplicación no puede iniciar porque la libreria " + lib + " no fue encontrada\nPongase en contacto con el administrador",
                        "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ejecuta el formulario de reproducción y grabación de la cámara.
        /// </summary>
        /// <param name="id">Identificación del formulario</param>
        private void ejecutaReproduccion(int id)
        {
            if (f.comprobarVentanaAbierta(mpl.ventanas[id].Name, buscarVentanaPor.nombre))
            {
                mpl.ventanas[id].Focus(); //Si ya está abierta que la enfoque.
            }
            else
            {
                try { mpl.ventanas[id].Show(); }
                catch (ObjectDisposedException) //En caso de que el CLR borre el formulario lo haga de nuevo
                {
                    mpl.ventanas[id] = rep.nuevaReproducion(id, mpl.filtroCamaras[id].Name, mpl.filtroCamaras[id].MonikerString);
                    mpl.ventanas[id].Show();
                }
            }
        }

        private void dibujarComponentes()
        {
            Control listaCam = this.flpListaDis as Control;

            mpl.buscarDispositivos(listaCam);
            rep.agregarEventoReproducir(listaCam, new ventanaReproduccion(reproducirCam));
        }
        #endregion

        #region [EVENTOS]

        private void cargaFormulario(object sender, EventArgs e)
        {
            if (!comprobarLibrerías())
                Application.ExitThread(); //Si no encuentra una librería que cierre el programa.
            else
            {
                if (string.IsNullOrEmpty(Settings.Default.Almacenamiento))
                {
                    Settings.Default.Almacenamiento = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Coruja\Grabaciones\";
                    Settings.Default.Save();
                }
                if (!Directory.Exists(Settings.Default.Almacenamiento))
                    Directory.CreateDirectory(Settings.Default.Almacenamiento);

                this.fswInspector.Path = Settings.Default.Almacenamiento;
                dibujarComponentes();
                mpl.listarArchivos(this.ltvGrabaciones);
            }
        }

        private void reproducirCam(object sender, EventArgs e)
        {
            Button imgPresionada = (Button)sender;
            int num = Convert.ToInt32(imgPresionada.Name.Substring(8));

            ejecutaReproduccion(num);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (f.comprobarVentanaAbierta("visualizandoCam", buscarVentanaPor.tipo))
            {
                if (rep.alerta())
                {
                    f.cerrarVentanaHija("visualizandoCam", buscarVentanaPor.tipo);
                    this.flpListaDis.Controls.Clear();

                    dibujarComponentes();
                }
            }
            else
            {
                this.flpListaDis.Controls.Clear();

                dibujarComponentes();
            }
        }

        private void frmControlVentana_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f.comprobarVentanaAbierta("visualizandoCam", buscarVentanaPor.tipo))
            {
                if (rep.alerta())
                    f.cerrarVentanaHija("visualizandoCam", buscarVentanaPor.tipo);
                else
                    e.Cancel = true;
            }
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            Opciones frmOpciones = new Opciones();
            frmOpciones.ShowDialog();

            frmOpciones.Dispose();
        }

        private void btnMOLista_Click(object sender, EventArgs e)
        {
            if (!this.spcContenedor.Panel2Collapsed)
            {
                this.spcContenedor.Panel2Collapsed = true;
                this.btnMOLista.Text = "Mostrar lista de grabación";
            }
            else
            {
                this.spcContenedor.Panel2Collapsed = false;
                this.btnMOLista.Text = "Ocultar lista de grabación";
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Ayuda frmAyuda = new Ayuda();
            frmAyuda.ShowDialog();

            frmAyuda.Dispose();
        }

        #region [Vigilando cambios en la carpeta de grabación]
        private void fswInspector_Created(object sender, FileSystemEventArgs e)
        {
            if(mpl.extensionCorrecta(e.Name))
                mpl.anexarNuevoElemento(e.FullPath, this.ltvGrabaciones);
        }

        private void fswInspector_Deleted(object sender, FileSystemEventArgs e)
        {
            mpl.eliminarElemento(e.Name, this.ltvGrabaciones);
        }

        private void fswInspector_Renamed(object sender, RenamedEventArgs e)
        {
            mpl.cambiarNombreAlElemento(e.OldName, e.Name, this.ltvGrabaciones);
        }
        #endregion

        #region [Controlando la invocación del reproductor para el archivo seleccionado]
        private void ltvGrabaciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                /* Abriendo el archivo en la ruta especificada, se toma el nombre del ListViewItem más la ruta del
                 * FileSystemWacher que es la misma a la que apunta todas las grabaciones. */
                string ruta = this.fswInspector.Path + this.ltvGrabaciones.SelectedItems[0].Text;
                Process.Start(ruta);
            }
            catch (ArgumentOutOfRangeException error) { } /* Se produce si no se selecciona nada y el control tiene el foco */
        }

        private void ltvGrabaciones_KeyUp(object sender, KeyEventArgs e)
        {
            /* Que haga la misma acción que el doble clic si presiona la tecla ENTER */
            if(e.KeyData == Keys.Enter)
                ltvGrabaciones_DoubleClick(sender, null);
        }
        #endregion

        #endregion
    }
}