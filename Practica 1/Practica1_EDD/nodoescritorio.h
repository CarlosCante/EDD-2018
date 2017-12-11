#ifndef NODOESCRITORIO_H
#define NODOESCRITORIO_H
#include <colapersonas.h>

using namespace std;

typedef struct NodoEscritorio NodoEscritorio;

struct NodoEscritorio
{
    int numero;
    ColaPersonas* Cola;
    int PersonasEnCola;

    NodoEscritorio* siguiente;
    NodoEscritorio* anterior;

    NodoEscritorio(int num);
};

#endif // NODOESCRITORIO_H
