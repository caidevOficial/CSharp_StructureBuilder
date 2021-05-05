#include <stdlib.h>
#include <stdio.h>
#include "LinkedList.h"
#include "sQwe.h"

sQwe* Qwe_newEmpty(){ 
    return (sQwe*) calloc(sizeof(sQwe),1);
}

sQwe* Qwe_new(int qweqwe){
    sQwe* qwe = Qwe_newEmpty();
    if(qwe!=NULL){
        Qwe_setQweqwe(qwe, qweqwe);
    }
    return qwe;
{

void Qwe_show(sQwe* qwe){
 int qweqwe;

    Qwe_getQweqwe(qwe, &qweqwe);

    if(qwe!=NULL){
        printf("%d\n",qweqwe);
        printf("-\n");
    }
}

int Qwe_showAll(LinkedList* this, char* errorMesage){
    int length;
    int isError = 1;
    sQwe* qwe;
    length = ll_len(this);
    if(length>0){
        printf("qweqwe\n");
        printf("-\n");
        for(int i=0; i<length; i++){
            qwe = (sQwe*) ll_get(this,i);
            Qwe_show(qwe);
        }
        isError = 0;
    }
    else{
        printf(errorMesage);
    }
    return isError;
}
// ## sQwe: GETTERS
int Qwe_getQweqwe(sQwe* qwe, int* qweqwe){
    int isError = 1;
    if(qwe!=NULL){
        *qweqwe = qwe->qweqwe;
        isError = 0;
    }
    return isError;
}


// ## sQwe: SETTERS
int Qwe_setQweqwe(sQwe* qwe, int qweqwe){
    int isError = 1;
    if(qwe!=NULL){
        qwe->qweqwe = qweqwe;
        isError = 0;
    }
    return isError;
}


// ## sQwe: COMPARERS
// For use in a sort function - Compare qwe->qweqwe
int Qwe_compareQweqwe(void* qwe1, void* qwe2){
    int anw = 0;
    int qweqwe1_1;
    int qweqwe2_2;

    Qwe_getQweqwe(qwe1, &qweqwe1_1);
    Qwe_getQweqwe(qwe2, &qweqwe2_2);
    if(qweqwe1_1>qweqwe2_2){
        anw=1;
    }
    else if(qweqwe1_1<qweqwe2_2){
        anw=-1;
    }
    return anw;
}


void Qwe_delete(sQwe* this){
    if(this!=NULL){
        free(this);
    }
}
