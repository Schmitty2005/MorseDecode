//!A Morse Code audio class
//@TODO  Reconfigure ramp duration calculation to give accurate time!
/*!
 * This class allows the  user to input a frequency, duration, start and end ramp times, and sampling rate
 *
 * The wave file is then generated and stored as a pointer in memory.
 * A future function will be audio playback using the class with PortAudio!
 * 1/31/2014
 *
 */
#include <math.h>
#ifndef pi
#define pi (3.14159265)
#endif
#include <iostream>
#include "portaudio.h"
#define MORSE_RAMP_DURATION_DEFAULT_MS (5)
#define MORSE_SAMPLE_RATE (44100)
#define MORSE_FREQ_DEFAULT (800)
#define MORSE_DIT_DURATION_DEFAULT_MS (250)
#define SAMPLE_RATE (44100)

//Revised 1/30/3014
// Using pointers worked!

// Resource for future spacing of morse signals:
// http://en.wikipedia.org/wiki/Morse_code
// scroll 2/3rds down to find spacing information
//
/*
 International Morse code is composed of five elements:

    short mark, dot or "dit" (·) — "dot duration" is one time unit long
    longer mark, dash or "dah" (–) — three time units long
    inter-element gap between the dots and dashes within a character — one dot duration or one unit long
    short gap (between letters) — three time units long
    medium gap (between words) — seven time units long[1]

  *
  Based upon a 50 dot duration standard word such as PARIS, the time for one dot duration or one unit can be
  computed by the formula:

    T = 1200 / W

or

    T = 6000 / C

Where: T is the unit time, or dot duration, in milliseconds, W is the speed in wpm, and C is the speed in cpm.
  *
  *
*/

class Morsebeep
{
private:
	//variables used to port audio
	//PaError err;


	float sample_rate;  //!Sample Rate in Hertz
	float begin_ramp_ms; //! Begin Ramp in milliseconds
	float end_ramp_ms;	//!End Ramp in milliseconds
	float duration_ms;	//!Duration of tone in milliseconds
	float freq_hz;		//!Frequency of tone in Hertz
	


	//!A struct for passing sample data
	/*!This struct will allow the class to pass data outside of the class.
	 * It will be made into a public function when completed.
	 */


public:
	typedef struct wave_data 
	{
		float *wave_pointer;
		int wave_duration;
		int phase = 0;
	};
	
	wave_data dit_data;
	wave_data dah_data;
	wave_data letterSpace_data;
	wave_data wordSpace_data;
	
	float *dit_pointer;			//dit wave pointer
	float *dah_pointer;			//dah wave pointer
	float *letter_space_pointer;//letter space pointer
	float *word_space_pointer;	//word space pointer
	//float *data_pointer;
	float *sample_pointer; //! Private Pointer for class use
	/*typedef struct sample_info
	{
		float numberSamples;
		float *pointerSample;
	};*/
	
	
	~Morsebeep ()
	{
		delete [] sample_pointer	;
	}
	//! Member returns sample_duration of wave file
	/*!
	\a float is returned.
	\param s a constant character pointer.
	\return The test results
	\sa Test(), ~Test(), testMeToo() and publicVar()
	*/
	float sample_duration()
	{
		float m_number_samples;
		m_number_samples = (this->sample_rate*(this->duration_ms));//this->sample_rate/this->freq_hz*(this->duration_ms);//(duration_ms/10 )*(freq_hz);//omitted /1000 from duration_ms
		return m_number_samples;
	}

