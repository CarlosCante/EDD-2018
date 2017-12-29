using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Matriz
/// </summary>
public class Matriz
{
    public int TamañoX;
    public int TamañoY;

    public int NoUnidadesSateliteJ1;
    public int NoUnidadesAvionJ1;
    public int NoUnidadesBarcoJ1;
    public int NoUnidadesSubmarinoJ1;

    public int NoUnidadesSateliteJ2;
    public int NoUnidadesAvionJ2;
    public int NoUnidadesBarcoJ2;
    public int NoUnidadesSubmarinoJ2;

    public CabezerasX CX;
    public CabezerasY CY;

    string[] Tiposdeunidades = new string[7];
    string[] Jugadores = new string[3];

    public string Juagdor1;
    public string Jugador2;

    public int TipoDeJuego;
    public Matriz(string j1, string j2, int uniSub, int uniBa, int uniAv, int uniSa, int dimx, int dimy, int tipo)
	{
        CX = new CabezerasX();
        CY = new CabezerasY();

        Juagdor1 = j1;
        Jugador2 = j2;

        TamañoX = dimx;
        TamañoY = dimy;

        NoUnidadesSateliteJ1 = uniSa;
        NoUnidadesAvionJ1 = uniAv;
        NoUnidadesBarcoJ1 = uniBa;
        NoUnidadesSubmarinoJ1 = uniSub;

        NoUnidadesSateliteJ2 = uniSa;
        NoUnidadesAvionJ2 = uniAv;
        NoUnidadesBarcoJ2 = uniBa;
        NoUnidadesSubmarinoJ2 = uniSub;

        TipoDeJuego = tipo;

        Tiposdeunidades[0] = "Neosatelite";
        Tiposdeunidades[1] = "Bombardero";
        Tiposdeunidades[2] = "Caza";
        Tiposdeunidades[3] = "Helicoptero de combate";
        Tiposdeunidades[4] = "Fragata";
        Tiposdeunidades[5] = "Crucero";
        Tiposdeunidades[6] = "Submarino";

        Jugadores[1] = j1;
        Jugadores[2] = j2;
	}

    public bool InsertarUnidad(NodoUnidad nuevo)
    {
        switch (nuevo.Jugador)
        {
            case 1:// se inserta la unidad en la mitad correspondiente de el jugador 1
                if(nuevo.CooX <= TamañoX/2 && nuevo.CooY <= TamañoY && nuevo.CooX <= TamañoX && nuevo.CooZ <= 4)
                {
                    //Se crean la nuevas cabezeras si estas no existen
                    CX.Insertar(new NodoCabezeraX(nuevo.CooX, nuevo.CooZ));
                    CY.Insertar(new NodoCabezeraY(nuevo.CooY, nuevo.CooZ));

                    NodoCabezeraX tmpx = CX.BuscarNodo(nuevo.CooX, nuevo.CooZ);
                    NodoCabezeraY tmpy = CY.BuscarNodo(nuevo.CooY, nuevo.CooZ);

                    tmpx.lista.Insertar(nuevo);
                    tmpy.lista.Insertar(nuevo);

                }
                else
                {
                    return false;
                }


                break;
            case 2:// se inserta la unidad en la mitad correspondiente de el jugador 2
                if (nuevo.CooX > TamañoX / 2 && nuevo.CooY <= TamañoY && nuevo.CooX <= TamañoX && nuevo.CooZ <= 4)
                {
                    //Se crean la nuevas cabezeras si estas no existen
                    CX.Insertar(new NodoCabezeraX(nuevo.CooX, nuevo.CooZ));
                    CY.Insertar(new NodoCabezeraY(nuevo.CooY, nuevo.CooZ));

                    NodoCabezeraX tmpx = CX.BuscarNodo(nuevo.CooX, nuevo.CooZ);
                    NodoCabezeraY tmpy = CY.BuscarNodo(nuevo.CooY, nuevo.CooZ);

                    tmpx.lista.Insertar(nuevo);
                    tmpy.lista.Insertar(nuevo);

                }
                else
                {
                    return false;
                }




                break;
            default:
                break;
        }
        return false;
    }


