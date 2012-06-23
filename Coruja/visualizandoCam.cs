using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using AForge.Video;
using System.Drawing;
using Coruja.Algoritmos;
using Coruja.Properties;
using System.Collections;
using AForge.Video.FFMPEG;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using AForge.Video.DirectShow;
using System.Collections.Generic;

namespace Coruja
{
    /// <summary>
    /// Formulario en donde se activa la cámara para recibir video.
    /// </summary>
    public partial class visualizandoCam : Form
    {
        public visualizandoCam()
        {
            InitializeComponent();
        }
        ~visualizandoCam() /* PARA LA PRÓXIMA VERSIÓN EN VEZ DE APLICAR UN DESTRUCTOR USA EL MÉTODO POLIMÓRFICO DEL DISPOSE. */
        {
            /* Incluir la parte de abajo más this = null; para el polimorfismo del Dispose. */
            /* public override void Dispose()
             * {
             *      base.Dispose();
             *      this.grabacion = null;
             *      this.copia = null;
             *      this.hConfig = null;
             * }
             */
            this.grabacion = null;
            this.copia = null;
            this.hConfig = null;
        }

        #region [MIEMBROS DE DATOS]

        private Herramientas hConfig = new Herramientas(); //Para manipular la configuración.

        private VideoCaptureDevice camara = null;       //Representa la cámara y manipula la reproducción
        private string ruta, nombreCam;                       //Contiene el nombre y ruta de la cámara

        private Bitmap copia;                           //Se usa para reestructurar la imagen a un tamaño personalizado

        bool grabando = false;                          //Para saber si se ha presionado el botón de grabar
        VideoFileWriter grabacion;                      //Recurso de grabación
        
        private Size Resolucion;
        private VideoCodec Codec;

        #endregion

        #region [PROPIEDADES]
        /// <summary>
        ///Propiedad que le establece la ubicación de la cámara a la variable ruta, si se le envia
        ///una cadena vacia se genera una excepción. Es usada desde otro Formulario
        /// </summary>
        public string rutaCamara
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("No se puede obtener la ruta al dispositivo.", "Error de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                    this.ruta = value;
            }
            get { return this.ruta; }
        }

        /// <summary>
        /// Propiedad que le establece la ubicación de la cámara a la variable nombreCam, la utilizo
        /// para que la ventana tome el nombre de la cámara. Es usada desde otro Formulario.
        /// </summary>
        public string tituloVentana
        {
            set
            {
                this.nombreCam = string.IsNullOrEmpty(value) ? "Dispositivo desconocido": value;
            }
            get { return this.nombreCam; }
        }

        #endregion

        #region [REPRODUCCIÓN DE LA CÁMARA]

        public void detenerVideo()
        {
            if (this.camara != null)
                if (this.camara.IsRunning)
                    this.camara.SignalToStop();
        }

        private void reproduce(string rutaDispositivo)
        {
            this.camara = new VideoCaptureDevice(this.rutaCamara);
            this.camara.NewFrame += new NewFrameEventHandler(enviandoVideo);
            this.camara.PlayingFinished += new PlayingFinishedEventHandler(finVideo);
            
            this.camara.Start();
        }

        #endregion

        #region [EVENTOS]
        private void visualizandoCam_Load(object sender, EventArgs e)
        {
            this.Resolucion = hConfig.interpretarResolucion(Settings.Default.Resolucion);
            this.Codec = hConfig.interpretaCodec(Settings.Default.Codec);

            /* Empezando con la reproducción y poniendo el titulo de la cámara. */
            reproduce(rutaCamara);
            this.Text = this.tituloVentana;
        }

        private void enviandoVideo(object sender, NewFrameEventArgs e)
        {
            Bitmap imagen = (Bitmap)e.Frame.Clone();
            this.pbxReproductor.Image = imagen;
            
            /* OJO, se ha duplicado la imagen y se le ha establecido un tamaño muy distinto
             * al que devuelve la cámara, esta ha sido la solución a los constantes errores
             * del formato, los numeros tienen que ser multiplos de 2, o sea, numeros pares.*/
            try
            {
                copia = new Bitmap(e.Frame, this.Resolucion);
                grabacion.WriteVideoFrame(copia);
            }
            //Se genera porque tengo el recurso nulo hasta que no precione el botón, no hago nada para manejarla.
            catch (NullReferenceException error) { }
            /* Se genera porque cuando presiono el botón detener se cierra el archivo y no puedo añadir más imágenes,
             * pero el proceso de transmisión no se detiene, sólo el de escritura. No hago nada para manejarla, sólo que no se finalice el programa. */
            catch (IOException error) { }
        }

        private void visualizandoCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.camara.IsRunning)
                detenerVideo();
            this.camara = null;
        }

        /// <summary>
        /// Si se para el video por alguna u otra razón el archivo debe mantener lo poco que grabó hasta ese momento.
        /// La excepción es porque si no he presionado el botón de grabar no he creado el recurso de grabación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finVideo(object sender, ReasonToFinishPlaying e)
        {
            try
            {
                this.grabacion.Close();
            }
            catch (NullReferenceException error) { }

            /* Si el dispositivo se desconecta entonces que muestre el error*/
            if (e == ReasonToFinishPlaying.DeviceLost)
            {
                MessageBox.Show("Se ha perdido la comunicación con el dispositivo", "Dispositivo desconectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!grabando)
            {
                this.grabacion = new VideoFileWriter(); //Creando la instancia y estableciendo el codec.

                if (!Directory.Exists(Settings.Default.Almacenamiento))
                    Directory.CreateDirectory(Settings.Default.Almacenamiento);

                //Creando la grabación, estableciendo el nombre y su resolución
                int id = int.Parse(this.Name.Substring(8)) + 1;
                string nombreArchivo = Settings.Default.Almacenamiento + ("Cam" + id + '-') + DateTime.Now.ToFileTime() + hConfig.extension(this.Codec);
                try
                {
                    grabacion.Open(nombreArchivo, this.Resolucion.Width, this.Resolucion.Height, Settings.Default.FPS, this.Codec);
                    this.pbxGrabando.Visible = true;
                }
                catch (VideoException error) { return; } //Se produce si no se encuentra el codec, no es lo mismo a que si no encuentra el archivo de codecs.

                this.grabando = true;
                this.btnDetener.BackgroundImage = global::Coruja.Properties.Resources.parar;
            }
            else
            {
                this.grabando = false;
                this.grabacion.Close();
                this.pbxGrabando.Visible = false;
                this.btnDetener.BackgroundImage = global::Coruja.Properties.Resources.grabar;
            }
        }
        #endregion
    }
}
