#ifndef NODOESCRITORIO_H
#define NODOESCRITORIO_H
#include <colapersonas.h>
#include <nodopersona.h>
#include <piladocumentos.h>
#include <stdio.h>
#include <stdlib.h>


using namespace std;

typedef struct NodoEscritorio NodoEscritorio;

struct NodoEscritorio
{
    int numero;
    int PersonasEnCola;
    NodoPersona* PersonaActual;
    ColaPersonas* Cola;
    PilaDocumentos* Pila;

    NodoEscritorio* siguiente;
    NodoEscritorio* anterior;

    NodoEscritorio(int num);
    void AnadirDocumentos(int numero, int id);
    void SacarDocumentos(int numero);
};

#endif // NODOESCRITORIO_H
