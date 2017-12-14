#ifndef COLAPERSONAS_H
#define COLAPERSONAS_H
#include <nodopersona.h>
#include <listamaletas.h>

using namespace std;

typedef struct ColaPersonas ColaPersonas;

struct ColaPersonas
{
    NodoPersona* Primero;
    NodoPersona* Ultimo;
    int IDPersona = 1;

    ColaPersonas();
    void IngresarPersona(ListaMaletas* l);
    void IngresarPersona2(NodoPersona* nueva);
    void CargarPasajeros(int Cantidad, ListaMaletas* l );
    NodoPersona* GenerarPersona();
    NodoPersona* SacarPersona();
    string GenerarSubGrafo(int NumeroCola);
};

#endif // COLAPERSONAS_H
