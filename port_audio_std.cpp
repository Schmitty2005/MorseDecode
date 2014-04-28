//#include "portaudio.h"
#include <stdio.h>
#include "portaudio.h"
#include "iostream"
#include <new>

#define SAMPLE_RATE (44100)
#define NUMBER_CHANNELS (1)
#define FRAMES_BUFFER (800)
#define CHECK_OVERFLOW  (0)
#define CHECK_UNDERFLOW  (0)

int startup(){
	PaStream *stream;
	PaError err;
	PaHostErrorInfo paerr;
	const char *code;
	

	err = Pa_Initialize();
	if( err != paNoError ) std::cout<<"PortAudio Intizliation error";

	//open port audio stream
	//setup audio stream
	err = Pa_OpenDefaultStream (&stream, 0, NUMBER_CHANNELS, paFloat32, SAMPLE_RATE, FRAMES_BUFFER, NULL, NULL);
	if (err != paNoError ) std::cout <<"Error Opening Audio Device"<<std::endl;
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
}



/*int portaudiotesting ()
{

	std::cout<<"port audio test function started"<<std::endl;

	PaStream *stream;
	PaError err;
	char * sampleBlock;
	int numBytes;
//setup audio stream
	err = Pa_OpenDefaultStream (&stream, 0, NUMBER_CHANNELS, paFloat32, SAMPLE_RATE, FRAMES_BUFFER, NULL, NULL);
	if (err != paNoError ) std::cout <<"Error Opening Audio Device"<<std::endl;
//open audio stream
	err = Pa_StartStream (stream);
	if (err != paNoError ) std::cout <<"Error Opening Audio Stream"<<std::endl;
//pass data to audio stream
	numBytes = FRAMES_BUFFER * 2 * SAMPLE_RATE ;
	//sampleBlock = (char *) malloc( numBytes );
	if( sampleBlock == NULL )
		{
			printf("Could not allocate record array.\n");

		}
	//CLEAR( sampleBlock );

	for( int i=0; i<(120*SAMPLE_RATE)/FRAMES_BUFFER; ++i )
		{
			err = Pa_WriteStream( stream, sampleBlock, FRAMES_BUFFER );
			if( err && CHECK_UNDERFLOW ) std::cout <<"Error Opening Audio Stream"<<std::endl;
			err = Pa_ReadStream( stream, sampleBlock, FRAMES_BUFFER );
			if( err && CHECK_OVERFLOW ) std::cout <<"Error Opening Audio Stream"<<std::endl;
		}
//err = Pa_WriteStream (stream, sampleBlock, FRAMES_BUFFER)
//if(err) std::cout<<"Error is sending stream"<<std::endl;
	return 0;

exit:
	std::cout<<"There was an error!"<<std::endl;
	return 1;

};*/
