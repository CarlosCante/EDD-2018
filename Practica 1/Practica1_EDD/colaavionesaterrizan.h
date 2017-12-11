#ifndef COLAAVIONESATERRIZAN_H
#define COLAAVIONESATERRIZAN_H
#include <nodoavion.h>
#include <numeroaleatorio.h>

using namespace std;

typedef struct ColaAvionesAterrizan ColaAvionesAterrizan;

struct ColaAvionesAterrizan
{
    NodoAvion* Primero;
    NodoAvion* Ultimo;
    int IDAvion = 1;

    ColaAvionesAterrizan();
    void IngresarAvion();
    NodoAvion* CrearAvion();
    NodoAvion* SacarAvion();
    string GenerarSubGrafo();
};

#endif // COLAAVIONESATERRIZAN_H
