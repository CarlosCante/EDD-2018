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

    public bool Insertar(NodoUnidad nuevo)
    {
        NodoUnidad tmp = Primero;

        if (Primero == null)
        {
            Primero = nuevo;
            Ultimo = nuevo;
            return true;
        }
        else if (nuevo.CooX < Primero.CooX)
        {
            tmp.Izquierda = nuevo;
            nuevo.Derecha = tmp;
            Primero = nuevo;
            return true;
        }
        else if (nuevo.CooX > Ultimo.CooX)
        {
            tmp = Ultimo;
            tmp.Derecha = nuevo;
            nuevo.Izquierda = tmp;
            Ultimo = nuevo;
            return true;
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
                    return true;
                }
                else if (tmp.CooX == nuevo.CooX)
                {
                    return false;
                }
                tmp = tmp.Derecha;
            } while (tmp != null);
        }
        return false;
    }

    public bool Eliminar(int x, int jugador)
    {
        if(Primero != null)
        {
            if(Primero == Ultimo && Primero.CooX == x && Primero.Jugador == jugador)
            {
                Primero = null;
                Ultimo = null;
                return true;
            }
            else if (Primero.CooX == x && Primero.Jugador == jugador)
            {
                NodoUnidad tmp = Primero.Derecha;
                Primero.Derecha = null;
                tmp.Izquierda = null;
                Primero = tmp;
                return true;
            }
            else if (Ultimo.CooX == x && Ultimo.Jugador == jugador)
            {
                NodoUnidad tmp = Ultimo.Izquierda;
                Ultimo.Izquierda = null;
                tmp.Derecha = null;
                Ultimo = tmp;
                return true;
            }
            else
            {
                NodoUnidad tmp = Primero;
                while (tmp != null)
                {
                    if (tmp.CooX == x && tmp.Jugador == jugador)
                    {
                        tmp.Izquierda.Derecha = tmp.Derecha;
                        tmp.Derecha.Izquierda = tmp.Izquierda;
                        tmp.Derecha = null;
                        tmp.Izquierda = null;
                        return true;
                    }
                    tmp = tmp.Derecha;
                }
            }
        }
        return false;
    }
}