Imports GMap.NET
Imports GMap.NET.MapProviders

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainMap.MapProvider = GMapProviders.GoogleSatelliteMap
        MainMap.Position = New PointLatLng(3.6640055, 98.6688937)
        MainMap.MinZoom = 0
        MainMap.MaxZoom = 24
        MainMap.Zoom = 9
    End Sub
End Class
