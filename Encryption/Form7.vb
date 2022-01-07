Public Class Form7

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Me.Close()
    End Sub

    Private Sub LogInLabel1_Click(sender As Object, e As EventArgs) Handles LogInLabel1.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("http://www.refud.me/scan.php")
    End Sub

    Private Sub LogInLabel2_Click(sender As Object, e As EventArgs) Handles LogInLabel2.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("http://nodistribute.com/")
    End Sub

    Private Sub LogInLabel3_Click(sender As Object, e As EventArgs) Handles LogInLabel3.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("https://hellzone.xyz/Scanner.php")
    End Sub

    Private Sub LogInLabel7_Click(sender As Object, e As EventArgs) Handles LogInLabel7.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("http://rghost.net/")
    End Sub

    Private Sub LogInLabel6_Click(sender As Object, e As EventArgs) Handles LogInLabel6.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("http://www.exeupp.com/")
    End Sub
    Private Sub LogInLabel8_Click(sender As Object, e As EventArgs) Handles LogInLabel8.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Process.Start("https://userscloud.com")
    End Sub
End Class