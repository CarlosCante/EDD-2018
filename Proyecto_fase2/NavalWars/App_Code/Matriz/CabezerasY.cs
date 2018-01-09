using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CabezerasY
/// </summary>
public class CabezerasY
{
    public NodoCabezeraY primero;
    public NodoCabezeraY ultimo;
	public CabezerasY()
	{
        primero = null;
        ultimo = null;
	}

    public void Insertar(NodoCabezeraY nuevoaux)
    {
        NodoCabezeraY nuevo;

        if (nuevoaux.PosZ == 1)
        {
            nuevo = nuevoaux;
        }
        else
        {
            nuevo = new NodoCabezeraY(nuevoaux.PosY, 1);
        }

        NodoCabezeraY tmp = primero;

        if (primero == null)
        {
            primero = nuevo;
            ultimo = nuevo;

            tmp = primero;
        }
        else if (nuevo.PosY < primero.PosY)
        {
            primero.Izquierda = nuevo;
            nuevo.Derecha = primero;
            primero = nuevo;

            tmp = primero;
        }
        else if (nuevo.PosY > ultimo.PosY)
        {
            ultimo.Derecha = nuevo;
            nuevo.Izquierda = ultimo;
            ultimo = nuevo;

            tmp = ultimo;
        }
        else
        {
            while (tmp != null)
            {
                if (tmp.PosY < nuevo.PosY && tmp.Derecha.PosY > nuevo.PosY)
                {
                    nuevo.Derecha = tmp.Derecha;
                    nuevo.Izquierda = tmp;
                    tmp.Derecha = nuevo;
                    nuevo.Derecha.Izquierda = nuevo;

                    tmp = nuevo;
                    break;
                }
                else if (tmp.PosY == nuevo.PosY)
                {
                    break;
                }

                tmp = tmp.Derecha;
            }
        }

        //insertar en el nivel 0
        switch (nuevoaux.PosZ)
        {
            case 0:
                if (tmp.Abajo == null)
                {
                    tmp.Abajo = nuevoaux;
                }
                break;
            case 1:
                break;
            case 2:
                if (tmp.Arriba == null)
                {
                    tmp.Arriba = nuevoaux;
                }
                else if (tmp.Arriba != null && tmp.Arriba.PosZ == 3)
                {
                    nuevoaux.Arriba = tmp.Arriba;
                    tmp.Arriba = nuevoaux;
                }

                break;
            case 3:
                if (tmp.Arriba == null)
                {
                    tmp.Arriba = nuevoaux;
                }
                else if (tmp.Arriba != null && tmp.Arriba.PosZ == 2 && tmp.Arriba.Arriba == null)
                {
                    tmp.Arriba.Arriba = nuevoaux;
                }
                break;

            default:
                break;
        }

    }

    public NodoCabezeraY BuscarNodo(int y, int z)
    {
        NodoCabezeraY tmp = primero;
        do
        {
            if (tmp.PosY == y)
            {
                switch (z)
                {
                    case 0:
                        if (tmp.Abajo != null)
                            return tmp.Abajo;
                        return null;


                    case 1:
                        return tmp;


                    case 2:
                        if (tmp.Arriba != null && tmp.Arriba.PosZ == z)
                            return tmp.Arriba;
                        return null;


                    case 3:
                        if (tmp.Arriba != null && tmp.Arriba.PosZ == z)
                        {
                            return tmp.Arriba;
                        }
                        else if (tmp.Arriba != null && tmp.Arriba.Arriba != null && tmp.Arriba.Arriba.PosZ == z)
                        {
                            return tmp.Arriba.Arriba;
                        }
                        return null;


                    default:
                        return null;
                }
            }
            tmp = tmp.Derecha;
        } while (tmp != null);

        return null;
    }
}