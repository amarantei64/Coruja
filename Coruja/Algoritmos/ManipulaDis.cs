using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Coruja.Properties;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Collections.Generic;

namespace Coruja.Algoritmos
{
    /// <summary>
    /// Contiene los métodos que se encargan de dibujar las representaciones de las cámaras y ficheros.
    /// </summary>
    class ManipulaDis
    {
        ~ManipulaDis()
        {
            this.idReproduccionCam = null; /* OJO: POSIBLE VIOLACIÓN DE MEMORIA */
        }

        #region [MIEMBROS DE DATOS]
        private FilterInfoCollection dispositivos;      //Objeto que contiene la cantidad de cámaras con su nombre y su ruta.

        private visualizandoCam[] idReproduccionCam = null;
        private Estructura rep = new Estructura();

        #endregion

        #region [PROPIEDADES]
        public FilterInfoCollection filtroCamaras
        {
            get { return this.dispositivos; }
        }

        /// <summary>
        /// Propiedad que contiene las ventanas de reproducción de cámaras creadas.
        /// </summary>
        public visualizandoCam[] ventanas
        {
            get { return this.idReproduccionCam; }
        }
        #endregion

        #region [MÉTODOS]
        /// <summary>
        /// Examina el equipo para ver las cámaras conectadas y crea un vector según la cantidad encontrada.
        /// </summary>
        public void buscarDispositivos(Control anexarAlElemento)
        {
            this.dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int cantidad = this.dispositivos.Count;

            if (cantidad >= 1)
            {
                idReproduccionCam = new visualizandoCam[cantidad];

                crearPaquetePrev(cantidad, anexarAlElemento);
            }
            else
            {
                MessageBox.Show("No se han encontrado ninguna cámara de video en el equipo\nPor favor conecte el dispositivo y actualice la lista.",
                    "Error de dispositivos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// Añade los elementos que representarán las cámaras al control establecido.
        /// </summary>
        private void crearPaquetePrev(int cantidad, Control anexarAlElemento)
        {
            for (int c = 0; c < cantidad; c++)
            {
                this.idReproduccionCam[c] = rep.nuevaReproducion(c, this.filtroCamaras[c].Name, this.filtroCamaras[c].MonikerString);

                /* Agrego estos botones al panel que se utiliza como contenedor principal */
                anexarAlElemento.Controls.Add(rep.nuevaRepresentacion(c, this.dispositivos[c].Name, Resources.camara1));
            }
        }

        /// <summary>
        /// Crea una lista de todos los archivos dentro del directorio de grabación según el criterio de búsqueda
        /// para la carga del visor de ficheros de la aplicación.
        /// </summary>
        public void listarArchivos(ListView anexarAlArbol)
        {
            string ruta;

            /* Consultando los archivos según el criterio de extensiones */
            IEnumerable<string> nodos = from archivo in Directory.GetFiles(Settings.Default.Almacenamiento)
                                        where extensionCorrecta(archivo)
                                        select Path.GetFileName(archivo);
            
            /* Creando los grupos según la fecha */
            foreach (string fichero in nodos)
            {
                ruta = Settings.Default.Almacenamiento + fichero;
                anexarNuevoElemento(ruta, anexarAlArbol);
            }
        }

        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        public void anexarNuevoElemento(string rutaArchivo, ListView anexarAlArbol)
        {
            /* Obteniendo la fecha de creación del archivo */
            string fechaCreacion = File.GetCreationTime(rutaArchivo).ToShortDateString();

            /* Creando un grupo con esa fecha en caso de que no exista. */
            if (!existeElGrupo(fechaCreacion, anexarAlArbol))
                anexarAlArbol.Groups.Add(rep.nuevoGrpArchivo(fechaCreacion));

            /* Creando el elemento y añadiendolo a su grupo correspondiente. */
            ListViewItem elemento = rep.nuevoRepArchivo(Path.GetFileName(rutaArchivo));
            elemento.Group = asignarGrupo(fechaCreacion, anexarAlArbol);
            anexarAlArbol.Items.Add(elemento);
        }

        /// <summary>
        /// Elimina un elemento según la búsqueda que está dentro del ListView
        /// </summary>
        public void eliminarElemento(string nombre, ListView anexarAlArbol)
        {
            foreach(ListViewItem elemento in anexarAlArbol.Items)
            {
                if (elemento.Text == nombre)
                {
                    anexarAlArbol.Items.Remove(elemento);
                    return;
                }
            }
        }

        /// <summary>
        /// Cambia el nombre a un elemento dentro del ListView.
        /// </summary>
        public void cambiarNombreAlElemento(string viejo, string nuevo, ListView contenedor)
        {
            foreach (ListViewItem elemento in contenedor.Items)
            {
                if (elemento.Text == viejo)
                {
                    elemento.Text = nuevo;
                    return;
                }
            }
        }

        /// <summary>
        /// Comprueba si el archivo tiene las extensiones manejadas por este programa, según los codecs
        /// </summary>
        public bool extensionCorrecta(string rutaArchivo)
        {
            string[] extensiones = new string[] { ".wmv", ".mp4", ".flv", ".avi" };
            foreach (string ext in extensiones)
                if (ext == Path.GetExtension(rutaArchivo))
                    return true;
            return false;
        }

        /// <summary>
        /// Comprueba que el nombre establecido está repetido dentro de los grupos en el ListView
        /// </summary>
        private bool existeElGrupo(string nombre, ListView listViewPadre)
        {
            foreach (ListViewGroup c in listViewPadre.Groups)
                if (c.Header == nombre)
                    return true;
            return false;
        }

        /// <summary>
        /// Devuelve un ListViewGroup según el criterio de búsqueda para ser añadido a un elemento ListViewItem
        /// en la función anexarNuevoElemento()
        /// </summary>
        private ListViewGroup asignarGrupo(string criterio, ListView listViewPadre)
        {
            foreach (ListViewGroup c in listViewPadre.Groups)
                if (c.Header == criterio)
                    return c;
            return null; /* Que no ponga nada en caso de que no lo encuentre. */
        }

        #endregion
    }
}
