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

public class LancamentosDAO
{
    public LancamentosDAO() { }

    public DataSet LancamentosProdutos(int codFornecedor)
    {
        StringBuilder sql = new StringBuilder();
        sql.Append(" SELECT ");
        sql.Append("   lancamentos.CodCliente, lancamentos.nomeProduto, ");
        sql.Append("   cores.NomeCorPor,  lancamentos.observacao, lancamentos.CodLancAccess ");
        sql.Append(" FROM lancamentos, cores ");
        sql.Append(" WHERE lancamentos.codCliente = " + codFornecedor+" and");
        sql.Append("       lancamentos.CodCor = cores.CodCor ");
        return AcessoaBancoDados.BuscaDados(sql.ToString());
    }

    public LancamentosDOM LancamentosFornecedor(int codFornecedor)
    {
        StringBuilder sqlMontada = new StringBuilder();
        sqlMontada.Append(" SELECT clientes.codCliente, ");
        sqlMontada.Append(" clientes.NomeFantasia, CONCAT(clientes.telefone1,IF(clientes.telefone2 = '','',' / '), clientes.telefone2) AS telefones, ");
        sqlMontada.Append(" LOWER(CONCAT(clientes.email, IF(clientes.email2 = '','',' <br> '), clientes.email2)) AS emails, CONCAT(clientes.enderecoCom,', ',clientes.bairroCom,', ', "); 
        sqlMontada.Append(" clientes.cidadeCom, ', ',clientes.ufCom,', CEP: ', clientes.cepCom) AS endcliente, clientes.logotipo, ");
        sqlMontada.Append(" clientes.observacao, LOWER(clientes.site) as sitecli ");
        sqlMontada.Append(" FROM clientes ");
        sqlMontada.Append(" WHERE clientes.codCliente = "+codFornecedor);

        DataSet dsFornecedor = AcessoaBancoDados.BuscaDados(sqlMontada.ToString());

        LancamentosDOM lancamentosDOM = new LancamentosDOM();


        if (dsFornecedor.Tables[0].Rows.Count > 0 )
        {
            lancamentosDOM.CodCliente = Conversor.ConverterParaInteiro(dsFornecedor.Tables[0].Rows[0]["codCliente"].ToString());
            lancamentosDOM.NomeFantasia = dsFornecedor.Tables[0].Rows[0]["nomeFantasia"].ToString();
            lancamentosDOM.EndCliente = dsFornecedor.Tables[0].Rows[0]["endCliente"].ToString();
            lancamentosDOM.Telefones = dsFornecedor.Tables[0].Rows[0]["telefones"].ToString();
            lancamentosDOM.Emails = dsFornecedor.Tables[0].Rows[0]["emails"].ToString();
            lancamentosDOM.SiteCli = dsFornecedor.Tables[0].Rows[0]["siteCli"].ToString();
            lancamentosDOM.Observacao = dsFornecedor.Tables[0].Rows[0]["observacao"].ToString();
            lancamentosDOM.Logotipo = dsFornecedor.Tables[0].Rows[0]["logotipo"].ToString();
        }

        return lancamentosDOM;
    }

    public DataSet LancamentosMenu(int codFornecedor)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select clientes.codCliente, clientes.nomeFantasia from clientes ");
            sql.Append(" where exists (select * from lancamentos where lancamentos.codCliente = clientes.codcliente)");
            if (codFornecedor > 0)
                sql.Append(" and clientes.codCliente = " + codFornecedor.ToString());

            sql.Append(" order by clientes.nomeFantasia ");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }



}