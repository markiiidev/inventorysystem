Imports System.Data.SqlClient
Public Class Category
#Region "Load Data"
    'For category
    Sub loadcategory()
        Try
            DataGridView1.Rows.Clear()
            Dim i As Integer
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblCategory", con)
            dr = cmd.ExecuteReader
            While dr.Read
                i += 1
                DataGridView1.Rows.Add(i, dr.Item("category").ToString)
                DataGridView1.ClearSelection()
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
#End Region
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try

            If is_validation(txtCategory.Text) = True Then Return
            If MsgBox("Do you want Save this Category?", vbQuestion + vbYesNo) = vbYes Then
                con.Open()
                cmd = New SqlCommand("INSERT INTO tblCategory VALUES (@category)", con)
                cmd.Parameters.AddWithValue("@category", Trim(txtCategory.Text))
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Category has been Saved......", vbInformation)
                txtCategory.Clear()
                loadcategory()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            con.Close()
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            If is_validation(txtCategory.Text) = True Then Return
            If MsgBox("Do you want Update this Category?", vbQuestion + vbYesNo) = vbYes Then
                con.Open()
                cmd = New SqlCommand("UPDATE tblCategory set category=@category where category like '" & id & "'", con)
                cmd.Parameters.AddWithValue("@category", Trim(txtCategory.Text))
                cmd.ExecuteNonQuery()
                con.Close()
                btncancel.PerformClick()
                loadcategory()
                MsgBox("Category books has been Update!", vbInformation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            con.Close()
        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtCategory.Clear()
        Guna2Button1.Enabled = True
        Guna2Button2.Enabled = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Dim colname As String = DataGridView1.Columns(e.ColumnIndex).Name
            If colname = "colEdit" Then
                Guna2Button1.Enabled = False
                Guna2Button2.Enabled = True
                txtCategory.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                id = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            ElseIf colname = "colDelete" Then
                If MsgBox("Delete this record?", vbQuestion + vbYesNo) = vbYes Then
                    con.Open()
                    cmd = New SqlCommand("DELETE from tblCategory where category like '" & DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Record has been delete...", vbInformation)
                    btncancel.PerformClick()
                    loadcategory()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            con.Close()
        End Try
    End Sub

    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click

        Me.Dispose()
    End Sub
End Class