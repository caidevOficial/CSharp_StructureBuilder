#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "LinkedList.h"
#include "sTitanes.h"

sTitanes* Titanes_newEmpty(){ 
    return (sTitanes*) calloc(sizeof(sTitanes),1);
}

sTitanes* Titanes_new(int hijos, char* nombre, float poder, short nivel){
    sTitanes* titanes = Titanes_newEmpty();
    if(titanes!=NULL){
        Titanes_setHijos(titanes, hijos);
        Titanes_setNombre(titanes, nombre);
        Titanes_setPoder(titanes, poder);
        Titanes_setNivel(titanes, nivel);
    }
    return titanes;
{

void Titanes_show(sTitanes* titanes){
 int hijos;
 char nombre[8];
 float poder;
 short nivel;

    Titanes_getHijos(titanes, &hijos);
    Titanes_getNombre(titanes, nombre);
    Titanes_getPoder(titanes, &poder);
    Titanes_getNivel(titanes, &nivel);

    if(titanes!=NULL){
        printf("%d|%s|%f|\n",hijos,nombre,poder,nivel);
        printf("-\n");
    }
}

int Titanes_showAll(LinkedList* this, char* errorMesage){
    int length;
    int isError = 1;
    sTitanes* titanes;
    length = ll_len(this);
    if(length>0){
        printf("hijos|nombre|poder|nivel\n");
        printf("-\n");
        for(int i=0; i<length; i++){
            titanes = (sTitanes*) ll_get(this,i);
            Titanes_show(titanes);
        }
        isError = 0;
    }
    else{
        printf(errorMesage);
    }
    return isError;
}
// ## sTitanes: GETTERS
int Titanes_getHijos(sTitanes* titanes, int* hijos){
    int isError = 1;
    if(titanes!=NULL){
        *hijos = titanes->hijos;
        isError = 0;
    }
    return isError;
}

int Titanes_getNombre(sTitanes* titanes, char* nombre){
    int isError = 1;
    if(titanes!=NULL){
        strcpy(nombre,titanes->nombre);
        isError = 0;
    }
    return isError;
}

int Titanes_getPoder(sTitanes* titanes, float* poder){
    int isError = 1;
    if(titanes!=NULL){
        *poder = titanes->poder;
        isError = 0;
    }
    return isError;
}

int Titanes_getNivel(sTitanes* titanes, short* nivel){
    int isError = 1;
    if(titanes!=NULL){
        *nivel = titanes->nivel;
        isError = 0;
    }
    return isError;
}


// ## sTitanes: SETTERS
int Titanes_setHijos(sTitanes* titanes, int hijos){
    int isError = 1;
    if(titanes!=NULL){
        titanes->hijos = hijos;
        isError = 0;
    }
    return isError;
}

int Titanes_setNombre(sTitanes* titanes, char* nombre){
    int isError = 1;
    if(titanes!=NULL){
        strcpy(titanes->nombre,nombre);
        isError = 0;
    }
    return isError;
}

int Titanes_setPoder(sTitanes* titanes, float poder){
    int isError = 1;
    if(titanes!=NULL){
        titanes->poder = poder;
        isError = 0;
    }
    return isError;
}

int Titanes_setNivel(sTitanes* titanes, short nivel){
    int isError = 1;
    if(titanes!=NULL){
        titanes->nivel = nivel;
        isError = 0;
    }
    return isError;
}


// ## sTitanes: COMPARERS
// For use in a sort function - Compare titanes->hijos
int Titanes_compareHijos(void* titanes1, void* titanes2){
    int anw = 0;
    int hijos1_1;
    int hijos2_2;

    Titanes_getHijos(titanes1, &hijos1_1);
    Titanes_getHijos(titanes2, &hijos2_2);
    if(hijos1_1>hijos2_2){
        anw=1;
    }
    else if(hijos1_1<hijos2_2){
        anw=-1;
    }
    return anw;
}

// For use in a sort function - Compare titanes->nombre
int Titanes_compareNombre(void* titanes1, void* titanes2){
    int anw;
    char nombre1_1[8];
    char nombre2_2[8];

    Titanes_getNombre(titanes1, nombre1_1);
    Titanes_getNombre(titanes2, nombre2_2);

    anw = strcmp(nombre1_1,nombre2_2);
    return anw;
}

// For use in a sort function - Compare titanes->poder
int Titanes_comparePoder(void* titanes1, void* titanes2){
    int anw = 0;
    float poder1_1;
    float poder2_2;

    Titanes_getPoder(titanes1, &poder1_1);
    Titanes_getPoder(titanes2, &poder2_2);
    if(poder1_1>poder2_2){
        anw=1;
    }
    else if(poder1_1<poder2_2){
        anw=-1;
    }
    return anw;
}

// For use in a sort function - Compare titanes->nivel
int Titanes_compareNivel(void* titanes1, void* titanes2){
    int anw = 0;
    short nivel1_1;
    short nivel2_2;

    Titanes_getNivel(titanes1, &nivel1_1);
    Titanes_getNivel(titanes2, &nivel2_2);
    if(nivel1_1>nivel2_2){
        anw=1;
    }
    else if(nivel1_1<nivel2_2){
        anw=-1;
    }
    return anw;
}


void Titanes_delete(sTitanes* this){
    if(this!=NULL){
        free(this);
    }
}
