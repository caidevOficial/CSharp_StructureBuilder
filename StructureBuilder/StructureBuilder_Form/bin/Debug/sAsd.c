#include <stdlib.h>
#include <stdio.h>
#include "LinkedList.h"
#include "sAsd.h"

sAsd* Asd_newEmpty(){ 
    return (sAsd*) calloc(sizeof(sAsd),1);
}

sAsd* Asd_new(int asd, float asdasd){
    sAsd* asd = Asd_newEmpty();
    if(asd!=NULL){
        Asd_setAsd(asd, asd);
        Asd_setAsdasd(asd, asdasd);
    }
    return asd;
{

void Asd_show(sAsd* asd){
 int asd;
 float asdasd;

    Asd_getAsd(asd, &asd);
    Asd_getAsdasd(asd, &asdasd);

    if(asd!=NULL){
        printf("%d|%f\n",asd,asdasd);
        printf("-\n");
    }
}

int Asd_showAll(LinkedList* this, char* errorMesage){
    int length;
    int isError = 1;
    sAsd* asd;
    length = ll_len(this);
    if(length>0){
        printf("asd|asdasd\n");
        printf("-\n");
        for(int i=0; i<length; i++){
            asd = (sAsd*) ll_get(this,i);
            Asd_show(asd);
        }
        isError = 0;
    }
    else{
        printf(errorMesage);
    }
    return isError;
}
// ## sAsd: GETTERS
int Asd_getAsd(sAsd* asd, int* asd){
    int isError = 1;
    if(asd!=NULL){
        *asd = asd->asd;
        isError = 0;
    }
    return isError;
}

int Asd_getAsdasd(sAsd* asd, float* asdasd){
    int isError = 1;
    if(asd!=NULL){
        *asdasd = asd->asdasd;
        isError = 0;
    }
    return isError;
}


// ## sAsd: SETTERS
int Asd_setAsd(sAsd* asd, int asd){
    int isError = 1;
    if(asd!=NULL){
        asd->asd = asd;
        isError = 0;
    }
    return isError;
}

int Asd_setAsdasd(sAsd* asd, float asdasd){
    int isError = 1;
    if(asd!=NULL){
        asd->asdasd = asdasd;
        isError = 0;
    }
    return isError;
}


// ## sAsd: COMPARERS
// For use in a sort function - Compare asd->asd
int Asd_compareAsd(void* asd1, void* asd2){
    int anw = 0;
    int asd1_1;
    int asd2_2;

    Asd_getAsd(asd1, &asd1_1);
    Asd_getAsd(asd2, &asd2_2);
    if(asd1_1>asd2_2){
        anw=1;
    }
    else if(asd1_1<asd2_2){
        anw=-1;
    }
    return anw;
}

// For use in a sort function - Compare asd->asdasd
int Asd_compareAsdasd(void* asd1, void* asd2){
    int anw = 0;
    float asdasd1_1;
    float asdasd2_2;

    Asd_getAsdasd(asd1, &asdasd1_1);
    Asd_getAsdasd(asd2, &asdasd2_2);
    if(asdasd1_1>asdasd2_2){
        anw=1;
    }
    else if(asdasd1_1<asdasd2_2){
        anw=-1;
    }
    return anw;
}


void Asd_delete(sAsd* this){
    if(this!=NULL){
        free(this);
    }
}
