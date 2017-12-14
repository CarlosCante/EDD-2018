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
    }
    else
    {
       this->Ultimo->siguiente = nuevo;
       nuevo->anterior = this->Ultimo;
       this->Ultimo = nuevo;
//       this->Ultimo->siguiente = this->Primero;
//       this->Primero->anterior = this->Ultimo;
    }
}

void ListaMaletas::CargarMaletas(int NoMaletas)
{
    if(NoMaletas > 0)
    {
        CargarMaletas(NoMaletas - 1);
        IngresarMaleta();
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
            if(tmp->siguiente != nullptr)
            {
                subgrafo += " -> ";

                subgrafo += "\"Maleta: " + to_string(tmp->siguiente->id) + "\"";

                subgrafo += "\n";

                subgrafo = subgrafo + "\"Maleta: " + to_string(tmp->siguiente->id) + "\"";

                subgrafo += " -> ";

                subgrafo += "\"Maleta: " + to_string(tmp->id) + "\"";
            }

            tmp = tmp->siguiente;
        } while (tmp != nullptr);
        free(tmp);
        subgrafo += "\n";
        subgrafo += "\"Maleta: " + to_string(this->Primero->id) + "\" -> \"Maleta: " + to_string(this->Ultimo->id) + "\"\n" ;
        subgrafo += "\"Maleta: " + to_string(this->Ultimo->id) + "\" -> \"Maleta: " + to_string(this->Primero->id) + "\"\n" ;
    }

    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
}
