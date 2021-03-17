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

public class CategoriasDAO
{
    public CategoriasDAO() { }
    public void Inserir(CategoriasDOM dados)
    {
        try
        {
            RegistroExiste(dados.DescCategoria, EOperacao.Incluir, 0);
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into categorias ");
            sql.Append("(DescCategoria)");
            sql.Append(" values (");
            sql.Append(FormatarDados.Formatar(dados.DescCategoria)+ ") ");
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Alterar(CategoriasDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update categorias ");
            sql.Append("set DescCategoria = ");
            sql.Append(FormatarDados.Formatar(dados.DescCategoria));
            sql.Append(" where codCategoria = " + dados.CodCategoria.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(CategoriasDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from categorias ");
            sql.Append(" where codCategoria = " + dados.CodCategoria.ToString());
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
            sqlMontada.Append(" select codCategoria, descCategoria ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as codCategoria, '<SELECIONE A CATEGORIA>' as descCategoria");
            sqlMontada.Append(" Union ");
            sqlMontada.Append(" select codCategoria, descCategoria ");
        }
        sqlMontada.Append("from categorias ");
        return sqlMontada;
    }
    public CategoriasDOM Buscar(int codigo)
    {
        CategoriasDOM dados = new CategoriasDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL(ETipoDados.Geral).ToString());
            sql.Append(" where codCategoria = " + codigo.ToString());
            sql.Append(" order by descCategoria ");
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodCategoria = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodCategoria"].ToString());
                dados.DescCategoria = dsDados.Tables[0].Rows[0]["DescCategoria"].ToString();
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
            sql.Append(" order by descCategoria ");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void RegistroExiste(string descCategoria, EOperacao operacao, int codigoOriginal)
    {
        bool existente = false;
        string sql = "Select codCategoria from categorias where descCategoria = " + FormatarDados.Formatar(descCategoria);
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
            throw new Exception("Categoria já Cadastrada.");
    }


    public DataSet CategoriasFornecedor(int codCategoria)
    {
        StringBuilder sqlMontada = new StringBuilder();

        sqlMontada.Append(" SELECT ");
        sqlMontada.Append(" clientes.NomeFantasia, CONCAT(clientes.telefone1,IF(clientes.telefone2 = '','',' / '), clientes.telefone2) AS telefones, ");
        sqlMontada.Append(" LOWER(CONCAT(clientes.email, IF(clientes.email2 = '','',' <br> '), clientes.email2)) AS emails, CONCAT(clientes.enderecoCom,', ',clientes.bairroCom,', ', "); 
        sqlMontada.Append(" clientes.cidadeCom, ', ',clientes.ufCom,', CEP: ', clientes.cepCom) AS endcliente, clientes.logotipo, ");
        sqlMontada.Append(" clientes.observacao, LOWER(clientes.site) as sitecli ");
        sqlMontada.Append(" FROM clientes ");
        sqlMontada.Append(" WHERE clientes.codCategoria = "+codCategoria);
        return AcessoaBancoDados.BuscaDados(sqlMontada.ToString());
    }

    public DataSet CategoriasMenu()
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select codCategoria, descCategoria from categorias ");
            sql.Append(" where categorias.codCategoria in (select clientes.codCategoria from clientes)");
            sql.Append(" order by descCategoria ");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }



}