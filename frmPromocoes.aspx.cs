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

public partial class frmPromocoes : System.Web.UI.Page
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
           
            PromocoesCTL promocoesCTL = new PromocoesCTL();
            DataSet dsPromocoes = promocoesCTL.PromocoesMenu(codFornecedor);
            dlstFornecedores.DataSource = dsPromocoes;
            dlstFornecedores.DataBind();

            if (dsPromocoes.Tables[0].Rows.Count > 0)
            {
                HabilitarDados(true);
                codFornecedor = Conversor.ConverterParaInteiro(dsPromocoes.Tables[0].Rows[0][0].ToString());
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
            PromocoesCTL promocoesCTL = new PromocoesCTL();
            dtlPromocoes.DataSource = promocoesCTL.PromocoesProdutos(codigo);
            dtlPromocoes.DataBind();

            PromocoesDOM promocoesDOM = promocoesCTL.PromocoesFornecedor(codigo);

            imgLogotipo.ImageUrl = "~/Logotipos/" + promocoesDOM.Logotipo;
            lblNomeFantasia.Text = promocoesDOM.NomeFantasia;
            lblEndCliente.Text = promocoesDOM.EndCliente;
            lblTelefones.Text = promocoesDOM.Telefones;
            lblEmails.Text = promocoesDOM.Emails;

            lblSiteCli.Text = promocoesDOM.SiteCli;
            linkSite.HRef = "http://" + promocoesDOM.SiteCli;

            lblObservacao.Text = promocoesDOM.Observacao;

            lblpromocoesSelect.Text = promocoesDOM.NomeFantasia;
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }

    public void HabilitarDados(Boolean status)
    {
        if (status == false)
            lblpromocoesSelect.Text = "Não existem promoções cadastradas.";
        
        divLogo.Visible = status;
        divFornecedor.Visible = status;
    }

    protected void dtlPromocoes_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {

            Image botaoImagem = (Image)e.Item.FindControl("ImagePeq");
            ImageButton botaoAmpliar = (ImageButton)e.Item.FindControl("IbtnAmpliar");

            string diretorio = System.AppDomain.CurrentDomain.BaseDirectory;
            string arquivo = botaoImagem.ImageUrl.Replace("~/Promocoes", "Promocoes");
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

        CarregarPromocao(imagem, produto);
    }


    public void CarregarPromocao(string imagem, string produto)
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
