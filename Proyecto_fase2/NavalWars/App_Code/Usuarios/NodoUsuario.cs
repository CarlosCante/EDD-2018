using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoUsuario
/// </summary>
public class NodoUsuario
{
    public string NickName;
    public string Contraseña;
    public string Correo;
    public bool Conectado;
    public NodoUsuario izq;
    public NodoUsuario der;

    public ArbolContactosAVL Contactos;


    public ListaJuegos ListaDeJuegos;

	public NodoUsuario(string nick, string pass, string correo, bool conectado)
	{
        NickName = nick;
        Contraseña = pass;
        Correo = correo;
        Conectado = conectado;
        izq = null;
        der = null;
        ListaDeJuegos = new ListaJuegos();
        Contactos = new ArbolContactosAVL();
	}
}