using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LimparFiltro();
        }
    }

    public void CarregarFornecedores(string codCor, string codMaterial, string codTipo, string codEspessura)
    {
        try
        {
            FornecedoresCTL fornecedoresCTL = new FornecedoresCTL();
            cbxFornecedores.DataTextField = "NomeFantasia";
            cbxFornecedores.DataValueField = "CodCliente";

            if (codCor.Equals("-1") && codMaterial.Equals("-1") && codTipo.Equals("-1") && codEspessura.Equals("-1"))
                cbxFornecedores.DataSource = fornecedoresCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.DropDown).Tables[0];
            else
                cbxFornecedores.DataSource = fornecedoresCTL.FiltrarFornecedores(codCor, codMaterial, codTipo, codEspessura).Tables[0];

            cbxFornecedores.DataBind();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }

    public void CarregarCores(string codFornecedor, string codMaterial, string codTipo, string codEspessura)
    {
        try
        {
            CoresCTL coresCTL = new CoresCTL();
            cbxCor.DataTextField = "NomeCor";
            cbxCor.DataValueField = "CodCor";
            Idioma.IdiomaAtual = EIdioma.Portugues;

            if (codFornecedor.Equals("-1") && codMaterial.Equals("-1") && codTipo.Equals("-1") && codEspessura.Equals("-1"))
                cbxCor.DataSource = coresCTL.Listar(string.Empty, ETipoConsulta.Iniciando, Idioma.IdiomaAtual, ETipoDados.DropDown).Tables[0];
            else
                cbxCor.DataSource = coresCTL.CoresdoFornecedor(codFornecedor, codMaterial, codTipo, codEspessura).Tables[0];

            cbxCor.DataBind();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }


    public void CarregarMateriais(string codFornecedor, string codCor, string codTipo, string codEspessura)
    {
        try
        {
            MateriaisCTL materiaisCTL = new MateriaisCTL();
            cbxMaterial.DataTextField = "DescMaterial";
            cbxMaterial.DataValueField = "CodMaterial";

            if (codFornecedor.Equals("-1") && codCor.Equals("-1") && codTipo.Equals("-1") && codEspessura.Equals("-1"))
                cbxMaterial.DataSource = materiaisCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.DropDown).Tables[0];
            else
                cbxMaterial.DataSource = materiaisCTL.MateriaisdoFornecedor(codFornecedor, codCor, codTipo, codEspessura).Tables[0];

            cbxMaterial.DataBind();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }

    public void CarregarTiposdeProdutos(string codFornecedor, string codCor, string codMaterial, string codEspessura)
    {
        try
        {
            TiposdeProdutosCTL tiposdeProdutosCTL = new TiposdeProdutosCTL();
            cbxTipoProduto.DataTextField = "DescTipo";
            cbxTipoProduto.DataValueField = "CodTipo";
            if (codFornecedor.Equals("-1") && codCor.Equals("-1") && codMaterial.Equals("-1") && codEspessura.Equals("-1"))
                cbxTipoProduto.DataSource = tiposdeProdutosCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.DropDown).Tables[0];
            else
                cbxTipoProduto.DataSource = tiposdeProdutosCTL.TipoMateriaisdoFornecedor(codFornecedor, codCor, codMaterial, codEspessura).Tables[0];

            cbxTipoProduto.DataBind();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }

    public void CarregarEspessuras(string codFornecedor, string codCor, string codMaterial, string codTipoProduto)
    {
        try
        {
            EspessurasCTL espessurasCTL = new EspessurasCTL();
            cbxEspessura.DataTextField = "DescEspessura";
            cbxEspessura.DataValueField = "CodEspessura";

            if (codFornecedor.Equals("-1") && codCor.Equals("-1") && codMaterial.Equals("-1") && codTipoProduto.Equals("-1"))
                cbxEspessura.DataSource = espessurasCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.DropDown).Tables[0];
            else
                cbxEspessura.DataSource = espessurasCTL.EspessurasdoFornecedor(codFornecedor, codCor, codMaterial, codTipoProduto).Tables[0];

            cbxEspessura.DataBind();
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }


    protected void cbxFornecedores_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["codFornecedor"] = cbxFornecedores.SelectedValue;
        AtivarFiltro();
    }

    protected void cbxCor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["codCor"] = cbxCor.SelectedValue;
        AtivarFiltro();
    }

    protected void cbxMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["codMaterial"] = cbxMaterial.SelectedValue;
        AtivarFiltro();
    }


    protected void cbxTipoProduto_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["codTipo"] = cbxTipoProduto.SelectedValue;
        AtivarFiltro();
    }

    protected void cbxEspessura_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["codEspessura"] = cbxEspessura.SelectedValue;
        AtivarFiltro();
    }

    public void AtivarFiltro()
    {
        string codFornecedor = ViewState["codFornecedor"].ToString();
        string codCor = ViewState["codCor"].ToString();
        string codMaterial = ViewState["codMaterial"].ToString();
        string codTipo = ViewState["codTipo"].ToString();
        string codEspessura = ViewState["codEspessura"].ToString();

        CarregarFornecedores(codCor, codMaterial, codTipo, codEspessura);
        CarregarCores(codFornecedor, codMaterial, codTipo, codEspessura);
        CarregarMateriais(codFornecedor, codCor, codTipo, codEspessura);
        CarregarTiposdeProdutos(codFornecedor, codCor, codMaterial, codEspessura);
        CarregarEspessuras(codFornecedor, codCor, codMaterial, codTipo);

        cbxFornecedores.SelectedValue = codFornecedor;
        cbxCor.SelectedValue = codCor;
        cbxMaterial.SelectedValue = codMaterial;
        cbxTipoProduto.SelectedValue = codTipo;
        cbxEspessura.SelectedValue = codEspessura;
    }


    protected void ibtnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        string codFornecedor = ViewState["codFornecedor"].ToString();
        string codCor = ViewState["codCor"].ToString();
        string codMaterial = ViewState["codMaterial"].ToString();
        string codTipo = ViewState["codTipo"].ToString();
        string codEspessura = ViewState["codEspessura"].ToString();
        Response.Redirect("frmProdutos.aspx?codFornecedor=" + codFornecedor + "&codCor=" + codCor + "&codMaterial=" + codMaterial + "&codTipo=" + codTipo + "&codEspessura="+codEspessura);
    }
    protected void ibtnLimpar_Click(object sender, ImageClickEventArgs e)
    {
        LimparFiltro();
    }


    public void LimparFiltro()
    {
        ViewState["codFornecedor"] = "-1";
        ViewState["codCor"] = "-1";
        ViewState["codMaterial"] = "-1";
        ViewState["codTipo"] = "-1";
        ViewState["codEspessura"] = "-1";
        AtivarFiltro();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
