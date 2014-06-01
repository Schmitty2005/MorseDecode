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
    
    Function createWave(ByRef genStream As MemoryStream, ByVal frequency As Double, ByVal msDuration As Integer, _
                        Optional msRamp As Integer = 3, Optional ByVal volume As UInt16 = 16383) ' 16383
        ' createWave generates a sine wave in the form of a memory stream to be passed to windows.media.player
        ' frequency is frequency in Hertz, msDuration is tone duration in milliseconds, msRamp is the beginning and ending
        ' volume ramp (5ms is standard CW)
        'set variables
        Dim writer As New BinaryWriter(genStream)
        Dim TAU As Double = 2 * Math.PI
        Dim formatChunkSize As Integer = 16
        Dim headerSize As Integer = 8
        Dim formatType As Short = 1
        Dim tracks As Short = 1
        Dim samplesPerSecond As Integer = 44100
        Dim bitsPerSample As Short = 16
        Dim frameSize As Short = 2 ' manual input of 2 because it should be right! CShort(tracks * ((bitsPerSample + 7) \ 8))
        Dim bytesPerSecond As Integer = samplesPerSecond * frameSize
        Dim waveSize As Integer = 2 ' change from 4 to 2
        Dim total_samples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * CDbl(msDuration * 0.001)))   'removed /1000 from both
        Dim rampSamples As Integer = CInt(Math.Truncate(CType(samplesPerSecond, [Decimal]) * msRamp * 0.001))   'number of samples for ramp
        Dim full_amplitude_samples As Integer = total_samples - (rampSamples * 2)         'number of samples at full amplitude
        Dim dataChunkSize As Integer = total_samples * 2 'frameSize --- changed 1 to 2 5/28/14
        Dim fileSize As Integer = 36 + dataChunkSize 'waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize
        ' var encoding = new System.Text.UTF8Encoding();
        writer.Write(&H46464952) ' = encoding.GetBytes("RIFF")
        writer.Write(fileSize)
        writer.Write(&H45564157) ' = encoding.GetBytes("WAVE")
        writer.Write(&H20746D66) ' = encoding.GetBytes("fmt ")
        writer.Write(formatChunkSize) ' = 16 for 'PCM'
        writer.Write(formatType)        ' 1 for 'PCM'
        writer.Write(tracks)            ' number of channels
        writer.Write(samplesPerSecond)  ' sample rate
        writer.Write(bytesPerSecond)    ' ByteRate         == SampleRate * NumChannels * BitsPerSample/8
        writer.Write(frameSize)         ' AKA 'Block Align' according to https://ccrma.stanford.edu/courses/422/projects/WaveFormat/
        writer.Write(bitsPerSample)     ' 8 bit or  16 bit sound sample etc....
        writer.Write(&H61746164) ' = encoding.GetBytes("data")
        writer.Write(dataChunkSize)     ' == NumSamples * NumChannels * BitsPerSample/8
        Dim theta As Double = frequency * TAU / CDbl(samplesPerSecond) ' removed -1 from samples per second. CDbl(samplesPerSecond -1)
        ' 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
        ' we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
        Dim amp As Double = volume >> 2 ' so we simply set amp = volume / 2
        Dim rampAmp As Double = 0

        'create amplification ramp of wave  for number of ramp samples (duration of msRamp)
        For [step] As Integer = 0 To rampSamples
            rampAmp = CDbl([step]) / CDbl(rampSamples)
            Dim s As Short = CShort(((amp) * Math.Sin(theta * CDbl([step]))))
            s = s * rampAmp
            writer.Write(s)
        Next [step]
        'amp = volume >> 2 uncommented on 5/30/14 should be OKAY
        ' create regular amplitude wave for full duration minus beginning and ending ramp
        For [step] As Integer = rampSamples To (full_amplitude_samples + rampSamples)
            Dim s As Short = CDbl((amp * Math.Sin(theta * CDbl([step]))))
            writer.Write(s)
        Next [step]
        'create ending ramp amplfication from full volume to 0
        For [step] As Integer = (rampSamples + full_amplitude_samples) To total_samples
            rampAmp = (total_samples - [step]) / CDbl(rampSamples)
            Dim s As Short = CShort(((amp) * Math.Sin(theta * CDbl([step]))))
            s = CShort(s * rampAmp)
        Next [step]
        ' add extra sample to keep samples even
        If genStream.Length Mod 2 <> 0 Then writer.Write(0)
        '
        'Eventually add code to add on interspace silence onto each dit and dah in a effort to remove clicks and pops in audio
        ' adjust variables for file length in wave header to accomplish this.
        '
        '
        '   INSERT CODE HERE FOR SILENCE AT END OF WAVE
        '
        '
        Return genStream
    End Function
    Function createSilence(ByRef genStream As MemoryStream, ByRef msDuration As Integer)
        'a wave of silence will be created.
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
        For [step] As Integer = 0 To samples
            Dim s As Short = 0
            writer.Write(s)
            Debug.Print("Step :" & [step] & vbCrLf)
        Next [step]
        Debug.Print("Silence: " & genStream.Length)
        Return genStream

    End Function
    Public Sub initializeSounds(ByVal wordsPerMin As Integer, ByVal frequencyHz As Integer, Optional ByVal farnsworth_bool As Boolean = False, Optional ByVal farns_spacing As Integer = 15)
        ''routine to calc WPM dit and dah lengths
        ' Integers are just placeholders for testing purposes
        Dim ditDurations As Integer = 1200 / wordsPerMin
        Dim dahDurations As Integer = ditDurations * 3
        Dim wrdspDuration As Integer = ditDurations * 7  ' need to make code for proper spacing
        Dim ltrspDuration As Integer = (dahDurations - ditDurations)
        If farnsworth_bool Then wrdspDuration = (1200 / farns_spacing) * 7
        If farnsworth_bool Then ltrspDuration = (wrdspDuration * 3) - wrdspDuration
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
        'ditStream.Seek(0, SeekOrigin.Begin)
        'dahStream.Seek(0, SeekOrigin.Begin)
        'ltrSpace.Seek(0, SeekOrigin.Begin)
        ' wrdSpace.Seek(0, SeekOrigin.Begin)

        '=====================================================================================
        '==         THESE ARE COMMENTED OUT!  USED FOR TESTING!                             ==
        '=====================================================================================

    End Sub ' sub used to initialize waves to be played back
    Sub playDit()
        
        ditStream.Seek(0, SeekOrigin.Begin)
        player.Stream = ditStream
        player.PlaySync()

    End Sub
    Sub playDah()
        dahStream.Seek(0, SeekOrigin.Begin)
        player.Stream = dahStream
        player.PlaySync()
    End Sub
    Sub playLtrSpc()
        player.Stream = ltrSpace
        ltrSpace.Seek(0, SeekOrigin.Begin)
        player.PlaySync()
    End Sub
    Sub playWrdSpc()
        wrdSpace.Seek(0, SeekOrigin.Begin)
        player.Stream = wrdSpace
        player.PlaySync()
    End Sub
    Sub playInterSpc()
        interSpace.Seek(0, SeekOrigin.Begin)
        player.Stream = interSpace
        player.PlaySync()
    End Sub
    Public Sub PlayCharacter(ByVal pChar As Char, Optional ByVal repeats As Integer = 1)
        'this routine will play the dit's/dah's from an individual character
        Dim morseString = morsedict.Item(pChar) 'get dit dah sequence from morsedict
        Dim counter As Int16 = morseString.Length
        Dim ditdah As Char

        For [step] As Integer = 0 To counter - 1
            ditdah = morseString.Chars([step])
            Application.DoEvents()

            If ditdah = "." Then
                playDit()
            End If

            If ditdah = "-" Then
                playDah()
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
            On Error GoTo -1

            playChar = toPlay.Chars([step])
            Dim morsestring = morsedict.Item(playChar)       ' retrives dah-dit sequence from dictionary
            Form1.display_test.Text = morsestring
            'displays dah dit sequece in window for testing purposes
            Form1.display_chr.Text = (Char.ToUpper(playChar))   'display char in big window
            If playChar = " " Then
                playWrdSpc()
            Else
                PlayCharacter(playChar)
                playLtrSpc()

            End If
            'Do Events and check for closed stream to avoid errors
            Application.DoEvents()
            If player.Stream.CanWrite <> True Then Exit Sub
        Next [step]

    End Sub
    Sub write_stream(ByRef MS As MemoryStream, ByVal wave_filname As String)
        Using file As New FileStream(wave_filname, FileMode.Create, System.IO.FileAccess.Write)
            Dim bytes As Byte() = New Byte(MS.Length - 1) {}
            MS.Read(bytes, 0, CInt(MS.Length))
            file.Write(bytes, 0, bytes.Length)
            MS.Close()
        End Using

    End Sub
    Public Sub Main()

    End Sub
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
    Function PCM_to_wave(ByRef wave_PCM_data_chunk As MemoryStream)
        ' create a wave from PCM data!
        'create variables for header with proper length
        Dim genStream As New MemoryStream
        Dim writer As New BinaryWriter(genStream)
        Dim formatChunkSize As Integer = 16
        Dim headerSize As Integer = 8
        Dim formatType As Short = 1
        Dim tracks As Short = 1
        Dim samplesPerSecond As Integer = 44100
        Dim bitsPerSample As Short = 16
        Dim frameSize As Short = 2 ' manual input of 2 because it should be right! CShort(tracks * ((bitsPerSample + 7) \ 8))
        Dim bytesPerSecond As Integer = samplesPerSecond * frameSize
        Dim waveSize As Integer = 2 ' change from 4 to 2
        Dim dataChunkSize As Integer = wave_PCM_data_chunk.Length 'frameSize --- changed 1 to 2 5/28/14
        Dim fileSize As Integer = 36 + dataChunkSize 'waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize
        'Write new wave header
        writer.Write(&H46464952) ' = encoding.GetBytes("RIFF")
        writer.Write(fileSize)
        writer.Write(&H45564157) ' = encoding.GetBytes("WAVE")
        writer.Write(&H20746D66) ' = encoding.GetBytes("fmt ")
        writer.Write(formatChunkSize) ' = 16 for 'PCM'
        writer.Write(formatType)        ' 1 for 'PCM'
        writer.Write(tracks)            ' number of channels
        writer.Write(samplesPerSecond)  ' sample rate
        writer.Write(bytesPerSecond)    ' ByteRate         == SampleRate * NumChannels * BitsPerSample/8
        writer.Write(frameSize)         ' AKA 'Block Align' according to https://ccrma.stanford.edu/courses/422/projects/WaveFormat/
        writer.Write(bitsPerSample)     ' 8 bit or  16 bit sound sample etc....
        writer.Write(&H61746164) ' = encoding.GetBytes("data")
        writer.Write(dataChunkSize)     ' == NumSamples * NumChannels * BitsPerSample/8
        ' create routine to write stream data to new stream
        wave_PCM_data_chunk.CopyTo(genStream)
        If genStream.Length Mod 2 <> 0 Then writer.Write(0)
        Return genStream
    End Function
    Function strip_wave_header(ByRef wave_stream As MemoryStream)
        Dim PCM_data As New MemoryStream
        wave_stream.Position = 36
        wave_stream.CopyTo(PCM_data)
        PCM_data.Seek(0, SeekOrigin.Begin)
        Return PCM_data
    End Function
    Public Sub combine_PCM(ByVal combined As MemoryStream, ByRef append_to_combined As MemoryStream)
        'set append stream position to remove header information
        append_to_combined.Position = (append_to_combined.Seek(44, SeekOrigin.Current))
        'set result stream position to end
        combined.Position = combined.Length
        'remeber to find position of file length in wave header


    End Sub

End Module
