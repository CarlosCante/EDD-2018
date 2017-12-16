#ifndef PILADOCUMENTOS_H
#define PILADOCUMENTOS_H
#include <nododocumento.h>
#include <string>

typedef struct PilaDocumentos PilaDocumentos;

struct PilaDocumentos
{
    NodoDocumento* cima;
    PilaDocumentos();
    void PilaPush(int num, int id);
    void PilaPop();
    int Tamano();

    string GenerarSubGrafo(int id);
};

#endif // PILADOCUMENTOS_H
