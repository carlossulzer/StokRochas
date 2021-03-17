<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="frmServicos.aspx.cs" Inherits="frmServicos" Title=":: Stok Rochas - Utilidades ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="servicos_form">
    
    <div class="servicos_topo">
        <div class="servicos_titulo_imagen">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/imagens/seta_titulo.jpg" />
        </div>
        <div class="servicos_titulo_texto">
            <asp:Label ID="Label6" runat="server" Text="UTILIDADES" SkinID="labelTitulo" ></asp:Label>
        </div>
    </div>
      
    <div class="servicos_body">
        <div class="servicos_menu">
            <div style="height: 25px; text-align:center; background-color:#FFA500; padding-top: 5px; width: 209px; float:left;">
                <asp:Label ID="Label1" runat="server" Text="Categorias" CssClass="labelSubTitulo"></asp:Label>
            </div>       
            <div class="servicos_menu_interno">
                <div id="servicos_categoria"  >
                    <asp:DataList ID="dlstCategorias" runat="server" Width="193px" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtFornecedor" OnClick="lnkbtCategoria_Click" runat="server" 
                               Text='<%# Eval("DescCategoria") %>' CommandArgument='<%# Eval("CodCategoria") %>'>
                            </asp:LinkButton>
                            <br />                                
                                
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>        
        </div>     
        
        <div class="servicos_right">
            <div class="servicos_select">
                <asp:Label ID="lblCategoriaSelect" runat="server" Text="categoria selecionada" CssClass="labelSubTitulo"></asp:Label>
            </div>
        
            <div class="servicos_itens">
                <asp:DataList ID="dtlServicos" runat="server" Width="515px">
                    <ItemTemplate>
                        <div style="height: auto; width: 515px; padding-top: 7px; border-top-style: dotted; border-top-width: 1px; border-top-color: #000000;">
                      
                            <div style="clear:both; width: 144px; float: left; height: auto; text-align: left; vertical-align:middle">
                                <asp:Image ID="Image2" runat="server" Height="70px" Width="130px" ImageUrl='<%# Eval("Logotipo", "~/Logotipos/{0}") %>'  ImageAlign="Middle" />
                            </div>
                            
                            <div style="width: 351px; float: left; height: auto;">
                                <br/> 
                                <div style="float:left; width: 16px; padding-top:2px">   
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/seta_estoque.jpg" />
                                </div>
                                
                                <asp:Label ID="Label2" runat="server" Font-Names="Verdana"  
                                   Text='<%# Eval("nomeFantasia") %>' CssClass="labelSubTitulo" Width="320px">
                                </asp:Label>
                                <br />
                                <br />
                                
                                <asp:Label ID="Label16" runat="server" Font-Names="Verdana" 
                                    Text='<%# Eval("endcliente") %>' style="width: 350px; height: auto;"  >
                                </asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label3" runat="server" Font-Names="Verdana"  style="height:auto; min-height:11px; width: 350px"
                                    Text='<%# Eval("telefones") %>'>
                                </asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label4" runat="server" Font-Names="Verdana" 
                                   style="height:auto; min-height:11px; width: 350px" Text='<%# Eval("emails") %>'>
                                </asp:Label>
                                <br />
                                <br />
                              
                                <asp:Label ID="Label14" runat="server" Text="WebSite:" CssClass="labelSubTitulo" />
                                &nbsp;
                                <a id="link" href='<%# Eval("sitecli", "http://{0}") %>' target="_blank">
                                    <asp:Label ID="Label5" runat="server" Font-Names="Verdana" 
                                       style="height:auto; min-height:11px; width: 350px" Text='<%# Eval("sitecli") %>'>
                                    </asp:Label>
                                </a>
                                
                                <br />
                                <br />
                            
                                <asp:Label ID="Label12" runat="server" Font-Names="Verdana"  
                                    Text='<%# Eval("observacao") %>' Width="350px"></asp:Label>
                                    
                                    
                                <br />
                                <br />
                            </div>                        
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
    
</div>


</asp:Content>

