using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();
   

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (servidor.LoginAdministrador(TextBoxUsuario.Text, TextBoxPass.Text))
        {
            Response.Redirect("~/Administrador.aspx");
        }
        else if(servidor.LoginUsuario(TextBoxUsuario.Text, TextBoxPass.Text))
        {
            if (servidor.VerificarJugador1(TextBoxUsuario.Text))
            {
                Response.Redirect("~/Jugador.aspx");
            }
            else if (servidor.VerificarJugador2(TextBoxUsuario.Text))
            {
                Response.Redirect("~/Jugador2.aspx");
            }
            else
            {
                LabelMensajeLogin.Text = "Usted no esta registrado para el juego actual.";
            }
            
        }
        else
        {
            LabelMensajeLogin.Text = "El usuario o contraseña no existen.";
        }

    }
    protected void Rehistro_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registro.aspx");
    }
}
