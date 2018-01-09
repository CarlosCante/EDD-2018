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

    public bool Insertar(NodoUnidad nuevo)
    {
        NodoUnidad tmp = Primero;

        if (Primero == null)
        {
            Primero = nuevo;
            Ultimo = nuevo;
            return true;
        }
        else if (nuevo.CooY < Primero.CooY)
        {
            tmp.Arriba = nuevo;
            nuevo.Abajo = tmp;
            Primero = nuevo;
            return true;
        }
        else if (nuevo.CooY > Ultimo.CooY)
        {
            tmp = Ultimo;
            tmp.Abajo = nuevo;
            nuevo.Arriba = tmp;
            Ultimo = nuevo;
            return true;
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
                    nuevo.Arriba = tmp;
                    return true;
                }
                else if(tmp.CooY == nuevo.CooY)
                {
                    return false;
                }
                tmp = tmp.Abajo;
            } while (tmp != null);
        }
        return false;
    }

    public bool Eliminar(int y, int jugador)
    {
        if (Primero != null)
        {
            if (Primero == Ultimo && Primero.CooY == y && Primero.Jugador == jugador)
            {
                Primero = null;
                Ultimo = null;
                return true;
            }
            else if (Primero.CooY == y && Primero.Jugador == jugador)
            {
                NodoUnidad tmp = Primero.Abajo;
                Primero.Abajo = null;
                tmp.Arriba = null;
                Primero = tmp;
                return true;
            }
            else if (Ultimo.CooY == y && Ultimo.Jugador == jugador)
            {
                NodoUnidad tmp = Ultimo.Arriba;
                Ultimo.Arriba = null;
                tmp.Abajo = null;
                Ultimo = tmp;
                return true;
            }
            else
            {
                NodoUnidad tmp = Primero;
                while (tmp != null)
                {
                    if (tmp.CooY == y && tmp.Jugador == jugador)
                    {
                        tmp.Arriba.Abajo = tmp.Abajo;
                        tmp.Abajo.Arriba = tmp.Arriba;
                        tmp.Abajo = null;
                        tmp.Arriba = null;
                        return true;
                    }
                    tmp = tmp.Abajo;
                }
            }
        }
        return false;
    }
}