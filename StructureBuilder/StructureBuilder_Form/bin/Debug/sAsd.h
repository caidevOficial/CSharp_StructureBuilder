#ifndef SASD_H_INCLUDED
#define SASD_H_INCLUDED
#include "LinkedList.h"

typedef struct{
    int asd;
    float asdasd;
}sAsd;

#endif 

// # CREDITS TO:
// ## Idea in C: Santiago Herrera.
// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.
// ## Follow me on -> github.com/CaidevOficial

// ## sAsd: BASIC STRUCTURE FUNCTIONS.
sAsd* Asd_newEmpty();
sAsd* Asd_new(int asd, float asdasd);

void Asd_show(sAsd* asd);
int Asd_showAll(LinkedList* this, char* errorMesage);

// ## sAsd: GETTERS
int Asd_getAsd(sAsd* asd, int* asd);
int Asd_getAsdasd(sAsd* asd, float* asdasd);

// ## sAsd: SETTERS
int Asd_setAsd(sAsd* asd, int asd);
int Asd_setAsdasd(sAsd* asd, float asdasd);

// ## sAsd: COMPARERS
int Asd_compareAsd(void* asd1, void* asd2);
int Asd_compareAsdasd(void* asd1, void* asd2);

void Asd_delete(sAsd* this);
