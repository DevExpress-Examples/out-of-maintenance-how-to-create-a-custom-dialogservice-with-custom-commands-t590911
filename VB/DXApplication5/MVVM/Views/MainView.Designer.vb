Imports Microsoft.VisualBasic
Imports System
Namespace DXApplication5
	Partial Public Class MainView
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.navigationFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
			Me.navigationPage1 = New DevExpress.XtraBars.Navigation.NavigationPage()
			Me.navigationPage2 = New DevExpress.XtraBars.Navigation.NavigationPage()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.mvvmContext = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
			CType(Me.navigationFrame, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.navigationFrame.SuspendLayout()
			CType(Me.mvvmContext, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' navigationFrame
			' 
			Me.navigationFrame.Controls.Add(Me.navigationPage1)
			Me.navigationFrame.Controls.Add(Me.navigationPage2)
			Me.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill
			Me.navigationFrame.Location = New System.Drawing.Point(0, 0)
			Me.navigationFrame.Name = "navigationFrame"
			Me.navigationFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() { Me.navigationPage1, Me.navigationPage2})
			Me.navigationFrame.SelectedPage = Me.navigationPage2
			Me.navigationFrame.Size = New System.Drawing.Size(1118, 607)
			Me.navigationFrame.TabIndex = 1
			Me.navigationFrame.Text = "navigationFrame1"
			' 
			' navigationPage1
			' 
			Me.navigationPage1.Caption = "navigationPage1"
			Me.navigationPage1.Name = "navigationPage1"
			Me.navigationPage1.Size = New System.Drawing.Size(1118, 607)
			' 
			' navigationPage2
			' 
			Me.navigationPage2.Caption = "navigationPage2"
			Me.navigationPage2.Name = "navigationPage2"
			Me.navigationPage2.Size = New System.Drawing.Size(1118, 607)
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "The Bezier"
			' 
			' mvvmContext
			' 
			Me.mvvmContext.ContainerControl = Me
			Me.mvvmContext.ViewModelType = GetType(DXApplication5.MVVM.ViewModels.DocumentsViewModel)
			' 
			' MainView
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1118, 607)
			Me.Controls.Add(Me.navigationFrame)
			Me.Name = "MainView"
			Me.Text = "MainView"
			CType(Me.navigationFrame, System.ComponentModel.ISupportInitialize).EndInit()
			Me.navigationFrame.ResumeLayout(False)
			CType(Me.mvvmContext, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private mvvmContext As DevExpress.Utils.MVVM.MVVMContext
		Private navigationFrame As DevExpress.XtraBars.Navigation.NavigationFrame
		Private navigationPage1 As DevExpress.XtraBars.Navigation.NavigationPage
		Private navigationPage2 As DevExpress.XtraBars.Navigation.NavigationPage
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
	End Class
End Namespace

