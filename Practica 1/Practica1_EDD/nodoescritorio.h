#ifndef NODOESCRITORIO_H
#define NODOESCRITORIO_H
#include <colapersonas.h>
#include <stdio.h>
#include <stdlib.h>


using namespace std;

typedef struct NodoEscritorio NodoEscritorio;

struct NodoEscritorio
{
    int numero;
    int PersonasEnCola;
    ColaPersonas* Cola;

    NodoEscritorio* siguiente;
    NodoEscritorio* anterior;

    NodoEscritorio(int num);
};

#endif // NODOESCRITORIO_H
