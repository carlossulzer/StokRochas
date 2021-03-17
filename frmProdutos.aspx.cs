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
using System.Text;
using System.Drawing;
using System.IO;

public partial class frmProdutos : System.Web.UI.Page //CompactarViewState 
{

    PagedDataSource pds = new PagedDataSource();

    
    public frmProdutos()
    {
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HabilitarMultiView(ViewItens);
            CurrentPage = 0;
            ViewState["PrimeiraPagina"] = null;
            ViewState["UltimaPagina"] = null;

            CarregarDados();
            ViewState["codFornecedor"] = Request["codFornecedor"].ToString();
            ViewState["codCor"] = Request["codCor"].ToString();
            ViewState["codMaterial"] = Request["codMaterial"].ToString();
            ViewState["codTipo"] = Request["codTipo"].ToString();
            ViewState["codEspessura"] = Request["codEspessura"].ToString();

            ConsultarDados();
        }
    }

    public void CarregarDados()
    {
        CurrentPage = 0;
        DesabilitarPaginacao();

        ViewState["codFornecedor"] = "-1";
        ViewState["codCor"] = "-1";
        ViewState["codMaterial"] = "-1";
        ViewState["codTipo"] = "-1";
        ViewState["codEspessura"] = "-1";

        dlstProdutos.DataSource = null;
        dlstProdutos.DataBind();

    }

   
    // -------------------------------------- Paginação -----------------------------------------
    protected void ConsultarDados()
    {
        string codFornecedor = ViewState["codFornecedor"].ToString();
        string codCor = ViewState["codCor"].ToString();
        string codMaterial = ViewState["codMaterial"].ToString();
        string codTipo = ViewState["codTipo"].ToString();
        string codEspessura = ViewState["codEspessura"].ToString();


        ibtnDireita.Visible = true;
        ibtnEsquerda.Visible = true;

        ProdutosCTL produtosCTL = new ProdutosCTL();

        try
        {
            pds.DataSource = produtosCTL.Listar(codFornecedor, codCor, codEspessura, codTipo, codMaterial).Tables[0].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 20; 
            pds.CurrentPageIndex = CurrentPage;
            ibtnDireita.Visible = !pds.IsLastPage;
            ibtnEsquerda.Visible = !pds.IsFirstPage;

            dlstProdutos.DataSource = pds;
            dlstProdutos.DataBind();


            if (!(pds.Count > 0))
                HabilitarMultiView(ViewSemProduto);
            else
                HabilitarMultiView(ViewItens);

            //divMensagem.Visible = !(pds.Count > 0);
            //lblConsulta.Visible = !(pds.Count > 0);

            //divTelEmail.Visible = (pds.Count == 0);


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
        ConsultarDados(); 
    }
    protected void ibtnDireita_Click(object sender, ImageClickEventArgs e)
    {
        CurrentPage += 1;
        ConsultarDados();
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
            ConsultarDados();
        }
    }


    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = 0;
        ConsultarDados();
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

    public void CarregarRegistro(object sender)
    {
        try
        {
            ModalPopupExtender1.Show();

            LinkButton ibtnCodigo = (LinkButton)sender;

            string[] codigos = ibtnCodigo.CommandArgument.Split(';');

            int codigoCliente = Convert.ToInt32(codigos[0]);
            int codigoProduto = Convert.ToInt32(codigos[1]);

            ViewState["codFornecedor"] = codigoCliente;

            string endereco = string.Empty;
            string cidade = string.Empty;

            ClientesCTL clientesCTL = new ClientesCTL();
            ClientesDOM dados = clientesCTL.Buscar(codigoCliente);

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


            ProdutosCTL produtosCTL = new ProdutosCTL();
            ProdutosDOM produto = produtosCTL.Buscar(codigoCliente, codigoProduto);


            string diretorio = System.AppDomain.CurrentDomain.BaseDirectory;
            string arquivo = "Produtos\\" + codigoCliente.ToString() + "\\Grande\\" + produto.CodMaterial.ToString() + ".jpg";


            if (!File.Exists(diretorio + arquivo))
                imgGrande.ImageUrl = "imagens/ProdutoSemFoto.jpg";
            else
                imgGrande.ImageUrl = arquivo.Replace("/", "\\");

            lblMaterial.Text = produto.NomeProduto;
            lblQuant.Text = produto.Quantidade.ToString();

        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }


    protected void lnkbtFornecedor_Click(object sender, EventArgs e)
    {
        LinkButton ibtnCodigo = (LinkButton)sender;
        CarregarRegistro(sender);
    }

    public void HabilitarMultiView(View viewAtiva)
    {
        MultiViewProdutos.SetActiveView(viewAtiva);
    
    }

    
}
