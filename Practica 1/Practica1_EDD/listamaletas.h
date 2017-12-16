#ifndef LISTAMALETAS_H
#define LISTAMALETAS_H
#include <nodomaleta.h>
#include <string>

using namespace std;

typedef struct ListaMaletas ListaMaletas;

struct ListaMaletas
{
      int IdMaleta;

      NodoMaleta* Primero;
      NodoMaleta* Ultimo;

      ListaMaletas();
      void IngresarMaleta();
      void CargarMaletas(int NoMaletas);
      void SacarMaletas(int Cantidad);
      void PopMaleta();

      string GenerarSubGrafo();

      int CantidadDeMaletas();
};

#endif // LISTAMALETAS_H
