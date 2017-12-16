#ifndef NODOMANTENIMIENTO_H
#define NODOMANTENIMIENTO_H
#include <nodoavion.h>
#include <string>

typedef struct NodoMantenimiento NodoMantenimiento;

struct NodoMantenimiento
{
    int numero;
    string estado;
    NodoAvion* AvionActual;
    NodoMantenimiento* siguiente;
    NodoMantenimiento(int numero_);
};

#endif // NODOMANTENIMIENTO_H
