#include <nodomantenimiento.h>

NodoMantenimiento::NodoMantenimiento(int numero_)
{
    this->numero = numero_;
    this->estado = "Libre";
    this->AvionActual = nullptr;
    this->siguiente = nullptr;
}
