using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolB
/// </summary>
public class ArbolB
{
    public int Orden;
    public Pagina Raiz;
	public ArbolB(int m)
	{
        Orden = m;
        Raiz = null;
	}

    public bool EstaVacio()
    {
        return Raiz == null;
    }

    public void Insertar(NodoAtaque nuevo)
    {
        Raiz = Insertar(Raiz, nuevo);
    }

    Pagina Insertar(Pagina raiz, NodoAtaque nuevo)
    {
        bool sube;
        NodoAtaque mitad = null;
        Pagina nd = null;
        sube = Empujar(raiz, nuevo,ref mitad, ref nd);
        if(sube)
        {
            Pagina p;
            p = new Pagina(Orden);
            p.setConteo(1);
            p.CambiarClave(1, nuevo);
            p.CambiarRama(0, raiz);
            p.CambiarRama(1, nd);
            raiz = p;
        }
        return raiz;
    }

    bool Empujar(Pagina actual, NodoAtaque nodo, ref NodoAtaque mediana, ref Pagina nuevo)
    {
        int k = 0;
        bool sube = false;
        if(actual == null)
        {
            sube = true;
            mediana = nodo;
            nuevo = null;
        }
        else
        {
            bool esta;
            esta = buscarNodo(actual, nodo, ref k);
            if(esta)
            {
                sube = Empujar(actual.ObtenerRama(k), nodo,ref mediana,ref nuevo);
            }
            if(sube)
            {
                if (actual.NodoLLeno())
                {
                    dividirnodo(actual, ref mediana, ref nuevo, k);
                }
            }
            else
            {
                sube = false;
                meterPagina(actual, mediana, nuevo, k);
            }
        }
        return sube;
    }

    void meterPagina(Pagina actual, NodoAtaque nuevo, Pagina ramaDr, int K)
    {
        for (int i = actual.getConteo(); i >= K + 1; i--)
        {
            actual.CambiarClave(i + 1, actual.Claves[i]);
            actual.CambiarRama(i + 1, actual.Ramas[i]);
        }

        actual.CambiarClave(K + 1, nuevo);
        actual.CambiarRama(K + 1, ramaDr);

        actual.setConteo(actual.getConteo() + 1);
    }

    void dividirnodo(Pagina actual, ref NodoAtaque mediana, ref Pagina nuevo, int pos)
    {
        int i, k, posmd;
        Pagina nuevapag;
        k = pos;

        posmd = (k <= Orden / 2) ? Orden / 2 : Orden / 2 + 1;
        nuevapag = new Pagina(Orden);
        for (i = posmd; i < Orden; i++)
        {
            nuevapag.Claves[i - posmd] = actual.Claves[i];
            nuevapag.Ramas[i - posmd] = actual.Ramas[i];
        }
        nuevapag.setConteo((Orden - 1) - posmd);
        actual.setConteo(posmd);
        if(k <= Orden/2)
        {
            meterPagina(actual, mediana, nuevo, pos);
        }
        else
        {
            pos = k - posmd;
            meterPagina(nuevapag, mediana, nuevo, pos);
        }
        mediana = actual.Claves[actual.getConteo()];
        nuevapag.Ramas[0] = actual.Ramas[actual.getConteo()];
        actual.setConteo(actual.getConteo() - 1);
        nuevo = nuevapag;
    }
    public void eliminar(NodoAtaque nodo)
    {

    }

    public bool buscarNodo(Pagina actual, NodoAtaque nodo, ref int k)
    {
        int i;
        bool esta;
        if(nodo.IDAtaque < actual.Claves[1].IDAtaque)
        {
            esta = false;
            i = 0;
        }
        else
        {
            i = actual.getConteo();
            while (nodo.IDAtaque < actual.Claves[i].IDAtaque && i > 1)
            {
                i--;
            }
            esta = (nodo.IDAtaque == actual.Claves[i].IDAtaque);
        }
        k = i;
        return esta;
    }

    public Pagina Buscar(NodoAtaque nodo, ref int n)
    {
        return Buscar(Raiz, nodo, ref n);
    }
    public Pagina Buscar(Pagina actual, NodoAtaque nodo, ref int n)
    {
        if(actual == null)
        {
            return null;
        }
        else
        {
            bool esta = buscarNodo(actual, nodo, ref n);
            if (esta)
                return actual;
            else
                return Buscar(actual.ObtenerRama(n), nodo, ref n);
        }
    }
}