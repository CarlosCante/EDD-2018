#ifndef LISTAESCRITORIOS_H
#define LISTAESCRITORIOS_H
#include <nodoescritorio.h>


using namespace std;

typedef struct ListaEscritorios ListaEscritorios;

struct ListaEscritorios
{
    NodoEscritorio* Primero;
    NodoEscritorio* Ultimo;

    ListaEscritorios();

    void AgregarEscritorio(NodoEscritorio *nuevo);

    void CargarEscritorios(int NoEscritorios);

    string GenerarSubgrafo();

    void CargarPersonas(ColaPersonas* colaper);

    bool HayLugares();
};

#endif // LISTAESCRITORIOS_H
