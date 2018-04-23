Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports DevExpress.Utils.MVVM
Imports DevExpress.Utils.MVVM.Services
Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DXApplication5.MVVM.Service
	Public Class CustomDialogService
		Inherits ViewServiceBase
		Implements IDialogService
		Private getForm As Func(Of Action(Of IDialogForm), IDialogForm)
		Private owner As IWin32Window
		Private title As String
		Protected Sub New(ByVal owner As IWin32Window, ByVal title As String, ByVal getForm As Func(Of Action(Of IDialogForm), IDialogForm))
			Me.owner = owner
			Me.title = title
			Me.getForm = getForm
		End Sub
		Public Shared Function Create(ByVal owner As IWin32Window, Optional ByVal title As String = Nothing) As CustomDialogService
			Return New CustomDialogService(owner, title, Function(onFormCustomization) New DialogFormWithCustomButtons(onFormCustomization))
		End Function
        Public Function ShowDialog(ByVal dialogCommands As IEnumerable(Of UICommand), ByVal title As String, ByVal documentType As String, ByVal viewModel As Object, ByVal parameter As Object, ByVal parentViewModel As Object) As UICommand Implements IDialogService.ShowDialog
            Dim results() As DialogResult = GetResults(dialogCommands)
            Dim result As DialogResult = results.FirstOrDefault()
            If getForm IsNot Nothing AndAlso (Not DevExpress.Utils.Design.DesignTimeTools.IsDesignMode) Then
                Using dialogForm As IDialogForm = getForm(Sub(f)
                                                              Dim form = TryCast(f, DialogFormWithCustomButtons)
                                                              For index = 0 To form.Buttons.Length - 1
                                                                  Dim btn = form.Buttons(index)
                                                                  Dim command = dialogCommands.ElementAt(index)
                                                                  btn.Text = If(command.Caption Is Nothing, String.Empty, command.Caption.ToString())
                                                                  btn.BindCommand(command.Command)
                                                                  If (command.IsDefault) Then
                                                                      form.AcceptButton = btn
                                                                  End If

                                                                  If (command.IsCancel) Then
                                                                      form.CancelButton = btn
                                                                  End If
                                                              Next
                                                          End Sub)
                    AddHandler dialogForm.Closing, AddressOf DialogForm_Closing
                    AddHandler dialogForm.Closed, AddressOf DialogForm_Closed
                    Dim content As Control = CreateAndInitializeView(documentType, viewModel, parameter, parentViewModel)
                    Dim caption As String = If((Not String.IsNullOrEmpty(title)), title, TryCast(MVVMContext.GetTitle(content), String))
                    result = dialogForm.ShowDialog(owner, content, caption, results)
                    RemoveHandler dialogForm.Closing, AddressOf DialogForm_Closing
                    RemoveHandler dialogForm.Closed, AddressOf DialogForm_Closed
                End Using
            End If

            Dim resultIndex As Integer = Array.IndexOf(results, result)
            Return If((resultIndex <> -1 AndAlso dialogCommands.Count() > 0), dialogCommands.ElementAt(resultIndex), Nothing)
        End Function
        Private Function GetResults(ByVal dialogCommands As IEnumerable(Of UICommand)) As DialogResult()
			Return dialogCommands.Select(Function(c) CType(c.Tag, DialogResult)).ToArray()
		End Function
		Private Sub DialogForm_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim dialogForm = CType(sender, IDialogForm)
			MVVMContext.OnClose(dialogForm.Content, e)
		End Sub
        Private Sub DialogForm_Closed(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialogForm = CType(sender, IDialogForm)
            RemoveHandler dialogForm.Closing, AddressOf DialogForm_Closing
            RemoveHandler dialogForm.Closed, AddressOf DialogForm_Closed
            MVVMContext.OnDestroy(dialogForm.Content)
        End Sub

        Private Class DialogFormWithCustomButtons
            Inherits XtraDialogForm
            Implements IDialogForm
            Private onFormCustomization As Action(Of IDialogForm)
            Public Sub New(Optional ByVal onFormCustomization As Action(Of IDialogForm) = Nothing)
                Me.onFormCustomization = onFormCustomization
            End Sub
            Friend Shadows ReadOnly Property Buttons() As SimpleButton()
                Get
                    Return MyBase.Buttons
                End Get
            End Property
            Private ReadOnly Property Content() As Control Implements IDialogForm.Content
                Get
                    Return Message.Content
                End Get
            End Property
            Private Shadows Function ShowDialog(ByVal owner As IWin32Window, ByVal content As Control, ByVal caption As String, ByVal buttons() As DialogResult) As DialogResult Implements IDialogForm.ShowDialog
                Dim args As New XtraDialogArgs() With {.Owner = owner, .Content = content, .Caption = caption, .Buttons = buttons}
                AddHandler args.Showing, AddressOf BeforeFormShowing
                Return ShowMessageBoxDialog(args)
            End Function
            Private Sub BeforeFormShowing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
                If onFormCustomization IsNot Nothing Then
                    onFormCustomization(Me)
                End If
            End Sub
            Public Shadows Event Closing As CancelEventHandler Implements IDialogForm.Closing
            Public Shadows Event Closed As EventHandler Implements IDialogForm.Closed

            Public Shadows Sub Close() Implements IDialogForm.Close
                MyBase.Close()
            End Sub
        End Class
	End Class
End Namespace