	int generate_wave() //!Generates sine wave based on settings COMPLETED! 1/5/2014!
	{
		int x=0;
		//variables to be used for all beeps generated
		float begin_ramp_count =(this->sample_rate *(this->begin_ramp_ms/1000));//  (this->begin_ramp_ms/10 * this->freq_hz);//omitted /1000 from ramps
		float end_ramp_count = (this->sample_rate *(this->end_ramp_ms/1000));//(this->end_ramp_ms/10 * this->freq_hz);			//see above NOTE: Change to similar formula of sw_sample_rate should fix problem!
		float adjust_amp = 0;
		float slice_value = 0;

		//variables for duration of different beeps
		const int sw_duration_length = (this->sample_rate*(this->duration_ms/1000));//=((this->sample_rate/this->freq_hz)*(this->duration_ms/10));//((this->duration_ms)*(this->freq_hz));///this->sample_rate);///this->sample_rate;//omitted /1000 from (this->duration_ms/1000)*(this->freq_hz)
		const int dit_duration = (this->sample_rate * (this->duration_ms/1000));
		const int dah_duration = (this->sample_rate * (this->duration_ms/1000)*3);
		const int letter_sp_duration = (this->sample_rate * (this->duration_ms/1000)*3);// n/c
		const int word_sp_duration = (this->sample_rate * (this->duration_ms/1000)*7);// n/c

		//float *data_pointer;
		//allocate memory for samples to be generated
		dit_pointer = new float [dit_duration];
		dah_pointer = new float [dah_duration];
		letter_space_pointer = new float [letter_sp_duration];
		word_space_pointer = new float [word_sp_duration];


		sample_pointer =  new float [sw_duration_length+8192]; //512 Add for testing adding 0's to end
		//The line above dynamically allocates memory for the sample!
		//it must be used OR the sample will be destroyed when
		//the function is completed!  Memory is reserved for the sample!

		
		
// begin dit generation
// set sample pointer to proper location
sample_pointer = dit_pointer;

		while (x<=begin_ramp_count)
			{
				//loop for first amplitude taper
				adjust_amp = ((x)/begin_ramp_count);
				slice_value = ((sin(freq_hz * (2 * pi) * x / sample_rate))*adjust_amp);
				*sample_pointer++= slice_value;
				x++;
				//std::cout << x << " : " << slice_value << " ,";
			}

		while (x < ((dit_duration) - end_ramp_count))
			{
				//loop for rest of sine wave at full amplitude
				slice_value = (sin(freq_hz * (2 * pi) * x / sample_rate));
				*sample_pointer++= slice_value;
				x++;
				//std::cout << x << " : " << slice_value << " ,";
			}

		while (x<=dit_duration)
			{
				//loop for final taper of sound wave
				adjust_amp = (((sw_duration_length-x))/end_ramp_count); //WTF <----! ! !
				slice_value = (sin(freq_hz * (2 * pi) * x / sample_rate))*adjust_amp;
				*sample_pointer++= slice_value;
				x++;
				//std::cout << x << " : " << slice_value << " ,";
			}

		//add several 0's to end of sample to get rid of clicks
		while (x<=(dit_duration)+0)
			{
				*sample_pointer++ = 0;
				x++;
			}

dit_data.wave_pointer = dit_pointer;
dit_data.wave_duration = dit_duration;




// code to generate dahs......
//
sample_pointer = dah_pointer;
	while (x<=begin_ramp_count)
		{
			//loop for first amplitude taper
			adjust_amp = ((x)/begin_ramp_count);
			slice_value = ((sin(freq_hz * (2 * pi) * x / sample_rate))*adjust_amp);
			*sample_pointer++= slice_value;
			x++;
			//std::cout << x << " : " << slice_value << " ,";
		}

	while (x < ((dah_duration) - end_ramp_count))
		{
			//loop for rest of sine wave at full amplitude
			slice_value = (sin(freq_hz * (2 * pi) * x / sample_rate));
			*sample_pointer++= slice_value;
			x++;
			//std::cout << x << " : " << slice_value << " ,";
		}

	while (x<=dah_duration)
		{
			//loop for final taper of sound wave
			adjust_amp = (((sw_duration_length-x))/end_ramp_count);
			slice_value = (sin(freq_hz * (2 * pi) * x / sample_rate))*adjust_amp;
			*sample_pointer++= slice_value;
			x++;
			//std::cout << x << " : " << slice_value << " ,";
		}

	//add several 0's to end of sample to get rid of clicks
	while (x<=(dah_duration)+8192)
		{
			*sample_pointer++ = 0;
			x++;
		}
		
dah_data.wave_pointer = dah_pointer;
dah_data.wave_duration = dah_duration;
//code to generate letter space
//........................
sample_pointer = letter_space_pointer;
x=0;
while (x<letter_sp_duration)
{
	*sample_pointer++ = 0;
	x++;
}

letterSpace_data.wave_pointer = letter_space_pointer;
letterSpace_data.wave_duration = letter_sp_duration;
//code to generate word space
//........................
sample_pointer = word_space_pointer;
x=0;
while (x<word_sp_duration)
{
	*sample_pointer++ = 0;
	x++;
}

wordSpace_data.wave_pointer = word_space_pointer;
wordSpace_data.wave_duration = word_sp_duration;
return 0;

	};

