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
using System.IO;

public partial class frmLancamentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int codFornecedor = 0;
            if (Conversor.ConverterParaInteiro(Request["codFornecedor"].ToString()) > 0)
            {
                codFornecedor = Conversor.ConverterParaInteiro(Request["codFornecedor"].ToString());
            }

            LancamentosCTL lancamentosCTL = new LancamentosCTL();
            DataSet dsFornecedores = lancamentosCTL.LancamentosMenu(codFornecedor);
            dlstFornecedores.DataSource = dsFornecedores;
            dlstFornecedores.DataBind();

            if (dsFornecedores.Tables[0].Rows.Count > 0)
            {
                HabilitarDados(true);
                codFornecedor = Conversor.ConverterParaInteiro(dsFornecedores.Tables[0].Rows[0][0].ToString());
                CarregarRegistro(codFornecedor);
            }
            else
            {
                HabilitarDados(false);
            }
        }
    }

    protected void lnkbtFornecedor_Click(object sender, EventArgs e)
    {
        LinkButton ibtnCodigo = (LinkButton)sender;
        int codigo = Conversor.ConverterParaInteiro(ibtnCodigo.CommandArgument);
        CarregarRegistro(codigo);
    }

    public void CarregarRegistro(int codigo)
    {
        try
        {
            LancamentosCTL lancamentosCTL = new LancamentosCTL();
            dlstLancamentos.DataSource = lancamentosCTL.LancamentosProdutos(codigo);
            dlstLancamentos.DataBind();

            LancamentosDOM lancamentosDOM = lancamentosCTL.LancamentosFornecedor(codigo);

            imgLogotipo.ImageUrl = "~/Logotipos/" + lancamentosDOM.Logotipo;
            lblNomeFantasia.Text = lancamentosDOM.NomeFantasia;
            lblEndCliente.Text = lancamentosDOM.EndCliente;
            lblTelefones.Text = lancamentosDOM.Telefones;
            lblEmails.Text = lancamentosDOM.Emails;
            lblSiteCli.Text = lancamentosDOM.SiteCli;
            linkSite.HRef = "http://" + lancamentosDOM.SiteCli;
            lblObservacao.Text = lancamentosDOM.Observacao;

            lblLancamentosSelect.Text = lancamentosDOM.NomeFantasia;
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }

    public void HabilitarDados(Boolean status)
    {
        if (status == false)
            lblLancamentosSelect.Text = "Não existem lançamentos cadastrados.";
        
        divLogo.Visible = status;
        divFornecedor.Visible = status;
    }

    protected void dlstLancamentos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {

            Image botaoImagem = (Image)e.Item.FindControl("ImagePeq");
            ImageButton botaoAmpliar = (ImageButton)e.Item.FindControl("IbtnAmpliar");

            string diretorio = System.AppDomain.CurrentDomain.BaseDirectory;
            string arquivo = botaoImagem.ImageUrl.Replace("~/Lancamentos", "Lancamentos");
            arquivo = diretorio + arquivo.Replace("/", "\\");

            if (!File.Exists(arquivo))
            {
                botaoImagem.ImageUrl = "imagens/ProdutoSemFotoP.jpg";
                botaoAmpliar.Visible = false;
            }
        }
    }

    protected void ibtnAmpliar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibtnCodigo = (ImageButton)sender;
        string imagem = ibtnCodigo.CommandArgument;
        string produto = ibtnCodigo.ToolTip;

        CarregarLancamentos(imagem, produto);
    }


    public void CarregarLancamentos(string imagem, string produto)
    {
        try
        {
            imgGrande.ImageUrl = imagem;
            lblProduto.Text = produto;
            ModalPopupExtender1.Show();
        }
        catch
        {

        }
    }

}
