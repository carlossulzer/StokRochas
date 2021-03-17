<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="frmProdutos.aspx.cs" Inherits="frmProdutos" Title=":: Stok Rochas - Produtos ::"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="produtos_forms">
                <div class="produtos_topo">
                    <div class="produtos_titulo_imagem">
                        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/seta_titulo.jpg">
                        </asp:Image>
                    </div>
                    <div class="produtos_titulo_texto">
                        <asp:Label ID="Label1" runat="server" Text="ESTOQUE ON-LINE" 
                            SkinID="labelTitulo"></asp:Label>
                    </div>
                </div>

                <asp:MultiView ID="MultiViewProdutos" runat="server" ActiveViewIndex="0">

                    <asp:View ID="ViewItens" runat="server">
                        <div style="text-align: left" class="produtos_datalist" runat="server" id="divItens">
                            <asp:DataList ID="dlstProdutos" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                RepeatColumns="4">
                                <ItemTemplate>
                                    <asp:Panel ID="Panel1" class="produtos_painel" runat="server">
                                        <div class="produtos_itens_interna">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/seta_estoque.jpg"></asp:Image>&nbsp;<asp:LinkButton
                                                ID="lnkbtFornecedor" OnClick="lnkbtFornecedor_Click" runat="server" Text='<%# Eval("nomeFantasia") %>'
                                                CommandArgument='<%# String.Format("{0};{1}", Eval("codCliente") , Eval("codProduto")) %>'></asp:LinkButton><br />
                                            <asp:Label ID="Label11" runat="server" Width="56px" Text="Telefone:" Font-Bold="False"
                                                Font-Size="10px" Font-Names="Verdana" Height="11px"></asp:Label><asp:Label ID="Label12"
                                                    runat="server" Width="89px" Text='<%# Eval("Telefone1") %>' Font-Size="10px"
                                                    Font-Names="Verdana" Height="11px"></asp:Label><br />
                                            <asp:Label ID="Label4" runat="server" Width="27px" Text="Cor:" Font-Bold="False"
                                                Font-Size="10px" Font-Names="Verdana" Height="11px"></asp:Label><asp:Label ID="Label6"
                                                    runat="server" Width="100px" Text='<%# Eval("NomeCorPor") %>' Font-Size="10px"
                                                    Font-Names="Verdana" Height="11px"></asp:Label><br />
                                            <asp:Label ID="Label7" runat="server" Text="Tipo:" Font-Bold="False" Font-Size="10px"
                                                Font-Names="Verdana" Height="11px"></asp:Label><asp:Label ID="Label8" runat="server"
                                                    Width="103px" Text='<%# Eval("DescTipo") %>' Font-Size="10px" Font-Names="Verdana"
                                                    Height="11px"></asp:Label><br />
                                            <asp:Label ID="Label9" runat="server" Text="Espessura:" Font-Bold="False" Font-Size="10px"
                                                Font-Names="Verdana" Height="11px"></asp:Label><asp:Label ID="Label10" runat="server"
                                                    Width="75px" Text='<%# Eval("DescEspessura") %>' Font-Size="10px" Font-Names="Verdana"
                                                    Height="11px"></asp:Label><br />
                                            <asp:Label ID="Label13" runat="server" Text="Quantidade:" Font-Bold="False" Font-Size="10px"
                                                Font-Names="Verdana" Height="11px"></asp:Label><asp:Label ID="Label15" runat="server"
                                                    Width="64px" Text='<%# Eval("Quantidade") %>' Font-Bold="True" Font-Size="10px"
                                                    Font-Names="Verdana" Height="11px" ForeColor="Black"></asp:Label><br />
                                            <asp:Label ID="Label3" runat="server" Width="38px" Text="Nome:" Font-Bold="False"
                                                Font-Size="10px" Font-Names="Verdana" Height="26px"></asp:Label>
                                            <asp:Label Style="vertical-align: top" ID="Label5" runat="server" Width="123px" Text='<%# Eval("nomeProduto") %>'
                                                Font-Bold="True" Font-Size="10px" Font-Names="Verdana" Height="26px" ForeColor="Black"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></asp:Label>
                                        </div>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <div class="navegador">
                            <table style="width: 678px; height: 50px; vertical-align: top;">
                                <tbody>
                                    <tr>
                                        <td style="width: 169px; height: 50px">
                                        </td>
                                        <td style="width: 405px; height: 35px; text-align: center">
                                            <div class="navegador_interna">
                                                <div class="seta_esquerda">
                                                    <asp:ImageButton ID="ibtnEsquerda" OnClick="ibtnEsquerda_Click" runat="server" ImageUrl="~/imagens/seta_esquerda.jpg"
                                                        Visible="False"></asp:ImageButton>
                                                </div>
                                                <div class="letra_st">
                                                    <asp:Image ID="imgST" runat="server" ImageUrl="~/imagens/st.jpg" Visible="False">
                                                    </asp:Image>
                                                </div>
                                                <div class="navegador_centro">
                                                    <asp:DataList ID="dlPaging" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
                                                        RepeatColumns="5" OnItemDataBound="dlPaging_ItemDataBound" OnItemCommand="dlPaging_ItemCommand"
                                                        BorderWidth="0px">
                                                        <ItemTemplate>
                                                            <div class="navegador_imagem_o">
                                                                <asp:ImageButton ID="ibtnAtual" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                                                    CommandName="lnkbtnPaging" ImageUrl="~/imagens/Letra_O_Cinza.jpg" Text='<%# Eval("PageText") %>' />
                                                            </div>
                                                            <div class="navegador_link">
                                                                <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                                                    CommandName="lnkbtnPaging" CssClass="linkNavegador" Text='<%# Eval("PageText") %>'></asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                                <div class="letra_k">
                                                    <asp:Image ID="imgLetraK" runat="server" ImageUrl="~/imagens/LetraK.jpg" Visible="False">
                                                    </asp:Image>
                                                </div>
                                                <div style="text-align: center" class="seta_direita">
                                                    <asp:ImageButton ID="ibtnDireita" OnClick="ibtnDireita_Click" runat="server" ImageUrl="~/imagens/seta_direita.jpg"
                                                        Visible="False"></asp:ImageButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 100px; height: 50px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </asp:View>
                    
                    <asp:View ID="ViewSemProduto" runat="server">
                        <div id="divMensagem" class="produtos_mensagem">
                            <asp:Label ID="lblConsulta" runat="server" SkinID="labelSubTitulo" Text="Não existem produtos para a consulta efetuada."
                                Visible="true">
                            </asp:Label>
                        </div>
                    </asp:View>
                    
                </asp:MultiView>
            </div>

          
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                
                    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" Radius="10"
                        TargetControlID="Panel31">
                    </cc1:RoundedCornersExtender>
                    
                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="popup"
                        CancelControlID="ibtnFecharDetalhes" PopupControlID="pnlFornecedor" TargetControlID="hiddenTargetControlForModalPopup">
                    </cc1:ModalPopupExtender>
                    
                    <asp:Panel ID="pnlFornecedor" runat="server" BackColor="Transparent" Height="452px"
                        Style="display: none" Width="865px">
                        <asp:Panel ID="Panel31" runat="server" BackColor="White" Height="496px" 
                            Width="863px">
 
                            <div style="padding-left: 10px; width: 371px; padding-top: 10px; height: 431px; float:left;">
                                <div style="width: 354px; height: 37px; text-align: left; float:left">
                                    <asp:Image ID="Imagem1" runat="server" ImageUrl="~/imagens/seta_estoque.jpg" />
                                    <asp:Label ID="lblNome" runat="server" SkinID="labelTitulo"></asp:Label>
                                </div>
                                
                                <div style="width: 340px; height: 66px; text-align: left">
                                    <asp:Label ID="Label31" runat="server" SkinID="labelSubTitulo" Text="Endereço"></asp:Label>
                                </div>
                                
                                <div style="padding-left: 10px; width: 330px; height: 59px; text-align: left">
                                    <asp:Label ID="lblEndereco" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="lblCidade" runat="server"></asp:Label>
                                </div>
                                             
                                <div style="width: 340px; height: 23px; text-align: left;">
                                    <asp:Label ID="Label14" runat="server" SkinID="labelSubTitulo" Text="Telefone"></asp:Label>
                                </div>
                                <div style="padding-left: 10px; width: 330px; height: 41px; text-align: left; ">
                                    <asp:Label ID="lblTelefone1" runat="server" Text="Label"/><br />
                                    <asp:Label ID="lblTelefone2" runat="server" Text="Label"/>
                                </div>
                                <div style="text-align: left; width:340px; height: 25px;">
                                    <asp:Label ID="Label33" runat="server" SkinID="labelSubTitulo" Text="E-Mail"></asp:Label>
                                </div>
                                
                                <div style="padding-left:10px; width: 330px; height: 55px; text-align: left;">
                                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblEmail2" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div style="width: 340px; height: 23px; text-align: left">
                                    <asp:Label ID="Label35" runat="server" Text="Site" SkinID="labelSubTitulo"></asp:Label>
                                </div>
                                <div style="padding-left: 10px; width: 330px; height: 27px; text-align: left;">
                                    <asp:HyperLink ID="hplkSite" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                </div>
                                <div ID="Div1" runat="server" 
                                    style="height: 99px; text-align: left; width: 340px;">
                                    <asp:Label ID="lblObservacao" runat="server" Style="width: 339px;
                                                            height: auto;" Text='<%# Eval("Observacao") %>'>
                                    </asp:Label>
                                    
                                </div>
                                
                                         
                            </div>

                            <div style="padding-left: 10px; width: 465px; padding-top: 10px; height: 430px; float:right;">
                                <div style="width: 463px; height: 347px; text-align: center">
                                    <asp:Image ID="imgGrande" runat="server" 
                                        ImageUrl="~/Produtos/3/grande/1.jpg" BorderStyle="Outset" BorderWidth="3px" 
                                        Height="340px" />
                                </div>
                                
                                <div style="width: 466px; height: 80px; text-align: center">
                                    <table style="width: 463px; height: 69px">
                                        <tr>
                                            <td style="text-align: left; height: 20px;" colspan="2">
                                                <asp:Label ID="Label37" runat="server" 
                                                    Text="* foto do tipo do produto meramente ilustrativa"></asp:Label>
                                            </td>
                                        </tr>                                    
                                        <tr>
                                            <td colspan="2" style="text-align: left; height: 5px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 87px; text-align: right;">
                                                <asp:Label ID="Label36" runat="server" Text="Nome : "></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 350px;">
                                                <asp:Label ID="lblMaterial" runat="server" SkinID="labelSubTitulo" Text=""></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="width: 87px; text-align: right;">
                                                <asp:Label ID="Label2" runat="server" Text="Quantidade : "></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 350px;">
                                                <asp:Label ID="lblQuant" runat="server" Text="" SkinID="labelSubTitulo"></asp:Label>
                                            </td>
                                        </tr>
                                       
                                    </table>
                                </div>
                            </div>
                                                        
                            <div style="height: 23px; text-align: center; width: 857px; clear: both;">
                                <asp:ImageButton ID="ibtnFecharDetalhes" runat="server" 
                                    ImageUrl="~/imagens/botao_fechar.jpg" />
                            </div>
                            


                        </asp:Panel>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
          </ContentTemplate>

    </asp:UpdatePanel>            
</asp:Content>
