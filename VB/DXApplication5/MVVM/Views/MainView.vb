Imports Microsoft.VisualBasic
Imports DevExpress.Utils.MVVM.Services
Imports DevExpress.XtraEditors
Imports DXApplication5.MVVM.Service
Imports DXApplication5.MVVM.ViewModels
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace DXApplication5
	Partial Public Class MainView
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
            If (Not mvvmContext.IsDesignMode) Then
                InitializeBindings()
            End If
		End Sub

		Private Sub InitializeBindings()
			mvvmContext.RegisterService(CustomDialogService.Create(Me))
			Dim fluent = mvvmContext.OfType(Of DocumentsViewModel)()
			mvvmContext.RegisterDefaultService(DocumentManagerService.Create(navigationFrame))
            fluent.WithEvent(Me, "Load").EventToCommand(Sub(x) x.LoadDefaultDocument())
        End Sub
    End Class
End Namespace

