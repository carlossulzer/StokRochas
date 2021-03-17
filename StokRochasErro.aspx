<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StokRochasErro.aspx.cs" Inherits="StokRochasErro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Stok Rochas ::</title>
</head>
<body style="text-align: center; margin-top: 4px;">
    <form id="form1" runat="server">
        <div id="topo" style="border-right: black 1px solid; border-top: black 1px solid;
            border-left: black 1px solid; border-bottom: black 1px solid; width: 1024px;
            height: 81px">
            <div style="float: right; width: 384px; padding-top: 15px; height: 58px">
                <div class="divendereco" style="font-size: 11px; float: left; width: 182px; color: black;
                    font-family: Tahoma; height: 46px; text-align: left">
                    <span style="font-size: 8pt; color: dimgray; font-family: Verdana">stokrochas.com.br<br />
                        +55 28 3518-6666<br />
                        stokrochas@stokrochas.com.br </span>
                </div>
                <div class="divendereco" style="font-size: 11px; float: left; width: 12px; color: black;
                    font-family: Tahoma; height: 22px">
                    <span style="color: darkgray">|<br />
                        |<br />
                        |</span></div>
                <div class="divendereco" style="font-size: 11px; float: left; width: 188px; color: black;
                    font-family: Tahoma; height: 45px; text-align: left">
                    <span><span><span style="font-family: Verdana"><span style="font-size: 8pt"><span><span
                        style="color: dimgray"><span>Rua Dr. Amilcar Figliuzzi, 130, Coronel Borges, Cachoeiro
                            de Itapemirim, </span><span><span>CEP: 29.306-220</span></span></span></span></span></span></span></span></div>
            </div>
            <div style="padding-left: 0px; float: left; width: 252px; padding-top: 3px; height: 70px">
                <span style="font-size: 36pt; color: #ffffff">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagens/Logo_StokRochas.gif" /></span></div>
        </div>
        <div style="width: 1024px; height: 296px; border-right: black 1px solid; border-left: black 1px solid;
            border-bottom: black 1px solid; padding-top: 150px; text-align: center;">
            <asp:Label ID="Label1" runat="server" Text="Ocorreu um erro na sua solicitação. O erro será reportado a nossa equipe e em breve estará solucionado. Desculpe." Height="105px" SkinID="titulo" Width="778px"></asp:Label>
            <div style="width: 1016px; height: 100px; text-align: center; padding-top: 30px">
                <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" /></div>
        </div>
    </form>
</body>
</html>
