using DXApplication5.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DXApplication5.MVVM.Views {
    public partial class FindDialogView : DevExpress.XtraEditors.XtraUserControl {
        public FindDialogView() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitializeBindings();
        }
        private void InitializeBindings() {
            var fluent = mvvmContext.OfType<FindDialogViewModel>();
            fluent.SetBinding(findTextEdit, f => f.EditValue, x => x.SearchID);
        }
    }
}
