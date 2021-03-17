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
public class TiposdeProdutosDAO
{
    public TiposdeProdutosDAO(){}
    public void Inserir(TiposdeProdutosDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into tiposdeprodutos ");
            sql.Append("(descTipo)");
            sql.Append(" values (");

            sql.Append(FormatarDados.Formatar(dados.DescTipo) + ") ");

            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Alterar(TiposdeProdutosDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update tiposdeprodutos ");
            sql.Append("set descTipo = ");
            sql.Append(FormatarDados.Formatar(dados.DescTipo));
            sql.Append(" where codTipo = " + dados.CodTipo.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(TiposdeProdutosDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from tipodeprodutos ");
            sql.Append(" where codTipo = " + dados.CodTipo.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public StringBuilder MontarSQL(ETipoDados tipoDados)
    {
        StringBuilder sqlMontada = new StringBuilder();
        if (tipoDados.Equals(ETipoDados.Geral))
            sqlMontada.Append("select codTipo, descTipo ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as codTipo, '<TODOS OS TIPOS DE PRODUTOS>' as descTipo");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codTipo, descTipo ");
        }
        else if (tipoDados.Equals(ETipoDados.Exportacao))
        {
            sqlMontada.Append(" Select -1 as codTipo, '<SELECIONE O TIPO DO PRODUTO>' as descTipo");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codTipo, descTipo ");
        }
        sqlMontada.Append(" from tiposdeprodutos ");
        return sqlMontada;
    }
    public TiposdeProdutosDOM Buscar(int codigo)
    {
        TiposdeProdutosDOM dados = new TiposdeProdutosDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(ETipoDados.Geral).ToString());
            sql.Append(" where codTipo = " + codigo.ToString());
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodTipo = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodTipo"].ToString());
                dados.DescTipo = dsDados.Tables[0].Rows[0]["DescTipo"].ToString();
            }
            return dados;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet Listar(string nome, ETipoConsulta tipoConsulta, ETipoDados tipoDados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(tipoDados).ToString());
            if (!nome.Equals(string.Empty))
            {
                if (tipoConsulta.Equals(ETipoConsulta.Iniciando))
                    sql.Append(" where descTipo like " + FormatarDados.Formatar(nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Contendo))
                    sql.Append(" where descTipo like " + FormatarDados.Formatar("%" + nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Terminando))
                    sql.Append(" where descTipo like " + FormatarDados.Formatar("%" + nome));
            }
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet TipoMateriaisdoFornecedor(string codFornecedor, string codCor, string codMaterial, string codEspessura)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Select -1 as codTipo, '<SELECIONE O TIPO DE PRODUTO>' as descTipo");
            sql.Append(" Union ");
            sql.Append(" select tiposdeprodutos.codTipo, tiposdeprodutos.descTipo ");
            sql.Append(" from produtos, tiposdeprodutos ");
            sql.Append(" where produtos.codTipo = tiposdeprodutos.codTipo ");
            if (!codFornecedor.Equals("-1"))
                sql.Append(" and produtos.codCliente = " + codFornecedor.ToString());
            if (!codCor.Equals("-1"))
                sql.Append(" and produtos.codcor = " + codCor.ToString());
            if (!codMaterial.Equals("-1"))
                sql.Append(" and produtos.codMaterial = " + codMaterial.ToString());
            if (!codEspessura.Equals("-1"))
                sql.Append(" and produtos.codEspessura = " + codEspessura.ToString());
            sql.Append(" order by 2");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}