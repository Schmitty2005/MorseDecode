
Public Class Form1

    Private Sub display_chr_Click(sender As Object, e As EventArgs) Handles display_chr.Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click


        About.Show()

    End Sub

    Private Sub exit_button_Click(sender As Object, e As EventArgs) Handles exit_button.Click
        Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()

    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub start_button_Click(sender As Object, e As EventArgs) Handles start_button.Click

        MorseDecode.Main()
        Dim morsestring = morsedict.Item("?")       ' retrives dah-dit sequence from dictionary
        display_test.Text = morsestring             'displays dah dit sequece in window for testing purposes
        display_chr.Text = Char.ToUpper("?")        'Displays upper case to main window





    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'a test routine for simplicity....
        PlayBeep(800, 500)
        PlayBeep(400, 500)
        PlayBeep(800, 1500)
    End Sub

    Private Sub display_test_Click(sender As Object, e As EventArgs) Handles display_test.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MorseDecode.PlayString("the Man was here")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'Dim player As New System.Media.SoundPlayer(mStrm)
        initializeSounds(25, 800)

        ditStream.Seek(0, IO.SeekOrigin.Begin)
        MorseDecode.player.Stream = ditStream

        'ditStream.Seek(0, SeekOrigin.begin)
        player.PlaySync()




        ''MorseDecode.player.PlaySync()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MorseDecode.PlayBeep(800, 800)
        For [crap] = 1 To 10000

        Next
        MorseDecode.PlayBeep(800, 250)
        For [crap] = 1 To 10000

        Next
        MorseDecode.PlayBeep(800, 250)





    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
