#ifndef SBARCO_H_INCLUDED
#define SBARCO_H_INCLUDED
#include "LinkedList.h"

typedef struct{
    float velocidad;
    int metros;
    char nombre[5];
}sBarco;

#endif 

// # CREDITS TO:
// ## Idea in C: Santiago Herrera.
// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.

// ## sBarco: BASIC STRUCTURE FUNCTIONS.
sBarco* Barco_newEmpty();
sBarco* Barco_new(float velocidad, int metros, char* nombre);

void Barco_show(sBarco* barco);
int Barco_showAll(LinkedList* this, char* errorMesage);

// ## sBarco: GETTERS
int Barco_getVelocidad(sBarco* barco, float* velocidad);
int Barco_getMetros(sBarco* barco, int* metros);
int Barco_getNombre(sBarco* barco, char* nombre);

// ## sBarco: SETTERS
int Barco_setVelocidad(sBarco* barco, float velocidad);
int Barco_setMetros(sBarco* barco, int metros);
int Barco_setNombre(sBarco* barco, char* nombre);

// ## sBarco: COMPARERS
int Barco_compareVelocidad(void* barco1, void* barco2);
int Barco_compareMetros(void* barco1, void* barco2);
int Barco_compareNombre(void* barco1, void* barco2);

