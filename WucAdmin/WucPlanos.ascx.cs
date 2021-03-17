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

public partial class WucPlanos : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["inicio"] == null)
        {
            CarregarDados(string.Empty, ETipoConsulta.Iniciando);
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
        txtDe.Enabled = status;
        txtAte.Enabled = status;
        txtValor.Enabled = status;
        
        ibtnConfirmar.Enabled = status;
        ibtnCancelar.Enabled = status;

        if (status)
            txtDe.Focus();

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
        txtDe.Text = string.Empty;
        txtAte.Text = string.Empty;
        txtValor.Text = "0.00";
    }
    #endregion

    public void CarregarDados(string nome, ETipoConsulta tipo)
    {
        PlanosCTL planosCTL = new PlanosCTL();
        grvPlano.DataSource = planosCTL.Listar(ETipoDados.Geral);
        grvPlano.DataBind();
    }

    protected void grvPlano_RowDataBound(object sender, GridViewRowEventArgs e)
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

        int codigo = Convert.ToInt32(grvPlano.DataKeys[rowNumber].Value.ToString());
        ViewState["codigo"] = codigo;

        PlanosDOM dados = new PlanosDOM();
        PlanosCTL planosCTL = new PlanosCTL();

        dados = planosCTL.Buscar(codigo);
        txtDe.Text = dados.De.ToString();
        txtAte.Text = dados.Ate.ToString();
        txtValor.Text = dados.Valor.ToString("###,##0.00");
        HabilitarDesabilitar(status);
    }

    protected void ibtnNovo_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Incluir;
        LimparCampos();
        HabilitarDesabilitar(true);
        MultiView1.ActiveViewIndex = 1;
        ScriptManager.GetCurrent(Page).SetFocus(txtDe);
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

    
    protected void ibtnAlterar_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Alterar;
        CarregarRegistro(true, sender);
        MultiView1.ActiveViewIndex = 1;
    }

    protected void ibtnConfirmar_Click(object sender, ImageClickEventArgs e)
    {
        int codigo = Convert.ToInt32(ViewState["codigo"].ToString());

        try
        {
            PlanosCTL planosCTL = new PlanosCTL();
            PlanosDOM planosDOM = new PlanosDOM();

            planosDOM.CodPlano = codigo;
            planosDOM.De = Convert.ToInt32(txtDe.Text);
            planosDOM.Ate = Convert.ToInt32(txtAte.Text);
            planosDOM.Valor = Convert.ToDouble(txtValor.Text);


            planosCTL.ManterDados(planosDOM, (EOperacao)ViewState["opcao"]);
            CarregarDados(string.Empty, ETipoConsulta.Iniciando);
            MultiView1.ActiveViewIndex = 0;

        }
        catch(Exception ex)
        {
            ExibirMensagem.Padrao(ex.Message.ToString(), this.Page);
        }
    }


    protected void ibtnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void grvMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPlano.PageIndex = e.NewPageIndex;
        CarregarDados(string.Empty, ETipoConsulta.Iniciando);

    }
    protected void grvPlano_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

