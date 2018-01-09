using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ListaJuegos
/// </summary>
public class ListaJuegos
{
    public NodoJuego Primero;
    public NodoJuego Ultimo;
	public ListaJuegos()
	{
        Primero = null;
        Ultimo = null;
	}

    public void Insertar(NodoJuego nuevo)
    {
        if(Primero == null)
        {
            Primero = nuevo;
            Ultimo = nuevo;
        }
        else
        {
            Ultimo.siguiente = nuevo;
            nuevo.anterior = Ultimo;
            Ultimo = nuevo;
        }
    }

    public string Graficar(string jugador)
    {
        string subgrafo = "subgraph cluster_Lista" + jugador + " {\n";

        subgrafo += "node [shape=box, style=filled];\n";
        subgrafo += "label = \"Lista de juegos " + jugador + "\";\n";
        subgrafo += "color = blue;\n";

        if (Primero != null)
        {
            NodoJuego aux = Primero;

            do
            {
                subgrafo += "\"Jugador: " + jugador + "\n";
                subgrafo += "Oponente: " + aux.Oponente + "\n";
                subgrafo += "Unidades Desplegadas: " + aux.UnidadesDesplegadas.ToString() + "\n";
                subgrafo += "Unidades Sobrevivientes: " + aux.UnidadesSobrevivientes.ToString() + "\n";
                subgrafo += "Unidades Destruidas: " + aux.UnidadesDestruidas + "\n";
                subgrafo += "Gano: " + aux.Gano.ToString() + "\"";

                if (aux.siguiente != null)
                {
                    subgrafo += " -> ";

                    subgrafo += "\"Jugador: " + jugador + "\n";
                    subgrafo += "Oponente: " + aux.siguiente.Oponente + "\n";
                    subgrafo += "Unidades Desplegadas: " + aux.siguiente.UnidadesDesplegadas.ToString() + "\n";
                    subgrafo += "Unidades Sobrevivientes: " + aux.siguiente.UnidadesSobrevivientes.ToString() + "\n";
                    subgrafo += "Unidades Destruidas: " + aux.siguiente.UnidadesDestruidas + "\n";
                    subgrafo += "Gano: " + aux.siguiente.Gano.ToString() + "\"";

                    subgrafo += "\n";

                    subgrafo += "\"Jugador: " + jugador + "\n";
                    subgrafo += "Oponente: " + aux.siguiente.Oponente + "\n";
                    subgrafo += "Unidades Desplegadas: " + aux.siguiente.UnidadesDesplegadas.ToString() + "\n";
                    subgrafo += "Unidades Sobrevivientes: " + aux.siguiente.UnidadesSobrevivientes.ToString() + "\n";
                    subgrafo += "Unidades Destruidas: " + aux.siguiente.UnidadesDestruidas + "\n";
                    subgrafo += "Gano: " + aux.siguiente.Gano.ToString() + "\"";

                    subgrafo += " -> ";

                    subgrafo += "\"Jugador: " + jugador + "\n";
                    subgrafo += "Oponente: " + aux.Oponente + "\n";
                    subgrafo += "Unidades Desplegadas: " + aux.UnidadesDesplegadas.ToString() + "\n";
                    subgrafo += "Unidades Sobrevivientes: " + aux.UnidadesSobrevivientes.ToString() + "\n";
                    subgrafo += "Unidades Destruidas: " + aux.UnidadesDestruidas + "\n";
                    subgrafo += "Gano: " + aux.Gano.ToString() + "\"";

                }

                aux = aux.siguiente;
            } while (aux != null);

        }
        else
        {
            return "";
        }

        subgrafo = subgrafo + "\n" + "}" + "\n\n";
        return subgrafo;
    }
}