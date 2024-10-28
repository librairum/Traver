using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;

namespace Inv.UI.Win
{
    public partial class frmDetalleMovi : frmBaseReg
    {
   
        public frmDetalleMovi()
        {
            InitializeComponent();
        }
        private frmMDI FrmParent { get; set; }
      
        private static frmDetalleMovi _aForm;
        public static frmDetalleMovi Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return _aForm;
            _aForm = new frmDetalleMovi(mdiPrincipal);
            return _aForm;
        }

        public frmDetalleMovi(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
    }
}
