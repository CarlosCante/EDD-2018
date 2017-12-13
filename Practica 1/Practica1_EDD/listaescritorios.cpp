#include <listaescritorios.h>

using namespace std;

ListaEscritorios::ListaEscritorios()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
}

void ListaEscritorios::AgregarEscritorio(NodoEscritorio* nuevo)
{
    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;
    }
    else
    {
        NodoEscritorio* tmp = this->Primero;
        do {
            if(this->Primero == this->Ultimo)
            {
                this->Primero->siguiente = nuevo;
                nuevo->anterior = this->Primero;
                this->Ultimo = nuevo;
                free(tmp);
                return;
            }
            else if(tmp->siguiente == nullptr)
            {
                this->Ultimo->siguiente = nuevo;
                nuevo->anterior = this->Ultimo;
                this->Ultimo = nuevo;
                free(tmp);
                return;
            }
            else if(nuevo->numero > tmp->numero && nuevo->numero < tmp->siguiente->numero)
            {
                tmp->siguiente->anterior = nuevo;
                nuevo->siguiente = tmp->siguiente;
                tmp->siguiente = nuevo;
                nuevo->anterior = tmp;
                free(tmp);
                return;
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }
}

void ListaEscritorios::CargarEscritorios(int NoEscritorios)
{
    if(NoEscritorios > 0)
    {
        AgregarEscritorio(new NodoEscritorio(NoEscritorios));
        CargarEscritorios(NoEscritorios - 1);
    }
}

//bool ListaEscritorios::HayLugares()
//{
//    if(this->Primero != nullptr)
//    {
//        NodoEscritorio* tmp = this->Primero;
//        do {
//            if(tmp->PersonasEnCola < 10)
//            {
//                free(tmp);
//                return true;
//            }
//            tmp = tmp->siguiente;
//        } while (tmp != nullptr);
//        free(tmp);
//        return false;
//    }
//    return false;
//}

//void ListaEscritorios::CargarPersonas(ColaPersonas *colaper)
//{
//    NodoEscritorio* tmp = this->Primero;
//    while (HayLugares()) {

//        do {

//            if(tmp->PersonasEnCola < 10)
//            {
//                if(colaper->Primero != nullptr)
//                {
//                    tmp->Cola->IngresarPersona2(colaper->SacarPersona());
//                    tmp->PersonasEnCola++;
//                }
//            }
//            tmp = tmp->siguiente;

//        } while (tmp != nullptr);

//    }
//    free(tmp);
//}

string ListaEscritorios::GenerarSubgrafo()
{
    string subgrafo = "subgraph cluster_Escritorios{\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Lista de Escritorios\";\n";
    subgrafo += "color = blue;\n";

    if(this->Primero != nullptr)
    {
        NodoEscritorio* tmp = this->Primero;

        do {
            subgrafo += "\"Escritorio: " + to_string(tmp->numero) + "\"";
            if(tmp->siguiente != nullptr)
            {
                subgrafo += " -> ";

                subgrafo += "\"Escritorio: " + to_string(tmp->siguiente->numero) + "\"";

                subgrafo += "\n";

                subgrafo = subgrafo + "\"Escritorio: " + to_string(tmp->siguiente->numero) + "\"";

                subgrafo += " -> ";

                subgrafo += "\"Escritorio: " + to_string(tmp->numero) + "\"";
            }

            tmp = tmp->siguiente;
        } while (tmp != nullptr);
        free(tmp);
    }

    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
}
