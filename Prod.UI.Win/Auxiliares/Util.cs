﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic;
using System.Linq;

namespace Prod.UI.Win
{
    public static class Util
    {

        public static bool IsValidoDato(int key)
        {
            bool retorno = false;
            if (key >= 48 && key <= 56) retorno = true;
            if (key >= 48 && key <= 56) retorno = true;

            return retorno;
        }

        public static void SendTab(int key)
        {
            if (key == Keys.Enter.GetHashCode()) SendKeys.Send("{TAB}");
            //if (key == Keys.Down.GetHashCode()) SendKeys.Send("{TAB}");
            //if (key == Keys.Up.GetHashCode()) SendKeys.Send("{TAB}");
        }

        static void enfocarRegistro(Control xsender)
        {
            string tipo = xsender.GetType().ToString();

            if ((xsender) is RadTextBox)
            {
                ((RadTextBox)xsender).SelectionStart = 0;
                ((RadTextBox)xsender).SelectionLength = ((RadTextBox)xsender).Text.Length;
            }
        }
        public static void SendEnter(KeyEventArgs evt, Control obj, Form frm = null)
        {
            //if (!(obj is RadGridView)) { }
            if (evt.KeyCode == Keys.Enter)
            {
                evt.Handled = true;
                SendKeys.Send("{TAB}");
                //enfocarRegistro(obj);

            }
            else if (evt.KeyCode == Keys.Up || evt.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{TAB}");
                //enfocarRegistro(obj);

            }
            else if (evt.KeyCode == Keys.Down || evt.KeyCode == Keys.Right)
            {
                SendKeys.Send("{TAB}");
                //enfocarRegistro(obj);                
            }


        }
        public static string convertiracadena(object valor)
        { 
            string cadena ="";
            if (valor == null)
            {
                cadena = "";
            }
            else {
                cadena = valor.ToString();
            }


            return cadena;
        }

        public static string convertirahora(object valor)
        {
            string cadena = "";
            if (valor == null)
            {
                cadena = "00:00";
            }
            else
            {
                if (valor.ToString() == "__:__")
                {
                    cadena = "00:00";
                }
                else
                {
                    cadena = valor.ToString();
                }
            }
            return cadena;
        }
        public static string convertirahoras(string numero) { 
            string horaformato = "";
            string hora="";
            string minuto="";

            
            bool esnumerico = Information.IsNumeric(numero);

            if (esnumerico)
            {
                 //busca punto
                int posicion =  numero.IndexOf('.');
                    
                //no encontro punto 
                if (posicion == -1)
                {                    
                    //devolver Hora
                    //horaformato = numero.Length < 2 ?  string.Concat("0", numero) : numero ;  
                    //horaformato = horaformato + ":" + "00";
                    hora = numero.Length < 2 ? string.Concat("0", numero) : numero;
                    minuto = "00";

                    horaformato = hora + ":" + minuto;
                }
                else { 
                //encontro punto
                        hora = numero.Substring(0,posicion);
                        minuto = numero.Substring(posicion + 1, numero.Length - (posicion + 1));

                        // Rellenar con cero
                        //minuto = minuto.Length < 1 ? string.Concat("0", minuto) : minuto; 
                        hora = hora.Length < 2 ? string.Concat("0", hora) : hora;
                        minuto = minuto.Length < 2 ? string.Concat("0", minuto) : minuto;  

                }

                horaformato = hora + ":" + minuto;
            }
            else {
                    horaformato = numero;
                    //return "Hora no valido";
                }

           
            return horaformato;
        }


        public static string convertiracero(object valor)
        {
            string cadena = "0";
            if (valor == null)
            {
                cadena = "0";
            }
            else
            {
                cadena = valor.ToString();
            }


            return cadena;
        }

