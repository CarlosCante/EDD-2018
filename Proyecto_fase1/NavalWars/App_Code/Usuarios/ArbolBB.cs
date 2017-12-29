using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolBB
/// </summary>
public class ArbolBB
{
    public NodoUsuario Raiz;
    public int numeronodos = 0;
	public ArbolBB()
	{
        Raiz = null;
	}

    public void Insertar(NodoUsuario r, NodoUsuario nuevo)
    {
        if (Raiz == null) // Si se llego a un nodo nulo, el nuevo nodo se inserta en ese espacio
        {
            Raiz = nuevo;
            return;
        }
            
        if(nuevo.NickName.CompareTo(r.NickName) < 0) //Si el nuevo nodo es menor que el actual se decide seguir buscando por la derecha si lugar de insercion
        {
            if (r.izq == null)
                r.izq = nuevo;
            else
                Insertar(r.izq, nuevo);
        }
        else if (nuevo.NickName.CompareTo(r.NickName) > 0)//Si el nuevo nodo es menor que el actual se decide seguir buscando por la izquierda si lugar de insercion
        {
            if (r.der == null)
                r.der = nuevo;
            else
                Insertar(r.der, nuevo);
        }
    }

    public void Eliminar(string name)
    {
        NodoUsuario aux = Raiz;
        NodoUsuario padre = Raiz;
        bool izquierdo = true;
        while(name.CompareTo(aux.NickName) != 0)
        {
            padre = aux;
            if(name.CompareTo(aux.NickName) < 0)
            {
                izquierdo = true;
                aux = aux.izq;
            }
            else if(name.CompareTo(aux.NickName) > 0)
            {
                izquierdo = false;
                aux = aux.der;
            }

            if (aux == null)
                return;
        }

        if(EsHoja(aux))
        {
            if(aux == Raiz)
            {
                Raiz = null;
            }
            else if(izquierdo)
            {
                padre.izq = null;
            }
            else
            {
                padre.der = null;
            }
        }
        else if(aux.der == null)
        {
            if(aux == Raiz)
            {
                Raiz = aux.izq;
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
        else if(aux.izq == null)
        {
            if (aux == Raiz)
            {
                Raiz = aux.der;
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
            NodoUsuario Nuevo = BuscarNuevo(aux);
            if(aux == Raiz)
            {
                Raiz = Nuevo;
            }
            else if(izquierdo)
            {
                padre.izq = Nuevo;
            }
            else
            {
                padre.der = Nuevo;
            }
            Nuevo.izq = aux.izq;
        }
        return;

    }

    public bool VerificarUsuario(string nombre, string contraseña)
    {
        NodoUsuario aux = Raiz;

        while (nombre.CompareTo(aux.NickName) != 0)
        {
            if (nombre.CompareTo(aux.NickName) < 0)
            {
                aux = aux.izq;
            }
            else if (nombre.CompareTo(aux.NickName) > 0)
            {
                aux = aux.der;
            }

            if (aux == null)
                return false;
        }

        if(nombre.CompareTo(aux.NickName) == 0 && contraseña.CompareTo(aux.Contraseña) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    bool EsHoja(NodoUsuario nodo)
    {
        return (nodo.izq == null && nodo.der == null);
    }

    public NodoUsuario BuscarNuevo(NodoUsuario NRee)
    {
        NodoUsuario RPadre = NRee;
        NodoUsuario R = NRee;
        NodoUsuario aux = NRee.der;

        while(aux != null)
        {
            RPadre = R;
            R = aux;
            aux = aux.izq;
        }
        
        if(R != NRee.der)
        {
            RPadre.izq = R.der;
            R.der = NRee.der;
        }
        return R;
    }

    public bool AñadirJuego(string Usuario, NodoJuego nuevo)
    {
        NodoUsuario tmp = Raiz;
        do
        {
            if(Usuario.CompareTo(tmp.NickName) < 0)//izquierda
            {
                tmp = tmp.izq;
            }
            else if(Usuario.CompareTo(tmp.NickName) > 0)//Derecha
            {
                tmp = tmp.der;
            }
            else if(Usuario.CompareTo(tmp.NickName) == 0)//Es el nodo
            {
                tmp.ListaDeJuegos.Insertar(nuevo);
                return true;
            }
            
        } while (tmp != null);

        return false;
    }

    public string Graficar()
    {
        string grafo = "digraph G {\n";

        grafo += apuntarNodos(Raiz);

        grafo += "}\n";
        return grafo;
    }

    string apuntarNodos(NodoUsuario r)
    {
        string grafo = "";

        if(r.izq == null && r.der == null)
        {
            grafo = grafo + "\"NICK: " + r.NickName + "\n" + "Contraseña: " + r.Contraseña + "\n" + "Correo: " + r.Correo + "\n";
            if (r.Conectado == true)
            {
                grafo = grafo + "Conectado: si\"";
            }
            else
            {
                grafo = grafo + "Conectado: no\"";
            }

        }
        else
        {
            if (r.izq != null)
            {
                grafo = grafo + "\"NICK: " + r.NickName + "\n" + "Contraseña: " + r.Contraseña + "\n" + "Correo: " + r.Correo + "\n";
                if (r.Conectado == true)
                {
                    grafo = grafo + "Conectado: si\"" + " -> ";
                }
                else
                {
                    grafo = grafo + "Conectado: no\"" + " -> ";
                }

                grafo = grafo + "\"NICK: " + r.izq.NickName + "\n" + "Contraseña: " + r.izq.Contraseña + "\n" + "Correo: " + r.izq.Correo + "\n";
                if (r.izq.Conectado == true)
                {
                    grafo = grafo + "Conectado: si\"\n";
                }
                else
                {
                    grafo = grafo + "Conectado: no\"\n";
                }
                grafo = grafo + apuntarNodos(r.izq);
            }
            if (r.der != null)
            {
                grafo = grafo + "\"NICK: " + r.NickName + "\n" + "Contraseña: " + r.Contraseña + "\n" + "Correo: " + r.Correo + "\n";
                if (r.Conectado == true)
                {
                    grafo = grafo + "Conectado: si\"" + " -> ";
                }
                else
                {
                    grafo = grafo + "Conectado: no\"" + " -> ";
                }

                grafo = grafo + "\"NICK: " + r.der.NickName + "\n" + "Contraseña: " + r.der.Contraseña + "\n" + "Correo: " + r.der.Correo + "\n";
                if (r.der.Conectado == true)
                {
                    grafo = grafo + "Conectado: si\"\n";
                }
                else
                {
                    grafo = grafo + "Conectado: no\"\n";
                }
                grafo = grafo + apuntarNodos(r.der);

            }
        }

       

        return grafo;
    }

    public string GraficarListaJuegos()
    {
        string grafo = "digraph G {\n";

        grafo += apuntarNodos2(Raiz);

        grafo += "}\n";
        return grafo;
    }

    string apuntarNodos2(NodoUsuario r)
    {
        string grafo = "";

        if (r.izq == null && r.der == null)
        {
            grafo += r.ListaDeJuegos.Graficar(r.NickName);

        }
        else
        {

            grafo += r.ListaDeJuegos.Graficar(r.NickName);
            if (r.izq != null)
            {
                grafo = grafo + apuntarNodos2(r.izq);
            }
            if (r.der != null)
            {
                grafo = grafo + apuntarNodos2(r.der);

            }
        }



        return grafo;
    }

    public int ContarHojas(NodoUsuario raiz)
    {
        if(raiz == null)
        {
            return 0;
        }
        if((raiz.der == null) && (raiz.izq == null))
        {
            return 1;
        }
        else
        {
            return ContarHojas(raiz.izq) + ContarHojas(raiz.der);
        }
    }

    public int ContarNodos(NodoUsuario raiz)
    {
        int res = 0;
        if (raiz != null)
        {
            res += ContarNodos(raiz.izq);
            res += 1;
            res += ContarNodos(raiz.der);
        }
        return res;

    }


    public int Altura(NodoUsuario raiz)
    {
        int altizq;
        int altder;

        if (raiz == null)
        {
            return -1;
        }
        else
        {
            altizq = Altura(raiz.izq);
            altder = Altura(raiz.der);

            if(altizq > altder)
            {
                return altizq + 1;
            }
            else
            {
                return altder + 1;
            }
        }
    }

    public NodoUsuario Espejo(NodoUsuario raiz)
    {
        NodoUsuario tmp;

        if(raiz != null)
        {
            tmp = raiz.izq;
            raiz.izq = Espejo(raiz.der);
            raiz.der = Espejo(tmp);
        }

        return raiz;
    }


}