Imports Microsoft.VisualBasic
Imports System
Namespace DXApplication5.MVVM.Views
	Partial Public Class CustomersView
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(CustomersView))
			Me.mvvmContext = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
			Me.customersGridControl = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.windowsUIButtonPanel = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
			CType(Me.mvvmContext, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.customersGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' mvvmContext
			' 
			Me.mvvmContext.ContainerControl = Me
			' 
			' customersGridControl
			' 
			Me.customersGridControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.customersGridControl.Location = New System.Drawing.Point(0, 0)
			Me.customersGridControl.MainView = Me.gridView1
			Me.customersGridControl.Name = "customersGridControl"
			Me.customersGridControl.Size = New System.Drawing.Size(689, 433)
			Me.customersGridControl.TabIndex = 0
			Me.customersGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.customersGridControl
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsBehavior.Editable = False
			Me.gridView1.OptionsSelection.MultiSelect = True
			Me.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
			Me.gridView1.OptionsView.ShowGroupPanel = False
			' 
			' windowsUIButtonPanel
			' 
            Me.windowsUIButtonPanel.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("", (CType(resources.GetObject("windowsUIButtonImageOptions1.Image"), System.Drawing.Image)), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1)})
			Me.windowsUIButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.windowsUIButtonPanel.Location = New System.Drawing.Point(0, 433)
			Me.windowsUIButtonPanel.Name = "windowsUIButtonPanel"
			Me.windowsUIButtonPanel.Size = New System.Drawing.Size(689, 48)
			Me.windowsUIButtonPanel.TabIndex = 1
			Me.windowsUIButtonPanel.Text = "windowsUIButtonPanel1"
			' 
			' CustomersView
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.customersGridControl)
			Me.Controls.Add(Me.windowsUIButtonPanel)
			Me.Name = "CustomersView"
			Me.Size = New System.Drawing.Size(689, 481)
			CType(Me.mvvmContext, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.customersGridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private mvvmContext As DevExpress.Utils.MVVM.MVVMContext
		Private customersGridControl As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private windowsUIButtonPanel As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
	End Class
End Namespace
