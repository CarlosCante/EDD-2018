#ifndef COLAAVIONESATERRIZAN_H
#define COLAAVIONESATERRIZAN_H
#include <nodoavion.h>

using namespace std;

typedef struct ColaAvionesAterrizan ColaAvionesAterrizan;

struct ColaAvionesAterrizan
{
    NodoAvion* Primero;
    NodoAvion* Ultimo;

    ColaAvionesAterrizan();
    void IngresarAvion(NodoAvion* nuevo);
    NodoAvion* SacarAvion();
};

#endif // COLAAVIONESATERRIZAN_H
