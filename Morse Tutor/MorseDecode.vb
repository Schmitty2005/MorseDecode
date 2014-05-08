Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports System.Threading

' A future version should have an Async method for playback verusus using the System.Media.player.playsync().
' The program runs like crap
'


Public Module MorseDecode

    'morsedict contains a dictionary with the proper morse code attached to the letter
    Public morsedict As New Dictionary(Of Char, String) From {{"a", ".-"}, {"b", "-..."}, {"c", "-.-."}, {"d", "-.."}, _
                                                              {"e", "."}, {"f", "..-."}, {"g", "--."}, {"h", "...."}, _
                                                              {"i", ".."}, {"j", ".---"}, {"k", "-.-"}, {"l", ".-.."}, _
                                                              {"m", "--"}, {"n", "-."}, {"o", "---"}, {"p", ".--."}, _
                                                              {"q", "--.-"}, {"r", ".-."}, {"s", "..."}, {"t", "-"}, _
                                                              {"u", "..-"}, {"v", "...-"}, {"w", ".--"}, {"x", "-..-"}, _
                                                              {"y", "-.--"}, {"z", "--.."}, {"0", "-----"}, {"1", ".----"}, _
                                                              {"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."}, _
                                                              {"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."}, _
                                                              {"?", "..--.."}, {"!", ".-.-"}, {"(", "--..--"}, {")", "........."}, _
                                                              {" ", " "}, {"@", ".--.-."}, {"/", "-..-."}}
    'declare memoryStreams as public for playback
    Public mStrm As New MemoryStream
    Public player As New System.Media.SoundPlayer
    Public ditStream As New MemoryStream
    Public dahStream As New MemoryStream
    Public ltrSpace As New MemoryStream
    Public wrdSpace As New MemoryStream
    Public interSpace As New MemoryStream

    
    Sub debug_output(ByVal testStream As MemoryStream)
        Dim length As Int16 = testStream.Length
        For [counter] = 0 To length

        Next
        'this sub will output the stream into the debug window for checking waves!

    End Sub

    'createWave generates a sine wave in the form of a memory stream to be passed to windows.media.player
    ' frequency is frequency in Hertz, msDuration is tone duration in milliseconds, msRamp is the beginning and ending
    ' volume ramp (5ms is standard CW)

    Function createWave(ByRef genStream As MemoryStream, ByVal frequency As UInt16, ByVal msDuration As Integer, _
                        Optional msRamp As Integer = 7, Optional ByVal volume As UInt16 = 16383) ' 16383
        'set variables
        Dim writer As New BinaryWriter(genStream)
        Dim TAU As Double = 2 * Math.PI
        Dim formatChunkSize As Integer = 16
        Dim headerSize As Integer = 8
        Dim formatType As Short = 1
        Dim tracks As Short = 1
        Dim samplesPerSecond As Integer = 44100
        Dim bitsPerSample As Short = 16
        Dim frameSize As Short = CShort(tracks * ((bitsPerSample + 7) \ 8))
        Dim bytesPerSecond As Integer = samplesPerSecond * frameSize
        Dim waveSize As Integer = 4
        Dim samples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msDuration \ 1000))   'removed /1000 from both
        Dim rampSamples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msRamp \ 1000))   'number of samples for ramp
        Dim fullSamples As Integer = samples - (rampSamples * 2)         'number of samples at full amplitude
        Dim dataChunkSize As Integer = samples * frameSize
        Dim fileSize As Integer = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize
        ' var encoding = new System.Text.UTF8Encoding();
        writer.Write(&H46464952) ' = encoding.GetBytes("RIFF")
        writer.Write(fileSize)
        writer.Write(&H45564157) ' = encoding.GetBytes("WAVE")
        writer.Write(&H20746D66) ' = encoding.GetBytes("fmt ")
        writer.Write(formatChunkSize)
        writer.Write(formatType)
        writer.Write(tracks)
        writer.Write(samplesPerSecond)
        writer.Write(bytesPerSecond)
        writer.Write(frameSize)
        writer.Write(bitsPerSample)
        writer.Write(&H61746164) ' = encoding.GetBytes("data")
        writer.Write(dataChunkSize)
        Dim theta As Double = frequency * TAU / CDbl(samplesPerSecond)
        ' 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
        ' we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
        Dim amp As Double = volume >> 2 ' so we simply set amp = volume / 2
        Dim rampAmp As Double = 0

        'create amplification ramp of wave  for number of ramp samples (duration of msRamp)
        For [step] As Integer = 0 To rampSamples - 1
            rampAmp = [step] / rampSamples
            Dim s As Short = CShort(Math.Truncate((amp) * Math.Sin(theta * CDbl([step]))))
            s = s * rampAmp
            writer.Write(s)
            'Debug.Print("Step :" & [step] & " Ramp at beginning: " & rampAmp & " S Value :" & s)
        Next [step]

        amp = volume >> 2 'commented out on 5/3/2014 uncomment if audio waves are no longer working
        ' create regular amplitude wave for full duration minus ending ramp
        For [step] As Integer = rampSamples To fullSamples - 1 ' remeber to add -1 to my own C++ code that uses PortAudio!
            Dim s As Short = CShort(Math.Truncate(amp * Math.Sin(theta * CDbl([step]))))
            writer.Write(s)
            'Debug.Print("Step: " & [step] & "  Full Amp sample : " & s)
        Next [step]


        'create ending ramp amplfication from full volume to 0
        For [step] As Integer = (rampSamples + fullSamples) To (((2 * rampSamples) + fullSamples) - 1)
            rampAmp = CDbl((rampSamples + fullSamples + rampSamples - [step]) / rampSamples)
            Dim s As Short = CShort(Math.Truncate((amp) * Math.Sin(theta * CDbl([step]))))
            s = s * rampAmp
            'debug statement
            'Debug.Print("Step: " & [step] & "   RampAmp at ending : " & rampAmp & "  S value : " & s)
            Debug.Print("Step : " & [step])
            writer.Write(s)
        Next [step]

        'add extra zero at end for good measure
        Dim z As Short = 0
        writer.Write(z)
        Debug.Print("generateWave stream length: " & genStream.Length)


        Return genStream

    End Function

    Function createSilence(ByRef genStream As MemoryStream, ByRef msDuration As Integer)

        'a wave of silence will be created.
        'wave header variables
        Dim writer As New BinaryWriter(genStream)
        Dim TAU As Double = 2 * Math.PI
        Dim formatChunkSize As Integer = 16
        Dim headerSize As Integer = 8
        Dim formatType As Short = 1
        Dim tracks As Short = 1
        Dim samplesPerSecond As Integer = 44100
        Dim bitsPerSample As Short = 16
        Dim frameSize As Short = CShort(tracks * ((bitsPerSample + 7) \ 8))
        Dim bytesPerSecond As Integer = samplesPerSecond * frameSize
        Dim waveSize As Integer = 4
        Dim samples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msDuration \ 1000))
        'Dim rampSamples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msRamp \ 1000))   'number of samples for ramp
        'Dim fullSamples As Integer = samples - (rampSamples * 2)         'number of samples at full amplitude
        Dim dataChunkSize As Integer = samples * frameSize
        Dim fileSize As Integer = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize
        ' var encoding = new System.Text.UTF8Encoding();
        writer.Write(&H46464952) ' = encoding.GetBytes("RIFF")
        writer.Write(fileSize)
        writer.Write(&H45564157) ' = encoding.GetBytes("WAVE")
        writer.Write(&H20746D66) ' = encoding.GetBytes("fmt ")
        writer.Write(formatChunkSize)
        writer.Write(formatType)
        writer.Write(tracks)
        writer.Write(samplesPerSecond)
        writer.Write(bytesPerSecond)
        writer.Write(frameSize)
        writer.Write(bitsPerSample)
        writer.Write(&H61746164) ' = encoding.GetBytes("data")
        writer.Write(dataChunkSize)
        'Dim theta As Double = frequency * TAU / CDbl(samplesPerSecond)
        ' 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
        ' we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
        'Dim amp As Double = volume >> 2 ' so we simply set amp = volume / 2
        'Dim rampAmp As Double = 0
        'Debug.Print(rampSamples)
        For [step] As Integer = 0 To samples - 1
            Dim s As Short = 0
            writer.Write(s)
            'Debug.Print("Step :" & [step] & " Ramp at beginning: " & rampAmp & " S Value :" & s)
        Next [step]
        'mStrm.Seek(0, SeekOrigin.Begin)
        Debug.Print("Silence: " & genStream.Length)
        Return genStream

    End Function


    Public Sub initializeSounds(ByVal wordsPerMin As Integer, ByVal frequencyHz As Integer, Optional ByVal spacingWPM As Integer = 15)
        ''routine to calc WPM dit and dah lengths
        ' Integers are just placeholders for testing purposes
        Dim ditDurations As Integer = 1200 / wordsPerMin
        Dim dahDurations As Integer = ditDurations * 3
        Dim wrdspDuration As Integer = ditDurations * 7  ' need to make code for proper spacing
        Dim ltrspDuration As Integer = (dahDurations - ditDurations)
        'Debug.Print("Dit Duration: " & ditDurations & "Dah Duration :" & dahDurations & "Letter Space : " & ltrspDuration & "Word Space : " & wrdspDuration)

        'generate wave memory streams
        Debug.Print("Generating Dit Stream.....")
        MorseDecode.createWave(MorseDecode.ditStream, frequencyHz, ditDurations)
        Debug.Print("Generating Dah Stream.....")
        MorseDecode.createWave(MorseDecode.dahStream, frequencyHz, dahDurations)
        MorseDecode.createSilence(MorseDecode.ltrSpace, ltrspDuration)
        MorseDecode.createSilence(MorseDecode.wrdSpace, wrdspDuration)
        MorseDecode.createSilence(MorseDecode.interSpace, ditDurations)

        'set memory streams to beginning
        ditStream.Seek(0, SeekOrigin.Begin)
        dahStream.Seek(0, SeekOrigin.Begin)
        ltrSpace.Seek(0, SeekOrigin.Begin)
        wrdSpace.Seek(0, SeekOrigin.Begin)

        '=====================================================================================
        '==         THESE ARE COMMENTED OUT!  USED FOR TESTING!                             ==
        '=====================================================================================
        '
        'set memory stream to play dit
        'ditStream.Seek(0, SeekOrigin.Begin)
        'player.Stream = ditStream
        'set memory stream to beginning for proper playback

        'play current stream in Sync mode
        'player.PlaySync()

        'set memory stream to play dah
        'MorseDecode.player.Stream = ltrSpace
        'MorseDecode.player.PlaySync()
        'MorseDecode.player.Stream = dahStream
        'MorseDecode.player.PlaySync()

        'set dah stream, set origin, play stream
        'MorseDecode.player.Stream = dahStream
        'MorseDecode.dahStream.Seek(0, SeekOrigin.Begin)
        'MorseDecode.player.PlaySync()
        'set stream, set origin to begining, play stream
        'MorseDecode.player.Stream = ltrSpace
        'MorseDecode.ltrSpace.Seek(0, SeekOrigin.Begin)
        'MorseDecode.player.PlaySync()
        ' set ditstream, set origin to begining, play stream
        'MorseDecode.player.Stream = ditStream
        'MorseDecode.ditStream.Seek(0, SeekOrigin.Begin)
        'MorseDecode.player.PlaySync()


        'set stream, set origin to begining, play stream
        'MorseDecode.player.Stream = ltrSpace
        'MorseDecode.ltrSpace.Seek(0, SeekOrigin.Begin)
        'MorseDecode.player.PlaySync()

        ' set ditstream, set origin to begining, play stream
        'MorseDecode.player.Stream = ditStream
        'ditStream.Seek(0, SeekOrigin.Begin)
        '===========================================================================
        '=            END OF TESTING CODE                                          =
        '===========================================================================




        '
    End Sub ' sub used to initialize waves to be played back




    Public Sub PlayBeep(ByVal frequency As UInt16, ByVal msDuration As Integer, Optional ByVal msRamp As Integer = 10, Optional ByVal volume As UInt16 = 16383)
        '' a routine that plays a beep!
        'http://stackoverflow.com/questions/19672593/generate-morse-code-or-any-audio-in-net-c-or-vb-net-without-3rd-party-depe
        '
        'Dim mStrm As New MemoryStream()
        Dim writer As New BinaryWriter(mStrm)

        Dim TAU As Double = 2 * Math.PI
        Dim formatChunkSize As Integer = 16
        Dim headerSize As Integer = 8
        Dim formatType As Short = 1
        Dim tracks As Short = 1
        Dim samplesPerSecond As Integer = 44100
        Dim bitsPerSample As Short = 16
        Dim frameSize As Short = CShort(tracks * ((bitsPerSample + 7) \ 8))
        Dim bytesPerSecond As Integer = samplesPerSecond * frameSize
        Dim waveSize As Integer = 4
        Dim samples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msDuration \ 1000))
        Dim rampSamples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msRamp \ 1000))   'number of samples for ramp
        Dim fullSamples As Integer = samples - (rampSamples * 2)         'number of samples at full amplitude
        Dim dataChunkSize As Integer = samples * frameSize
        Dim fileSize As Integer = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize
        ' var encoding = new System.Text.UTF8Encoding();
        writer.Write(&H46464952) ' = encoding.GetBytes("RIFF")
        writer.Write(fileSize)
        writer.Write(&H45564157) ' = encoding.GetBytes("WAVE")
        writer.Write(&H20746D66) ' = encoding.GetBytes("fmt ")
        writer.Write(formatChunkSize)
        writer.Write(formatType)
        writer.Write(tracks)
        writer.Write(samplesPerSecond)
        writer.Write(bytesPerSecond)
        writer.Write(frameSize)
        writer.Write(bitsPerSample)
        writer.Write(&H61746164) ' = encoding.GetBytes("data")
        writer.Write(dataChunkSize)
        Dim theta As Double = frequency * TAU / CDbl(samplesPerSecond)
        ' 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
        ' we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
        Dim amp As Double = volume >> 2 ' so we simply set amp = volume / 2
        Dim rampAmp As Double = 0
        Debug.Print(rampSamples)
        For [step] As Integer = 0 To rampSamples - 1
            rampAmp = [step] / rampSamples
            Dim s As Short = CShort(Math.Truncate((amp) * Math.Sin(theta * CDbl([step]))))
            s = s * rampAmp
            writer.Write(s)
            'Debug.Print("Step :" & [step] & " Ramp at beginning: " & rampAmp & " S Value :" & s)
        Next [step]

        amp = volume >> 2
        For [step] As Integer = rampSamples To fullSamples - 1 ' remeber to add -1 to my own C++ code that uses PortAudio!
            Dim s As Short = CShort(Math.Truncate(amp * Math.Sin(theta * CDbl([step]))))
            writer.Write(s)
            'Debug.Print("Full Amp sample : " & s)
        Next [step]
        'Insert Code here for ending ramp
        '
        'THIS NEEDS TO BE FIXED!  maybe.....
        '
        For [step] As Integer = (rampSamples + fullSamples) To ((2 * rampSamples) + fullSamples - 1)
            rampAmp = 1
            Dim s As Short = CShort(Math.Truncate((amp) * Math.Sin(theta * CDbl([step]))))
            s = s * rampAmp
            'Debug.Print("RampAmp at ending : " & rampAmp & "  S value : " & s)
            writer.Write(s)
        Next [step]

        mStrm.Seek(0, SeekOrigin.Begin)
        player.Stream = mStrm
        mStrm.Seek(0, SeekOrigin.Begin)
        mStrm.Seek(0, SeekOrigin.Begin)
        player.PlaySync()

        player.Dispose()

    End Sub ' public static void PlayBeep(UInt16 frequency, int msDuration

    Sub playDit()
        'Console.Beep(600, 100)
        'Thread.Sleep(100)
        ditStream.Seek(0, SeekOrigin.Begin)
        player.Stream = ditStream
        player.PlaySync()
    End Sub
    Sub playDah()
        'Console.Beep(600, 300)
        'Thread.Sleep(100)
        dahStream.Seek(0, SeekOrigin.Begin)
        player.Stream = dahStream
        player.PlaySync()
    End Sub
    Sub playLtrSpc()
        Thread.Sleep(100)
        'ltrSpace.Seek(0, SeekOrigin.Begin)
        'player.Stream = ltrSpace
        'player.PlaySync()
    End Sub
    Sub playWrdSpc()
        Thread.Sleep(600)
        'wrdSpace.Seek(0, SeekOrigin.Begin)
        'player.Stream = wrdSpace
        'player.PlaySync()
    End Sub
    Sub playInterSpc()
        Thread.Sleep(0)
        'interSpace.Seek(0, SeekOrigin.Begin)
        'player.Stream = interSpace
        'player.PlaySync()
    End Sub

    Public Sub PlayCharacter(ByVal pChar As Char, Optional ByVal repeats As Integer = 1)
        'this routine will play the dit's/dah's from an individual character
        Dim morseString = morsedict.Item(pChar) 'get dit dah sequence from morsedict
        Dim counter As Int16 = morseString.Length
        Dim ditdah As Char

        For [step] As Integer = 0 To counter - 1
            ditdah = morseString.Chars([step])

            If ditdah = "." Then
                playDit()
                'If [step] <> (counter - 1) Then playInterSpc()
            End If

            If ditdah = "-" Then
                playDah()
                'If [step] <> (counter - 1) Then playInterSpc()
            End If

        Next

    End Sub

    Public Sub PlayString(ByVal playString As String, Optional ByVal repeats As Integer = 1)
        ''this routine displays each character in a string....
        ''dits and dahs will be added later on
        Dim toPlay As String = playString.ToLower
        Dim playLength As Short = CType(playString.Length, Short)
        Dim playChar As Char

        For [step] As Integer = 0 To playLength - 1
            playChar = toPlay.Chars([step])
            Dim morsestring = morsedict.Item(playChar)       ' retrives dah-dit sequence from dictionary
            Form1.display_test.Text = morsestring             'displays dah dit sequece in window for testing purposes
            Form1.display_chr.Text = (Char.ToUpper(playChar))   'display char in big window

            If playChar = " " Then
                playWrdSpc()
            Else
                PlayCharacter(playChar)
                playLtrSpc()
            End If

        Next [step]

    End Sub
    Public Sub Main()

    End Sub




End Module
