#ifndef NODOAVION_H
#define NODOAVION_H
#include <stdio.h>
#include <stdlib.h>

using namespace std;

typedef struct NodoAvion NodoAvion;

struct NodoAvion
{
    int ID;
    int Turnos_D;
    int Turnos_M;
    int No_Pasajeros;

    NodoAvion* siguiente;
    NodoAvion* anterior;

    NodoAvion(int id, int turnosd, int turnosm, int nopasajeros);

};


#endif // NODOAVION_H
