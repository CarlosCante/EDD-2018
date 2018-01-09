using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoAtaque
/// </summary>
public class NodoAtaque
{
    public int IDAtaque;

    public int CooX;
    public int CooY;
    public string UnidadAtacante;
    public string Emisor;
    public string Receptor;
    public string fecha;
    public int TiempoRestante;

    public string Resultado;
    public string TipoUnidadDañana;
   

	public NodoAtaque(int ID, int x, int y, string UniAt, string emisor, string receptor, string fech, string result, string TipoUnidDestr)
	{
        IDAtaque = ID;
        CooX = x;
        CooY = y;
        UnidadAtacante = UniAt;
        Emisor = emisor;
        Receptor = receptor;
        fecha = fech;
        Resultado = result;
        TipoUnidadDañana = TipoUnidDestr;
	}
}