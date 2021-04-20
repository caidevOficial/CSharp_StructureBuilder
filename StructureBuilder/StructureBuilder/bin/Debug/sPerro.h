#ifndef SPERRO_H_INCLUDED
#define SPERRO_H_INCLUDED
#include "LinkedList.h"

typedef struct{
    int edad;
}sPerro;

#endif 

// # CREDITS TO:
// ## Idea in C: Santiago Herrera.
// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.

// ## sPerro: BASIC STRUCTURE FUNCTIONS.
sPerro* Perro_newEmpty();
sPerro* Perro_new(int edad);

void Perro_show(sPerro* Perro);
int Perro_showAll(LinkedList* this, char* errorMesage);

// ## sPerro: GETTERS
int Perro_getEdad(sPerro* Perro, int* edad);

// ## sPerro: SETTERS
int Perro_setEdad(sPerro* Perro, int edad);

// ## sPerro: COMPARERS
int Perro_compareEdad(void* Perro1, void* Perro2);

