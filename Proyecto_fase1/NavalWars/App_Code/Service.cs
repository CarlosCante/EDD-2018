using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;

[WebService(Namespace = "http://NavalWars.org", Name = "WebServiceNavalWars", Description = "ServicioWeb")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public static Matriz Juego;
    public static ArbolBB Arbol = new ArbolBB();
    string UserAdmin = "Carlo5";
    string PassAdmin = "54321";
    static int IDunidades = 0;

    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Boolean Login(string usuario, string password)
    {
        if(usuario.Equals(UserAdmin) && password.Equals(PassAdmin))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    [WebMethod]
    public void Prueba()
    {
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Mario", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Carlos", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Alfredo", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Juan", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Lucas", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Cesar", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Miguel", "123", "cc", false));
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario("Esteban", "123", "cc", false));

        Arbol.Eliminar("Carlos");

        return;

    }
    [WebMethod]
    public void NuevoUsuario(string nick, string pass, string correo, bool estado)
    {
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario(nick, pass, correo, estado));
    }
    [WebMethod]
    public void CargarUsuario(string linea)
    {
        string[] Arreglo = linea.Split(',');
        bool conectado = false;

        if(Arreglo[3] == "1")
        {
            conectado = true;
        }

        Arbol.Insertar(Arbol.Raiz, new NodoUsuario(Arreglo[0],Arreglo[1],Arreglo[2],conectado));

    }

    [WebMethod]
    public void CargarJuegosAJugadores(string linea)
    {
        string[] Arreglo = linea.Split(',');
        bool gano = false;

        if (Arreglo[5] == "1")
        {
            gano = true;
        }

        Arbol.AñadirJuego(Arreglo[0], new NodoJuego(Arreglo[1], Convert.ToInt32(Arreglo[2]), Convert.ToInt32(Arreglo[3]), Convert.ToInt32(Arreglo[4]), gano));
    }

    [WebMethod]
    public string GraficarABB()
    {
        return Arbol.Graficar();
    }

    [WebMethod]
    public string GraficarNivel1Actual()
    {
        return Juego.GraficarNivel1J1();
    }

    [WebMethod]
    public string GraN1UniSob()
    {
        return Juego.GraficarN1UnidadesSob();
    }

    [WebMethod]
    public void CaragaJuego(string linea)
    {
        string[] Arreglo = linea.Split(',');
        Juego = new Matriz(Arreglo[0], Arreglo[1], Convert.ToInt32(Arreglo[2]), Convert.ToInt32(Arreglo[3]), Convert.ToInt32(Arreglo[4]), Convert.ToInt32(Arreglo[5]), Convert.ToInt32(Arreglo[6]), Convert.ToInt32(Arreglo[7]), Convert.ToInt32(Arreglo[8]));
    }

    [WebMethod]
    public void CargarTablero(string linea)
    {
        string[] Arreglo = linea.Split(',');
        int Tipo = 1;
        int fila;
        int columna = 0;
        int nivel = 0;
        int jugador = 0;

        if(Arreglo[0].CompareTo(Juego.Juagdor1) == 0)
        {
            jugador = 1;
        }
        else if (Arreglo[0].CompareTo(Juego.Jugador2) == 0)
        {
            jugador = 2;
        }

        if(jugador != 0)
        {
            byte[] array = Encoding.ASCII.GetBytes(Arreglo[1]);
            for(int i = 0 ; i < array.Length ; i++)
            {
                columna = columna + (array[i]-64);
            }

            fila = Convert.ToInt32(Arreglo[2]);

            switch (Arreglo[3])
            {
                case "Neosatelite":
                    Tipo = 0;
                    nivel = 3;
                    break;
                case "Bombardero":
                    Tipo = 1;
                    nivel = 2;
                    break;
                case "Caza":
                    Tipo = 2;
                    nivel = 2;
                    break;
                case "Helicoptero":
                    Tipo = 3;
                    nivel = 2;
                    break;
                case "Fragata":
                    Tipo = 4;
                    nivel = 1;
                    break;
                case "Crucero":
                    Tipo = 5;
                    nivel = 1;
                    break;
                case "Submarino":
                    Tipo = 6;
                    nivel = 0;
                    break;
                default:
                    break;
            }

            Juego.InsertarUnidad(new NodoUnidad(IDunidades, Convert.ToInt32(Arreglo[4]), Tipo, columna, fila, nivel, jugador));
            IDunidades++;
        }
        
    }
}