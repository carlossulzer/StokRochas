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

public class MateriaisDAO
{
    public MateriaisDAO(){}
    public void Inserir(MateriaisDOM dados)
    {
        try
        {
            RegistroExiste(dados.DescMaterial, EOperacao.Incluir, 0);
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into materiais ");
            sql.Append("(descMaterial, codCor)");
            sql.Append(" values (");
            sql.Append(FormatarDados.Formatar(dados.DescMaterial) + ",");
            sql.Append(FormatarDados.Formatar(dados.CodCor) + ") ");
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Alterar(MateriaisDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update materiais ");
            sql.Append("set descMaterial = ");
            sql.Append(FormatarDados.Formatar(dados.DescMaterial) + ", ");
            sql.Append(" CodCor = ");
            sql.Append(FormatarDados.Formatar(dados.CodCor));
            sql.Append(" where codMaterial = " + dados.CodMaterial.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(MateriaisDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from materiais ");
            sql.Append(" where codMaterial = " + dados.CodMaterial.ToString());
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
            sqlMontada.Append(" select codMaterial, descMaterial, CodCor ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as CodMaterial, '<TODOS OS MATERIAIS>' as descMaterial");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codMaterial, descMaterial ");
        }
        else if (tipoDados.Equals(ETipoDados.Exportacao))
        {
            sqlMontada.Append(" Select -1 as CodMaterial, '<SELECIONE O MATERIAL>' as descMaterial, -1 as CodCor");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codMaterial, descMaterial, CodCor ");
        }
        sqlMontada.Append("from materiais ");
        return sqlMontada;
    }
    public MateriaisDOM Buscar(int codigo)
    {
        MateriaisDOM dados = new MateriaisDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(ETipoDados.Geral).ToString());
            sql.Append(" where codMaterial = " + codigo.ToString());
            sql.Append(" order by descMaterial ");
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodMaterial = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodMaterial"].ToString());
                dados.DescMaterial = dsDados.Tables[0].Rows[0]["DescMaterial"].ToString();
                dados.CodCor = (string.IsNullOrEmpty(dsDados.Tables[0].Rows[0]["CodCor"].ToString())) ? -1 : Conversor.ConverterParaInteiro(dsDados.Tables[0].Rows[0]["CodCor"].ToString());
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
                nome = nome.ToUpper();
                if (tipoConsulta.Equals(ETipoConsulta.Iniciando))
                    sql.Append(" where descMaterial like " + FormatarDados.Formatar(nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Contendo))
                    sql.Append(" where descMaterial like " + FormatarDados.Formatar("%" + nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Terminando))
                    sql.Append(" where descMaterial like " + FormatarDados.Formatar("%" + nome));
            }
            sql.Append(" order by descMaterial ");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet MateriaisdoFornecedor(string codFornecedor, string codCor, string codTipoProduto, string codEspessura)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Select -1 as CodMaterial, '<SELECIONE O MATERIAL>' as descMaterial");
            sql.Append(" Union ");
            sql.Append(" select materiais.codMaterial, materiais.descMaterial ");
            sql.Append(" from produtos, materiais ");
            sql.Append(" where produtos.codMaterial = materiais.codMaterial ");
            if (!codFornecedor.Equals("-1"))
                sql.Append(" and produtos.codCliente = " + codFornecedor.ToString());
            if (!codCor.Equals("-1"))
                sql.Append(" and produtos.codcor = " + codCor.ToString());
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

    public void RegistroExiste(string descricao, EOperacao operacao, int codigoOriginal)
    {
        bool existente = false;
        string sql = "Select codMaterial from materiais where descMaterial = " + FormatarDados.Formatar(descricao);
        AcessoaBancoDados dados = new AcessoaBancoDados();
        int codigo = dados.ObterValorInteiro(sql);
        if (operacao.Equals(EOperacao.Alterar))
        {
            if (codigoOriginal.Equals(codigo) || codigoOriginal.Equals(0))
                existente = false;
            else
                existente = true;
        }
        else if (operacao.Equals(EOperacao.Incluir) && !codigoOriginal.Equals(codigo))
            existente = true;

        if (existente)
            throw new Exception("Descrição do Material já Cadastrada");
    }
}