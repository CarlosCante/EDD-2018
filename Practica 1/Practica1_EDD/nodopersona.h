#ifndef NODOPERSONA_H
#define NODOPERSONA_H
#include <numeroaleatorio.h>

using namespace std;

typedef struct NodoPersona NodoPersona;

struct NodoPersona
{
    int IDPersona;
    int NoMaletas;
    int NoDocumentos;
    int NoTurnosR;

    NodoPersona* siguiente;

    NodoPersona(int id, int maletas, int doc, int turnosr);
};

#endif // NODOPERSONA_H
