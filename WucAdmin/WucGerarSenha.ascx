<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucGerarSenha.ascx.cs" Inherits="WucAdmin_WucGerarSenha" %>
<div style="width: 831px; padding-top: 40px; height: 288px; text-align: center">
    <asp:GridView ID="grvClientes" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
        CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="1px" Width="790px" OnSelectedIndexChanged="grvClientes_SelectedIndexChanged">
        <FooterStyle BackColor="#CCCC99" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="CodCliente" HeaderText="C&#243;digo">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="NomeFantasia" HeaderText="Nome do Cliente">
                <ItemStyle Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="Login" HeaderText="Login">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="E-Mail">
                <ItemStyle Width="250px" />
            </asp:BoundField>
            <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
        </Columns>
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    &nbsp;<br />
<br />
<table style="padding-left: 3px; width: 248px">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:ImageButton ID="ibtnEnviar" runat="server" ImageUrl="~/imagens/Enviar.png"
                ToolTip="Enviar Senha" OnClick="ibtnEnviar_Click" />&nbsp;<asp:ImageButton ID="ibtnVoltar" runat="server"
                    ImageUrl="~/imagens/voltar.png" ToolTip="Voltar" OnClick="ibtnVoltar_Click" /></td>
    </tr>
</table>
</div>
