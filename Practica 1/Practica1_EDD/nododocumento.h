#ifndef NODODOCUMENTO_H
#define NODODOCUMENTO_H

using namespace std;

typedef struct NodoDocumento NodoDocumento;

struct NodoDocumento
{
    int numero;
    int IdPersona;
    NodoDocumento* siguiente;

    NodoDocumento(int n, int idp);
};

#endif // NODODOCUMENTO_H
