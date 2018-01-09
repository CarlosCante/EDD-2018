using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pagina
/// </summary>
public class Pagina
{
    public NodoAtaque[] Claves;
    public Pagina[] Ramas;
    public int Conteo;

    public int Orden;
	public Pagina(int orden)
	{
        Orden = orden;
        Claves = new NodoAtaque[orden];
        Ramas = new Pagina[orden];

        for (int i = 0; i < orden; i++)
        {
            Ramas[i] = null;
        }
	}

    public bool NodoLLeno()
    {
        return (Conteo == Orden - 1);
    }

    public bool NodoMedioLLeno()
    {
        return (Conteo < (Orden / 2));
    }

    public NodoAtaque ObtenerClave(int i)
    {
        return Claves[i];
    }

    public void CambiarClave(int i, NodoAtaque nuevo)
    {
        Claves[i] = nuevo;
    }

    public Pagina ObtenerRama(int i)
    {
        return Ramas[i];
    }

    public void CambiarRama(int i, Pagina nueva)
    {
        Ramas[i] = nueva;
    }

    public int getConteo()
    {
        return Conteo;
    }

    public void setConteo(int i)
    {
        Conteo = i;
    }
}