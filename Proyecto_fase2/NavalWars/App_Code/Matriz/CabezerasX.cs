using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CabezerasX
/// </summary>
public class CabezerasX
{
    public NodoCabezeraX primero;
    public NodoCabezeraX ultimo;
	public CabezerasX()
	{
        primero = null;
        ultimo = null;
	}

    public void Insertar(NodoCabezeraX nuevoaux)
    {
        NodoCabezeraX nuevo;
       
        if(nuevoaux.PosZ == 1)
        {
            nuevo = nuevoaux;
        }
        else
        {
            nuevo = new NodoCabezeraX(nuevoaux.PosX, 1);
        }

        NodoCabezeraX tmp = primero;

        if (primero == null)
        {
            primero = nuevo;
            ultimo = nuevo;

            tmp = primero;
        }
        else if (nuevo.PosX < primero.PosX)
        {
            primero.Izquierda = nuevo;
            nuevo.Derecha = primero;
            primero = nuevo;

            tmp = primero;
        }
        else if (nuevo.PosX > ultimo.PosX)
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
                if (tmp.PosX < nuevo.PosX && tmp.Derecha.PosX > nuevo.PosX)
                {
                    nuevo.Derecha = tmp.Derecha;
                    nuevo.Izquierda = tmp;
                    tmp.Derecha = nuevo;
                    nuevo.Derecha.Izquierda = nuevo;

                    tmp = nuevo;
                    break;
                }
                else if(tmp.PosX == nuevo.PosX)
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
                if(tmp.Abajo == null)
                {
                    tmp.Abajo = nuevoaux;
                }
                break;
            case 1:
                break;
            case 2:
                if(tmp.Arriba == null)
                {
                    tmp.Arriba = nuevoaux;
                }
                else if(tmp.Arriba != null && tmp.Arriba.PosZ == 3)
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
                else if(tmp.Arriba != null && tmp.Arriba.PosZ == 2 && tmp.Arriba.Arriba == null)
                {
                    tmp.Arriba.Arriba = nuevoaux;
                }
                break;

            default:
                break;
        }


    }

    public NodoCabezeraX BuscarNodo(int x, int z)
    {
        NodoCabezeraX tmp = primero;
        do
        {
            if(tmp.PosX == x)
            {
                    switch (z)
                    {
                        case 0:
                            if (tmp.Abajo != null)
                            {
                                tmp = tmp.Abajo;
                                return tmp;
                            }
                                
                            return null;


                        case 1:
                            return tmp;


                        case 2:
                            if (tmp.Arriba != null && tmp.Arriba.PosZ == z)
                                return tmp.Arriba;
                            return null;


                        case 3:
                            if(tmp.Arriba != null && tmp.Arriba.PosZ == z)
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