using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmRepFacturaAnticipo : frmBaseReporte
    {

        #region "Instancia"

        private static frmRepFacturaAnticipo _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepFacturaAnticipo Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepFacturaAnticipo(formParent);
            _aForm = new frmRepFacturaAnticipo(formParent);
            return _aForm;
        }
        #endregion

        public frmRepFacturaAnticipo(frmMDI padre)
        {
            InitializeComponent();
        }
        private void CrearColumnas()
        { 
            //CreateGridColumn(
        }
    }
}
