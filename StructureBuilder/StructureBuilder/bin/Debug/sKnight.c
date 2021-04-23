
sKnight* Knight_newEmpty(){ 
    return (sKnight*) calloc(sizeof(sKnight),1);
}

sKnight* Knight_new(int cosmos, char* armor, float power){
    sKnight* knight = Knight_newEmpty();
    if(knight!=NULL){
        Knight_setCosmos(knight, cosmos);
        Knight_setArmor(knight, armor);
        Knight_setPower(knight, power);
    }
    return knight;
{

void Knight_show(sKnight* knight){
 int cosmos;
 char armor[5];
 float power;

    Knight_getCosmos(knight, &cosmos);
    Knight_getArmor(knight, armor);
    Knight_getPower(knight, &power);

    if(knight!=NULL){
        printf("%d|%s|%f\n",cosmos,armor,power);
        printf("-\n");
    }
}

int Knight_showAll(LinkedList* this, char* errorMesage){
    int length;
    int isError = 1;
    sKnight* knight;
    length = ll_len(this);
    if(length>0){
        printf("cosmos|armor|power\n");
        printf("-\n");
        for(int i=0; i<length; i++){
            knight = (sKnight*) ll_get(this,i);
            Knight_show(knight);
        }
        isError = 0;
    }
    else{
        printf(errorMesage);
    }
    return isError;
}
// ## sKnight: GETTERS
int Knight_getCosmos(sKnight* knight, int* cosmos){
    int isError = 1;
    if(knight!=NULL){
        *cosmos = knight->cosmos;
        isError = 0;
    }
    return isError;
}

int Knight_getArmor(sKnight* knight, char* armor){
    int isError = 1;
    if(knight!=NULL){
        strcpy(armor,knight->armor);
        isError = 0;
    }
    return isError;
}

int Knight_getPower(sKnight* knight, float* power){
    int isError = 1;
    if(knight!=NULL){
        *power = knight->power;
        isError = 0;
    }
    return isError;
}


// ## sKnight: SETTERS
int Knight_setCosmos(sKnight* knight, int cosmos){
    int isError = 1;
    if(knight!=NULL){
        knight->cosmos = cosmos;
        isError = 0;
    }
    return isError;
}

int Knight_setArmor(sKnight* knight, char* armor){
    int isError = 1;
    if(knight!=NULL){
        strcpy(knight->armor,armor);
        isError = 0;
    }
    return isError;
}

int Knight_setPower(sKnight* knight, float power){
    int isError = 1;
    if(knight!=NULL){
        knight->power = power;
        isError = 0;
    }
    return isError;
}


// ## sKnight: COMPARERS
// For use in a sort function - Compare knight->cosmos
int Knight_compareCosmos(void* knight1, void* knight2){
    int anw = 0;
    int cosmos1_1;
    int cosmos2_2;

    Knight_getCosmos(knight1, &cosmos1_1);
    Knight_getCosmos(knight2, &cosmos2_2);
    if(cosmos1_1>cosmos2_2){
        anw=1;
    }
    else if(cosmos1_1<cosmos2_2){
        anw=-1;
    }
    return anw;
}

// For use in a sort function - Compare knight->armor
int Knight_compareArmor(void* knight1, void* knight2){
    int anw;
    char armor1_1[5];
    char armor2_2[5];

    Knight_getArmor(knight1, armor1_1);
    Knight_getArmor(knight2, armor2_2);

    anw = strcmp(armor1_1,armor2_2);
    return anw;
}

// For use in a sort function - Compare knight->power
int Knight_comparePower(void* knight1, void* knight2){
    int anw = 0;
    float power1_1;
    float power2_2;

    Knight_getPower(knight1, &power1_1);
    Knight_getPower(knight2, &power2_2);
    if(power1_1>power2_2){
        anw=1;
    }
    else if(power1_1<power2_2){
        anw=-1;
    }
    return anw;
}


