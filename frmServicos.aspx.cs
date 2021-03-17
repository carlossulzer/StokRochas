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

public partial class frmServicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CategoriasCTL categoriasCTL = new CategoriasCTL();
            DataSet dsCategoria =  categoriasCTL.CategoriasMenu(ETipoDados.Geral);
            dlstCategorias.DataSource = dsCategoria;
            dlstCategorias.DataBind();

            if (dsCategoria.Tables[0].Rows.Count > 0)
            {
                int codigo =  Conversor.ConverterParaInteiro(dsCategoria.Tables[0].Rows[0][0].ToString());
                CarregarRegistro(codigo);
            }
            
        }

    }
    protected void lnkbtCategoria_Click(object sender, EventArgs e)
    {
        LinkButton ibtnCodigo = (LinkButton)sender;
        int codigo = Conversor.ConverterParaInteiro(ibtnCodigo.CommandArgument);
        CarregarRegistro(codigo);
    }

    public void CarregarRegistro(int codigo)
    {
        try
        {
            CategoriasCTL categoriasCTL = new CategoriasCTL();
            dtlServicos.DataSource = categoriasCTL.CategoriasFornecedor(codigo);
            dtlServicos.DataBind();

            lblCategoriaSelect.Text = categoriasCTL.Buscar(codigo).DescCategoria;
        }
        catch (Exception ex)
        {
            GravarExibirErro.Log(ex.Message.ToString(), this.Page);
        }
    }




}
