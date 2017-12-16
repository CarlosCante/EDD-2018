#ifndef LISTAESCRITORIOS_H
#define LISTAESCRITORIOS_H
#include <nodoescritorio.h>
#include <listamaletas.h>
#include <QString>


using namespace std;

typedef struct ListaEscritorios ListaEscritorios;

struct ListaEscritorios
{
    NodoEscritorio* Primero;
    NodoEscritorio* Ultimo;
    int IdDocumentos;

    ListaEscritorios();

    void AgregarEscritorio(int id);
    void CargarEscritorios(int NoEscritorios);
    string GenerarSubgrafo();

    void CargarPersonas(ColaPersonas* colageneral);
    bool HayEspacio();

    void PasarTurno(ListaMaletas* l);

    QString EstadoActual();
};

#endif // LISTAESCRITORIOS_H
