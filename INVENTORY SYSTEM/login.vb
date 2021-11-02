Imports System.Data.SqlClient
Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPass.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            txtPass.UseSystemPasswordChar = False
        Else
            txtPass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If is_validation(txtUsername.Text) = True Then Return
            If is_validation(txtPass.Text) = True Then Return
            Call opencon()
            Dim found As Boolean = False
            con.Open()
            cmd = New SqlCommand("select * from tblUser where username like '" & Trim(txtUsername.Text) & "' and password like '" & txtPass.Text & "'", con)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                id = dr.Item("id").ToString
                userN = dr.Item("username").ToString
                passW = dr.Item("password").ToString
                found = True
            End If
            dr.Close()
            con.Close()
            If found = True Then
                MsgBox("Welcome", vbInformation)
                Main.Show()

            Else
                MsgBox("Cannot find account in database!!", vbExclamation)
                txtUsername.Clear()
                txtPass.Clear()
                Return
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class