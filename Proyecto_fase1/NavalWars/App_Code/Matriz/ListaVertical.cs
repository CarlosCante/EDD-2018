using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ListaVertical
/// </summary>
public class ListaVertical
{
    public NodoUnidad Primero;
    public NodoUnidad Ultimo;
	public ListaVertical()
	{
        Primero = null;
        Ultimo = null;
    }

    public void Insertar(NodoUnidad nuevo)
    {
        NodoUnidad tmp = Primero;

        if (Primero ==null)
        {
            Primero = nuevo;
            Ultimo = nuevo;
        }
        else if (nuevo.CooY < Primero.CooY)
        {
            Primero.Arriba = nuevo;
            nuevo.Abajo = Primero;
            Primero = nuevo;
        }
        else if (nuevo.CooY > Ultimo.CooY)
        {
            Ultimo.Abajo = nuevo;
            nuevo.Arriba = Ultimo;
            Ultimo = nuevo;
        }
        else
        {
            do
            {
                if (tmp.CooY < nuevo.CooY && tmp.Abajo.CooY > nuevo.CooY)
                {
                    nuevo.Abajo = tmp.Abajo;
                    tmp.Abajo.Arriba = nuevo;
                    tmp.Abajo = nuevo;
                    nuevo.Abajo = tmp;
                }
                tmp = tmp.Abajo;
            } while (tmp != null);
        }
    }
}