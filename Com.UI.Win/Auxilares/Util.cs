using System;
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

using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using Com.UI.Win.Auxilares;
using System.Globalization;


namespace Com.UI.Win
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
        public static double ConvertiraDecimal(string valor)
        {
            double valornumero = 0;
            if (valor != "")
            {
                bool valido = double.TryParse(valor, out valornumero);
                if (valido == false)
                {
                    Util.ShowAlert("El valor ingresado no se puede convertir a numero");
                }

            }
            return valornumero;
        }
        public static DateTime ConvertiraFecha(string valor)
        {
            DateTime fecha = new DateTime();

            if (valor != "")
            {
                bool valido = DateTime.TryParse(valor, out fecha);
                if (valido == false)
                {
                    Util.ShowAlert("El valor ingresa no puede convertirse a fecha");
                }

            }


            return fecha;
        }
        public static void SendTab(int key)
        {
            //if (key == Keys.Enter.GetHashCode()) SendKeys.Send("{TAB}");
            if (key == Keys.Down.GetHashCode()) SendKeys.Send("{TAB}");
            if (key == Keys.Up.GetHashCode()) SendKeys.Send("+{TAB}");
        }

        static void enfocarRegistro(object xsender)
        {
            if ( ((Control)xsender) is RadTextBox ) {
                ((RadTextBox)xsender).SelectionStart = 0;
                ((RadTextBox)xsender).SelectionLength = ((RadTextBox)xsender).Text.Length;    
            }                       
        }
       public static void enfocarFila(RadGridView gridControl,string columna, string valor)
        {
            try
            {
                var filtro = gridControl.Rows.Where(c => c.Cells[columna].Value.ToString() == valor);
                if (!filtro.Any())
                {
                    MessageBox.Show("El elemento no se encuentra");
                    return;
                }

                var fila = filtro.Single();
                if (fila == null)
                {

                    return;
                }
                int indice = fila.Index;
                gridControl.MasterView.Rows[indice].IsCurrent = true;
                gridControl.MasterView.Rows[indice].IsSelected = true;

                //Fijar el scroll en la fila resaltado
                GridTableElement tableElement = gridControl.CurrentView as GridTableElement;
                GridViewRowInfo row = gridControl.CurrentRow;

                if (tableElement != null && row != null)
                {
                    tableElement.ScrollToRow(row);
                }


            }
            catch (Exception ex) { 
            
            }
            
        }
        public static void SendEnter(KeyEventArgs evt, object obj,Form frm = null)
        {

            
            if (evt.KeyCode == Keys.Enter)
            {
                evt.Handled = true;
                
                SendKeys.Send("{TAB}");
                
                //frm.SelectNextControl(((Control)obj), true, true, true, true);
                
               
                enfocarRegistro(obj);
                //MessageBox.Show(((Control)obj).Name);
            }
            else if (evt.KeyCode == Keys.Up) {
                evt.Handled = true;
                SendKeys.Send("+{TAB}");
                enfocarRegistro(obj);       
            }
            else if (evt.KeyCode == Keys.Down) {
                evt.Handled = true;
                
                SendKeys.Send("{TAB}");
                enfocarRegistro(obj);     
            }
            //else if (evt.KeyCode == Keys.Up || evt.KeyCode == Keys.Left)
            //{
            //    SendKeys.Send("+{TAB}");
            //    enfocarRegistro(obj);                                                                                                                  
            //}
            //else if (evt.KeyCode == Keys.Down || evt.KeyCode == Keys.Right)
            //{
            //    SendKeys.Send("{TAB}");
            //    enfocarRegistro(obj);
            //}
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
                string initagcampo = "", endtagcampo = "";
                for (int i = 0; i < celdas.Length; i++)
                {
                    initagcampo = "<campo" + (i + 1).ToString() + ">";

                    endtagcampo = "</campo" + (i + 1).ToString() + ">";
                    sb.Append(initagcampo);

                    celdas[i] = celdas[i].Replace("&", "&amp;");
                    sb.Append(celdas[i].ToString());
                    sb.Append(endtagcampo);


                }
                sb.Append("</tbl>");

            }
            sb.Append("</DataSet>");
            return sb.ToString();
        }
        public static string ConvertiraXML(IEnumerable<string> lista)
        {
            var sb = new StringBuilder();

            sb.Append("<DataSet>");

            foreach (var codigo in lista)
            {
                sb.Append("<tbl><Codigo>");
                sb.Append(codigo);
                sb.Append("</Codigo></tbl> ");
            }

            sb.Append("</DataSet>");

            return sb.ToString();
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
    public static void enfocar(Control anterior, Control siguiente, KeyEventArgs evt,
        Form frm,
        RadCommandBar menuRad = null)
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
        catch (Exception ex) { 
        }
       
                       
    }
   static void activaBoton(RadCommandBarBaseItem boton, bool valor)
    {
        
        boton.IsMouseDown = valor;
        boton.IsMouseOver = valor;
        boton.Focus();
        if (valor)
        {
            boton.BackColor = Color.LightSkyBlue;
        }
        else
        {
            boton.BackColor = Color.White;
        }
    }
    public static void Mantenimiento(CommandBarStripElement miMenu) { 
    //commandBarStripElement1.Items[0].
        
    }
    public static string NumerNoNegativo(string numero)
    { 
        bool esnumerico = Information.IsNumeric(numero);
        if (esnumerico) {
            if (Convert.ToDouble(numero) < 0)
            {
                return "Numero debe ser positivo";
            }
            else { 
                return "";
            }
        }else{
            return "Numero no valido.";
        }        
    }
    public static bool EsNumero(string numero)
    {
        bool esnumerico = Information.IsNumeric(numero);
        if (esnumerico)
        {
            return true;
        }
        else
            {
                return false;
            }
    }

    public static string NumberFormat(string valor, string formato = "{0:#,##0.00}")
    {
        string Formateado = "";
        try
        {
            double numero = Convert.ToDouble(valor);
            Formateado = string.Format(formato, numero);
            
        }
        catch (Exception ex) {
            Util.ShowAlert("Error al formatear numero");
        }
        return Formateado;
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
        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
        return processOK;
    }
    public static bool ShowQuestion(string mensaje)
    {
        bool processOK = false;


        RadMessageLocalizationProvider.CurrentProvider = new CulturaVentanaMensaje();
        
        if (RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
        {
            processOK = true;
        }
        else
        {
            processOK = false;
        }

        return processOK;
    }

    public static RespuestaMensaje ShowQuestionWithCancel(string mensaje)
    {

        RadMessageLocalizationProvider.CurrentProvider = new CulturaVentanaMensaje();

        RespuestaMensaje respuesta = RespuestaMensaje.Cancelar;

        if(RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.YesNoCancel, 
                              RadMessageIcon.Question) == DialogResult.Yes)
        {
            respuesta = RespuestaMensaje.Si;
        }else if(RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.YesNoCancel, 
                              RadMessageIcon.Question) == DialogResult.No)  {
            respuesta = RespuestaMensaje.No;
                              }
        else if (RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.YesNoCancel,
                             RadMessageIcon.Question) == DialogResult.Cancel)
        {
            respuesta = RespuestaMensaje.Cancelar;
        }

        return respuesta;

    }

    public static GridViewRowInfo GetCurrentRow(RadGridView DataGrid)
    {
        GridViewRowInfo row = null;
        if (DataGrid.RowCount > 0)
        {
            row = DataGrid.CurrentRow;
        }
        else
        {
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
        else
        {
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
        else
        {
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
        else
        {
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
    //metodo para traer numero formateado para asignar a control de caja texto
    public static string GetCurrentCellTextNumero(GridViewRowInfo row, string name) {
        string texto = "";
        if (row != null)
        {
            texto = Util.convertiracadena(row.Cells[name].Value) == "" ?
                            "" : Util.convertiracadena(row.Cells[name].Value);
            texto = texto == "" ? "0.00" : GetCurrentCellDbl(row, name).ToString("0.00");
        }
        return texto;
    }
    //metodo para mostrar el numero con 2 decimales con parametro tipo double
    public static string AsignarNumeroFormateado(double valor) {
        string numeroFormateado = "";
        if (valor == 0)
        {
            numeroFormateado = "0.00";
        }
        else {
           numeroFormateado =  valor.ToString("0.00");
        }
        return numeroFormateado;
    }
    public static string AsignarNumeroFormateado4dec(double valor)
    {
        string numeroFormateado = "";
        if (valor == 0)
        {
            numeroFormateado = "0.0000";
        }
        else
        {
            numeroFormateado = valor.ToString("0.0000");
        }
        return numeroFormateado;
    }
        //metodo para mostrar el numero con 2 decimales con parametro tipo decimal
    public static string AsignarNumeroFormateado(decimal valor)
    {
        string numeroFormateado = "";
        if (valor == 0)
        {
            numeroFormateado = "0.00";
        }
        else
        {
            numeroFormateado = valor.ToString("0.00");
        }
        return numeroFormateado;
    }
    public static string AsignarNumeroFormateado4dec(decimal valor)
    {
        string numeroFormateado = "";
        if (valor == 0)
        {
            numeroFormateado = "0.0000";
        }
        else
        {
            numeroFormateado = valor.ToString("0.0000");
        }
        return numeroFormateado;
    }
        public static bool ItsEditingRow(GridViewRowInfo parRow, string parColumnName = "flag")
    {
        bool bool_IsEdiing = false;
        string str_flag = Util.GetCurrentCellText(parRow, parColumnName);
        if (str_flag == "0" || str_flag == "1")
        {
            bool_IsEdiing = true;
        }
        else if (str_flag == "")
        {
            bool_IsEdiing = false;
        }
        return bool_IsEdiing;
    }
    public static bool GetCurrentCellFlag(GridViewRowInfo parRow, string parName  = "flag")
    {
        bool bool_EsNuevo = false;

        string str_flag = Util.GetCurrentCellText(parRow, parName);
        //Nuevo
        if (str_flag == "0")
        {
            bool_EsNuevo = true;
        } //Editar
        else if (str_flag == "1")
        {
            bool_EsNuevo = false;
        }
        return bool_EsNuevo;
    }
    public static bool GetCurrentCellChkValue(GridViewRowInfo parRow, string parName)
    {
        bool bool_Seleccionado = false;

        string str_Chk =  Util.GetCurrentCellText(parRow, parName);

        if (str_Chk == "")
            bool_Seleccionado = false;        
        else if (str_Chk != "")
            if(str_Chk == "0")
                bool_Seleccionado = false;
            else if (str_Chk.ToUpper()== "TRUE" || str_Chk.ToUpper() == "ON" || str_Chk == "1")
                bool_Seleccionado = true;


        return bool_Seleccionado;
        
    }
    public static void SetValueCurrentCellInt(RadGridView DataGrid, string name, int value)
    {
        if (DataGrid.Rows.Count == 0)
        {
            Util.ShowError("La grilla " + DataGrid.Name + " no tiene fila ");
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
    public static void SetValueCurrentCellInt(GridViewRowInfo row, string name, int value)
    {
        row.Cells[name].Value = value;
    }
    

    public static void SetValueCurrentCellDbl(RadGridView DataGrid, string name, double value)
    {
        DataGrid.CurrentRow.Cells[name].Value = value;
    }
    public static void SetValueCurrentCellDbl(GridViewRowInfo row, string name, double value)
    {
        row.Cells[name].Value = value;
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
    public static bool ValidateCellInt(GridViewRowInfo currentrow, string name, int valuetocompare, string message,
                                            bool focuscell = false)
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
    
    public static void SetCellGridFocus(RadGridView parDataGrid, string parColumnName)
    {
        parDataGrid.Focus();
        parDataGrid.CurrentRow.Cells[parColumnName].IsSelected = true;
    }
    public static void SetCellGridFocus(GridViewRowInfo parRow, string parColumnName)
    {
        parRow.Cells[parColumnName].IsSelected = true;
    }
    public static int GetAllVisibleColumns(RadGridView DataGrid)
    {
        int columnsvisible = 0;
        foreach (GridViewColumn col in DataGrid.Columns)
        {
            if (col.IsVisible == true)
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
        DataGrid.NewRowEnterKeyMode = RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
        //DataGrid.BeginEditMode = RadGridViewBeginEditMode.BeginEditProgrammatically;
        DataGrid.BeginEditMode = RadGridViewBeginEditMode.BeginEditOnKeystrokeOrF2;
        DataGrid.EnterKeyMode = RadGridViewEnterKeyMode.None;
        DataGrid.KeyUp += new KeyEventHandler(Grid_KeyUp);
        DataGrid.CurrentCellChanged += new CurrentCellChangedEventHandler(Grid_CurrentCellChanged);
    }
    
    static void Grid_KeyUp(object sender, KeyEventArgs e)
    {        
        try
        {
            if (e.KeyValue == (char)Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        catch (Exception ex)
        {
            Util.ShowError("Error Key Up :" + ex.Message);
        }
    }

    static void Grid_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
    {        
        try
        {
            RadGridView Grid = (RadGridView)sender;
            string columnName = Grid.CurrentColumn.Name;
            Util.SetCellInitEdit(Grid, columnName);
        }
        catch (Exception ex)
        {
            //Util.ShowError("Error Grid Current Cell Changed: " + ex.Message);
        }
    }

    public static void SetCellInitEdit(GridViewRowInfo parRow, string parName)
    {
        //parRow.Parent.
        parRow.Cells[parName].BeginEdit();
    }
    static void SetCellInitEdit(GridViewCellInfo DataGridCell, string name)
    {
        DataGridCell.BeginEdit();
    }
    public static void SetCellInitEdit(RadGridView DataGrid, string name)
    {
        DataGrid.Focus();
        DataGrid.CurrentColumn = DataGrid.Columns[name];
        DataGrid.BeginEdit();
    }
    public static void SetCellInitEdit(RadGridView DataGrid, string name, int indexrow = 0, int countcolsvisible = 0)
    {
        DataGrid.Focus();
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
            
            summaryItem.Aggregate = GridAggregateFunction.Count;
            listSummaryItem[x] = summaryItem;
            
        }
        GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem(listSummaryItem);
        DataGrid.SummaryRowsBottom.Add(summaryRowItem);
        DataGrid.MasterTemplate.ShowTotals = true;
        DataGrid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
    }

    public static ColumnCollection AddGroupDefinitionToGrid(ColumnGroupsViewDefinition GroupDefinition, RadGridView DataGrid,
                        string GroupTextHeader, string[] ColumnToGruop, int GroupIndexRow, int RowIndex)
    {
        
        GroupDefinition.ColumnGroups.Add(new GridViewColumnGroup(GroupTextHeader));
        GridViewColumnGroup CurrentGroup = GroupDefinition.ColumnGroups[GroupIndexRow];
        GroupDefinition.ColumnGroups[GroupIndexRow].Rows.Add(new GridViewColumnGroupRow());

        foreach (string column in ColumnToGruop)
        {
            CurrentGroup.Rows[RowIndex].Columns.Add(DataGrid.Columns[column]);
        }
        return CurrentGroup.Rows[RowIndex].Columns;
        
    }
    public static string convertiracadena(object valor)
    {
        string cadena = "";
        if (valor == null)
        {
            cadena = "";
        }
        else
        {
            cadena = valor.ToString();
        }


        return cadena;
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

    public static void ResetearAyuda(RadGridView DataGrid,  int index, string name)
    {

        DataGrid.Rows[index].Cells[name].Style.BorderColor = Color.FromArgb(221, 231, 242);
        DataGrid.Rows[index].Cells[name].Style.DrawBorder = true;
        DataGrid.Rows[index].Cells[name].Style.BorderWidth = 2;
        DataGrid.Rows[index].Cells[name].Style.BorderGradientStyle = GradientStyles.Solid;
        DataGrid.Rows[index].Cells[name].Style.CustomizeBorder = true;
        
    }

    public static void ResaltarAyuda(RadGridView DataGrid, int fila, string name)
    {
        DataGrid.Rows[fila].Cells[name].Style.BorderColor = Color.FromArgb(255, 204, 102);
        DataGrid.Rows[fila].Cells[name].Style.DrawBorder = true;
        DataGrid.Rows[fila].Cells[name].Style.BorderWidth = 2;
        DataGrid.Rows[fila].Cells[name].Style.BorderGradientStyle = GradientStyles.Solid;
        DataGrid.Rows[fila].Cells[name].Style.CustomizeBorder = true;
    }

    public static void seleccionatFilaCompleta(RadGridView Grid)
    {
        Grid.SelectionMode = GridViewSelectionMode.FullRowSelect;
    }

    public static void AddCmdButtonToGrid(RadGridView Grid, string NameButton, 
        string TextButton, string ColumnGrid)
    {
        GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
        cmdbtn.Name = NameButton;
        cmdbtn.HeaderText = TextButton;
        Grid.Columns.Add(cmdbtn);
        Grid.Columns[NameButton].Width = 30;

    }

    public static void AddButtonsToGrid(RadGridView Grid)
    {
        AddCmdButtonToGrid(Grid, "btnGrabarDet", "", "btnGrabarDet");
        AddCmdButtonToGrid(Grid, "btnCancelarDet", "", "btnCancelarDet");
        AddCmdButtonToGrid(Grid, "btnEliminarDet", "", "btnEliminarDet");
        AddCmdButtonToGrid(Grid, "btnEditarDet", "", "btnEditarDet");
    }
    public static void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
    bool bCancelar, bool bEliminar, bool bEditar, bool bVerDetalle = false, bool bRegularizar = false)
    {
        GridCommandCellElement cellElement = CommandCell;
        switch (nombre)
        {
            case "btnGrabarDet":
                cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = bGrabar;
                break;

            case "btnCancelarDet":
                cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = bCancelar;
                break;

            case "btnEliminarDet":
                cellElement.CommandButton.Image = bEliminar ? Properties.Resources.delete_enabled : Properties.Resources.delete_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = bEliminar;
                break;

            case "btnEditarDet":
                cellElement.CommandButton.Image = bEditar ? Properties.Resources.edit_enabled : Properties.Resources.edited_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = bEditar;
                break;
            case "btnVerDet":
                cellElement.CommandButton.Image = bEditar ? Properties.Resources.verdetalle_enabled : Properties.Resources.verdetalle_enabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = bVerDetalle;
                break;
            case "btnRegularizar":
                cellElement.CommandButton.Image = bEditar ? Properties.Resources.regularizar_enabled : Properties.Resources.regularizar_enabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = true;
                break;
            default:
                break;
        }
    }
    public static void deshabilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell)
    {
        GridCommandCellElement cellElement = CommandCell;
        switch (nombre)
        {
            case "btnGrabarDet":

                cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = false;
                break;
            case "btnCancelarDet":
                cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;

                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = false;
                break;
            case "btnEliminarDet":
                cellElement.CommandButton.Image = Properties.Resources.delete_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = false;
                break;
            case "btnEditarDet":
                cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                cellElement.CommandButton.Enabled = false;
                break;
            default:
                break;
        }
    }
    public static int HasRowToSave(RadGridView Grid)
    {
        int rowsaffected = 0;

        foreach (GridViewRowInfo row in Grid.Rows)
        {
            if (Util.GetCurrentCellText(row, "flagBotones") == "E")
                rowsaffected++;
        }
        return rowsaffected;
    }

        
    public static void FormateoBotones(RadGridView Grid,
        FormEstate EstadoFormulario,
        CellFormattingEventArgs EventoCelda)
    {
        GridCommandCellElement cellElement = EventoCelda.CellElement as GridCommandCellElement;
        if (cellElement == null) return;
        if (EventoCelda.CellElement.ColumnInfo is GridViewCommandColumn)
        {
            RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)cellElement).Children[0]);
            if (EstadoFormulario == FormEstate.View) 
            {
                deshabilitarBotonProdDet(EventoCelda.Column.Name, cellElement);
                return;
            }
            if (Grid.Rows[EventoCelda.RowIndex].Cells["flag"].Value == null)
            {
                habilitarBotonProdDet(EventoCelda.Column.Name, cellElement, false, false, true, true, true);
            }
            else {
                habilitarBotonProdDet(EventoCelda.Column.Name, cellElement, true, true, false, false,false);
            }

        }
    }

    public static  void FocusNextControl(KeyEventArgs paramEvent)
    {
        if (paramEvent.KeyValue == (char)Keys.Enter || paramEvent.KeyValue == (char)Keys.Down)
            SendKeys.Send("{TAB}");
        else if (paramEvent.KeyValue == (char)Keys.Up)
            SendKeys.Send("+{TAB}");
    }


    public static void CeldaEditado(RadGridView DataGrid, string name)
    {
        DataGrid.CurrentRow.Cells[name].Style.BorderColor = Color.FromArgb(255, 34, 34);
        DataGrid.CurrentRow.Cells[name].Style.ForeColor = Color.White;
        DataGrid.CurrentRow.Cells[name].Style.DrawBorder = true;
        DataGrid.CurrentRow.Cells[name].Style.BorderWidth = 2;
        DataGrid.CurrentRow.Cells[name].Style.BorderGradientStyle = GradientStyles.Solid;
        DataGrid.CurrentRow.Cells[name].Style.CustomizeBorder = true;
    }
    public static void CeldaEditado(GridViewCellInfo celda)
    {
        celda.Style.BorderColor = Color.FromArgb(255, 34, 34);
        celda.Style.ForeColor = Color.White;
        celda.Style.DrawBorder = true;
        celda.Style.BorderWidth = 2;
        celda.Style.BorderGradientStyle = GradientStyles.Solid;
        celda.Style.CustomizeBorder = true;
        celda.Style.DrawFill = true;
        celda.Style.BackColor = Color.FromArgb(255, 34, 34);

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


    public static string Right(string cadena, int length)
    {
        if (String.IsNullOrEmpty(cadena)) return string.Empty;

        return cadena.Length <= length ? cadena : cadena.Substring(cadena.Length - length);
    }

    public static void  OnEnfocarRegistro(RadGridView gv, string codigoRegistro, string nomcol)
    {
        if (!gv.IsLoaded) { return; }

            foreach (GridViewRowInfo row in gv.Rows)
            {
                if (row.Cells[nomcol].Value.ToString() == codigoRegistro)
                {
                    //gv.Rows[row.Index].IsCurrent = true;
                    gv.Rows[row.Index].IsSelected = true;
                }
            }        
    }

    public static void ResaltarAyuda(RadTextBox text)
    {
        text.TextBoxElement.TextBoxItem.BackColor = Color.FromArgb(255, 225, 137);

        text.TextBoxElement.Fill.BackColor = Color.FromArgb(255, 225, 137);

    }
    public static void ResetearAyuda(RadTextBox text)
    {
        text.TextBoxElement.TextBoxItem.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
        text.TextBoxElement.Fill.BackColor = Color.FromArgb(221, 231, 242);
    }
    
    public static void  ExportarEnFormatoPDF(ReportDocument rpt, string nombreArchivoPDF)
    {
        string rutaArchivo = "";
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

        try
        {
            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar documento pdf";
            saveFileDialog1.Filter = "Pdf Files|*.pdf";
            saveFileDialog1.FileName = nombreArchivoPDF;
            saveFileDialog1.ShowDialog();
            rutaArchivo = saveFileDialog1.FileName;
            
            if (File.Exists(rutaArchivo))
                File.Delete(rutaArchivo);
            diskOpts.DiskFileName = rutaArchivo;
            rpt.ExportOptions.DestinationOptions = diskOpts;
            rpt.Export();

                //Luego de exportar abrir el archivo pdf.
                System.Diagnostics.Process.Start(rutaArchivo);
            
        }
        catch (Exception ex)
        {
            Util.ShowError("Error al exportar a pdf: " + ex.Message);
        }

        
    }

    public static bool ValidarHora(string phora)
    {

        //int hora = Convert.ToInt32(phora);
        int hora = 0;
        if (!int.TryParse(phora, out hora))
        {
            return false;
        }
        if (hora > 23)
        {
            return false;
        }
        return true;
    }

    public static bool ValidarMinuto(string pminuto)
    {
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

    public static void AddButtonsToGrid(RadGridView Grid, BaseRegBotonesDetalle boton)
    {
        switch (boton)
        {
            case BaseRegBotonesDetalle.btnGuardarDet:
                AddCmdButtonToGrid(Grid, "btnGrabarDet", "", "btnGrabarDet");
                break;

            case BaseRegBotonesDetalle.btnCancelarDet:
                AddCmdButtonToGrid(Grid, "btnCancelarDet", "", "btnCancelarDet");
                break;

            case BaseRegBotonesDetalle.btnEliminarDet:
                AddCmdButtonToGrid(Grid, "btnEliminarDet", "", "btnEliminarDet");
                break;

            case BaseRegBotonesDetalle.btnEditarDet:
                AddCmdButtonToGrid(Grid, "btnEditarDet", "", "btnEditarDet");
                break;
            case BaseRegBotonesDetalle.btnVerDet:
                AddCmdButtonToGrid(Grid, "btnVerDet", "", "btnVerDet");
                break;
            case BaseRegBotonesDetalle.btnRegularizar:
                AddCmdButtonToGrid(Grid, "btnRegularizar", "", "btnRegularizar");
                break;
            default:
                break;
        }
    }

    public static void ExportarEnCorreo(ReportDocument rpt, string nombreArchivoPDF)
    {
        string rutaArchivo = "";
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
        try
        {
            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = nombreArchivoPDF + ".pdf";
            rutaArchivo = saveFileDialog1.FileName;
            if (File.Exists(rutaArchivo))
                File.Delete(rutaArchivo);
            diskOpts.DiskFileName = rutaArchivo;
            rpt.ExportOptions.DestinationOptions = diskOpts;
            rpt.Export();
        }
        catch (Exception ex)
        {
            Util.ShowError("Error al exportar en formato pdf : " + ex.Message);
        }
    }

    public static double Redondear(double numero, int cantidadDecimales)
    {
        string valorNumero = "";
        valorNumero = numero.ToString();

        decimal numeroRedondeado = 0;

        numeroRedondeado = decimal.Round(Convert.ToDecimal(valorNumero), cantidadDecimales);

        return double.Parse(numeroRedondeado.ToString());
    }

    public static void ResaltaAyudaPorEstado(RadTextBox texto)
    {
        if (texto.Enabled)
        {
            Util.ResaltarAyuda(texto);
        }
        else
        {
            Util.ResetearAyuda(texto);
        }
    }


    public static Boolean ValidaFormatoDecimal(KeyPressEventArgs evento)
    {
        bool validaDato = false;
        
        try
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(evento.KeyChar) ||
                evento.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator
                || evento.KeyChar == (char)Keys.Back)
            {
                //evento.Handled = false;
                validaDato = false;
            }
            else
            {

                validaDato = true;
            }
        }
        catch (Exception ex) {
            Util.ShowAlert("Error en validar formato decimal");
        }
        return validaDato;
    }
    
    }
}