    //*****************************GRAFICAS DEL TABLERO COMPLETO***************************************
    public string GraficarNivel0J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if(tmpx.Abajo != null)
            {
                grafo += "\"X" + tmpx.Abajo.PosX.ToString() + "\";";
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if(tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy.Abajo.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            if(tmpx.Abajo != null)
            {
                tmpunidad = tmpx.Abajo.lista.Primero;

                while (tmpunidad != null)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    if (tmpunidad.Abajo != null)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
            }
            


            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if(tmpx.Abajo != null)
            {
                tmpunidad = tmpx.Abajo.lista.Primero;

                grafo += "\"X" + tmpx.Abajo.PosX.ToString() + "\"";

                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }

            }
            
            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if(tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;

                while (tmpunidad != null)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    if (tmpunidad.Derecha != null)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"[constraint=false];\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
            }
            
            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if(tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;

                grafo += "\"Y" + tmpy.Abajo.PosY.ToString() + "\"";


                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
            }
            
            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if(tmpx.Abajo != null)
            {
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx.Abajo.PosX + "\";\n";

        

        while (tmpx != null)
        {
            if(tmpx.Abajo != null)
            {
                grafo += "\"X" + tmpx.Abajo.PosX + "\"";

                tmpx = tmpx.Derecha;

                while(tmpx != null)
                {
                    if(tmpx.Abajo != null)
                    {
                        grafo += " -> " + "\"X" + tmpx.Abajo.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }
                
            }
            
        }

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                grafo += "\"Y" + tmpy.Abajo.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Abajo != null)
                    {
                        grafo += " -> " + "\"Y" + tmpy.Abajo.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

            }

        }


        grafo += "}\n";





        return grafo;
    }

    public string GraficarNivel1J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            grafo += "\"X" + tmpx.PosX.ToString() + "\";";
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;
            grafo += "{rank=same;\"Y" + tmpy.PosY.ToString() + "\";";
            while (tmpunidad != null)
            {
                 grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n" 
                        + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n" 
                        + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                 tmpunidad = tmpunidad.Derecha;
            }

            grafo += "};\n";

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            tmpunidad = tmpx.lista.Primero;

            while (tmpunidad != null)
            {
                 grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                if(tmpunidad.Abajo != null)
                {
                    grafo += " -> ";

                    grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"\n";

                    grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"";

                    grafo += " -> ";

                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }

                
                tmpunidad = tmpunidad.Abajo;
            }


            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            tmpunidad = tmpx.lista.Primero;

            grafo += "\"X" + tmpx.PosX.ToString() + "\"";

            if(tmpunidad != null)
            {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
            }

            

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;

            while (tmpunidad != null)
            {
                grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                if (tmpunidad.Derecha != null)
                {
                    grafo += " -> ";

                    grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"[constraint=false];\n";

                    grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"";

                    grafo += " -> ";

                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }


                tmpunidad = tmpunidad.Derecha;
            }


            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;



            grafo += "\"Y" + tmpy.PosY.ToString() + "\"";


            if(tmpunidad != null)
            {
                grafo += " -> ";
                grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
            }
            

