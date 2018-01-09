using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolContactosAVL
/// </summary>
public class ArbolContactosAVL
{
    public NodoContacto raiz;
	public ArbolContactosAVL()
	{
        raiz = null;
	}

    public bool Insertar(NodoContacto nuevo)
    {
        if(raiz == null)
        {
            raiz = nuevo;
            raiz.padre = null;
            return true;
        }
        else
        {
            NodoContacto padre = null;
            NodoContacto tmp = raiz;
            while (tmp != null)
            {
                padre = tmp;
                if(nuevo.contacto.NickName.CompareTo(tmp.contacto.NickName) == 0)
                {
                    break;
                }
                else if(nuevo.contacto.NickName.CompareTo(tmp.contacto.NickName) < 0)
                {
                    tmp = tmp.izq;
                }
                else if(nuevo.contacto.NickName.CompareTo(tmp.contacto.NickName) > 0)
                {
                    tmp = tmp.der;
                }
            }

            if(tmp == null)
            {
                if(nuevo.contacto.NickName.CompareTo(padre.contacto.NickName) < 0)
                {
                    padre.izq = nuevo;
                    nuevo.padre = padre;
                    ActualizarFE(raiz);
                    return true;
                }
                else if (nuevo.contacto.NickName.CompareTo(padre.contacto.NickName) > 0)
                {
                    padre.der = nuevo;
                    nuevo.padre = padre;
                    ActualizarFE(raiz);
                    return true;
                }
            }
            return false;
        }
    }

    public bool Eliminar(string name)
    {
        NodoContacto aux = raiz;
        NodoContacto padre = raiz;
        bool izquierdo = true;
        while (name.CompareTo(aux.contacto.NickName) != 0)
        {
            padre = aux;
            if (name.CompareTo(aux.contacto.NickName) < 0)
            {
                izquierdo = true;
                aux = aux.izq;
            }
            else if (name.CompareTo(aux.contacto.NickName) > 0)
            {
                izquierdo = false;
                aux = aux.der;
            }

            if (aux == null)
                return false;
        }

        if (EsHoja(aux))
        {
            if (aux == raiz)
            {
                raiz = null;
            }
            else if (izquierdo)
            {
                padre.izq = null;
            }
            else
            {
                padre.der = null;
            }
        }
        else if (aux.der == null)
        {
            if (aux == raiz)
            {
                raiz = aux.izq;
            }
            else if (izquierdo)
            {
                padre.izq = aux.izq;
            }
            else
            {
                padre.der = aux.izq;
            }
        }
        else if (aux.izq == null)
        {
            if (aux == raiz)
            {
                raiz = aux.der;
            }
            else if (izquierdo)
            {
                padre.izq = aux.der;
            }
            else
            {
                padre.der = aux.izq;
            }
        }
        else
        {
            NodoContacto Nuevo = BuscarNuevo(aux);
            if (aux == raiz)
            {
                raiz = Nuevo;
            }
            else if (izquierdo)
            {
                padre.izq = Nuevo;
            }
            else
            {
                padre.der = Nuevo;
            }
            Nuevo.izq = aux.izq;
        }

        ActualizarFE(raiz);
        return true;
    }

    public string Graficar()
    {
        string grafo = "digraph G {\n";

        if (raiz != null)
        {
            grafo += apuntarNodos(raiz);
        }
        grafo += "}\n";
        return grafo;
    }

    string apuntarNodos(NodoContacto r)
    {
        string grafo = "";

        if (r.izq == null && r.der == null)
        {
            grafo = grafo + "\"NICK: " + r.contacto.NickName + "\n" + "Contraseña: " + r.contacto.Contraseña + "\n" + "Correo: " + r.contacto.Correo + "\"\n";

        }
        else
        {
            if (r.izq != null)
            {
                grafo = grafo + "\"NICK: " + r.contacto.NickName + "\n" + "Contraseña: " + r.contacto.Contraseña + "\n" + "Correo: " + r.contacto.Correo + "\"\n -> ";

                grafo = grafo + "\"NICK: " + r.izq.contacto.NickName + "\n" + "Contraseña: " + r.izq.contacto.Contraseña + "\n" + "Correo: " + r.izq.contacto.Correo + "\"\n";
                grafo = grafo + apuntarNodos(r.izq);
            }
            if (r.der != null)
            {
                grafo = grafo + "\"NICK: " + r.contacto.NickName + "\n" + "Contraseña: " + r.contacto.Contraseña + "\n" + "Correo: " + r.contacto.Correo + "\"\n ->";

                grafo = grafo + "\"NICK: " + r.der.contacto.NickName + "\n" + "Contraseña: " + r.der.contacto.Contraseña + "\n" + "Correo: " + r.der.contacto.Correo + "\"\n";
                grafo = grafo + apuntarNodos(r.der);

            }
        }



        return grafo;
    }

