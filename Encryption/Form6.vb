Public Class Form6


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Me.Close()
    End Sub

    Private Sub LogInLabel3_Click_1(sender As Object, e As EventArgs) Handles LogInLabel3.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("http://www.iq-team.org/vb/")
    End Sub

    Private Sub LogInLabel1_Click_1(sender As Object, e As EventArgs) Handles LogInLabel1.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("https://www.facebook.com/mina.mazen2015")
    End Sub
End Class