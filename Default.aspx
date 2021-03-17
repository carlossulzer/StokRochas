<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title=":: Stok Rochas - Home ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="inicio_flash">
        <asp:Label ID="LabelFlash" runat="server" CssClass="inicio_flash" EnableViewState="false"
            Text="<embed src='animacao/banner.swf' wmode='transparent' quality=high width=730 height=270 type='application/x-shockwave-flash'></embed>"></asp:Label>
    </div>
    <div id="divTelEmail" style="width: 684px; padding-top: 20px; height: 330px" runat="server">
        <table style="width: 681px; height: 55px">
            <tr>
                <td style="width: 25px">
                    &nbsp;</td>
                <td style="width: 151px">
                    <asp:ImageButton ID="ibtnFornecedores" runat="server" 
                        ImageUrl="~/imagens/botao_fornecedores.jpg" 
                        onclick="ibtnFornecedores_Click" />
                </td>
                <td style="width: 151px">
                    <asp:ImageButton ID="ibtnPromocoes" runat="server" 
                        ImageUrl="~/imagens/botao_promocoes.jpg" onclick="ibtnPromocoes_Click" />
                </td>
                <td style="width: 154px">
                    <asp:ImageButton ID="ibtnUtilidades" runat="server" 
                        ImageUrl="~/imagens/botao_utilidades.jpg" onclick="ibtnUtilidades_Click" />
                </td>
                <td style="width: 142px">
                    <asp:ImageButton ID="ImageButton13" runat="server" 
                        ImageUrl="~/imagens/botao_lancamento.jpg" onclick="ImageButton13_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25px">
                    &nbsp;</td>
                <td style="width: 151px">
                    &nbsp;</td>
                <td style="width: 151px">
                    &nbsp;</td>
                <td style="width: 154px">
                    &nbsp;</td>
                <td style="width: 142px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td colspan="6">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Rodape.jpg" />
                </tr>
            </tr>
            
            <%--<tr>
                <td colspan="5">
                    <DIV CLASS="sombraSite">
                        www.stokrochas.com.br
                    </DIV>

                    <DIV CLASS="textoSite">
                        www.stokrochas.com.br
                    </DIV>

                    
                    
                </td>
            </tr>
            
            <tr>
                <td colspan="5">
                    <DIV CLASS="sombraTelefone">
                        (28) 3518-6666
                    </DIV>

                    <DIV CLASS="textoTelefone">
                        (28) 3518-6666
                    </DIV>

                    
                    
                </td>
            </tr>            --%>
            
            
            
            </table>
    </div>
</asp:Content>

