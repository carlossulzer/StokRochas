<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="frmSejaUmParceiro.aspx.cs" Inherits="frmSejaUmParceiro" Title=":: Stok Rochas - Seja Um Parceiro ::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="parceria_form">
        <div class="parceria_topo">
            <div class="parceria_titulo_imagen">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" />
            </div>
            <div class="parceria_titulo_texto">
                <asp:Label ID="Label2" runat="server" Text="SEJA UM PARCEIRO" 
                    SkinID="labelTitulo"></asp:Label>
            </div>
        </div>
        <div class="parceria_texto">
            <span style="font-size: 11px; font-family: Verdana">Stok Rochas é uma ferramenta de
                busca, que permite maior interação entre clientes e fornecedores, fomentando ainda
                mais os mercados de contrução civil, arquitetura e a relação de comércio entre as
                empresas do setor de rochas ornamentais. </span>
            <p style="text-align: justify">
                <span style="font-size: 11px; font-family: Verdana">Com esta ferramenta você pode publicar
                    na WEB o estoque de blocos, chapas e ladrilhos da sua empresa. </span>
            </p>
            <p style="text-align: justify">
                <span style="font-size: 11px; font-family: Verdana">Nossos servidores são constantemente
                    atualizados com base nas informações fornecidas por nossos parceiros, dessa forma
                    conseguimos manter o seu estoque sempre on-line e proporcionar novas oportunidades
                    de negocios. </span>
            </p>
            <p style="text-align: justify">
                <span style="font-size: 11px; font-family: Verdana">Empresas que não possuem programas
                    de controle de estoque, poderão cadastrar e gerenciar seu estoque através de uma
                    ferramenta desenvolvida pela Stok Rochas, e as que já o possuem, poderão disponibilizar
                    seus produtos e estoques de forma rápida e dinâmica.</span></p>
            <p style="text-align: justify">
                <span style="font-size: 11px; font-family: Verdana">Clique e conheça nossos planos ai
                    ao lado! </span>
            </p>
            <p style="text-align: justify">
                <span style="font-size: 11px; font-family: Verdana">Esteja on-line venha para o Stok
                    Rochas, agende uma visita.</span></p>
            <p style="text-align: center">
                <span style="color: dimgray; font-family: Verdana; font-size: 11px;"><strong>Venha hospedar
                    seu estoque em nosso portal!<br />
                    Seus clientes vão adorar essa facilidade.</strong></span></p>
        </div>
        <div class="parceria_logo_investimento">
            <div class="parceria_separacao">
            </div> 
                       
            <asp:Image ID="ImageButton1" runat="server" ImageUrl="~/imagens/TipoPlano.gif" />

            <div class="parceria_separacao">
            </div>            
            
            <asp:ImageButton ID="ibtnSemSistema" runat="server" ImageUrl="~/imagens/parceiro_2.jpg" />
            <div class="parceria_separacao">
            </div>
            <asp:ImageButton ID="ibtnComSistema" runat="server" ImageUrl="~/imagens/parceiro_3.jpg" /></div>
        <div class="parceria_telefone">
            <span style="color: #ff9900; font-family: Verdana; font-size: 13px;"><strong>Telefone (28) 3518-6666</strong>
            </span>
        </div>
    </div>
    
    <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="pnlSemSistema2"
        Radius="10" Corners="All">
    </cc1:RoundedCornersExtender>
    
    <asp:Panel ID="pnlSemSistema" runat="server" Width="689px" 
    Style="display: none" Height="202px">
        <asp:Panel ID="pnlSemSistema2" runat="server" Height="201px" Width="687px" 
            BackColor="White">
            <div class="parceria_sem_sistema" style="width: 679px; height:200px">
                <div class="parceria_sem_sistema_topo">
                    <div class="parceria_sem_sistema_imagem">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" />
                    </div>
                    <div class="parceria_sem_sistema_titulo">
                        <asp:Label ID="Label3" runat="server" SkinID="titulo" Text="EMPRESAS SEM SISTEMA DE ESTOQUE">
                        </asp:Label>
                    </div>
                </div>
                <div class="parceria_sem_sistema_texto">
                    <span>Empresas que não possuem um sistema de estoque poderão utilizar o GERENCIADOR
                        STOKROCHAS para cadastrar e disponibilizar seus materiais. O procedimento de envio
                        de dados para a WEB será feito manualmente e disponibilizados para consulta no portal
                        STOK ROCHAS. Dessa forma será possível controlar o seu estoque tanto on-line como
                        off-line a partir do GERENCIADOR. </span>
                </div>
                <div class="parceria_sem_sistema_valor1">
                    <div class="parceria_sem_sistema_valor2">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/imagens/seta_estoque.jpg" />
                    </div>
                    <div class="parceria_sem_sistema_valor3">
                        <span>Valor da implantação: <strong>R$ 300,00</strong> (Trezentos Reais).</span>
                    </div>
                </div>
                <div class="parceria_sem_sistema_fechar" style="width: 674px; float: left;">
                    <asp:ImageButton ID="ibtnFecharSemSistema" runat="server" ImageUrl="~/imagens/botao_fechar.jpg" />
                </div>
            </div>
        </asp:Panel>
    </asp:Panel>
    
    
    <%--<asp:Panel ID="pnlSemSistema" runat="server" Width="713px" 
        Style="display: none" Height="217px">
        <asp:Panel ID="pnlSemSistema2" runat="server" Height="212px" Width="708px" 
            BackColor="White">
            <div class="parceria_sem_sistema" style="width: 682px">
                <div class="parceria_sem_sistema_topo">
                    <div class="parceria_sem_sistema_imagem">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" />
                    </div>
                    <div class="parceria_sem_sistema_titulo">
                        <asp:Label ID="Label3" runat="server" SkinID="titulo" Text="EMPRESAS SEM SISTEMA DE ESTOQUE">
                        </asp:Label>
                    </div>
                </div>
                <div class="parceria_sem_sistema_texto">
                    <span>Empresas que não possuem um sistema de estoque poderão utilizar o GERENCIADOR
                        STOKROCHAS para cadastrar e disponibilizar seus materiais. O procedimento de envio
                        de dados para a WEB será feito manualmente e disponibilizados para consulta no portal
                        STOK ROCHAS. Dessa forma será possível controlar o seu estoque tanto on-line como
                        off-line a partir do GERENCIADOR. </span>
                </div>
                <div class="parceria_sem_sistema_valor1">
                    <div class="parceria_sem_sistema_valor2">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/imagens/seta_estoque.jpg" />
                    </div>
                    <div class="parceria_sem_sistema_valor3">
                        <span>Valor da implantação: <strong>R$ 300,00</strong> (Trezentos Reais).</span>
                    </div>
                </div>
                <div class="parceria_sem_sistema_fechar" style="width: 688px">
                    <asp:ImageButton ID="ibtnFecharSemSistema" runat="server" ImageUrl="~/imagens/botao_fechar.jpg" />
                </div>
            </div>
        </asp:Panel>
    </asp:Panel>--%>
    
    <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="pnlComSistema2"
        Radius="10" Corners="All">
    </cc1:RoundedCornersExtender>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="popup"
        PopupControlID="pnlSemSistema" TargetControlID="ibtnSemSistema" CancelControlID="ibtnFecharSemSistema">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlComSistema" runat="server" Height="200px" Width="730px" 
    Style="display: none">
        <asp:Panel ID="pnlComSistema2" runat="server" Height="199px" Width="719px" 
            BackColor="White">
            <div class="parceria_com_sistema">

                <span>
                    <div class="parceria_com_sistema_topo">
                        <div class="parceria_com_sistema_imagem">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" /></div>
                        <div class="parceria_com_sistema_titulo">
                            <asp:Label ID="Label4" runat="server" SkinID="titulo" Text="EMPRESAS COM SISTEMA DE ESTOQUE"></asp:Label></div>
                    </div>
                </span>

                <div class="parceria_com_sistema_texto">
                    <span>Empresas que possuem um sistema
                        de estoque poderão utilizar o aplicativo GERENCIADOR STOKROCHAS e atualizar seus
                        dados no portal, para isso os dados devem ser gerados de acordo com o layout pré-definido
                        por nossa equipe. Os materiais serão atualizados e disponibilizados para consulta,
                        mantendo seu estoque sempre atualizado na internet e facilitando a consulta dos
                        interessados.
                    </span>
                </div>
                <div class="parceria_com_sistema_valor1">
                    <div class="parceria_com_sistema_valor2">
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/imagens/seta_estoque.jpg" />
                    </div>
                    <div class="parceria_com_sistema_valor3">
                        <span>Valor da implantação: <strong>R$ 450,00</strong> (Quatrocentos e Cinquenta Reais).</span>
                    </div>
                </div>
                <div class="parceria_com_sistema_fechar">
                    <asp:ImageButton ID="ibtnFecharComSistema" runat="server" ImageUrl="~/imagens/botao_fechar.jpg" />
                </div>
            </div>
        </asp:Panel>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" BackgroundCssClass="popup"
        PopupControlID="pnlComSistema" TargetControlID="ibtnComSistema" CancelControlID="ibtnFecharComSistema">
    </cc1:ModalPopupExtender>
</asp:Content>
