/** doxygen comment **/

#include <stdio.h>

#include <stdio.h>
#include <iostream>
#include <new>
#include "portaudio.h"


#include <math.h>
#ifndef pi
#define pi (3.14159265)
#endif

//defines for port audio
//#define SAMPLE_RATE (44100)
#define NUMBER_CHANNELS (1)
#define FRAMES_BUFFER (44100) //44100 divided by 800 hz set HIGH AND MOST OF SAMPLE PLAYS!
#define CHECK_OVERFLOW  (0)
#define CHECK_UNDERFLOW  (0)

#include "morsebeep.cpp"
//#include "port_audio_std.cpp"

//user must create a float array with the proper number of samples ( ie. float morsearray[number of samples] )
// calulated by number of samples =(({duration in milliseconds / 1000)*({desired frequency}))

//create struct typedef for morse type audio data.....pointer to data and length of array....

// this code creates a proper length dit....maybe 11/23/2013..fixed using Scilab! 12/2/2013!
// this is the wrong code! get code off of laptop! 1/20/2014....this code is fixed now! 1/22/2014!

/*int wavegen ( float *sample_pointer, float freqc = 800, float duration_ms = 1000,
                                float begin_ramp = 100, float end_ramp = 100,
                                float sample_rate = 44100)
{
        int x=0;
        float begin_ramp_count =  (begin_ramp/1000 * freqc);
        float end_ramp_count = (end_ramp/1000 * freqc);
        float adjust_amp = 0;
        float slice_value = 0;
        const int sw_duration_length =((duration_ms / 1000)*(freqc));

while (x<=begin_ramp_count)
        { //loop for first amplitude taper
        adjust_amp = ((x)/begin_ramp_count);
        slice_value = ((sin(freqc * (2 * pi) * x / sample_rate))*adjust_amp);
 *sample_pointer++= slice_value;
        x++;
        std::cout << x << " : " << slice_value << " ,";
        }

while (x < ((sw_duration_length) - end_ramp_count))
        { //loop for rest of sine wave at full amplitude
        slice_value = (sin(freqc * (2 * pi) * x / sample_rate));
 *sample_pointer++= slice_value;
        x++;
        std::cout << x << " : " << slice_value << " ,";
        }

while (x<=sw_duration_length)
        { //loop for final taper of sound wave
        adjust_amp = (((sw_duration_length-x))/end_ramp_count);
        slice_value = (sin(freqc * (2 * pi) * x / sample_rate))*adjust_amp;
 *sample_pointer++= slice_value;
        x++;
        std::cout << x << " : " << slice_value << " ,";
        }

return 0;
}*/
void newplayroutine();