	float *data_pointer;

	//default constructor
	Morsebeep() :  sample_rate(MORSE_SAMPLE_RATE),   begin_ramp_ms(MORSE_RAMP_DURATION_DEFAULT_MS),   end_ramp_ms(MORSE_RAMP_DURATION_DEFAULT_MS),
		duration_ms(MORSE_DIT_DURATION_DEFAULT_MS),  freq_hz(MORSE_FREQ_DEFAULT)
	{
		this->generate_wave();
	};
	//constructor with frequency and duration options
	Morsebeep ( float freq_hertz,  float duration_millis): freq_hz(freq_hertz), duration_ms(duration_millis),
		begin_ramp_ms (MORSE_RAMP_DURATION_DEFAULT_MS), end_ramp_ms(MORSE_RAMP_DURATION_DEFAULT_MS),
		sample_rate(MORSE_SAMPLE_RATE)
	{
		this->generate_wave();
	};
	//constructor with only duration
	Morsebeep ( float duration_millis):  freq_hz(MORSE_FREQ_DEFAULT),duration_ms(duration_millis),
		begin_ramp_ms(MORSE_RAMP_DURATION_DEFAULT_MS), end_ramp_ms(MORSE_RAMP_DURATION_DEFAULT_MS), sample_rate(MORSE_SAMPLE_RATE)
	{
		this->generate_wave();
	};
	//create constructor that allows "w" wpm or "c" cpm! Morsebeep (char wpm_or_cpm, int wcspeed) : freq_hz(800),
	// begin_ramp_ms(calc...), end_ramp_ms(calc), sample_rate (44100)


	//these are the members:
	/*float sample_duration()
	{
		float m_number_samples;
		m_number_samples = (duration_ms / 1000)*(freq_hz);
		return m_number_samples;
	}*/



	void wave_output () //! Outputs all of the wave steps in console for testing
	{
		float wave_samples = (duration_ms / 1000)*(freq_hz);
		int x = 0;
		while (x<=wave_samples)
			{
				float z = *(data_pointer + x);
				std::cout <<"Step : "<<x<<" Value : "<< z << " , ";
				x++;
			}
	}
	void testoutput() //!outputs all of class settings to console for testing
	{
		std::cout <<std::endl<< "Class duration : "<<this->duration_ms<<std::endl<<"Class Frequency : "
		          << this->freq_hz<<std::endl;

		std::cout <<"Class begin ramp : " << this->begin_ramp_ms <<std::endl <<
		          "Class end ramp : " << this->end_ramp_ms << std::endl<< "Data pointer address:"<<this->data_pointer<< std::endl;

		std::cout << "pause here......\n";
	}

	int play_dit ()
	{
		/*err = Pa_WriteStream( stream, this->dit_pointer, FRAMES_BUFFER );
			if (err != paNoError) std::cout <<"There is an error!"<<std::endl;
		//this code will play a dit
		std::cout<<"This code will play a dit!"<<std::endl;
		 * */
		return 0;
	}
	int play_dah ()
	{
		//this code will play a dah
		std::cout<<"This code will play a dah!"<<std::endl;
		return 0;
	}
	int play_letter_space ()
	{
		//this code will pause a space between letters
		std::cout<<"This code will play a pause between letters"<<std::endl;
		return 0;
	}
	int play_word_space ()
	{
		//this code will play a space between words
		std::cout<<"This code will play a space between words"<<std::endl;
		return 0;
	}

	;

	;

	/*Morsebeep::Morsebeep (int m_freq_hz, int m_duration_ms)
	{
		freq_hz = float (m_freq_hz);
		duration_ms = float (m_duration_ms);
	}*/
}
;
