
sBarco* Barco_newEmpty(){ 
    return (sBarco*) calloc(sizeof(sBarco),1);
}

sBarco* Barco_new(float velocidad, int metros, char* nombre){
    sBarco* barco = Barco_newEmpty();
    if(barco!=NULL){
        Barco_setVelocidad(barco, velocidad);
        Barco_setMetros(barco, metros);
        Barco_setNombre(barco, nombre);
    }
    return barco;
{

void Barco_show(sBarco* barco){
 float velocidad;
 int metros;
 char nombre[5];

    Barco_getVelocidad(barco, &velocidad);
    Barco_getMetros(barco, &metros);
    Barco_getNombre(barco, nombre);

    if(barco!=NULL){
        printf("%f|%d|%s\n",velocidad,metros,nombre);
        printf("-\n");
    }
}

int Barco_showAll(LinkedList* this, char* errorMesage){
    int length;
    int isError = 1;
    sBarco* barco;
    length = ll_len(this);
    if(length>0){
        printf("velocidad|metros|nombre\n");
        printf("-\n");
        for(int i=0; i<length; i++){
            barco = (sBarco*) ll_get(this,i);
            Barco_show(barco);
        }
        isError = 0;
    }
    else{
        printf(errorMesage);
    }
    return isError;
}
// ## sBarco: GETTERS
int Barco_getVelocidad(sBarco* barco, float* velocidad){
    int isError = 1;
    if(barco!=NULL){
        *velocidad = barco->velocidad;
        isError = 0;
    }
    return isError;
}

int Barco_getMetros(sBarco* barco, int* metros){
    int isError = 1;
    if(barco!=NULL){
        *metros = barco->metros;
        isError = 0;
    }
    return isError;
}

int Barco_getNombre(sBarco* barco, char* nombre){
    int isError = 1;
    if(barco!=NULL){
        strcpy(nombre,barco->nombre);
        isError = 0;
    }
    return isError;
}


// ## sBarco: SETTERS
int Barco_setVelocidad(sBarco* barco, float velocidad){
    int isError = 1;
    if(barco!=NULL){
        barco->velocidad = velocidad;
        isError = 0;
    }
    return isError;
}

int Barco_setMetros(sBarco* barco, int metros){
    int isError = 1;
    if(barco!=NULL){
        barco->metros = metros;
        isError = 0;
    }
    return isError;
}

int Barco_setNombre(sBarco* barco, char* nombre){
    int isError = 1;
    if(barco!=NULL){
        strcpy(barco->nombre,nombre);
        isError = 0;
    }
    return isError;
}


// ## sBarco: COMPARERS
// For use in a sort function - Compare barco->velocidad
int Barco_compareVelocidad(void* barco1, void* barco2){
    int anw = 0;
    float velocidad1_1;
    float velocidad2_2;

    Barco_getVelocidad(barco1, &velocidad1_1);
    Barco_getVelocidad(barco2, &velocidad2_2);
    if(velocidad1_1>velocidad2_2){
        anw=1;
    }
    else if(velocidad1_1<velocidad2_2){
        anw=-1;
    }
    return anw;
}

// For use in a sort function - Compare barco->metros
int Barco_compareMetros(void* barco1, void* barco2){
    int anw = 0;
    int metros1_1;
    int metros2_2;

    Barco_getMetros(barco1, &metros1_1);
    Barco_getMetros(barco2, &metros2_2);
    if(metros1_1>metros2_2){
        anw=1;
    }
    else if(metros1_1<metros2_2){
        anw=-1;
    }
    return anw;
}

// For use in a sort function - Compare barco->nombre
int Barco_compareNombre(void* barco1, void* barco2){
    int anw;
    char nombre1_1[5];
    char nombre2_2[5];

    Barco_getNombre(barco1, nombre1_1);
    Barco_getNombre(barco2, nombre2_2);

    anw = strcmp(nombre1_1,nombre2_2);
    return anw;
}


