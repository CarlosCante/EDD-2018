<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jugador2.aspx.cs" Inherits="Jugador2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
            background-color: #00FF00;
        }
        .auto-style3 {
            width: 199px;
        }
        .auto-style4 {
            width: 246px;
        }
        .auto-style9 {
            width: 477px;
        }
        .auto-style10 {
            width: 199px;
            height: 26px;
        }
        .auto-style11 {
            width: 246px;
            height: 26px;
        }
        .auto-style12 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #3366FF">Ingreso de Unidades</h3>
            </caption>
            <tr>
                <td class="auto-style3">Cantidad Unidades Restantes:</td>
                <td class="auto-style4">Satelites:
                    <asp:Label ID="LabelSatelite" runat="server" Text="0"></asp:Label>
                </td>
                <td>Jugador:
                    <asp:Label ID="LabelJugador" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">Aviones:
                    <asp:Label ID="LabelAvion" runat="server" Text="0"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">Barcos:
                    <asp:Label ID="LabelBarco" runat="server" Text="0"></asp:Label>
                </td>
                <td style="background-color: #00FF00">Limites del Tablero:</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">Submarinos:
                    <asp:Label ID="LabelSubmarino" runat="server" Text="0"></asp:Label>
                </td>
                <td>Dimencion X: </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>Dimencion Y:</td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="3">Ingresar nueva unidad:</td>
            </tr>
            <tr>
                <td class="auto-style3">Tipo:</td>
                <td class="auto-style4">
                    <asp:RadioButtonList ID="tipoUnidad" runat="server">
                        <asp:ListItem Selected="True">Neosatelite</asp:ListItem>
                        <asp:ListItem>Bombardero</asp:ListItem>
                        <asp:ListItem>Caza</asp:ListItem>
                        <asp:ListItem>Helicoptero</asp:ListItem>
                        <asp:ListItem>Fragata</asp:ListItem>
                        <asp:ListItem>Crucero</asp:ListItem>
                        <asp:ListItem>Submarino</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Label ID="LabelMensajeIngreso" runat="server" Text="Seleccione un tipo de unidad"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Coordenada X:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextCooX" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Coordenada Y:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextCooY" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insertar" />
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Finalizar" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
        </div>
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #3366FF">Graficas del Tablero</h3>
            </caption>
            <tr>
                <td class="auto-style9">Nivel 0 (Submarinos):</td>
                <td>Nivel 1 (Barcos):</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Image ID="ImageNivel0" runat="server" />
                </td>
                <td>
                    <asp:Image ID="ImageNivel1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Nivel 2 (Aviones):</td>
                <td>Nivel 3 (Satelites):</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Image ID="ImageNivel2" runat="server" />
                </td>
                <td>
                    <asp:Image ID="ImageNivel3" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
