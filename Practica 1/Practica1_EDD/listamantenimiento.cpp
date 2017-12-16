#include <listamantenimiento.h>

ColaAviones::ColaAviones()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
}

void ColaAviones::IngresarAvion(NodoAvion *nuevo)
{
    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;
    }
    else
    {
        this->Ultimo->siguiente = nuevo;
        this->Ultimo = nuevo;
    }
}

NodoAvion* ColaAviones::SacarAvion()
{
    if(this->Primero != nullptr)
    {
        NodoAvion* tmp = this->Primero;
        this->Primero = tmp->siguiente;
        tmp->siguiente = nullptr;
        return tmp;
    }
    return nullptr;
}

bool ColaAviones::EstaVacia()
{
    return this->Primero != nullptr;
}

ListaMantenimiento::ListaMantenimiento()
{
    this->Primero = nullptr;
    this->Ultimo = nullptr;
    this->ColaAv = new ColaAviones();
}

void ListaMantenimiento::IngresarEstacion(int id)
{
    NodoMantenimiento* nuevo = new NodoMantenimiento(id);

    if(this->Primero == nullptr)
    {
        this->Primero = nuevo;
        this->Ultimo = nuevo;
    }
    else
    {
        this->Ultimo->siguiente = nuevo;
        this->Ultimo = nuevo;
    }
}

void ListaMantenimiento::CargarEstaciones(int n)
{
    for(int i = 0 ; i < n ; i++)
    {
        IngresarEstacion(i);
    }
}

void ListaMantenimiento::CargarAviones()
{
    if(this->ColaAv->Primero != nullptr && HayEspacio())
    {
        NodoMantenimiento* tmp = this->Primero;
        do
        {
            if(tmp->AvionActual == nullptr)
            {
                tmp->AvionActual = this->ColaAv->SacarAvion();
                tmp->estado = "Ocupado";
            }
            tmp = tmp->siguiente;
        }while(tmp != nullptr && this->ColaAv->Primero != nullptr);
    }
}

bool ListaMantenimiento::HayEspacio()
{
    if(this->Primero != nullptr)
    {
        NodoMantenimiento* tmp = this->Primero;
        do
        {
            if(tmp->AvionActual == nullptr)
            {
                return true;
            }
            tmp = tmp->siguiente;
        }while(tmp != nullptr);
    }
    return false;

}

