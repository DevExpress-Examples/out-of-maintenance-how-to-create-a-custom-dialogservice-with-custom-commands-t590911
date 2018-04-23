using DevExpress.Mvvm;
using DXApplication5.MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm.POCO;
using System.Windows.Forms;

namespace DXApplication5.MVVM.ViewModels {
    public class CustomersViewModel : BaseViewModel<Customer> {
        public CustomersViewModel() {
            Entities = DataAccessHelper.GetCustomers();
        }
        public IDialogService DialogService {
            get {
                return this.GetService<IDialogService>();
            }
        }
        public void FindCustomer() {
            var findDialogViewModel = FindDialogViewModel.Create();
            findDialogViewModel.SetParentViewModel(this);
            if (SelectedEntity != null) {
                findDialogViewModel.SearchID = SelectedEntity.ID;
            }
            var commands = new List<UICommand>
                {
                    new UICommand {
                        Id = "Find",
                        Caption = "Find",
                        Command = new DelegateCommand(() => NavigateToCustomerByID(findDialogViewModel)),
                        IsDefault = true,
                        IsCancel = false, 
                        Tag = DialogResult.OK
                    }
                };

            DialogService.ShowDialog(commands, "Find Customer", "FindDialogView", findDialogViewModel);
        }
        void NavigateToCustomerByID(FindDialogViewModel findDialogViewModel) {
            SelectedEntity = Entities.FirstOrDefault(c => c.ID == findDialogViewModel.SearchID);
        }
    }
}
