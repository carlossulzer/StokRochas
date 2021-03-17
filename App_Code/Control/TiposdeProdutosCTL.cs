using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public class TiposdeProdutosCTL
{
    public TiposdeProdutosCTL(){}
    public void ManterDados(TiposdeProdutosDOM dados, EOperacao operacao)
    {
        try
        {
            TiposdeProdutosDAO tiposdeProdutosDAO = new TiposdeProdutosDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                tiposdeProdutosDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                tiposdeProdutosDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                tiposdeProdutosDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public TiposdeProdutosDOM Buscar(int codigo)
    {
        try
        {
            TiposdeProdutosDAO tiposdeProdutosDAO = new TiposdeProdutosDAO();
            return tiposdeProdutosDAO.Buscar(codigo);
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
            TiposdeProdutosDAO tiposdeProdutosDAO = new TiposdeProdutosDAO();
            return tiposdeProdutosDAO.Listar(nome, tipoConsulta, tipoDados);
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
            TiposdeProdutosDAO tiposdeProdutosDAO = new TiposdeProdutosDAO();
            return tiposdeProdutosDAO.TipoMateriaisdoFornecedor(codFornecedor, codCor, codMaterial, codEspessura);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}