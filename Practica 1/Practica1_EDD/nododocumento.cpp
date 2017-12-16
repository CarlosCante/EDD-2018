#include <nododocumento.h>

NodoDocumento::NodoDocumento(int n, int idp)
{
    this->numero = n;
    this->IdPersona = idp;
    this->siguiente =  nullptr;
}
