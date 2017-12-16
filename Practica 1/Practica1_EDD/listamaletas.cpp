#include <listamaletas.h>

ListaMaletas::ListaMaletas()
{
    this->IdMaleta = 1;
    this->Primero = nullptr;
    this->Ultimo = nullptr;
}

void ListaMaletas::IngresarMaleta()
{
    NodoMaleta* nuevo = new NodoMaleta(IdMaleta);
    IdMaleta++;

    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;

        this->Ultimo->anterior = this->Primero;
        this->Ultimo->siguiente = this->Primero;

        this->Primero->siguiente = this->Ultimo;
        this->Primero->anterior = this->Ultimo;

    }
    else if(this->Primero == this->Ultimo)
    {
        this->Ultimo = nuevo;
        this->Ultimo->anterior = this->Primero;
        this->Ultimo->siguiente = this->Primero;

        this->Primero->siguiente = this->Ultimo;
        this->Primero->anterior = this->Ultimo;
        return;
    }
    else
    {
        this->Ultimo->siguiente = nuevo;
        nuevo->anterior = this->Ultimo;

        this->Ultimo = nuevo;

        this->Ultimo->siguiente = this->Primero;
        this->Primero->anterior = this->Ultimo;


    }
}

void ListaMaletas::CargarMaletas(int NoMaletas)
{
    for(int i = 0 ; i < NoMaletas ; i++)
    {
        IngresarMaleta();
    }
}

void ListaMaletas::PopMaleta()
{
    if(this->Primero != nullptr)
    {
        if(this->Primero == this->Ultimo)
        {
            this->Primero = nullptr;
            this->Ultimo = nullptr;
            return;
        }
        else if(this->Primero->siguiente == this->Ultimo)
        {
            this->Primero = this->Ultimo;
            this->Primero->anterior = this->Ultimo;
            this->Ultimo->siguiente = this->Primero;
            return;
        }

        this->Primero = this->Primero->siguiente;

        this->Ultimo->siguiente = this->Primero;
        this->Primero->anterior = this->Ultimo;


    }
}

void ListaMaletas::SacarMaletas(int Cantidad)
{
    for(int i = 0 ; i < Cantidad ; i++)
    {
        PopMaleta();
    }
}

string ListaMaletas::GenerarSubGrafo()
{
    string subgrafo = "subgraph cluster_Maletas{\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Lista de Maletas\";\n";
    subgrafo += "color = blue;\n";

    if(this->Primero != nullptr)
    {
        NodoMaleta* tmp = this->Primero;

        do {

            subgrafo += "\"Maleta: " + to_string(tmp->id) + "\"";
            if(tmp->siguiente != this->Primero)
            {
                subgrafo += " -> ";

                subgrafo += "\"Maleta: " + to_string(tmp->siguiente->id) + "\"";

                subgrafo += "\n";

                subgrafo = subgrafo + "\"Maleta: " + to_string(tmp->siguiente->id) + "\"";

                subgrafo += " -> ";

                subgrafo += "\"Maleta: " + to_string(tmp->id) + "\"";
            }

            tmp = tmp->siguiente;
        } while (tmp != this->Primero);
        subgrafo += "\n";

        subgrafo += "\"Maleta: " + to_string(this->Primero->id) + "\"";
        subgrafo += " -> ";
        subgrafo += "\"Maleta: " + to_string(this->Ultimo->id) + "\"";

        subgrafo += "\n";

        subgrafo = subgrafo + "\"Maleta: " + to_string(this->Ultimo->id) + "\"";
        subgrafo += " -> ";
        subgrafo += "\"Maleta: " + to_string(this->Primero->id) + "\"";

    }


    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
}

int ListaMaletas::CantidadDeMaletas()
{
    int Cantidad = 0;

    if(this->Primero != nullptr)
    {
        NodoMaleta* tmp = this->Primero;
        do {
            Cantidad++;
            tmp = tmp->siguiente;
        } while (tmp != this->Primero);
    }

    return Cantidad;
}
