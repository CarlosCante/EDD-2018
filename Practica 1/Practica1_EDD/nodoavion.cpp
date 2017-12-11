#include <nodoavion.h>

NodoAvion::NodoAvion(int id, int turnosd, int turnosm, int nopasajeros)
{
    this->ID = id;
    this->Turnos_D = turnosd;
    this->Turnos_M = turnosm;
    this->No_Pasajeros = nopasajeros;

    this->siguiente = nullptr;
    this->anterior = nullptr;
}
