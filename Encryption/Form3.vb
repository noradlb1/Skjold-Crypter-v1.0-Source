Public Class Form3



    Private Sub LogInButton2_Click_1(sender As Object, e As EventArgs) Handles LogInButton2.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox2.Text.Contains("http") Then

            Dim url As String = My.Resources.url
            url = url.Replace("minaurl", TextBox2.Text)
            RichTextBox2.Text = url
            MsgBox("done")
        Else
            MsgBox("Erorr URL")
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Me.Close()
    End Sub

    Private Sub LogInButton18_Click(sender As Object, e As EventArgs) Handles LogInButton18.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox2.SelectAll()
        RichTextBox2.Copy()
        MsgBox("Done !!")
    End Sub
End Class