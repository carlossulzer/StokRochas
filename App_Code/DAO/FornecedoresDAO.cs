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
public class FornecedoresDAO
{
    public FornecedoresDAO(){}
    public StringBuilder MontarSQL(ETipoDados tipoDados)
    {
        StringBuilder sqlMontada = new StringBuilder();
        if (tipoDados.Equals(ETipoDados.Geral))
            //sqlMontada.Append("select codcliente, nomeFantasia, telefone1, telefone2, site, logotipo, EnderecoCom, BairroCom, CidadeCom, UfCom, CepCom ");
            sqlMontada.Append("select codcliente, logotipo ");
        else if (tipoDados.Equals(ETipoDados.DropDown))
        {
            sqlMontada.Append(" Select -1 as CodCliente, '<TODOS OS FORNECEDORES>' as NomeFantasia");
            sqlMontada.Append(" Union ");
            sqlMontada.Append("select CodCliente, NomeFantasia ");
        }
        sqlMontada.Append("from clientes ");
        sqlMontada.Append("where ativo = 1 ");
        return sqlMontada;
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
                    sql.Append(" and nomeFantasia like " + FormatarDados.Formatar(nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Contendo))
                    sql.Append(" and nomeFantasia like " + FormatarDados.Formatar("%" + nome + "%"));
                else if (tipoConsulta.Equals(ETipoConsulta.Terminando))
                    sql.Append(" and nomeFantasia like " + FormatarDados.Formatar("%" + nome));
            }
            sql.Append(" order by nomeFantasia");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public string BuscaLogotipo(string codigo)
    {
        try
        {
            string logotipo = string.Empty;
            StringBuilder sql = new StringBuilder();
            sql.Append("select logotipo from clientes where codCliente = " + codigo.ToString());
            DataSet dsCliente = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsCliente.Tables[0].Rows.Count > 0)
                logotipo = dsCliente.Tables[0].Rows[0]["logotipo"].ToString();
            return logotipo;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet FiltrarFornecedores(string codCor, string codMaterial, string codTipoProduto, string codEspessura)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Select -1 as CodCliente, '<TODOS OS FORNECEDORES>' as NomeFantasia");
            sql.Append(" Union ");
            sql.Append(" select clientes.codCliente, clientes.NomeFantasia ");
            sql.Append(" from produtos, clientes ");
            sql.Append(" where produtos.codCliente = clientes.codCliente and ");
            sql.Append("       clientes.ativo = 1 ");
            if (!codCor.Equals("-1"))
                sql.Append(" and produtos.codcor = " + codCor.ToString());
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