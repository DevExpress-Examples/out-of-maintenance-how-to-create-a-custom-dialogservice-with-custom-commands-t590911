Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm.POCO

Namespace DXApplication5.MVVM.ViewModels
	Public Class DocumentsViewModel
		Private ReadOnly viewNameSuffix As String = "View"
		Public ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return Me.GetRequiredService(Of IDocumentManagerService)()
			End Get
		End Property
		Private privateDocumentType As DocumentType
		Public Overridable Property DocumentType() As DocumentType
		Protected Sub OnDocumentTypeChanged()
			LoadDocument()
		End Sub
		Public Sub LoadDocument()
			If DocumentType <> DocumentType.None AndAlso DocumentManagerService IsNot Nothing Then
				Dim document As IDocument = DocumentManagerService.FindDocumentByIdOrCreate(DocumentType, Function(x) CreateDocument())
				document.Show()
			End If
		End Sub
		Public Sub LoadDefaultDocument()
            DocumentType = DocumentType.Customers
		End Sub
		Private Function CreateDocument() As IDocument
			Dim document = DocumentManagerService.CreateDocument(DocumentType.ToString() & viewNameSuffix, Nothing, Me)
			document.Title = DocumentType
			document.DestroyOnClose = False
			Return document
		End Function
	End Class
	Public Enum DocumentType
		None
		Customers
	End Enum
End Namespace