            tmpy = tmpy.Derecha;
        }



        grafo += "\"Matriz\" -> \"X" + CX.primero.PosX + "\";\n";

        tmpx = CX.primero;

        while (tmpx != null)
        {
             if (tmpx.Derecha != null)
            {
                grafo += "\"X" + tmpx.PosX + "\" -> \"X" + tmpx.Derecha.PosX + "\";\n";
            }
            tmpx = tmpx.Derecha;
        }


        grafo += "\"Matriz\" -> \"Y" + CY.primero.PosY + "\"[rankdir=UD];\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Derecha != null)
            {
                grafo += "\"Y" + tmpy.PosY + "\" -> \"Y" + tmpy.Derecha.PosY + "\"[rankdir=UD];\n";
            }
            tmpy = tmpy.Derecha;
        }


        grafo += "}\n";





        return grafo;
    }

    public string GraficarNivel2J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"X" + tmpx.Arriba.PosX.ToString() + "\";";
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy.Arriba.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                tmpunidad = tmpx.Arriba.lista.Primero;

                while (tmpunidad != null)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    if (tmpunidad.Abajo != null)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                tmpunidad = tmpx.Arriba.lista.Primero;

                grafo += "\"X" + tmpx.Arriba.PosX.ToString() + "\"";

                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }

            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;

                while (tmpunidad != null)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    if (tmpunidad.Derecha != null)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"[constraint=false];\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;

                grafo += "\"Y" + tmpy.Arriba.PosY.ToString() + "\"";


                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx.Arriba.PosX + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"X" + tmpx.Arriba.PosX + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"X" + tmpx.Arriba.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

            }

        }

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy.Arriba.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                grafo += "\"Y" + tmpy.Arriba.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"Y" + tmpy.Arriba.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

            }

        }


        grafo += "}\n";


        return grafo;
    }

    public string GraficarNivel3J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraX tmpx2 = null;
        NodoCabezeraY tmpy = CY.primero;
        NodoCabezeraY tmpy2 = null;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if(tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if(tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                grafo += "\"X" + tmpx2.PosX.ToString() + "\";";
                tmpx2 = null;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {

            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy2.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if(tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                tmpunidad = tmpx2.lista.Primero;

                while (tmpunidad != null)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    if (tmpunidad.Abajo != null)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Abajo.tipo] + tmpunidad.Abajo.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Abajo.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Abajo.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
                tmpx2 = null;
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if(tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                tmpunidad = tmpx2.lista.Primero;

                grafo += "\"X" + tmpx2.PosX.ToString() + "\"";

                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }
                tmpx2 = null;
            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {

            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;

                while (tmpunidad != null)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    if (tmpunidad.Derecha != null)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"[constraint=false];\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.Derecha.tipo] + tmpunidad.Derecha.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Derecha.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Derecha.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;

                grafo += "\"Y" + tmpy2.PosY.ToString() + "\"";


                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
                break;
            }
            else if(tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx2.PosX + "\";\n";

        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if(tmpx2 != null)
            {
                grafo += "\"X" + tmpx2.PosX + "\"";
                tmpx2 = null;
                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
                    {
                        tmpx2 = tmpx.Arriba;
                    }
                    else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
                    {
                        tmpx2 = tmpx.Arriba.Arriba;
                    }

                    if (tmpx2 != null)
                    {
                        grafo += " -> " + "\"X" + tmpx2.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

                tmpx2 = null;
            }

            tmpx = tmpx.Derecha;
        }

        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
                break;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy2.PosY + "\";\n";

        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                grafo += "\"Y" + tmpy2.PosY + "\"";
                tmpy2 = null;
                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
                    {
                        tmpy2 = tmpy.Arriba;
                    }
                    else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
                    {
                        tmpy2 = tmpy.Arriba.Arriba;
                    }

                    if (tmpy2 != null)
                    {
                        grafo += " -> " + "\"Y" + tmpy2.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }


        grafo += "}\n";


        return grafo;
    }


    //*****************************GRAFICAS DEL TABLERO MOSTRANDO SOLO LAS UNIDADES SOBREVIVIENTES********************

    public string GraficarN0UnidadesSob()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                grafo += "\"X" + tmpx.Abajo.PosX.ToString() + "\";";
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy.Abajo.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {
                    if(tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    }

                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
            }

            tmpy = tmpy.Derecha;
        }

        //*******************************************
        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                tmpunidad = tmpx.Abajo.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Abajo;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 1)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Abajo;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                        }
                    }
                    tmpunidad = tmpunidad.Abajo;
                }
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                tmpunidad = tmpx.Abajo.lista.Primero;

                grafo += "\"X" + tmpx.Abajo.PosX.ToString() + "\"";

                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 1)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Abajo;
                }

                if (tmpunidad != null && tmpunidad.estado == 1)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }


            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Derecha;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 1)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Derecha;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                        }
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;

                grafo += "\"Y" + tmpy.Abajo.PosY.ToString() + "\"";


                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 1)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Derecha;
                }

                if (tmpunidad != null && tmpunidad.estado == 1)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx.Abajo.PosX + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                grafo += "\"X" + tmpx.Abajo.PosX + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Abajo != null)
                    {
                        grafo += " -> " + "\"X" + tmpx.Abajo.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

            }

        }

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                grafo += "\"Y" + tmpy.Abajo.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Abajo != null)
                    {
                        grafo += " -> " + "\"Y" + tmpy.Abajo.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

            }

        }


        grafo += "}\n";





        return grafo;
    }
    public string GraficarN1UnidadesSob()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            grafo += "\"X" + tmpx.PosX.ToString() + "\";";
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;
            grafo += "{rank=same;\"Y" + tmpy.PosY.ToString() + "\";";
            while (tmpunidad != null)
            {
                if(tmpunidad.estado == 1)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                }
                
                tmpunidad = tmpunidad.Derecha;
            }

            grafo += "};\n";

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            tmpunidad = tmpx.lista.Primero;
            

            while (tmpunidad != null)
            {
                if(tmpunidad.estado == 1)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                      + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                      + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    tmpunidad2 = tmpunidad.Abajo;

                    while (tmpunidad2 != null)
                    {
                        if(tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            break;
                        }
                        tmpunidad2 = tmpunidad2.Abajo;
                    }

                    if (tmpunidad2 != null && tmpunidad2.estado == 1)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                    }
                }

                

                tmpunidad = tmpunidad.Abajo;
            }


            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            tmpunidad = tmpx.lista.Primero;

            grafo += "\"X" + tmpx.PosX.ToString() + "\"";

            while (tmpunidad != null)
            {
                if(tmpunidad != null && tmpunidad.estado == 1)
                {
                    break;
                }
                tmpunidad = tmpunidad.Abajo;
            }

            if (tmpunidad != null && tmpunidad.estado == 1)
            {
                grafo += " -> ";
                grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                        + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                        + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
            }



            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;

            while (tmpunidad != null)
            {
                if(tmpunidad.estado == 1)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    tmpunidad2 = tmpunidad.Derecha;

                    while (tmpunidad2 != null)
                    {
                        if(tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            break;
                        }
                        tmpunidad2 = tmpunidad2.Derecha;
                    }

                    if (tmpunidad2 != null && tmpunidad2.estado == 1)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                    }
                }

                tmpunidad = tmpunidad.Derecha;
            }


            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;



            grafo += "\"Y" + tmpy.PosY.ToString() + "\"";

            while (tmpunidad != null)
            {
                if(tmpunidad != null && tmpunidad.estado ==1)
                {
                    break;
                }
                tmpunidad = tmpunidad.Derecha;
            }

            if (tmpunidad != null && tmpunidad.estado == 1)
            {
                grafo += " -> ";
                grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
            }


            tmpy = tmpy.Derecha;
        }



        grafo += "\"Matriz\" -> \"X" + CX.primero.PosX + "\";\n";

        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Derecha != null)
            {
                grafo += "\"X" + tmpx.PosX + "\" -> \"X" + tmpx.Derecha.PosX + "\";\n";
            }
            tmpx = tmpx.Derecha;
        }


        grafo += "\"Matriz\" -> \"Y" + CY.primero.PosY + "\"[rankdir=UD];\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Derecha != null)
            {
                grafo += "\"Y" + tmpy.PosY + "\" -> \"Y" + tmpy.Derecha.PosY + "\"[rankdir=UD];\n";
            }
            tmpy = tmpy.Derecha;
        }


        grafo += "}\n";





        return grafo;
    }
    public string GraficarN2UnidadesSob()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"X" + tmpx.Arriba.PosX.ToString() + "\";";
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy.Arriba.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    }

                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                tmpunidad = tmpx.Arriba.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Abajo;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 1)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Abajo;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                        }
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                tmpunidad = tmpx.Arriba.lista.Primero;

                grafo += "\"X" + tmpx.Arriba.PosX.ToString() + "\"";

                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 1)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Abajo;
                }

                if (tmpunidad != null && tmpunidad.estado == 1)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }

            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Derecha;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 1)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Derecha;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                        }
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;

                grafo += "\"Y" + tmpy.Arriba.PosY.ToString() + "\"";


                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 1)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Derecha;
                }

                if (tmpunidad != null && tmpunidad.estado == 1)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx.Arriba.PosX + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"X" + tmpx.Arriba.PosX + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"X" + tmpx.Arriba.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

            }

        }

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy.Arriba.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                grafo += "\"Y" + tmpy.Arriba.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"Y" + tmpy.Arriba.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

            }

        }


        grafo += "}\n";


        return grafo;
    }
    public string GraficarN3UnidadesSob()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraX tmpx2 = null;
        NodoCabezeraY tmpy = CY.primero;
        NodoCabezeraY tmpy2 = null;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                grafo += "\"X" + tmpx2.PosX.ToString() + "\";";
                tmpx2 = null;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {

            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy2.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    }

                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                tmpunidad = tmpx2.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Abajo;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 1)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Abajo;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                        }
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
                tmpx2 = null;
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                tmpunidad = tmpx2.lista.Primero;

                grafo += "\"X" + tmpx2.PosX.ToString() + "\"";

                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 1)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Abajo;
                }

                if (tmpunidad != null && tmpunidad.estado == 1)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }
                tmpx2 = null;
            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {

            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 1)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Derecha;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 1)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Derecha;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 1)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                        }
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;

                grafo += "\"Y" + tmpy2.PosY.ToString() + "\"";


                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 1)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Derecha;
                }

                if (tmpunidad != null && tmpunidad.estado == 1)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
                break;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx2.PosX + "\";\n";

        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                grafo += "\"X" + tmpx2.PosX + "\"";
                tmpx2 = null;
                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
                    {
                        tmpx2 = tmpx.Arriba;
                    }
                    else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
                    {
                        tmpx2 = tmpx.Arriba.Arriba;
                    }

                    if (tmpx2 != null)
                    {
                        grafo += " -> " + "\"X" + tmpx2.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

                tmpx2 = null;
            }

            tmpx = tmpx.Derecha;
        }

        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
                break;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy2.PosY + "\";\n";

        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                grafo += "\"Y" + tmpy2.PosY + "\"";
                tmpy2 = null;
                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
                    {
                        tmpy2 = tmpy.Arriba;
                    }
                    else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
                    {
                        tmpy2 = tmpy.Arriba.Arriba;
                    }

                    if (tmpy2 != null)
                    {
                        grafo += " -> " + "\"Y" + tmpy2.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }


        grafo += "}\n";


        return grafo;
    }

    //*****************************GRAFICAS DEL TABLERO MOSTRANDO SOLO LAS UNIDADES DESTRUIDAS********************

    public string GraficarN0UnidadesDes()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                grafo += "\"X" + tmpx.Abajo.PosX.ToString() + "\";";
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy.Abajo.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    }

                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
            }

            tmpy = tmpy.Derecha;
        }

        //*******************************************
        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                tmpunidad = tmpx.Abajo.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Abajo;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 0)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Abajo;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                        }
                    }
                    tmpunidad = tmpunidad.Abajo;
                }
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                tmpunidad = tmpx.Abajo.lista.Primero;

                grafo += "\"X" + tmpx.Abajo.PosX.ToString() + "\"";

                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 0)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Abajo;
                }

                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }


            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Derecha;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 0)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Derecha;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                        }
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                tmpunidad = tmpy.Abajo.lista.Primero;

                grafo += "\"Y" + tmpy.Abajo.PosY.ToString() + "\"";


                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 0)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Derecha;
                }

                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx.Abajo.PosX + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                grafo += "\"X" + tmpx.Abajo.PosX + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Abajo != null)
                    {
                        grafo += " -> " + "\"X" + tmpx.Abajo.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

            }

        }

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                grafo += "\"Y" + tmpy.Abajo.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Abajo != null)
                    {
                        grafo += " -> " + "\"Y" + tmpy.Abajo.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

            }

        }


        grafo += "}\n";





        return grafo;
    }
    public string GraficarN1UnidadesDes()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            grafo += "\"X" + tmpx.PosX.ToString() + "\";";
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;
            grafo += "{rank=same;\"Y" + tmpy.PosY.ToString() + "\";";
            while (tmpunidad != null)
            {
                if (tmpunidad.estado == 0)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                }

                tmpunidad = tmpunidad.Derecha;
            }

            grafo += "};\n";

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            tmpunidad = tmpx.lista.Primero;


            while (tmpunidad != null)
            {
                if (tmpunidad.estado == 0)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                      + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                      + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    tmpunidad2 = tmpunidad.Abajo;

                    while (tmpunidad2 != null)
                    {
                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            break;
                        }
                        tmpunidad2 = tmpunidad2.Abajo;
                    }

                    if (tmpunidad2 != null && tmpunidad2.estado == 0)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                    }
                }



                tmpunidad = tmpunidad.Abajo;
            }


            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            tmpunidad = tmpx.lista.Primero;

            grafo += "\"X" + tmpx.PosX.ToString() + "\"";

            while (tmpunidad != null)
            {
                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    break;
                }
                tmpunidad = tmpunidad.Abajo;
            }

            if (tmpunidad != null && tmpunidad.estado == 0)
            {
                grafo += " -> ";
                grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                        + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                        + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
            }



            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;

            while (tmpunidad != null)
            {
                if (tmpunidad.estado == 0)
                {
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                    tmpunidad2 = tmpunidad.Derecha;

                    while (tmpunidad2 != null)
                    {
                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            break;
                        }
                        tmpunidad2 = tmpunidad2.Derecha;
                    }

                    if (tmpunidad2 != null && tmpunidad2.estado == 0)
                    {
                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                        grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                           + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                        grafo += " -> ";

                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                    }
                }

                tmpunidad = tmpunidad.Derecha;
            }


            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;



            grafo += "\"Y" + tmpy.PosY.ToString() + "\"";

            while (tmpunidad != null)
            {
                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    break;
                }
                tmpunidad = tmpunidad.Derecha;
            }

            if (tmpunidad != null && tmpunidad.estado == 0)
            {
                grafo += " -> ";
                grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                       + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                       + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
            }


            tmpy = tmpy.Derecha;
        }



        grafo += "\"Matriz\" -> \"X" + CX.primero.PosX + "\";\n";

        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Derecha != null)
            {
                grafo += "\"X" + tmpx.PosX + "\" -> \"X" + tmpx.Derecha.PosX + "\";\n";
            }
            tmpx = tmpx.Derecha;
        }


        grafo += "\"Matriz\" -> \"Y" + CY.primero.PosY + "\"[rankdir=UD];\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Derecha != null)
            {
                grafo += "\"Y" + tmpy.PosY + "\" -> \"Y" + tmpy.Derecha.PosY + "\"[rankdir=UD];\n";
            }
            tmpy = tmpy.Derecha;
        }


        grafo += "}\n";





        return grafo;
    }
    public string GraficarN2UnidadesDes()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"X" + tmpx.Arriba.PosX.ToString() + "\";";
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy.Arriba.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    }

                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                tmpunidad = tmpx.Arriba.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Abajo;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 0)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Abajo;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                        }
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                tmpunidad = tmpx.Arriba.lista.Primero;

                grafo += "\"X" + tmpx.Arriba.PosX.ToString() + "\"";

                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 0)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Abajo;
                }

                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }

            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Derecha;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 0)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Derecha;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                        }
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                tmpunidad = tmpy.Arriba.lista.Primero;

                grafo += "\"Y" + tmpy.Arriba.PosY.ToString() + "\"";


                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 0)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Derecha;
                }

                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx.Arriba.PosX + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"X" + tmpx.Arriba.PosX + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"X" + tmpx.Arriba.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

            }

        }

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy.Arriba.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                grafo += "\"Y" + tmpy.Arriba.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"Y" + tmpy.Arriba.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

            }

        }


        grafo += "}\n";


        return grafo;
    }
    public string GraficarN3UnidadesDes()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraX tmpx2 = null;
        NodoCabezeraY tmpy = CY.primero;
        NodoCabezeraY tmpy2 = null;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        string grafo = "";

        grafo += "digraph G {\n";
        grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
        grafo += "{rank=min;\"Matriz\";";

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                grafo += "\"X" + tmpx2.PosX.ToString() + "\";";
                tmpx2 = null;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {

            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;
                grafo += "{rank=same;\"Y" + tmpy2.PosY.ToString() + "\";";

                while (tmpunidad != null)
                {

                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID.ToString() + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\";";
                    }

                    tmpunidad = tmpunidad.Derecha;
                }

                grafo += "};\n";
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }


        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                tmpunidad = tmpx2.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                          + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                          + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Abajo;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 0)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Abajo;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                        }
                    }


                    tmpunidad = tmpunidad.Abajo;
                }
                tmpx2 = null;
            }



            tmpx = tmpx.Derecha;
        }



        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                tmpunidad = tmpx2.lista.Primero;

                grafo += "\"X" + tmpx2.PosX.ToString() + "\"";

                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 0)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Abajo;
                }

                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                            + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                            + "Vida: " + tmpunidad.Vida.ToString() + "\"\n";
                }
                tmpx2 = null;
            }

            tmpx = tmpx.Derecha;
        }



        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {

            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;

                while (tmpunidad != null)
                {
                    if (tmpunidad.estado == 0)
                    {
                        grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                        tmpunidad2 = tmpunidad.Derecha;

                        while (tmpunidad2 != null)
                        {
                            if (tmpunidad2 != null && tmpunidad2.estado == 0)
                            {
                                break;
                            }
                            tmpunidad2 = tmpunidad2.Derecha;
                        }

                        if (tmpunidad2 != null && tmpunidad2.estado == 0)
                        {
                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"[constraint=false];\n";

                            grafo += "\"" + Tiposdeunidades[tmpunidad2.tipo] + tmpunidad2.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad2.Jugador] + "\n"
                               + "Vida: " + tmpunidad2.Vida.ToString() + "\"";

                            grafo += " -> ";

                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                        }
                    }


                    tmpunidad = tmpunidad.Derecha;
                }
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }



        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                tmpunidad = tmpy2.lista.Primero;

                grafo += "\"Y" + tmpy2.PosY.ToString() + "\"";


                while (tmpunidad != null)
                {
                    if (tmpunidad != null && tmpunidad.estado == 0)
                    {
                        break;
                    }
                    tmpunidad = tmpunidad.Derecha;
                }

                if (tmpunidad != null && tmpunidad.estado == 0)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }
                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }



        tmpx = CX.primero;
        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
                break;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
                break;
            }
            tmpx = tmpx.Derecha;
        }

        grafo += "\"Matriz\" -> \"X" + tmpx2.PosX + "\";\n";

        tmpx2 = null;

        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba;
            }
            else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
            {
                tmpx2 = tmpx.Arriba.Arriba;
            }

            if (tmpx2 != null)
            {
                grafo += "\"X" + tmpx2.PosX + "\"";
                tmpx2 = null;
                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 3)
                    {
                        tmpx2 = tmpx.Arriba;
                    }
                    else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
                    {
                        tmpx2 = tmpx.Arriba.Arriba;
                    }

                    if (tmpx2 != null)
                    {
                        grafo += " -> " + "\"X" + tmpx2.PosX + "\"";
                        break;
                    }
                    tmpx = tmpx.Derecha;
                }

                tmpx2 = null;
            }

            tmpx = tmpx.Derecha;
        }

        tmpy = CY.primero;
        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
                break;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
                break;
            }
            tmpy = tmpy.Derecha;
        }

        grafo += "\"Matriz\" -> \"Y" + tmpy2.PosY + "\";\n";

        tmpy2 = null;

        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba;
            }
            else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
            {
                tmpy2 = tmpy.Arriba.Arriba;
            }

            if (tmpy2 != null)
            {
                grafo += "\"Y" + tmpy2.PosY + "\"";
                tmpy2 = null;
                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 3)
                    {
                        tmpy2 = tmpy.Arriba;
                    }
                    else if (tmpy.Arriba != null && tmpy.Arriba.Arriba != null && tmpy.Arriba.Arriba.PosZ == 3)
                    {
                        tmpy2 = tmpy.Arriba.Arriba;
                    }

                    if (tmpy2 != null)
                    {
                        grafo += " -> " + "\"Y" + tmpy2.PosY + "\"";
                        break;
                    }
                    tmpy = tmpy.Derecha;
                }

                tmpy2 = null;
            }

            tmpy = tmpy.Derecha;
        }


        grafo += "}\n";


        return grafo;
    }
}