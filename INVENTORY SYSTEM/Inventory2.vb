Imports System.Data.SqlClient
Public Class Inventory2
#Region "Methods/Functions"
    Sub LoadCategory()
        Try
            cboCategory.Items.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblCategory", con)
            dr = cmd.ExecuteReader
            While dr.Read
                cboCategory.Items.Add(dr.Item("category"))
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
#End Region

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim id As Integer = txtID.Text
        Dim pname As String = txtProduct.Text
        Dim supp As String = txtSupp.Text
        Dim cbo As String = cboCategory.Text

        Dim query As String = "Insert into UserInfo values (@id, @pname, @supply, @category)"
        Using cmd As SqlCommand = New SqlCommand(query, con)
            opencon()
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@pname", pname)
            cmd.Parameters.AddWithValue("@supply", supp)
            cmd.Parameters.AddWithValue("@category", cbo)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Successfully added", vbInformation)
            txtID.Clear()
            txtProduct.Clear()
            txtSupp.Clear()
            cboCategory.SelectedIndex = -1
            DData()
        End Using
    End Sub

    Private Sub DData()
        Dim query As String = "select * from UserInfo"
        Using cmd As SqlCommand = New SqlCommand(query, con)
            opencon()
            Using da As New SqlDataAdapter()
                Using dt As New DataTable()
                    da.SelectCommand = cmd
                    da.Fill(dt)
                    DataGridView1.DataSource = dt

                End Using
            End Using
        End Using
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim query As String = "SELECT * FROM UserInfo where ID = '" & txtID.Text & "'"
        opencon()
        Using cmd As SqlCommand = New SqlCommand(query, con)
            Using da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Using dt As New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then

                        txtProduct.Text = dt.Rows(0)(1).ToString
                        txtSupp.Text = dt.Rows(0)(2).ToString
                        cboCategory.Text = dt.Rows(0)(3).ToString

                    Else
                        txtProduct.Text = ""
                        txtSupp.Text = ""


                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id As Integer = txtID.Text
        Dim pname As String = txtProduct.Text
        Dim supp As String = txtSupp.Text
        Dim cbo As String = cboCategory.Text

        Dim query As String = "update UserInfo set pname=@pname, supply=@supply, category=@category where ID = @id"
        Using cmd As SqlCommand = New SqlCommand(query, con)
            opencon()
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@pname", pname)
            cmd.Parameters.AddWithValue("@supply", supp)
            cmd.Parameters.AddWithValue("@category", cbo)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Successfully Update", vbInformation)
            DData()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim id As Integer = txtID.Text

        Dim query As String = "Delete UserInfo where ID = @id"
        Using cmd As SqlCommand = New SqlCommand(query, con)
            opencon()
            cmd.Parameters.AddWithValue("@id", id)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Successfully Delete", vbInformation)
            txtID.Clear()
            txtProduct.Clear()
            txtSupp.Clear()
            cboCategory.SelectedIndex = -1
            DData()
        End Using
    End Sub

    Private Sub Inventory2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DData()
    End Sub

    Private Sub cboCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCategory.KeyPress
        Select Case Asc(e.KeyChar)
            Case 8, 46, 48 To 57
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        Me.Dispose()
    End Sub
End Class