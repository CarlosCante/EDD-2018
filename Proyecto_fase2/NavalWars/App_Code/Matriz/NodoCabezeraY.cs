using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoCabezeraY
/// </summary>
public class NodoCabezeraY
{
    public int PosY;
    public int PosZ;

    public NodoCabezeraY Izquierda;
    public NodoCabezeraY Derecha;
    public NodoCabezeraY Arriba;
    public NodoCabezeraY Abajo;

    public ListaHorizontal lista;
	public NodoCabezeraY(int y, int z)
	{
        PosY = y;
        PosZ = z;

        Izquierda = null;
        Derecha = null;
        Arriba = null;
        Abajo = null;

        lista = new ListaHorizontal();
	}
}