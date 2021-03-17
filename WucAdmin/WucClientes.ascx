<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucClientes.ascx.cs" Inherits="WucClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxKit" %>
<%@ Register Assembly="WebCtrlMascara" Namespace="WebCtrlMascara" TagPrefix="cc1" %>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <div style="border-right: black 1px solid; border-top: black 1px solid; margin-top: 15px;
            border-left: black 1px solid; width: 956px; border-bottom: black 1px solid; height: 354px;
            background-color: white" id="DIV5" visible="true">
            <div id="divTopo" style="width: 100%; border-bottom: black 1px solid; height: 24px;
                background-color: #ffcc33; text-align: center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="18px" Text="Clientes"></asp:Label></div>
            <div style="width: 950px; height: 82px">
                <div style="padding-left: 7px; float: left; width: 501px; padding-top: 10px; height: 69px;
                    text-align: left;">
                    <asp:Label ID="Label9" runat="server" Text="Nome Fantasia do Cliente"></asp:Label>
                    <asp:TextBox ID="txtConsulta" runat="server" Width="321px" TabIndex="1"></asp:TextBox>&nbsp;<br />
                    <div style="width: 481px; padding-top: 8px; height: 20px">
                        <asp:RadioButton ID="rbtIniciando" runat="server" Checked="True" GroupName="grpConsulta"
                            Text="Iniciando" Width="77px" />
                        <asp:RadioButton ID="rbtContendo" runat="server" GroupName="grpConsulta" Text="Contendo" />
                        <asp:RadioButton ID="rbtTerminando" runat="server" GroupName="grpConsulta" Text="Terminando" /></div>
                </div>
                <div style="float: right; width: 382px; height: 64px; padding-left: 5px; padding-top: 20px;"
                    id="DIV1">
                    <asp:ImageButton ID="ibtnConsultar" runat="server" ImageUrl="~/imagens/Pesquisar.png"
                        ToolTip="Consultar" OnClick="ibtnConsultar_Click" TabIndex="2" />
                    <asp:ImageButton ID="ibtnNovo" runat="server" ImageUrl="~/Imagens/Novo.png" OnClick="ibtnNovo_Click"
                        ToolTip="Novo" TabIndex="3" />
                    <asp:ImageButton ID="ibtnSair" runat="server" ImageUrl="~/Imagens/Sair.jpg" OnClick="ibtnSair_Click"
                        ToolTip="Sair" TabIndex="4" /></div>
            </div>
            <div id="divPesquisa" style="border-top: black 1px solid; width: 950px; padding-top: 10px;
                height: 189px; text-align: center">
                <asp:GridView ID="grvClientes" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False"
                    EmptyDataText="Pressione o botão novo para cadastrar um cliente" Width="933px"
                    OnRowDataBound="grvClientes_RowDataBound" DataKeyNames="CodCliente" TabIndex="5"
                    ForeColor="Black" Height="1px" AllowPaging="True" OnPageIndexChanging="grvClientes_PageIndexChanging" PageSize="7">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnSelecionar" runat="server" OnClick="ibtnSelecionar_Click"
                                    ImageUrl="~/Imagens/Detalhe.png" ToolTip="Detalhes" />
                            </ItemTemplate>
                            <ItemStyle Width="18px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnAlterar" runat="server" ImageUrl="~/Imagens/alterar.gif"
                                    OnClick="ibtnAlterar_Click" ToolTip="Alterar" />
                            </ItemTemplate>
                            <ItemStyle Width="18px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnExcluir" runat="server" ImageUrl="~/Imagens/excluir.gif"
                                    OnClick="ibtnExcluir_Click" ToolTip="Excluir" />
                            </ItemTemplate>
                            <ItemStyle Width="18px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codCliente" HeaderText="C&#243;digo" >
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NomeFantasia" HeaderText="Nome Fantasia do Cliente">
                            <ItemStyle Width="320px" Wrap="False" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CNPJ" HeaderText="CNPJ">
                            <ItemStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Telefone1" HeaderText="Telefone (1)">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Telefone2" HeaderText="Telefone (2)">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
             </div>
        </div>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <div style="width: 959px; height: 935px; text-align: center;">
            <div id="Div2" style="width: 956px; height: 24px; background-color: #ffcc33; text-align: center;
                border-right: black 1px solid; border-top: black 1px solid; margin-top: 15px;
                border-left: black 1px solid;">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="18px" Text="Clientes"></asp:Label>
            </div>
            <div style="border: 1px solid black; width: 956px; height: 894px; background-color: white;" id="DIV4" visible="true">
                <div style="width: 914px; height: 610px">
                    <table style="width: 910px; height: 387px; background-color: white" id="tblClientes"
                        runat="server" visible="true">
                        <tr>
                            <td style="width: 370px; text-align: right; height: 18px;">
                            </td>
                            <td style="width: 515px; height: 18px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 26px; text-align: right">
                                Razao Social</td>
                            <td style="width: 515px; height: 26px; text-align: left">
                                <asp:TextBox ID="txtRazaoSocial" runat="server" TabIndex="101" Width="347px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; text-align: right; height: 26px;">
                                Nome Fantasia</td>
                            <td style="width: 515px; text-align: left; height: 26px;">
                                <asp:TextBox ID="txtNomeFantasia" runat="server" MaxLength="80" TabIndex="102" Width="348px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right;">
                                CNPJ</td>
                            <td style="width: 515px; height: 8px; text-align: left;">
                                <cc1:MascaraEntrada ID="txtCnpj" runat="server" Mascara="CNPJ" TabIndex="103" CssClass="caixaAlta"></cc1:MascaraEntrada></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                E-Mail (1)</td>
                            <td style="width: 515px; height: 8px; text-align: left;">
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="80" TabIndex="104" Width="348px"
                                    SkinID="CaixaBaixa"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                E-Mail (2)</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <asp:TextBox ID="txtEmail2" runat="server" MaxLength="80" SkinID="CaixaBaixa" 
                                    TabIndex="105" Width="348px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Site</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <asp:TextBox ID="txtSite" runat="server" MaxLength="80" SkinID="CaixaBaixa" 
                                    TabIndex="109" Width="348px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Logotipo</td>
                            <td style="width: 515px; height: 8px; text-align: left" valign="bottom">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtLogotipo" runat="server" Width="478px" MaxLength="80" SkinID="CaixaBaixa"
                                            TabIndex="105"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnLogotipo" runat="server" ImageUrl="~/imagens/search.gif"
                                            ImageAlign="AbsMiddle" />
                                        <AjaxKit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="popup"
                                            PopupControlID="pnlLogotipo" TargetControlID="ibtnLogotipo" CancelControlID="ibtnCancelarLogo"></AjaxKit:ModalPopupExtender>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ibtnConfirmarLogo" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Telefone (1)</td>
                            <td style="width: 515px; height: 8px; text-align: left;">
                                <cc1:MascaraEntrada ID="txtTelefone1" runat="server" Mascara="TELEFONE" TabIndex="107"
                                    CssClass="caixaAlta"></cc1:MascaraEntrada></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Telefone (2)</td>
                            <td style="width: 515px; height: 8px; text-align: left;">
                                <cc1:MascaraEntrada ID="txtTelefone2" runat="server" Mascara="TELEFONE" TabIndex="108"
                                    CssClass="caixaAlta"></cc1:MascaraEntrada></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Cliente Ativo</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <div style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                    width: 164px; border-bottom: black 1px solid; height: 23px">
                                    &nbsp;<asp:RadioButton ID="rbtAtivoSim" runat="server" Checked="True" GroupName="grpAtivo"
                                        Text="Sim" />
                                    <asp:RadioButton ID="rbtAtivoNao" runat="server" GroupName="grpAtivo" Text="Não" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Login do Cliente</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <asp:TextBox ID="txtLogin" runat="server" TabIndex="110" MaxLength="15" CssClass="caixaAlta"
                                    Width="162px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Anúncio</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <div style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                    width: 164px; border-bottom: black 1px solid; height: 23px">
                                    <asp:RadioButton ID="rbtAnuncioSim" runat="server" GroupName="grpAnuncio" Text="Sim" />
                                    <asp:RadioButton ID="rbtAnuncioNao" runat="server" Checked="True" GroupName="grpAnuncio"
                                        Text="Não" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Validade&nbsp; do Anúncio</td>
                            <td style="width: 515px; height: 8px; text-align: left; margin-left: 80px;">
                                <cc1:MascaraEntrada ID="txtValidade" runat="server" Mascara="DATA" TabIndex="111"
                                    CssClass="caixaAlta"></cc1:MascaraEntrada></td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Movimenta Estoque</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <div style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                    width: 164px; border-bottom: black 1px solid; height: 23px">
                                    <asp:RadioButton ID="rbtMovEstoqueSim" runat="server" GroupName="grpAnuncio" Text="Sim" />
                                    <asp:RadioButton ID="rbtMovEstoqueNao" runat="server" Checked="True" GroupName="grpAnuncio"
                                        Text="Não" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Categoria</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <asp:DropDownList ID="ddlCategoria" runat="server" TabIndex="113" Width="273px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Quantidade de Produtos</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <asp:DropDownList ID="ddlPlano" runat="server" TabIndex="115" 
                                    Width="273px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 370px; height: 8px; text-align: right">
                                Nº de Produtos Para Promoção</td>
                            <td style="width: 515px; height: 8px; text-align: left">
                                <cc1:MascaraEntrada ID="txtProdPromocao" runat="server" MaxLength="4" 
                                    Width="80px">  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </cc1:MascaraEntrada>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 370px; height: 8px;">
                                Nº de Produtos Para Lançamento</td>
                            <td style="text-align: left; width: 515px; height: 8px;">
                                <cc1:MascaraEntrada ID="txtProdLancamento" runat="server" MaxLength="4" 
                                    Width="80px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </cc1:MascaraEntrada>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; vertical-align: top;">
                                Observações</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtObservacoes" runat="server" Height="76px" MaxLength="200" 
                                    TabIndex="116" TextMode="MultiLine" Width="507px" Columns="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 9px; text-align: center;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div style="width: 450px; height: 1200px">
                                            <AjaxKit:TabContainer ID="tbcEndereco" runat="server" ActiveTabIndex="1" 
                                                Height="206px" Style="margin-top: 25px" Width="119%">
                                                <AjaxKit:TabPanel ID="TbpComercial" runat="server" 
                                                    HeaderText="Endereço Comercial">
                                                    <ContentTemplate>
                                                        <table style="width: 100%; height: 115px">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 120px; height: 26px; text-align: right">
                                                                        Endereço</td>
                                                                    <td style="width: 400px; height: 26px; text-align: left">
                                                                        <asp:TextBox ID="txtEnderecoCom" runat="server" MaxLength="100" TabIndex="121" 
                                                                            Width="348px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px; height: 26px; text-align: right">
                                                                        Bairro</td>
                                                                    <td style="width: 400px; height: 26px; text-align: left">
                                                                        <asp:TextBox ID="txtBairroCom" runat="server" MaxLength="60" TabIndex="122" 
                                                                            Width="348px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px; height: 26px; text-align: right">
                                                                        Cidade</td>
                                                                    <td style="width: 400px; height: 26px; text-align: left">
                                                                        <asp:TextBox ID="txtCidadeCom" runat="server" MaxLength="60" TabIndex="123" 
                                                                            Width="348px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px; height: 26px; text-align: right">
                                                                        Estado</td>
                                                                    <td style="width: 400px; height: 26px; text-align: left">
                                                                        <asp:DropDownList ID="ddlEstadosCom" runat="server" TabIndex="124" 
                                                                            Width="305px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px; height: 26px; text-align: right">
                                                                        Cep</td>
                                                                    <td style="width: 400px; height: 26px; text-align: left">
                                                                        <cc1:MascaraEntrada ID="txtCepCom" runat="server" CssClass="caixaAlta" 
                                                                            Mascara="CEP" TabIndex="125" Width="135px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </cc1:MascaraEntrada>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                </AjaxKit:TabPanel>
                                                <AjaxKit:TabPanel ID="TbpCobranca" runat="server" 
                                                    HeaderText="Endereço de Cobrança">
                                                    <HeaderTemplate>
                                                        Endereço de Cobrança
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%; height: 152px;">
                                                            <tr>
                                                                <td style="text-align: right; width: 120px; height: 26px;">
                                                                    Endereço
                                                                </td>
                                                                <td style="width: 400px; text-align: left; height: 26px;">
                                                                    <asp:TextBox ID="txtEnderecoCob" runat="server" MaxLength="100" TabIndex="131" 
                                                                        Width="348px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right; width: 120px; height: 25px;">
                                                                    Bairro
                                                                </td>
                                                                <td style="width: 400px; text-align: left; height: 25px;">
                                                                    <asp:TextBox ID="txtBairroCob" runat="server" MaxLength="60" TabIndex="132" 
                                                                        Width="348px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right; width: 120px; height: 26px;">
                                                                    Cidade
                                                                </td>
                                                                <td style="width: 400px; text-align: left; height: 26px;">
                                                                    <asp:TextBox ID="txtCidadeCob" runat="server" MaxLength="60" TabIndex="133" 
                                                                        Width="348px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 120px; height: 26px; text-align: right">
                                                                    Estado</td>
                                                                <td style="width: 400px; height: 26px; text-align: left">
                                                                    <asp:DropDownList ID="ddlEstadosCob" runat="server" TabIndex="134" 
                                                                        Width="305px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right; width: 120px; height: 26px;">
                                                                    Cep
                                                                </td>
                                                                <td style="width: 400px; text-align: left; height: 26px;">
                                                                    <cc1:MascaraEntrada ID="txtCepCob" runat="server" CssClass="caixaAlta" 
                                                                        Mascara="CEP" TabIndex="135" Width="135px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    </cc1:MascaraEntrada>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="border-top: black 1px; border-right-style: none; border-left-style: none;
                                                                    height: 5px; text-align: center; border-bottom-style: none">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="height: 40px; text-align: center; border-top: black 1px solid;
                                                                    padding-top: 4px;">
                                                                    <asp:Button ID="btnCopiar" runat="server" OnClick="btnCopiar_Click" 
                                                                        Text="Copiar Endereço" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </AjaxKit:TabPanel>
                                            </AjaxKit:TabContainer>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 710px; height: 154px">
                <asp:Panel ID="pnlLogotipo" runat="server" BackColor="#FFCC33" Height="197px" Width="710px">
                    <div style="width: 710px; padding-top: 4px; height: 21px; background-color: gray;
                        text-align: center">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="Selecione a Imagem"></asp:Label>
                    </div>
                    <div style="padding-right: 10px; padding-left: 10px; width: 694px; padding-top: 20px;
                        height: 40px">
                        O arquivo deverá estar no formato .Gif devido ao seu tamanho, sua dimensão deverá
                        ser 90px(altura) X 200px (largura), e o tamanho do arquivo não poderá ultrapassar
                        os 500 kb.</div>
                    <div style="padding-right: 5px; padding-left: 10px; padding-bottom: 10px; width: 710px;
                        padding-top: 10px; height: 29px">
                        &nbsp;<asp:FileUpload ID="fuplLogotipo" runat="server" Width="512px" /></div>
                    <div style="width: 710px; height: 40px; text-align: center">
                        <asp:ImageButton ID="ibtnConfirmarLogo" runat="server" ImageUrl="~/Imagens/Confirmar.png"
                            OnClick="ibtnConfirmarLogo_Click" />&nbsp;
                        <asp:ImageButton ID="ibtnCancelarLogo" runat="server" ImageUrl="~/Imagens/Cancelar.png" /></div>
                </asp:Panel>
            </div>
        </div>
        <div id="Div3" style="border-top: black 1px solid; width: 956px; padding-top: 10px;
            height: 52px; text-align: center; border-right: black 1px solid; border-left: black 1px solid;
            border-bottom: black 1px solid;">
            <asp:ImageButton ID="ibtnConfirmar" runat="server" 
                ImageUrl="~/Imagens/Confirmar.png" ToolTip="Confirmar" TabIndex="141" 
                onclick="ibtnConfirmar_Click" />&nbsp;
            <asp:ImageButton ID="ibtnCancelar" runat="server" ImageUrl="~/Imagens/Cancelar.png"
                OnClick="ibtnCancelar_Click" ToolTip="Cancelar" TabIndex="142" 
                Width="32px" />&nbsp;
            <asp:ImageButton ID="ibtnVoltar" runat="server" ImageUrl="~/Imagens/voltar.png" OnClick="ImageButton1_Click"
                TabIndex="143" ToolTip="Voltar" />
        </div>
    </asp:View>
</asp:MultiView>
