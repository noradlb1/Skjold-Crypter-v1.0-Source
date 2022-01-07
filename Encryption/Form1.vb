Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Array
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
    Dim stub As String = My.Resources.txt1



    Private Sub LogInButton1_Click(sender As Object, e As EventArgs) Handles LogInButton1.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Dim OpenFileDialog As New OpenFileDialog
        With OpenFileDialog
            .Title = "Select EXE File"
            .Filter = "Exe Files (*.exe)|*.exe"
            .ShowDialog()
        End With
        TextBox1.Text = OpenFileDialog.FileName


    End Sub

    Public Function ConvertFileToBase64(ByVal fileName As String) As String
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
    End Function

    Private Sub LogInButton2_Click(sender As Object, e As EventArgs) Handles LogInButton2.Click
        On Error Resume Next
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = RichTextBox1.Text.Replace(TextBox2.Text, TextBox3.Text)
        Form2.RichTextBox1.Text = Form2.RichTextBox1.Text & vbNewLine & TextBox2.Text & "  to  " & TextBox3.Text
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub LogInButton5_Click(sender As Object, e As EventArgs) Handles LogInButton5.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Form2.Show()
    End Sub

    Private Sub LogInButton7_Click(sender As Object, e As EventArgs) Handles LogInButton7.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Form6.Show()
    End Sub

    Private Sub LogInButton8_Click(sender As Object, e As EventArgs) Handles LogInButton8.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If LogInLabel6.Text = "0" Then
        Else
            TextBox5.Text = GenRandom(LogInLabel6.Text)
        End If

    End Sub
    Function GenRandom(ByVal Length As Integer)
        Dim Output As String = Nothing
        Dim UsedLetters As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        For i = 1 To Length
            Threading.Thread.Sleep(5)
            Dim Rnd As New Random(Now.Millisecond)
            Output &= UsedLetters(Rnd.Next(0, UsedLetters.Length))
        Next
        Return Output
    End Function

    Public Function TripleDES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim TripleDES As New System.Security.Cryptography.TripleDESCryptoServiceProvider
        Dim Hash_TripleDES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(23) As Byte
            Dim temp As Byte() = Hash_TripleDES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 8)
            TripleDES.Key = hash
            TripleDES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = TripleDES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function


    Private Sub LogInButton10_Click(sender As Object, e As EventArgs) Handles LogInButton10.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Form3.Show()
    End Sub

    Private Sub LogInButton6_Click(sender As Object, e As EventArgs) Handles LogInButton6.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Then
        Else

            Dim Brow1 As New FolderBrowserDialog
            Dim Brow2 As FolderBrowserDialog = Brow1
            If Brow2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim a As String = NumericUpDown1.Value
                Dim b As String = RichTextBox1.Text
                Dim c As String = b.Length
                Dim d As String = c / a
                Dim lll As String = 1
                For i As Integer = 0 To a
                    Dim split As String = Mid(b, lll, d)
                    IO.File.WriteAllText(Brow2.SelectedPath & "\pit" & i & ".txt", split)
                    lll += +CInt(d)
                Next
                MsgBox("Done !! ")
            End If
        End If
    End Sub

   


    Public Shared Function GZip(ByVal byte_0 As Byte()) As Byte()
        Using stream As MemoryStream = New MemoryStream
            Using stream2 As GZipStream = New GZipStream(stream, CompressionMode.Compress)
                stream2.Write(byte_0, 0, byte_0.Length)
                stream2.Close()
                byte_0 = New Byte(((((stream.ToArray.Length - 1) + 1) - 1) + 1) - 1) {}
                byte_0 = stream.ToArray
            End Using
            stream.Close()
        End Using
        Return byte_0
    End Function
    Public Shared Function RNG(ByVal byte_0 As Byte()) As Byte()
        Dim provider As New RNGCryptoServiceProvider
        Dim data As Byte() = New Byte(&H20 - 1) {}
        Dim dst As Byte() = New Byte(((((&H20 + (byte_0.Length - 1)) + 1) - 1) + 1) - 1) {}
        provider.GetBytes(data)
        Buffer.BlockCopy(data, 0, dst, 0, &H20)
        Buffer.BlockCopy(byte_0, 0, dst, &H20, byte_0.Length)
        Dim num2 As Integer = (dst.Length - 1)
        Dim i As Integer = &H20
        Do While (i <= num2)
            dst(i) = CByte((dst(i) Xor data((i Mod data.Length))))
            i += 1
        Loop
        Return dst
    End Function

    Private Sub LogInButton13_Click(sender As Object, e As EventArgs) Handles LogInButton13.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        TextBox3.Text = GenRandom1(1)
    End Sub

    Function GenRandom1(ByVal Length As Integer)
        Dim Output As String = Nothing
        Dim UsedLetters As String = " ❤•★♫✌☠™ℬ✿❁ℰ♛♡ℋ♪ℴℯ♕☣✧Ⓞ♬✩ℓ☾♚♔Ⓜ☮Ⓝ☢❤†✈ℕ☛➳☪〗ᴬ♥☞☺❃✪「✔✰ℂ卍☯》✞Å⋆☼━➤ℭ☆『ϟ⇝ℊⒸ☽✾❥☪©ⓘ✦』ℙ✽►☚✯☁✝☀†㋡♠✖☹❖✠♞K➊☭❊〕ℌ☂☮✌℧☻➽☯✯♋"
        For i = 1 To Length
            Threading.Thread.Sleep(5)
            Dim Rnd As New Random(Now.Millisecond)
            Output &= UsedLetters(Rnd.Next(0, UsedLetters.Length))
        Next
        Return Output
    End Function
    Function GenRandom2(ByVal Length As Integer)
        Dim Output As String = Nothing
        Dim UsedLetters As String = "~!@#$%^&*()_+|/-+÷×؛<>,.?"
        For i = 1 To Length
            Threading.Thread.Sleep(5)
            Dim Rnd As New Random(Now.Millisecond)
            Output &= UsedLetters(Rnd.Next(0, UsedLetters.Length))
        Next
        Return Output
    End Function

    Private Sub LogInButton14_Click(sender As Object, e As EventArgs) Handles LogInButton14.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Form4.Show()
    End Sub

    Private Sub LogInButton4_Click(sender As Object, e As EventArgs) Handles LogInButton4.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        Form7.Show()
    End Sub

    Private Sub LogInButton16_Click(sender As Object, e As EventArgs) Handles LogInButton16.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        TextBox3.Text = GenRandom2(1)
    End Sub

    Private Sub LogInButton18_Click(sender As Object, e As EventArgs) Handles LogInButton18.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.SelectAll()
        RichTextBox1.Copy()

        MsgBox("Done !!")
    End Sub

    Private Sub LogInButton20_Click(sender As Object, e As EventArgs) Handles LogInButton20.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.Gzip
    End Sub

    Private Sub LogInButton21_Click(sender As Object, e As EventArgs) Handles LogInButton21.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.md5
    End Sub

    Private Sub LogInButton22_Click(sender As Object, e As EventArgs) Handles LogInButton22.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.bas64
    End Sub

    Private Sub LogInButton19_Click(sender As Object, e As EventArgs) Handles LogInButton19.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.vgr
    End Sub

    Public Shared Function Encryptvg(ByVal proj As String, ByVal key As String)
        Dim mina As String = ""
        For i As Integer = 1 To proj.Length
            Dim temp As Integer = AscW(GetChar(proj, i)) + AscW(GetChar(key, i Mod key.Length + 1))
            mina += ChrW(temp)
        Next
        Return mina
    End Function

    Public Function TripleDES_Encrypt1(ByVal input As String, ByVal pass As String) As String
        Dim TripleDES As New System.Security.Cryptography.TripleDESCryptoServiceProvider
        Dim Hash_TripleDES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(23) As Byte
            Dim temp As Byte() = Hash_TripleDES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 8)
            TripleDES.Key = hash
            TripleDES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = TripleDES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function

   


    Private Sub LogInButton23_Click(sender As Object, e As EventArgs) Handles LogInButton23.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.trydel
    End Sub

    Private Sub LogInButton24_Click(sender As Object, e As EventArgs) Handles LogInButton24.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.trvg1
    End Sub

    Public Shared Function Rijndaelcrypt(ByVal File As String, ByVal Key As String)
        Dim oAesProvider As New RijndaelManaged
        Dim btClear() As Byte
        Dim btSalt() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
        Dim oKeyGenerator As New Rfc2898DeriveBytes(Key, btSalt)
        oAesProvider.Key = oKeyGenerator.GetBytes(oAesProvider.Key.Length)
        oAesProvider.IV = oKeyGenerator.GetBytes(oAesProvider.IV.Length)
        Dim ms As New IO.MemoryStream
        Dim cs As New CryptoStream(ms, _
          oAesProvider.CreateEncryptor(), _
          CryptoStreamMode.Write)
        btClear = System.Text.Encoding.UTF8.GetBytes(File)
        cs.Write(btClear, 0, btClear.Length)
        cs.Close()
        File = Convert.ToBase64String(ms.ToArray)
        Return File
    End Function

    Public Function LORDEncrypt(ByVal ParmEnc As String)
        ParmEnc = ParmEnc.Replace("a", "月").Replace("A", "아").Replace("b", "官").Replace("B", "악").Replace("c", "匹").Replace("C", "안").Replace("d", "力").Replace("D", "알").Replace("e", "三").Replace("E", "앙").Replace("f", "下").Replace("F", "앞").Replace("g", "巨").Replace("G", "얘").Replace("h", "升").Replace("H", "ᄍ").Replace("i", "工").Replace("I", "ᄊ").Replace("j", "丁").Replace("J", "ᄈ").Replace("k", "水").Replace("K", "응").Replace("l", "心").Replace("L", "읍").Replace("m", "冊").Replace("M", "음").Replace("n", "內").Replace("N", "을").Replace("o", "口").Replace("O", "임").Replace("p", "戶").Replace("P", "잎").Replace("q", "已").Replace("Q", "율").Replace("r", "尺").Replace("R", "월").Replace("s", "弓").Replace("S", "원").Replace("t", "七").Replace("T", "웅").Replace("u", "臼").Replace("U", "울").Replace("v", "人").Replace("V", "운").Replace("w", "山").Replace("W", "옴").Replace("x", "父").Replace("X", "왕").Replace("y", "了").Replace("Y", "왜").Replace("z", "乙").Replace("Z", "에")
        Return ParmEnc
    End Function
    Function GenRandom3(ByVal Length As Integer)
        Dim Output As String = Nothing
        Dim UsedLetters As String = "에乙왜了왕父옴山운人울臼웅七원弓월尺율已잎戶임口을內음冊읍心응水ᄈ丁ᄊ工ᄍ升얘巨앞下앙三알力안匹악官아月"
        For i = 1 To Length
            Threading.Thread.Sleep(5)
            Dim Rnd As New Random(Now.Millisecond)
            Output &= UsedLetters(Rnd.Next(0, UsedLetters.Length))
        Next
        Return Output
    End Function

    Private Sub LogInButton27_Click(sender As Object, e As EventArgs) Handles LogInButton27.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            RichTextBox1.Text = ConvertFileToBase64(TextBox1.Text)
            RichTextBox1.Text = LORDEncrypt(RichTextBox1.Text)
            MsgBox("Done !! ")
        End If

    End Sub



    Private Sub LogInButton17_Click_2(sender As Object, e As EventArgs) Handles LogInButton17.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Text = My.Resources.Jp2
    End Sub

    Private Sub LogInButton9_Click_1(sender As Object, e As EventArgs) Handles LogInButton9.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Or TextBox5.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            Dim xx As Byte() = IO.File.ReadAllBytes(TextBox1.Text)
            Dim v As String = Convert.ToBase64String(xx)
            Dim vv As String = TripleDES_Encrypt(v, TextBox5.Text)
            RichTextBox1.Text = vv
            MsgBox("Done !!")
        End If
    End Sub

    Private Sub LogInButton11_Click_1(sender As Object, e As EventArgs) Handles LogInButton11.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            RichTextBox1.Text = Convert.ToBase64String(Form1.GZip(IO.File.ReadAllBytes(TextBox1.Text)))
            MsgBox("Done !! ")
        End If
    End Sub

    Private Sub LogInButton26_Click_1(sender As Object, e As EventArgs) Handles LogInButton26.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Or TextBox5.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            RichTextBox1.Text = ConvertFileToBase64(TextBox1.Text)
            RichTextBox1.Text = TripleDES_Encrypt(RichTextBox1.Text, TextBox5.Text)
            MsgBox("Done !! ")
        End If
    End Sub

    Private Sub LogInButton25_Click_1(sender As Object, e As EventArgs) Handles LogInButton25.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Or TextBox5.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            RichTextBox1.Text = ConvertFileToBase64(TextBox1.Text)
            RichTextBox1.Text = Rijndaelcrypt(RichTextBox1.Text, TextBox5.Text)
            MsgBox("Done !! ")
        End If
    End Sub

    Private Sub LogInButton12_Click_1(sender As Object, e As EventArgs) Handles LogInButton12.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Or TextBox5.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            RichTextBox1.Text = ConvertFileToBase64(TextBox1.Text)
            RichTextBox1.Text = Encryptvg(RichTextBox1.Text, TextBox5.Text)
            MsgBox("Done !! ")
        End If
    End Sub

    Private Sub LogInButton3_Click_1(sender As Object, e As EventArgs) Handles LogInButton3.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If TextBox1.Text = "" Then
            RichTextBox1.Text = "Erorr"
        Else
            RichTextBox1.Text = ConvertFileToBase64(TextBox1.Text)
            MsgBox("Done !! ")
        End If
    End Sub

    Private Sub LogInButton15_Click_1(sender As Object, e As EventArgs) Handles LogInButton15.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        RichTextBox1.Clear()
    End Sub

    Private Sub FlatTrackBar1_Scroll(sender As Object) Handles FlatTrackBar1.Scroll
        LogInLabel6.Text = FlatTrackBar1.Value
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
    End Sub

    Private Sub LogInButton28_Click(sender As Object, e As EventArgs) Handles LogInButton28.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
        If LogInLabel6.Text = "0" Then
        Else
            TextBox5.Text = GenRandom3(LogInLabel6.Text)
        End If
    End Sub

    Private Sub NumericUpDown1_Click(sender As Object, e As EventArgs) Handles NumericUpDown1.Click
        My.Computer.Audio.Play(My.Resources.click_one, AudioPlayMode.Background)
    End Sub
End Class
