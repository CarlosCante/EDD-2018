#ifndef COLAPERSONAS_H
#define COLAPERSONAS_H
#include <nodopersona.h>

using namespace std;

typedef struct ColaPersonas ColaPersonas;

struct ColaPersonas
{
    NodoPersona* Primero;
    NodoPersona* Ultimo;
    int IDPersona = 1;

    ColaPersonas();
    void IngresarPersona();
    void IngresarPersona2(NodoPersona* nueva);
    void CargarPasajeros(int Cantidad);
    NodoPersona* GenerarPersona();
    NodoPersona* SacarPersona();
    string GenerarSubGrafo(int NumeroCola);
};

#endif // COLAPERSONAS_H
