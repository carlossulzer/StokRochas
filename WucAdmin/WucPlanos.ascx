<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucPlanos.ascx.cs" Inherits="WucPlanos" %>
    
<%@ Register assembly="WebCtrlMascara" namespace="WebCtrlMascara" tagprefix="cc1" %>

    
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <div style="width: 606px; border: 1px solid #000000; height: 500px; border-style: solid; border-width: 1px; border-color: #000000; margin-top:10px">
            <div ID="divTopo" style="width: 605px; border-bottom: black 1px solid;
                height: 24px; background-color: #ffcc33; text-align: center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="18px" 
                    Text="Planos"></asp:Label>
            </div>            
            <div style="border-bottom: 1px solid #000000; width: 603px; height: 71px; ">
                <div ID="DIV5" 
                    
                    style="float: right; width: 82px; height: 64px; padding-left: 5px; padding-top: 20px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagens/Novo.png" 
                        OnClick="ibtnNovo_Click" TabIndex="3" ToolTip="Novo" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/Sair.jpg" 
                        OnClick="ibtnSair_Click" TabIndex="4" ToolTip="Sair" />
                </div>
            </div>
            <div ID="divPesquisa" style="width: 604px; padding-top: 10px;
                height: 500px; text-align: center">
                <asp:GridView ID="grvPlano" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="CodPlano" 
                    EmptyDataText="Pressione o botão novo para cadastrar um plano" 
                    ForeColor="Black" GridLines="Vertical" Height="1px" 
                    OnRowDataBound="grvPlano_RowDataBound" PageSize="12" TabIndex="5" 
                    Width="595px" onselectedindexchanged="grvPlano_SelectedIndexChanged">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnSelecionar" runat="server" 
                                    ImageUrl="~/Imagens/Detalhe.png" OnClick="ibtnSelecionar_Click" 
                                    ToolTip="Detalhes" />
                            </ItemTemplate>
                            <ItemStyle Width="18px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnAlterar" runat="server" 
                                    ImageUrl="~/Imagens/alterar.gif" OnClick="ibtnAlterar_Click" 
                                    ToolTip="Alterar" />
                            </ItemTemplate>
                            <ItemStyle Width="18px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnExcluir" runat="server" 
                                    ImageUrl="~/Imagens/excluir.gif" OnClick="ibtnExcluir_Click" 
                                    ToolTip="Excluir" />
                            </ItemTemplate>
                            <ItemStyle Width="18px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codCatgoria" HeaderText="Código" Visible="False" />
                        <asp:BoundField DataField="de" HeaderText="De">
                            <ItemStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ate" HeaderText="Até">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="valor" HeaderText="Valor R$" 
                            DataFormatString="{0:c}">
                            <ItemStyle Width="250px" HorizontalAlign="Center" />
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
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="18px" 
                    Text="Planos"></asp:Label></div>
            <div style="width: 607px; height: 123px">
                <table style="width: 597px; height: 101px; background-color: white" id="tblPlanos"
                    runat="server" visible="true">
                    <tr>
                        <td style="width: 25px; height: 18px;">
                        </td>
                        <td style="width: 147px; text-align: right; height: 18px;">
                        </td>
                        <td>
                        </td>
                        <td style="width: 25px; height: 18px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25px">
                        </td>
                        <td style="width: 147px; text-align: right">
                            De</td>
                        <td style="text-align: left">
                            <cc1:MascaraEntrada ID="txtDe" runat="server" MaxLength="4" 
                                style="margin-left: 0px" TabIndex="101" Width="54px"></cc1:MascaraEntrada>
                        </td>
                        <td style="width: 25px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25px">
                            &nbsp;</td>
                        <td style="width: 147px; text-align: right">
                            Até</td>
                        <td class="style2" style="text-align: left">
                            <cc1:MascaraEntrada ID="txtAte" runat="server" MaxLength="4" TabIndex="102" 
                                Width="54px"></cc1:MascaraEntrada>
                        </td>
                        <td style="width: 25px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 25px">
                            &nbsp;</td>
                        <td style="width: 147px; text-align: right">
                            Valor R$</td>
                        <td class="style2" style="text-align: left">
                            <cc1:MascaraEntrada ID="txtValor" runat="server" Mascara="VALOR" TabIndex="103"></cc1:MascaraEntrada>
                        </td>
                        <td style="width: 25px">
                            &nbsp;</td>
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

