#include <nodoescritorio.h>

NodoEscritorio::NodoEscritorio(int num)
{
    this->numero = num;
    this->siguiente = nullptr;
    this->anterior = nullptr;
    this->Cola = new ColaPersonas();
    this->PersonasEnCola = 0;
}
