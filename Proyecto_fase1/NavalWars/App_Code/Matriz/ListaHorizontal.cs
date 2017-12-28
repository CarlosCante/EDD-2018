using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ListaHorizontal
/// </summary>
public class ListaHorizontal
{
    public NodoUnidad Primero;
    public NodoUnidad Ultimo;

	public ListaHorizontal()
	{
        Primero = null;
        Ultimo = null;
	}

    public void Insertar(NodoUnidad nuevo)
    {
        NodoUnidad tmp = Primero;

        if (Primero == null)
        {
            Primero = nuevo;
            Ultimo = nuevo;
        }
        else if (nuevo.CooX < Primero.CooX)
        {
            Primero.Izquierda = nuevo;
            nuevo.Derecha = Primero;
            Primero = nuevo;
        }
        else if (nuevo.CooX > Ultimo.CooX)
        {
            Ultimo.Derecha = nuevo;
            nuevo.Izquierda = Ultimo;
            Ultimo = nuevo;
        }
        else
        {
            do
            {
                if (tmp.CooX < nuevo.CooX && tmp.Derecha.CooX > nuevo.CooX)
                {
                    nuevo.Derecha = tmp.Derecha;
                    tmp.Derecha.Izquierda = nuevo;
                    tmp.Derecha = nuevo;
                    nuevo.Izquierda = tmp;
                }
                tmp = tmp.Derecha;
            } while (tmp != null);
        }
    }
}