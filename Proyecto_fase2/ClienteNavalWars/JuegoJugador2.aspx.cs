using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JuegoJugador2 : System.Web.UI.Page
{
    static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        TextConsola.Text = servidor.ObtenerBitacora();
    }
    protected void BotonActualizar_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraficarNivel0ActualJ1(), "GN0J1", this.ImageNivel0);
        RealizarGrafica(servidor.GraficarNivel1Actual(), "GN1J1", this.ImageNivel1);
        RealizarGrafica(servidor.GraficarNivel2Actual(), "GN2J1", this.ImageNivel2);
        RealizarGrafica(servidor.GraficarNivel3Actual(), "GN3J1", this.ImageNivel3);
        LabelTurno.Text = servidor.ConsultarTurno().ToString();
        LabelTurno0.Text = servidor.ConsultarTurno().ToString();
        TextConsola.Text = servidor.ObtenerBitacora();
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
        catch (Exception)
        {

        }
        string imagenorden = obtenerimagen("C:/Grafos/" + nombre + ".jpg");
        destino.ImageUrl = imagenorden;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (servidor.ConsultarTurno() == 2)
        {
            if (TextBoxColumOrigen.Text != "" && TextBoxFilaOrigen.Text != "" && TextBoxNivelOrigen.Text != "" && TextBoxColumDestino.Text != "" && TextBoxFilaDestino.Text != "" && TextBoxNivelDestino.Text != "")
            {
                if (servidor.MoverPieza(TextBoxColumOrigen.Text, Convert.ToInt32(TextBoxFilaOrigen.Text), Convert.ToInt32(TextBoxNivelOrigen.Text), TextBoxColumDestino.Text, Convert.ToInt32(TextBoxFilaDestino.Text), Convert.ToInt32(TextBoxNivelDestino.Text), 2))
                {
                    LabelMensajeMovimiento.Text = "Movimiento exitoso";
                }
                else
                {
                    LabelMensajeMovimiento.Text = "No se pudo realizar el movimiento";
                }
            }
            else
            {
                LabelMensajeMovimiento.Text = "Llene todo los campos para realizar el movimiento";
            }

        }
        else
        {
            LabelMensajeMovimiento.Text = "No es su turno para mover";
        }
        TextConsola.Text = servidor.ObtenerBitacora();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBoxColumOrigen0.Text != "" && TextBoxFilaOrigen0.Text != "" && TextBoxNivelOrigen0.Text != "" && TextBoxColumDestino0.Text != "" && TextBoxFilaDestino0.Text != "" && TextBoxNivelDestino0.Text != "")
        {
            LabelMensajeAtaque.Text = servidor.Atacar(TextBoxColumOrigen0.Text, Convert.ToInt32(TextBoxFilaOrigen0.Text), Convert.ToInt32(TextBoxNivelOrigen0.Text), TextBoxColumDestino0.Text, Convert.ToInt32(TextBoxFilaDestino0.Text), Convert.ToInt32(TextBoxNivelDestino0.Text), 2, 1);
        }
        else
        {
            LabelMensajeAtaque.Text = "Llene todo los campos para realizar el movimiento";
        }
        TextConsola.Text = servidor.ObtenerBitacora();
    }
    protected void TerminarTurno_Click(object sender, EventArgs e)
    {
        servidor.CambiarTurno(2);
        LabelTurno.Text = servidor.ConsultarTurno().ToString();
        LabelTurno0.Text = servidor.ConsultarTurno().ToString();
        TextConsola.Text = servidor.ObtenerBitacora();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextConsola.Text = servidor.ObtenerBitacora();
    }
}