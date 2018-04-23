Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DXApplication5.MVVM.ViewModels
	Public Class FindDialogViewModel
		Public Shared Function Create() As FindDialogViewModel
			Return ViewModelSource.Create(Of FindDialogViewModel)()
		End Function
        Public Overridable Property SearchID As Int32
    End Class
End Namespace
