Public Class Form2

 

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Me.Hide()
    End Sub
End Class