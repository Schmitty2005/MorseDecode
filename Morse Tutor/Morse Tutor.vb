
Public Class Form1

    Private Sub display_chr_Click(sender As Object, e As EventArgs) Handles display_chr.Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click


        About.Show()

    End Sub

    Private Sub exit_button_Click(sender As Object, e As EventArgs) Handles exit_button.Click
        'clean up!
        player.Stop()
        player.Dispose()
        On Error Resume Next

        ditStream.Dispose()
        dahStream.Dispose()
        wrdSpace.Dispose()
        ltrSpace.Dispose()
        interSpace.Dispose()

        On Error Resume Next



        'and exit

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        'a test routine for simplicity....
        PlayBeep(800, 500)
        PlayBeep(400, 500)
        PlayBeep(800, 1500)
    End Sub

    Private Sub display_test_Click(sender As Object, e As EventArgs) Handles display_test.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        initializeSounds(12, 441, True, 12)
        MorseDecode.PlayString("5 0 e t a r q c d")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Call initializeSounds routine to set up waveforms for playback
        initializeSounds(23, 600)

        'set stream to beginning
        ditStream.Seek(0, IO.SeekOrigin.Begin)
        MorseDecode.player.Stream = ditStream
        'Play stream
        player.PlaySync()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MorseDecode.PlayBeep(800, 800)

        For [crap] = 1 To 10000
            'pause timer
        Next
        'play beep
        MorseDecode.PlayBeep(800, 250)

        For [crap] = 1 To 10000
            'pause timer
        Next

        MorseDecode.PlayBeep(800, 250)





    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        initializeSounds(7, 600)
        'wave_out.DataSource = ditStream
        'wave_out.Update()
        

        For [step] = 1 To 5
            playDit()
            Application.DoEvents()

        Next
        For [step] = 1 To 5
            playLtrSpc()
            Application.DoEvents()

        Next

        For [step] = 1 To 5
            playDah()
            Application.DoEvents()

        Next
        For [step] = 1 To 5
            playWrdSpc()
            Application.DoEvents()
        Next
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dahStream.Seek(0, IO.SeekOrigin.Begin)
        write_stream(MorseDecode.ditStream)
    End Sub
End Class
