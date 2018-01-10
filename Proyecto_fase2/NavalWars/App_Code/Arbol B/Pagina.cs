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
    public NodoAtaque Mitad;
    public int CantidadClaves;
    public int Orden;

	public Pagina(int orden)
	{
        Orden = orden;
        Claves = new NodoAtaque[orden];
        Ramas = new Pagina[orden + 1];
        CantidadClaves = 0;
        Mitad = null;
	}

    public bool EstaLlena()
    {
        return CantidadClaves == Orden;
    }
}