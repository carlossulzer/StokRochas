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
using System.IO;
using System.Text;

public partial class WucClientes : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["inicio"] == null)
        {
            CarregarDados(string.Empty, ETipoConsulta.Iniciando);
            ViewState["opcao"] = EOperacao.Inicial;
            ViewState["codigo"] = 0;
            CarregarEstados();
            CarregarCategorias();
            CarregarPlanos();
            HabilitarDesabilitar(false);
            ViewState["inicio"] = "1";
            tbcEndereco.ActiveTabIndex = 0;
        }
    }

    #region Habilitar ou Desabilitar Campos
    /// <summary>
    /// Habilitar ou Desabilitar Campos
    /// </summary>
    /// <param name="status"></param>
    public void HabilitarDesabilitar(bool status)
    {
        txtRazaoSocial.Enabled = status;
        txtNomeFantasia.Enabled = status;
        txtCnpj.Enabled = status;
        txtEmail.Enabled = status;
        txtEmail2.Enabled = status;
        txtSite.Enabled = status;
        txtLogotipo.Enabled = status;
        txtTelefone1.Enabled = status;
        txtTelefone2.Enabled = status;

        rbtAtivoSim.Enabled = status;
        rbtAtivoNao.Enabled = status;
        txtLogin.Enabled = status;
        rbtAnuncioSim.Enabled = status;
        rbtAnuncioNao.Enabled = status;
        txtValidade.Enabled = status;

        txtEnderecoCom.Enabled = status;
        txtBairroCom.Enabled = status;
        txtCidadeCom.Enabled = status;
        ddlEstadosCom.Enabled = status;
        txtCepCom.Enabled = status;

        txtEnderecoCob.Enabled = status;
        txtBairroCob.Enabled = status;
        txtCidadeCob.Enabled = status;
        ddlEstadosCob.Enabled = status;
        txtCepCob.Enabled = status;

        ibtnConfirmar.Enabled = status;
        ibtnCancelar.Enabled = status;
        ibtnLogotipo.Enabled = status;

        rbtMovEstoqueSim.Enabled = status;
        rbtMovEstoqueNao.Enabled = status;

        ddlCategoria.Enabled = status;
        ddlPlano.Enabled = status;
        txtProdPromocao.Enabled = status;
        txtProdLancamento.Enabled = status;
        txtObservacoes.Enabled = status;


        if (status)
            txtRazaoSocial.Focus();

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
        txtRazaoSocial.Text = string.Empty;
        txtNomeFantasia.Text = string.Empty;
        txtCnpj.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtEmail2.Text = string.Empty;
        txtSite.Text = string.Empty;
        txtLogotipo.Text = string.Empty;
        txtTelefone1.Text = string.Empty;
        txtTelefone2.Text = string.Empty;

        rbtAtivoSim.Checked = true;
        txtLogin.Text = string.Empty;
        rbtAnuncioSim.Checked = true;
        txtValidade.Text = string.Empty;

        ddlCategoria.SelectedValue = "-1";
        ddlPlano.SelectedValue = "-1";
        txtProdPromocao.Text = string.Empty;
        txtProdLancamento.Text = string.Empty;
        txtObservacoes.Text = string.Empty;

        txtEnderecoCom.Text = string.Empty;
        txtBairroCom.Text = string.Empty;
        txtCidadeCom.Text = string.Empty;
        ddlEstadosCom.SelectedValue = "ES";
        txtCepCom.Text = string.Empty;

        txtEnderecoCob.Text = string.Empty;
        txtBairroCob.Text = string.Empty;
        txtCidadeCob.Text = string.Empty;
        ddlEstadosCob.SelectedValue = "ES";
        txtCepCob.Text = string.Empty;

        tbcEndereco.ActiveTabIndex = 0;

        rbtMovEstoqueSim.Checked = true;

    }
    #endregion

    public void CarregarDados(string nome, ETipoConsulta tipo)
    {
        ClientesCTL clientesCTL = new ClientesCTL();
        grvClientes.DataSource = clientesCTL.Listar(nome, tipo);
        grvClientes.DataBind();
    }

    protected void grvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
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

        int codigo = Convert.ToInt32(grvClientes.DataKeys[rowNumber].Value.ToString());
        ViewState["codigo"] = codigo;

        ClientesDOM dados = new ClientesDOM();
        ClientesCTL clientesCTL = new ClientesCTL();

        dados = clientesCTL.Buscar(codigo);

        txtRazaoSocial.Text = dados.RazaoSocial;
        txtNomeFantasia.Text = dados.NomeFantasia;

        txtCnpj.Text = dados.Cnpj;
        txtEmail.Text = dados.Email;
        txtEmail2.Text = dados.Email2;
        txtSite.Text = dados.Site;
        txtLogotipo.Text = dados.Logotipo;
        txtLogin.Text = dados.Login;
        txtTelefone1.Text = dados.Telefone1;
        txtTelefone2.Text = dados.Telefone2;
        rbtAtivoSim.Checked = (dados.Ativo == 1 ? true : false);
        rbtAtivoNao.Checked = (dados.Ativo == 0 ? true : false);
        txtLogin.Text = dados.Login;

        rbtAnuncioSim.Checked = (dados.Ativo == 1 ? true : false);
        rbtAtivoNao.Checked = (dados.Ativo == 0 ? true : false);

        txtValidade.Text = dados.Validade.ToString("dd/MM/yyyy");
        txtEnderecoCom.Text = dados.EnderecoCom;
        txtBairroCom.Text = dados.BairroCom;
        txtCidadeCom.Text = dados.CidadeCom;
        ddlEstadosCom.SelectedValue = dados.UfCom;
        txtCepCom.Text = dados.CepCom;
        txtEnderecoCob.Text = dados.EnderecoCob;
        txtBairroCob.Text = dados.BairroCob;
        txtCidadeCob.Text = dados.CidadeCob;
        ddlEstadosCob.SelectedValue = dados.UfCob;

        rbtMovEstoqueSim.Checked = (dados.MovEstoque == 1 ? true : false);
        rbtMovEstoqueNao.Checked = (dados.MovEstoque == 0 ? true : false);

        ddlCategoria.SelectedValue = (dados.CodCategoria == 0) ? "-1" : dados.CodCategoria.ToString();
        ddlPlano.SelectedValue = (dados.CodPlano == 0) ? "-1" : dados.CodPlano.ToString();
        txtProdPromocao.Text = dados.NumProdPromocao.ToString();
        txtProdLancamento.Text = dados.NumProdLancamento.ToString();
        txtObservacoes.Text = dados.Observacao;
        txtCepCob.Text = dados.CepCob;
        HabilitarDesabilitar(status);
    }


    protected void ibtnNovo_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["opcao"] = EOperacao.Incluir;
        LimparCampos();
        HabilitarDesabilitar(true);
        MultiView1.ActiveViewIndex = 1;
        ScriptManager.GetCurrent(Page).SetFocus(txtRazaoSocial);
    }
    protected void ibtnSair_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "redirectMe", "location.href='Default.aspx?wucForm=';", true);
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
        ClientesCTL clientesCTL = new ClientesCTL();
        ClientesDOM clientesDOM = new ClientesDOM();

        clientesDOM.CodCliente = codigo;
        clientesDOM.RazaoSocial = txtRazaoSocial.Text;
        clientesDOM.NomeFantasia = txtNomeFantasia.Text;
        clientesDOM.Cnpj = txtCnpj.Text;
        clientesDOM.Email = txtEmail.Text;
        clientesDOM.Email2 = txtEmail2.Text;
        clientesDOM.Site = txtSite.Text;

        if (!txtLogotipo.Text.Trim().Equals(string.Empty))
        {
            if (txtLogotipo.Text.Trim().IndexOf("\\") > 0)
            {
                clientesDOM.Logotipo = txtLogotipo.Text.Trim().Substring((txtLogotipo.Text.Trim().LastIndexOf("\\") + 1), txtLogotipo.Text.Trim().Length - txtLogotipo.Text.Trim().LastIndexOf("\\") - 1);

                try
                {
                    EnviarArquivo enviar = new EnviarArquivo();
                    ArrayList arquivos = new ArrayList();
                    arquivos.Add(txtLogotipo.Text.Trim());

                    string retorno = enviar.Enviar(arquivos, "Logotipos");

                    //if (retorno != string.Empty)
                    //{
                    //    Label1.Text = retorno;
                    //}
                }
                catch(Exception ex)
                {
                    ExibirMensagem.Padrao(ex.Message.ToString(), this.Page);
                }

            }
            else
                clientesDOM.Logotipo = txtLogotipo.Text;
        }


        clientesDOM.Telefone1 = txtTelefone1.Text;
        clientesDOM.Telefone2 = txtTelefone2.Text;
        clientesDOM.Ativo = (rbtAtivoSim.Checked ? 1 : 0);
        clientesDOM.Login = txtLogin.Text;
        clientesDOM.Anuncio = (rbtAnuncioSim.Checked ? 1 : 0);
        clientesDOM.Validade = Conversor.ConverterParaDateTime(txtValidade.Text);
        clientesDOM.EnderecoCom = txtEnderecoCom.Text;
        clientesDOM.BairroCom = txtBairroCom.Text;
        clientesDOM.CidadeCom = txtCidadeCom.Text;
        clientesDOM.UfCom = ddlEstadosCom.SelectedValue;
        clientesDOM.CepCom = txtCepCom.Text;
        clientesDOM.EnderecoCob = txtEnderecoCob.Text;
        clientesDOM.BairroCob = txtBairroCob.Text;
        clientesDOM.CidadeCob = txtCidadeCob.Text;
        clientesDOM.UfCob = ddlEstadosCob.SelectedValue;
        clientesDOM.CepCob = txtCepCob.Text;
        clientesDOM.MovEstoque = (rbtMovEstoqueSim.Checked ? 1 : 0);
        clientesDOM.CodCategoria = Conversor.ConverterParaInteiro(ddlCategoria.SelectedValue);
        clientesDOM.CodPlano = Conversor.ConverterParaInteiro(ddlPlano.SelectedValue);
        clientesDOM.NumProdPromocao = Conversor.ConverterParaInteiro(txtProdPromocao.Text);
        clientesDOM.NumProdLancamento = Conversor.ConverterParaInteiro(txtProdLancamento.Text);
        clientesDOM.Observacao = txtObservacoes.Text;
        clientesCTL.ManterDados(clientesDOM, (EOperacao)ViewState["opcao"]);
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


    public void CarregarEstados()
    {
        ddlEstadosCom.DataTextField = "Descricao";
        ddlEstadosCom.DataValueField = "UF";
        ddlEstadosCom.DataSource = Estados.CarregaEstados();
        ddlEstadosCom.DataBind();

        ddlEstadosCob.DataTextField = "Descricao";
        ddlEstadosCob.DataValueField = "UF";
        ddlEstadosCob.DataSource = Estados.CarregaEstados();
        ddlEstadosCob.DataBind();
    }

    protected void ibtnConfirmarLogo_Click(object sender, ImageClickEventArgs e)
    {
        if (fuplLogotipo.HasFile)
        {
            int FileSiteInKB = (fuplLogotipo.PostedFile.ContentLength / 1024);

            if (FileSiteInKB > 500) // 300kb
            {
                ExibirMensagem.Padrao("Não é permitido anexar arquivo maior que 500kb.", this.Page);
            }
            txtLogotipo.Text = fuplLogotipo.PostedFile.FileName;
        }
    }

    protected void grvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvClientes.PageIndex = e.NewPageIndex;
        CarregarDados(txtConsulta.Text, ETipoConsulta.Iniciando);
    }
    protected void btnCopiar_Click(object sender, EventArgs e)
    {
        txtEnderecoCob.Text = txtEnderecoCom.Text;
        txtBairroCob.Text = txtBairroCom.Text;
        txtCidadeCob.Text = txtCidadeCom.Text;
        ddlEstadosCob.SelectedValue = ddlEstadosCom.SelectedValue;
        txtCepCob.Text = txtCepCom.Text;
    }

    public void CarregarCategorias()
    {
        CategoriasCTL categoriasCTL = new CategoriasCTL();

        ddlCategoria.DataTextField = "DescCategoria";
        ddlCategoria.DataValueField = "CodCategoria";
        ddlCategoria.DataSource = categoriasCTL.Listar(ETipoDados.DropDown);
        ddlCategoria.DataBind();
    }

    public void CarregarPlanos()
    {
        PlanosCTL planosCTL = new PlanosCTL();

        ddlPlano.DataTextField = "descPlano";
        ddlPlano.DataValueField = "codPlano";
        ddlPlano.DataSource = planosCTL.Listar(ETipoDados.DropDown);
        ddlPlano.DataBind();
    }

}

