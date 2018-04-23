using System;
using System.Collections.Generic;
using System.Linq;
using DXApplication5.MVVM.ViewModels;
using DevExpress.XtraBars.Docking2010;
using DXApplication5.MVVM.Data;
using DevExpress.XtraEditors;
using DevExpress.Utils.MVVM.Services;

namespace DXApplication5.MVVM.Views {
    public partial class CustomersView : DevExpress.XtraEditors.XtraUserControl {
        public CustomersView() {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode) {
                InitializeBindings();
            }
        }
        private void InitializeBindings() {
            mvvmContext.ViewModelType = typeof(CustomersViewModel);
            var fluent = mvvmContext.OfType<CustomersViewModel>();
            fluent.SetBinding(customersGridControl, c => c.DataSource, x => x.Entities);
            fluent.BindCommand(windowsUIButtonPanel.Buttons[0] as WindowsUIButton, x => x.FindCustomer());
            fluent.WithEvent<DevExpress.XtraGrid.Views.Base.ColumnView, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity,
                    args => args.Row as Customer,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            
        }
    }
}
