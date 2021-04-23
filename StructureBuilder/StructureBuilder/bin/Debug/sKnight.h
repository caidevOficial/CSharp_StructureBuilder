#ifndef SKNIGHT_H_INCLUDED
#define SKNIGHT_H_INCLUDED
#include "LinkedList.h"

typedef struct{
    int cosmos;
    char armor[5];
    float power;
}sKnight;

#endif 

// # CREDITS TO:
// ## Idea in C: Santiago Herrera.
// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.

// ## sKnight: BASIC STRUCTURE FUNCTIONS.
sKnight* Knight_newEmpty();
sKnight* Knight_new(int cosmos, char* armor, float power);

void Knight_show(sKnight* knight);
int Knight_showAll(LinkedList* this, char* errorMesage);

// ## sKnight: GETTERS
int Knight_getCosmos(sKnight* knight, int* cosmos);
int Knight_getArmor(sKnight* knight, char* armor);
int Knight_getPower(sKnight* knight, float* power);

// ## sKnight: SETTERS
int Knight_setCosmos(sKnight* knight, int cosmos);
int Knight_setArmor(sKnight* knight, char* armor);
int Knight_setPower(sKnight* knight, float power);

// ## sKnight: COMPARERS
int Knight_compareCosmos(void* knight1, void* knight2);
int Knight_compareArmor(void* knight1, void* knight2);
int Knight_comparePower(void* knight1, void* knight2);