    public NodoContacto BuscarNuevo(NodoContacto NRee)
    {
        NodoContacto RPadre = NRee;
        NodoContacto R = NRee;
        NodoContacto aux = NRee.der;

        while (aux != null)
        {
            RPadre = R;
            R = aux;
            aux = aux.izq;
        }

        if (R != NRee.der)
        {
            RPadre.izq = R.der;
            R.der = NRee.der;
        }
        return R;
    }

    bool EsHoja(NodoContacto nodo)
    {
        return (nodo.izq == null && nodo.der == null);
    }

    public void ActualizarFE(NodoContacto padre)
    {
        if (padre != null)
        {
            ActualizarFE(padre.izq);
            ActualizarFE(padre.der);

            //CALCULANDO EL FACTOR DE EQUILIBRIO
            int alturaizquierda = Altura(padre.izq);
            int alturaderecha = Altura(padre.der);

            padre.fe = alturaderecha - alturaizquierda;

            //REALIZANDO ROTACIONES
            NodoContacto equilibrado = equilibrar(padre);

            if (equilibrado != null)
            {
                if (padre == raiz)
                {
                    raiz = equilibrado;
                }
                else
                {
                    NodoContacto tp = equilibrado.padre;
                    if (tp.izq != null)
                    {
                        if (tp.izq.padre != tp)
                        {
                            tp.izq = equilibrado;
                        }
                    }
                    if (tp.der != null)
                    {
                        if (tp.der.padre != tp)
                        {
                            tp.der = equilibrado;
                        }
                    }
                }
                return;
            }
        }
    }


    NodoContacto equilibrar(NodoContacto padre)
    {
        if(padre.fe == -2)
        {
            if(padre.izq != null)
            {
                if(padre.izq.fe == -1)
                {
                    return RSD(padre);
                }
                else if(padre.izq.fe == 1)
                {
                    return RDI(padre);
                }
            }
        }
        else if(padre.fe == 2)
        {
            if(padre.der != null)
            {
                if(padre.der.fe == -1)
                {
                    return RDD(padre);
                }
                else if(padre.der.fe == 1)
                {
                    return RSI(padre);
                }
            }
        }
        //EN CASO QUE NO SE REALIZO NINGUNA ROTACION
        return padre;
    }

    NodoContacto RSD(NodoContacto padre)
    {
        NodoContacto aux = padre.izq;
        padre.izq = aux.der;
        if(aux.der != null)
        {
            aux.der.padre = padre;
        }
        aux.der = padre;
        aux.padre = padre.padre;
        padre.padre = aux;
        return aux;
    }

    NodoContacto RSI(NodoContacto padre)
    {
        NodoContacto aux = padre.der;
        padre.der = aux.izq;
        if(aux.izq != null)
        {
            aux.izq.padre = padre;
        }
        aux.izq = padre;
        aux.padre = padre.padre;
        padre.padre = aux;
        return aux;
    }

    NodoContacto RDD(NodoContacto padre)
    {
        padre.der = RSD(padre.der);
        return RSI(padre);
    }

    NodoContacto RDI(NodoContacto padre)
    {
        padre.izq = RSI(padre.izq);
        return RSD(padre);
    }

    public int Altura(NodoContacto padre)
    {
        if(padre == null)
        {
            return 0;
        }
        else
        {
            int alturaizquierdo = Altura(padre.izq);
            int alturaderecho = Altura(padre.der);
            int max = 0;
            if (alturaderecho > alturaizquierdo)
            {
                max = alturaderecho;
            }
            else if (alturaizquierdo > alturaderecho)
            {
                max = alturaizquierdo;
            }
            else
            {
                max = alturaderecho;
            }
            return max + 1;
        }
    }
}