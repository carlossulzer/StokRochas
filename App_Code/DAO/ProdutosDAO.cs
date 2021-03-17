using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
public class ProdutosDAO
{
    public ProdutosDAO(){}
    public StringBuilder MontarSQL(string codFornecedor, string codCor, string codEspessura, string tipoProduto, string codMaterial)
    {
        StringBuilder sqlMontada = new StringBuilder();
        sqlMontada.Append("select produtos.CodProduto, produtos.NomeProduto, ");
        sqlMontada.Append("clientes.nomeFantasia, clientes.telefone1, clientes.telefone2, clientes.site, clientes.logotipo, ");
        sqlMontada.Append("cores.nomecorpor, cores.nomecoring, cores.nomecoresp, espessuras.descespessura, tiposdeprodutos.desctipo, ");
        sqlMontada.Append("produtos.Quantidade, clientes.codCliente ");
        sqlMontada.Append("from produtos, clientes, cores, espessuras, tiposdeprodutos ");
        sqlMontada.Append("where produtos.codCliente = clientes.codCliente and ");
        sqlMontada.Append(" produtos.codCor = cores.codCor and ");
        sqlMontada.Append(" produtos.codEspessura = espessuras.codEspessura and ");
        sqlMontada.Append(" produtos.codTipo = tiposdeprodutos.codTipo and ");
        sqlMontada.Append(" clientes.Ativo = 1 and clientes.movEstoque = 1 ");
        if (Conversor.ConverterParaInteiro(codFornecedor.Trim()) > 0)
            sqlMontada.Append(" and produtos.codCliente = " + codFornecedor.ToString());
        if (Conversor.ConverterParaInteiro(codCor.Trim()) > 0)
            sqlMontada.Append(" and produtos.codCor = " + codCor.ToString());
        if (Conversor.ConverterParaInteiro(codEspessura.Trim()) > 0)
            sqlMontada.Append(" and produtos.codEspessura = " + codEspessura.ToString());
        if (Conversor.ConverterParaInteiro(tipoProduto.Trim()) > 0)
            sqlMontada.Append(" and produtos.codTipo = " + tipoProduto.ToString());
        if (Conversor.ConverterParaInteiro(codMaterial.Trim()) > 0)
            sqlMontada.Append(" and produtos.codMaterial = " + codMaterial.ToString());
        sqlMontada.Append(" order by produtos.NomeProduto, clientes.nomeFantasia");
        return sqlMontada;
    }

    public DataSet Listar(string codFornecedor, string codCor, string codEspessura, string tipoProduto, string codMaterial)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(codFornecedor, codCor, codEspessura, tipoProduto, codMaterial).ToString());

            return AcessoaBancoDados.BuscaDados(sql.ToString());
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
            StringBuilder sql = new StringBuilder();
            sql.Append("select  produtos.NomeProduto, produtos.Quantidade, produtos.CodMaterial ");
            sql.Append("from produtos ");
            sql.Append("where produtos.codCliente = "+ codFornecedor.ToString()+" and ");
            sql.Append(" produtos.codProduto = " + codProduto.ToString());

            DataSet dsProduto = AcessoaBancoDados.BuscaDados(sql.ToString());

            ProdutosDOM produtosDOM = new ProdutosDOM();
            if (dsProduto.Tables[0].Rows.Count > 0)
            {
                produtosDOM.NomeProduto   = dsProduto.Tables[0].Rows[0][0].ToString();
                produtosDOM.Quantidade    = Conversor.ConverterParaInteiro(dsProduto.Tables[0].Rows[0][1].ToString());
                produtosDOM.CodMaterial = Conversor.ConverterParaInteiro(dsProduto.Tables[0].Rows[0][2].ToString());
            }

            return produtosDOM;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

}