using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Coruja.Algoritmos
{
    /// <summary>
    /// Delegado que controla un evento Click para las representaciones de las cámaras, se usa como un puente para
    /// manipular un método de otra clase desde esta.
    /// </summary>
    public delegate void ventanaReproduccion(object sender, EventArgs e);

    /// <summary>
    /// Contiene la definición de los componentes prediseñados para representar las cámaras y añadirle su evento.
    /// </summary>
    public class Estructura
    {
        #region [COMPONENTES PREESTABLECIDOS PARA AÑADIR]

        public Button nuevaRepresentacion(int id, string contenido, Bitmap imagen)
        {
            Button idBoton = new Button();
            idBoton.TabIndex = 0;
            idBoton.Image = imagen;
            idBoton.Name = "idBtnRep" + id;
            idBoton.FlatStyle = FlatStyle.Flat;
            idBoton.FlatAppearance.BorderSize = 0;
            idBoton.UseVisualStyleBackColor = true;
            idBoton.BackgroundImageLayout = ImageLayout.Zoom;
            idBoton.TextAlign = ContentAlignment.BottomCenter;
            idBoton.TextImageRelation = TextImageRelation.ImageAboveText;
            idBoton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            idBoton.Bounds = new Rectangle(new Point(), new Size(200, 87));
            idBoton.Font = new Font("Arial", 8.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            /* Si el texto pasa de 33 letras lo recorto para que no se corra de la pantalla */
            string texto = String.Format("Cámara {0}: {1}", (id + 1), contenido);
            idBoton.Text = (texto.Length > 33) ? texto.Substring(0, 33) : texto;
            
            return idBoton;
        }

        /// <summary>
        /// Crea un nuevo formulario prediseñado de tipo visualizandoCam.
        /// </summary>
        /// <param name="id">Identificador de este formulario</param>
        /// <param name="nombreCam">Nombre de la cámara que se va a controlar</param>
        /// <param name="ruta">Ruta del dispositivo, se obtiene del objeto VideoFilterCollection</param>
        public visualizandoCam nuevaReproducion(int id, string nombreCam, string ruta)
        {
            visualizandoCam nuevoVideo = new visualizandoCam();
            nuevoVideo.Name = "idFrmRep" + id;
            nuevoVideo.tituloVentana = "Cámara " + (id + 1) + ": " + nombreCam;
            nuevoVideo.rutaCamara = ruta;

            return nuevoVideo;
        }

        public ListViewItem nuevoRepArchivo(string nombre)
        {
            ListViewItem nuevoNodo = new ListViewItem(nombre);
            nuevoNodo.Name = nombre;

            return nuevoNodo;
        }

        public ListViewGroup nuevoGrpArchivo(string nombre)
        {
            ListViewGroup nuevoGrupo = new ListViewGroup(nombre, HorizontalAlignment.Center);
            nuevoGrupo.Name = nombre;

            return nuevoGrupo;
        }
        #endregion

        #region [OTROS]
        /// <summary>
        /// Agrega un evento Click a todos los PictureBox que estén dentro del control establecido.
        /// </summary>
        /// <param name="accion">Delegado a la función que desenvolverá el evento Click</param>
        public void agregarEventoReproducir(Control aLosHijosDe, ventanaReproduccion accion)
        {
            foreach (Control hijo in aLosHijosDe.Controls)
            {
                if (hijo.GetType().Name == "Button")
                    hijo.Click += new EventHandler(accion);
            }
        }

        /// <summary>
        /// Mensaje común para las tareas de cerrado de ventanas.
        /// </summary>
        public bool alerta()
        {
            if (MessageBox.Show("Este proceso cerrará todas las cámaras en reproducción \n¿Desea continuar?",
                    "Cerrar formulario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                return true;
            else
                return false;
        }
        #endregion
    }
}
