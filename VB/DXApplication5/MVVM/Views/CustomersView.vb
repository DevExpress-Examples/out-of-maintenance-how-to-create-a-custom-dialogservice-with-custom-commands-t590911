Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DXApplication5.MVVM.ViewModels
Imports DevExpress.XtraBars.Docking2010
Imports DXApplication5.MVVM.Data
Imports DevExpress.XtraGrid.Views.Base

Namespace DXApplication5.MVVM.Views
	Partial Public Class CustomersView
		Inherits DevExpress.XtraEditors.XtraUserControl
		Public Sub New()
			InitializeComponent()
			If (Not mvvmContext.IsDesignMode) Then
				InitializeBindings()
			End If
		End Sub
		Private Sub InitializeBindings()
			mvvmContext.ViewModelType = GetType(CustomersViewModel)
			Dim fluent = mvvmContext.OfType(Of CustomersViewModel)()
			fluent.SetBinding(customersGridControl, Function(c) c.DataSource, Function(x) x.Entities)
            fluent.BindCommand(TryCast(windowsUIButtonPanel.Buttons(0), WindowsUIButton), Sub(x) x.FindCustomer())
            fluent.WithEvent(Of ColumnView, FocusedRowObjectChangedEventArgs)(gridView1, "FocusedRowObjectChanged").SetBinding(Function(x) x.SelectedEntity, _
                                           Function(args) TryCast(args.Row, Customer), Sub(gView, entity) gView.FocusedRowHandle = gView.FindRow(entity))

		End Sub
	End Class
End Namespace
