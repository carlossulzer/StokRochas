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
public class EspessurasDAO
{
    public EspessurasDAO(){}
    public void Inserir(EspessurasDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into espessuras ");
            sql.Append("(descEspessura, codTipo)");
            sql.Append(" values (");

            sql.Append(FormatarDados.Formatar(dados.DescEspessura) +", ");
            sql.Append(FormatarDados.Formatar(dados.CodTipo)+ ") ");

            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Alterar(EspessurasDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update espessuras ");
            sql.Append("set descEspessura = ");
            sql.Append(FormatarDados.Formatar(dados.DescEspessura));
            sql.Append(", codTipo = ");
            sql.Append(FormatarDados.Formatar(dados.CodTipo));
            sql.Append(" where codEspessura = " + dados.CodEspessura.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(EspessurasDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from espessuras ");
            sql.Append(" where codEspessura = " + dados.CodEspessura.ToString());
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
            sqlMontada.Append(" select espessuras.codEspessura, espessuras.descEspessura, tiposdeprodutos.DescTipo, tiposdeprodutos.CodTipo ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as CodEspessura, '<TODAS AS ESPESSURAS>' as descEspessura");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codEspessura, descEspessura ");
        }
        else if (tipoDados.Equals(ETipoDados.Exportacao))
        {
            sqlMontada.Append(" Select -1 as CodEspessura, '<SELECIONE A ESPESSURA>' as descEspessura");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codEspessura, descEspessura ");
        }
        sqlMontada.Append("from espessuras ");
        return sqlMontada;
    }
    public EspessurasDOM Buscar(int codigo)
    {
        EspessurasDOM dados = new EspessurasDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(ETipoDados.Geral).ToString());
            sql.Append(", tiposdeprodutos ");
            sql.Append(" where espessuras.codEspessura = " + codigo.ToString());
            sql.Append(" and espessuras.codTipo = tiposdeprodutos.codtipo ");

            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodEspessura = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodEspessura"].ToString());
                dados.DescEspessura = dsDados.Tables[0].Rows[0]["DescEspessura"].ToString();
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

            if (tipoDados.Equals(ETipoDados.Geral))
                sql.Append(", tiposdeprodutos ");


            if (!nome.Equals(string.Empty))
            {
                if (tipoDados.Equals(ETipoConsulta.Iniciando))
                    sql.Append(" where descEspessura like " + FormatarDados.Formatar(nome + "%"));
                else if (tipoDados.Equals(ETipoConsulta.Contendo))
                    sql.Append(" where descEspessura like " + FormatarDados.Formatar("%" + nome + "%"));
                else if (tipoDados.Equals(ETipoConsulta.Terminando))
                    sql.Append(" where descEspessura like " + FormatarDados.Formatar("%" + nome));

                if (tipoDados.Equals(ETipoDados.Geral))
                    sql.Append(" and espessuras.codTipo = tiposdeprodutos.codtipo ");
            }
            else if (tipoDados.Equals(ETipoDados.Geral))
                sql.Append(" where espessuras.codTipo = tiposdeprodutos.codtipo ");

            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet EspessurasdoFornecedor(string codFornecedor, string codCor, string codMaterial, string codTipoProduto)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Select -1 as CodEspessura, '<SELECIONE A ESPESSURA>' as descEspessura");
            sql.Append(" Union ");
            sql.Append(" select espessuras.codEspessura, espessuras.descEspessura ");
            sql.Append(" from produtos, espessuras ");
            sql.Append(" where produtos.codEspessura = espessuras.codEspessura ");
            if (!codFornecedor.Equals("-1"))
                sql.Append(" and produtos.codCliente = " + codFornecedor.ToString());
            if (!codCor.Equals("-1"))
                sql.Append(" and produtos.codcor = " + codCor.ToString());
            if (!codMaterial.Equals("-1"))
                sql.Append(" and produtos.codMaterial = " + codMaterial.ToString());
            if (!codTipoProduto.Equals("-1"))
                sql.Append(" and produtos.codTipo = " + codTipoProduto.ToString());
            sql.Append(" order by 1");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}