Imports GMap.NET
Imports GMap.NET.MapProviders
Imports System.Text
Imports CefSharp.WinForms
Imports GMap.NET.WindowsForms
Imports System
Imports Microsoft.Maps.MapControl.WPF
Imports System.Windows.Media
Imports CHR.Common

Public Class Maps
    Private WithEvents browser As ChromiumWebBrowser
    Private _points As List(Of PointLatLng) = New List(Of PointLatLng)
    Dim x As Integer = 0
    Dim Constr As String = GetConnectionString(My.Settings.Server, My.Settings.DatabaseCustom, My.Settings.AppID, False, "sa", "ipiserver!234")
    Dim dt As DataTable = GetDataTable("SELECT TOP 30 Name,Address from IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$Ship-to Address] WHERE Address LIKE '%JL.%'", Constr)
    Dim b As Integer = 0
    Dim NamaTempat As String
    Private Sub Maps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim setting As New CefSettings
        'setting.RemoteDebuggingPort = 8888
        'CefSharp.Cef.Initialize(setting)
        'browser = New ChromiumWebBrowser("https://www.google.com/maps/") With {
        '.Dock = DockStyle.Fill
        '}
        'Panel1.Controls.Add(browser)
        '       GMapProviders.GoogleMap.ApiKey = My.Settings.BingMapKey
        GMapProviders.BingMap.ClientKey = My.Settings.BingMapKey
        MainMap.DragButton = MouseButtons.Left
        MainMap.MapProvider = GMapProviders.BingMap
        '  MainMap.Position = New PointLatLng(3.6640055, 98.6688937)
        MainMap.MinZoom = 5
        MainMap.MaxZoom = 100
        MainMap.Zoom = 10
        MainMap.SetPositionByKeywords("Medan, INDONESIA")

    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        '  MainMap.MapProvider = GMapProviders.GoogleMap
        'Dim lat As Double = Convert.ToDouble(latitude.Text)
        'Dim longs As Double = Convert.ToDouble(longtitude.Text)
        MainMap.Position = New PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longtitude.Text))
        MainMap.MinZoom = 5
        MainMap.MaxZoom = 100
        MainMap.Zoom = 10
        _points.Add(New PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longtitude.Text)))
        Dim point As PointLatLng = New PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longtitude.Text))
        Dim Penanda As GMapMarker = New Markers.GMarkerGoogle(point, Markers.GMarkerGoogleType.red_pushpin)
        Dim tanda As GMapOverlay = New GMapOverlay("markers")
        Penanda.ToolTipText = NamaTempat
        tanda.Markers.Add(Penanda)
        MainMap.Overlays.Add(tanda)
        If b = 0 Then
            dt.Columns.Add()
            b = b + 1
        End If
    End Sub

    Private Sub btnRoute_Click(sender As Object, e As EventArgs) Handles btnRoute.Click
        ' Dim route = BingMapProvider.Instance.GetRoute(_points(0), _points(1), False, False, 14)
        Dim provider As BingMapProvider = BingMapProvider.Instance
        Dim totaljarak As Integer = 0
        ' Membuat objek GMapRoute untuk menyimpan rute-rute
        Dim routesOverlay As GMapOverlay = New GMapOverlay("routes")

        ' Loop melalui daftar lokasi
        For i As Integer = 0 To _points.Count - 2
            Dim random As New Random()
            Dim color As Color = color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256))

            ' Membuat objek Pen dengan warna yang dihasilkan
            Dim pen As New Pen(color, 3)
            ' Mendapatkan rute antara dua titik lokasi
            Dim route = provider.GetRoute(_points(i), _points(i + 1), False, False, 14)
            totaljarak = totaljarak + IsNulls(route.Distance, 0)
            ' Membuat objek GMapRoute untuk rute
            Dim gmapRoute As GMapRoute = New GMapRoute(route.Points, "Route " & (i + 1))
            gmapRoute.Stroke = pen
            ' Menambahkan rute ke overlay
            routesOverlay.Routes.Add(gmapRoute)
        Next
        'Dim r = New GMapRoute(route.Points, "My Route")
        'Dim routes As GMapOverlay = New GMapOverlay("routes")
        'routes.Routes.Add(r)
        MainMap.Overlays.Add(routesOverlay)
        lblJarak.Text = totaljarak.ToString + " Km"

    End Sub

    Private Sub btnAddPoint_Click(sender As Object, e As EventArgs) Handles btnAddPoint.Click
        _points.Add(New PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longtitude.Text)))
        Dim Penanda As GMapMarker = New Markers.GMarkerGoogle(_points(x), Markers.GMarkerGoogleType.red_pushpin)
        Dim tanda As GMapOverlay = New GMapOverlay("markers")
        tanda.Markers.Add(Penanda)
        MainMap.Overlays.Add(tanda)
        x = x + 1
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        _points.Clear()
        x = 0
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        If longtitude.Text = "" Then
            Dim statuscode As GeoCoderStatusCode
            For Each row As DataRow In dt.Rows

                Dim alamat As String = row.Item("Address") & " Medan Indonesia"
                Dim pointstatuscode = BingMapProvider.Instance.GetPoint(alamat, statuscode)
                NamaTempat = row.Item("Name") & "
" & row.Item("Address")
                If (statuscode = GeoCoderStatusCode.OK) Then
                    latitude.Text = pointstatuscode?.Lat.ToString()
                    longtitude.Text = pointstatuscode?.Lng.ToString()
                    btnFind.PerformClick()
                    'Else
                    '    btnFind.PerformClick()
                End If
            Next
        End If
    End Sub
End Class