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
    public partial class frmseguridad : frmBaseMante
    {

        #region "Instancia"
        private static frmseguridad _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmseguridad Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmseguridad(formParent);
            _aForm = new frmseguridad(formParent);
            return _aForm;
        }
        #endregion

        public frmseguridad(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
    }
}
