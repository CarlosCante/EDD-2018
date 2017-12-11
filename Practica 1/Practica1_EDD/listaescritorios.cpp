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
            if(nuevo->numero > tmp->numero && nuevo->numero < tmp->siguiente->numero)//Se ingresa en medio de dos nodos
            {
                tmp->siguiente->anterior = nuevo;
                nuevo->siguiente = tmp->siguiente;
                tmp->siguiente = nuevo;
                nuevo->anterior = tmp;
                free(tmp);
                return;
            }
            else if(tmp->siguiente == nullptr)//Se ingresa al final de la lista
            {
                tmp->siguiente = nuevo;
                nuevo->anterior = tmp;
                this->Ultimo = nuevo;
                free(tmp);
                return;
            }
            else if(this->Primero == this->Ultimo)//Solo hay un elemento en la lista
            {
                this->Primero->siguiente = nuevo;
                nuevo->anterior = this->Primero;
                this->Ultimo = nuevo;
                free(tmp);
                return;
            }

            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }
}

void ListaEscritorios::CargarEscritorios(int NoEscritorios)
{
    for(int i = 0 ; i < NoEscritorios ; i++)
    {
        AgregarEscritorio(new NodoEscritorio(i));
    }
}

bool ListaEscritorios::HayLugares()
{
    if(this->Primero != nullptr)
    {
        NodoEscritorio* tmp = this->Primero;
        do {
            if(tmp->PersonasEnCola < 10)
            {
                free(tmp);
                return true;
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
        free(tmp);
        return false;
    }
    return false;
}

void ListaEscritorios::CargarPersonas(ColaPersonas *colaper)
{
    NodoEscritorio* tmp = this->Primero;
    while (HayLugares()) {

        do {

            if(tmp->PersonasEnCola < 10)
            {
                if(colaper->Primero != nullptr)
                {
                    tmp->Cola->IngresarPersona2(colaper->SacarPersona());
                    tmp->PersonasEnCola++;
                }
            }
            tmp = tmp->siguiente;

        } while (tmp != nullptr);

    }
    free(tmp);
}
