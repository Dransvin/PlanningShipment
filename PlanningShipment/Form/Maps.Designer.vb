<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Maps
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddPoint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRoute = New DevExpress.XtraEditors.SimpleButton()
        Me.longtitude = New DevExpress.XtraEditors.TextEdit()
        Me.btnFind = New DevExpress.XtraEditors.SimpleButton()
        Me.latitude = New DevExpress.XtraEditors.TextEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MainMap = New GMap.NET.WindowsForms.GMapControl()
        Me.lblJarak = New System.Windows.Forms.Label()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.longtitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.latitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.lblJarak)
        Me.PanelControl1.Controls.Add(Me.btnLoad)
        Me.PanelControl1.Controls.Add(Me.btnClear)
        Me.PanelControl1.Controls.Add(Me.btnAddPoint)
        Me.PanelControl1.Controls.Add(Me.btnRoute)
        Me.PanelControl1.Controls.Add(Me.longtitude)
        Me.PanelControl1.Controls.Add(Me.btnFind)
        Me.PanelControl1.Controls.Add(Me.latitude)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1254, 82)
        Me.PanelControl1.TabIndex = 1
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(571, 24)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(112, 34)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Load"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(689, 24)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 34)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        '
        'btnAddPoint
        '
        Me.btnAddPoint.Location = New System.Drawing.Point(452, 24)
        Me.btnAddPoint.Name = "btnAddPoint"
        Me.btnAddPoint.Size = New System.Drawing.Size(112, 34)
        Me.btnAddPoint.TabIndex = 5
        Me.btnAddPoint.Text = "Add Points"
        '
        'btnRoute
        '
        Me.btnRoute.Location = New System.Drawing.Point(334, 24)
        Me.btnRoute.Name = "btnRoute"
        Me.btnRoute.Size = New System.Drawing.Size(112, 34)
        Me.btnRoute.TabIndex = 4
        Me.btnRoute.Text = "Route"
        '
        'longtitude
        '
        Me.longtitude.Location = New System.Drawing.Point(12, 44)
        Me.longtitude.Name = "longtitude"
        Me.longtitude.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.longtitude.Size = New System.Drawing.Size(150, 26)
        Me.longtitude.TabIndex = 3
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(196, 24)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(112, 34)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Find"
        '
        'latitude
        '
        Me.latitude.Location = New System.Drawing.Point(12, 12)
        Me.latitude.Name = "latitude"
        Me.latitude.Size = New System.Drawing.Size(150, 26)
        Me.latitude.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MainMap)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1254, 520)
        Me.Panel1.TabIndex = 0
        '
        'MainMap
        '
        Me.MainMap.Bearing = 0!
        Me.MainMap.CanDragMap = True
        Me.MainMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainMap.EmptyTileColor = System.Drawing.Color.Navy
        Me.MainMap.GrayScaleMode = False
        Me.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.MainMap.LevelsKeepInMemory = 5
        Me.MainMap.Location = New System.Drawing.Point(0, 0)
        Me.MainMap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MainMap.MarkersEnabled = True
        Me.MainMap.MaxZoom = 2
        Me.MainMap.MinZoom = 2
        Me.MainMap.MouseWheelZoomEnabled = True
        Me.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.MainMap.Name = "MainMap"
        Me.MainMap.NegativeMode = False
        Me.MainMap.PolygonsEnabled = True
        Me.MainMap.RetryLoadTile = 0
        Me.MainMap.RoutesEnabled = True
        Me.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.MainMap.ShowTileGridLines = False
        Me.MainMap.Size = New System.Drawing.Size(1254, 520)
        Me.MainMap.TabIndex = 3
        Me.MainMap.Zoom = 0R
        '
        'lblJarak
        '
        Me.lblJarak.AutoSize = True
        Me.lblJarak.Location = New System.Drawing.Point(836, 38)
        Me.lblJarak.Name = "lblJarak"
        Me.lblJarak.Size = New System.Drawing.Size(48, 20)
        Me.lblJarak.TabIndex = 4
        Me.lblJarak.Text = "Jarak"
        '
        'Maps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 602)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "Maps"
        Me.Text = "Maps"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.longtitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.latitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents latitude As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnFind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MainMap As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents longtitude As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnRoute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddPoint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblJarak As Label
End Class
