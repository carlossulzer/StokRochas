﻿<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="frmLancamentos.aspx.cs" Inherits="frmLancamentos" Title=":: Stok Rochas - Lançamentos ::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="lancamentos_form">
                <div class="lancamentos_topo">
                    <div class="lancamentos_titulo_imagen">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" />
                    </div>
                    <div class="lancamentos_titulo_texto">
                        <asp:Label ID="Label6" runat="server" Text="LANÇAMENTOS" SkinID="labelTitulo"></asp:Label>
                    </div>
                </div>
                <div class="lancamentos_body">
                    <div class="lancamentos_menu">
                        <div style="height: 25px; text-align: center; background-color: #FFA500; padding-top: 5px; width: 209px; float:left;">
                            <asp:Label ID="Label1" runat="server" Text="Fornecedores" CssClass="labelSubTitulo"></asp:Label>
                        </div>
                        <div class="lancamentos_menu_interno" >
                           <asp:DataList ID="dlstFornecedores" runat="server" Width="193px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtFornecedor" OnClick="lnkbtFornecedor_Click" runat="server"
                                        Text='<%# Eval("NomeFantasia") %>' CommandArgument='<%# Eval("CodCliente") %>'>
                                    </asp:LinkButton>
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>

                    </div>
                    <div class="lancamentos_right">
                        <div class="lancamentos_select">
                            <asp:Label ID="lblLancamentosSelect" runat="server" Text="fornecedor selecionado" CssClass="labelSubTitulo"></asp:Label>
                        </div>
                        <div style="border-top: 1px dotted #000000; height: auto; width: 508px; padding-top: 7px; background-color: #FFFFFF; padding-left: 7px;">
                            <div id="divLogo" style="clear: both; width: 144px; float: left; height: auto; text-align: left;
                                vertical-align: middle" runat="server">
                                <asp:Image ID="imgLogotipo" runat="server" Height="70px" Width="130px" ImageUrl=""
                                    ImageAlign="Middle" />
                            </div>
                            <div id="divFornecedor" 
                                style="width: 351px; float: left; height: auto; margin-right: 0px;" 
                                runat="server">
                                <br />
                                <div style="float: left; width: 16px; padding-top: 2px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/seta_estoque.jpg" />
                                </div>
                                <asp:Label ID="lblNomeFantasia" runat="server" Font-Names="Verdana" Text="" CssClass="labelSubTitulo"
                                    Width="320px">
                                </asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblEndCliente" runat="server" Font-Names="Verdana" Text="" Style="width: 350px;
                                    height: auto;">
                                </asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblTelefones" runat="server" Font-Names="Verdana" Style="height: auto;
                                    min-height: 11px; width: 350px" Text="">
                                </asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblEmails" runat="server" Font-Names="Verdana" Style="height: auto;
                                    min-height: 11px; width: 350px" Text="">
                                </asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblWebSite" runat="server" Text="WebSite:" CssClass="labelSubTitulo" />
                               
                                <a id="linkSite" href="" target="_blank" runat="server">
                                    <asp:Label ID="lblSiteCli" runat="server" Font-Names="Verdana" Style="height: auto; min-height: 11px;
                                        width: 350px" Text="">
                                    </asp:Label>
                                </a>
                                <br />
                                <br />
                                <asp:Label ID="lblObservacao" runat="server" Font-Names="Verdana" Text="" Width="350px"></asp:Label>
                                <br />
                                <br />
                            </div>
                        </div>
                        
                        <div class="lancamentos_itens">
                        
                            <asp:DataList ID="dlstLancamentos" runat="server" Width="500px" 
                                OnItemDataBound="dlstLancamentos_ItemDataBound">
                                <ItemTemplate>
                                    <div style="border-top: 1px dotted #000000; height: 138px; width: 515px; padding-top: 7px; ">
                                        <div style="clear: both; width: 146px; float: left; height: 108px; text-align: center;
                                            vertical-align: middle">
                                            <asp:Image ID="ImagePeq" runat="server" Height="100px" Width="135px" ImageUrl='<%# String.Format("~/Lancamentos/{0}/pequena/{1}.jpg", Eval("codCliente") , Eval("codLancAccess")) %>'
                                                ImageAlign="Middle" BorderStyle="Outset" BorderWidth="3px" />
                                            <div style="padding: 5px; clear: both; width: 135px; float: left; height: 20px; text-align: center;
                                            vertical-align: middle; ">
                                                <asp:ImageButton ID="ibtnAmpliar" runat="server" 
                                                    CommandArgument='<%# String.Format("~/Lancamentos/{0}/grande/{1}.jpg", Eval("codCliente") , Eval("codLancAccess")) %>' 
                                                    ImageAlign="Middle" ImageUrl="~/imagens/Ampliar.jpg" 
                                                    OnClick="ibtnAmpliar_Click" ToolTip='<%# Eval("nomeProduto") %>' />
                                            </div>
                                        </div>
                                        
                                        <div>
                                            <div style="float: left; width: 348px; height: auto;">
                                                <table style="width: 349px; height: 10px">
                                                    <tr>
                                                        <td style="width: 112px; text-align: right; height: 17px;">
                                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Nome : "></asp:Label>
                                                        </td>
                                                        <td style="text-align: left; height: 17px;">
                                                            <asp:Label ID="Label16" runat="server" Font-Names="Verdana" Style="width: 350px;
                                                                height: auto;" Text='<%# Eval("nomeProduto") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 112px; text-align: right">
                                                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Cor : "></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label3" runat="server" Font-Names="Verdana" 
                                                                Style="width: 350px; height: auto;" Text='<%# Eval("nomeCorPor") %>'>
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 112px; text-align: right">
                                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Observação : "></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label20" runat="server" Font-Names="Verdana" 
                                                                Style="width: 350px; height: auto;" Text='<%# Eval("Observacao") %>'>
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                                                    
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
            
            
            <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server"/>

            <ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="Panel1" Radius="10"/>

            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
                BackgroundCssClass="popup" CancelControlID="ibtnFecharDetalhes" PopupControlID="pnlLancamentos">
            </ajaxToolkit:ModalPopupExtender>
            
        <%--    <asp:Panel Style="display: none" ID="pnlLancamentos" runat="server" Width="580px" BackColor="Transparent" Height="435px">
                <asp:Panel ID="Panel1" runat="server" Width="578px" BackColor="White" Height="433px">
        --%>        
            <asp:Panel Style="display: none; text-align:center;" ID="pnlLancamentos" runat="server" Width="520px" BackColor="Transparent" Height="435px">
                <asp:Panel ID="Panel1" runat="server" Width="480px" BackColor="White" Height="411px" style="text-align:center; padding-top:10px;">  
                    <div style="width: 450px; height: 340px; background-color:White; border-style:outset; border-width:3px; margin-left:12px; margin-right:15px;">
                        <asp:Image ID="imgGrande" runat="server" ImageUrl="~/imagens/ProdutoSemFoto.jpg" ></asp:Image>
                    </div>
                    
                    <div style="width: 450px; height: 25px; text-align: left; float:left; padding-left: 13px; margin-top:10px;">
                        <asp:Label ID="lblProduto" runat="server" SkinID="labelTitulo" Text="Nome do Produto"></asp:Label>
                    </div>
                    
                    <div style="width: 450px; height: 25px; text-align: center; float:left; padding-left: 13px;">
                        <asp:Image ID="ibtnFecharDetalhes" runat="server" ImageUrl="~/imagens/botao_fechar.jpg" ></asp:Image>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