int main(int argc, char **argv) {
	const char *paerrorstringchar;
	PaStream *stream;
	PaError err;
	PaHostErrorInfo paerr;
	const char *code;
	PaStreamParameters outputParameters;

	err = Pa_Initialize();
	if( err != paNoError ) std::cout<<"PortAudio Intizliation error";

	//open port audio stream
	//setup audio stream for blocking method
	err = Pa_OpenDefaultStream (&stream, 0, NUMBER_CHANNELS, paFloat32, SAMPLE_RATE, FRAMES_BUFFER, NULL, NULL);
	if (err != paNoError ) std::cout <<"Error Opening Audio Device"<<std::endl;
	//
	outputParameters.device = Pa_GetDefaultOutputDevice(); /* default output device */
	outputParameters.channelCount = 1; /* mono input */
	outputParameters.sampleFormat = paFloat32; /* 32 bit floating point output */
	outputParameters.hostApiSpecificStreamInfo = NULL;
	//open audio stream
	
	err = Pa_StartStream (stream);
	if (err != paNoError ){
			if( stream ) {
       Pa_AbortStream( stream );
       Pa_CloseStream( stream );
	    
		
		code = Pa_GetErrorText (err);
    }
	 std::cout <<"Error Opening Audio Stream"<<std::endl;
	}

    printf("hello world\n");   
/*    Morsebeep constructed_test;
    constructed_test.testoutput();


    Morsebeep durtest(511, 444);
    durtest.testoutput();


    Morsebeep crapload(1000, 1000);
    crapload.testoutput();

    Morsebeep testload(2000, 2000);
    testload.testoutput();
  */ 
    Morsebeep otherload(441	, 1000);
    otherload.testoutput();
//		otherload.wave_output();
//
////
////
////
/*float buffer[FRAMES_BUFFER]; /* stereo output buffer */
/*int bufferCount ;
int j, i;
bufferCount = ((otherload.sample_duration() * SAMPLE_RATE) / FRAMES_BUFFER);
for( i=0; i < bufferCount; i++ )
        {
            for( j=0; j < FRAMES_BUFFER; j++ )
            {
                //buffer[j] = (otherload.dit_pointer)+j;//sine[left_phase];  /* left */
                /*
                left_phase += left_inc;
                if( left_phase >= TABLE_SIZE ) left_phase -= TABLE_SIZE;
                right_phase += right_inc;
                if( right_phase >= TABLE_SIZE ) right_phase -= TABLE_SIZE;
            
			  }

            err = Pa_WriteStream( stream, buffer, FRAMES_BUFFER );
            if( err != paNoError ) std::cout<<"ERROR"<<std::endl;
        }  */ 
		///
		////
		////
		////
		////
	
	//play audio
	int z = (otherload.sample_duration()/FRAMES_BUFFER);
	int q = 0;
	int counter = 0;
//	float buffer[FRAMES_BUFFER]; //EXP
	float *buffer_pointer = new float [FRAMES_BUFFER]; // EXP
	float buffer_calc = 0;  //EXP
	float test_val = (otherload.sample_duration());//EXP
	while (q<1){ 
	for( int i=0; i<3; ++i )
		{
			buffer_calc = (otherload.sample_duration()) - (FRAMES_BUFFER * i);
			buffer_pointer = otherload.data_pointer + (FRAMES_BUFFER *i);
			float *y = (otherload.dit_pointer);
			//std::cout<<"Frame: "<<i<<", "<<"Value: "<<*y<<"  ;  ";
			err = Pa_WriteStream( stream, y, FRAMES_BUFFER );
			if( err && CHECK_UNDERFLOW ) std::cout <<"Error Opening Audio Stream"<<std::endl;
		}

	q++;
	counter = 0;
	while (counter<1000){std::cout<<"."; counter++;};
	}
	
	
    std::cout << "Main Pause........." << std::endl;

otherload.play_dit();
otherload.play_dah();
otherload.play_letter_space();
otherload.play_word_space();

///
///
///
Morsebeep testplay (441, 1000);
	 
	 float *buffer = new float [FRAMES_BUFFER];
/////
int i,j;
int bufferCount = ((testplay.dit_data.wave_duration) / FRAMES_BUFFER);
//
i=bufferCount; //added as a bypass so it will not play! for testing
float testpoint;

        for( i=0; i <= (bufferCount); i++ )
        {
            for( j=0; j <= (FRAMES_BUFFER); j++ )
            {
				buffer[j]= *((testplay.dit_data.wave_pointer)+j+(FRAMES_BUFFER * i));
				//std::cout<<"counter: "<<i<<"FramePos: "<<j<<" Value: "<<buffer[j]<<"   ";
				
				//testpoint = *((testplay.dit_data.wave_pointer)+j+(FRAMES_BUFFER * i));
				//Pa_Sleep (20);
            } ;
			//Pa_Sleep (10);
            err = Pa_WriteStream( stream, buffer, FRAMES_BUFFER );
            if( err != paNoError ) std::cout <<"There is an error!"<<std::endl;	
        }   ;	 
	 
	 
/////	 



//Pa_CloseStream( stream );
//newplayroutine();
//Pa_Sleep (1000);
};
 
 

 
 