        public static string ConvertiraXML(IEnumerable<string> lista)
        {
            var sb = new StringBuilder();

            sb.Append("<DataSet>");

            foreach (var codigo in lista)
            {
                sb.Append("<tbl><Codigo>");
                sb.Append(codigo);
                sb.Append("</Codigo></tbl>");
            }

            sb.Append("</DataSet>");

            return sb.ToString();
        }
        public static string ConvertiraXMLMateriaPrima(IEnumerable<string> lista)
        {
            var sb = new StringBuilder();

            sb.Append("<DataSet>");
            foreach (var codigo in lista)
            {
                string[] datos = codigo.Split('|');
                string campo1valor = datos[0];
                string campo2valor = datos[1];
                string campo3valor = datos[2];
                string campo4valor = datos[3];
                string campo5valor = datos[4];
                string campo6valor = datos[5];
                string campo7valor = datos[6];
                string campo8valor = datos[7];
                string campo9valor = datos[8];
                string campo10valor = datos[9];

                //
                sb.Append("<tbl><campo1>");
                sb.Append(campo1valor);
                sb.Append("</campo1>");
                //
                sb.Append("<campo2>");
                sb.Append(campo2valor);
                sb.Append("</campo2>");
                //
                sb.Append("<campo3>");
                sb.Append(campo3valor);
                sb.Append("</campo3>");
                //
                sb.Append("<campo4>");
                sb.Append(campo4valor);
                sb.Append("</campo4>");
                //
                sb.Append("<campo5>");
                sb.Append(campo5valor);
                sb.Append("</campo5>");
                //
                sb.Append("<campo6>");
                sb.Append(campo6valor);
                sb.Append("</campo6>");
                //
                sb.Append("<campo7>");
                sb.Append(campo7valor);
                sb.Append("</campo7>");

                sb.Append("<campo8>");
                sb.Append(campo8valor);
                sb.Append("</campo8>");

                sb.Append("<campo9>");
                sb.Append(campo9valor);
                sb.Append("</campo9>");

                sb.Append("<campo10>");
                sb.Append(campo10valor);
                sb.Append("</campo10></tbl>");
            }

            sb.Append("</DataSet>");

            return sb.ToString();
        }
        
