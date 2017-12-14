#include <nodoescritorio.h>

NodoEscritorio::NodoEscritorio(int num)
{
    this->numero = num;
    this->PersonasEnCola = 0;
    this->siguiente = nullptr;
    this->anterior = nullptr;
    this->Cola = new ColaPersonas();

}
