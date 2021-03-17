using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class frmFornecedores : System.Web.UI.Page
{
    public string pagina = string.Empty;
    public string endereco = string.Empty;
    public string cidade = string.Empty;
    public string codigo = string.Empty;
    public string logotipo = string.Empty;
    PagedDataSource pds = new PagedDataSource();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["site"] = string.Empty;
            ViewState["codFornecedor"] = string.Empty;
            CarregarFornecedores(string.Empty);
        }
    }


    public string LetraSelecionada
    {
        get
        {
            if (this.ViewState["Letra"] == null)
                return string.Empty;
            else
                return this.ViewState["Letra"].ToString();
        }

        set
        {
            this.ViewState["Letra"] = value;
        }

    }


    public void CarregarFornecedores(string nomeFornecedor)
    {
        CurrentPage = 0;
        ViewState["UltimaPagina"] = null;
        ViewState["PrimeiraPagina"] = null;

        ViewState["filtro"] = nomeFornecedor;

        ibtnLetraA.ImageUrl = "~/imagens/Letra_A.gif";
        ibtnLetraB.ImageUrl = "~/imagens/Letra_B.gif";
        ibtnLetraC.ImageUrl = "~/imagens/Letra_C.gif";
        ibtnLetraD.ImageUrl = "~/imagens/Letra_D.gif";
        ibtnLetraE.ImageUrl = "~/imagens/Letra_E.gif";
        ibtnLetraF.ImageUrl = "~/imagens/Letra_F.gif";
        ibtnLetraG.ImageUrl = "~/imagens/Letra_G.gif";
        ibtnLetraH.ImageUrl = "~/imagens/Letra_H.gif";
        ibtnLetraI.ImageUrl = "~/imagens/Letra_I.gif";
        ibtnLetraJ.ImageUrl = "~/imagens/Letra_J.gif";
        ibtnLetraK.ImageUrl = "~/imagens/Letra_K.gif";
        ibtnLetraL.ImageUrl = "~/imagens/Letra_L.gif";
        ibtnLetraM.ImageUrl = "~/imagens/Letra_M.gif";
        ibtnLetraN.ImageUrl = "~/imagens/Letra_N.gif";
        ibtnLetraO.ImageUrl = "~/imagens/Letra_O.gif";
        ibtnLetraP.ImageUrl = "~/imagens/Letra_P.gif";
        ibtnLetraQ.ImageUrl = "~/imagens/Letra_Q.gif";
        ibtnLetraR.ImageUrl = "~/imagens/Letra_R.gif";
        ibtnLetraS.ImageUrl = "~/imagens/Letra_S.gif";
        ibtnLetraT.ImageUrl = "~/imagens/Letra_T.gif";
        ibtnLetraU.ImageUrl = "~/imagens/Letra_U.gif";
        ibtnLetraV.ImageUrl = "~/imagens/Letra_V.gif";
        ibtnLetraW.ImageUrl = "~/imagens/Letra_W.gif";
        ibtnLetraX.ImageUrl = "~/imagens/Letra_X.gif";
        ibtnLetraY.ImageUrl = "~/imagens/Letra_Y.gif";
        ibtnLetraZ.ImageUrl = "~/imagens/Letra_Z.gif";
        ibtnTodos.ImageUrl = "~/imagens/Todos.gif";

        ConsultarDados(nomeFornecedor);
    }

    protected void ibtnLetraA_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("A");
        ibtnLetraA.ImageUrl = "~/imagens/Letra_A_Sel.gif";

    }
    protected void ibtnLetraB_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("B");
        ibtnLetraB.ImageUrl = "~/imagens/Letra_B_Sel.gif";
    }
    protected void ibtnLetraC_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("C");
        ibtnLetraC.ImageUrl = "~/imagens/Letra_C_Sel.gif";
    }
    protected void ibtnLetraD_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("D");
        ibtnLetraD.ImageUrl = "~/imagens/Letra_D_Sel.gif";
    }
    protected void ibtnLetraE_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("E");
        ibtnLetraE.ImageUrl = "~/imagens/Letra_E_Sel.gif";
    }
    protected void ibtnLetraF_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("F");
        ibtnLetraF.ImageUrl = "~/imagens/Letra_F_Sel.gif";
    }
    protected void ibtnLetraG_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("G");
        ibtnLetraG.ImageUrl = "~/imagens/Letra_G_Sel.gif";
    }
    protected void ibtnLetraH_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("H");
        ibtnLetraH.ImageUrl = "~/imagens/Letra_H_Sel.gif";
    }
    protected void ibtnLetraI_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("I");
        ibtnLetraI.ImageUrl = "~/imagens/Letra_I_Sel.gif";
    }
    protected void ibtnLetraJ_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("J");
        ibtnLetraJ.ImageUrl = "~/imagens/Letra_J_Sel.gif";
    }
    protected void ibtnLetraK_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("K");
        ibtnLetraK.ImageUrl = "~/imagens/Letra_K_Sel.gif";
    }
    protected void ibtnLetraL_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("L");
        ibtnLetraL.ImageUrl = "~/imagens/Letra_L_Sel.gif";
    }
    protected void ibtnLetraM_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("M");
        ibtnLetraM.ImageUrl = "~/imagens/Letra_M_Sel.gif";
    }
    protected void ibtnLetraN_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("N");
        ibtnLetraN.ImageUrl = "~/imagens/Letra_N_Sel.gif";
    }
    protected void ibtnLetraO_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("O");
        ibtnLetraO.ImageUrl = "~/imagens/Letra_O_Sel.gif";
    }
    protected void ibtnLetraP_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("P");
        ibtnLetraP.ImageUrl = "~/imagens/Letra_P_Sel.gif";
    }
    protected void ibtnLetraQ_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("Q");
        ibtnLetraQ.ImageUrl = "~/imagens/Letra_Q_Sel.gif";
    }
    protected void ibtnLetraR_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("R");
        ibtnLetraR.ImageUrl = "~/imagens/Letra_R_Sel.gif";
    }
    protected void ibtnLetraS_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("S");
        ibtnLetraS.ImageUrl = "~/imagens/Letra_S_Sel.gif";
    }
    protected void ibtnLetraT_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("T");
        ibtnLetraT.ImageUrl = "~/imagens/Letra_T_Sel.gif";
    }
    protected void ibtnLetraU_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("U");
        ibtnLetraU.ImageUrl = "~/imagens/Letra_U_Sel.gif";
    }
    protected void ibtnLetraV_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("V");
        ibtnLetraV.ImageUrl = "~/imagens/Letra_V_Sel.gif";
    }
    protected void ibtnLetraW_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("W");
        ibtnLetraW.ImageUrl = "~/imagens/Letra_W_Sel.gif";
    }
    protected void ibtnLetraX_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("X");
        ibtnLetraX.ImageUrl = "~/imagens/Letra_X_Sel.gif";
    }
    protected void ibtnLetraY_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("Y");
        ibtnLetraY.ImageUrl = "~/imagens/Letra_Y_Sel.gif";
    }
    protected void ibtnLetraZ_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores("Z");
        ibtnLetraZ.ImageUrl = "~/imagens/Letra_Z_Sel.gif";

    }
    protected void ibtnTodos_Click(object sender, ImageClickEventArgs e)
    {
        CarregarFornecedores(String.Empty);
        ibtnTodos.ImageUrl = "~/imagens/Todos_Sel.gif";
    }



    // -------------------------------------- Paginação -----------------------------------------
    protected void ConsultarDados(string nomeFornecedor)
    {

        try
        {
            ibtnDireita.Visible = true;
            ibtnEsquerda.Visible = true;

            FornecedoresCTL fornecedoresCTL = new FornecedoresCTL();

            pds.DataSource = fornecedoresCTL.Listar(nomeFornecedor, ETipoConsulta.Iniciando, ETipoDados.Geral).Tables[0].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 25; // Convert.ToInt16(ddlPageSize.SelectedValue); 
            pds.CurrentPageIndex = CurrentPage;
            ibtnDireita.Visible = !pds.IsLastPage;
            ibtnEsquerda.Visible = !pds.IsFirstPage;

            dlstFornecedores.DataSource = pds;
            dlstFornecedores.DataBind();

            divMensagem.Visible = !(pds.Count > 0);
            lblConsulta.Visible = !(pds.Count > 0);

            imgST.Visible = (pds.Count > 0);
            imgLetraK.Visible = (pds.Count > 0);
            dlPaging.Visible = (pds.Count > 0);

            doPaging();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }

    }


    private void doPaging()
    {

        int primeiraPagina = 0;
        int ultimaPagina = 0;

        if (ViewState["PrimeiraPagina"] == null)
        {
            ViewState["PrimeiraPagina"] = CurrentPage;
            primeiraPagina = CurrentPage;
        }
        else
        {
            primeiraPagina = (int)ViewState["PrimeiraPagina"];
        }

        if (ViewState["UltimaPagina"] == null)
        {
            ViewState["UltimaPagina"] = CurrentPage + 5;
            if ((int)ViewState["UltimaPagina"] >= pds.PageCount)
            {
                ViewState["UltimaPagina"] = pds.PageCount;

            }
            ultimaPagina = (int)ViewState["UltimaPagina"];

            if (pds.PageCount <= 1)
            {
                ViewState["UltimaPagina"] = null;
                ultimaPagina = 0;
            }

        }
        else
        {
            ultimaPagina = (int)ViewState["UltimaPagina"];
        }

        if (CurrentPage > 0 && CurrentPage < primeiraPagina)
        {
            ViewState["PrimeiraPagina"] = CurrentPage - 4;
            primeiraPagina = (int)ViewState["PrimeiraPagina"];
            if (primeiraPagina < 0)
            {
                ViewState["PrimeiraPagina"] = 0;
                primeiraPagina = (int)ViewState["PrimeiraPagina"];
            }

            ViewState["UltimaPagina"] = CurrentPage + 1;
            ultimaPagina = (int)ViewState["UltimaPagina"];
        }

        else if (CurrentPage >= ultimaPagina)
        {
            ViewState["PrimeiraPagina"] = CurrentPage;
            primeiraPagina = (int)ViewState["PrimeiraPagina"];

            ViewState["UltimaPagina"] = CurrentPage + 5;
            if ((int)ViewState["UltimaPagina"] > pds.PageCount) // ==
                ViewState["UltimaPagina"] = pds.PageCount;
            ultimaPagina = (int)ViewState["UltimaPagina"];

            if (pds.PageCount <= 1)
            {
                ViewState["UltimaPagina"] = null;
                ultimaPagina = 0;
            }


        }


        // Cria DataTable para gerar a numeração das páginas
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");

        if (ultimaPagina > 0)
        {
            for (int i = primeiraPagina; i < ultimaPagina; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }
        }
        else
        {
            DesabilitarPaginacao();
        }

        dlPaging.DataSource = dt;
        dlPaging.DataBind();


        if (ViewState["UltimaPagina"] != null)
        {
            if ((int)ViewState["UltimaPagina"] == pds.PageCount)
                ibtnDireita.Visible = false;
        }
    }

    protected void ibtnEsquerda_Click(object sender, ImageClickEventArgs e)
    {
        CurrentPage -= 1;
        ConsultarDados(LetraSelecionada);
    }

    protected void ibtnDireita_Click(object sender, ImageClickEventArgs e)
    {
        CurrentPage += 1;
        ConsultarDados(LetraSelecionada);
    }

    public int CurrentPage
    {
        get
        {
            if (this.ViewState["CurrentPage"] == null)
                return 0;
            else
                return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
        }

        set
        {
            this.ViewState["CurrentPage"] = value;
        }

    }
    protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("lnkbtnPaging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            ConsultarDados(LetraSelecionada);
        }
    }


    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = 0;
        ConsultarDados(LetraSelecionada);
    }

    protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
        ImageButton ibtnAtual = (ImageButton)e.Item.FindControl("ibtnAtual");
        if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Font.Bold = true;
            ibtnAtual.ImageUrl = "~/imagens/Letra_O_Laranja.jpg";
        }
    }

    public void DesabilitarPaginacao()
    {
        dlPaging.Visible = false;
        imgST.Visible = false;
        imgLetraK.Visible = false;
        ibtnEsquerda.Visible = false;
        ibtnDireita.Visible = false;
    }

    protected void ImageLogo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibtnCodigo = (ImageButton)sender;
        string codFornecedor = ibtnCodigo.CommandArgument;

        CarregarRegistro(false, sender);
    }


    public void CarregarRegistro(bool status, object sender)
    {
        try
        {
            ModalPopupExtender1.Show();

            ImageButton ibtnCodigo = (ImageButton)sender;
            int codigo = Convert.ToInt32(ibtnCodigo.CommandArgument);

            ViewState["codFornecedor"] = codigo;

            string endereco = string.Empty;
            string cidade = string.Empty;

            ClientesCTL clientesCTL = new ClientesCTL();
            ClientesDOM dados = clientesCTL.Buscar(codigo);

            lblNome.Text = dados.NomeFantasia;

            lblEndereco.Text = dados.EnderecoCom + " - " + dados.BairroCom;
            lblCidade.Text = dados.CidadeCom + " - " + dados.UfCom + " - " + dados.CepCom;

            lblEmail.Text = dados.Email.ToLower();
            lblEmail2.Text = dados.Email2.ToLower();

            lblTelefone1.Text = dados.Telefone1;
            lblTelefone2.Text = dados.Telefone2;


            hplkSite.NavigateUrl = "http://" + dados.Site;
            hplkSite.Text = dados.Site.ToLower();

            lblObservacao.Text = dados.Observacao.ToLower();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }


    protected void ibtnEstoque_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmProdutos.aspx?codFornecedor=" + ViewState["codFornecedor"].ToString() + "&codCor=-1&codMaterial=-1&codTipo=-1&codEspessura=-1");
    }

    protected void ibtnPromocao_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmPromocoes.aspx?codFornecedor=" + ViewState["codFornecedor"].ToString());
    }
    protected void ibtnLancamento_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmLancamentos.aspx?codFornecedor=" + ViewState["codFornecedor"].ToString());
    }
}
