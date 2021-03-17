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

public partial class WucCores : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["inicio"] == null)
        {
            CarregarDados(string.Empty, ETipoConsulta.Iniciando, EIdioma.Portugues);
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
        txtNomePor.Enabled = status;
        txtNomeIng.Enabled = status;
        txtNomeEsp.Enabled = status;
        
        ibtnConfirmar.Enabled = status;
        ibtnCancelar.Enabled = status;

        if (status)
            txtNomePor.Focus();

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
        txtNomePor.Text = string.Empty;
        txtNomeIng.Text = string.Empty;
        txtNomeEsp.Text = string.Empty;
    }
    #endregion

    public void CarregarDados(string nome, ETipoConsulta tipo, EIdioma idioma)
    {
        CoresCTL coresCTL = new CoresCTL();
        grvCores.DataSource = coresCTL.Listar(nome, tipo, idioma, ETipoDados.Geral);
        grvCores.DataBind();
    }

    protected void grvCores_RowDataBound(object sender, GridViewRowEventArgs e)
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

        int codigo = Convert.ToInt32(grvCores.DataKeys[rowNumber].Value.ToString());
        ViewState["codigo"] = codigo;

        CoresDOM dados = new CoresDOM();
        CoresCTL corsCTL = new CoresCTL();

        dados = corsCTL.Buscar(codigo);

        txtNomePor.Text = dados.NomeCorPor;
        txtNomeIng.Text = dados.NomeCorIng;
        txtNomeEsp.Text = dados.NomeCorEsp;
       
        HabilitarDesabilitar(status);
    }


    protected void ibtnNovo_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Incluir;
        LimparCampos();
        HabilitarDesabilitar(true);
        MultiView1.ActiveViewIndex = 1;
        ScriptManager.GetCurrent(Page).SetFocus(txtNomePor);
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
        EIdioma tipoIdioma = EIdioma.Portugues;
        if (rbtIniciando.Checked)
            tipoConsulta = ETipoConsulta.Iniciando;
        else if (rbtContendo.Checked)
            tipoConsulta = ETipoConsulta.Contendo;
        else if (rbtTerminando.Checked)
            tipoConsulta = ETipoConsulta.Terminando;

        if (rbtnPortugues.Checked)
            tipoIdioma = EIdioma.Portugues;
        else if (rbtnIngles.Checked)
            tipoIdioma = EIdioma.Ingles;
        else if (rbtnEspanhol.Checked)
            tipoIdioma = EIdioma.Espanhol;

        CarregarDados(txtConsulta.Text, tipoConsulta, tipoIdioma);
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
        CoresCTL coresCTL = new CoresCTL();
        CoresDOM coresDOM = new CoresDOM();

        coresDOM.CodCor = codigo;
        coresDOM.NomeCorPor = txtNomePor.Text;
        coresDOM.NomeCorIng = txtNomeIng.Text;
        coresDOM.NomeCorEsp = txtNomeEsp.Text;

        coresCTL.ManterDados(coresDOM, (EOperacao)ViewState["opcao"]);
        CarregarDados(string.Empty, ETipoConsulta.Iniciando, EIdioma.Portugues);
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

    protected void grvCores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCores.PageIndex = e.NewPageIndex;
        CarregarDados(string.Empty, ETipoConsulta.Iniciando, EIdioma.Portugues);
    }
}

