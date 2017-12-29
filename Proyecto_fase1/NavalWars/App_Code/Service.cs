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
    public static Matriz Juego = new Matriz("","",0,0,0,0,0,0,0);
    public static ArbolBB Arbol = new ArbolBB();
    public static ArbolBB ArbolEspejo = new ArbolBB();
    string UserAdmin = "Carlo5";
    string PassAdmin = "54321";
    static int IDunidades = 0;

    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Boolean LoginAdministrador(string usuario, string password)
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
    public Boolean LoginUsuario(string usuario, string password)
    {
        if(Arbol.VerificarUsuario(usuario,password))
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
    public Boolean VerificarJugador1(string usuario)
    {
        if (Juego.Juagdor1.CompareTo(usuario) == 0)
            return true;
        return false;
    }
    [WebMethod]
    public Boolean VerificarJugador2(string usuario)
    {
        if (Juego.Jugador2.CompareTo(usuario) == 0)
            return true;
        return false;
    }

    //*******************************Servicios del Arbol BB de usuarios*****************************************

    [WebMethod]
    public void NuevoUsuario(string nick, string pass, string correo, bool estado)
    {
        Arbol.Insertar(Arbol.Raiz, new NodoUsuario(nick, pass, correo, estado));
    }
    [WebMethod]
    public void EliminarUaurio(string nick)
    {
        Arbol.Eliminar(nick);
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
    public string GraficarListasJuegos()
    {
        return Arbol.GraficarListaJuegos();
    }
    
    [WebMethod]
    public int ContarHojas()
    {
        return Arbol.ContarHojas(Arbol.Raiz);
    }
    [WebMethod]
    public int ContarRamas()
    {
        return Arbol.ContarNodos(Arbol.Raiz) - Arbol.ContarHojas(Arbol.Raiz);
    }
    [WebMethod]
    public string GraficarABBEspejo()
    {
        ArbolEspejo.Raiz = ArbolEspejo.Espejo(Arbol.Raiz);
        return ArbolEspejo.Graficar();
    }
    [WebMethod]
    public int AlturaArbol()
    {
        return Arbol.Altura(Arbol.Raiz) + 1;
    }
    

    [WebMethod]
    public int ContarNiveles()
    {
        return Arbol.Altura(Arbol.Raiz);
    }

    //******************************Servicios de graficas para Tablero Actual************************************

    [WebMethod]
    public string GraficarNivel0Actual()
    {
        return Juego.GraficarNivel0J1();
    }

    [WebMethod]
    public string GraficarNivel1Actual()
    {
        return Juego.GraficarNivel1J1();
    }

    [WebMethod]
    public string GraficarNivel2Actual()
    {
        return Juego.GraficarNivel2J1();
    }

    [WebMethod]
    public string GraficarNivel3Actual()
    {
        return Juego.GraficarNivel3J1();
    }

    //******************************Servicios de graficas para unidades Sobrevivientes************************************

    [WebMethod]
    public string GraN0UniSob()
    {
        return Juego.GraficarN0UnidadesSob();
    }
    [WebMethod]
    public string GraN1UniSob()
    {
        return Juego.GraficarN1UnidadesSob();
    }
    [WebMethod]
    public string GraN2UniSob()
    {
        return Juego.GraficarN2UnidadesSob();
    }
    [WebMethod]
    public string GraN3UniSob()
    {
        return Juego.GraficarN3UnidadesSob();
    }

    //******************************Servicios de graficas para unidades Destruidas****************************************
    [WebMethod]
    public string GraN0UniDes()
    {
        return Juego.GraficarN0UnidadesDes();
    }
    [WebMethod]
    public string GraN1UniDes()
    {
        return Juego.GraficarN1UnidadesDes();
    }
    [WebMethod]
    public string GraN2UniDes()
    {
        return Juego.GraficarN2UnidadesDes();
    }
    [WebMethod]
    public string GraN3UniDes()
    {
        return Juego.GraficarN3UnidadesDes();
    }
    [WebMethod]
    public void CaragaJuego(string linea)
    {
        string[] Arreglo = linea.Split(',');
        Juego = new Matriz(Arreglo[0], Arreglo[1], Convert.ToInt32(Arreglo[2]), Convert.ToInt32(Arreglo[3]), Convert.ToInt32(Arreglo[4]), Convert.ToInt32(Arreglo[5]), Convert.ToInt32(Arreglo[6]), Convert.ToInt32(Arreglo[7]), Convert.ToInt32(Arreglo[8]));
    }

    [WebMethod]
    public void CargarParametrosManual(string j1, string j2, string nsa, string nav, string nba, string nsub, string x, string y, string tipo)
    {
        Juego = new Matriz(j1, j2, Convert.ToInt32(nsub), Convert.ToInt32(nba), Convert.ToInt32(nav), Convert.ToInt32(nsa), Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(tipo));
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

    [WebMethod]
    public void InsertarUnidad(int tipo, int x, int y, int z, int jug)
    {
        Juego.InsertarUnidad(new NodoUnidad(IDunidades, 1, tipo, x, y, z, jug));
    }

    [WebMethod]
    public string getNombreJ1()
    {
        return Juego.Juagdor1;
    }

    [WebMethod]
    public string getNombreJ2()
    {
        return Juego.Jugador2;
    }


    [WebMethod]
    public string getUnidadesSATJ1()
    {
        return Juego.NoUnidadesSateliteJ1.ToString();
    }
    [WebMethod]
    public string getUnidadesAVIJ1()
    {
        return Juego.NoUnidadesAvionJ1.ToString();
    }
    [WebMethod]
    public string getUnidadesBAJ1()
    {
        return Juego.NoUnidadesBarcoJ1.ToString();
    }
    [WebMethod]
    public string getUnidadesSUBJ1()
    {
        return Juego.NoUnidadesSubmarinoJ1.ToString();
    }




    [WebMethod]
    public string getUnidadesSATJ2()
    {
        return Juego.NoUnidadesSateliteJ2.ToString();
    }
    [WebMethod]
    public string getUnidadesAVIJ2()
    {
        return Juego.NoUnidadesAvionJ2.ToString();
    }
    [WebMethod]
    public string getUnidadesBAJ2()
    {
        return Juego.NoUnidadesBarcoJ2.ToString();
    }
    [WebMethod]
    public string getUnidadesSUBJ2()
    {
        return Juego.NoUnidadesSubmarinoJ2.ToString();
    }



    [WebMethod]
    public void setUnidadesSATJ1()
    {
        Juego.NoUnidadesSateliteJ1--;
    }
    [WebMethod]
    public void setUnidadesAVIJ1()
    {
        Juego.NoUnidadesAvionJ1--;
    }
    [WebMethod]
    public void setUnidadesBAJ1()
    {
        Juego.NoUnidadesBarcoJ1--;
    }
    [WebMethod]
    public void setUnidadesSUBJ1()
    {
        Juego.NoUnidadesSubmarinoJ1--;
    }




    [WebMethod]
    public void setUnidadesSATJ2()
    {
        Juego.NoUnidadesSateliteJ2--;
    }
    [WebMethod]
    public void setUnidadesAVIJ2()
    {
        Juego.NoUnidadesAvionJ2--;
    }
    [WebMethod]
    public void setUnidadesBAJ2()
    {
        Juego.NoUnidadesBarcoJ2--;
    }
    [WebMethod]
    public void setUnidadesSUBJ2()
    {
        Juego.NoUnidadesSubmarinoJ2--;
    }
}