Imports System.Data.SqlClient
Module Connection
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public da As New SqlDataAdapter
    Public id As String
    Public userN As String
    Public passW As String

    Sub opencon()
        con.ConnectionString = "Data Source=DESKTOP-BRTST2M;Initial Catalog=inventory1;Integrated Security=True"
    End Sub

    'Validation is_validation()
    Function is_validation(text As Object) As Boolean
        If text = String.Empty Then
            MsgBox("Required missing field!", vbExclamation)
            Return True
        Else
            Return False
        End If
    End Function
End Module
