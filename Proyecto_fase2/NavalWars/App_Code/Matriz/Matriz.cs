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

    public bool Listo;

    public int Tiempo;

    public int TurnoJugador;

    public string Bitacora;

    //++++++++++++++++++++++++++++++++++++++++++++++++METODOS DE LA MATRIZ++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public Matriz(string j1, string j2, int uniSub, int uniBa, int uniAv, int uniSa, int dimx, int dimy, int tipo, int tiempo, bool listo)
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

        Listo = listo;

        Tiempo = tiempo;

        TurnoJugador = 1;

        Bitacora = "";
	}

    //********************METODOS REFERENTES A LA INSERCION ELIMINACION Y MOVIMIENTO DENTRO DE LA MATRIZ************************

    public bool InsertarUnidad(NodoUnidad nuevo)
    {
        switch (nuevo.Jugador)
        {
            case 1:// se inserta la unidad en la mitad correspondiente de el jugador 1
                if(nuevo.CooX <= TamañoX/2 && nuevo.CooY <= TamañoY && nuevo.CooZ <= 4)
                {
                    //Se crean la nuevas cabezeras si estas no existen
                    CX.Insertar(new NodoCabezeraX(nuevo.CooX, nuevo.CooZ));
                    CY.Insertar(new NodoCabezeraY(nuevo.CooY, nuevo.CooZ));

                    NodoCabezeraX tmpx = CX.BuscarNodo(nuevo.CooX, nuevo.CooZ);
                    NodoCabezeraY tmpy = CY.BuscarNodo(nuevo.CooY, nuevo.CooZ);

                    if (tmpx.lista.Insertar(nuevo) && tmpy.lista.Insertar(nuevo))
                    {
                        return true;
                    }
                    return false;

                }
                else
                {
                    return false;
                }
            case 2:// se inserta la unidad en la mitad correspondiente de el jugador 2
                if (nuevo.CooX > TamañoX / 2 && nuevo.CooY <= TamañoY && nuevo.CooX <= TamañoX && nuevo.CooZ <= 4)
                {
                    //Se crean la nuevas cabezeras si estas no existen
                    CX.Insertar(new NodoCabezeraX(nuevo.CooX, nuevo.CooZ));
                    CY.Insertar(new NodoCabezeraY(nuevo.CooY, nuevo.CooZ));

                    NodoCabezeraX tmpx = CX.BuscarNodo(nuevo.CooX, nuevo.CooZ);
                    NodoCabezeraY tmpy = CY.BuscarNodo(nuevo.CooY, nuevo.CooZ);

                    if (tmpx.lista.Insertar(nuevo) && tmpy.lista.Insertar(nuevo))
                    {
                        return true;
                    }
                    return false;

                }
                else
                {
                    return false;
                }
            default:
                break;
        }
        return false;
    }

    public void CambiarTurno(int j)
    {
        switch (j)
        {
            case 1:
                if(TurnoJugador == 1)
                {
                    TurnoJugador = 2;
                    Bitacora += "Termino turno de jugador 1\n\n";
                }
                break;
            case 2:
                if(TurnoJugador == 2)
                {
                    TurnoJugador = 1;
                    Bitacora += "Termino turno de jugador 2\n\n";
                }
                break;
            default:
                break;
        }
    }

    public bool InsertarUnidad_Auxiliar(NodoUnidad nuevo)
    {
        //Se crean la nuevas cabezeras si estas no existen
        CX.Insertar(new NodoCabezeraX(nuevo.CooX, nuevo.CooZ));
        CY.Insertar(new NodoCabezeraY(nuevo.CooY, nuevo.CooZ));

        NodoCabezeraX tmpx = CX.BuscarNodo(nuevo.CooX, nuevo.CooZ);
        NodoCabezeraY tmpy = CY.BuscarNodo(nuevo.CooY, nuevo.CooZ);

        if (tmpx.lista.Insertar(nuevo) && tmpy.lista.Insertar(nuevo))
        {
            return true;
        }
        return false;
    }

    public bool EliminarUnidad(int x, int y, int z, int Jugador)
    {
        NodoCabezeraX tmpx = CX.BuscarNodo(x, z);
        NodoCabezeraY tmpy = CY.BuscarNodo(y, z);

        if (tmpx.lista.Eliminar(y, Jugador) && tmpy.lista.Eliminar(x, Jugador))
        {
            return true;
        }
        return false;
    }

    public bool MoverPieza(int Xorigen, int Yorigen, int Zorigen, int Xdestino, int Ydestino, int Zdestino, int jugador)
    {
        NodoUnidad tmp = BuscarUnidad(Xorigen, Yorigen, Zorigen);
        if(tmp != null)
        {
            if(tmp.Jugador == jugador)
            {
                //Verificacion del tipo y si puede moverse al destino deseado
                switch (tmp.tipo)
                {
                    case 0:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 6)
                        {
                            break;
                        }
                        return false;
                    case 1:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 7)
                        {
                            break;
                        }
                        return false;
                    case 2:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 9)
                        {
                            break;
                        }
                        return false;
                    case 3:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 9)
                        {
                            break;
                        }
                        return false;
                    case 4:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 5)
                        {
                            break;
                        }
                        return false;
                    case 5:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 6)
                        {
                            break;
                        }
                        return false;
                    case 6:
                        if (Math.Abs(tmp.CooX - Xdestino) + Math.Abs(tmp.CooY - Ydestino) <= 5)
                        {
                            break;
                        }
                        return false;
                    default:
                        return false;
                }

                //Si puede mover los espacios
                //Verificar si el espacio de destino esta vacio
                NodoUnidad tmp2 = BuscarUnidad(Xdestino, Ydestino, Zdestino);
                if (tmp2 != null)
                {
                    return false;
                }

                //El destino esta disponible para moverse

                if (EliminarUnidad(Xorigen, Yorigen, Zorigen, jugador))
                {

                    tmp.CooX = Xdestino;
                    tmp.CooY = Ydestino;
                    tmp.CooZ = Zdestino;
                    tmp.Arriba = null;
                    tmp.Abajo = null;
                    tmp.Derecha = null;
                    tmp.Izquierda = null;
                    return InsertarUnidad_Auxiliar(tmp);
                }
                else
                {
                    return false;
                }

            }
        }
        return false;
    }
   
    NodoUnidad BuscarUnidad(int x, int y, int z)
    {
        NodoCabezeraX tmpx = CX.BuscarNodo(x, z);
        NodoUnidad tmp = null;

        if(tmpx != null)
        {
            tmp = tmpx.lista.Primero;
            while (tmp != null)
            {
                if (tmp.CooY == y)
                {
                    break;
                }
                tmp = tmp.Abajo;
            }
        }
        return tmp;
    }

    public string Atacar(int Xorigen, int Yorigen, int Zorigen, int Xdestino, int Ydestino, int Zdestino, int Jatacante, int Jdañado)
    {
        NodoUnidad atacante = BuscarUnidad(Xorigen, Yorigen, Zorigen);
        NodoUnidad objetivo = BuscarUnidad(Xdestino, Ydestino, Zdestino);
        if(atacante != null && objetivo != null)
        {
            if(atacante.Jugador == Jatacante)
            {
                if(objetivo.Jugador == Jdañado)
                {
                    switch (atacante.tipo)
                    {
                        case 0://**************SATELITE*************
                            if((atacante.CooX == objetivo.CooX) && (atacante.CooY == objetivo.CooY) && (objetivo.CooZ < atacante.CooZ))
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";



                        case 1://*****************BOMVARDERO*****************
                            if((atacante.CooX == objetivo.CooX) && (atacante.CooY == objetivo.CooY) && (objetivo.CooZ < atacante.CooZ))
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";



                        case 2://********************CAZA*************************
                            if ((Math.Abs(atacante.CooX - objetivo.CooX) + Math.Abs(atacante.CooY - objetivo.CooY) == 1) && atacante.CooZ == objetivo.CooZ)
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";


                        case 3:
                            if ((Math.Abs(atacante.CooX - objetivo.CooX) + Math.Abs(atacante.CooY - objetivo.CooY) == 1) && atacante.CooZ == objetivo.CooZ)
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";


                            
                        case 4:
                            if ((Math.Abs(atacante.CooX - objetivo.CooX) + Math.Abs(atacante.CooY - objetivo.CooY) <= 6)
                                &&
                                (Math.Abs(atacante.CooX - objetivo.CooX) + Math.Abs(atacante.CooY - objetivo.CooY) >= 2)
                                &&
                                (objetivo.CooZ == atacante.CooZ)
                                )
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";



                        case 5:
                            if ((Math.Abs(atacante.CooX - objetivo.CooX) + Math.Abs(atacante.CooY - objetivo.CooY) == 1) && atacante.CooZ == objetivo.CooZ)
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";



                        case 6:
                            if ((Math.Abs(atacante.CooX - objetivo.CooX) + Math.Abs(atacante.CooY - objetivo.CooY) == 1) && atacante.CooZ == objetivo.CooZ)
                            {
                                objetivo.Vida = objetivo.Vida - atacante.Daño;
                                if(objetivo.Vida <= 0)
                                {
                                    EliminarUnidad(objetivo.CooX,objetivo.CooY,objetivo.CooZ,Jdañado);
                                    return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " eliminado por " + Tiposdeunidades[atacante.tipo] + atacante.ID;
                                }
                                return "Objetivo: " + Tiposdeunidades[objetivo.tipo] + objetivo.ID + " recibio " + atacante.Daño + "puntos de daño";
                            }
                            return "El objetivo esta fuera del alcance de la unidad.";

                        default:
                            return "No se pudo relizar el ataque";
                    }
                }
                else
                {
                    return "La unidad atacada te pertenece.";
                }
            }
            else
            {
                return "La unidad seleccionada para realizar el ataque no te pertenece.";
            }
        }

        return "Alguna de las 2 unidades no existe";
       
    }
   
    //**********************GRAFICAS DEL TABLERO COMPLETO JUGADOR 1 Y JUGADOR 2 EN LOS NIVELES DEL 1 AL 3************************
    public string GraficarNivel1J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;
        bool Vacia = true;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";

        if (tmpx != null)
        {

            grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
            grafo += "{rank=min;\"Matriz\";";

        
            while (tmpx != null)
            {
                grafo += "\"" + NumeroALetras(tmpx.PosX) + "\";";
                tmpx = tmpx.Derecha;
                Vacia = false;
            }

            if(Vacia == true)
            {
                grafo = "digraph G {\n}";
                return grafo;
            }

            grafo += "};\n";

            tmpy = CY.primero;

            while (tmpy != null)
            {
                tmpunidad = tmpy.lista.Primero;
                grafo += "{rank=same;\"" + tmpy.PosY.ToString() + "\";";
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


                tmpx = tmpx.Derecha;
            }



            tmpx = CX.primero;

            while (tmpx != null)
            {
                tmpunidad = tmpx.lista.Primero;

                grafo += "\"" + NumeroALetras(tmpx.PosX) + "\"";

                if (tmpunidad != null)
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



                grafo += "\"" + tmpy.PosY.ToString() + "\"";


                if (tmpunidad != null)
                {
                    grafo += " -> ";
                    grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                           + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                           + "Vida: " + tmpunidad.Vida.ToString() + "\"[constraint=false];\n";
                }


                tmpy = tmpy.Derecha;
            }



            grafo += "\"Matriz\" -> \"" + NumeroALetras(CX.primero.PosX) + "\";\n";

            tmpx = CX.primero;

            while (tmpx != null)
            {
                if (tmpx.Derecha != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.PosX) + "\" -> \"" + NumeroALetras(tmpx.Derecha.PosX) + "\";\n";
                }
                tmpx = tmpx.Derecha;
            }


            grafo += "\"Matriz\" -> \"" + CY.primero.PosY + "\"[rankdir=UD];\n";

            tmpy = CY.primero;

            while (tmpy != null)
            {
                if (tmpy.Derecha != null)
                {
                    grafo += "\"" + tmpy.PosY + "\" -> \"" + tmpy.Derecha.PosY + "\"[rankdir=UD];\n";
                }
                tmpy = tmpy.Derecha;
            }
        }

        


        grafo += "}\n";





        return grafo;
    }

    public string GraficarNivel2J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;
        bool Vacia = true;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";


        if (tmpx != null)
        {

            grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
            grafo += "{rank=min;\"Matriz\";";

            while (tmpx != null)
            {
                if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\";";
                    Vacia = false;
                }
                tmpx = tmpx.Derecha;
            }

            if(Vacia == true)
            {
                grafo = "digraph G {\n}";
                return grafo;
            }

            grafo += "};\n";

            tmpy = CY.primero;

            while (tmpy != null)
            {
                if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                {
                    tmpunidad = tmpy.Arriba.lista.Primero;
                    grafo += "{rank=same;\"" + tmpy.Arriba.PosY.ToString() + "\";";

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

                    grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";

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

                    grafo += "\"" + tmpy.Arriba.PosY.ToString() + "\"";


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

            grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Arriba.PosX) + "\";\n";



            while (tmpx != null)
            {
                if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";

                    tmpx = tmpx.Derecha;

                    while (tmpx != null)
                    {
                        if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                        {
                            grafo += " -> " + "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";
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

            grafo += "\"Matriz\" -> \"" + tmpy.Arriba.PosY + "\"[rankdir=UD];\n";



            while (tmpy != null)
            {
                if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                {
                    grafo += "\"" + tmpy.Arriba.PosY + "\"";

                    tmpy = tmpy.Derecha;

                    while (tmpy != null)
                    {
                        if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                        {
                            grafo += " -> " + "\"" + tmpy.Arriba.PosY + "\"";
                            break;
                        }
                        tmpy = tmpy.Derecha;
                    }

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
        bool Vacia = true;

        NodoUnidad tmpunidad = null;

        string grafo = "";

        grafo += "digraph G {\n";

        if(tmpx != null)
        {

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
                    grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\";";
                    Vacia = false;
                    tmpx2 = null;
                }
                tmpx = tmpx.Derecha;
            }

            if(Vacia == true)
            {
                grafo = "digraph G {\n}";
                return grafo;
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
                    grafo += "{rank=same;\"" + tmpy2.PosY.ToString() + "\";";

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
                else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
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
                else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
                {
                    tmpx2 = tmpx.Arriba.Arriba;
                }

                if (tmpx2 != null)
                {
                    tmpunidad = tmpx2.lista.Primero;

                    grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\"";

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

                    grafo += "\"" + tmpy2.PosY.ToString() + "\"";


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
                else if (tmpx.Arriba != null && tmpx.Arriba.Arriba != null && tmpx.Arriba.Arriba.PosZ == 3)
                {
                    tmpx2 = tmpx.Arriba.Arriba;
                    break;
                }
                tmpx = tmpx.Derecha;
            }

            grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx2.PosX) + "\";\n";

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
                    grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\"";
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
                            grafo += " -> " + "\"" + NumeroALetras(tmpx2.PosX) + "\"\n";
                            break;
                        }
                        tmpx = tmpx.Derecha;
                    }

                    tmpx2 = null;
                }
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

            grafo += "\"Matriz\" -> \"" + tmpy2.PosY + "\";\n";

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
                    grafo += "\"" + tmpy2.PosY + "\"";
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
                            grafo += " -> " + "\"" + tmpy2.PosY + "\"";
                            break;
                        }
                        tmpy = tmpy.Derecha;
                    }

                    tmpy2 = null;
                }
            }

        }

       

        grafo += "}\n";


        return grafo;
    }

    public string GraficarNivel0J1()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        bool Vacia = true;

        string grafo = "";

        grafo += "digraph G {\n";

        if (tmpx != null)
        {

            grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
            grafo += "{rank=min;\"Matriz\";";


            while (tmpx != null)
            {
                if (tmpx.Abajo != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\";";
                    Vacia = false;
                }
                tmpx = tmpx.Derecha;
            }

            if (Vacia == true)
            {
                grafo = "digraph G {\n}";
                return grafo;
            }

            grafo += "};\n";

            tmpy = CY.primero;

            while (tmpy != null)
            {
                if (tmpy.Abajo != null)
                {
                    tmpunidad = tmpy.Abajo.lista.Primero;
                    grafo += "{rank=same;\"" + tmpy.Abajo.PosY.ToString() + "\";";

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
                if (tmpx.Abajo != null)
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
                if (tmpx.Abajo != null)
                {
                    tmpunidad = tmpx.Abajo.lista.Primero;

                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

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
                if (tmpy.Abajo != null)
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
                if (tmpy.Abajo != null)
                {
                    tmpunidad = tmpy.Abajo.lista.Primero;

                    grafo += "\"" + tmpy.Abajo.PosY.ToString() + "\"";


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
                if (tmpx.Abajo != null)
                {
                    break;
                }
                tmpx = tmpx.Derecha;
            }

            grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Abajo.PosX) + "\";\n";



            while (tmpx != null)
            {
                if (tmpx.Abajo != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                    tmpx = tmpx.Derecha;

                    while (tmpx != null)
                    {
                        if (tmpx.Abajo != null)
                        {
                            grafo += " -> " + "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";
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

            grafo += "\"Matriz\" -> \"" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



            while (tmpy != null)
            {
                if (tmpy.Abajo != null)
                {
                    grafo += "\"" + tmpy.Abajo.PosY + "\"";

                    tmpy = tmpy.Derecha;

                    while (tmpy != null)
                    {
                        if (tmpy.Abajo != null)
                        {
                            grafo += " -> " + "\"" + tmpy.Abajo.PosY + "\"";
                            break;
                        }
                        tmpy = tmpy.Derecha;
                    }

                }

            }
        }




        grafo += "}\n";





        return grafo;
    }

    //*****************************GRAFICAS DEL NIVEL 0 JUGADOR 1***************************************


    public string GraficarNivel0J1Nuevo()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        bool Vacia = true;

        string grafo = "";

        grafo += "digraph G {\n";

        if (tmpx != null)
        {

            grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
            grafo += "{rank=min;\"Matriz\";";

            while (tmpx != null)
            {
                if (tmpx.Abajo != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\";";
                    Vacia = false;
                }
                tmpx = tmpx.Derecha;
            }

            if (Vacia == true)
            {
                grafo = "digraph G {\n}";
                return grafo;
            }

            grafo += "};\n";

            tmpy = CY.primero;

            while (tmpy != null)
            {
                if (tmpy.Abajo != null)
                {
                    tmpunidad = tmpy.Abajo.lista.Primero;
                    grafo += "{rank=same;\"" + tmpy.Abajo.PosY.ToString() + "\";";

                    while (tmpunidad != null)
                    {
                        if (tmpunidad.Jugador == 1)
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
                        if (tmpunidad.Jugador == 1)
                        {
                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                              + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                              + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                            tmpunidad2 = tmpunidad.Abajo;

                            while (tmpunidad2 != null)
                            {
                                if (tmpunidad2 != null && tmpunidad2.Jugador == 1)
                                {
                                    break;
                                }
                                tmpunidad2 = tmpunidad2.Abajo;
                            }

                            if (tmpunidad2 != null && tmpunidad2.Jugador == 1)
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

                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                    while (tmpunidad != null)
                    {
                        if (tmpunidad != null && tmpunidad.Jugador == 1)
                        {
                            break;
                        }
                        tmpunidad = tmpunidad.Abajo;
                    }

                    if (tmpunidad != null && tmpunidad.Jugador == 1)
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
                        if (tmpunidad.Jugador == 1)
                        {
                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                            tmpunidad2 = tmpunidad.Derecha;

                            while (tmpunidad2 != null)
                            {
                                if (tmpunidad2 != null && tmpunidad2.Jugador == 1)
                                {
                                    break;
                                }
                                tmpunidad2 = tmpunidad2.Derecha;
                            }

                            if (tmpunidad2 != null && tmpunidad2.Jugador == 1)
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

                    grafo += "\"" + tmpy.Abajo.PosY.ToString() + "\"";


                    while (tmpunidad != null)
                    {
                        if (tmpunidad != null && tmpunidad.Jugador == 1)
                        {
                            break;
                        }
                        tmpunidad = tmpunidad.Derecha;
                    }

                    if (tmpunidad != null && tmpunidad.Jugador == 1)
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

            grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Abajo.PosX) + "\";\n";



            while (tmpx != null)
            {
                if (tmpx.Abajo != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                    tmpx = tmpx.Derecha;

                    while (tmpx != null)
                    {
                        if (tmpx.Abajo != null)
                        {
                            grafo += " -> " + "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";
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

            grafo += "\"Matriz\" -> \"" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



            while (tmpy != null)
            {
                if (tmpy.Abajo != null)
                {
                    grafo += "\"" + tmpy.Abajo.PosY + "\"";

                    tmpy = tmpy.Derecha;

                    while (tmpy != null)
                    {
                        if (tmpy.Abajo != null)
                        {
                            grafo += " -> " + "\"" + tmpy.Abajo.PosY + "\"";
                            break;
                        }
                        tmpy = tmpy.Derecha;
                    }

                }

            }

        }


        grafo += "}\n";





        return grafo;
    }


    //*****************************GRAFICAS DEL NIVEL 0 JUGADOR 2***************************************

    public string GraficarNivel0J2Nuevo()
    {
        NodoCabezeraX tmpx = CX.primero;
        NodoCabezeraY tmpy = CY.primero;

        NodoUnidad tmpunidad = null;
        NodoUnidad tmpunidad2 = null;

        bool Vacia = true;

        string grafo = "";

        grafo += "digraph G {\n";

        if (tmpx != null)
        {

            grafo += "node[shape=box, style=filled, color=Gray95];\n edge[color=black];\n rankdir=UD; \n";
            grafo += "{rank=min;\"Matriz\";";

            while (tmpx != null)
            {
                if (tmpx.Abajo != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\";";
                    Vacia = false;
                }
                tmpx = tmpx.Derecha;
            }

            if (Vacia == true)
            {
                grafo = "digraph G {\n}";
                return grafo;
            }

            grafo += "};\n";

            tmpy = CY.primero;

            while (tmpy != null)
            {
                if (tmpy.Abajo != null)
                {
                    tmpunidad = tmpy.Abajo.lista.Primero;
                    grafo += "{rank=same;\"" + tmpy.Abajo.PosY.ToString() + "\";";

                    while (tmpunidad != null)
                    {
                        if (tmpunidad.Jugador == 2)
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
                        if (tmpunidad.Jugador == 2)
                        {
                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                              + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                              + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                            tmpunidad2 = tmpunidad.Abajo;

                            while (tmpunidad2 != null)
                            {
                                if (tmpunidad2 != null && tmpunidad2.Jugador == 2)
                                {
                                    break;
                                }
                                tmpunidad2 = tmpunidad2.Abajo;
                            }

                            if (tmpunidad2 != null && tmpunidad2.Jugador == 2)
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

                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                    while (tmpunidad != null)
                    {
                        if (tmpunidad != null && tmpunidad.Jugador == 2)
                        {
                            break;
                        }
                        tmpunidad = tmpunidad.Abajo;
                    }

                    if (tmpunidad != null && tmpunidad.Jugador == 2)
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
                        if (tmpunidad.Jugador == 2)
                        {
                            grafo += "\"" + Tiposdeunidades[tmpunidad.tipo] + tmpunidad.ID + "\n"
                               + "Jugador: " + Jugadores[tmpunidad.Jugador] + "\n"
                               + "Vida: " + tmpunidad.Vida.ToString() + "\"";

                            tmpunidad2 = tmpunidad.Derecha;

                            while (tmpunidad2 != null)
                            {
                                if (tmpunidad2 != null && tmpunidad2.Jugador == 2)
                                {
                                    break;
                                }
                                tmpunidad2 = tmpunidad2.Derecha;
                            }

                            if (tmpunidad2 != null && tmpunidad2.Jugador == 2)
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

                    grafo += "\"" + tmpy.Abajo.PosY.ToString() + "\"";


                    while (tmpunidad != null)
                    {
                        if (tmpunidad != null && tmpunidad.Jugador == 2)
                        {
                            break;
                        }
                        tmpunidad = tmpunidad.Derecha;
                    }

                    if (tmpunidad != null && tmpunidad.Jugador == 2)
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

            grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Abajo.PosX) + "\";\n";



            while (tmpx != null)
            {
                if (tmpx.Abajo != null)
                {
                    grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                    tmpx = tmpx.Derecha;

                    while (tmpx != null)
                    {
                        if (tmpx.Abajo != null)
                        {
                            grafo += " -> " + "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";
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

            grafo += "\"Matriz\" -> \"" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



            while (tmpy != null)
            {
                if (tmpy.Abajo != null)
                {
                    grafo += "\"" + tmpy.Abajo.PosY + "\"";

                    tmpy = tmpy.Derecha;

                    while (tmpy != null)
                    {
                        if (tmpy.Abajo != null)
                        {
                            grafo += " -> " + "\"" + tmpy.Abajo.PosY + "\"";
                            break;
                        }
                        tmpy = tmpy.Derecha;
                    }

                }

            }

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
                grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\";";
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
                grafo += "{rank=same;\"" + tmpy.Abajo.PosY.ToString() + "\";";

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

                grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

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

                grafo += "\"" + tmpy.Abajo.PosY.ToString() + "\"";


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

        grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Abajo.PosX) + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Abajo != null)
                    {
                        grafo += " -> " + "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";
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

        grafo += "\"Matriz\" -> \"" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                grafo += "\"" + tmpy.Abajo.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Abajo != null)
                    {
                        grafo += " -> " + "\"" + tmpy.Abajo.PosY + "\"";
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
            grafo += "\"" + NumeroALetras(tmpx.PosX) + "\";";
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;
            grafo += "{rank=same;\"" + tmpy.PosY.ToString() + "\";";
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

            grafo += "\"" + NumeroALetras(tmpx.PosX) + "\"";

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



            grafo += "\"" + tmpy.PosY.ToString() + "\"";

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



        grafo += "\"Matriz\" -> \"" + NumeroALetras(CX.primero.PosX) + "\";\n";

        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Derecha != null)
            {
                grafo += "\"X" + tmpx.PosX + "\" -> \"" + NumeroALetras(tmpx.Derecha.PosX) + "\";\n";
            }
            tmpx = tmpx.Derecha;
        }


        grafo += "\"Matriz\" -> \"" + CY.primero.PosY + "\"[rankdir=UD];\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Derecha != null)
            {
                grafo += "\"" + tmpy.PosY + "\" -> \"Y" + tmpy.Derecha.PosY + "\"[rankdir=UD];\n";
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
                grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\";";
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
                grafo += "{rank=same;\"" + tmpy.Arriba.PosY.ToString() + "\";";

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

                grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";

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

                grafo += "\"" + tmpy.Arriba.PosY.ToString() + "\"";


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

        grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Arriba.PosX) + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";
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

        grafo += "\"Matriz\" -> \"" + tmpy.Arriba.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                grafo += "\"" + tmpy.Arriba.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"" + tmpy.Arriba.PosY + "\"";
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
                grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\";";
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
                grafo += "{rank=same;\"" + tmpy2.PosY.ToString() + "\";";

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

                grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\"";

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

                grafo += "\"" + tmpy2.PosY.ToString() + "\"";


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

        grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx2.PosX) + "\";\n";

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
                grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\"";
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
                        grafo += " -> " + "\"" + NumeroALetras(tmpx2.PosX) + "\"";
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

        grafo += "\"Matriz\" -> \"" + tmpy2.PosY + "\";\n";

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
                grafo += "\"" + tmpy2.PosY + "\"";
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
                        grafo += " -> " + "\"" + tmpy2.PosY + "\"";
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
                grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\";";
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
                grafo += "{rank=same;\"" + tmpy.Abajo.PosY.ToString() + "\";";

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

                grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

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

                grafo += "\"" + tmpy.Abajo.PosY.ToString() + "\"";


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

        grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Abajo.PosX) + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Abajo != null)
            {
                grafo += "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Abajo != null)
                    {
                        grafo += " -> " + "\"" + NumeroALetras(tmpx.Abajo.PosX) + "\"";
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

        grafo += "\"Matriz\" -> \"" + tmpy.Abajo.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Abajo != null)
            {
                grafo += "\"" + tmpy.Abajo.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Abajo != null)
                    {
                        grafo += " -> " + "\"" + tmpy.Abajo.PosY + "\"";
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
            grafo += "\"" + NumeroALetras(tmpx.PosX) + "\";";
            tmpx = tmpx.Derecha;
        }

        grafo += "};\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            tmpunidad = tmpy.lista.Primero;
            grafo += "{rank=same;\"" + tmpy.PosY.ToString() + "\";";
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

            grafo += "\"" + NumeroALetras(tmpx.PosX) + "\"";

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



            grafo += "\"" + tmpy.PosY.ToString() + "\"";

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



        grafo += "\"Matriz\" -> \"" + NumeroALetras(CX.primero.PosX) + "\";\n";

        tmpx = CX.primero;

        while (tmpx != null)
        {
            if (tmpx.Derecha != null)
            {
                grafo += "\"" + NumeroALetras(tmpx.PosX) + "\" -> \"" + NumeroALetras(tmpx.Derecha.PosX) + "\";\n";
            }
            tmpx = tmpx.Derecha;
        }


        grafo += "\"Matriz\" -> \"" + CY.primero.PosY + "\"[rankdir=UD];\n";

        tmpy = CY.primero;

        while (tmpy != null)
        {
            if (tmpy.Derecha != null)
            {
                grafo += "\"" + tmpy.PosY + "\" -> \"" + tmpy.Derecha.PosY + "\"[rankdir=UD];\n";
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
                grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\";";
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
                grafo += "{rank=same;\"" + tmpy.Arriba.PosY.ToString() + "\";";

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

                grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";

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

                grafo += "\"" + tmpy.Arriba.PosY.ToString() + "\"";


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

        grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx.Arriba.PosX) + "\";\n";



        while (tmpx != null)
        {
            if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
            {
                grafo += "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";

                tmpx = tmpx.Derecha;

                while (tmpx != null)
                {
                    if (tmpx.Arriba != null && tmpx.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"" + NumeroALetras(tmpx.Arriba.PosX) + "\"";
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

        grafo += "\"Matriz\" -> \"" + tmpy.Arriba.PosY + "\"[rankdir=UD];\n";



        while (tmpy != null)
        {
            if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
            {
                grafo += "\"" + tmpy.Arriba.PosY + "\"";

                tmpy = tmpy.Derecha;

                while (tmpy != null)
                {
                    if (tmpy.Arriba != null && tmpy.Arriba.PosZ == 2)
                    {
                        grafo += " -> " + "\"" + tmpy.Arriba.PosY + "\"";
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
                grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\";";
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
                grafo += "{rank=same;\"" + tmpy2.PosY.ToString() + "\";";

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

                grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\"";

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

                grafo += "\"" + tmpy2.PosY.ToString() + "\"";


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

        grafo += "\"Matriz\" -> \"" + NumeroALetras(tmpx2.PosX) + "\";\n";

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
                grafo += "\"" + NumeroALetras(tmpx2.PosX) + "\"";
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
                        grafo += " -> " + "\"" + NumeroALetras(tmpx2.PosX) + "\"";
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

        grafo += "\"Matriz\" -> \"" + tmpy2.PosY + "\";\n";

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
                grafo += "\"" + tmpy2.PosY + "\"";
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
                        grafo += " -> " + "\"" + tmpy2.PosY + "\"";
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

    //*********************************************METODOS AUXILIARES**********************************************

    public static string NumeroALetras(int columna)
    {
        string columnaLetras = "";
        decimal columnaNumero = columna;

        while (columnaNumero > 0)
        {
            decimal LetraNumeroActual = (columnaNumero - 1) % 26;
            char LetraActual = (char)(LetraNumeroActual + 65);
            columnaLetras = LetraActual + columnaLetras;
            columnaNumero = (columnaNumero - (LetraNumeroActual + 1)) / 26;
        }
        return columnaLetras;
    }

    public static int LetrasANuemro(string columna)
    {
        int valor = 0;
        string columnaLetras = columna.ToUpper();
        for (int i = columnaLetras.Length - 1; i >= 0; i--)
        {
            char LetraColumna = columnaLetras[i];
            int ColumnaNumero = LetraColumna - 64;
            valor = valor + ColumnaNumero * (int)Math.Pow(26, columnaLetras.Length - (i + 1));
        }
        return valor;
    }
}