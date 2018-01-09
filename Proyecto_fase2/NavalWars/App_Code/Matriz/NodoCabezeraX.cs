using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoCabezeraX
/// </summary>
public class NodoCabezeraX
{
    public int PosX;
    public int PosZ;

    public NodoCabezeraX Izquierda;
    public NodoCabezeraX Derecha;
    public NodoCabezeraX Arriba;
    public NodoCabezeraX Abajo;

    public ListaVertical lista;
	public NodoCabezeraX(int x, int z)
	{
        PosX = x;
        PosZ = z;

        Izquierda = null;
        Derecha = null;
        Arriba = null;
        Abajo = null;

        lista = new ListaVertical();
	}
}