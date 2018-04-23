using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors;
using DXApplication5.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DXApplication5 {
    public partial class MainView : XtraForm {
        public MainView() {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings() {
            mvvmContext.RegisterDefaultService(DialogService.CreateXtraDialogService(this));
            var fluent = mvvmContext.OfType<DocumentsViewModel>();
            mvvmContext.RegisterDefaultService(DocumentManagerService.Create(navigationFrame));
            fluent.WithEvent(this, "Load")
                 .EventToCommand(x => x.LoadDefaultDocument());
        }
    }
}

