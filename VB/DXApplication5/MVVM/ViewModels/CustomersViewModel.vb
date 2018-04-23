Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports DXApplication5.MVVM.Data
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Mvvm.POCO
Imports System.Windows.Forms

Namespace DXApplication5.MVVM.ViewModels
	Public Class CustomersViewModel
		Inherits BaseViewModel(Of Customer)
		Public Sub New()
			Entities = DataAccessHelper.GetCustomers()
		End Sub
		Public ReadOnly Property DialogService() As IDialogService
			Get
				Return Me.GetService(Of IDialogService)()
			End Get
		End Property
		Public Sub FindCustomer()
            Dim _findDialogViewModel = FindDialogViewModel.Create()
            _findDialogViewModel.SetParentViewModel(Me)
            If SelectedEntity IsNot Nothing Then
                _findDialogViewModel.SearchID = SelectedEntity.ID
            End If
            Dim commands = New List(Of UICommand)(New UICommand() {New UICommand With {.Id = "Find", .Caption = "Find", .Command = New DelegateCommand(Sub() NavigateToCustomerByID(_findDialogViewModel)), .IsDefault = True, .IsCancel = False, .Tag = DialogResult.OK}})

            DialogService.ShowDialog(commands, "Find Customer", "FindDialogView", _findDialogViewModel)
		End Sub
        Private Sub NavigateToCustomerByID(ByVal _findDialogViewModel As FindDialogViewModel)
            SelectedEntity = Entities.FirstOrDefault(Function(c) c.ID = _findDialogViewModel.SearchID)
        End Sub
	End Class
End Namespace
