
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
        initializeSounds(40, 600, True, 15)
        MorseDecode.PlayString("n7wdk test k7frt")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' Call initializeSounds routine to set up waveforms for playback
        initializeSounds(23, 600)

        'set stream to beginning
        ditStream.Seek(0, IO.SeekOrigin.Begin)
        MorseDecode.player.Stream = ditStream
        'Play stream
        player.PlaySync()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        createWave_NEW(ditStream, 400, 240)
        player.Stream = ditStream
        ditStream.Seek(0, IO.SeekOrigin.Begin)
        player.PlaySync()


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        initializeSounds(7, 600)
        'wave_out.DataSource = ditStream
        'wave_out.Update()


        For [step] = 1 To 5
            playDit()
            'Application.DoEvents()

        Next
        For [step] = 1 To 2
            playLtrSpc()
            'Application.DoEvents()

        Next

        For [step] = 1 To 5
            playDah()
            Application.DoEvents()

        Next
        For [step] = 1 To 1
            playWrdSpc()
            Application.DoEvents()
        Next
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'write all samples as a wave file for debugging purposes
        ditStream.Seek(0, IO.SeekOrigin.Begin)
        write_stream(MorseDecode.ditStream, "ditwave.wav")
        dahStream.Seek(0, IO.SeekOrigin.Begin)
        write_stream(MorseDecode.dahStream, "dahwave.wav")
        ltrSpace.Seek(0, IO.SeekOrigin.Begin)
        write_stream(MorseDecode.ltrSpace, "ltrspacewave.wav")
        wrdSpace.Seek(0, IO.SeekOrigin.Begin)
        write_stream(MorseDecode.wrdSpace, "wrdspacewave.wav")
        interSpace.Seek(0, IO.SeekOrigin.Begin)
        write_stream(MorseDecode.interSpace, "intrspacewave.wav")

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        strip_wave_header(MorseDecode.ditStream)


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PCM_to_wave(MorseDecode.ditStream)
        MorseDecode.ditStream.Seek(0, IO.SeekOrigin.Begin)
        playDit()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        strip_wave_header(MorseDecode.ditStream)
        strip_wave_header(MorseDecode.dahStream)
        strip_wave_header(MorseDecode.interSpace)
        strip_wave_header(MorseDecode.ltrSpace)
        strip_wave_header(MorseDecode.wrdSpace)
        combine_PCM(ditStream, interSpace)
        combine_PCM(ditStream, dahStream)
        combine_PCM(ditStream, interSpace)
        combine_PCM(ditStream, dahStream)
        combine_PCM(ditStream, wrdSpace)
        combine_PCM(ditStream, dahStream)
        PCM_to_wave(ditStream)
        playDit()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        createWave(ditStream, 800, 100, 5, 100)
        createWave(dahStream, 800, 300, 5, 100)
        ditStream.Seek(0, IO.SeekOrigin.Begin)
        dahStream.Seek(0, IO.SeekOrigin.Begin)
        For [step] = 1 To 5
            playDit()
            playDah()
            playDit()
            playDit()

        Next
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Dim charStream As New IO.MemoryStream
        If ditStream.Length = 0 Then initializeSounds(45, 500, True, 13)

        charStream = createCharWave(charStream, "f")
        player.Stream = charStream
        charStream.Seek(0, IO.SeekOrigin.Begin)
        player.PlaySync()
        playWrdSpc()


        charStream = createCharWave(charStream, "a")
        player.Stream = charStream
        charStream.Seek(0, IO.SeekOrigin.Begin)
        player.PlaySync()
        playWrdSpc()

        charStream = createCharWave(charStream, "r")
        player.Stream = charStream
        charStream.Seek(0, IO.SeekOrigin.Begin)
        player.PlaySync()
        playWrdSpc()

        charStream = createCharWave(charStream, "t")
        player.Stream = charStream
        charStream.Seek(0, IO.SeekOrigin.Begin)
        player.PlaySync()
        playWrdSpc()

        charStream.Dispose()

    End Sub
End Class
