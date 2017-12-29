using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jugador : System.Web.UI.Page
{
    public static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelJugador.Text = servidor.getNombreJ1();
        LabelSatelite.Text = servidor.getUnidadesSATJ1();
        LabelAvion.Text = servidor.getUnidadesAVIJ1();
        LabelBarco.Text = servidor.getUnidadesBAJ1();
        LabelSubmarino.Text = servidor.getUnidadesSUBJ1();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int Tipo = 0;
        int nivel = 0;
        if(TextCooX.Text != "" && TextCooY.Text != "")
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

            servidor.InsertarUnidad(Tipo, Convert.ToInt32(TextCooX.Text), Convert.ToInt32(TextCooY.Text), nivel, 1);

            switch (Tipo)
            {
                case 0:
                    servidor.setUnidadesSATJ1();
                    break;
                case 1:
                    servidor.setUnidadesAVIJ1();
                    break;
                case 2:
                    servidor.setUnidadesAVIJ1();
                    break;
                case 3:
                    servidor.setUnidadesAVIJ1();
                    break;
                case 4:
                    servidor.setUnidadesBAJ1();
                    break;
                case 5:
                    servidor.setUnidadesBAJ1();
                    break;
                case 6:
                    servidor.setUnidadesSUBJ1();
                    break;

                default:
                    break;
            }
            LabelSatelite.Text = servidor.getUnidadesSATJ1();
            LabelAvion.Text = servidor.getUnidadesAVIJ1();
            LabelBarco.Text = servidor.getUnidadesBAJ1();
            LabelSubmarino.Text = servidor.getUnidadesSUBJ1();
        }
    }
    protected void tipoUnidad_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}