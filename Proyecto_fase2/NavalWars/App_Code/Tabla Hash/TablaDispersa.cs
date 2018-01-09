using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TablaDispersa
/// </summary>
public class TablaDispersa
{
    public int Tamaño;
    public NodoUsuario[] Tabla;
    int NumeroElementos;
	public TablaDispersa(int tamaño)
	{
        
        Tamaño = tamaño;
        Tabla = new NodoUsuario[Tamaño];
        NumeroElementos = 0;
	}

    public void Insertar(NodoUsuario nuevo)
    {
       if(nuevo != null)
       {
           //Verificacion de el tamaño de la tabla;
           if ((NumeroElementos * 100) / Tamaño > 50)
           {
               Tamaño = Tamaño * 2;
               while (true)
               {
                   int a = 0;
                   for (int i = 1; i < (Tamaño + 1); i++)
                   {
                       if (Tamaño % i == 0)
                           a++;
                   }
                   if (a == 2)
                       break;

                   Tamaño++;
               }

               TablaDispersa tmp = new TablaDispersa(Tamaño);

               for (int i = 0; i < Tabla.Length; i++)
               {
                   tmp.Insertar(Tabla[i]);
               }

               Tabla = tmp.Tabla;
               NumeroElementos = tmp.NumeroElementos;
           }

           int indice = Funcion(nuevo.NickName);

           //Se inserta el nuevo elemento en la tabla

           if (Tabla[indice] == null)
           {
               Tabla[indice] = nuevo;
               NumeroElementos++;
           }
           else
           {
               //*********Algoritmo de Coliciones**********//
               int i = 1;
               int nuevoindice;
               while (true)
               {
                   int nVuelta;
                   nuevoindice = indice + (i * i);

                   if (nuevoindice > Tamaño)
                   {
                       nVuelta = nuevoindice / Tamaño;
                       nuevoindice = nuevoindice - (nVuelta * Tamaño);
                   }

                   if (Tabla[nuevoindice] == null)
                   {
                       Tabla[nuevoindice] = nuevo;
                       NumeroElementos++;
                       break;
                   }
                   i++;
               }
           }

       }

    }

    public int Funcion(string nickname)
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

        if (valor >= Tamaño)
        {
            nVuelta = valor / Tamaño;
            valor = valor - (nVuelta * Tamaño);
        }

        return valor;
    }

    public string GraficarTabla()
    {
        string grafo = "digraph G { \n node[shape=box, style=filled, color=Gray95];\n edge[color=black]";
        bool primero = true;
        for (int i = 0; i < Tabla.Length; i++)
        {
            if (Tabla[i] != null)
            {
                if(primero)
                {
                    grafo += "\" Indice: [" + i.ToString() + "]\n" + Tabla[i].NickName + "\n" + Tabla[i].Contraseña + "\n" + Tabla[i].Correo + "\"\n";
                    primero = false;
                }
                else
                {
                    grafo += " -> ";
                    grafo += "\" Indice: [" + i.ToString() + "]\n" + Tabla[i].NickName + "\n" + Tabla[i].Contraseña + "\n" + Tabla[i].Correo + "\"\n";                 
                }
              
            }
        }

        grafo += "}";
        return grafo;
    }
}