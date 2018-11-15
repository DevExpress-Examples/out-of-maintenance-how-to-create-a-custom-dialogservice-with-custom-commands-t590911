<!-- default file list -->
*Files to look at*:

* [Customer.cs](./CS/DXApplication5/MVVM/Data/Customer.cs) (VB: [Customer.vb](./VB/DXApplication5/MVVM/Data/Customer.vb))
* [DataAccess.cs](./CS/DXApplication5/MVVM/Data/DataAccess.cs) (VB: [DataAccess.vb](./VB/DXApplication5/MVVM/Data/DataAccess.vb))
* [BaseViewModel.cs](./CS/DXApplication5/MVVM/ViewModels/BaseViewModel.cs) (VB: [BaseViewModel.vb](./VB/DXApplication5/MVVM/ViewModels/BaseViewModel.vb))
* [CustomersViewModel.cs](./CS/DXApplication5/MVVM/ViewModels/CustomersViewModel.cs) (VB: [CustomersViewModel.vb](./VB/DXApplication5/MVVM/ViewModels/CustomersViewModel.vb))
* [DocumentsViewModel.cs](./CS/DXApplication5/MVVM/ViewModels/DocumentsViewModel.cs) (VB: [DocumentsViewModel.vb](./VB/DXApplication5/MVVM/ViewModels/DocumentsViewModel.vb))
* [FindDialogViewModel.cs](./CS/DXApplication5/MVVM/ViewModels/FindDialogViewModel.cs) (VB: [FindDialogViewModel.vb](./VB/DXApplication5/MVVM/ViewModels/FindDialogViewModel.vb))
* [CustomersView.cs](./CS/DXApplication5/MVVM/Views/CustomersView.cs) (VB: [CustomersView.vb](./VB/DXApplication5/MVVM/Views/CustomersView.vb))
* [FindDialogView.cs](./CS/DXApplication5/MVVM/Views/FindDialogView.cs) (VB: [FindDialogView.vb](./VB/DXApplication5/MVVM/Views/FindDialogView.vb))
* [MainView.cs](./CS/DXApplication5/MVVM/Views/MainView.cs) (VB: [MainView.vb](./VB/DXApplication5/MVVM/Views/MainView.vb))
* [Program.cs](./CS/DXApplication5/Program.cs) (VB: [Program.vb](./VB/DXApplication5/Program.vb))
<!-- default file list end -->
# How to create a custom DialogService with custom commands


<p><strong>Starting from version</strong> <strong>17.2.5</strong> our <strong>DialogService</strong> supports custom <strong>UICommands</strong>. I should note that each <strong>UICommand</strong> should have the <strong>Id</strong> or <strong>Tag</strong> property set to <strong>MessageResult</strong> or <strong>DialogResult</strong>. Thus, creation of a custom dialog service is no longer required. <br><br><strong>For earlier versions:</strong><br><br>It is possible to specify what buttons should be shown by a dialog form associated with <strong>DialogService</strong> by passing <strong>MessageButton</strong> to the <strong>ShowDialog</strong> method. Such buttons are limited to a predefined set of values (OK, OKCancel, YesNoCancel, and YesNo). If you wish to create custom buttons with your own captions and associate them with the necessary custom commands, create a custom <strong>DialogService</strong> and pass a list of <strong>UICommands</strong> to the <strong>ShowDialog</strong> method. <br>This example shows how to implement such a service and register it. Here, by using a custom find dialog, you are able to locate the necessary record in the grid by using the data model's Id and focus it. </p>

<br/>


