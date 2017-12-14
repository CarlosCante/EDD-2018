#ifndef NODOMALETA_H
#define NODOMALETA_H

typedef struct NodoMaleta NodoMaleta;

struct NodoMaleta
{
    int id;

    NodoMaleta* siguiente;
    NodoMaleta* anterior;
    NodoMaleta(int id_);
};

#endif // NODOMALETA_H
