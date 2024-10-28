using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Com.UI.Win
{
    public partial class frmControles : Telerik.WinControls.UI.RadForm
    {
        public frmControles()
        {
            InitializeComponent();
        }

        private void frmControles_Load(object sender, EventArgs e)
        {
            this.txtValor.Enabled = true;
            this.txtValor.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtValor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            coleccion.Add("Test");
            coleccion.Add("Terminal");
            coleccion.Add("Tetera");
            coleccion.Add("Termostato");
            coleccion.Add("Tenebroso");
            this.txtValor.AutoCompleteCustomSource = coleccion;
            this.gpxFlotante.Visible = false;
            //this.gpxFlotante.Location.X = this.txtValor.Location.X;
            //this.gpxFlotante.Location.Y = this.txtValor.Location.Y + this.txtValor.Height;

            Point ubicacion = new Point();
            ubicacion.X = this.txtValor.Location.X;
            ubicacion.Y = this.txtValor.Location.Y + this.txtValor.Height;
            this.gpxFlotante.Location = ubicacion;
            //mascara de numero

            maskedTextBox1.TextMaskFormat = MaskFormat.IncludeLiterals;
            maskedTextBox1.Mask = "0000.00";
            radDateTimePicker2.NullableValue = null;
            
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            //txtvalor 33,119
            //panel de busqueda 33,188
            if (txtValor.Text.Trim() != "")
            {
                int posicionX = this.txtValor.Location.X;
                int posicionY = this.txtValor.Location.Y;
                System.Console.Write("Posicion X: " + posicionX + " Posicion Y:" + posicionY);
                this.gpxFlotante.Visible = true;
                if (txtValor.Text.Length == 10) {
                    this.gpxFlotante.Visible = false;
                }
            }
            else {
                this.gpxFlotante.Visible = false;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

            //if (maskedTextBox1.MaskFull)
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected - Too Much Data";
            //    toolTip1.Show("You cannot enter any more data into the date field. Delete some characters in order to insert more data.", maskedTextBox1, 0, -20, 5000);
            //}
            //else if (e.Position == maskedTextBox1.Mask.Length)
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected - End of Field";
            //    toolTip1.Show("You cannot add extra characters to the end of this date field.", maskedTextBox1, 0, -20, 5000);
            //}
            //else
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected";
            //    toolTip1.Show("You can only add numeric characters (0-9) into this date field.", maskedTextBox1, 0, -20, 5000);
            //}
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == (char)Keys.Enter)
            {
                //string textoFormateado = string.Format("{0:dd/MM/yyyy}", maskedTextBox1.Text);
                //System.Console.Write(textoFormateado);
                System.Console.WriteLine(maskedTextBox1.Text.Trim());
                
            }
            else {
                toolTip1.Hide(maskedTextBox1);
            }
        }


    }
}
