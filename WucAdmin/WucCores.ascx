<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucCores.ascx.cs" Inherits="WucCores" %>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <div style="border-right: black 1px solid; border-top: black 1px solid; margin-top: 15px;
            border-left: black 1px solid; width: 611px; border-bottom: black 1px solid; height: 354px;
            background-color: white" id="DIV5" visible="true">
            <div id="divTopo" style="width: 608px; border-bottom: black 1px solid;
                height: 24px; background-color: #ffcc33; text-align: center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="18px" Text="Cores"></asp:Label></div>
            <div style="width: 562px; height: 115px">
                <div style="padding-left: 7px; float: left; width: 340px; padding-top: 10px; height: 114px;
                    text-align: left;">
                    <asp:Label ID="Label9" runat="server" Text="Nome da Cor"></asp:Label>
                    <asp:TextBox ID="txtConsulta" runat="server" Width="321px" TabIndex="1"></asp:TextBox>&nbsp;<br />
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 325px; height: 42px">
                        <tr>
                            <td style="width: 100px">
                    <asp:RadioButton ID="rbtIniciando" runat="server" Checked="True" GroupName="grpConsulta"
                        Text="Iniciando" Width="77px" /></td>
                            <td style="width: 100px">
                    <asp:RadioButton ID="rbtContendo" runat="server" GroupName="grpConsulta" Text="Contendo" /></td>
                            <td style="width: 100px">
                    <asp:RadioButton ID="rbtTerminando" runat="server" GroupName="grpConsulta" Text="Terminando" /></td>
                        </tr>
                        <tr>
                            <td style="border-top: black 1px solid; width: 100px">
                                <asp:RadioButton ID="rbtnPortugues" runat="server" Checked="True" Text="Português" GroupName="grpIdioma" /></td>
                            <td style="border-top: black 1px solid; width: 100px">
                                <asp:RadioButton ID="rbtnIngles" runat="server" Text="Inglês" GroupName="grpIdioma" /></td>
                            <td style="border-top: black 1px solid; width: 100px">
                                <asp:RadioButton ID="rbtnEspanhol" runat="server" Text="Espanhol" GroupName="grpIdioma" /></td>
                        </tr>
                    </table>
                </div>
                <div style="float: right; width: 210px; height: 85px; padding-left: 5px; padding-top: 30px;"
                    id="DIV1">
                    <asp:ImageButton ID="ibtnConsultar" runat="server" ImageUrl="~/imagens/Pesquisar.png"
                        ToolTip="Consultar" OnClick="ibtnConsultar_Click" TabIndex="2" />
                    <asp:ImageButton ID="ibtnNovo" runat="server" ImageUrl="~/Imagens/Novo.png" OnClick="ibtnNovo_Click"
                        ToolTip="Novo" TabIndex="3" />
                    <asp:ImageButton ID="ibtnSair" runat="server" ImageUrl="~/Imagens/Sair.jpg" OnClick="ibtnSair_Click"
                        ToolTip="Sair" TabIndex="4" /></div>
            </div>
            <div id="divPesquisa" style="border-top: black 1px solid; width: 607px; padding-top: 10px;
                height: 189px; text-align: center">
                <asp:GridView ID="grvCores" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False"
                    EmptyDataText="Pressione o botão novo para cadastrar uma cor" Width="595px"
                    OnRowDataBound="grvCores_RowDataBound" DataKeyNames="CodCor" TabIndex="5" ForeColor="Black" Height="1px" AllowPaging="True" HorizontalAlign="Center" OnPageIndexChanging="grvCores_PageIndexChanging" PageSize="5">
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
                        <asp:BoundField DataField="codCor" HeaderText="C&#243;digo" Visible="False" />
                        <asp:BoundField DataField="NomeCorPor" HeaderText="Nome (Portugu&#234;s)">
                            <ItemStyle Width="150px" Wrap="False" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NomeCorIng" HeaderText="Nome (Ingl&#234;s)">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NomeCorEsp" HeaderText="Nome (Espanhol)">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                &nbsp;</div>
        </div>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <div style="border-right: black 1px solid; border-top: black 1px solid; margin-top: 15px;
            border-left: black 1px solid; width: 611px; border-bottom: black 1px solid; height: 213px;
            background-color: white" id="DIV4" visible="true">
            <div id="Div2" style="width: 608px; border-bottom: black 1px solid;
                height: 24px; background-color: #ffcc33; text-align: center">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="18px" Text="Cores"></asp:Label></div>
            <div style="width: 607px; height: 119px">
                <table style="width: 604px; height: 60px; background-color: white" id="tblCores"
                    runat="server" visible="true">
                    <tr>
                        <td style="width: 25px; height: 18px;">
                        </td>
                        <td style="width: 222px; text-align: right; height: 18px;">
                        </td>
                        <td style="width: 236px; height: 18px;">
                        </td>
                        <td style="width: 27px; height: 18px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25px">
                        </td>
                        <td style="width: 222px; text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Nome da Cor (Português)" Width="181px"></asp:Label></td>
                        <td style="width: 236px; text-align: left">
                            <asp:TextBox ID="txtNomePor" runat="server" MaxLength="15" TabIndex="101" Width="232px"></asp:TextBox></td>
                        <td style="width: 27px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25px; height: 8px;">
                        </td>
                        <td style="width: 222px; height: 8px; text-align: right;">
                            <asp:Label ID="Label2" runat="server" Text="Nome da Cor (Inglês)" Width="183px"></asp:Label></td>
                        <td style="width: 236px; height: 8px;">
                            <asp:TextBox ID="txtNomeIng" runat="server" MaxLength="15" TabIndex="102" Width="232px"></asp:TextBox></td>
                        <td style="width: 27px; height: 8px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25px; height: 8px">
                        </td>
                        <td style="width: 222px; height: 8px; text-align: right">
                            <asp:Label ID="Label3" runat="server" Text="Nome da Cor (Espanhol)" Width="183px"></asp:Label></td>
                        <td style="width: 236px; height: 8px">
                            <asp:TextBox ID="txtNomeEsp" runat="server" MaxLength="15" TabIndex="103" Width="232px"></asp:TextBox></td>
                        <td style="width: 27px; height: 8px">
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div3" style="border-top: black 1px solid; width: 605px; padding-top: 10px;
                height: 52px; text-align: center">
                <asp:ImageButton ID="ibtnConfirmar" runat="server" ImageUrl="~/Imagens/Confirmar.png"
                    OnClick="ibtnConfirmar_Click" ToolTip="Confirmar" TabIndex="104" />&nbsp;
                <asp:ImageButton ID="ibtnCancelar" runat="server" ImageUrl="~/Imagens/Cancelar.png"
                    OnClick="ibtnCancelar_Click" ToolTip="Cancelar" TabIndex="105" />&nbsp;
                <asp:ImageButton ID="ibtnVoltar" runat="server" ImageUrl="~/Imagens/voltar.png" OnClick="ImageButton1_Click" TabIndex="106" ToolTip="Voltar" />&nbsp;
            </div>
        </div>
    </asp:View>
</asp:MultiView>
<%--  </ContentTemplate>
</asp:UpdatePanel>
--%>
