<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jugador.aspx.cs" Inherits="Jugador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 203px;
        }
        .auto-style2 {
            background-color: #00FF00;
        }
        .auto-style3 {
            width: 203px;
            background-color: #00FF00;
        }
        .auto-style4 {
            background-color: #FFFFFF;
        }
        .auto-style5 {
            width: 203px;
            background-color: #FFFFFF;
        }
        .auto-style6 {
            width: 225px;
        }
        .auto-style7 {
            width: 225px;
            background-color: #00FF00;
        }
        .auto-style8 {
            width: 225px;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <caption style="background-color: #3333FF">
                <h3>Ingreso de Unidades<br />
                </h3>
            </caption>
            <tr>
                <td class="auto-style1">Cantidad de unidades restantes:</td>
                <td class="auto-style6">Satelites:
                    <asp:Label ID="LabelSatelite" runat="server" Text="0"></asp:Label>
                </td>
                <td>Jugador:
                    <asp:Label ID="LabelJugador" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">Aviones: <asp:Label ID="LabelAvion" runat="server" Text="0"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">Barcos:
                    <asp:Label ID="LabelBarco" runat="server" Text="0"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">Submarinos:
                    <asp:Label ID="LabelSubmarino" runat="server" Text="0"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Ingresar nueva unidad:</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Tipo:</td>
                <td class="auto-style8">
                    <asp:RadioButtonList ID="tipoUnidad" runat="server" OnSelectedIndexChanged="tipoUnidad_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Neosatelite</asp:ListItem>
                        <asp:ListItem>Bombardero</asp:ListItem>
                        <asp:ListItem>Caza</asp:ListItem>
                        <asp:ListItem>Helicoptero</asp:ListItem>
                        <asp:ListItem>Fragata</asp:ListItem>
                        <asp:ListItem>Crucero</asp:ListItem>
                        <asp:ListItem>Submarino</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Coordenada X:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextCooX" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Coordenada Y:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextCooY" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insertar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
