<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="frmFornecedores.aspx.cs" Inherits="frmFornecedores" Title=":: Stok Rochas - Fornecedores ::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="fornecedores_form">
                <div class="fornecedores_topo">
                    <div class="fornecedores_titulo_imagem">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/seta_titulo.jpg"></asp:Image>
                    </div>
                    <div class="fornecedores_titulo_texto">
                        <asp:Label ID="Label2" runat="server" Text="FORNECEDORES" SkinID="labelTitulo"></asp:Label>
                    </div>
                </div>
                <div class="fornecedores_menu">
                    <asp:ImageButton ID="ibtnLetraA" OnClick="ibtnLetraA_Click" runat="server" ImageUrl="~/imagens/Letra_A.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraB" OnClick="ibtnLetraB_Click" runat="server" ImageUrl="~/imagens/Letra_B.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraC" OnClick="ibtnLetraC_Click" runat="server" ImageUrl="~/imagens/Letra_C.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraD" OnClick="ibtnLetraD_Click" runat="server" ImageUrl="~/imagens/Letra_D.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraE" OnClick="ibtnLetraE_Click" runat="server" ImageUrl="~/imagens/Letra_E.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraF" OnClick="ibtnLetraF_Click" runat="server" ImageUrl="~/imagens/Letra_F.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraG" OnClick="ibtnLetraG_Click" runat="server" ImageUrl="~/imagens/Letra_G.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraH" OnClick="ibtnLetraH_Click" runat="server" ImageUrl="~/imagens/Letra_H.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraI" OnClick="ibtnLetraI_Click" runat="server" ImageUrl="~/imagens/Letra_I.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraJ" OnClick="ibtnLetraJ_Click" runat="server" ImageUrl="~/imagens/Letra_J.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraK" OnClick="ibtnLetraK_Click" runat="server" ImageUrl="~/imagens/Letra_K.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraL" OnClick="ibtnLetraL_Click" runat="server" ImageUrl="~/imagens/Letra_L.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraM" OnClick="ibtnLetraM_Click" runat="server" ImageUrl="~/imagens/Letra_M.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraN" OnClick="ibtnLetraN_Click" runat="server" ImageUrl="~/imagens/Letra_N.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraO" OnClick="ibtnLetraO_Click" runat="server" ImageUrl="~/imagens/Letra_O.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraP" OnClick="ibtnLetraP_Click" runat="server" ImageUrl="~/imagens/Letra_P.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraQ" OnClick="ibtnLetraQ_Click" runat="server" ImageUrl="~/imagens/Letra_Q.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraR" OnClick="ibtnLetraR_Click" runat="server" ImageUrl="~/imagens/Letra_R.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraS" OnClick="ibtnLetraS_Click" runat="server" ImageUrl="~/imagens/Letra_S.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraT" OnClick="ibtnLetraT_Click" runat="server" ImageUrl="~/imagens/Letra_T.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraU" OnClick="ibtnLetraU_Click" runat="server" ImageUrl="~/imagens/Letra_U.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraV" OnClick="ibtnLetraV_Click" runat="server" ImageUrl="~/imagens/Letra_V.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraW" OnClick="ibtnLetraW_Click" runat="server" ImageUrl="~/imagens/Letra_W.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraX" OnClick="ibtnLetraX_Click" runat="server" ImageUrl="~/imagens/Letra_X.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraY" OnClick="ibtnLetraY_Click" runat="server" ImageUrl="~/imagens/Letra_Y.gif">
                    </asp:ImageButton>
                    <asp:ImageButton ID="ibtnLetraZ" OnClick="ibtnLetraZ_Click" runat="server" ImageUrl="~/imagens/Letra_Z.gif">
                    </asp:ImageButton>
                    &nbsp; &nbsp; &nbsp;
                    <asp:ImageButton ID="ibtnTodos" OnClick="ibtnTodos_Click" runat="server" ImageUrl="~/imagens/Todos.gif">
                    </asp:ImageButton>
                </div>
                <div class="fornecedor_grid">
                    <div class="fornecedor_datalist">
                        <asp:DataList ID="dlstFornecedores" runat="server" RepeatColumns="5" CellPadding="0"
                            DataKeyField="codCliente" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Panel ID="pnlFornecedores" runat="server" CssClass="fornecedor_painel_dados">
                                    <div class="fornecedor_link">
                                        <asp:ImageButton ID="ImageLogo" OnClick="ImageLogo_Click" runat="server" ImageUrl='<%# Eval("Logotipo", "~/Logotipos/{0}") %>'
                                            Width="130px" Height="70px" CommandArgument='<%# Eval("CodCliente") %>'
                                            ToolTip="Clique na imagem para ver detalhes da empresa" ImageAlign="Middle">
                                        </asp:ImageButton>
                                    </div>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:DataList>
                        <div style="width: 668px; padding-top: 5px; height: 27px; text-align: center" id="divMensagem"
                            runat="server" visible="false">
                            <asp:Label ID="lblConsulta" runat="server" SkinID="labelSubTitulo" Text="Não existem fornecedores para a letra selecionada."
                                Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="navegador">
                        <table style="width: 668px; height: 50px">
                            <tbody>
                                <tr>
                                    <td style="width: 169px; height: 50px">
                                    </td>
                                    <td style="width: 266px; height: 50px; text-align: center">
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
                                                <asp:DataList ID="dlPaging" runat="server" RepeatColumns="5" BorderWidth="0px" OnItemCommand="dlPaging_ItemCommand"
                                                    OnItemDataBound="dlPaging_ItemDataBound" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
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
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                    </td>
                                    <td style="width: 100px; height: 50px">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server">
            </asp:Button>
            <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="Panel1"
                Radius="10">
            </cc1:RoundedCornersExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
                BackgroundCssClass="popup" CancelControlID="ibtnFecharDetalhes" PopupControlID="pnlFornecedor">
            </cc1:ModalPopupExtender>
            <asp:Panel Style="display: none" ID="pnlFornecedor" runat="server" Width="393px" 
                BackColor="Transparent" >
                <asp:Panel ID="Panel1" runat="server" Width="380px" BackColor="White" >
                    <div style="padding-left: 10px; width: 371px; padding-top: 10px; height: auto; background-color: White">
                        <div style="width: 340px; height: 37px; text-align: left">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/seta_estoque.jpg"></asp:Image>
                            <asp:Label ID="lblNome" runat="server" SkinID="labelTitulo"></asp:Label>
                        </div>
                        <div style="width: 340px; height: 22px; text-align: left">
                            <asp:Label ID="Label1" runat="server" SkinID="labelSubTitulo" Text="Endereço"></asp:Label>
                        </div>
                        <div style="padding-left: 7px; width: 332px; height: 59px; text-align: left">
                            <asp:Label ID="lblEndereco" runat="server" Text="Label"></asp:Label><br />
                            <asp:Label ID="lblCidade" runat="server"></asp:Label>
                        </div>
                        <div style="width: 340px; height: 23px; text-align: left">
                            <asp:Label ID="Label4" runat="server" SkinID="labelSubTitulo" Text="Telefone"></asp:Label>
                        </div>
                        <div style="padding-left: 7px; width: 333px; height: 41px; text-align: left">
                            <asp:Label ID="lblTelefone1" runat="server" Text="Label"></asp:Label><br />
                            <asp:Label ID="lblTelefone2" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div style="width: 340px; height: 23px; text-align: left">
                            <asp:Label ID="Label3" runat="server" SkinID="labelSubTitulo" Text="E-Mail"></asp:Label>
                        </div>
                        <div style="padding-left: 7px; width: 333px; height: 50px; text-align: left">
                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br/>
                            <asp:Label ID="lblEmail2" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div style="width: 340px; height: 23px; text-align: left">
                            <asp:Label ID="Label5" runat="server" SkinID="labelSubTitulo" Text="Site"></asp:Label>
                        </div>
                        <div style="padding-left: 7px; width: 332px; height: 30px; text-align: left">
                            <asp:HyperLink ID="hplkSite" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                        </div>
                        
                        <div ID="Div1" runat="server" 
                            style="height: auto; text-align: left; width: 335px; padding-left: 5px;">
                                
                            <asp:Label ID="lblObservacao" runat="server" Font-Names="Verdana"  
                                Text='<%# Eval("observacao") %>' Width="330px"></asp:Label>
                        </div>
                        
                        <div style="width: 366px; height: 35px; text-align: center; padding-top: 12px; background-color:White">
                            <asp:ImageButton ID="ibtnEstoque" runat="server" 
                                ImageUrl="~/imagens/botao_estoque.jpg" OnClick="ibtnEstoque_Click" />&nbsp;<asp:ImageButton 
                                ID="ibtnPromocao" runat="server" ImageUrl="~/imagens/promocao.jpg"
                                OnClick="ibtnPromocao_Click"></asp:ImageButton>&nbsp;<asp:ImageButton 
                                ID="ibtnLancamento" runat="server" ImageUrl="~/imagens/lancamentos.jpg" 
                                onclick="ibtnLancamento_Click" />&nbsp;<asp:ImageButton ID="ibtnFecharDetalhes" runat="server" ImageUrl="~/imagens/botao_fechar.jpg">
                            </asp:ImageButton>
                            
                        </div>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
