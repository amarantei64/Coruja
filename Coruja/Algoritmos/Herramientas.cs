using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Drawing;
using Coruja.Properties; /* Configuración de la aplicación */
using System.Collections;
using AForge.Video.FFMPEG;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Coruja.Algoritmos
{
    /// <summary>
    /// Enumeración que contiene los filtros de búsqueda para los algoritmos de enfoque o cierre de ventanas.
    /// </summary>
    public enum buscarVentanaPor { nombre, tipo, titulo }

    /// <summary>
    /// Contiene algoritmos clave de la aplicación, principalmente el manejo de la configuración.
    /// </summary>
    public class Herramientas
    {
        #region [ALGORITMOS DE VENTANAS]
        /// <summary>
        /// Cierra todas las ventanas según el criterio y el filtro, si el filtro es por nombre se cerrará
        /// una sola ventana.
        /// </summary>
        public void cerrarVentanaHija(string criterio, buscarVentanaPor opcion)
        {
            if (opcion == buscarVentanaPor.nombre)
            {
                for (int c = Application.OpenForms.Count - 1; c >= 0; c--)
                    if (Application.OpenForms[c].Name == criterio)
                    {
                        Application.OpenForms[c].Close();
                        return;
                    }
            }
            else if (opcion == buscarVentanaPor.tipo)
            {
                for (int c = Application.OpenForms.Count - 1; c >= 0; c--)
                    if (Application.OpenForms[c].GetType().Name == criterio)
                        Application.OpenForms[c].Close();
            }
            else if (opcion == buscarVentanaPor.titulo)
            {
                for (int c = Application.OpenForms.Count - 1; c >= 0; c--)
                    if (Application.OpenForms[c].Text == criterio)
                        Application.OpenForms[c].Close();
            }
        }

        /// <summary>
        /// Devuelve verdadero si se ha encontrado una ventana hija abierta con el criterio establecido.
        /// </summary>
        public bool comprobarVentanaAbierta(string criterio, buscarVentanaPor opcion)
        {
            if (opcion == buscarVentanaPor.nombre)
            {
                foreach (Form hijo in Application.OpenForms)
                    if (hijo.Name == criterio)
                        return true;
            }
            else if (opcion == buscarVentanaPor.tipo)
            {
                foreach (Form hijo in Application.OpenForms)
                    if (hijo.GetType().Name == criterio)
                        return true;
            }
            else if (opcion == buscarVentanaPor.titulo)
            {
                foreach (Form hijo in Application.OpenForms)
                    if (hijo.Text == criterio)
                        return true;
            }
            return false;
        }
        #endregion

        #region [ALGORITMOS DE CADENAS]
        /// <summary>
        /// Devuelve falso si la cadena contiene un caracter inválido como nombre para Sistemas Windows.
        /// </summary>
        public bool verificarRuta(string ruta)
        {
            if (string.IsNullOrEmpty(ruta.Trim())) //Limpiando los espacios en blanco con Trim
                return false;
            else
            {
                short doblePunto = 0;
                string[] noValido = new string[] { @"\\", "//", "*", "?", "¿", "\"", "|", "<", ">" };
                foreach (string c in noValido)
                    if (ruta.Contains(c))
                        return false;

                /* Aqui se comprueba que la ruta solo contengan los dos puntos de la unidad C:\Coruja */
                foreach (char c in ruta)
                {
                    if (c == ':')
                        doblePunto += 1;
                    if (doblePunto > 1)
                        return false;
                }
            }
            return true;
        }

        public bool noContieneNumeros(string texto)
        {
            foreach (char c in texto)
                if (!char.IsNumber(c))
                    return true;
            return false;
        }
        #endregion

        public Size interpretarResolucion(int numeroVector)
        {
            switch (numeroVector)
            {
                case 0: return new Size(600, 480);
                case 1: return new Size(800, 600);
                default: return new Size(1024, 768);
            }
        }

        public VideoCodec interpretaCodec(int idCodec)
        {
            switch(idCodec)
            {
                case 0: return VideoCodec.Raw;
                case 1: return VideoCodec.MPEG4;
                case 2: return VideoCodec.WMV2;
                case 3: return VideoCodec.FLV1;
                default: throw new ArgumentException("Este codec no está soportado.");
            }
        }

        public string extension(VideoCodec idCodec)
        {
            switch (idCodec)
            {
                case VideoCodec.MPEG4: return ".mp4";
                case VideoCodec.FLV1: return ".flv";
                case VideoCodec.WMV2: return ".wmv";
                case VideoCodec.Raw: return ".avi";
                default: throw new ArgumentException("Este codec no está soportado.");
            }
        }
    }
}
