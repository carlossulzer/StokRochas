using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for FornecedoresCTL
/// </summary>
public class ProdutosCTL
{
    public ProdutosCTL(){}
    public DataSet Listar(string codFornecedor, string codCor, string codEspessura, string tipoProduto, string codMaterial)
    {
        try
        {
            ProdutosDAO produtosDAO = new ProdutosDAO();
            return produtosDAO.Listar(codFornecedor, codCor, codEspessura, tipoProduto, codMaterial);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public ProdutosDOM Buscar(int codFornecedor, int codProduto)
    {
        try
        {
            ProdutosDAO produtosDAO = new ProdutosDAO();
            return produtosDAO.Buscar(codFornecedor, codProduto);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

}
