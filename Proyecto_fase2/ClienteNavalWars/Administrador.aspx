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
        .auto-style16 {
            width: 158px;
        }
        .auto-style17 {
            width: 158px;
            height: 23px;
        }
        .auto-style18 {
            height: 23px;
            width: 241px;
        }
        .auto-style19 {
            width: 241px;
        }
        .auto-style20 {
            background-color: #3366FF;
        }
        .auto-style21 {
            background-color: #00FF00;
        }
        .auto-style23 {
            width: 125px;
            background-color: #00FF00;
        }
        .auto-style25 {
            width: 105px;
        }
        .auto-style26 {
            width: 177px;
        }
        .auto-style27 {
            width: 214px;
        }
        .auto-style28 {
            width: 123px;
        }
        .auto-style29 {
            width: 177px;
            height: 26px;
        }
        .auto-style30 {
            width: 214px;
            height: 26px;
        }
        .auto-style31 {
            width: 182px;
        }
        .auto-style32 {
            width: 113px;
        }
        .auto-style33 {
            width: 223px;
        }
        .auto-style34 {
            width: 161px;
        }
        .auto-style35 {
            width: 241px;
            background-color: #00FF00;
        }
        .auto-style36 {
            height: 23px;
            width: 241px;
            background-color: #00FF00;
        }
        .auto-style37 {
            height: 23px;
            width: 786px;
        }
        .auto-style38 {
            width: 786px;
        }
        .auto-style39 {
            background-color: #00FF00;
            width: 786px;
        }
        .auto-style40 {
            width: 125px;
        }
        .auto-style41 {
            width: 223px;
            background-color: #00FF00;
        }
        .auto-style42 {
            width: 113px;
            background-color: #00FF00;
        }
        .auto-style43 {
            width: 182px;
            background-color: #00FF00;
        }
        .auto-style44 {
            text-align: center;
        }
        .auto-style45 {
            width: 125px;
            height: 30px;
        }
        .auto-style46 {
            height: 30px;
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
                <td class="auto-style2">Contactos:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUploadContactos" runat="server" Width="356px" />
                    <asp:Button ID="CargarContactos" runat="server" OnClick="CargarContactos_Click" Text="Cargar" />
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Historial:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUploadHistorial" runat="server" Width="356px" />
                    <asp:Button ID="CargarHistorial" runat="server" OnClick="CargarHistorial_Click" Text="Cargar" />
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                    <asp:Button ID="Button10" runat="server" Text="Graficar" OnClick="Button10_Click" />
                    <asp:Image ID="ImageNivel2Inicial" runat="server" />
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
                    <asp:Button ID="Button11" runat="server" Text="Graficar" OnClick="Button11_Click" />
                    <asp:Image ID="ImageNivel3Inicial" runat="server" />
                </td>
            </tr>
            </table>
    
    </div>
        <br />
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #3366FF">Tablero de Juego</h3>
                <h3 style="background-color: #3366FF">
                    <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Graficar" />
                </h3>
            </caption>
            <tr>
                <td class="auto-style25">Nivel 0:</td>
                <td>
                    <asp:Image ID="ImageNivel0Actual" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">Nivel 1:</td>
                <td>
                    <asp:Image ID="ImageNivel1Actual" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">Nivel 2:</td>
                <td>
                    <asp:Image ID="ImageNivel2Actual" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">Nivel 3:</td>
                <td>
                    <asp:Image ID="ImageNivel3Actual" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width:100%;">
            <caption class="auto-style20">
                <h3>Administracion de Usuarios</h3>
            </caption>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">Registro de Usuarios:</td>
                <td class="auto-style21" colspan="3">&nbsp;</td>
                <td class="auto-style21" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">NickName:</td>
                <td colspan="3">
                    <asp:TextBox ID="TextNuevoNick" runat="server" Width="187px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">Correo:</td>
                <td colspan="3">
                    <asp:TextBox ID="TextNuevoCorreo" runat="server" Width="186px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">Contraseña:</td>
                <td colspan="3">
                    <asp:TextBox ID="TextNuevoPass" runat="server" Width="183px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">
                    <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="Registrar" />
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">Elminar Usuario:</td>
                <td class="auto-style21" colspan="3">&nbsp;</td>
                <td class="auto-style21" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">NickName:</td>
                <td colspan="3">
                    <asp:TextBox ID="TextElminarNick" runat="server" Width="187px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">
                    <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="Eliminar" />
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">Modificar Usuarios:</td>
                <td class="auto-style21" colspan="3">&nbsp;</td>
                <td class="auto-style21" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style45">
                    &nbsp;</td>
                <td colspan="3" class="auto-style46">Nombre del usuario:
                    <asp:TextBox ID="TextBoxNickModactual" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style46"></td>
            </tr>
            <tr>
                <td class="auto-style45">
                    &nbsp;</td>
                <td colspan="3" class="auto-style46">Datos del usuario nuevos:</td>
                <td colspan="2" class="auto-style46">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">NickName:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxNickMod" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:Label ID="LabelMensajeModUsuario" runat="server" Text="Nota: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxCorreoMod" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">Contraseña:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxContraMod" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button15" runat="server" Text="Actualizar" OnClick="Button15_Click" />
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">Agregar Contacto:</td>
                <td class="auto-style21" colspan="3">&nbsp;</td>
                <td class="auto-style21" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">Nombre el usuario:</td>
                <td class="auto-style31">
                    <asp:TextBox ID="TextBoxUsuarioContacto" runat="server"></asp:TextBox>
                </td>
                <td colspan="4">Datos del Contacto</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style32">Nombre:</td>
                <td class="auto-style33">
                    <asp:TextBox ID="TextBoxnickcontacto" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">Si el usuario existe:</td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style32">Correo:</td>
                <td class="auto-style33">
                    <asp:TextBox ID="TextBoxcorreocontacto" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style34">NickName:</td>
                <td>
                    <asp:TextBox ID="TextBoxContactoUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style32">Contraseña:</td>
                <td class="auto-style33">
                    <asp:TextBox ID="TextBoxcontraseñacontacto" runat="server" OnTextChanged="TextBoxcontraseñacontacto_TextChanged"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="AñadirContacto0" runat="server" OnClick="AñadirContacto0_Click" Text="Añadir" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style33">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">Observaciones:</td>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style33">
                    <asp:Button ID="AñadirContacto" runat="server" OnClick="AñadirContacto_Click" Text="Añadir" />
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="LabelMensajeAñadirContacto" runat="server" Text="Ninguna"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style40">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style33">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">Eliminar Contacto</td>
                <td class="auto-style43">&nbsp;</td>
                <td class="auto-style42">&nbsp;</td>
                <td class="auto-style41">&nbsp;</td>
                <td class="auto-style21" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">Nombre de Usuario:</td>
                <td class="auto-style31">
                    <asp:TextBox ID="TextBoxUsuarioElContacto" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">Nombre de contacto a eliminar:
                    <asp:TextBox ID="TextBoxContactoEliminar" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:Button ID="EliminarContacto" runat="server" OnClick="EliminarContacto_Click" Text="Eliminar" />
                </td>
            </tr>
            <tr>
                <td colspan="6">Observaciones:</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="LabelMensajeEliminarContacto" runat="server" Text="Ninguna"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21" colspan="6">Dispercion de usuarios
                    <asp:Button ID="DispersarUsuarios" runat="server" OnClick="DispersarUsuarios_Click" Text="Generar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style44" colspan="6">
                    <asp:Image ID="ImageTablaHash" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #3366FF">Arbol de Usuarios (ABB)<br />
                    <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Generar Datos" />
                </h3>
            </caption>
            <tr>
                <td class="auto-style18">Altura:&nbsp;&nbsp;
                    <asp:Label ID="LabelAlturaArbol" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style37"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style19">Niveles:&nbsp;
                    <asp:Label ID="LabelNivelesArbol" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">Nodos Hoja:&nbsp;
                    <asp:Label ID="LabelNodosHoja" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">Nodos Rama:&nbsp;
                    <asp:Label ID="LabelNodosRama" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style35">Grafica del Arbol:</td>
                <td class="auto-style39">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Image ID="ImageArbol" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style35">Grafica del Arbol Espejo:</td>
                <td class="auto-style39">
                    <asp:Button ID="GenerarArbolEspejo" runat="server" OnClick="GenerarArbolEspejo_Click" Text="Generar" />
&nbsp;
                    <asp:Label ID="LabelMensajeEspejo" runat="server" Text="Generar Espejo"></asp:Label>
                </td>
                <td class="auto-style21">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Image ID="ImageArbolEspejo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style35">Grafica de Lista de Juegos:</td>
                <td class="auto-style39">&nbsp;
                    <asp:Button ID="GenerarListaJuegos" runat="server" OnClick="GenerarListaJuegos_Click" Text="Generar" />
&nbsp;&nbsp;
                    <asp:Label ID="LabelMensajeListaJuegos" runat="server" Text="Generar Espejo"></asp:Label>
                </td>
                <td class="auto-style21">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Image ID="ImageListaJuegos" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style36">Graficar Arbol de Contactos:</td>
                <td class="auto-style37"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style19">Nick de Usuario:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxNickContactoGrafAVL" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="LabelMensajeAVL" runat="server" Text="Ingrese el nombre del usuario para mostrar su arbol de contatos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="GraficarAVL" runat="server" OnClick="GraficarAVL_Click" Text="Graficar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td colspan="2">
                    <asp:Image ID="ImageAVL" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
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
                    <asp:Button ID="GraficarUniDes" runat="server" OnClick="GraficarUniDes_Click" Text="Graficar" />
                </h3>
            </caption>
            <tr>
                <td class="auto-style16">Nivel 0:</td>
                <td colspan="2">
                    <asp:Image ID="ImagenNivel0UD" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">Nivel 1:</td>
                <td class="auto-style4" colspan="2">
                    <asp:Image ID="ImagenNivel1UD" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">Nivel 2:</td>
                <td class="auto-style4" colspan="2">
                    <asp:Image ID="ImagenNivel2UD" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">Nivel 3:</td>
                <td colspan="2">
                    <asp:Image ID="ImagenNivel3UD" runat="server" />
                </td>
            </tr>
        </table>
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #3366FF">Parametros iniciales del juego</h3>
            </caption>
            <tr>
                <td class="auto-style26">Jugador 1:</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxPJugador1" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td class="auto-style28">Tiempo (Minutos):</td>
                <td>
                    <asp:TextBox ID="TextBoxTIempo" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style26">Jugador 2:</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxPJugador2" runat="server" Width="204px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29">Cantidad de Satelites</td>
                <td class="auto-style30">
                    <asp:TextBox ID="TextBoxNoSa" runat="server" Width="32px"></asp:TextBox>
                </td>
                <td class="auto-style8" colspan="2"></td>
            </tr>
            <tr>
                <td class="auto-style26">Cantidad de Aviones</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxNoAv" runat="server" Width="32px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">Cantidad de Barcos</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxNoBa" runat="server" Width="31px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">Cantidad de Submarinos</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxNoSub" runat="server" Width="31px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">Dimenciones X</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxDX" runat="server" Width="30px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">Dimenciones Y</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TextBoxDY" runat="server" Width="29px"></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">Tipo de Juego:</td>
                <td class="auto-style27">
                    <asp:RadioButtonList ID="TipodeJuego" runat="server" OnSelectedIndexChanged="TipodeJuego_SelectedIndexChanged">
                        <asp:ListItem Value="3">Base</asp:ListItem>
                        <asp:ListItem Value="2">Tiempo</asp:ListItem>
                        <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan="2">Nota: <asp:Label ID="LabelMensajeParametros" runat="server" Text="Ingrese los datos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style26">&nbsp;</td>
                <td class="auto-style27">
                    <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="Cargar" />
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
