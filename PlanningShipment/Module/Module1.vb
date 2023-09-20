Imports CHR.Common
Module Module1
    Public User As String
    Public Status As String
    Public Mode As Integer

    Public Constr As String = GetConnectionString(My.Settings.Server, My.Settings.DatabaseCustom, My.Settings.AppID, False, "sa", "ipiserver!234")
    Public PVConstr As String = GetConnectionString(My.Settings.Server, My.Settings.DatabasePv, My.Settings.AppID, False, "sa", "ipiserver!234")



End Module
