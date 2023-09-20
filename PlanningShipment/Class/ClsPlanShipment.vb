Imports CHR.Common
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid

Public Class ClsPlanShipment
    Implements iclsList

    Dim ModeForm As Integer = Mode
    Dim template As New TemplateControl
    Dim SQLQuery As String
    Dim dt As DataTable
    Dim KodePengangkutan, NamaPengangkutan, NamaKendaraan, CustomerCode As String
    Dim PanjangKendaraan, LebarKendaraan, TinggiKendaraan As Double
    Dim dtCustomer As DataTable = GetDataTable("SELECT No_,Name FROM " & My.Settings.DatabasePv & ".[dbo].[PT Industri Pembungkus Intl_$Customer] WHERE NOT Name = '' AND NOT Name = '-'", Constr)
    Dim Panjang, Lebar, Tinggi As Double

    Public Function Action(DataRow As DataRow, ActionType As String) As Boolean Implements iclsList.Action
        Action = False
        If ActionType = cRefresh Then
            Action = True
            Exit Function
        End If
        If Not ActionType = cNew And IsNothing(DataRow) Then Exit Function
    End Function

    Public Function CallTypeList() As List(Of iclsCallType) Implements iclsList.CallTypeList
        Return template.RF
    End Function

    Public Function RefreshData() As DataTable Implements iclsList.RefreshData
        SQLQuery = "SELECT DISTINCT Sl.ID,
    ISNULL(REPLACE(SUBSTRING(PcsIkatan.Text, PATINDEX('%[0-9]%', PcsIkatan.Text), PATINDEX('%[0-9][^0-9]%', PcsIkatan.Text + 't') - PATINDEX('%[0-9]%', 
                    PcsIkatan.Text)+1 ),'',0),0) AS PcsIkatan,
    Sl.Description,
    Sh.[Bill-to Name] AS CustomerName,
    Sl.Quantity,
    CASE WHEN FLUTE.[Text] = '1002' THEN '0.6'
		WHEN FLUTE.[Text] = '0035' THEN '1.2'
		WHEN FLUTE.[Text] = '2032' THEN '1.4'
		WHEN FLUTE.[Text] = '0032' THEN '1.4'
		WHEN FLUTE.[Text] = '0002' THEN '0.6'
		WHEN FLUTE.[Text] = '3332' THEN 'C/C/B'
		WHEN FLUTE.[Text] = '0025' THEN '1.0'
		WHEN FLUTE.[Text] = '0005' THEN '0.4'
		WHEN FLUTE.[Text] = '0003' THEN '0.8'
		WHEN FLUTE.[Text] = '1003' THEN '0.8'
		WHEN FLUTE.[Text] = '1005' THEN '0.4'
		WHEN FLUTE.[Text] = '2025' THEN '1.0'
		WHEN FLUTE.[Text] = '2035' THEN '1.2' END AS Sloter,
    CASE WHEN FLUTE.[Text]  = '1002' THEN '0.9'
		WHEN FLUTE.[Text]  = '0035' THEN '1.9'
		WHEN FLUTE.[Text]  = '2032' THEN '2.2'
		WHEN FLUTE.[Text]  = '0032' THEN '2.2'
		WHEN FLUTE.[Text]  = '0002' THEN '0.9'
		WHEN FLUTE.[Text]  = '3332' THEN 'C/C/B'
		WHEN FLUTE.[Text]  = '0025' THEN '1.5'
		WHEN FLUTE.[Text]  = '0005' THEN '0.6'
		WHEN FLUTE.[Text]  = '0003' THEN '1.3'
		WHEN FLUTE.[Text]  = '1003' THEN '1.3'
		WHEN FLUTE.[Text]  = '1005' THEN '0.6'
		WHEN FLUTE.[Text]  = '2025' THEN '1.5'
		WHEN FLUTE.[Text]  = '2035' THEN '1.9' END AS Scorer,
    CAST(LEBAR.Text AS FLOAT) AS Lebar,
    PANJANG.Text AS Panjang,
    TINGGI.Text AS Tinggi,
    ((CAST(PANJANG.Text AS FLOAT) + CAST(LEBAR.Text AS FLOAT) + ISNULL(CASE CAST(FLUTE.[Text] AS FLOAT)
            WHEN '1002' THEN '0.6'
            WHEN '0035' THEN '1.2'
            WHEN '2032' THEN '1.4'
            WHEN '0032' THEN '1.4'
            WHEN '0002' THEN '0.6'
            WHEN '3332' THEN 'C/C/B'
            WHEN '0025' THEN '1.0'
            WHEN '0005' THEN '0.4'
            WHEN '0003' THEN '0.8'
            WHEN '1003' THEN '0.8'
            WHEN '1005' THEN '0.4'
            WHEN '2025' THEN '1.0'
            WHEN '2035' THEN '1.2'
        END, '')) * (CAST(LEBAR.Text AS FLOAT) + (CAST(TINGGI.Text AS FLOAT) + ISNULL(CASE CAST(FLUTE.[Text] AS FLOAT)
            WHEN '1002' THEN '0.9'
            WHEN '0035' THEN '1.9'
            WHEN '2032' THEN '2.2'
            WHEN '0032' THEN '2.2'
            WHEN '0002' THEN '0.9'
            WHEN '3332' THEN 'C/C/B'
            WHEN '0025' THEN '1.5'
            WHEN '0005' THEN '0.6'
            WHEN '0003' THEN '1.3'
            WHEN '1003' THEN '1.3'
            WHEN '1005' THEN '0.6'
            WHEN '2025' THEN '1.5'
            WHEN '2035' THEN '1.9'
        END, ''))) * (ISNULL(CASE CAST(FLUTE.[Text] AS FLOAT)
            WHEN '1002' THEN '0.6'
            WHEN '0035' THEN '1.2'
            WHEN '2032' THEN '1.4'
            WHEN '0032' THEN '1.4'
            WHEN '0002' THEN '0.6'
            WHEN '3332' THEN 'C/C/B'
            WHEN '0025' THEN '1.0'
            WHEN '0005' THEN '0.4'
            WHEN '0003' THEN '0.8'
            WHEN '1003' THEN '0.8'
            WHEN '1005' THEN '0.4'
            WHEN '2025' THEN '1.0'
            WHEN '2035' THEN '1.2'
        END, '')) * CAST(ISNULL(REPLACE(SUBSTRING(PcsIkatan.Text, PATINDEX('%[0-9]%', PcsIkatan.Text), PATINDEX('%[0-9][^0-9]%', PcsIkatan.Text + 't') - PATINDEX('%[0-9]%', PcsIkatan.Text) + 1), '', '0'), 0) AS FLOAT)) AS Total,
        CAST('' AS VARCHAR(200)) Kendaraan
  FROM
    IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$Sales Line] Sl
    LEFT JOIN IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$PV Userfield Field Value] LEBAR ON Sl.ID = LEBAR.ID1 AND LEBAR.[Field No_] = 43
    LEFT JOIN IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$PV Userfield Field Value] PANJANG ON Sl.ID = PANJANG.ID1 AND PANJANG.[Field No_] = 44
    LEFT JOIN IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$PV Userfield Field Value] TINGGI ON Sl.ID = TINGGI.ID1 AND TINGGI.[Field No_] = 45
    LEFT JOIN IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$PV Userfield Field Value] FLUTE ON Sl.ID = FLUTE.ID1 AND FLUTE.[Field No_] = 46
    LEFT JOIN IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$PV Userfield Field Value] PcsIkatan ON Sl.ID = PcsIkatan.ID1 AND PcsIkatan.[Field No_] = 115
    LEFT JOIN IPI_LIVE.dbo.[PT Industri Pembungkus Intl_$Sales Header] Sh ON Sl.[Sell-to Customer No_] = Sh.[Sell-to Customer No_] AND Sl.[Document No_] = Sh.No_
  WHERE
    Sl.[Requested Delivery Date] = '2023-09-15'
    AND Sl.[Shortcut Dimension 1 Code] = 'CB'
    AND Sl.ID > 0
    AND Sl.[Document Type] = 1"
        dt = GetDataTable(SQLQuery, PVConstr, 300)
        For Each Row In dt.Rows
            SQLQuery = ""
        Next

        Return dt
    End Function

    Public Function CustomFormat() As Dictionary(Of String, String) Implements iclsList.CustomFormat
        Return Nothing
    End Function

    Public Function ConditionalFormat() As Dictionary(Of String, FormatConditionRuleExpression) Implements iclsList.ConditionalFormat
        Return Nothing
    End Function

    Public Function ColumnNumToFreeze() As String Implements iclsList.ColumnNumToFreeze
        Return Nothing
    End Function

    Public Function AddonText() As String Implements iclsList.AddonText
        Return Nothing
    End Function

    Public Function SummaryColumn() As List(Of GridColumnSummaryItem) Implements iclsList.SummaryColumn
        Return Nothing
    End Function
End Class
