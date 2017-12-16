#ifndef LISTAMANTENIMIENTO_H
#define LISTAMANTENIMIENTO_H
#include <nodomantenimiento.h>
#include <string>
#include <QString>


typedef struct ListaMantenimiento ListaMantenimiento;
typedef struct ColaAviones ColaAviones;

struct ListaMantenimiento
{
    NodoMantenimiento* Primero;
    NodoMantenimiento* Ultimo;

    ColaAviones* ColaAv;
    ListaMantenimiento();
    void CargarAviones();
    void IngresarEstacion(int id);
    void CargarEstaciones(int n);
    string GenerarSubGrafo();
    bool HayEspacio();

    void PasarTurnoMAntenimiento();

    QString EstadoActual();
};

struct ColaAviones
{
    NodoAvion* Primero;
    NodoAvion* Ultimo;

    ColaAviones();
    void IngresarAvion(NodoAvion* nuevo);
    NodoAvion* SacarAvion();
    bool EstaVacia();
    string GenerarSubGrafo();
};

#endif // LISTAMANTENIMIENTO_H
