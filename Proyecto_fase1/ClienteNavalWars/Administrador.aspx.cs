using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador : System.Web.UI.Page
{
    public static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if(FileUploadUsuarios.FileName == "")
        {
            Label2.Text = "Nota: No se ha seleccionado ningun archivo";
        }
        else
        {
            string extension = Path.GetExtension(FileUploadUsuarios.PostedFile.FileName);
            if(extension.ToLower() == ".csv")
            {
                FileUpload fu = FileUploadUsuarios; 
                if (fu.HasFile) 
                { 
                    StreamReader reader = new StreamReader(fu.FileContent);
                    reader.ReadLine();

                    do { 
                        string textLine = reader.ReadLine();
                        servidor.CargarUsuario(textLine);
                    } while (reader.Peek() != -1); 

                    reader.Close();

                    Label2.Text = "Nota: Carga de Usuarios Exitosa";
                }
            }
            else
            {
                Label2.Text = "Nota: El archivo selecionado no es del tipo permitido";
            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        
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
    protected void Button3_Click(object sender, EventArgs e)//cargar juegos
    {
        if (FileUploadJuegos.FileName == "")
        {
            Label5.Text = "Nota: No se ha seleccionado ningun archivo";
        }
        else
        {
            string extension = Path.GetExtension(FileUploadJuegos.PostedFile.FileName);
            if (extension.ToLower() == ".csv")
            {
                FileUpload fu = FileUploadJuegos;
                if (fu.HasFile)
                {
                    StreamReader reader = new StreamReader(fu.FileContent);
                    reader.ReadLine();

                    do
                    {
                        string textLine = reader.ReadLine();
                        servidor.CargarJuegosAJugadores(textLine);
                    } while (reader.Peek() != -1); 

                    reader.Close();

                    Label5.Text = "Nota: Carga de Juego Actual Exitosa";
                }
            }
            else
            {
                Label5.Text = "Nota: El archivo selecionado no es del tipo permitido";
            }
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        
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
        catch (Exception ex)
        {
        }
        string imagenorden = obtenerimagen("C:/Grafos/" + nombre + ".jpg");
        destino.ImageUrl = imagenorden;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (FileUploadJuegoActual.FileName == "")
        {
            Label5.Text = "Nota: No se ha seleccionado ningun archivo";
        }
        else
        {
            string extension = Path.GetExtension(FileUploadJuegoActual.PostedFile.FileName);
            if (extension.ToLower() == ".csv")
            {
                FileUpload fu = FileUploadJuegoActual;
                if (fu.HasFile)
                {
                    StreamReader reader = new StreamReader(fu.FileContent);
                    reader.ReadLine();

                    string textLine = reader.ReadLine();
                    servidor.CaragaJuego(textLine);

                    reader.Close();

                    Label5.Text = "Nota: Carga de Juego Actual Exitosa";
                }
            }
            else
            {
                Label5.Text = "Nota: El archivo selecionado no es del tipo permitido";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUploadTablero.FileName == "")
        {
            Label3.Text = "Nota: No se ha seleccionado ningun archivo";
        }
        else
        {
            string extension = Path.GetExtension(FileUploadTablero.PostedFile.FileName);
            if (extension.ToLower() == ".csv")
            {
                FileUpload fu = FileUploadTablero;
                if (fu.HasFile)
                {
                    StreamReader reader = new StreamReader(fu.FileContent);
                    reader.ReadLine();

                    do
                    {
                        string textLine = reader.ReadLine();
                        servidor.CargarTablero(textLine);
                    } while (reader.Peek() != -1); 

                    reader.Close();

                    Label3.Text = "Nota: Carga de Juego Actual Exitosa";
                }
            }
            else
            {
                Label3.Text = "Nota: El archivo selecionado no es del tipo permitido";
            }
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        
    }
    protected void Graficar_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraN0UniSob(), "GraN0UniSob", this.ImagenNivel0US);
        RealizarGrafica(servidor.GraN1UniSob(), "GraN1UniSob", this.ImagenNivel1US);
        RealizarGrafica(servidor.GraN2UniSob(), "GraN2UniSob", this.ImagenNivel2US);
        RealizarGrafica(servidor.GraN3UniSob(), "GraN3UniSob", this.ImagenNivel3US);
    }
    protected void GraficarUniDes_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraN0UniDes(), "GraN0UniDes", this.ImagenNivel0UD);
        RealizarGrafica(servidor.GraN1UniDes(), "GraN1UniDes", this.ImagenNivel1UD);
        RealizarGrafica(servidor.GraN2UniDes(), "GraN2UniDes", this.ImagenNivel2UD);
        RealizarGrafica(servidor.GraN3UniDes(), "GraN3UniDes", this.ImagenNivel3UD);
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        LabelAlturaArbol.Text = servidor.AlturaArbol().ToString();
        LabelNivelesArbol.Text = servidor.ContarNiveles().ToString();
        LabelNodosHoja.Text = servidor.ContarHojas().ToString();
        LabelNodosRama.Text = servidor.ContarRamas().ToString();
        RealizarGrafica(servidor.GraficarABB(), "ArbolBB", this.ImageArbol);
        RealizarGrafica(servidor.GraficarABBEspejo(), "ArbolBBEspejo", this.ImageArbolEspejo);
        RealizarGrafica(servidor.GraficarListasJuegos(), "ListaJuegos", this.ImageListaJuegos);
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        servidor.NuevoUsuario(TextNuevoNick.Text, TextNuevoPass.Text, TextNuevoCorreo.Text, false);
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        servidor.EliminarUaurio(TextElminarNick.Text);
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraficarNivel0Actual(), "Nivel0Actual", this.ImageNivel0Actual);
        RealizarGrafica(servidor.GraficarNivel1Actual(), "Nivel1Actual", this.ImageNivel1Actual);
        RealizarGrafica(servidor.GraficarNivel2Actual(), "Nivel2Actual", this.ImageNivel2Actual);
        RealizarGrafica(servidor.GraficarNivel3Actual(), "Nivel3Actual", this.ImageNivel3Actual);
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        if(TextBoxPJugador1.Text != "" && TextBoxPJugador2.Text != "" && TextBoxNoAv.Text != "" && TextBoxNoSa.Text != "" && TextBoxNoBa.Text != "" && TextBoxNoSub.Text != "" && TextBoxDX.Text != "" && TextBoxDY.Text != "")
        {
            servidor.CargarParametrosManual(TextBoxPJugador1.Text, TextBoxPJugador2.Text, TextBoxNoSa.Text, TextBoxNoAv.Text, TextBoxNoBa.Text, TextBoxNoSub.Text, TextBoxDX.Text, TextBoxDY.Text, TipodeJuego.SelectedValue);
        }
    }
}