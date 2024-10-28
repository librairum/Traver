namespace Prod.UI.Win
{
    partial class frmGraficoBarra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            Telerik.Pivot.Core.PropertyAggregateDescription propertyAggregateDescription1 = new Telerik.Pivot.Core.PropertyAggregateDescription();
            Telerik.Pivot.Core.SumAggregateFunction sumAggregateFunction1 = new Telerik.Pivot.Core.SumAggregateFunction();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription1 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer1 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription2 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer2 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription3 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer3 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription4 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer4 = new Telerik.Pivot.Core.GroupNameComparer();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
            this.premium_DeisiProd0707DataSet = new Prod.UI.Win.Premium_DeisiProd0707DataSet();
            this.in07moviBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.in07moviTableAdapter = new Prod.UI.Win.Premium_DeisiProd0707DataSetTableAdapters.in07moviTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.premium_DeisiProd0707DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.in07moviBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            this.radChartView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radChartView1.Location = new System.Drawing.Point(0, 0);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(811, 283);
            this.radChartView1.TabIndex = 0;
            this.radChartView1.Text = "radChartView1";
            // 
            // radPivotGrid1
            // 
            propertyAggregateDescription1.AggregateFunction = sumAggregateFunction1;
            propertyAggregateDescription1.CustomName = null;
            propertyAggregateDescription1.PropertyName = "IN07CANART";
            propertyAggregateDescription1.StringFormat = null;
            propertyAggregateDescription1.StringFormatSelector = null;
            propertyAggregateDescription1.TotalFormat = null;
            this.radPivotGrid1.AggregateDescriptions.Add(propertyAggregateDescription1);
            propertyGroupDescription1.CustomName = null;
            propertyGroupDescription1.GroupComparer = groupNameComparer1;
            propertyGroupDescription1.GroupFilter = null;
            propertyGroupDescription1.PropertyName = "IN07CODALM";
            propertyGroupDescription1.ShowGroupsWithNoData = false;
            propertyGroupDescription1.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            propertyGroupDescription2.CustomName = null;
            propertyGroupDescription2.GroupComparer = groupNameComparer2;
            propertyGroupDescription2.GroupFilter = null;
            propertyGroupDescription2.PropertyName = "IN07TIPDOC";
            propertyGroupDescription2.ShowGroupsWithNoData = false;
            propertyGroupDescription2.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            this.radPivotGrid1.ColumnGroupDescriptions.Add(propertyGroupDescription1);
            this.radPivotGrid1.ColumnGroupDescriptions.Add(propertyGroupDescription2);
            this.radPivotGrid1.DataSource = this.in07moviBindingSource;
            this.radPivotGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPivotGrid1.Location = new System.Drawing.Point(0, 283);
            this.radPivotGrid1.Name = "radPivotGrid1";
            propertyGroupDescription3.CustomName = null;
            propertyGroupDescription3.GroupComparer = groupNameComparer3;
            propertyGroupDescription3.GroupFilter = null;
            propertyGroupDescription3.PropertyName = "IN07AA";
            propertyGroupDescription3.ShowGroupsWithNoData = false;
            propertyGroupDescription3.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            propertyGroupDescription4.CustomName = null;
            propertyGroupDescription4.GroupComparer = groupNameComparer4;
            propertyGroupDescription4.GroupFilter = null;
            propertyGroupDescription4.PropertyName = "IN07MM";
            propertyGroupDescription4.ShowGroupsWithNoData = false;
            propertyGroupDescription4.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            this.radPivotGrid1.RowGroupDescriptions.Add(propertyGroupDescription3);
            this.radPivotGrid1.RowGroupDescriptions.Add(propertyGroupDescription4);
            this.radPivotGrid1.Size = new System.Drawing.Size(811, 112);
            this.radPivotGrid1.TabIndex = 1;
            this.radPivotGrid1.Text = "radPivotGrid1";
            // 
            // premium_DeisiProd0707DataSet
            // 
            this.premium_DeisiProd0707DataSet.DataSetName = "Premium_DeisiProd0707DataSet";
            this.premium_DeisiProd0707DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // in07moviBindingSource
            // 
            this.in07moviBindingSource.DataMember = "in07movi";
            this.in07moviBindingSource.DataSource = this.premium_DeisiProd0707DataSet;
            // 
            // in07moviTableAdapter
            // 
            this.in07moviTableAdapter.ClearBeforeFill = true;
            // 
            // frmGraficoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 395);
            this.Controls.Add(this.radPivotGrid1);
            this.Controls.Add(this.radChartView1);
            this.Name = "frmGraficoBarra";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmGraficoBarra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGraficoBarra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.premium_DeisiProd0707DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.in07moviBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadChartView radChartView1;
        private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
        private Premium_DeisiProd0707DataSet premium_DeisiProd0707DataSet;
        private System.Windows.Forms.BindingSource in07moviBindingSource;
        private Premium_DeisiProd0707DataSetTableAdapters.in07moviTableAdapter in07moviTableAdapter;
    }
}
