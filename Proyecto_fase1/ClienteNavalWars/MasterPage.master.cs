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
        
        if (servidor.Login(TextBoxUsuario.Text, TextBoxPass.Text))
        {
            Response.Redirect("~/Administrador.aspx");
        }
    }
    protected void Rehistro_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registro.aspx");
    }
}
