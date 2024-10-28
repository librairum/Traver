using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inv.UI.Win.Procesos
{
    public partial class FrmPrueba : frmBaseMante
    {
        //public FrmPrueba()
        //{
        //    InitializeComponent();
        //}

        private frmMDI FrmParent { get; set; }
        private static FrmPrueba _aForm;

        public static FrmPrueba Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmPrueba(mdiPrincipal);
            _aForm = new FrmPrueba(mdiPrincipal);
            return _aForm;
        }
        public FrmPrueba(frmMDI padre)
        {
            InitializeComponent();
        }

    }
}
