#include <colaavionesaterrizan.h>
#include <string>


ColaAvionesAterrizan::ColaAvionesAterrizan()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
}

void ColaAvionesAterrizan::IngresarAvion()
{
    NodoAvion* nuevo = CrearAvion();

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

NodoAvion* ColaAvionesAterrizan::CrearAvion()
{
    int turnosd = GenerarNumero(1,3);
    int turnosm;
    int pasajeros;

    switch (turnosd) {
    case 1:
        turnosm = GenerarNumero(1,3);
        pasajeros = GenerarNumero(5,10);
        break;
    case 2:
        turnosm = GenerarNumero(2,4);
        pasajeros = GenerarNumero(15,25);
        break;
    case 3:
        turnosm = GenerarNumero(3,6);
        pasajeros = GenerarNumero(30,40);
        break;
    default:
        break;
    }

    NodoAvion* tmp = new NodoAvion(IDAvion,turnosd,turnosm,pasajeros);
    IDAvion++;
    return tmp;

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

string ColaAvionesAterrizan::GenerarSubGrafo()
{
    string subgrafo = "subgraph cluster_ColaAvionesLlegan {\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Llegada de Aviones\";\n";
    subgrafo += "color = blue;\n";

    NodoAvion* aux = this->Primero;

    do {
        subgrafo += "\"Avion " + to_string(aux->ID) + "\n";
        subgrafo += "Turdos Desabordaje: " + to_string(aux->Turnos_D) + "\n";
        subgrafo += "Numero Pasajeros: " + to_string(aux->No_Pasajeros) + "\n";
        subgrafo += "Turdos Mantenimiento: " + to_string(aux->Turnos_M) + "\"";

        if(aux->siguiente != nullptr)
        {
            subgrafo += " -> ";

            subgrafo += "\"Avion " + to_string(aux->siguiente->ID) + "\n";
            subgrafo += "Turdos Desabordaje: " + to_string(aux->siguiente->Turnos_D) + "\n";
            subgrafo += "Numero Pasajeros: " + to_string(aux->siguiente->No_Pasajeros) + "\n";
            subgrafo += "Turdos Mantenimiento: " + to_string(aux->siguiente->Turnos_M) + "\"";

            subgrafo += "\n";

            subgrafo = subgrafo + "\"Avion " + to_string(aux->siguiente->ID) + "\n";
            subgrafo += "Turdos Desabordaje: " + to_string(aux->siguiente->Turnos_D) + "\n";
            subgrafo += "Numero Pasajeros: " + to_string(aux->siguiente->No_Pasajeros) + "\n";
            subgrafo += "Turdos Mantenimiento: " + to_string(aux->siguiente->Turnos_M) + "\"";

            subgrafo += " -> ";

            subgrafo += "\"Avion " + to_string(aux->ID) + "\n";
            subgrafo += "Turdos Desabordaje: " + to_string(aux->Turnos_D) + "\n";
            subgrafo += "Numero Pasajeros: " + to_string(aux->No_Pasajeros) + "\n";
            subgrafo += "Turdos Mantenimiento: " + to_string(aux->Turnos_M) + "\"";

        }

        aux = aux->siguiente;
    } while (aux != nullptr);

    free(aux);

    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
}

