#ifndef SQWE_H_INCLUDED
#define SQWE_H_INCLUDED
#include "LinkedList.h"

typedef struct{
    int qweqwe;
}sQwe;

#endif 

// # CREDITS TO:
// ## Idea in C: Santiago Herrera.
// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.
// ## Follow me on -> github.com/CaidevOficial

// ## sQwe: BASIC STRUCTURE FUNCTIONS.
sQwe* Qwe_newEmpty();
sQwe* Qwe_new(int qweqwe);

void Qwe_show(sQwe* qwe);
int Qwe_showAll(LinkedList* this, char* errorMesage);

// ## sQwe: GETTERS
int Qwe_getQweqwe(sQwe* qwe, int* qweqwe);

// ## sQwe: SETTERS
int Qwe_setQweqwe(sQwe* qwe, int qweqwe);

// ## sQwe: COMPARERS
int Qwe_compareQweqwe(void* qwe1, void* qwe2);

void Qwe_delete(sQwe* this);
