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


namespace Cos.UI.Win
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
        public static string ConvertirXMLDinamico(IEnumerable<string> lista)
        {
            var sb = new StringBuilder();
            int i = 0 ;
            sb.Append("<DataSet>");
            
            foreach (var valores in lista)
            {
                sb.Append("<tbl>");
                string[] datos = valores.Split('|');
                for (int x = 1; x <= datos.Length; x++)
                {
                    sb.Append("<campo" + x.ToString() + ">");
                    sb.Append(datos[x - 1]);
                    sb.Append("</campo" + x.ToString() + ">"); 
                }
                sb.Append("</tbl>");
               
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
     

        public static void ResaltarAyuda(GridViewCellInfo fila)
        {
            
            fila.Style.BorderColor = Color.FromArgb(255, 204, 102);
            fila.Style.DrawBorder = true;
            fila.Style.BorderWidth = 2;
            fila.Style.BorderGradientStyle = GradientStyles.Solid;
            fila.Style.CustomizeBorder = true;                    
            
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

    }
}
