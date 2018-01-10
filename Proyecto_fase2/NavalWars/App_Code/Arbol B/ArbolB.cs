using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolB
/// </summary>
public class ArbolB
{
    public int Orden;
    public Pagina Raiz;

	public ArbolB(int orden)
	{
        Orden = orden;
        Raiz = null;
	}


}