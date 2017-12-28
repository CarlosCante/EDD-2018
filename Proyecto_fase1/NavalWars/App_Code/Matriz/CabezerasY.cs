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
        NodoCabezeraY tmp2 = nuevo;

        if (primero == null)
        {
            primero = nuevo;
            ultimo = nuevo;
        }
        else if (nuevo.PosY < primero.PosY)
        {
            primero.Derecha = nuevo;
            nuevo.Izquierda = primero;
            primero = nuevo;
        }
        else if (nuevo.PosY > ultimo.PosY)
        {
            ultimo.Derecha = nuevo;
            nuevo.Izquierda = ultimo;
            ultimo = nuevo;
        }
        else
        {
            do
            {
                if (tmp.PosY < nuevo.PosY && tmp.Derecha.PosY > nuevo.PosY)
                {
                    nuevo.Derecha = tmp.Derecha;
                    tmp.Derecha.Izquierda = nuevo;
                    tmp.Derecha = nuevo;
                    nuevo.Izquierda = tmp;
                    tmp2 = nuevo;
                    break;
                }
                else if (tmp.PosY == nuevo.PosY)
                {
                    tmp2 = tmp;
                    break;
                }

                tmp = tmp.Derecha;
            } while (tmp != null);
        }

        //insertar en el nivel
        switch (nuevoaux.PosZ)
        {
            case 0:
                tmp2.Abajo = nuevoaux;
                break;
            case 1:
                break;
            case 2:
                tmp2.Arriba = nuevoaux;
                break;
            case 3:
                if (tmp2.Arriba == null)
                {
                    tmp2.Arriba = nuevoaux;
                    break;
                }
                else if (tmp.Arriba.Arriba == null)
                {
                    tmp2.Arriba.Arriba = nuevoaux;
                    break;
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
                        else if (tmp.Arriba != null && tmp.Arriba.Arriba.PosZ == z)
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