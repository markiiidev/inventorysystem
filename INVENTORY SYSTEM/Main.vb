Public Class Main

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Category
            .TopLevel = False
            MainPanel.Controls.Add(Category)
            .loadcategory()
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Inventory2
            .TopLevel = False
            MainPanel.Controls.Add(Inventory2)
            .LoadCategory()
            .BringToFront()
            .Show()
        End With
    End Sub
End Class