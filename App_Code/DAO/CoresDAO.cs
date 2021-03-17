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
public class CoresDAO
{
    public CoresDAO(){}
    public void Inserir(CoresDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into cores ");
            sql.Append("(nomeCorPor, nomeCorIng, nomeCorEsp)");
            sql.Append(" values (");
            sql.Append(FormatarDados.Formatar(dados.NomeCorPor) + ", ");
            sql.Append(FormatarDados.Formatar(dados.NomeCorIng) + ", ");
            sql.Append(FormatarDados.Formatar(dados.NomeCorEsp) + ") ");
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void Alterar(CoresDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update cores ");
            sql.Append("set nomeCorPor = ");
            sql.Append(FormatarDados.Formatar(dados.NomeCorPor) + ", ");
            sql.Append(" nomeCorIng = ");
            sql.Append(FormatarDados.Formatar(dados.NomeCorIng) + ", ");
            sql.Append(" nomeCorEsp = ");
            sql.Append(FormatarDados.Formatar(dados.NomeCorEsp));
            sql.Append(" where codCor = " + dados.CodCor.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(CoresDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from cores ");
            sql.Append(" where codCor = " + dados.CodCor.ToString());
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
            sqlMontada.Append(" select codCor, nomeCorPor, nomeCorIng, nomeCorEsp ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as CodCor, '<TODAS AS CORES>' as NomeCor");
            sqlMontada.Append(" Union ");
            if (Idioma.IdiomaAtual.Equals(EIdioma.Portugues))
                sqlMontada.Append(" select codCor, nomeCorPor as NomeCor ");
            else if (Idioma.IdiomaAtual.Equals(EIdioma.Ingles))
                sqlMontada.Append(" select codCor, nomeCorIng as NomeCor ");
            else if (Idioma.IdiomaAtual.Equals(EIdioma.Espanhol))
                sqlMontada.Append(" select codCor, nomeCorEsp as NomeCor");
        }
        else if (tipoDados.Equals(ETipoDados.Exportacao))
        {
            sqlMontada.Append(" Select -1 as CodCor, '<SELECIONE A COR>' as NomeCorPor, '<SELECIONE A COR>' as NomeCorIng, '<SELECIONE A COR>' as NomeCorEsp");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codCor, nomeCorPor, nomeCorIng, nomeCorEsp ");
        }
        sqlMontada.Append("from cores ");
        return sqlMontada;
    }
    public CoresDOM Buscar(int codigo)
    {
        CoresDOM dados = new CoresDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(ETipoDados.Geral).ToString());
            sql.Append(" where codCor = " + codigo.ToString());
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodCor = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodCor"].ToString());
                dados.NomeCorPor = dsDados.Tables[0].Rows[0]["NomeCorPor"].ToString();
                dados.NomeCorIng = dsDados.Tables[0].Rows[0]["NomeCorIng"].ToString();
                dados.NomeCorEsp = dsDados.Tables[0].Rows[0]["NomeCorEsp"].ToString();
            }
            return dados;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet Listar(string nome, ETipoConsulta tipoConsulta, EIdioma idioma, ETipoDados tipoDados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(tipoDados).ToString());

            if (!nome.Equals(string.Empty))
            {
                string idiomaSelecionado = string.Empty;
                if (idioma.Equals(EIdioma.Portugues))
                    idiomaSelecionado = "nomeCorPor";
                else if (idioma.Equals(EIdioma.Ingles))
                    idiomaSelecionado = "nomeCorIng";
                else if (idioma.Equals(EIdioma.Espanhol))
                    idiomaSelecionado = "nomeCorEsp";
                if (tipoConsulta.Equals(ETipoConsulta.Iniciando))
                    sql.Append(" where " + idiomaSelecionado + " like " + FormatarDados.Formatar(nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Contendo))
                    sql.Append(" where " + idiomaSelecionado + " like " + FormatarDados.Formatar("%" + nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Terminando))
                    sql.Append(" where " + idiomaSelecionado + " like " + FormatarDados.Formatar("%" + nome));
            }
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet CoresdoFornecedor(string codFornecedor, string codMaterial, string codTipoProduto, string codEspessura)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Select -1 as CodCor, '<SELECIONE A COR>' as NomeCor");
            sql.Append(" Union ");
            if (Idioma.IdiomaAtual.Equals(EIdioma.Portugues))
                sql.Append(" select distinct cores.codCor, cores.nomeCorPor as NomeCor ");
            else if (Idioma.IdiomaAtual.Equals(EIdioma.Ingles))
                sql.Append(" select distinct cores.codCor, cores.nomeCorIng as NomeCor ");
            else if (Idioma.IdiomaAtual.Equals(EIdioma.Espanhol))
                sql.Append(" select distinct cores.codCor, cores.nomeCorEsp as NomeCor");
            sql.Append(" from produtos, cores ");
            sql.Append(" where produtos.codCor = cores.codCor ");
            if (!codFornecedor.Equals("-1"))
                sql.Append(" and produtos.codCliente = " + codFornecedor.ToString());
            if (!codMaterial.Equals("-1"))
                sql.Append(" and produtos.codMaterial = " + codMaterial.ToString());
            if (!codTipoProduto.Equals("-1"))
                sql.Append(" and produtos.codTipo = " + codTipoProduto.ToString());
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