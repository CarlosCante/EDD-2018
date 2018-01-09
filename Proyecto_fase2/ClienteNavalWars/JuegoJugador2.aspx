<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JuegoJugador2.aspx.cs" Inherits="JuegoJugador2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            height: 23px;
            text-align: center;
            background-color: #00FF00;
        }
        .auto-style6 {
            text-align: left;
            width: 510px;
        }
        .auto-style7 {
            text-align: left;
            width: 531px;
        }
        .auto-style11 {
            width: 150px;
        }
        .auto-style9 {
            width: 376px;
        }
        .auto-style10 {
            width: 160px;
        }
        .auto-style14 {
            width: 359px;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style15 {
            text-align: center;
            height: 23px;
        }
        .auto-style16 {
            text-align: center;
            background-color: #00FF00;
        }
        .auto-style18 {
            height: 23px;
        }
        .auto-style19 {
            text-align: left;
            height: 23px;
        }
        .auto-style12 {
            width: 220px;
        }
        .auto-style20 {
            width: 220px;
            height: 23px;
        }
        .auto-style13 {
            width: 220px;
            height: 21px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table aria-expanded="undefined" aria-grabbed="undefined" style="width: 100%">
            <caption>
                <h1 style="background-color: #0000FF">JUGADOR 2</h1>
                <h2 style="background-color: #0000FF">
                    <asp:Label ID="LabelJugador" runat="server" Text="Jugador 1"></asp:Label>
                </h2>
            </caption>
            <tr>
                <td class="auto-style1" colspan="2">
                    <h3>Estado del Tablero<br />
                        <asp:Button ID="BotonActualizar" runat="server" OnClick="BotonActualizar_Click" Text="Actualizar" />
                    </h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Nivel 0 Submarinos:</td>
                <td class="auto-style7">Nivel 1 Barcos:</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Image ID="ImageNivel0" runat="server" />
                </td>
                <td class="auto-style7">
                    <asp:Image ID="ImageNivel1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Nivel 2 Aviones:</td>
                <td class="auto-style7">Nivel 3 Satelites:</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Image ID="ImageNivel2" runat="server" />
                </td>
                <td class="auto-style7">
                    <asp:Image ID="ImageNivel3" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
        <table style="width:100%;">
            <caption style="background-color: #00FF00">
                <h3>&nbsp;Movimientos</h3>
            </caption>
            <tr>
                <td class="auto-style11">Coordenadas de origen:</td>
                <td class="auto-style9">Columna:
                    <asp:TextBox ID="TextBoxColumOrigen" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">Coordenadas de destino:</td>
                <td class="auto-style14">Columna:&nbsp;
                    <asp:TextBox ID="TextBoxColumDestino" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style9">Fila:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxFilaOrigen" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style14">Fila:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxFilaDestino" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style9">Nivel:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxNivelOrigen" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td class="auto-style14">Nivel:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxNivelDestino" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">
                    <asp:Label ID="LabelMensajeMovimiento" runat="server" Text="De click en mover para realizar su movimiento"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">Turno Atual:
                    <asp:Label ID="LabelTurno" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mover" />
                </td>
            </tr>
            <tr>
                <td class="auto-style15" colspan="4">
                </td>
            </tr>
            <tr>
                <td class="auto-style16" colspan="4">
                    <h3>Atacar</h3>
                </td>
            </tr>
            <tr>
                <td>
                    Coordenadas de origen:</td>
                <td>
                    Columna:&nbsp;
                    <asp:TextBox ID="TextBoxColumOrigen0" runat="server"></asp:TextBox>
                </td>
                <td>
                    Coordenadas de destino:</td>
                <td>
                    Columna:&nbsp;
                    <asp:TextBox ID="TextBoxColumDestino0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style18">
                </td>
                <td class="auto-style19">
                    Fila:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxFilaOrigen0" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style15">
                </td>
                <td class="auto-style19">
                    Fila:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxFilaDestino0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Nivel:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxNivelOrigen0" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Nivel:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxNivelDestino0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">
                    <asp:Label ID="LabelMensajeAtaque" runat="server" Text="De click en atacar para realizar su ataque"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">
                    Turno Actual:
                    <asp:Label ID="LabelTurno0" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Atacar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <caption>
                <h3 style="background-color: #00FF00">Estadisticas</h3>
            </caption>
            <tr>
                <td class="auto-style12">Unidades perdidas:&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelUnidadesPerdidas" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="15">
                    <asp:TextBox ID="TextConsola" runat="server" Height="323px" TextMode="MultiLine" Width="808px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Unidades Destruidas:&nbsp; <asp:Label ID="LabelUnidadesDestruidas" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Tiempo Restante:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelTiempoRestante" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Button ID="TerminarTurno" runat="server" OnClick="TerminarTurno_Click" Text="Terminar Turno" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Actualizar Bitacora" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
