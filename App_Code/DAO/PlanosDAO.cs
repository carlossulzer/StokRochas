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

public class PlanosDAO
{

    public void Inserir(PlanosDOM dados)
    {
        try
        {
            RegistroExiste(dados.De, dados.Ate, EOperacao.Incluir, 0);
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into planos ");
            sql.Append("(de, ate, valor)");
            sql.Append(" values (");
            sql.Append(FormatarDados.Formatar(dados.De) + ",");
            sql.Append(FormatarDados.Formatar(dados.Ate) + ",");
            sql.Append(FormatarDados.Formatar(dados.Valor) + ") ");
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Alterar(PlanosDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update planos ");
            sql.Append("set de = ");
            sql.Append(FormatarDados.Formatar(dados.De) + ", ");
            sql.Append(" ate = ");
            sql.Append(FormatarDados.Formatar(dados.Ate));
            sql.Append(" valor = ");
            sql.Append(FormatarDados.Formatar(dados.Valor));
            sql.Append(" where codPlano = " + dados.CodPlano.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(PlanosDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from planos ");
            sql.Append(" where codPlano = " + dados.CodPlano.ToString());
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
            sqlMontada.Append(" select codPlano, de, ate, valor ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as CodPlano, '<SELECIONE O PLANO>' as descPlano ");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codPlano, ");
            sqlMontada.Append("    CONCAT(CAST(LPAD(de,3,'000') AS CHAR(3)),' a ', CAST(LPAD(ate,3,'000') AS CHAR(3)),' - ','(R$ ', CAST(FORMAT(valor,2) AS CHAR) ,')') AS descPlano  ");
        }
        sqlMontada.Append("from planos ");
        return sqlMontada;
    }
    public PlanosDOM Buscar(int codigo)
    {
        PlanosDOM dados = new PlanosDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(ETipoDados.Geral).ToString());
            sql.Append(" where codPlano = " + codigo.ToString());
            //sql.Append(" order by 2 ");
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodPlano = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodPlano"].ToString());
                dados.De = Convert.ToInt32(dsDados.Tables[0].Rows[0]["De"].ToString());
                dados.Ate = Convert.ToInt32(dsDados.Tables[0].Rows[0]["Ate"].ToString());
                dados.Valor = Convert.ToDouble(dsDados.Tables[0].Rows[0]["Valor"].ToString());
            }
            return dados;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet Listar(ETipoDados tipoDados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(tipoDados).ToString());
            sql.Append(" order by 2 ");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void RegistroExiste(int de, int ate, EOperacao operacao, int codigoOriginal)
    {
        bool existente = false;
        string sql = "Select codPlano from planos where de = " + FormatarDados.Formatar(de) + " and ate = " + FormatarDados.Formatar(ate);
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
            throw new Exception("Plano já Cadastrado.");
    }
}