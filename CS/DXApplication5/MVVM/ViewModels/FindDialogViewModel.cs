using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication5.MVVM.ViewModels {
    public class FindDialogViewModel {
        public FindDialogViewModel() { }
        public static FindDialogViewModel Create() {
            return ViewModelSource.Create<FindDialogViewModel>();
        }
        public virtual int SearchID { get; set; }
    }
}
