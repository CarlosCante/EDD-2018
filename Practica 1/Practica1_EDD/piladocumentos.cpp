#include <piladocumentos.h>

PilaDocumentos::PilaDocumentos()
{
    this->cima = nullptr;
}

void PilaDocumentos::PilaPush(int num, int id)
{
    NodoDocumento* nuevo = new NodoDocumento(num,id);
    if(this->cima == nullptr)
    {
        this->cima = nuevo;
    }
    else
    {
        nuevo->siguiente = this->cima;
        this->cima = nuevo;
    }
}

void PilaDocumentos::PilaPop()
{
    if(this->cima != nullptr)
    {
        if(this->cima->siguiente == nullptr)
        {
            this->cima = nullptr;
            return;
        }
        else
        {
            NodoDocumento* tmp = this->cima;
            this->cima = tmp->siguiente;
            tmp->siguiente = nullptr;
            return;
        }
    }
}

int PilaDocumentos::Tamano()
{
    int t = 0;
    if(this->cima != nullptr)
    {
        NodoDocumento* tmp = this->cima;
        do {
            t++;
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }
    return t;
}

string PilaDocumentos::GenerarSubGrafo(int id)
{
    string subgrafo = "";

    if(this->cima != nullptr)
    {
        subgrafo += "\"Pila Escritorio: " + to_string(id) + "\n";
        subgrafo += "Documentos en la pila: " + to_string(Tamano()) + "\"\n";
    }
    else
    {
        subgrafo += "\"Pila Escritorio: " + to_string(id) + "\n";
        subgrafo += "Sin Documentos\"\n";
    }

    return subgrafo;
}
