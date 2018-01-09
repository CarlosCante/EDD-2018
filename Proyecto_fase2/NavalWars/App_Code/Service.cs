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
    static Matriz Juego;
    static ArbolBB Arbol = new ArbolBB();
    static ArbolBB ArbolEspejo = new ArbolBB();
    static ArbolB arbolb = new ArbolB(5);
    string UserAdmin = "Carlo5";
    string PassAdmin = "54321";
    static int IDunidades = 0;
    static TablaDispersa tabladis;

    static ArbolContactosAVL AVL = new ArbolContactosAVL();

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
        arbolb.Insertar(new NodoAtaque(1, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(2, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(3, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(4, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(5, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(6, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(7, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(8, 0, 0, "", "", "", null, "", ""));
        arbolb.Insertar(new NodoAtaque(9, 0, 0, "", "", "", null, "", ""));
        return;
    }
    [WebMethod]
    public int Prueba2(string nickname)
    {
        int valor = 0;
        string nick = nickname.ToUpper();

        for (int i = 0; i < nick.Length; i++)
        {
            int v;
            char letra = nick[i];
            if (char.IsDigit(letra))
            {
                v = letra - 48;
            }
            else
            {
                v = letra - 64;
            }

            valor = valor + v;
        }

        int nVuelta;

        if (valor >= 47)
        {
            nVuelta = valor / 47;
            valor = valor - (nVuelta * 47);
        }

        return valor;
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
    public void CargarContatos(string linea)
    {
        string[] Arreglo = linea.Split(',');
        NodoUsuario tmp = Arbol.ObtenerUsuario(Arreglo[1]);
        NodoUsuario tmp2 = Arbol.ObtenerUsuario(Arreglo[0]);
        if(tmp2 != null)
        {
            if (tmp != null)
            {
                Arbol.AñadirContacto(Arreglo[0], new NodoContacto(tmp));
            }
            else
            {
                Arbol.AñadirContacto(Arreglo[0], new NodoContacto(new NodoUsuario(Arreglo[1], Arreglo[2], Arreglo[3], false)));
            }
        }
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

    [WebMethod]
    public string AgregarContactoExistente(string Usuario, string Contacto)
    {
        NodoUsuario tmp = Arbol.ObtenerUsuario(Usuario);
        if(tmp != null)
        {
            NodoUsuario tmp2 = Arbol.ObtenerUsuario(Contacto);
            if(tmp2 != null)
            {
                NodoContacto tmpcon = new NodoContacto(tmp2);
                tmpcon.NickName = tmp2.NickName;
                tmpcon.Pass = tmp2.Contraseña;
                tmpcon.Correo = tmp2.Correo;
                tmp.Contactos.Insertar(tmpcon);
                return "Contacto agregado con exito!!!!!";
            }
            else
            {
                return "El usuario contacto no existe";
            }
        }
        else
        {
            return "El usuario al destino no existe";
        }
    }

    [WebMethod]
    public string AgregarContactoNoExistente(string Usuario, string nick, string pass, string correo)
    {
        NodoUsuario tmp = Arbol.ObtenerUsuario(Usuario);
        if(tmp != null)
        {
            tmp.Contactos.Insertar(new NodoContacto(new NodoUsuario(nick, pass, correo, false)));
            return "Contacto añadido con exito!!!!!";
        }
        else
        {
            return "El usuario al destino no existe";
        }
    }

    [WebMethod]
    public string GraficarAVL(string nick)
    {
        string graf = Arbol.GraficarAVL(nick);
        return graf;
    }

    [WebMethod]
    public string GraficarTablaHash()
    {
        tabladis = new TablaDispersa(43);
        inOrden(Arbol.Raiz);
        return tabladis.GraficarTabla();
    }

    [WebMethod]
    public string EliminarContacto(string nick, string contacto)
    {
        if(Arbol.EliminarContacto(nick,contacto))
        {
            return "Contacto eliminado con exito!!!!!";
        }
        return "Error al eliminar contacto";
    }

    //******************************Servicios de graficas para Tablero Actual************************************

    [WebMethod]
    public string GraficarNivel0Actual()
    {
        return Juego.GraficarNivel0J1();
    }

    [WebMethod]
    public string GraficarNivel0ActualJ2()
    {
        return Juego.GraficarNivel0J2Nuevo();
    }

    [WebMethod]
    public string GraficarNivel0ActualJ1()
    {
        return Juego.GraficarNivel0J1Nuevo();
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
        Juego = new Matriz(Arreglo[0], Arreglo[1], Convert.ToInt32(Arreglo[2]), Convert.ToInt32(Arreglo[3]), Convert.ToInt32(Arreglo[4]), Convert.ToInt32(Arreglo[5]), Convert.ToInt32(Arreglo[6]), Convert.ToInt32(Arreglo[7]), Convert.ToInt32(Arreglo[8]), 0, true);
    }

    [WebMethod]
    public bool CargarParametrosManual(string j1, string j2, string nsa, string nav, string nba, string nsub, string x, string y, string tipo, string tiempo)
    {
        try
        {
            if(Arbol.UsuarioExiste(j1) && Arbol.UsuarioExiste(j2))
            {
                Juego = new Matriz(j1, j2, Convert.ToInt32(nsub), Convert.ToInt32(nba), Convert.ToInt32(nav), Convert.ToInt32(nsa), Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(tipo), Convert.ToInt32(tiempo), true);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
        
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
            columna = Matriz.LetrasANuemro(Arreglo[1]);

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
    public bool InsertarUnidad(int tipo, string x, int y, int z, int jug)
    {
        try
        {
            IDunidades++;
            bool res = Juego.InsertarUnidad(new NodoUnidad(IDunidades,1, tipo, Matriz.LetrasANuemro(x), y, z, jug));
            return res;
        }
        catch (Exception)
        {
            return false;
        }
        
    }

    [WebMethod]
    public bool MoverPieza(string Xorigen, int Yorigen, int Zorigen, string Xdestino, int Ydestino, int Zdestino, int jugador)
    {
        if(jugador == Juego.TurnoJugador)
        {
            if(Juego.MoverPieza(Matriz.LetrasANuemro(Xorigen), Yorigen, Zorigen, Matriz.LetrasANuemro(Xdestino), Ydestino, Zdestino, jugador))
            {
                Juego.Bitacora += "Jugador " + Juego.TurnoJugador + " movio la pieza en la posicion X=" + Xorigen + " Y=" + Yorigen + " Z=" + Zorigen + " a la posicion: ";
                Juego.Bitacora += "X=" + Xdestino + " Y=" + Ydestino + " Z=" + Zdestino + ".\n\n";
                return true;
            }
        }
        return false;
    }

    [WebMethod]
    public string Atacar(string Xorigen, int Yorigen, int Zorigen, string Xdestino, int Ydestino, int Zdestino, int Jatacante, int Jdañado)
    {
        if(Jatacante == Juego.TurnoJugador)
        {
            Juego.Bitacora += "El Jugador " + Jatacante + "Realizo el siguiente ataque: \n";
            string mensaje = Juego.Atacar(Matriz.LetrasANuemro(Xorigen), Yorigen, Zorigen, Matriz.LetrasANuemro(Xdestino), Ydestino, Zdestino, Jatacante, Jdañado);
            Juego.Bitacora += mensaje + "\n\n";
            return mensaje;
        }
        return "No es su turno para atacar";
    }

    [WebMethod]
    public string ModificarUsuario(string Usuario, string nuevoUsuario, string NuevoPass, string  nuevoCorreo)
    {
        return Arbol.Modificar(Usuario, nuevoUsuario, NuevoPass, nuevoCorreo);
    }

    [WebMethod]
    public void CambiarTurno(int j)
    {
        Juego.CambiarTurno(j);
    }

    [WebMethod]
    public string ObtenerBitacora()
    {
        return Juego.Bitacora;
    }
    [WebMethod]
    public int ConsultarTurno()
    {
        return Juego.TurnoJugador;
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
    public bool setUnidadesSATJ1()
    {
        if(Juego.NoUnidadesSateliteJ1 > 0)
        {
            Juego.NoUnidadesSateliteJ1--;
            return true;
        }
        else
        {
            return false;
        }
        
    }
    [WebMethod]
    public bool setUnidadesAVIJ1()
    {
        if(Juego.NoUnidadesBarcoJ1 > 0)
        {
            Juego.NoUnidadesAvionJ1--;
            return true;
        }
        return false;
        
    }
    [WebMethod]
    public bool setUnidadesBAJ1()
    {
        if(Juego.NoUnidadesBarcoJ1 > 0)
        {
            Juego.NoUnidadesBarcoJ1--;
            return true;
        }
        return false;
    }
    [WebMethod]
    public bool setUnidadesSUBJ1()
    {
        if(Juego.NoUnidadesSubmarinoJ1 > 0)
        { 
            Juego.NoUnidadesSubmarinoJ1--;
            return true;
        }
        return false;
    }




    [WebMethod]
    public bool setUnidadesSATJ2()
    {
        if (Juego.NoUnidadesSateliteJ2 > 0)
        {
            Juego.NoUnidadesSateliteJ2--;
            return true;
        }
        else
        {
            return false;
        }
        
    }
    [WebMethod]
    public bool setUnidadesAVIJ2()
    {
        if (Juego.NoUnidadesBarcoJ2 > 0)
        {
            Juego.NoUnidadesAvionJ2--;
            return true;
        }
        return false;
        
    }
    [WebMethod]
    public bool setUnidadesBAJ2()
    {
        if (Juego.NoUnidadesBarcoJ2 > 0)
        {
            Juego.NoUnidadesBarcoJ2--;
            return true;
        }
        return false;
    }
    [WebMethod]
    public bool setUnidadesSUBJ2()
    {
        if (Juego.NoUnidadesSubmarinoJ2 > 0)
        {
            Juego.NoUnidadesSubmarinoJ2--;
            return true;
        }
        return false;
    }

    string inOrden(NodoUsuario padre)
    {
        if(padre != null){
            
            inOrden(padre.izq);
            tabladis.Insertar(padre);
            inOrden(padre.der);
        }
        return "";
    }
}