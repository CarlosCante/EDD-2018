using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoUnidad
/// </summary>
public class NodoUnidad
{
    /*Identificador unico de la unidad*/
    public int ID;

    /*Tipo de unidad
     * 0 = Neosatelite
     * 1 = Bombardero
     * 2 = Caza
     * 3 = Helicoptero de combate
     * 4 = Fragata
     * 5 = Crucero
     * 6 = Submarino
     */
    public int tipo;

    /*Pertenecia de jugador
     * 1 = Jugador 1
     * 2 = Jugador 2
     */
    public int Jugador; 

    /*Coordenadas de la unidad dentro del tablero
     * z = 0 Submarino
     * z = 1 Barco
     * z = 2 Avion
     * z = 3 Satelite
     */
    public int CooX;
    public int CooY;
    public int CooZ;

    public int Movimiento;

    public int Daño;

    public int Vida;

    //Apuntadores
    public NodoUnidad Arriba;
    public NodoUnidad Abajo;
    public NodoUnidad Izquierda;
    public NodoUnidad Derecha;
    public NodoUnidad Superio;
    public NodoUnidad Inferior;
    // 0 = destruida
    // 1 = activa
    public int estado;

	public NodoUnidad(int id_, int est, int tipo_, int x, int y, int z, int jugador_)
	{
        ID = id_;
        tipo = tipo_;
        
        CooX = x;
        CooY = y;
        CooZ = z;

        Jugador = jugador_;

        estado = est;

        switch (tipo)
        {
            case 0:
                Movimiento = 6;
                Daño = 2;
                Vida = 10;
                break;
            case 1:
                Movimiento = 7;
                Daño = 5;
                Vida = 10;
                break;
            case 2:
                Movimiento = 9;
                Daño = 2;
                Vida = 20;
                break;
            case 3:
                Movimiento = 9;
                Daño = 3;
                Vida = 15;
                break;
            case 4:
                Movimiento = 5;
                Daño = 3;
                Vida = 10;
                break;
            case 5:
                Movimiento = 6;
                Daño = 3;
                Vida = 15;
                break;
            case 6:
                Movimiento = 5;
                Daño = 2;
                Vida = 10;
                break;
            default:
                break;
        }

        Arriba = null;
        Abajo = null;
        Derecha = null;
        Izquierda = null;
        Superio = null;
        Inferior = null;

	}
}