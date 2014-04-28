
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
'testing comments

Public Class globalVar


    'Dim mStrm As New MemoryStream
    'Dim player As System.Media.SoundPlayer





    Public Sub init_dict()

        Dim morsedict As New Dictionary(Of Char, String)
        morsedict.Add("a", ".-")
        morsedict.Add("b", "-...")
        morsedict.Add("c", ".-.-")
        morsedict.Add("d", "-..")
        morsedict.Add("e", ".")
        morsedict.Add("f", "..-.")
        morsedict.Add("g", "--.")
        morsedict.Add("h", "....")
        morsedict.Add("i", "..")
        morsedict.Add("j", ".---")
        morsedict.Add("k", "-.-")
        morsedict.Add("l", ".-..")
        morsedict.Add("m", "--")
        morsedict.Add("n", "-.")
        morsedict.Add("o", "---")
        morsedict.Add("p", ".--.")
        morsedict.Add("q", "--.-")
        morsedict.Add("r", ".-.")
        morsedict.Add("s", "...")
        morsedict.Add("t", "-")
        morsedict.Add("u", "..-")
        morsedict.Add("v", "...-")
        morsedict.Add("w", ".--")
        morsedict.Add("x", "-..-")
        morsedict.Add("y", "-.--")
        morsedict.Add("z", "--..")
        morsedict.Add(" ", " ")
        morsedict.Add("?", "..--..")
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
