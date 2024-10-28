using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Cos.UI.Win
{
    public class Extensions
    {
        public void Bind(Telerik.WinControls.UI.RadDropDownList combo, System.Collections.IList lista)
        {
            combo.DataSource = lista;
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";
        }

        public void Bind(Telerik.WinControls.UI.RadMultiColumnComboBox combo, System.Collections.IList lista)
        {
            combo.DataSource = lista;
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";

        }

        public bool ExistsValueGridControl(RadGridView gridControl, string columnName, string value)
        {
            if (gridControl.RowCount == 0) return false;

            bool retorno = false;
            foreach (GridViewRowInfo item in gridControl.Rows)
            {
                if (item.Cells[columnName].Value == null)
                {
                    break;
                }

                if (item.Cells[columnName].Value.ToString().CompareTo(value.ToString()) == 0)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }


        //public void Bind(LookUpEdit lookUpEdit, System.Collections.IList lista)
        //{
        //    lookUpEdit.Properties.DataSource = lista;
        //    lookUpEdit.Properties.DisplayMember = "Text";
        //    lookUpEdit.Properties.ValueMember = "Value";
        //    lookUpEdit.Properties.ShowHeader = false;
        //}

        //public void Bind(CheckedListBoxControl checkedListBoxControl, System.Collections.IList lista)
        //{
        //    checkedListBoxControl.DataSource = lista;
        //    checkedListBoxControl.DisplayMember = "Text";
        //    checkedListBoxControl.ValueMember = "Value";
        //}

        //public void Bind(CheckedComboBoxEdit checkedComboBoxEdit, System.Collections.IList lista)
        //{
        //    checkedComboBoxEdit.Properties.DataSource = lista;
        //    checkedComboBoxEdit.Properties.DisplayMember = "Text";
        //    checkedComboBoxEdit.Properties.ValueMember = "Value";
        //}

        //public void Bind(RepositoryItemLookUpEdit lookUpEdit, System.Collections.IList lista)
        //{
        //    lookUpEdit.DataSource = lista;
        //    lookUpEdit.DisplayMember = "Text";
        //    lookUpEdit.ValueMember = "Value";
        //    lookUpEdit.ShowHeader = false;
        //}

        //public void Bind(LookUpEdit lookUpEdit, System.Collections.IList lista, string text, string value)
        //{
        //    lookUpEdit.Properties.DataSource = lista;
        //    //lookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;

        //    lookUpEdit.Properties.DisplayMember = text;
        //    lookUpEdit.Properties.ValueMember = value;
        //    lookUpEdit.Properties.ShowHeader = false;
        //}

        public string NullValue(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value == string.Empty)
            {
                return null;
            }

            return value.ToString();
        }

    }
}
