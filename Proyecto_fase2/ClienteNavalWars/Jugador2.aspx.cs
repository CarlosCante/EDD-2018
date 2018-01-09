using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jugador2 : System.Web.UI.Page
{
    static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelJugador.Text = servidor.getNombreJ2();
        LabelSatelite.Text = servidor.getUnidadesSATJ2();
        LabelAvion.Text = servidor.getUnidadesAVIJ2();
        LabelBarco.Text = servidor.getUnidadesBAJ2();
        LabelSubmarino.Text = servidor.getUnidadesSUBJ2();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int Tipo = 0;
        int nivel = 0;

        if (TextCooX.Text != "" && TextCooY.Text != "")
        {
            switch (tipoUnidad.SelectedValue)
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

            switch (Tipo)
            {
                case 0:
                    if (servidor.getUnidadesSATJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }
                    break;
                case 1:
                    if (servidor.getUnidadesAVIJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }
                    break;
                case 2:
                    if (servidor.getUnidadesAVIJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }
                    break;
                case 3:
                    if (servidor.getUnidadesAVIJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }
                    break;
                case 4:
                    if (servidor.getUnidadesBAJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }
                    break;
                case 5:
                    if (servidor.getUnidadesBAJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }

                    break;
                case 6:
                    if (servidor.getUnidadesSUBJ2().CompareTo("0") == 0)
                    {
                        LabelMensajeIngreso.Text = "Ya no puede ingresar mas unidades de este tipo";
                        return;
                    }
                    break;

                default:
                    break;
            }

            if (servidor.InsertarUnidad(Tipo, TextCooX.Text, Convert.ToInt32(TextCooY.Text), nivel, 2))
            {
                LabelMensajeIngreso.Text = "Unidad ingresada con exito.";
                switch (Tipo)
                {
                    case 0:
                        servidor.setUnidadesSATJ2();
                        break;
                    case 1:
                        servidor.setUnidadesAVIJ2();
                        break;
                    case 2:
                        servidor.setUnidadesAVIJ2();
                        break;
                    case 3:
                        servidor.setUnidadesAVIJ2();
                        break;
                    case 4:
                        servidor.setUnidadesBAJ2();
                        break;
                    case 5:
                        servidor.setUnidadesBAJ2();
                        break;
                    case 6:
                        servidor.setUnidadesSUBJ2();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                LabelMensajeIngreso.Text = "Ocurrio un problema al ingresar la unidad.";
            }


            LabelSatelite.Text = servidor.getUnidadesSATJ2();
            LabelAvion.Text = servidor.getUnidadesAVIJ2();
            LabelBarco.Text = servidor.getUnidadesBAJ2();
            LabelSubmarino.Text = servidor.getUnidadesSUBJ2();

            RealizarGrafica(servidor.GraficarNivel0ActualJ2(), "GN0J2", this.ImageNivel0);
            RealizarGrafica(servidor.GraficarNivel1Actual(), "GN1J2", this.ImageNivel1);
            RealizarGrafica(servidor.GraficarNivel2Actual(), "GN2J2", this.ImageNivel2);
            RealizarGrafica(servidor.GraficarNivel3Actual(), "GN3J2", this.ImageNivel3);
        }
        else
        {
            LabelMensajeIngreso.Text = "No ingreso coordenadas para la unidad";
        }


    }

    public string obtenerimagen(string rutaOrden)
    {
        try
        {
            Byte[] bytesImagen = System.IO.File.ReadAllBytes(rutaOrden);
            string imagen = Convert.ToBase64String(bytesImagen);
            string tipoContenido = "";

            switch (Path.GetExtension(rutaOrden))
            {
                case ".jpg":
                    tipoContenido = "image/jpg";
                    break;
                default:
                    break;
            }
            return System.String.Format("data:{0};base64,{1}", tipoContenido, imagen);
        }
        catch (Exception)
        {
            throw;
        }


    }

    public void RealizarGrafica(string grafo, string nombre, Image destino)
    {
        string graf = grafo;

        StreamWriter f = new StreamWriter("C://Grafos//" + nombre + ".dot");
        f.Write(graf);
        f.Close();

        try
        {
            var comand = string.Format("dot.exe -Tjpg C://Grafos//" + nombre + ".dot -o C://Grafos//" + nombre + ".jpg");
            var proctstarinfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comand);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = proctstarinfo;
            proc.Start();
            proc.WaitForExit();
        }
        catch (Exception )
        {

        }
        string imagenorden = obtenerimagen("C:/Grafos/" + nombre + ".jpg");
        destino.ImageUrl = imagenorden;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (LabelSatelite.Text == "0" && LabelAvion.Text == "0" && LabelBarco.Text == "0" && LabelSubmarino.Text == "0")
        {
            Response.Redirect("~/JuegoJugador2.aspx");
        }
        else
        {
            LabelMensajeIngreso.Text = "No ha terminado de posicionar sus unidades.";
        }
    }
}