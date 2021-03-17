using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public class ClientesCTL
{
    public ClientesCTL() { }
    public void ManterDados(ClientesDOM dados, EOperacao operacao)
    {
        try
        {
            ClientesDAO clientesDAO = new ClientesDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                clientesDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                clientesDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                clientesDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message);
        }
    }


    public ClientesDOM Buscar(int codigo)
    {
        try
        {
            ClientesDAO clientesDAO = new ClientesDAO();
            return clientesDAO.Buscar(codigo);

        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message);
        }
    }


    public ClientesDOM BuscarEnderecoCliente(int codigo)
    {
        try
        {
            ClientesDAO clientesDAO = new ClientesDAO();
            return clientesDAO.BuscarEndereco(codigo);

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
            ClientesDAO clientesDAO = new ClientesDAO();
            return clientesDAO.Listar(nome, tipo);

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
            ClientesDAO clientesDAO = new ClientesDAO();
            return clientesDAO.ClientesGeraSenhas();

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
            ClientesDAO clientesDAO = new ClientesDAO();
            clientesDAO.AlterarSenha(codigoCliente, senha);

        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message);
        }
    }
}
