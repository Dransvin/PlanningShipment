<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.MainMap = New GMap.NET.WindowsForms.GMapControl()
        Me.SuspendLayout()
        '
        'MainMap
        '
        Me.MainMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainMap.Bearing = 0!
        Me.MainMap.CanDragMap = True
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
        Me.MainMap.Size = New System.Drawing.Size(484, 405)
        Me.MainMap.TabIndex = 2
        Me.MainMap.Zoom = 0R
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 397)
        Me.Controls.Add(Me.MainMap)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainMap As GMap.NET.WindowsForms.GMapControl
End Class
