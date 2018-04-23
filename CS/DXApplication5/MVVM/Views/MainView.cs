using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors;
using DXApplication5.MVVM.Service;
using DXApplication5.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DXApplication5 {
    public partial class MainView : XtraForm {
        public MainView() {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings() {
            mvvmContext.RegisterService(CustomDialogService.Create(this));
            var fluent = mvvmContext.OfType<DocumentsViewModel>();
            mvvmContext.RegisterDefaultService(DocumentManagerService.Create(navigationFrame));
            fluent.WithEvent(this, "Load")
                 .EventToCommand(x => x.LoadDefaultDocument());
        }
    }
}

