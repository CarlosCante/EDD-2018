using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registro : System.Web.UI.Page
{
    public static ServidorNavalWars.WebServiceNavalWarsSoapClient servidor = new ServidorNavalWars.WebServiceNavalWarsSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            servidor.NuevoUsuario(NuevoUsuario.Text, NuevaContraseña.Text, NuevoCorreo.Text, false);
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}