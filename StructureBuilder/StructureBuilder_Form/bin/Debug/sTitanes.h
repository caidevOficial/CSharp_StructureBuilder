#ifndef STITANES_H_INCLUDED
#define STITANES_H_INCLUDED
#include "LinkedList.h"

typedef struct{
    int hijos;
    char nombre[8];
    float poder;
    short nivel;
}sTitanes;

#endif 

// # CREDITS TO:
// ## Idea in C: Santiago Herrera.
// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.
// ## Follow me on -> github.com/CaidevOficial

// ## sTitanes: BASIC STRUCTURE FUNCTIONS.
sTitanes* Titanes_newEmpty();
sTitanes* Titanes_new(int hijos, char* nombre, float poder, short nivel);

void Titanes_show(sTitanes* titanes);
int Titanes_showAll(LinkedList* this, char* errorMesage);

// ## sTitanes: GETTERS
int Titanes_getHijos(sTitanes* titanes, int* hijos);
int Titanes_getNombre(sTitanes* titanes, char* nombre);
int Titanes_getPoder(sTitanes* titanes, float* poder);
int Titanes_getNivel(sTitanes* titanes, short* nivel);

// ## sTitanes: SETTERS
int Titanes_setHijos(sTitanes* titanes, int hijos);
int Titanes_setNombre(sTitanes* titanes, char* nombre);
int Titanes_setPoder(sTitanes* titanes, float poder);
int Titanes_setNivel(sTitanes* titanes, short nivel);

// ## sTitanes: COMPARERS
int Titanes_compareHijos(void* titanes1, void* titanes2);
int Titanes_compareNombre(void* titanes1, void* titanes2);
int Titanes_comparePoder(void* titanes1, void* titanes2);
int Titanes_compareNivel(void* titanes1, void* titanes2);

void Titanes_delete(sTitanes* this);
