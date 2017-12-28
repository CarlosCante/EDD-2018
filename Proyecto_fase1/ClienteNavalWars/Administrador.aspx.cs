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
        string graf = "digraph G{ \"hola\" -> \"mundo\" }";

        StreamWriter f = new StreamWriter("C://prueba.dot");

        f.Write(graf);

        f.Close();

        try
        {
            var comand = string.Format("dot.exe -Tjpg C://prueba.dot -o C://prueba.jpg");

            var proctstarinfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comand);

            var proc = new System.Diagnostics.Process();

            proc.StartInfo = proctstarinfo;

            proc.Start();

            proc.WaitForExit();

        }
        catch (Exception ex)
        {
        }

        string imagenorden = obtenerimagen("C:/prueba.jpg");

        Image2.ImageUrl = imagenorden;
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
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraficarABB(), "ArbolBB", this.ImagenABB);
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
        RealizarGrafica(servidor.GraficarNivel1Actual(), "Nivel1Actual", this.ImageNivel1Inicial);
    }
    protected void Graficar_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraN1UniSob(), "GraN1UniSob", this.ImagenNivel1US);
    }
    protected void GraficaUniDes_Click(object sender, EventArgs e)
    {

    }
}