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

public class ClientesDAO
{
    public ClientesDAO(){}
    public void Inserir(ClientesDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into clientes ");
            sql.Append("(razaoSocial, nomeFantasia, Cnpj, email, email2, telefone1, telefone2, EnderecoCom, BairroCom, CidadeCom, UfCom, CepCom, ");
            sql.Append(" EnderecoCob, BairroCob, CidadeCob, UfCob, CepCob, ativo, login, anuncio, validade, site, logotipo, movEstoque, ");
            sql.Append(" codCategoria, codPlano, numProdPromocao, numProdLancamento, observacao)");
            sql.Append(" values (");
            sql.Append(FormatarDados.Formatar(dados.RazaoSocial) + ", ");
            sql.Append(FormatarDados.Formatar(dados.NomeFantasia) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Cnpj) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Email) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Email2) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Telefone1) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Telefone2) + ", ");
            sql.Append(FormatarDados.Formatar(dados.EnderecoCom) + ", ");
            sql.Append(FormatarDados.Formatar(dados.BairroCom) + ", ");
            sql.Append(FormatarDados.Formatar(dados.CidadeCom) + ", ");
            sql.Append(FormatarDados.Formatar(dados.UfCom) + ", ");
            sql.Append(FormatarDados.Formatar(dados.CepCom) + ", ");
            sql.Append(FormatarDados.Formatar(dados.EnderecoCob) + ", ");
            sql.Append(FormatarDados.Formatar(dados.BairroCob) + ", ");
            sql.Append(FormatarDados.Formatar(dados.CidadeCob) + ", ");
            sql.Append(FormatarDados.Formatar(dados.UfCob) + ", ");
            sql.Append(FormatarDados.Formatar(dados.CepCob) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Ativo) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Login) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Anuncio) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Validade) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Site) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Logotipo) + ", ");
            sql.Append(FormatarDados.Formatar(dados.MovEstoque) + ", ");
            sql.Append(FormatarDados.Formatar(dados.CodCategoria) + ", ");
            sql.Append(FormatarDados.Formatar(dados.CodPlano) + ", ");
            sql.Append(FormatarDados.Formatar(dados.NumProdPromocao) + ", ");
            sql.Append(FormatarDados.Formatar(dados.NumProdLancamento) + ", ");
            sql.Append(FormatarDados.Formatar(dados.Observacao) + ") ");
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Alterar(ClientesDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update clientes ");
            sql.Append("set razaoSocial = ");
            sql.Append(FormatarDados.Formatar(dados.RazaoSocial) + ", ");
            sql.Append(" nomeFantasia = ");
            sql.Append(FormatarDados.Formatar(dados.NomeFantasia) + ", ");
            sql.Append(" Cnpj = ");
            sql.Append(FormatarDados.Formatar(dados.Cnpj) + ", ");
            sql.Append(" email = ");
            sql.Append(FormatarDados.Formatar(dados.Email) + ", ");
            sql.Append(" email2 = ");
            sql.Append(FormatarDados.Formatar(dados.Email2) + ", ");
            sql.Append(" telefone1 = ");
            sql.Append(FormatarDados.Formatar(dados.Telefone1) + ", ");
            sql.Append(" telefone2 = ");
            sql.Append(FormatarDados.Formatar(dados.Telefone2) + ", ");
            sql.Append(" enderecoCom = ");
            sql.Append(FormatarDados.Formatar(dados.EnderecoCom) + ", ");
            sql.Append(" bairroCom = ");
            sql.Append(FormatarDados.Formatar(dados.BairroCom) + ", ");
            sql.Append(" cidadeCom = ");
            sql.Append(FormatarDados.Formatar(dados.CidadeCom) + ", ");
            sql.Append(" ufCom = ");
            sql.Append(FormatarDados.Formatar(dados.UfCom) + ", ");
            sql.Append(" cepCom = ");
            sql.Append(FormatarDados.Formatar(dados.CepCom) + ", ");
            sql.Append(" enderecoCob = ");
            sql.Append(FormatarDados.Formatar(dados.EnderecoCob) + ", ");
            sql.Append(" bairroCob = ");
            sql.Append(FormatarDados.Formatar(dados.BairroCob) + ", ");
            sql.Append(" cidadeCob = ");
            sql.Append(FormatarDados.Formatar(dados.CidadeCob) + ", ");
            sql.Append(" ufCob = ");
            sql.Append(FormatarDados.Formatar(dados.UfCob) + ", ");
            sql.Append(" cepCob = ");
            sql.Append(FormatarDados.Formatar(dados.CepCob) + ", ");
            sql.Append(" ativo = ");
            sql.Append(FormatarDados.Formatar(dados.Ativo) + ", ");
            sql.Append(" login = ");
            sql.Append(FormatarDados.Formatar(dados.Login) + ", ");
            sql.Append(" anuncio = ");
            sql.Append(FormatarDados.Formatar(dados.Anuncio) + ", ");
            sql.Append(" validade = ");
            sql.Append(FormatarDados.Formatar(dados.Validade) + ", ");
            sql.Append(" site = ");
            sql.Append(FormatarDados.Formatar(dados.Site) + ", ");
            sql.Append(" logotipo = ");
            sql.Append(FormatarDados.Formatar(dados.Logotipo) + ", ");
            sql.Append(" movEstoque = ");
            sql.Append(FormatarDados.Formatar(dados.MovEstoque) + ", ");
            sql.Append(" codCategoria = ");
            sql.Append(FormatarDados.Formatar(dados.CodCategoria) + ", ");
            sql.Append(" codPlano = ");
            sql.Append(FormatarDados.Formatar(dados.CodPlano) + ", ");
            sql.Append(" numProdPromocao = ");
            sql.Append(FormatarDados.Formatar(dados.NumProdPromocao) + ", ");
            sql.Append(" numProdLancamento = ");
            sql.Append(FormatarDados.Formatar(dados.NumProdLancamento) + ", ");
            sql.Append(" observacao = ");
            sql.Append(FormatarDados.Formatar(dados.Observacao));
            sql.Append(" where codCliente = " + dados.CodCliente.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public void Excluir(ClientesDOM dados)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from clientes ");
            sql.Append(" where codCliente = " + dados.CodCliente.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public StringBuilder MontarSQL()
    {
        StringBuilder sqlMontada = new StringBuilder();
        sqlMontada.Append(" select codcliente,razaoSocial, nomeFantasia, Cnpj, email, email2, telefone1, telefone2, EnderecoCom, BairroCom, ");
        sqlMontada.Append(" CidadeCom, UfCom, CepCom, EnderecoCob, BairroCob, CidadeCob, UfCob, CepCob, ");
        sqlMontada.Append(" ativo, login, anuncio, validade, site, logotipo, movEstoque, ");
        sqlMontada.Append(" codCategoria, codPlano, numProdPromocao, numProdLancamento, observacao ");
        sqlMontada.Append(" from clientes ");
        return sqlMontada;
    }
    public ClientesDOM Buscar(int codigo)
    {
        ClientesDOM dados = new ClientesDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL().ToString());
            sql.Append(" where codCliente = " + codigo.ToString());
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodCliente = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodCliente"].ToString());
                dados.RazaoSocial = dsDados.Tables[0].Rows[0]["RazaoSocial"].ToString();
                dados.NomeFantasia = dsDados.Tables[0].Rows[0]["NomeFantasia"].ToString();
                dados.Cnpj = dsDados.Tables[0].Rows[0]["Cnpj"].ToString();
                dados.Email = dsDados.Tables[0].Rows[0]["Email"].ToString();
                dados.Email2 = dsDados.Tables[0].Rows[0]["Email2"].ToString();
                dados.Telefone1 = dsDados.Tables[0].Rows[0]["Telefone1"].ToString();
                dados.Telefone2 = dsDados.Tables[0].Rows[0]["Telefone2"].ToString();
                dados.EnderecoCom = dsDados.Tables[0].Rows[0]["EnderecoCom"].ToString();
                dados.BairroCom = dsDados.Tables[0].Rows[0]["BairroCom"].ToString();
                dados.CidadeCom = dsDados.Tables[0].Rows[0]["CidadeCom"].ToString();
                dados.UfCom = dsDados.Tables[0].Rows[0]["UfCom"].ToString();
                dados.CepCom = dsDados.Tables[0].Rows[0]["CepCom"].ToString();
                dados.EnderecoCob = dsDados.Tables[0].Rows[0]["EnderecoCob"].ToString();
                dados.BairroCob = dsDados.Tables[0].Rows[0]["BairroCob"].ToString();
                dados.CidadeCob = dsDados.Tables[0].Rows[0]["CidadeCob"].ToString();
                dados.UfCob = dsDados.Tables[0].Rows[0]["UfCob"].ToString();
                dados.CepCob = dsDados.Tables[0].Rows[0]["CepCob"].ToString();
                dados.Ativo = (dsDados.Tables[0].Rows[0]["ativo"].ToString() == "True" ? 1 : 0);
                dados.Login = dsDados.Tables[0].Rows[0]["login"].ToString();
                dados.Anuncio = (dsDados.Tables[0].Rows[0]["anuncio"].ToString() == "True" ? 1 : 0);
                dados.Validade = Conversor.ConverterParaDateTime(dsDados.Tables[0].Rows[0]["validade"].ToString());
                dados.Site = dsDados.Tables[0].Rows[0]["site"].ToString();
                dados.Logotipo = dsDados.Tables[0].Rows[0]["logotipo"].ToString();
                dados.MovEstoque = (dsDados.Tables[0].Rows[0]["movEstoque"].ToString() == "True" ? 1 : 0);
                dados.CodCategoria = Conversor.ConverterParaInteiro(dsDados.Tables[0].Rows[0]["CodCategoria"].ToString());
                dados.CodPlano = Conversor.ConverterParaInteiro(dsDados.Tables[0].Rows[0]["CodPlano"].ToString());
                dados.NumProdPromocao = Conversor.ConverterParaInteiro(dsDados.Tables[0].Rows[0]["NumProdPromocao"].ToString());
                dados.NumProdLancamento = Conversor.ConverterParaInteiro(dsDados.Tables[0].Rows[0]["NumProdLancamento"].ToString());
                dados.Observacao = dsDados.Tables[0].Rows[0]["Observacao"].ToString();
            }
            return dados;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public ClientesDOM BuscarEndereco(int codigo)
    {
        ClientesDOM dados = new ClientesDOM();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select codcliente, nomeFantasia,email, email2, telefone1, telefone2, EnderecoCom, BairroCom, ");
            sql.Append("CidadeCom, UfCom, CepCom, site, logotipo, observacao ");
            sql.Append("from clientes ");
            sql.Append(" where codCliente = " + codigo.ToString());
            DataSet dsDados = AcessoaBancoDados.BuscaDados(sql.ToString());
            if (dsDados.Tables[0].Rows.Count > 0)
            {
                dados.CodCliente = Convert.ToInt32(dsDados.Tables[0].Rows[0]["CodCliente"].ToString());
                dados.NomeFantasia = dsDados.Tables[0].Rows[0]["NomeFantasia"].ToString();
                dados.Email = dsDados.Tables[0].Rows[0]["Email"].ToString();
                dados.Email = dsDados.Tables[0].Rows[0]["Email2"].ToString();
                dados.Telefone1 = dsDados.Tables[0].Rows[0]["Telefone1"].ToString();
                dados.Telefone2 = dsDados.Tables[0].Rows[0]["Telefone2"].ToString();
                dados.EnderecoCom = dsDados.Tables[0].Rows[0]["EnderecoCom"].ToString();
                dados.BairroCom = dsDados.Tables[0].Rows[0]["BairroCom"].ToString();
                dados.CidadeCom = dsDados.Tables[0].Rows[0]["CidadeCom"].ToString();
                dados.UfCom = dsDados.Tables[0].Rows[0]["UfCom"].ToString();
                dados.CepCom = dsDados.Tables[0].Rows[0]["CepCom"].ToString();
                dados.Site = dsDados.Tables[0].Rows[0]["site"].ToString();
                dados.Logotipo = dsDados.Tables[0].Rows[0]["logotipo"].ToString();
                dados.Observacao = dsDados.Tables[0].Rows[0]["Observacao"].ToString();
            }
            return dados;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet Listar(string nome, ETipoConsulta tipo)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(MontarSQL().ToString());

            if (!nome.Equals(string.Empty))
            {
                if (tipo.Equals(ETipoConsulta.Iniciando))
                    sql.Append(" where nomeFantasia like " + FormatarDados.Formatar(nome + "%"));
                else if (tipo.Equals(ETipoConsulta.Contendo))
                    sql.Append(" where nomeFantasia like " + FormatarDados.Formatar("%" + nome + "%"));
                else if (tipo.Equals(ETipoConsulta.Terminando))
                    sql.Append(" where nomeFantasia like " + FormatarDados.Formatar("%" + nome));
            }
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet ClientesGeraSenhas()
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select CodCliente, NomeFantasia, Email, Login from clientes ");
            return AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message);
        }
    }
    public void AlterarSenha(int codigoCliente, string senha)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update clientes ");

            sql.Append(" set senha = ");
            sql.Append(FormatarDados.Formatar(senha));

            sql.Append(" where codCliente = " + codigoCliente.ToString());
            AcessoaBancoDados.ManterDados(sql.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}