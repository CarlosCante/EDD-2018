<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
    &nbsp;Registro de usuarios
        <br />
        <br />
        NickName:&nbsp;
        <asp:TextBox ID="NuevoUsuario" runat="server"></asp:TextBox>
        <br />
&nbsp;Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NuevoCorreo" runat="server"></asp:TextBox>
        <br />
&nbsp;Contraseña:
        <asp:TextBox ID="NuevaContraseña" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registrarse" />
        <br />
        <br />
        Ingrese sus datos<br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Volver a Login" />
    
    </div>
    </form>
</body>
</html>
