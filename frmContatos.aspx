<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="frmContatos.aspx.cs" Inherits="frmContatos" Title=":: Stok Rochas - Contatos ::" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contato_form">
    
    <div class="contato_topo">
        <div class="contato_titulo_imagen">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" />
        </div>
        <div class="contato_titulo_texto">
            <asp:Label ID="Label6" runat="server" Text="CONTATOS" SkinID="labelTitulo" ></asp:Label>
        </div>
   </div>
      
    
    
    <div style="float: left; width: 681px; height: 300px; text-align: center">
        <div style="float: left; width: 204px; padding-top: 25px; height: 288px">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/telefonista.jpg" /></div>
        <div class="contato_right">
            <div>
                <p class="labels">
                    Temos uma equipe sempre pronta para melhor atendê-lo.
                    Escolha uma opção para entrar em contato:</p>
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="E-Mail" CssClass="labelSubTitulo"></asp:Label>
                <table style="width: 418px; font-size: 11px; color: black; font-family: Verdana;">
                    <tr>
                        <td style="width: 114px; text-align: right">
                            Stok Rochas:</td>
                        <td>
                            <a href="mailto:stokrochas@stokrochas.com.br?subject%22On-line%22">
                                stokrochas@stokrochas.com.br</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 114px; text-align: right">
                            Comercial:</td>
                        <td>
                            <a href="mailto:comercial@stokrochas.com.br?subject%22On-line%22">
                                comercial@stokrochas.com.br</a></td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 114px; text-align: right">
                            Financeiro:</td>
                        <td>
                            <a href="mailto:financeiro@stokrochas.com.br?subject=%22On-line%22">
                                financeiro@stokrochas.com.br</a>
                        </td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 114px; text-align: right">
                            Diretoria:</td>
                        <td>
                           <a href="mailto:carlos@stokrochas.com.br?subject=%22On-line%22">
                              carlos@stokrochas.com.br</a>
                        </td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 114px; text-align: right">
                        </td>
                        <td>
                           <a href="mailto:rafael@stokrochas.com.br?subject=%22On-line%22">
                              rafael@stokrochas.com.br</a>
                        </td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 114px; text-align: right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="Label3" runat="server" Text="Correspondência" 
                CssClass="labelSubTitulo"></asp:Label>&nbsp;
            <div>
                    <span style="color: #0000ff; text-decoration: underline"></span>
                <table style="width: 416px">
                    <tr>
                        <td style="font-size: 11px; width: 415px; color: black; font-family: Verdana; height: 27px">
                
                    Rua Dr. Amilcar Figliuzzi, nº 130 • Coronel Borges • CEP 29306-220<br />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: 11px; width: 415px; color: black; font-family: Verdana; height: 15px;">
                            Cachoeiro de Itapemirim
                    • ES • Brasil
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width: 288px">
                    <tr>
                        <td style="width: 54px; text-align: right; height: 20px;">
                            &nbsp;</td>
                        <td style="width: 228px; text-align: left; font-size: 11px; font-family: Verdana; height: 20px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 54px; text-align: right; height: 20px;">
                            <asp:Label ID="Label4" runat="server" Text="PABX:" CssClass="labelSubTitulo"></asp:Label></td>
                        <td style="width: 228px; text-align: left; font-size: 11px; font-family: Verdana; height: 20px;">
                            <span style="color: #000000">+55 (28) 3518 6666 </span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 54px; text-align: right">
                            <asp:Label ID="Label5" runat="server" Text="Celular:" CssClass="labelSubTitulo"></asp:Label></td>
                        <td style="width: 228px; text-align: left; font-size: 11px; font-family: Verdana; height: 20px;">
                            <span style="color: #000000">+55 (28) 9273 6663</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 54px; text-align: right">
                        </td>
                        <td style="width: 228px; text-align: left; font-size: 11px; font-family: Verdana; height: 20px;">
                            +55 (28) 9278 2500</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
</asp:Content>
