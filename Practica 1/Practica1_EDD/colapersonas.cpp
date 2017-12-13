#include <colapersonas.h>

using namespace std;

ColaPersonas::ColaPersonas()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
}

NodoPersona* ColaPersonas::GenerarPersona()
{
    int NoMaletas = GenerarNumero(1,4);
    int NoDocumentos = GenerarNumero(1,10);
    int NTR = GenerarNumero(1,3);

    NodoPersona* tmp = new NodoPersona(IDPersona,NoMaletas,NoDocumentos,NTR);
    IDPersona++;
    return tmp;
}

void ColaPersonas::IngresarPersona()
{
    NodoPersona* nuevo = GenerarPersona();

    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;
    }
    else
    {
        nuevo->siguiente = this->Primero;
        this->Primero = nuevo;
    }
}

void ColaPersonas::IngresarPersona2(NodoPersona *nueva)
{
    if(this->Primero == nullptr)
    {
        this->Primero = nueva;
        this->Ultimo = nueva;
    }
    else
    {
        nueva->siguiente = this->Primero;
        this->Primero = nueva;
    }
}

void ColaPersonas::CargarPasajeros(int Cantidad)
{
    if(Cantidad > 0)
    {
        IngresarPersona();
        CargarPasajeros(Cantidad - 1);
    }
}

NodoPersona* ColaPersonas::SacarPersona()
{
    if(this->Primero != nullptr)
    {
        NodoPersona* tmp = this->Primero;
        if(this->Primero == this->Ultimo)
        {
            this->Primero = nullptr;
            this->Ultimo = nullptr;
            return tmp;
        }
        else
        {
            while (tmp->siguiente != this->Ultimo) {
                tmp = tmp->siguiente;
            }

            NodoPersona* tmp2 = this->Ultimo;

            this->Ultimo = tmp;
            this->Ultimo->siguiente = nullptr;
            free(tmp);

            return tmp2;
        }
    }
    return nullptr;
}

string ColaPersonas::GenerarSubGrafo(int NumeroCola)
{
    string subgrafo = "subgraph cluster_ColaPersonas" + to_string(NumeroCola) + "{\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Cola de Personas\";\n";
    subgrafo += "color = blue;\n";

    if(this->Primero != nullptr)
    {
        NodoPersona* aux = this->Primero;

        do {
            subgrafo += "\"Persona " + to_string(aux->IDPersona) + "\n";
            subgrafo += "No. Maletas: " + to_string(aux->NoMaletas) + "\n";
            subgrafo += "No. Documentos: " + to_string(aux->NoDocumentos) + "\n";
            subgrafo += "Turdos para Registro: " + to_string(aux->NoTurnosR) + "\"";

            if(aux->siguiente != nullptr)
            {
                subgrafo += " -> ";

                subgrafo += "\"Persona " + to_string(aux->siguiente->IDPersona) + "\n";
                subgrafo += "No. Maletas: " + to_string(aux->siguiente->NoMaletas) + "\n";
                subgrafo += "No. Documentos: " + to_string(aux->siguiente->NoDocumentos) + "\n";
                subgrafo += "Turdos para Registro: " + to_string(aux->siguiente->NoTurnosR) + "\"";

            }

            aux = aux->siguiente;
        } while (aux != nullptr);

        free(aux);
    }

    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
}
