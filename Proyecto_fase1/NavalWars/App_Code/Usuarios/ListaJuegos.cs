using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ListaJuegos
/// </summary>
public class ListaJuegos
{
    public NodoJuego Primero;
    public NodoJuego Ultimo;
	public ListaJuegos()
	{
        Primero = null;
        Ultimo = null;
	}

    public void Insertar(NodoJuego nuevo)
    {
        if(Primero == null)
        {
            Primero = nuevo;
            Ultimo = nuevo;
        }
        else
        {
            Ultimo.siguiente = nuevo;
            nuevo.anterior = Ultimo;
            Ultimo = nuevo;
        }
    }
}