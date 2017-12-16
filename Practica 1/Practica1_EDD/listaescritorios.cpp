#include <listaescritorios.h>

#include <QDebug>

using namespace std;

ListaEscritorios::ListaEscritorios()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
    this->IdDocumentos = 1;
}

void ListaEscritorios::AgregarEscritorio(int id)
{
    NodoEscritorio* nuevo = new NodoEscritorio(id);

    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;
        return;
    }
    else if(this->Primero == this->Ultimo)
    {
        if(nuevo->numero > this->Primero->numero)
        {
            this->Primero->siguiente = nuevo;
            nuevo->anterior = this->Primero;
            this->Ultimo = nuevo;
            return;
        }
        else if(nuevo->numero < this->Primero->numero)
        {
            nuevo->siguiente = this->Primero;
            this->Primero->anterior = nuevo;
            this->Primero = nuevo;
        }
    }
    else
    {
        NodoEscritorio* tmp = this->Primero;
        do {
            if(tmp == this->Ultimo)
            {
                this->Ultimo->siguiente = nuevo;
                nuevo->anterior = this->Ultimo;
                this->Ultimo = nuevo;
                return;
            }
            else if(tmp == this->Primero && nuevo->numero < this->Primero->numero)
            {
                nuevo->siguiente = this->Primero;
                this->Primero->anterior = nuevo;
                this->Primero = nuevo;
            }
            else if(nuevo->numero > tmp->numero && nuevo->numero < tmp->siguiente->numero)
            {
                nuevo->siguiente = tmp->siguiente;
                nuevo->siguiente->anterior = nuevo;
                nuevo->anterior = tmp;
                tmp->siguiente = nuevo;
                return;
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }
}

void ListaEscritorios::CargarEscritorios(int NoEscritorios)
{
    for(int i = 0; i<NoEscritorios ; i++)
        AgregarEscritorio(i);
}


void ListaEscritorios::CargarPersonas(ColaPersonas *colageneral)
{
    if(!colageneral->EstaVacia())
    {
        NodoEscritorio* tmp = this->Primero;
        while(!colageneral->EstaVacia() && HayEspacio())
        {
            if(tmp->PersonasEnCola < 10)
            {
                tmp->Cola->IngresarPersona2(colageneral->SacarPersona());
                tmp->PersonasEnCola++;
            }

            tmp = tmp->siguiente;
            if(tmp == nullptr)
                tmp = this->Primero;
        }
    }
}

bool ListaEscritorios::HayEspacio()
{
    if(this->Primero != nullptr)
    {
        NodoEscritorio* tmp = this->Primero;
        do {
            if(tmp->PersonasEnCola < 10)
            {
                return true;
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }
    return false;
}

void ListaEscritorios::PasarTurno(ListaMaletas *l)
{
    if(this->Primero != nullptr)
    {
        NodoEscritorio* tmp = this->Primero;
        do {
            if(tmp->PersonaActual == nullptr)
            {
                if(tmp->Cola->Primero != nullptr)
                {
                    tmp->PersonaActual = tmp->Cola->SacarPersona();
                    tmp->AnadirDocumentos(tmp->PersonaActual->NoDocumentos, tmp->PersonaActual->IDPersona);
                    tmp->PersonasEnCola--;
                }
            }
            else
            {
                tmp->PersonaActual->NoTurnosR--;
                if(tmp->PersonaActual->NoTurnosR <= 0)
                {
                    l->SacarMaletas(tmp->PersonaActual->NoMaletas);
                    tmp->SacarDocumentos(tmp->PersonaActual->NoDocumentos);
                    tmp->PersonaActual = nullptr;
                }
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }
}

string ListaEscritorios::GenerarSubgrafo()
{
    string subgrafo = "subgraph cluster_Escritorios{\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Lista de Escritorios\";\n";
    subgrafo += "color = blue;\n";
    char n = 0;

    if(this->Primero != nullptr)
    {
       subgrafo += "{rank=min;";
       NodoEscritorio* tmp = this->Ultimo;
       do
       {
                   n = tmp->numero + 65;
                   subgrafo += "\"Escritorio: ";
                   subgrafo.push_back(n);
                   subgrafo += "\n";
                   if(tmp->PersonaActual == nullptr)
                   {
                       subgrafo += "Cliente Atendido: Ninguno \n";
                       subgrafo += "Estado: Libre \n";
                       subgrafo += "Cantidad Documentos: 0 \n";
                       subgrafo += "Turnos Restantes: 0 \";\n";
                   }
                   else
                   {
                       subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
                       subgrafo += "Estado: Ocupado \n";
                       subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
                       subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \";\n";
                   }

           tmp = tmp->anterior;
       }while(tmp != nullptr);

       subgrafo += "};\n";

        tmp = this->Primero;
           do {
                n = tmp->numero + 65;
                subgrafo += "\"Escritorio: ";
                subgrafo.push_back(n);
                subgrafo += "\n";
               if(tmp->PersonaActual == nullptr)
               {
                   subgrafo += "Cliente Atendido: Ninguno \n";
                   subgrafo += "Estado: Libre \n";
                   subgrafo += "Cantidad Documentos: 0 \n";
                   subgrafo += "Turnos Restantes: 0 \"\n";
               }
               else
               {
                   subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
                   subgrafo += "Estado: Ocupado \n";
                   subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
                   subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \"\n";
               }

               if(tmp->siguiente != nullptr)
               {
                   subgrafo += " -> ";

                   n = tmp->siguiente->numero + 65;
                   subgrafo += "\"Escritorio: ";
                   subgrafo.push_back(n);
                   subgrafo += "\n";
                   if(tmp->siguiente->PersonaActual == nullptr)
                   {
                       subgrafo += "Cliente Atendido: Ninguno \n";
                       subgrafo += "Estado: Libre \n";
                       subgrafo += "Cantidad Documentos: 0 \n";
                       subgrafo += "Turnos Restantes: 0 \"\n";
                   }
                   else
                   {
                       subgrafo += "Cliente Atendido: " + to_string(tmp->siguiente->PersonaActual->IDPersona) + " \n";
                       subgrafo += "Estado: Ocupado \n";
                       subgrafo += "Cantidad Documentos: " + to_string(tmp->siguiente->PersonaActual->NoDocumentos) + " \n";
                       subgrafo += "Turnos Restantes: " + to_string(tmp->siguiente->PersonaActual->NoTurnosR) + " \"\n";
                   }

                   subgrafo += "\n";

                   n = tmp->siguiente->numero + 65;
                   subgrafo += "\"Escritorio: ";
                   subgrafo.push_back(n);
                   subgrafo += "\n";
                   if(tmp->siguiente->PersonaActual == nullptr)
                   {
                       subgrafo += "Cliente Atendido: Ninguno \n";
                       subgrafo += "Estado: Libre \n";
                       subgrafo += "Cantidad Documentos: 0 \n";
                       subgrafo += "Turnos Restantes: 0 \"\n";
                   }
                   else
                   {
                       subgrafo += "Cliente Atendido: " + to_string(tmp->siguiente->PersonaActual->IDPersona) + " \n";
                       subgrafo += "Estado: Ocupado \n";
                       subgrafo += "Cantidad Documentos: " + to_string(tmp->siguiente->PersonaActual->NoDocumentos) + " \n";
                       subgrafo += "Turnos Restantes: " + to_string(tmp->siguiente->PersonaActual->NoTurnosR) + " \"\n";
                   }


                   subgrafo += " -> ";

                   n = tmp->numero + 65;
                   subgrafo += "\"Escritorio: ";
                   subgrafo.push_back(n);
                   subgrafo += "\n";
                   if(tmp->PersonaActual == nullptr)
                   {
                       subgrafo += "Cliente Atendido: Ninguno \n";
                       subgrafo += "Estado: Libre \n";
                       subgrafo += "Cantidad Documentos: 0 \n";
                       subgrafo += "Turnos Restantes: 0 \"\n";
                   }
                   else
                   {
                       subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
                       subgrafo += "Estado: Ocupado \n";
                       subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
                       subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \"\n";
                   }
               }
               subgrafo += tmp->Cola->GenerarSubGrafo(tmp->numero);
               tmp = tmp->siguiente;
           } while (tmp != nullptr);

        tmp = this->Primero;
        do {
            if(tmp->Cola->Primero != nullptr)
            {
                n = tmp->numero + 65;
                subgrafo += "\"Escritorio: ";
                subgrafo.push_back(n);
                subgrafo += "\n";
                if(tmp->PersonaActual == nullptr)
                {
                    subgrafo += "Cliente Atendido: Ninguno \n";
                    subgrafo += "Estado: Libre \n";
                    subgrafo += "Cantidad Documentos: 0 \n";
                    subgrafo += "Turnos Restantes: 0 \"\n";
                }
                else
                {
                    subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
                    subgrafo += "Estado: Ocupado \n";
                    subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
                    subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \"\n";
                }


                subgrafo += " -> ";

                subgrafo += "\"Persona " + to_string(tmp->Cola->Ultimo->IDPersona) + "\n";
                subgrafo += "No. Maletas: " + to_string(tmp->Cola->Ultimo->NoMaletas) + "\n";
                subgrafo += "No. Documentos: " + to_string(tmp->Cola->Ultimo->NoDocumentos) + "\n";
                subgrafo += "Turdos para Registro: " + to_string(tmp->Cola->Ultimo->NoTurnosR) + "\"\n";
            }

            tmp = tmp->siguiente;
        } while (tmp != nullptr);

        tmp = this->Primero;

        do {
            n = tmp->numero + 65;
            subgrafo += "\"Escritorio: ";
            subgrafo.push_back(n);
            subgrafo += "\n";
            if(tmp->PersonaActual == nullptr)
            {
                subgrafo += "Cliente Atendido: Ninguno \n";
                subgrafo += "Estado: Libre \n";
                subgrafo += "Cantidad Documentos: 0 \n";
                subgrafo += "Turnos Restantes: 0 \"\n";
            }
            else
            {
                subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
                subgrafo += "Estado: Ocupado \n";
                subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
                subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \"\n";
            }

            subgrafo += " -> " + tmp->Pila->GenerarSubGrafo(tmp->numero);

            tmp = tmp->siguiente;
        } while (tmp != nullptr);

    }

    subgrafo = subgrafo + "\n" + "}" + "\n\n";




    return subgrafo;
}

QString ListaEscritorios::EstadoActual()
{
    QString estado = "********ESCRITORIOS********\n";
    char n;

    if(this->Primero != nullptr)
    {
        NodoEscritorio* tmp = this->Primero;
        do
        {
            n = tmp->numero + 65;
            estado += "Escritorio: ";
            estado.push_back(n);
            estado += "\n";

            if(tmp->PersonaActual != nullptr)
            {
                estado += "         Pasajero Atendido: " + QString::number(tmp->PersonaActual->IDPersona) + "\n";
                estado += "         Turnos Restantes: " + QString::number(tmp->PersonaActual->NoTurnosR) + "\n";
                estado += "         Cantidad de Documentos: " + QString::number(tmp->Pila->Tamano()) + "\n";
            }
            else
            {
                estado += "         Pasajero Atendido: Ninguna\n";
                estado += "         Turnos Restantes: 0\n";
                estado += "         Cantidad de Documentos: 0\n";
            }
            tmp = tmp->siguiente;
        }while(tmp != nullptr);
    }

    return estado;
}

//string subgrafo = "subgraph cluster_Escritorios{\n";

//subgrafo += "node [shape=box, style=filled];\n";
//subgrafo += "label = \"Lista de Escritorios\";\n";
//subgrafo += "color = blue;\n";

//if(this->Primero != nullptr)
//{
//    NodoEscritorio* tmp = this->Primero;

//    do {
//        subgrafo += "\"Escritorio: " + to_string(tmp->numero) + "\n";
//        if(tmp->PersonaActual == nullptr)
//        {
//            subgrafo += "Cliente Atendido: Ninguno \n";
//            subgrafo += "Estado: Libre \n";
//            subgrafo += "Cantidad Documentos: 0 \n";
//            subgrafo += "Turnos Restantes: 0 \"\n";
//        }
//        else
//        {
//            subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
//            subgrafo += "Estado: Ocupado \n";
//            subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
//            subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \"\n";
//        }

//        if(tmp->siguiente != nullptr)
//        {
//            subgrafo += " -> ";

//            subgrafo += "\"Escritorio: " + to_string(tmp->siguiente->numero) + "\n";
//            if(tmp->siguiente->PersonaActual == nullptr)
//            {
//                subgrafo += "Cliente Atendido: Ninguno \n";
//                subgrafo += "Estado: Libre \n";
//                subgrafo += "Cantidad Documentos: 0 \n";
//                subgrafo += "Turnos Restantes: 0 \"\n";
//            }
//            else
//            {
//                subgrafo += "Cliente Atendido: " + to_string(tmp->siguiente->PersonaActual->IDPersona) + " \n";
//                subgrafo += "Estado: Ocupado \n";
//                subgrafo += "Cantidad Documentos: " + to_string(tmp->siguiente->PersonaActual->NoDocumentos) + " \n";
//                subgrafo += "Turnos Restantes: " + to_string(tmp->siguiente->PersonaActual->NoTurnosR) + " \"\n";
//            }

//            subgrafo += "\n";

//            subgrafo = subgrafo + "\"Escritorio: " + to_string(tmp->siguiente->numero) + "\n";
//            if(tmp->siguiente->PersonaActual == nullptr)
//            {
//                subgrafo += "Cliente Atendido: Ninguno \n";
//                subgrafo += "Estado: Libre \n";
//                subgrafo += "Cantidad Documentos: 0 \n";
//                subgrafo += "Turnos Restantes: 0 \"\n";
//            }
//            else
//            {
//                subgrafo += "Cliente Atendido: " + to_string(tmp->siguiente->PersonaActual->IDPersona) + " \n";
//                subgrafo += "Estado: Ocupado \n";
//                subgrafo += "Cantidad Documentos: " + to_string(tmp->siguiente->PersonaActual->NoDocumentos) + " \n";
//                subgrafo += "Turnos Restantes: " + to_string(tmp->siguiente->PersonaActual->NoTurnosR) + " \"\n";
//            }


//            subgrafo += " -> ";

//            subgrafo += "\"Escritorio: " + to_string(tmp->numero) + "\n";
//            if(tmp->PersonaActual == nullptr)
//            {
//                subgrafo += "Cliente Atendido: Ninguno \n";
//                subgrafo += "Estado: Libre \n";
//                subgrafo += "Cantidad Documentos: 0 \n";
//                subgrafo += "Turnos Restantes: 0 \"\n";
//            }
//            else
//            {
//                subgrafo += "Cliente Atendido: " + to_string(tmp->PersonaActual->IDPersona) + " \n";
//                subgrafo += "Estado: Ocupado \n";
//                subgrafo += "Cantidad Documentos: " + to_string(tmp->PersonaActual->NoDocumentos) + " \n";
//                subgrafo += "Turnos Restantes: " + to_string(tmp->PersonaActual->NoTurnosR) + " \"\n";
//            }
//        }
//        subgrafo += tmp->Cola->GenerarSubGrafo(tmp->numero);
//        subgrafo += tmp->Pila->GenerarSubGrafo(tmp->numero);
//        tmp = tmp->siguiente;
//    } while (tmp != nullptr);
//    free(tmp);
//}

//subgrafo = subgrafo + "\n" + "}" + "\n\n";
//return subgrafo;
