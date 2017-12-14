#include <nodomaleta.h>

NodoMaleta::NodoMaleta(int id_)
{
    this->id = id_;
    this->siguiente = nullptr;
    this->anterior = nullptr;
}
