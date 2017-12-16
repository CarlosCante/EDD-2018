#include <nodoescritorio.h>

NodoEscritorio::NodoEscritorio(int num)
{
    this->numero = num;
    this->PersonaActual = nullptr;
    this->PersonasEnCola = 0;
    this->siguiente = nullptr;
    this->anterior = nullptr;
    this->Pila = new PilaDocumentos();
    this->Cola = new ColaPersonas();

}

void NodoEscritorio::AnadirDocumentos(int numero, int id)
{
    for(int i = 0 ; i < numero ; i++)
    {
        this->Pila->PilaPush(i,id);
    }
}

void NodoEscritorio::SacarDocumentos(int numero)
{
    for(int i = 0 ; i < numero ; i++)
    {
        this->Pila->PilaPop();
    }
}
