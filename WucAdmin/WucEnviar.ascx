<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucEnviar.ascx.cs" Inherits="WucAdmin_WucEnviar" %>
<div style="width: 831px; padding-top: 40px; height: 288px; text-align: center">
<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Para efetuar a exportação de dados para o provedor de internet, será preciso estar">
</asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="conectado à internet, sendo assim, clique no botão enviar."></asp:Label>&nbsp;<br />
<br />
<br />
<br />
<br />
<table style="padding-left: 3px; width: 248px">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:ImageButton ID="ibtnEnviar" runat="server" ImageUrl="~/imagens/Enviar.png"
                ToolTip="Enviar Dados" OnClick="ibtnEnviar_Click" />&nbsp;<asp:ImageButton ID="ibtnVoltar" runat="server"
                    ImageUrl="~/imagens/voltar.png" ToolTip="Voltar" /></td>
    </tr>
</table>
</div>
