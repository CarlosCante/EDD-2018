using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoJuego
/// </summary>
public class NodoJuego
{
    public string Oponente;
    public int UnidadesDesplegadas;
    public int UnidadesSobrevivientes;
    public int UnidadesDestruidas;
    public bool Gano;

    public NodoJuego anterior;
    public NodoJuego siguiente;

	public NodoJuego(string oponente, int UniDespl, int UniSob, int UniDestr, bool gano)
	{
        Oponente = oponente;
        UnidadesDesplegadas = UniDespl;
        UnidadesSobrevivientes = UniSob;
        UnidadesDestruidas = UniDestr;
        Gano = gano;

        anterior = null;
        siguiente = null;
	}
}