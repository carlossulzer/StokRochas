<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucEspMedDim.ascx.cs" Inherits="WucAdmin_WucEspMedDim" %>
 
 
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
<asp:View ID="View1" runat="server" >
        <div style="border-right: black 1px solid; border-top: black 1px solid; margin-top: 15px;
            border-left: black 1px solid; width: 629px; border-bottom: black 1px solid; height: 354px;
            background-color: white" id="DIV5" visible="true">
            <div id="divTopo" style="width: 628px; border-bottom: black 1px solid;
                height: 24px; background-color: #ffcc33; text-align: center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="18px" 
                    Text="Espessuras / Medidas / Dimensões"></asp:Label></div>
            <div style="width: 628px; height: 98px">
                <div style="padding-left: 7px; float: left; width: 340px; padding-top: 10px; height: 85px;
                    text-align: left;">
                    <asp:Label ID="Label9" runat="server" 
                        Text="Descrição da Espessura / Medida / Dimensão"></asp:Label>
                    <asp:TextBox ID="txtConsulta" runat="server" Width="321px" TabIndex="1"></asp:TextBox>&nbsp;<br />
                    <div style="width: 318px; height: 25px">
                    <asp:RadioButton ID="rbtIniciando" runat="server" Checked="True" GroupName="grpConsulta"
                        Text="Iniciando" Width="77px" />
                    <asp:RadioButton ID="rbtContendo" runat="server" GroupName="grpConsulta" Text="Contendo" />
                    <asp:RadioButton ID="rbtTerminando" runat="server" GroupName="grpConsulta" Text="Terminando" /></div>
                </div>
                <div style="float: right; width: 273px; height: 85px; padding-left: 5px; padding-top: 30px;"
                    id="DIV1">
                    <asp:ImageButton ID="ibtnConsultar" runat="server" ImageUrl="~/imagens/Pesquisar.png"
                        ToolTip="Consultar" OnClick="ibtnConsultar_Click" TabIndex="2" />
                    <asp:ImageButton ID="ibtnNovo" runat="server" ImageUrl="~/Imagens/Novo.png" OnClick="ibtnNovo_Click"
                        ToolTip="Novo" TabIndex="3" />
                    <asp:ImageButton ID="ibtnSair" runat="server" ImageUrl="~/Imagens/Sair.jpg" OnClick="ibtnSair_Click"
                        ToolTip="Sair" TabIndex="4" /></div>
            </div>
            <div id="divPesquisa" style="border-top: black 1px solid; width: 628px; padding-top: 10px;
                height: 189px; text-align: center">
                <asp:GridView ID="grvEspessuras" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False"
                    EmptyDataText="Pressione o botão novo para cadastrar uma espessura" Width="628px"
                    OnRowDataBound="grvEspessuras_RowDataBound" DataKeyNames="CodEspessura,CodTipo" 
                    TabIndex="5" ForeColor="Black" Height="1px" AllowPaging="True" 
                    OnPageIndexChanging="grvEspessuras_PageIndexChanging" PageSize="5">
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
                        <asp:BoundField DataField="codEspessura" HeaderText="C&#243;digo" Visible="False" />
                        <asp:BoundField DataField="DescEspessura" 
                            HeaderText="Descrição da Espessura / Medida / Dimensões">
                            <ItemStyle Width="330px" Wrap="False" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DescTipo" HeaderText="Tipo de Produto" />
                        <asp:BoundField DataField="codTipo" HeaderText="Codigo Tipo" Visible="False" />
                    </Columns>
                </asp:GridView>
                &nbsp;</div>
        </div>
    </asp:View>
     <asp:View ID="View2" runat="server">
        <div style="border-right: black 1px solid; border-top: black 1px solid; margin-top: 15px;
            border-left: black 1px solid; width: 629px; border-bottom: black 1px solid; height: 213px;
            background-color: white" id="DIV4" visible="true">
            <div id="Div2" style="width: 608px; border-bottom: black 1px solid;
                height: 24px; background-color: #ffcc33; text-align: center">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="18px" 
                    Text="Espessuras / Medidas / Dimensões"></asp:Label></div>
            <div style="width: 607px; height: 89px">
                <table style="width: 597px; height: 76px; background-color: white" id="tblEspessuras"
                    runat="server" visible="true">
                    <tr>
                        <td>
                        </td>
                        <td style="text-align: right;" >
                        </td>
                        <td>
                        </td>
                        <td style="width: 25px; height: 18px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="text-align: right" >
                            Descrição da Espessura / Medida / Dimensão</td>
                        <td style="text-align: left" >
                            <asp:TextBox ID="txtDescEspessura" runat="server" MaxLength="15" TabIndex="101" 
                                Width="211px"></asp:TextBox></td>
                        <td style="width: 25px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="text-align: right">
                            Tipo de Produto</td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlTipoProduto" runat="server" Height="22px" 
                                TabIndex="102" Width="258px">
                            </asp:DropDownList>
                        </td>
                        <td>
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
