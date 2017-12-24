using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarea3
{
    class Nodo
    {
        public char Caracter;
        public Nodo der;
        public Nodo izq;

        public Nodo(char c)
        {
            Caracter = c;
            der = null;
            izq = null;
        }
    }

    class Arbol
    {
        public Nodo Raiz;

        public Arbol()
        {
            Raiz = null;
        }

        public void Insertar(Nodo r, Nodo nuevo)
        {

            if (Raiz == null) // Si se llego a un nodo nulo, el nuevo nodo se inserta en ese espacio
            {
                Raiz = nuevo;
                return;
            }

            if (nuevo.Caracter.CompareTo(r.Caracter) < 0) //Si el nuevo nodo es menor que el actual se decide seguir buscando por la derecha si lugar de insercion
            {
                if (r.izq == null)
                    r.izq = nuevo;
                else
                    Insertar(r.izq, nuevo);
            }
            else if (nuevo.Caracter.CompareTo(r.Caracter) > 0)//Si el nuevo nodo es menor que el actual se decide seguir buscando por la izquierda si lugar de insercion
            {
                if (r.der == null)
                    r.der = nuevo;
                else
                    Insertar(r.der, nuevo);
            }
        }

        public string PreOrden(Nodo raiz)
        {
            string res = "";
            if (raiz != null)
            {
                res += raiz.Caracter;
                res += PreOrden(raiz.izq);
                res += PreOrden(raiz.der);
            }
            return res;
        }

        public string EnOrden(Nodo raiz)
        {
            string res = "";
            if (raiz != null)
            {
                res += EnOrden(raiz.izq);
                res += raiz.Caracter;
                res += EnOrden(raiz.der);
            }
            return res;
        }

        public string PostOrden(Nodo raiz)
        {
            string res = "";
            if (raiz != null)
            {
                res += PostOrden(raiz.izq);
                res += PostOrden(raiz.der);
                res += raiz.Caracter;
            }
            return res;
        }
    }
}