        public static string ConvertiraXMLvariasColumnas(IEnumerable<string> lista)
        {
            var sb = new StringBuilder();

            sb.Append("<DataSet>");
            foreach (var codigo in lista)
            {
               
                string[] datos = codigo.Split('|');
                string campo1valor = datos[0];
                string campo2valor = datos[1];
                string campo3valor = datos[2];
                string campo4valor = datos[3];
                string campo5valor = datos[4];
                string campo6valor = datos[5];
                string campo7valor = datos[6];
                string campo8valor = datos[7];
                string campo9valor = datos[8];
                string campo10valor = datos[9];
                string campo11valor = datos[10];
                string campo12valor = datos[11];
                string campo13valor = datos[12];
                string campo14valor = datos[13];
                string campo15valor = datos[14];
                string campo16valor = datos[15];
                string campo17valor = datos[16];
                string campo18valor = datos[17];
                string campo19valor = datos[18];
                string campo20valor = datos[19];
                string campo21valor = datos[20];
                string campo22valor = datos[21];
                string campo23valor = datos[22];
                string campo24valor = datos[23];
                string campo25valor = datos[24];
                string campo26valor = datos[25];
                string campo27valor = datos[26];
                string campo28valor = datos[27];
                //
                sb.Append("<tbl><campo1>");
                sb.Append(campo1valor);
                sb.Append("</campo1>");
                //
                sb.Append("<campo2>");
                sb.Append(campo2valor);
                sb.Append("</campo2>");
                //
                sb.Append("<campo3>");
                sb.Append(campo3valor);
                sb.Append("</campo3>");
                //
                sb.Append("<campo4>");
                sb.Append(campo4valor);
                sb.Append("</campo4>");
                //
                sb.Append("<campo5>");
                sb.Append(campo5valor);
                sb.Append("</campo5>");
                //
                sb.Append("<campo6>");
                sb.Append(campo6valor);
                sb.Append("</campo6>");
                //
                sb.Append("<campo7>");
                sb.Append(campo7valor);
                sb.Append("</campo7>");

                sb.Append("<campo8>");
                sb.Append(campo8valor);
                sb.Append("</campo8>");

                sb.Append("<campo9>");
                sb.Append(campo9valor);
                sb.Append("</campo9>");

                sb.Append("<campo10>");
                sb.Append(campo10valor);
                sb.Append("</campo10>");

                sb.Append("<campo11>");
                sb.Append(campo11valor);
                sb.Append("</campo11>");

                sb.Append("<campo12>");
                sb.Append(campo12valor);
                sb.Append("</campo12>");

                sb.Append("<campo13>");
                sb.Append(campo13valor);
                sb.Append("</campo13>");

                sb.Append("<campo14>");
                sb.Append(campo14valor);
                sb.Append("</campo14>");

                sb.Append("<campo15>");
                sb.Append(campo15valor);
                sb.Append("</campo15>");

                sb.Append("<campo16>");
                sb.Append(campo16valor);
                sb.Append("</campo16>");

                sb.Append("<campo17>");
                sb.Append(campo17valor);
                sb.Append("</campo17>");

                sb.Append("<campo18>");
                sb.Append(campo18valor);
                sb.Append("</campo18>");

                sb.Append("<campo19>");
                sb.Append(campo19valor);
                sb.Append("</campo19>");

                sb.Append("<campo20>");
                sb.Append(campo20valor);
                sb.Append("</campo20>");

                sb.Append("<campo21>");
                sb.Append(campo21valor);
                sb.Append("</campo21>");

                sb.Append("<campo22>");
                sb.Append(campo22valor);
                sb.Append("</campo22>");

                sb.Append("<campo23>");
                sb.Append(campo23valor);
                sb.Append("</campo23>");

                sb.Append("<campo24>");
                sb.Append(campo24valor);
                sb.Append("</campo24>");

                sb.Append("<campo25>");
                sb.Append(campo25valor);
                sb.Append("</campo25>");

                sb.Append("<campo26>");
                sb.Append(campo26valor);
                sb.Append("</campo26>");

                sb.Append("<campo27>");
                sb.Append(campo27valor);
                sb.Append("</campo27>");
                
                sb.Append("<campo28>");
                sb.Append(campo28valor);
                sb.Append("</campo28></tbl>");

            }

            sb.Append("</DataSet>");

            return sb.ToString();
        }

