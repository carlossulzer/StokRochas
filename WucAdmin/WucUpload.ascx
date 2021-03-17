<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucUpload.ascx.cs" Inherits="WucAdmin_WucUpload" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<div>
    &nbsp;<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="VIEW1"></asp:Label>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" /></asp:View>
        <asp:View ID="View2" runat="server">
            <asp:Label ID="Label3" runat="server" Text="VIEW2"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" targetcontrolid="Button1"
                popupcontrolid="pnlLogotipo" backgroundcssclass="popup">
                            </cc1:modalpopupextender>
            <div style="width: 590px; height: 154px">
                <asp:Panel ID="pnlLogotipo" runat="server" BackColor="#FFCC33" Height="197px" Style="display: none"
                    Width="550px">
                    <div style="width: 590px; padding-top: 4px; height: 21px; background-color: Gray;
                        text-align: center">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="Selecione a Imagem"></asp:Label>
                    </div>
                    <div style="padding-right: 10px; padding-left: 10px; width: 590px; padding-top: 20px;
                        height: 40px">
                        O arquivo deverá estar no formato .Gif devido ao seu tamanho, sua dimensão deverá
                        ser 40px(altura) X 200px (largura), e o tamanho do arquivo não poderá ultrapassar
                        os 300 kb.</div>
                    <div style="padding-right: 5px; padding-left: 10px; padding-bottom: 10px; width: 590px;
                        padding-top: 10px; height: 29px">
                        &nbsp;<asp:FileUpload ID="fuplLogotipo" runat="server" Width="512px" /></div>
                    <div style="width: 590px; height: 40px; text-align: center">
                        <asp:ImageButton ID="ibtnConfirmarLogo" runat="server" ImageUrl="~/Imagens/Confirmar.png"
                            OnClick="ibtnConfirmarLogo_Click" />&nbsp;
                        <asp:ImageButton ID="ibtnCancelarLogo" runat="server" ImageUrl="~/Imagens/Cancelar.png" /></div>
                </asp:Panel>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Button" Width="122px" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="601px"></asp:TextBox>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ibtnConfirmarLogo" />
        </Triggers>
    </asp:UpdatePanel>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagens/Confirmar.png" />
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1">
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                </cc1:TabPanel>
            </cc1:TabContainer></asp:View>
    </asp:MultiView></div>
