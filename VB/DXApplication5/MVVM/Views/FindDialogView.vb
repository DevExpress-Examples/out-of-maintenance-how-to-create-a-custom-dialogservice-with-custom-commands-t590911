Imports Microsoft.VisualBasic
Imports DXApplication5.MVVM.ViewModels
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace DXApplication5.MVVM.Views
	Partial Public Class FindDialogView
		Inherits DevExpress.XtraEditors.XtraUserControl
		Public Sub New()
			InitializeComponent()
        End Sub
        Protected Overrides Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)
            InitializeBindings()
        End Sub
		Private Sub InitializeBindings()
			Dim fluent = mvvmContext.OfType(Of FindDialogViewModel)()
            fluent.SetBinding(findTextEdit, Function(f) f.EditValue, Function(x) x.SearchID)
		End Sub
	End Class
End Namespace
