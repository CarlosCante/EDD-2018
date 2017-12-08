#include <colaavionesaterrizan.h>


ColaAvionesAterrizan::ColaAvionesAterrizan()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
}

void ColaAvionesAterrizan::IngresarAvion(NodoAvion *nuevo)
{
    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;
    }
    else
    {
        nuevo->siguiente = this->Primero;
        this->Primero->anterior = nuevo;
        this->Primero = nuevo;
    }
}

NodoAvion* ColaAvionesAterrizan::SacarAvion()
{
    if(this->Ultimo == nullptr)
        return nullptr;

    NodoAvion* tmp = this->Ultimo;
    NodoAvion* tmp2 = this->Ultimo->anterior;

    tmp2->siguiente = nullptr;
    tmp->anterior = nullptr;

    this->Ultimo = tmp2;

    return tmp;
}

