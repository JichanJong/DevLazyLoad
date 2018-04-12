using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace WindowsApplication1 {
    [System.ComponentModel.DesignerCategory("")]
    public class MyLookUpEdit : LookUpEdit {
        static MyLookUpEdit() {
            RepositoryItemMyLookUpEdit.Register();
        }
        public override object EditValue {
            get {
                return base.EditValue;
            }
            set {
                base.EditValue = value;
            }
        }
        public override string EditorTypeName {
            get {
                return RepositoryItemMyLookUpEdit.EditorName;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyLookUpEdit Properties {
            get {
                return base.Properties as RepositoryItemMyLookUpEdit;
            }
        }

        public override void ClosePopup() {
            base.ClosePopup();
            
        }

        protected override void ProcessFindItem(DevExpress.XtraEditors.Controls.KeyPressHelper helper, char pressedKey) {
            AssignDataSource(AutoSearchText);
            base.ProcessFindItem(helper, pressedKey);
        }
        private bool isNeedShowPopup(bool canImmediatePopup) {
            if(!this.IsEditorActive) {
                return false;
            }
            return ((canImmediatePopup && this.Properties.ImmediatePopup) || (this.Properties.SearchMode == SearchMode.AutoFilter));
        }
        private void maskBoxTextModified() {
            this.UpdateMaskBoxDisplayText();
            this.IsModified = true;
        }

        protected override void ProcessText(DevExpress.XtraEditors.Controls.KeyPressHelper helper, bool canImmediatePopup, char pressedKey, bool partialSearch) {
            bool isPopupOpen = this.IsPopupOpen;
            if(this.isNeedShowPopup(canImmediatePopup)) {
                this.ShowPopup();
            }
            int rowIndex = this.FindItem(helper.Text, partialSearch, 0);
            var t = typeof(LookUpEdit);
            var field = t.GetField("isDisplayTextValid", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field.SetValue(this,false);
                this.AutoSearchText = helper.Text;
                if(this.IsMaskBoxAvailable) {
                    this.maskBoxTextModified();
                }
                this.SelectionStart = helper.Text.Length;
            this.PopupForm.Filter.FilterPrefix = this.IsMaskBoxAvailable ? this.MaskBox.MaskBoxText : base.GetAutoSearchTextFilter();
            this.LayoutChanged();
        }
        private void AssignDataSource(string autoSearchText) {
            Properties.UpdateDataSource(autoSearchText);
        }
    }
}