string ListaMantenimiento::GenerarSubGrafo()
{
    string subgrafo = "subgraph cluster_ListaMantenimiento{\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Area de Mantenimiento\";\n";
    subgrafo += "color = blue;\n";

    if(this->Primero != nullptr)
    {
        subgrafo += "{rank=min;";
        NodoMantenimiento* tmp = this->Primero;

        do {
            subgrafo += "\"Estacion: " + to_string(tmp->numero) + "\n";
            if(tmp->AvionActual != nullptr)
            {
                subgrafo += "Estado: Ocupado\n";
                subgrafo += "Avion actual: " + to_string(tmp->AvionActual->ID) + "\n";
                subgrafo += "Turnos Restantes: " + to_string(tmp->AvionActual->Turnos_M) + "\";";
            }
            else
            {
                subgrafo += "Estado: Libre\n";
                subgrafo += "Avion actual: Ninguno\n";
                subgrafo += "Turnos Restantes: 0\";";
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);

        subgrafo += "};\n";
        tmp = this->Primero;
        do {
            subgrafo += "\"Estacion: " + to_string(tmp->numero) + "\n";
            if(tmp->AvionActual != nullptr)
            {
                subgrafo += "Estado: Ocupado\n";
                subgrafo += "Avion actual: " + to_string(tmp->AvionActual->ID) + "\n";
                subgrafo += "Turnos Restantes: " + to_string(tmp->AvionActual->Turnos_M) + "\"";
            }
            else
            {
                subgrafo += "Estado: Libre\n";
                subgrafo += "Avion actual: Ninguno\n";
                subgrafo += "Turnos Restantes: 0\"";
            }
            if(tmp->siguiente != nullptr)
            {
                subgrafo += " -> ";

                subgrafo += "\"Estacion: " + to_string(tmp->siguiente->numero) + "\n";
                if(tmp->siguiente->AvionActual != nullptr)
                {
                    subgrafo += "Estado: Ocupado\n";
                    subgrafo += "Avion actual: " + to_string(tmp->siguiente->AvionActual->ID) + "\n";
                    subgrafo += "Turnos Restantes: " + to_string(tmp->siguiente->AvionActual->Turnos_M) + "\"";
                }
                else
                {
                    subgrafo += "Estado: Libre\n";
                    subgrafo += "Avion actual: Ninguno\n";
                    subgrafo += "Turnos Restantes: 0\"";
                }


            }

            tmp = tmp->siguiente;
            } while (tmp != nullptr);

    }

    subgrafo += this->ColaAv->GenerarSubGrafo();
    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
//    string subgrafo = "subgraph cluster_ListaMantenimiento{\n";

//    subgrafo += "node [shape=box, style=filled];\n";
//    subgrafo += "label = \"Area de Mantenimiento\";\n";
//    subgrafo += "color = blue;\n";

//    if(this->Primero != nullptr)
//    {
//        NodoMantenimiento* aux = this->Primero;

//        do {
//            subgrafo += "\"Estacion " + to_string(aux->numero) + "\nEstado: "+ aux->estado +"\"";

//            if(aux->siguiente != nullptr)
//            {
//                subgrafo += " -> ";

//                subgrafo += "\"Estacion " + to_string(aux->siguiente->numero) + "\nEstado: "+ aux->siguiente->estado +"\"\n";
//            }

//            aux = aux->siguiente;
//        } while (aux != nullptr);

//        free(aux);
//    }

//    subgrafo += this->ColaAv->GenerarSubGrafo();
//    subgrafo = subgrafo + "\n" + "}" + "\n\n";
//    return subgrafo;
}

void ListaMantenimiento::PasarTurnoMAntenimiento()
{
    if(this->Primero != nullptr)
    {
        NodoMantenimiento* tmp = this->Primero;
        do
        {
            if(tmp->AvionActual == nullptr)
            {
                tmp->AvionActual = this->ColaAv->SacarAvion();
            }
            else
            {
                tmp->AvionActual->Turnos_M--;
                if(tmp->AvionActual->Turnos_M <= 0)
                {
                    tmp->AvionActual = nullptr;
                }
            }
            tmp = tmp->siguiente;
        }while(tmp != nullptr);
    }
}

string ColaAviones::GenerarSubGrafo()
{
    string subgrafo = "subgraph cluster_ColaAviones{\n";

    subgrafo += "node [shape=box, style=filled];\n";
    subgrafo += "label = \"Cola de Aviones Mantenimiento\";\n";
    subgrafo += "color = blue;\n";

    if(this->Primero != nullptr)
    {
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
            }

            aux = aux->siguiente;
        } while (aux != nullptr);
        free(aux);
    }


    subgrafo = subgrafo + "\n" + "}" + "\n\n";
    return subgrafo;
}


QString ListaMantenimiento::EstadoActual()
{
    QString estado = "******MANTENIMIENTO******\n";

    if(this->Primero != nullptr)
    {
        NodoMantenimiento* tmp = this->Primero;

        do {
            estado += "Estacion: " + QString::number(tmp->numero) + "\n";
            if(tmp->AvionActual != nullptr)
            {
                estado += "         Avion atendido: " + QString::number(tmp->AvionActual->ID) + "\n";
                estado += "         Turnos Restantes: " + QString::number(tmp->AvionActual->Turnos_M) + "\n";
            }
            else
            {
                estado += "         Avion atendido: Ninguno\n";
                estado += "         Turnos Restantes: 0\n";
            }
            tmp = tmp->siguiente;
        } while (tmp != nullptr);
    }

    return estado;
}
