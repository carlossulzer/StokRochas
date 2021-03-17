<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultADM.aspx.cs" Inherits="DefaultADM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:. Stok Rochas - Administração .:.</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600">
    </asp:ScriptManager>
    <div class="divADM" id="divTotal">
        <div style="float: left; width: 101%; height: 76px; border-bottom: black 1px solid;
            padding-top: 5px; text-align: left;" id="divLateral">
            <div style="float: right; width: 746px; height: 73px">
                <div style="width: 196px; height: 24px; float: left; padding-top: 30px; text-align: right;">
                    <asp:Label ID="Label1" runat="server" CssClass="titulo" Text="Área Administrativa"></asp:Label>
                </div>
                <div style="float: right; width: 476px; height: 46px; padding-right: 10px; text-align: right; padding-top: 15px;">
                    &nbsp;<asp:ImageButton ID="ibtnClientes" runat="server" ImageUrl="~/imagens/Clientes.bmp"
                        ToolTip="Clientes" OnClick="ibtnClientes_Click" />&nbsp; &nbsp;<asp:ImageButton ID="ibtnEspessura"
                            runat="server" ImageUrl="~/imagens/medidas.jpg" ToolTip="Espessuras / Medidas / Dimensões"
                            OnClick="ibtnEspessura_Click" />&nbsp; &nbsp;<asp:ImageButton ID="ibtnCores" runat="server"
                                ImageUrl="~/imagens/Cores.bmp" ToolTip="Cores" OnClick="ibtnCores_Click" />&nbsp;
                    <asp:ImageButton ID="ibtnTiposdeProdutos" runat="server" ImageUrl="~/imagens/TipodeProduto.bmp"
                        OnClick="ibtnTiposdeProdutos_Click" ToolTip="Tipos de Produtos" />
                    &nbsp;&nbsp;<asp:ImageButton ID="ibtnMateriais" runat="server" ImageUrl="~/imagens/Materiais.bmp"
                        OnClick="ibtnMateriais_Click" ToolTip="Materiais" />
                    &nbsp;<asp:ImageButton ID="ibtnCategoria" runat="server" ImageUrl="~/imagens/Categorias.jpg"
                        ToolTip="Categorias" OnClick="ibtnEnviar_Click" />&nbsp;<asp:ImageButton ID="ibtnPlanos"
                            runat="server" ImageUrl="~/imagens/Planos.jpg" OnClick="ibtnPlanos_Click" ToolTip="Planos" />
                    &nbsp;<asp:ImageButton ID="ibtnSenha" runat="server" ImageUrl="~/imagens/SenhaCliente.bmp"
                        OnClick="ibtnSenha_Click" ToolTip="Senha do Cliente" />
                </div>
            </div>
            <div style="padding-left: 0px; float: left; width: 127px; padding-top: 3px; height: 70px">
                <span style="font-size: 36pt; color: #ffffff">
                    <asp:ImageButton ID="ibtnPrincipal" runat="server" ImageUrl="~/imagens/Logo_StokRochas.gif" OnClick="ibtnPrincipal_Click" />
                </span>
            </div>
        </div>
        <div style="float: left; width: 100%; height: 471px; padding-left: 13px;">
            <asp:PlaceHolder ID="PlaceHolderADM" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    </form>
</body>
</html>
