#include <iostream>
#include <stdio.h>
class crap {public: int z, x, y; void testmember () { float q;}};

int main ()
{
 typedef struct craptest { int a; int b; int c; } ;
 craptest poopy;
 poopy.a = 45;
 poopy.b = 65;
 poopy.c = 12;
 
    
    
    crap pee;
 pee.x =12;
 pee.y = 32;
 pee.z = 43;
 pee.testmember();  
    
    return 0;
    
}
 //typedef struct crap { int a; int b; int c; } ;
 //struct crap poopy;
 
 
 
 
 
