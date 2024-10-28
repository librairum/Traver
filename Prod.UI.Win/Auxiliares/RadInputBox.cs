using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Prod.UI.Win
{
    public class RadInputBox
    {

        public static string Show(string Prompt, string Title, string DefaultResponse = "")
        {
            RadInputBoxInternal inputBox = new RadInputBoxInternal();

            inputBox.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            inputBox.LabelQuestion.Text = Prompt;
            inputBox.Text = Title;

            if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return inputBox.TextBoxInput.Text;
            }
            else
            {
                return DefaultResponse;
            }
        }

        private class RadInputBoxInternal : Telerik.WinControls.UI.RadForm
        {

            internal RadInputBoxInternal()
            {
                Shown += RadForm1_Shown;
                this.InitializeComponent();
            }

            [System.Diagnostics.DebuggerNonUserCode()]
            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing && components != null)
                    {
                        components.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }

            private System.ComponentModel.IContainer components;

            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
                this.ButtonOk = new Telerik.WinControls.UI.RadButton();
                this.ButtonCancel = new Telerik.WinControls.UI.RadButton();
                this.TextBoxInput = new Telerik.WinControls.UI.RadTextBox();
                this.LabelQuestion = new Telerik.WinControls.UI.RadLabel();
                ((System.ComponentModel.ISupportInitialize)this.ButtonOk).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this.ButtonCancel).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this.TextBoxInput).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this.LabelQuestion).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this).BeginInit();
                this.SuspendLayout();
                //
                //ButtonOk
                //
                this.ButtonOk.Location = new System.Drawing.Point(225, 4);
                this.ButtonOk.Name = "ButtonOk";
                this.ButtonOk.Size = new System.Drawing.Size(75, 23);
                this.ButtonOk.TabIndex = 0;
                this.ButtonOk.Text = "Ok";
                //
                //ButtonCancel
                //
                this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.ButtonCancel.Location = new System.Drawing.Point(225, 27);
                this.ButtonCancel.Name = "ButtonCancel";
                this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
                this.ButtonCancel.TabIndex = 1;
                this.ButtonCancel.Text = "Cancel";
                //
                //TextBoxInput
                //
                this.TextBoxInput.Location = new System.Drawing.Point(15, 29);
                this.TextBoxInput.Name = "TextBoxInput";
                this.TextBoxInput.Size = new System.Drawing.Size(162, 20);
                this.TextBoxInput.TabIndex = 2;
                this.TextBoxInput.TabStop = false;
                //
                //LabelQuestion
                //
                this.LabelQuestion.AutoSize = false;
                this.LabelQuestion.Location = new System.Drawing.Point(12, 4);
                this.LabelQuestion.Name = "LabelQuestion";
                this.LabelQuestion.Size = new System.Drawing.Size(165, 20);
                this.LabelQuestion.TabIndex = 3;
                this.LabelQuestion.Text = "text";
                //
                //RadForm1
                //
                this.AcceptButton = this.ButtonOk;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.CancelButton = this.ButtonCancel;
                this.ClientSize = new System.Drawing.Size(312, 52);
                this.Controls.Add(this.LabelQuestion);
                this.Controls.Add(this.TextBoxInput);
                this.Controls.Add(this.ButtonCancel);
                this.Controls.Add(this.ButtonOk);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "RadInputInternal";
                //
                //
                //
                this.RootElement.ApplyShapeToControl = true;
                this.Text = "RadInputInternal";
                ((System.ComponentModel.ISupportInitialize)this.ButtonOk).EndInit();
                ((System.ComponentModel.ISupportInitialize)this.ButtonCancel).EndInit();
                ((System.ComponentModel.ISupportInitialize)this.TextBoxInput).EndInit();
                ((System.ComponentModel.ISupportInitialize)this.LabelQuestion).EndInit();
                ((System.ComponentModel.ISupportInitialize)this).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

            }
            private Telerik.WinControls.UI.RadButton withEventsField_ButtonOk;
            internal Telerik.WinControls.UI.RadButton ButtonOk
            {
                get { return withEventsField_ButtonOk; }
                set
                {
                    if (withEventsField_ButtonOk != null)
                    {
                        withEventsField_ButtonOk.Click -= ButtonOk_Click;
                    }
                    withEventsField_ButtonOk = value;
                    if (withEventsField_ButtonOk != null)
                    {
                        withEventsField_ButtonOk.Click += ButtonOk_Click;
                    }
                }
            }
            internal Telerik.WinControls.UI.RadTextBox TextBoxInput;
            internal Telerik.WinControls.UI.RadLabel LabelQuestion;
            private Telerik.WinControls.UI.RadButton withEventsField_ButtonCancel;
            internal Telerik.WinControls.UI.RadButton ButtonCancel
            {
                get { return withEventsField_ButtonCancel; }
                set
                {
                    if (withEventsField_ButtonCancel != null)
                    {
                        withEventsField_ButtonCancel.Click -= ButtonCancel_Click;
                    }
                    withEventsField_ButtonCancel = value;
                    if (withEventsField_ButtonCancel != null)
                    {
                        withEventsField_ButtonCancel.Click += ButtonCancel_Click;
                    }
                }
            }


            private void RadForm1_Shown(System.Object sender, System.EventArgs e)
            {
                this.TextBoxInput.SelectionLength = 0;
                this.TextBoxInput.Focus();
            }

            private void ButtonCancel_Click(System.Object sender, System.EventArgs e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }

            private void ButtonOk_Click(System.Object sender, System.EventArgs e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }
    }
}
