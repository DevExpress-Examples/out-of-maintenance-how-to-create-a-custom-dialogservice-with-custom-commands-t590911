Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq

Namespace DXApplication5.MVVM.Data
	Public Class DataAccessHelper
		Public Shared Function GetCustomers() As BindingList(Of Customer)
			Dim dt As New BindingList(Of Customer)()
			For i As Integer = 0 To 999
				dt.Add(New Customer With {.ID = i, .FirstName = String.Format("Name {0}", i), .LastName = String.Format("Last Name {0}", i)})
			Next i
			Return dt
		End Function
	End Class
End Namespace
