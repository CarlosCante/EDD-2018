using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoContacto
/// </summary>
public class NodoContacto
{
    public int fe;
    public NodoUsuario contacto;
    public NodoContacto der;
    public NodoContacto izq;
    public NodoContacto padre;

    public string NickName;
    public string Pass;
    public string Correo;
	public NodoContacto(NodoUsuario nuevo)
	{
        contacto = nuevo;
        der = null;
        izq = null;
        padre = null;
        fe = 0;
        NickName = "";
        Pass = "";
        Correo = "";
	}

    public NodoContacto(string nick, string pass, string correo)
    {
        contacto = null;
        der = null;
        izq = null;
        padre = null;
        fe = 0;
        NickName = nick;
        Pass = pass;
        Correo = correo;
    }

}