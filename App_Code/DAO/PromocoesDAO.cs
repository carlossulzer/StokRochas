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

public class PromocoesDAO
{
    public PromocoesDAO() { }

    public DataSet PromocoesProdutos(int codFornecedor)
    {
        StringBuilder sql = new StringBuilder();
        sql.Append(" SELECT ");
        sql.Append("   promocoes.CodCliente, promocoes.CodMaterial, promocoes.nomeProduto, ");
        sql.Append("   cores.NomeCorPor, espessuras.descEspessura, tiposdeprodutos.desctipo, ");
        sql.Append("   promocoes.medidaBruta, promocoes.medidaLiquida, promocoes.observacao, ");
        sql.Append("   promocoes.quantidade, promocoes.valor, promocoes.dataValidade, ");
        sql.Append("   promocoes.Unidade, promocoes.CodPromocaoAccess ");
        sql.Append(" FROM promocoes, cores, espessuras, tiposdeprodutos ");
        sql.Append(" WHERE promocoes.codCliente = " + codFornecedor+" and");
        sql.Append("       promocoes.CodCor = cores.CodCor and");
        sql.Append("       promocoes.CodEspessura = espessuras.CodEspessura and");
        sql.Append("       promocoes.CodTipo = tiposdeprodutos.CodTipo ");
        //sql.Append("      and promocoes.dataValidade >= "+FormatarDados.Formatar(DateTime.Now.Date));
        return AcessoaBancoDados.BuscaDados(sql.ToString());
    }    
   
    public PromocoesDOM PromocoesFornecedor(int codFornecedor)
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

        PromocoesDOM promocoesDOM = new PromocoesDOM();


        if (dsFornecedor.Tables[0].Rows.Count > 0 )
        {
            promocoesDOM.CodCliente = Conversor.ConverterParaInteiro(dsFornecedor.Tables[0].Rows[0]["codCliente"].ToString());
            promocoesDOM.NomeFantasia = dsFornecedor.Tables[0].Rows[0]["nomeFantasia"].ToString();
            promocoesDOM.EndCliente = dsFornecedor.Tables[0].Rows[0]["endCliente"].ToString();
            promocoesDOM.Telefones = dsFornecedor.Tables[0].Rows[0]["telefones"].ToString();
            promocoesDOM.Emails = dsFornecedor.Tables[0].Rows[0]["emails"].ToString();
            promocoesDOM.SiteCli = dsFornecedor.Tables[0].Rows[0]["siteCli"].ToString();
            promocoesDOM.Observacao = dsFornecedor.Tables[0].Rows[0]["observacao"].ToString();
            promocoesDOM.Logotipo = dsFornecedor.Tables[0].Rows[0]["logotipo"].ToString();
        }

        return promocoesDOM;
    }

    public DataSet PromocoesMenu(int codFornecedor)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select clientes.codCliente, clientes.nomeFantasia from clientes ");
            sql.Append(" where exists (select * from promocoes where promocoes.codCliente = clientes.codcliente)");
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