#include <nodopersona.h>

NodoPersona::NodoPersona(int id, int maletas, int doc, int turnosr)
{
    this->IDPersona = id;
    this->NoMaletas = maletas;
    this->NoDocumentos = doc;
    this->NoTurnosR = turnosr;

    this->siguiente = nullptr;
}
