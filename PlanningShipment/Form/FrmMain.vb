Imports System.ComponentModel
Imports System.Text
Imports CHR.Common

Partial Public Class FrmMain
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Mode = 0
        Dim f As New frmList(New ClsMaster) With {.Text = "Master Pengangkutan"}
        Dim formOpen As Boolean = False
        For Each form As frmList In Me.MdiChildren
            If form.Text = "Master Pengangkutan" Then
                formOpen = True
                Exit For
            End If
        Next

        If formOpen Then
            f.Activate()
        Else
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Mode = 1
        Dim f As New frmList(New ClsMaster) With {.Text = "Kendaraan Pengangkutan"}
        Dim formOpen As Boolean = False
        For Each form As frmList In Me.MdiChildren
            If form.Text = "Kendaraan Pengangkutan" Then
                formOpen = True
                Exit For
            End If
        Next

        If formOpen Then
            f.Activate()
        Else
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Mode = 2
        Dim f As New frmList(New ClsMaster) With {.Text = "List Ukuran Pallet"}
        Dim formOpen As Boolean = False
        For Each form As frmList In Me.MdiChildren
            If form.Text = "List Ukuran Pallet" Then
                formOpen = True
                Exit For
            End If
        Next

        If formOpen Then
            f.Activate()
        Else
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim f As New Maps
        f.Show()
    End Sub


    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim f As New frmList(New ClsPlanShipment) With {.Text = "Planning Shipment", .IsGridEditable = True}
        f.MdiParent = Me
        f.Show()

    End Sub
End Class
