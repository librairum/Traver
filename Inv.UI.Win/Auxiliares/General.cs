using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Telerik.Windows;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Inv.UI.Win
{
    public class General
    {
        public static string GetFileText(string name)
        {
            string fileContents = String.Empty;

            // If the file has been deleted since we took 
            // the snapshot, ignore it and return the empty string.
            if (System.IO.File.Exists(name))
            {
                fileContents = System.IO.File.ReadAllText(name);
            }
            return fileContents;
        }

        /// <summary>
        /// Metoque que permite convertir un LIST en un DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static System.Data.DataTable convertToDataTable<T>(IList<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection properties = System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                System.Data.DataRow row = table.NewRow();
                foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// Muestra mensaje Informativo
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        public static void ShowMessageInformation(string titulo, string mensaje)
        {
            RadMessageBox.Show(mensaje, titulo, MessageBoxButtons.OKCancel, RadMessageIcon.Info);
        }

        /// <summary>
        /// Muestra mensaje de advertencia
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        public static void ShowMessageExclamation(string titulo, string mensaje)
        {
            RadMessageBox.Show(mensaje, titulo, MessageBoxButtons.OKCancel, RadMessageIcon.Exclamation);
        }

        /// <summary>
        /// Muestra mensaje de error
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        public static void ShowMessageError(string titulo, string mensaje)
        {
            RadMessageBox.Show(mensaje, titulo, MessageBoxButtons.OKCancel, RadMessageIcon.Error);
        }

        /// <summary>
        /// Extrae cadena a partir de la izquierda
        /// </summary>
        /// <param name="strCadena"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ExtractLeft(string strCadena, int length)
        {
            return strCadena.Substring(0, length);
        }

        /// <summary>
        /// Extrae Cadena a partir de la derecha
        /// </summary>
        /// <param name="strCadena"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ExtractRigth(string strCadena, int length)
        {
            int valor = strCadena.Length - length;
            return strCadena.Substring(valor, length);
        }

        public static string ExtractMid(string strCadena, int StarIndex, int length)
        {
            return strCadena.Substring(StarIndex, length);
        }

        public static string ExtractMid(string strCadena, int StarIndex)
        {
            return strCadena.Substring(StarIndex);
        }

        /// <summary>
        /// Retorna Url de la ubicacion de reportes
        /// <CreadoPor>Edgar Huarcaya C.</CreadoPor>
        /// </summary>
        /// <returns></returns>
        public static string RutaReportes
        {
            get
            {
                return Path.GetDirectoryName(Directory.GetCurrentDirectory());
            }
        }

        public static void SepararNombres(string nombreCompleto, out string apellidoPaterno, out string apellidoMaterno, out string nombres)
        {
            apellidoPaterno = string.Empty;
            apellidoMaterno = string.Empty;
            nombres = string.Empty;

            string[] separado = nombreCompleto.Split(' ');
            if (separado.Length == 3)
            {
                apellidoPaterno = separado[0];
                apellidoMaterno = separado[1];
                nombres = separado[2];
            }
            else if (separado.Length == 1)
            {
                nombres = separado[0];
            }
            else if (separado.Length == 2)
            {
                apellidoPaterno = separado[0];
                nombres = separado[1];
            }
            else if (separado.Length == 4)
            {
                apellidoPaterno = separado[0];
                apellidoMaterno = separado[1];
                nombres = separado[2] + " " + separado[3];

            }

            else if (separado.Length == 5)
            {
                apellidoPaterno = separado[0];
                apellidoMaterno = separado[1];
                nombres = separado[2] + " " + separado[3] + separado[4];

            }
            else
            {
                nombres = nombreCompleto;
            }
        }

        /// <summary>
        /// Devuelve fecha de día no laborable
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DateTime GetFechaDiaNoLaborable(DateTime fecha)
        {
            try
            {
                DateTime fecCont = fecha;
                int i = 1;
                int cont = 0;

                while (i <= 3)
                {
                    fecha = fecCont.AddDays(1);
                    if ((int)fecCont.DayOfWeek == 6 || (int)fecCont.DayOfWeek == 7)
                    {
                        cont++;
                        break;
                    }
                    else
                    {
                        i++;
                        cont++;
                    }
                }

                fecha = fecha.AddDays(cont);
                return fecha;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
