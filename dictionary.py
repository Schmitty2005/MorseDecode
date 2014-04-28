#-------------------------------------------------------------------------------
# Name:        module1
# Purpose:
#
# Author:      Schmitt
#
# Created:     27/10/2013
# Copyright:   (c) Schmitt 2013
# Licence:     <your licence>
#-------------------------------------------------------------------------------
import winsound
import time

def main():
    pass
morseDict = {
'a': '.-',
'b': '-...',
'c': '-.-.',
'd': '-..',
'e': '.',
'f': '..-.',
'g': '--.',
'h': '....',
'i': '..',
'j': '.---',
'k': '-.-',
'l': '.-..',
'm': '--',
'n': '-.',
'o': '---',
'p': '.--.',
'q': '--.-',
'r': '.-.',
's': '...',
't': '-',
'u': '..-',
'v': '...-',
'w': '.--',
'x': '-..-',
'y': '-.--',
'z': '--..',
' ': '',
}

if __name__ == '__main__':
    main()
while True:
    inp = input("Message: ")
    #a = morseDict[inp]
    #morseStr =  a
    for c in inp:
        a = morseDict[c]
        morseStr =  a
        print (a)
        for d in a:

            if d == '-':
                winsound.Beep(800, 600)
            elif d == '.':
                winsound.Beep(800, 200)
            elif d == ' ':
                time.sleep(0.8)
        else:
            time.sleep(0.4)
        time.sleep(0.2)