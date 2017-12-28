<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administrador.aspx.cs" Inherits="Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            width: 129px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 129px;
            height: 26px;
        }
        .auto-style7 {
            width: 458px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            font-size: xx-large;
        }
        .auto-style10 {
            background-color: #3333CC;
        }
        .auto-style11 {
            height: 23px;
            width: 160px;
        }
        .auto-style12 {
            width: 160px;
        }
        .auto-style14 {
        }
        .auto-style15 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <caption class="auto-style9">
                <h1 class="auto-style10">Administrador</h1>
            </caption>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Carga de Archivos:"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Usuarios:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUploadUsuarios" runat="server" Width="357px" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Cargar" />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Tablero:</td>
                <td class="auto-style7">
                    <asp:FileUpload ID="FileUploadTablero" runat="server" Width="357px" />
                    <asp:Button ID="Button2" runat="server" Text="Cargar" OnClick="Button2_Click" />
                </td>
                <td class="auto-style8"><asp:Label ID="Label3" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Juegos:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUploadJuegos" runat="server" Width="357px" />
                    <asp:Button ID="Button3" runat="server" Text="Cargar" OnClick="Button3_Click" />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Juego Actual:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUploadJuegoActual" runat="server" Width="357px" />
                    <asp:Button ID="Button4" runat="server" Text="Cargar" OnClick="Button4_Click" />
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Reportes:</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Prueba:</td>
                <td class="auto-style4" colspan="2">
                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Graficar" />
                    <asp:Image ID="Image2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Arbol de Usuarios (ABB):</td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Graficar" />
                    <asp:Image ID="ImagenABB" runat="server" BorderStyle="Double" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Nivel 0 juago inicial:</td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Graficar" />
                    <asp:Image ID="ImageNivel0Inicial" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Nivel 1 juego inicial:</td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Graficar" />
                    <asp:Image ID="ImageNivel1Inicial" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Nivel 2 juego inicial:</td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="Button10" runat="server" Text="Graficar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Nivel 3 juego inicial:</td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="Button11" runat="server" Text="Graficar" />
                </td>
            </tr>
            </table>
    
    </div>
        <table style="width:100%;">
            <caption style="background-color: #6699FF">
                <h3>Unidades Sobreviventes</h3>
                <h3>
                    <asp:Button ID="Graficar" runat="server" OnClick="Graficar_Click" Text="Graficar" />
                </h3>
            </caption>
            <tr>
                <td class="auto-style11">Nivel 0:</td>
                <td class="auto-style15" colspan="2">
                    <asp:Image ID="ImagenNivel0US" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Nivel 1:</td>
                <td class="auto-style14" colspan="2">
                    <asp:Image ID="ImagenNivel1US" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Nivel 2:</td>
                <td class="auto-style14" colspan="2">
                    <asp:Image ID="ImagenNivel2US" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Nivel 3:</td>
                <td class="auto-style14" colspan="2">
                    <asp:Image ID="ImagenNivel3US" runat="server" />
                </td>
            </tr>
        </table>
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #3366FF">Unidades Destruidas</h3>
                <h3 style="background-color: #3366FF">
                    <asp:Button ID="GraficaUniDes" runat="server" OnClick="GraficaUniDes_Click" Text="Graficar" />
                    <br />
                </h3>
            </caption>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
