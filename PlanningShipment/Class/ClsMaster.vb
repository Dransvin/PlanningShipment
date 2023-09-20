Imports CHR.Common
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Public Class ClsMaster
    Implements iclsList
    Dim ModeForm As Integer = Mode
    Dim template As New TemplateControl
    Dim SQLQuery As String
    Dim dt As DataTable
    Dim KodePengangkutan, NamaPengangkutan, NamaKendaraan, CustomerCode As String
    Dim PanjangKendaraan, LebarKendaraan, TinggiKendaraan As Double
    '  Dim dtItemNo As DataTable = GetDataTable("SELECT No_,Description from " & My.Settings.DatabasePv & ".[dbo].[PT Industri Pembungkus Intl_$Item] WHERE No_ LIKE '%CBFG%' AND Blocked = 0 AND [Product Group Code] = 'FG' AND [Item Type Code] = 'FINISHED-GOODS'", Constr)
    Dim dtCustomer As DataTable = GetDataTable("SELECT No_,Name FROM " & My.Settings.DatabasePv & ".[dbo].[PT Industri Pembungkus Intl_$Customer] WHERE NOT Name = '' AND NOT Name = '-'", Constr)
    Dim Panjang, Lebar, Tinggi As Double


    Public Function Action(DataRow As DataRow, ActionType As String) As Boolean Implements iclsList.Action
        Action = False
        If ActionType = cRefresh Then
            Action = True
            Exit Function
        End If
        If Not ActionType = cNew And IsNothing(DataRow) Then Exit Function

        If ActionType = cNew Or ActionType = cEdit Or ActionType = cView Or ActionType = cDelete Then
            Dim l_Dt As DataTable = Nothing
            Dim l_schema As DataTable = Nothing
            Dim l As New List(Of Object)
            Dim QueryViewDelete As String = Nothing

            If ModeForm = 0 Then
                SQLQuery = "SELECT CAST('' AS INT) EntryNo,CAST('' AS VARCHAR(50)) KodePengangkutan, CAST('' AS VARCHAR(200)) NamaPengangkutan"
                QueryViewDelete = "Select EntryNo,KodePengangkutan,NamaPengangkutan from Sys_MasterPengangkutan"
            ElseIf ModeForm = 1 Then
                SQLQuery = "SELECT CAST('' AS INT) EntryNo,CAST('' AS VARCHAR(50)) KodePengangkutan, CAST('' AS VARCHAR(200)) NamaKendaraan,CAST(0 AS FLOAT)PanjangKendaraan,CAST(0 AS FLOAT)LebarKendaraan,CAST(0 AS FLOAT)TinggiKendaraan"
                QueryViewDelete = "SELECT EntryNo,KodePengangkutan,NamaKendaraan,PanjangKendaraan,LebarKendaraan,TinggiKendaraan FROM Sys_MasterKendaraanPengangkutan"
            ElseIf ModeForm = 2 Then
                SQLQuery = "SELECT CAST('' AS INT) EntryNo,CAST('' AS VARCHAR(200)) CustomerCode,CAST(0 AS FLOAT)Panjang,CAST(0 AS FLOAT)Lebar,CAST(0 AS FLOAT)Tinggi"
                QueryViewDelete = "SELECT EntryNo,CustomerCode,Panjang,Lebar,Tinggi From Sys_MasterPallet"
            End If

            If ActionType = cView Or ActionType = cDelete Then
                l_Dt = dt.Copy
                l_schema = GetDataTable(QueryViewDelete, Constr, SchemaOnly:=True)
            Else
                l_Dt = GetDataTable(SQLQuery, Constr)
                l_schema = GetDataTable(SQLQuery, Constr, SchemaOnly:=True)
            End If
            l_Dt.Clear()
            If ActionType = cNew Then
                l_Dt.Rows.Add()
                l_Dt.Rows(0).Item("EntryNo") = "0"
            Else
                l_Dt.ImportRow(DataRow)
            End If


            l.Add(New clsCommonDetailItem With {.RowName = "EntryNo",
            .RowFriendlyName = "Entry No",
            .RowDescription = "Entry No",
            .AllowNull = True,
            .IsReadOnly = True,
            .IsVisible = If(ActionType = cNew, False, True),
            .AllowTrimEmptyString = True})

            If ModeForm = 0 Then
                l.Add(New clsCommonDetailItem With {.RowName = "KodePengangkutan",
            .RowFriendlyName = "Kode Pengangkutan",
            .RowDescription = "Kode Pengangkutan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem With {.RowName = "NamaPengangkutan",
            .RowFriendlyName = "Nama Pengangkutan",
            .RowDescription = "Nama Pengangkutan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})
            ElseIf ModeForm = 1 Then

                l.Add(New clsCommonDetailItem_LookupEdit With {.RowName = "KodePengangkutan",
            .RowFriendlyName = "Kode Pengangkutan",
            .RowDescription = "Kode Pengangkutan",
            .ValueMember = "KodePengangkutan",
            .DisplayMember = "KodePengangkutan",
            .SqlQuery = "SELECT DISTINCT KodePengangkutan,NamaPengangkutan From Sys_MasterPengangkutan",
            .ConnectionString = Constr,
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem With {.RowName = "NamaKendaraan",
            .RowFriendlyName = "Nama Kendaraan",
            .RowDescription = "Nama Kendaraan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_SpinEdit With {.RowName = "PanjangKendaraan",
            .RowFriendlyName = "Panjang Kendaraan",
            .RowDescription = "Panjang tempat muat kendaraan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_SpinEdit With {.RowName = "LebarKendaraan",
            .RowFriendlyName = "Lebar Kendaraan",
            .RowDescription = "Lebar tempat muat kendaraan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_SpinEdit With {.RowName = "TinggiKendaraan",
            .RowFriendlyName = "Tinggi Kendaraan",
            .RowDescription = "Tinggi tempat muat kendaraan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

            ElseIf ModeForm = 2 Then

                '     l.Add(New clsCommonDetailItem_LookupEdit With {.RowName = "ItemNo",
                '.RowFriendlyName = "Item No",
                '.DataSource = dtItemNo,
                '.ValueMember = "No_",
                '.DisplayMember = "No_",
                '.RowDescription = "Item No",
                '.AllowNull = True,
                '.AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_LookupEdit With {.RowName = "CustomerCode",
           .RowFriendlyName = "Customer Code",
           .DataSource = dtCustomer,
           .DisplayMember = "No_",
           .ValueMember = "No_",
           .RowDescription = "Customer Code",
           .AllowNull = True,
           .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_SpinEdit With {.RowName = "Panjang",
            .RowFriendlyName = "Panjang Pallet",
            .RowDescription = "Panjang ukuran pallet",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_SpinEdit With {.RowName = "Lebar",
            .RowFriendlyName = "Lebar Pallet",
            .RowDescription = "Lebar ukuran pallet",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

                l.Add(New clsCommonDetailItem_SpinEdit With {.RowName = "Tinggi",
            .RowFriendlyName = "Tinggi Pallet",
            .RowDescription = "Tinggi ukuran pallet",
            .AllowNull = True,
            .AllowTrimEmptyString = True})
            End If

            Dim f As New frmCommonDetail With {.Text = ActionType,
                                         .DataSource = l_Dt,
                                         .Schema = l_schema,
                                         .ListCustomItem = l,
                                         .ButtonSaveText = If(ActionType = cNew Or ActionType = cEdit, "save", "delete"),
                                         .IsForView = ActionType = cView,
                                         .IsForDelete = ActionType = cDelete}

            Dim dialogresult As DialogResult = Nothing
            Try
                Do
                    dialogresult = f.ShowDialog
                    If dialogresult = DialogResult.OK Then
                        Action = Save(f.Result, ActionType)
                    End If
                Loop Until Action Or Not dialogresult
            Catch ex As Exception
                mbError(ex.ToString)
            End Try
            f.Dispose()
        End If
    End Function


    Private Sub ReadData(ByVal DataRow As DataRow)
        With DataRow
            If ModeForm = 0 Then
                KodePengangkutan = IsNulls(DataRow.Item("KodePengangkutan"), "")
                NamaPengangkutan = IsNulls(DataRow.Item("NamaPengangkutan"), "")
            ElseIf ModeForm = 1 Then
                KodePengangkutan = IsNulls(DataRow.Item("KodePengangkutan"), "")
                NamaKendaraan = IsNulls(DataRow.Item("NamaKendaraan"), "")
                PanjangKendaraan = IsNulls(DataRow.Item("PanjangKendaraan"), "0")
                LebarKendaraan = IsNulls(DataRow.Item("LebarKendaraan"), "0")
                TinggiKendaraan = IsNulls(DataRow.Item("TinggiKendaraan"), "0")
            ElseIf ModeForm = 2 Then
                CustomerCode = IsNulls(DataRow.Item("CustomerCode"), "")
                Panjang = IsNulls(DataRow.Item("Panjang"), "0")
                Lebar = IsNulls(DataRow.Item("Lebar"), "0")
                Tinggi = IsNulls(DataRow.Item("Tinggi"), "0")
            End If
        End With
    End Sub


    Public Function isValid(ByVal DataRow As DataRow, ActionType As String) As Boolean
        isValid = False
        If ActionType = cNew Or ActionType = cEdit Then
            If ModeForm = 0 Then
                If KodePengangkutan = "" Then
                    mbInfo("Kode Pengangkutan masih kosong")
                    Throw New Exception("")
                End If
                If NamaPengangkutan = "" Then
                    mbInfo("Nama Pengangkutan masih kosong")
                    Throw New Exception("")
                End If
            ElseIf ModeForm = 1 Then
                If KodePengangkutan = "" Or NamaKendaraan = "" Then
                    mbInfo("Masih ada data yang kosong")
                    Throw New Exception("")
                End If
            ElseIf ModeForm = 2 Then
                If Panjang = 0 Or Lebar = 0 And Tinggi = 0 Then
                    mbInfo("Masih ada data yang kosong")
                    Throw New Exception("")
                End If
            End If
        End If
        isValid = True
    End Function


    Public Function Save(DataRow As DataRow, ActionType As String) As Boolean
        Save = False
        Dim oConn As SqlConnection = Nothing
        Dim oCmd As SqlCommand
        ReadData(DataRow)
        Dim Lanjut As Boolean = isValid(DataRow, ActionType)

        Dim Luas As Double = 0
        If Lanjut = True Then
            Try
                oConn = New SqlConnection(Constr)
                oConn.Open()
                If ActionType = cNew Then
                    If ModeForm = 0 Then
                        SQLQuery = "DECLARE @Entry as INT
                SET @Entry = (SELECT ISNULL(MAX(EntryNo),0)+1 from Sys_MasterPengangkutan)
                INSERT INTO Sys_MasterPengangkutan (EntryNo,KodePengangkutan,NamaPengangkutan)
                VALUES (@Entry," & StrSQL(KodePengangkutan) & "," & StrSQL(NamaPengangkutan) & ")"
                    ElseIf ModeForm = 1 Then
                        Luas = PanjangKendaraan * LebarKendaraan * TinggiKendaraan
                        Luas = Luas * 88 / 100
                        SQLQuery = "DECLARE @Entry as INT
                SET @Entry = (SELECT ISNULL(MAX(EntryNo),0)+1 from Sys_MasterKendaraanPengangkutan)
                INSERT INTO Sys_MasterKendaraanPengangkutan (EntryNo,KodePengangkutan,NamaKendaraan,PanjangKendaraan,LebarKendaraan,TinggiKendaraan,Luas)
                VALUES (@Entry," & StrSQL(KodePengangkutan) & "," & StrSQL(NamaKendaraan) & "," & StrSQL(PanjangKendaraan) & "," & StrSQL(LebarKendaraan) & "," & StrSQL(TinggiKendaraan) & "," & StrSQL(Luas) & ")"
                    ElseIf ModeForm = 2 Then
                        SQLQuery = "DECLARE @Entry as INT
                SET @Entry = (SELECT ISNULL(MAX(EntryNo),0)+1 from Sys_MasterPallet)
                INSERT INTO Sys_MasterPallet(EntryNo,CustomerCode,Panjang,Lebar,Tinggi)
                VALUES (@Entry," & StrSQL(CustomerCode) & "," & StrSQL(Panjang) & "," & StrSQL(Lebar) & "," & StrSQL(Tinggi) & ")"
                    End If
                ElseIf ActionType = cEdit Then
                    If ModeForm = 0 Then
                        SQLQuery = "UPDATE Sys_MasterPengangkutan SET KodePengangkutan =" & StrSQL(KodePengangkutan) & ",NamaPengangkutan =" & StrSQL(NamaPengangkutan) & " Where EntryNo = " & DataRow.Item("EntryNo")
                    ElseIf ModeForm = 1 Then
                        Luas = PanjangKendaraan * LebarKendaraan * TinggiKendaraan
                        Luas = Luas * 88 / 100
                        SQLQuery = "UPDATE Sys_MasterKendaraanPengangkutan SET KodePengangkutan =" & StrSQL(KodePengangkutan) & ",NamaKendaraan =" & StrSQL(NamaKendaraan) & ",PanjangKendaraan =" & StrSQL(PanjangKendaraan) &
                        ",LebarKendaraan =" & StrSQL(LebarKendaraan) & ",TinggiKendaraan =" & StrSQL(TinggiKendaraan) & ",Luas =" & StrSQL(Luas) & " Where EntryNo = " & DataRow.Item("EntryNo")
                    ElseIf ModeForm = 2 Then
                        SQLQuery = "UPDATE Sys_MasterPallet SET CustomerCode =" & StrSQL(CustomerCode) & ", Panjang = " & StrSQL(Panjang) & ", Lebar =" & StrSQL(Lebar) & ", Tinggi =" & StrSQL(Tinggi) & " Where EntryNo =" & DataRow.Item("EntryNo")
                    End If
                ElseIf ActionType = cDelete Then
                    If ModeForm = 0 Then
                        SQLQuery = "DELETE FROM Sys_MasterPengangkutan Where EntryNo =" & DataRow.Item("EntryNo")
                    ElseIf ModeForm = 1 Then
                        SQLQuery = "DELETE FROM Sys_MasterKendaraanPengangkutan Where EntryNo =" & DataRow.Item("EntryNo")
                    ElseIf ModeForm = 2 Then
                        SQLQuery = "DELETE FROM Sys_MasterPallet Where EntryNo =" & DataRow.Item("EntryNo")
                    End If
                End If
                oCmd = New SqlCommand(SQLQuery, oConn)
                oCmd.ExecuteNonQuery()
            Catch es As SqlException
                Throw es
            Catch ex As Exception
                Throw ex
            Finally
                If oConn.State <> ConnectionState.Closed Then oConn.Close()
                oConn.Dispose()
            End Try
        End If
        mbInfo("Action Success")
        Save = True
    End Function

    Public Function AddonText() As String Implements iclsList.AddonText
        Return Nothing
    End Function

    Public Function CallTypeList() As List(Of iclsCallType) Implements iclsList.CallTypeList
        Return template.CRUD
    End Function

    Public Function ColumnNumToFreeze() As String Implements iclsList.ColumnNumToFreeze
        Return Nothing
    End Function

    Public Function ConditionalFormat() As Dictionary(Of String, FormatConditionRuleExpression) Implements iclsList.ConditionalFormat
        Return Nothing
    End Function

    Public Function CustomFormat() As Dictionary(Of String, String) Implements iclsList.CustomFormat
        Return Nothing
    End Function

    Public Function RefreshData() As DataTable Implements iclsList.RefreshData
        If ModeForm = 0 Then
            'Master Pengangkutan
            SQLQuery = "Select EntryNo,KodePengangkutan,NamaPengangkutan from Sys_MasterPengangkutan ORDER BY EntryNo DESC"
        ElseIf ModeForm = 1 Then
            SQLQuery = "SELECT EntryNo,KodePengangkutan,NamaKendaraan,PanjangKendaraan,LebarKendaraan,TinggiKendaraan FROM Sys_MasterKendaraanPengangkutan ORDER BY EntryNo DESC"
        ElseIf ModeForm = 2 Then
            SQLQuery = "SELECT EntryNo,CustomerCode,Cus.Name,Panjang,Lebar,Tinggi From Sys_MasterPallet
                        LEFT JOIN " & My.Settings.DatabasePv & ".[dbo].[PT Industri Pembungkus Intl_$Customer] Cus on Cus.[No_] COLLATE database_default  = CustomerCode
                        ORDER BY EntryNo DESC"
        End If
        dt = GetDataTable(SQLQuery, Constr)
        Return dt
    End Function

    Public Function SummaryColumn() As List(Of DevExpress.XtraGrid.GridColumnSummaryItem) Implements iclsList.SummaryColumn
        Return Nothing
    End Function

End Class
