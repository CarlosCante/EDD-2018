using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador : System.Web.UI.Page
{
    static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();
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
            Label4.Text = "Nota: No se ha seleccionado ningun archivo";
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

                    Label4.Text = "Nota: Carga de Juegos Exitosa";
                }
            }
            else
            {
                Label4.Text = "Nota: El archivo selecionado no es del tipo permitido";
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
        catch (Exception)
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
            if(TipodeJuego.SelectedValue == "2")
            {
                if(TextBoxTIempo.Text != "")
                {
                    if (servidor.CargarParametrosManual(TextBoxPJugador1.Text, TextBoxPJugador2.Text, TextBoxNoSa.Text, TextBoxNoAv.Text, TextBoxNoBa.Text, TextBoxNoSub.Text, TextBoxDX.Text, TextBoxDY.Text, TipodeJuego.SelectedValue, TextBoxTIempo.Text))
                    {
                        LabelMensajeParametros.Text = "Se cargaron correctamente los nuevos parametros.";
                    }
                    else
                    {
                        LabelMensajeParametros.Text = "Ocurrio un problema durante la carga de los parametros. Intentelo de nuevo.";
                    }
            
                }
            }
            else
            {
                if (servidor.CargarParametrosManual(TextBoxPJugador1.Text, TextBoxPJugador2.Text, TextBoxNoSa.Text, TextBoxNoAv.Text, TextBoxNoBa.Text, TextBoxNoSub.Text, TextBoxDX.Text, TextBoxDY.Text, TipodeJuego.SelectedValue, "0"))
                {
                    LabelMensajeParametros.Text = "Se cargaron correctamente los nuevos parametros.";
                }
                else
                {
                    LabelMensajeParametros.Text = "Ocurrio un problema durante la carga de los parametros. Intentelo de nuevo.";
                }
            
            }
            
        }
        else
        {
            LabelMensajeParametros.Text = "Faltan casillas por llenar.";
        }
    }
    protected void TipodeJuego_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(TipodeJuego.SelectedValue == "2")
        {
            TextBoxTIempo.Enabled = true;
        }
        else
        {
            TextBoxTIempo.Enabled = false;
        }
    }
    protected void AñadirContacto0_Click(object sender, EventArgs e)
    {
        if(TextBoxUsuarioContacto.Text != "" && TextBoxContactoUsuario.Text != "")
        {
            LabelMensajeAñadirContacto.Text = servidor.AgregarContactoExistente(TextBoxUsuarioContacto.Text, TextBoxContactoUsuario.Text);
        }
        else
        {
            LabelMensajeAñadirContacto.Text = "Alguno de los campos nesesarios para la operacion esta vacio";
        }
    }
    protected void AñadirContacto_Click(object sender, EventArgs e)
    {
        if(TextBoxUsuarioContacto.Text != "" && TextBoxnickcontacto.Text != "" && TextBoxcontraseñacontacto.Text != "" && TextBoxcorreocontacto.Text != "")
        {
            LabelMensajeAñadirContacto.Text = servidor.AgregarContactoNoExistente(TextBoxUsuarioContacto.Text, TextBoxnickcontacto.Text, TextBoxcontraseñacontacto.Text, TextBoxcorreocontacto.Text);

        }
        else
        {
            LabelMensajeAñadirContacto.Text = "Alguno de los campos nesesarios para la operacion esta vacio";
        }
    }
    protected void GenerarArbolEspejo_Click(object sender, EventArgs e)
    {
        try
        {
            RealizarGrafica(servidor.GraficarABBEspejo(), "ArbolBBEspejo", this.ImageArbolEspejo);
        }
        catch (Exception)
        {

            LabelMensajeEspejo.Text = "Ocurrio un error al generar el arbol espejo";
        }
        
    }
    protected void GenerarListaJuegos_Click(object sender, EventArgs e)
    {
        try
        {
             RealizarGrafica(servidor.GraficarListasJuegos(), "ListaJuegos", this.ImageListaJuegos);
        }
        catch (Exception)
        {

            LabelMensajeListaJuegos.Text = "Ocurrio un problema al generar las listas de juegos";
        }
    }
    protected void GraficarAVL_Click(object sender, EventArgs e)
    {
        try
        {
            RealizarGrafica(servidor.GraficarAVL(TextBoxNickContactoGrafAVL.Text), "AVL", this.ImageAVL);
        }
        catch (Exception)
        {

            LabelMensajeAVL.Text = "Ocurrior al generar el arbol AVL o el usuario no existe";
        }
    }
    protected void CargarContactos_Click(object sender, EventArgs e)
    {
        if (FileUploadContactos.FileName == "")
        {
            Label6.Text = "Nota: No se ha seleccionado ningun archivo";
        }
        else
        {
            string extension = Path.GetExtension(FileUploadContactos.PostedFile.FileName);
            if (extension.ToLower() == ".csv")
            {
                FileUpload fu = FileUploadContactos;
                if (fu.HasFile)
                {
                    StreamReader reader = new StreamReader(fu.FileContent);
                    reader.ReadLine();

                    do
                    {
                        string textLine = reader.ReadLine();
                        servidor.CargarContatos(textLine);
                    } while (reader.Peek() != -1);

                    reader.Close();

                    Label6.Text = "Nota: Carga de Contactos Exitosa";
                }
            }
            else
            {
                Label6.Text = "Nota: El archivo selecionado no es del tipo permitido";
            }
        }
    }
    protected void CargarHistorial_Click(object sender, EventArgs e)
    {

    }
    protected void TextBoxcontraseñacontacto_TextChanged(object sender, EventArgs e)
    {

    }
    protected void EliminarContacto_Click(object sender, EventArgs e)
    {
        LabelMensajeEliminarContacto.Text = servidor.EliminarContacto(TextBoxUsuarioElContacto.Text, TextBoxContactoEliminar.Text);
    }
    protected void DispersarUsuarios_Click(object sender, EventArgs e)
    {
        RealizarGrafica(servidor.GraficarTablaHash(), "TablaHash", this.ImageTablaHash);
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        if(TextBoxNickModactual.Text != "" && TextBoxNickMod.Text != "" && TextBoxContraMod.Text != "" && TextBoxCorreoMod.Text != "")
        {
            LabelMensajeModUsuario.Text = servidor.ModificarUsuario(TextBoxNickModactual.Text, TextBoxNickMod.Text, TextBoxContraMod.Text, TextBoxCorreoMod.Text);
        }
        else
        {
            LabelMensajeModUsuario.Text = "Llene todos los campos para modificar el usuario";
        }
    }
}