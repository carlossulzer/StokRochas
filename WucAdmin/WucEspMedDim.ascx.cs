using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class WucAdmin_WucEspMedDim : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["inicio"] == null)
        {
            CarregarDados(string.Empty, ETipoConsulta.Iniciando);
            CarregarTipoProduto();
            ViewState["opcao"] = EOperacao.Inicial;
            ViewState["codigo"] = 0;
            HabilitarDesabilitar(false);
            ViewState["inicio"] = "1";
        }
    }

    #region Habilitar ou Desabilitar Campos
    /// <summary>
    /// Habilitar ou Desabilitar Campos
    /// </summary>
    /// <param name="status"></param>
    public void HabilitarDesabilitar(bool status)
    {
        txtDescEspessura.Enabled = status;
        ddlTipoProduto.Enabled = status;

        ibtnConfirmar.Enabled = status;
        ibtnCancelar.Enabled = status;

        if (status)
            txtDescEspessura.Focus();

        if (((EOperacao)ViewState["opcao"]).Equals(EOperacao.Visualizar))
        {
            ibtnConfirmar.Visible = false;
            ibtnCancelar.Visible = false;
            ibtnVoltar.Visible = true;
        }
        else if (((EOperacao)ViewState["opcao"]).Equals(EOperacao.Excluir))
        {
            ibtnConfirmar.Enabled = true;
            ibtnCancelar.Enabled = true;
        }
        else
        {
            ibtnConfirmar.Visible = true;
            ibtnCancelar.Visible = true;
            ibtnVoltar.Visible = false;
        }
    }
    #endregion

    #region Limpar Campos do Formulário
    public void LimparCampos()
    {
        txtDescEspessura.Text = string.Empty;
    }
    #endregion

    public void CarregarDados(string nome, ETipoConsulta tipo)
    {
        EspessurasCTL espessurasCTL = new EspessurasCTL();
        grvEspessuras.DataSource = espessurasCTL.Listar(nome, tipo, ETipoDados.Geral);
        grvEspessuras.DataBind();
    }

    protected void grvEspessuras_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((ImageButton)e.Row.Cells[0].Controls[1]).CommandArgument = e.Row.RowIndex.ToString();
            ((ImageButton)e.Row.Cells[1].Controls[1]).CommandArgument = e.Row.RowIndex.ToString();
            ((ImageButton)e.Row.Cells[2].Controls[1]).CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void ibtnExcluir_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Excluir;
        CarregarRegistro(false, sender);
        MultiView1.ActiveViewIndex = 1;
    }

    public void CarregarRegistro(bool status, object sender)
    {
        ImageButton ibtnCodigo = (ImageButton)sender;
        int rowNumber = Convert.ToInt32(ibtnCodigo.CommandArgument);

        int codigo = Convert.ToInt32(grvEspessuras.DataKeys[rowNumber]["CodEspessura"].ToString());
        string codTipo = grvEspessuras.DataKeys[rowNumber]["CodTipo"].ToString();
        ViewState["codigo"] = codigo;

        EspessurasDOM dados = new EspessurasDOM();
        EspessurasCTL espessurasCTL = new EspessurasCTL();

        dados = espessurasCTL.Buscar(codigo);
        txtDescEspessura.Text = dados.DescEspessura;
        CarregarTipoProduto();


        ddlTipoProduto.SelectedValue = codTipo;

        HabilitarDesabilitar(status);
    }

    protected void ibtnNovo_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Incluir;
        LimparCampos();
        HabilitarDesabilitar(true);
        MultiView1.ActiveViewIndex = 1;
        ScriptManager.GetCurrent(Page).SetFocus(txtDescEspessura);
    }
    protected void ibtnSair_Click(object sender, ImageClickEventArgs e)
    {
        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "redirectMe", "location.href='Default.aspx?wucForm=';", true);
    }

    protected void ibtnSelecionar_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Visualizar;
        CarregarRegistro(false, sender);
        MultiView1.ActiveViewIndex = 1;
    }

    protected void ibtnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        ETipoConsulta tipoConsulta = ETipoConsulta.Iniciando;
        if (rbtIniciando.Checked)
            tipoConsulta = ETipoConsulta.Iniciando;
        else if (rbtContendo.Checked)
            tipoConsulta = ETipoConsulta.Contendo;
        else if (rbtTerminando.Checked)
            tipoConsulta = ETipoConsulta.Terminando;

        CarregarDados(txtConsulta.Text, tipoConsulta);
    }
    protected void ibtnAlterar_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Alterar;
        CarregarRegistro(true, sender);
        MultiView1.ActiveViewIndex = 1;
    }

    protected void ibtnConfirmar_Click(object sender, ImageClickEventArgs e)
    {
        int codigo = Convert.ToInt32(ViewState["codigo"].ToString());
        EspessurasCTL espessurasCTL = new EspessurasCTL();
        EspessurasDOM espessurasDOM = new EspessurasDOM();

        espessurasDOM.CodEspessura = codigo;
        espessurasDOM.DescEspessura = txtDescEspessura.Text;
        espessurasDOM.CodTipo = Convert.ToInt16(ddlTipoProduto.SelectedValue);

        espessurasCTL.ManterDados(espessurasDOM, (EOperacao)ViewState["opcao"]);
        CarregarDados(string.Empty, ETipoConsulta.Iniciando);
        MultiView1.ActiveViewIndex = 0;
    }


    protected void ibtnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void grvEspessuras_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvEspessuras.PageIndex = e.NewPageIndex;
        CarregarDados(txtConsulta.Text, ETipoConsulta.Iniciando);
    }


    public void CarregarTipoProduto()
    {
        TiposdeProdutosCTL tipodeProdutosCTL = new TiposdeProdutosCTL();
        ddlTipoProduto.DataTextField = "descTipo";
        ddlTipoProduto.DataValueField = "codTipo";
        ddlTipoProduto.DataSource = tipodeProdutosCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.DropDown);
        ddlTipoProduto.DataBind();
    }

}
