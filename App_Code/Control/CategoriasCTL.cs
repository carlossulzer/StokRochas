using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class CategoriasCTL
{
    public CategoriasCTL(){}
    public void ManterDados(CategoriasDOM dados, EOperacao operacao)
    {
        try
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                categoriasDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                categoriasDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                categoriasDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public CategoriasDOM Buscar(int codigo)
    {
        try
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            return categoriasDAO.Buscar(codigo);
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
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            return categoriasDAO.Listar(tipoDados);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }


    public DataSet CategoriasFornecedor(int codCategoria)
    {
        try
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            return categoriasDAO.CategoriasFornecedor(codCategoria);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }


    public DataSet CategoriasMenu(ETipoDados tipoDados)
    {
        try
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            return categoriasDAO.CategoriasMenu();
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

}