        public static string ConvertiraXMLdinamico(IEnumerable<string> lista)
        {
            var sb = new StringBuilder();
            sb.Append("<DataSet>");

            // recorrer filas
            foreach (var fila in lista)
            {               
                //recorrer columnas                                        
                    string[] celdas = fila.Split('|');
                    sb.Append("<tbl>");
                    //recorrer columnas
                    string initagcampo  = "", endtagcampo = "";
                    for (int i = 0; i < celdas.Length; i++)
                    {
                        initagcampo  = "<campo"  + (i + 1).ToString() + ">";

                        endtagcampo = "</campo"  + (i + 1).ToString() + ">";
                        sb.Append(initagcampo);
                        sb.Append(celdas[i].ToString());
                        sb.Append(endtagcampo);
                        
                        
                    }
                    sb.Append("</tbl>");                
                
            }
            sb.Append("</DataSet>");
            return sb.ToString();
        }
        public static bool ValidarHora(string phora) {
            
            //int hora = Convert.ToInt32(phora);
            int hora = 0;
            if(!int.TryParse(phora, out hora)){
                return false;
            }
            if (hora > 23)
            {
                return false;
            }                        
            return true;
        }
        public static bool ValidarMinuto(string pminuto) {            
            //int minuto = Convert.ToInt32(pminuto);
            int minuto = 0;
            //int minuto 
            if (!int.TryParse(pminuto, out minuto))
            {
                return false;
            }
           
            if (minuto > 59)
            {
                return false;
            }            
            return true;
        }
        public static bool AbrirForm(string nombreForm)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == nombreForm);
            if (frm != null)
            {

                //frm.Show();
                frm.WindowState = FormWindowState.Normal;
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void enfocar(Control anterior, Control siguiente, KeyEventArgs evt, Form frm)
        {
            Control myCtrl = frm.GetNextControl(siguiente, false);
            if (!(myCtrl is RadGridView))
            {
                if (evt.KeyCode == Keys.Enter || evt.KeyCode == Keys.Down)
                {
                    frm.SelectNextControl(anterior, true, true, true, true);

                }
                else if (evt.KeyCode == Keys.Up)
                {
                    Control actual = frm.GetNextControl(siguiente, false);
                    frm.SelectNextControl(actual, false, true, true, true);
                }
            }
        }

        public static void enfocarFila(RadGridView gridControl, string columna, string valor)
        {
            try
            {
                var filtro = gridControl.Rows.Where(c => c.Cells[columna].Value.ToString() == valor);
                if (!filtro.Any())
                {
                    //MessageBox.Show("El elemento no se encuentra");
                    return;
                }

                var fila = filtro.Single();
                if (fila == null)
                {

                    return;
                }
                int indice = fila.Index;
                gridControl.ClearSelection();

                gridControl.MasterView.Rows[indice].IsCurrent = true;
                gridControl.MasterView.Rows[indice].IsSelected = true;
            }
            catch (Exception ex)
            {

            }

        }


        public static void enfocar(Control anterior, Control siguiente, KeyEventArgs evt,
                                    Form frm, RadCommandBar menuRad = null)
        {
            try
            {
                Control actual = frm.GetNextControl(siguiente, false);


                if (evt.KeyCode == Keys.Enter || evt.KeyCode == Keys.Down)
                {
                    //si encuentra un control con el tag = 0 entonces el siguien foco sera el menu de guardar
                    if (actual.Parent.Tag == "0")
                    {
                        if (menuRad != null)
                        {
                            var btnGuardar = menuRad.CommandBarElement.Rows[0].Strips[0].Items["cbbGuardar"];
                            btnGuardar.IsMouseOver = true;
                            btnGuardar.Focus();
                        }
                        return;
                    }


                    frm.SelectNextControl(anterior, true, true, true, true);
                }
                else if (evt.KeyCode == Keys.Up)
                {
                    frm.SelectNextControl(actual, false, true, true, true);
                }

            }
            catch (Exception ex)
            {
            }


        }

        public static void ResaltarAyuda(GridViewCellInfo fila)
        {

            fila.Style.BorderColor = Color.FromArgb(255, 204, 102);
            fila.Style.DrawBorder = true;
            fila.Style.BorderWidth = 2;
            fila.Style.BorderGradientStyle = GradientStyles.Solid;
            fila.Style.CustomizeBorder = true;

        }
        public static void ResaltarAyuda(RadGridView DataGrid, string name)
        {
            DataGrid.CurrentRow.Cells[name].Style.BorderColor = Color.FromArgb(255, 204, 102);
            DataGrid.CurrentRow.Cells[name].Style.DrawBorder = true;
            DataGrid.CurrentRow.Cells[name].Style.BorderWidth = 2;
            DataGrid.CurrentRow.Cells[name].Style.BorderGradientStyle = GradientStyles.Solid;
            DataGrid.CurrentRow.Cells[name].Style.CustomizeBorder = true;
        }
        public static void ResaltarAyuda(RadGridView DataGrid, int fila, string name)
        {
            DataGrid.Rows[fila].Cells[name].Style.BorderColor = Color.FromArgb(255, 104, 102);
            DataGrid.Rows[fila].Cells[name].Style.DrawBorder = true;
            DataGrid.Rows[fila].Cells[name].Style.BorderWidth = 2;
            DataGrid.Rows[fila].Cells[name].Style.BorderGradientStyle = GradientStyles.Solid;
            DataGrid.Rows[fila].Cells[name].Style.CustomizeBorder = true;
        }
        public static void ResaltarFila(RadGridView DataGrid, GridViewRowInfo fila)
        {
            GridRowElement RowElement = DataGrid.CurrentView.GetRowElement(fila);
            RowElement.BackColor = Color.FromArgb(239, 192, 192);
            RowElement.ForeColor = Color.Black;
            RowElement.GradientStyle = GradientStyles.Solid;
            RowElement.DrawFill = true;
        }
        public static void RestoreFila(RadGridView DataGrid, GridViewRowInfo fila)
        {
            GridRowElement RowElement = DataGrid.CurrentView.GetRowElement(fila);
            RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
        }
        public static void MostrarPopUp(RadPopupContainer contenedor, bool valor)
        {
            if (valor == true)
            {
                contenedor.BringToFront();
                contenedor.Visible = true;
            }
            else
            {
                contenedor.SendToBack();
                contenedor.Visible = false;
            }
        }

        public static void dimensionarPopUp(RadPopupContainer contenedor, int pwidth, int pheight)
        {
            contenedor.Width = pwidth;
            contenedor.Height = pheight;
        }
        public static void posicionarPopUp(RadPopupContainer contenedor, int px, int py)
        {
            contenedor.Location = new Point(px, py);
        }


        public static void MostrarPanel(RadPanel contenedor, bool valor)
        {
            if (valor == true)
            {
                contenedor.BringToFront();
                contenedor.Visible = true;
            }
            else
            {
                contenedor.SendToBack();
                contenedor.Visible = false;
            }
        }
        public static void dimensaiornPanel(RadPanel contenedor, int pwidth, int pheight)
        {
            contenedor.Width = pwidth;
            contenedor.Height = pheight;
        }

        public static void posicionarPanel(RadPanel contenedor, int px, int py)
        {
            contenedor.Location = new Point(px, py);
        }

        public static bool ShowMessage(string mensaje, int flag)
        {
            bool processOK = false;
            if (flag == 0 || flag == 1)
            {
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                processOK = true;
            }
            //else if (flag == -1)
            else
            {
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                processOK = false;
            }
            return processOK;
        }
        public static bool ShowAlert(string mensaje)
        {
            bool processOK = false;
            RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            return processOK;
        }
        public static bool ShowError(string mensaje)
        {
            bool processOK = false;
            RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            return processOK;
        }
        public static bool ShowQuestion(string mensaje)
        {
            bool processOK = false;
           

            if (RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                processOK = true;
            }
            else {
                processOK = false;
            }

            return processOK;
        }
        public static GridViewRowInfo GetCurrentRow(RadGridView DataGrid)
        {
            GridViewRowInfo row= null;
            if (DataGrid.RowCount > 0)
            {
                row = DataGrid.CurrentRow;
            }
            else {
                MessageBox.Show("Rows aren't founds");
                
            }
            return row;
        }
        public static GridViewCellInfo GetCurrentCell(RadGridView DataGrid, string cellname)
        {
            GridViewCellInfo cell = null;
            if (DataGrid.RowCount > 0)
            {
                cell = DataGrid.CurrentRow.Cells[cellname];
            }
            else {
                MessageBox.Show("Grid Empty");
            }
            return cell;
        }
        public static string GetTextValue(RadTextBox txt)
        {
            return txt.Text.Trim();
        }
        public static string GetCellText(GridViewRowInfo row, string name)
        {
            string valor = "";
            if (row == null)
            {
                MessageBox.Show("No existe fila");                
            }
            else {
                valor = Util.convertiracadena(row.Cells[name].Value);
            }

            return valor;
        }
        public static object GetCurrentCellValue(RadGridView DataGrid, string name)
        {
            object valor = null;
            if (DataGrid.Rows.Count > 0)
            { valor = DataGrid.CurrentRow.Cells[name].Value; }
            return valor;
        }
        public static int GetCurrentCellInt(RadGridView DataGrid, string name)
        {
            int numero = 0;
            if (DataGrid.Rows.Count > 0)
            { 
            numero = Util.convertiracadena(DataGrid.CurrentRow.Cells[name].Value) == "" ?
                         0 : Convert.ToInt32(DataGrid.CurrentRow.Cells[name].Value);
            }
            return numero;
        }
        public static int GetCurrentCellInt(GridViewRowInfo row, string name)
        {
            int numero = 0;
            if (row != null)
            {
                numero = Util.convertiracadena(row.Cells[name].Value) == "" ?
                             0 : Convert.ToInt32(row.Cells[name].Value);
            }
            
            return numero;
        }
        public static double GetCurrentCellDbl(RadGridView DataGrid, string name)
        {
            double numero = 0;
            if (DataGrid.Rows.Count > 0)
            {
                numero = Util.convertiracadena(DataGrid.CurrentRow.Cells[name].Value) == "" ?
                                0 : Convert.ToDouble(DataGrid.CurrentRow.Cells[name].Value);
            }
            else {
                Util.ShowError("No existe datos en la Grilla :" + DataGrid.Name);
            }            
            
            return numero;
        }
        public static double GetCurrentCellDbl(GridViewRowInfo row, string name)
        {
            double numero = 0;
            if (row != null)
            {
                numero = Util.convertiracadena(row.Cells[name].Value) == "" ?
                            0 : Convert.ToDouble(row.Cells[name].Value);
            }
            
            return numero;
        }
        public static string GetCurrentCellText(RadGridView DataGrid, string name)
        {
            string valor = "";
            try
            {
                if (DataGrid.Rows.Count > 0)
                {
                    valor = Util.convertiracadena(DataGrid.CurrentRow.Cells[name].Value);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return valor;
        }
        public static string GetCurrentCellText(GridViewRowInfo row, string name)
        {
            string texto = "";
            if (row != null)
            {
                texto = Util.convertiracadena(row.Cells[name].Value) == "" ?
                                "" : Util.convertiracadena(row.Cells[name].Value);
            }            
            return texto;
        }

        public static void SetValueCurrentCellInt(RadGridView DataGrid, string name, int value)
        {
            if (DataGrid.Rows.Count == 0)
            {
                Util.ShowError("La grilla "+DataGrid.Name+" no tiene fila ");
                return;
            }
            if (DataGrid.CurrentRow == null)
            {
                Util.ShowError("La fila actual no existe");
                return;
            }
            //if(DataGrid.CurrentRow.Cells[name]
            DataGrid.CurrentRow.Cells[name].Value = value;
        }
     
        
      
        public static void SetValueCurrentCellDbl(RadGridView DataGrid, string name, double value)
        {
            DataGrid.CurrentRow.Cells[name].Value = value;
        }

        public static void SetValueCurrentCellText(RadGridView DataGrid, string name, string value)
        {
            if (DataGrid.Rows.Count > 0)
            {
                DataGrid.CurrentRow.Cells[name].Value = value;
            }
            
        }
        
        public static void SetValueCurrentCellText(GridViewRowInfo row, string name, string value)
        {
            row.Cells[name].Value = value;
        }

        public static void SetClearCurrentCellText(GridViewRowInfo row, string name)
        {
            row.Cells[name].Value = null;    
        }

        public static void SetClearCurrentCellText(RadGridView DataGrid, string name)
        {
            DataGrid.CurrentRow.Cells[name].Value = null;
        }


        public static void SetClearCurrentCellInt(GridViewRowInfo row, string name)
        {
            row.Cells[name].Value = 0;
        }
        public static void SetClearCurrentCellInt(RadGridView DataGrid, string name)
        {
            DataGrid.CurrentRow.Cells[name].Value = 0;
        }


        public static void SetClearCurrentCellDbl(GridViewRowInfo row, string name)
        {
            row.Cells[name].Value = 0.0;
        }
        public static void SetClearCurrentCellDbl(RadGridView DataGrid, string name)
        {
            DataGrid.CurrentRow.Cells[name].Value = 0.0;
        }

        public static void IsReadOnlyCurrentCell(RadGridView DataGrid, string name, bool valor)
        {
            DataGrid.CurrentRow.Cells[name].ReadOnly = !valor;
        }
        //Valdacion de datos o valor de una celda
        public static void ValidateCellInt(RadGridView DataGrid, string name, int valluetocompare, string message, bool focuscell) 
        {
             
            //if (Util.convertiracadena(DataGrid.curr.Cells[name]) == "")
            //{
            //    RadMessageBox.Show(message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);

            //}    
        }
        public static bool ValidateCellInt(GridViewRowInfo currentrow, string name, int valuetocompare, string message, 
                                            bool focuscell= false)
        {
            bool processOK = true;            
            if (GetCurrentCellInt(currentrow, name) == valuetocompare)
            {                
                RadMessageBox.Show(message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                processOK = false;
            }
            return processOK;
        }
        public static bool ValidateCellText(RadGridView DataGrid, string name, string valuetocompare, string message,
                                            bool focuscell = false)
        {
            bool processOK = true;
            if (GetCurrentCellText(DataGrid, name) == valuetocompare)
            {
                DataGrid.CurrentRow = DataGrid.CurrentRow;
                DataGrid.CurrentColumn = DataGrid.Columns[name];
                RadMessageBox.Show(message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                processOK = false;
            }
            return processOK;
        }
        public static bool ValidateCellText(GridViewRowInfo currentrow, string name, string valuetocompare, string message, 
                                            bool focuscell = false)
        {
            bool processOK = true;
            if (GetCurrentCellText(currentrow, name) == valuetocompare)
            {
                RadMessageBox.Show(message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                processOK = false;
            }
            return processOK;
        }
        public static bool ValidateCellDbl(RadGridView DataGrid, string name, double valuetocompare, string message, 
                                            bool focuscell = false)
        {
            bool processOK = true;
            if (GetCurrentCellDbl(DataGrid, name) == valuetocompare)
            {
                RadMessageBox.Show(message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                processOK = false;
            }
            return processOK;
        }
        public static bool ValidateCellDbl(GridViewRowInfo currentrow, string name, double valuetocompare, string message, 
                                            bool focuscell = false)
        {
            bool processOK = true;
            if (GetCurrentCellDbl(currentrow, name) == valuetocompare)
            {
                RadMessageBox.Show(message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                processOK = false;
            }
            return processOK;
        }
        
        public static bool IsCurrentColumn(RadGridView DataGrid, string colname)
        {
            bool isCurrent = false;
            string currentColumn = DataGrid.CurrentColumn.Name;
            string userColumn = DataGrid.Columns[colname].Name;
            if (currentColumn == userColumn)
            {
                isCurrent = true;
            }
            return isCurrent;
        }
        public static bool IsCurrentColumn(GridViewColumn column, string name)
        {
            bool isCurrent = false;
            string currentColumn = column.Name;

            if (currentColumn == name)
            {
                isCurrent = true;
            }
            return isCurrent;
        }
        public static void SetCellGridFocus(RadGridView  DataGrid, string name)
        {
            
        }
        public static int GetAllVisibleColumns(RadGridView DataGrid)
        { 
            int columnsvisible = 0;
            foreach (GridViewColumn col in DataGrid.Columns)
            {
                if (col.IsVisible== true)
                { 
                    columnsvisible++;
                }
            }
            return columnsvisible;
        }
        public static void CatchFocusToGrid(RadGridView DataGrid, int columnsvisible = 0)
        {
            
        }
        public static void ConfigGridToEnterNavigation(RadGridView DataGrid)
        {
            DataGrid.BeginEditMode = RadGridViewBeginEditMode.BeginEditProgrammatically;
            DataGrid.EnterKeyMode = RadGridViewEnterKeyMode.None;
        }
        public static void SetCellInitEdit(RadGridView DataGrid, string name)
        {
            DataGrid.CurrentColumn = DataGrid.Columns[name];
            DataGrid.BeginEdit();
        }
        public static void SetCellInitEdit(RadGridView DataGrid, string name, int indexrow = 0, int countcolsvisible = 0)
        {
            if (DataGrid.RowCount > 0)
            { 
                DataGrid.CurrentColumn = DataGrid.Columns[name];
                DataGrid.CurrentRow = DataGrid.Rows[indexrow];
                DataGrid.BeginEdit();
            }
        }

        public static void AddGridSummarySum(RadGridView DataGrid, string[] FieldsName)
        {
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            GridViewSummaryItem[] listSummaryItem = new GridViewSummaryItem[FieldsName.Length];
            
            for (int x = 0; x < FieldsName.Length; x++)
            {
                summaryItem = new GridViewSummaryItem();
                summaryItem.Name = Util.convertiracadena(FieldsName[x]);
                summaryItem.FormatString = "{0:###,###0.00}";
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                listSummaryItem[x] = summaryItem;
                //listSummaryItem.Add(summaryItem);
            }
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem(listSummaryItem);
            DataGrid.SummaryRowsBottom.Add(summaryRowItem);
            DataGrid.MasterTemplate.ShowTotals = true;
            DataGrid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
        public static void AddGridSummaryCount(RadGridView DataGrid, string[] FieldsName)
        {
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            GridViewSummaryItem[] listSummaryItem = new GridViewSummaryItem[FieldsName.Length];

            for (int x = 0; x < FieldsName.Length; x++)
            {
                summaryItem = new GridViewSummaryItem();
                summaryItem.Name = Util.convertiracadena(FieldsName[x]);
                //summaryItem.FormatString = "{0:###,###0.00}";
                summaryItem.Aggregate = GridAggregateFunction.Count;
                listSummaryItem[x] = summaryItem;
                //listSummaryItem.Add(summaryItem);
            }
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem(listSummaryItem);
            DataGrid.SummaryRowsBottom.Add(summaryRowItem);
            DataGrid.MasterTemplate.ShowTotals = true;
            DataGrid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }

        public static ColumnCollection AddGroupDefinitionToGrid(ColumnGroupsViewDefinition GroupDefinition ,RadGridView DataGrid, 
                            string GroupTextHeader, string[] ColumnToGruop, int GroupIndexRow, int RowIndex)
        {
            //ColumnGroupsViewDefinition ColumnsGroupView = new ColumnGroupsViewDefinition();
            GroupDefinition.ColumnGroups.Add(new GridViewColumnGroup(GroupTextHeader));
            GridViewColumnGroup CurrentGroup = GroupDefinition.ColumnGroups[GroupIndexRow];
            GroupDefinition.ColumnGroups[GroupIndexRow].Rows.Add(new GridViewColumnGroupRow());
            
            foreach(string column in ColumnToGruop)
            {
                CurrentGroup.Rows[RowIndex].Columns.Add(DataGrid.Columns[column]);
            }
            return CurrentGroup.Rows[RowIndex].Columns;
            //ColumnsGroupView.ColumnGroups[GroupIndexRow].Rows[RowIndex].Columns.Add(DataGrid.Columns[
            //ColumnsGroupView.ColumnGroups[GroupIndexRow].Rows[RowIndex].Columns.Add(
        }
        //public static void AddColumnsToGroupDefinition(RadGridView DataGrid, string
    }
}