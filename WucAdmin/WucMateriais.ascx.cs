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

public partial class WucMateriais : System.Web.UI.UserControl
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
        txtDescMaterial.Enabled = status;
        ddlCor.Enabled = status;
        
        ibtnConfirmar.Enabled = status;
        ibtnCancelar.Enabled = status;

        if (status)
            txtDescMaterial.Focus();

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
        txtDescMaterial.Text = string.Empty;
        ddlCor.SelectedValue = "-1";
    }
    #endregion

    public void CarregarDados(string nome, ETipoConsulta tipo)
    {
        MateriaisCTL materiaisCTL = new MateriaisCTL();
        grvMaterial.DataSource = materiaisCTL.Listar(nome, tipo, ETipoDados.Geral);
        grvMaterial.DataBind();

        CoresCTL coresCTL = new CoresCTL();
        ddlCor.DataTextField = "NomeCorPor";
        ddlCor.DataValueField = "CodCor";
        ddlCor.DataSource = coresCTL.Listar(string.Empty, ETipoConsulta.Iniciando, EIdioma.Portugues , ETipoDados.Exportacao ).Tables[0];
        ddlCor.DataBind();

    }

    protected void grvMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
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

        int codigo = Convert.ToInt32(grvMaterial.DataKeys[rowNumber].Value.ToString());
        ViewState["codigo"] = codigo;

        MateriaisDOM dados = new MateriaisDOM();
        MateriaisCTL materiaisCTL = new MateriaisCTL();

        dados = materiaisCTL.Buscar(codigo);
        txtDescMaterial.Text = dados.DescMaterial;
        ddlCor.SelectedValue = dados.CodCor.ToString();
        HabilitarDesabilitar(status);
    }

    protected void ibtnNovo_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Incluir;
        LimparCampos();
        HabilitarDesabilitar(true);
        MultiView1.ActiveViewIndex = 1;
        ScriptManager.GetCurrent(Page).SetFocus(txtDescMaterial);
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

        try
        {
            MateriaisCTL materiaisCTL = new MateriaisCTL();
            MateriaisDOM materiaisDOM = new MateriaisDOM();

            materiaisDOM.CodMaterial = codigo;
            materiaisDOM.DescMaterial = txtDescMaterial.Text;
            materiaisDOM.CodCor = Conversor.ConverterParaInteiro(ddlCor.SelectedValue);

            materiaisCTL.ManterDados(materiaisDOM, (EOperacao)ViewState["opcao"]);
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
        grvMaterial.PageIndex = e.NewPageIndex;
        CarregarDados(string.Empty, ETipoConsulta.Iniciando);

    }
}

