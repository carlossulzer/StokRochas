using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public class EspessurasCTL
{
    public EspessurasCTL(){}
    public void ManterDados(EspessurasDOM dados, EOperacao operacao)
    {
        try
        {
            EspessurasDAO espessurasDAO = new EspessurasDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                espessurasDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                espessurasDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                espessurasDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public EspessurasDOM Buscar(int codigo)
    {
        try
        {
            EspessurasDAO espessurasDAO = new EspessurasDAO();
            return espessurasDAO.Buscar(codigo);
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
            EspessurasDAO espessurasDAO = new EspessurasDAO();
            return espessurasDAO.Listar(nome, tipoConsulta, tipoDados);
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
            EspessurasDAO espessurasDAO = new EspessurasDAO();
            return espessurasDAO.EspessurasdoFornecedor(codFornecedor, codCor, codMaterial, codTipoProduto);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
