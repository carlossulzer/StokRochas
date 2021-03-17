using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class PlanosCTL
{
    public PlanosCTL(){}
    public void ManterDados(PlanosDOM dados, EOperacao operacao)
    {
        try
        {
            PlanosDAO planosDAO = new PlanosDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                planosDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                planosDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                planosDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public PlanosDOM Buscar(int codigo)
    {
        try
        {
            
            PlanosDAO planosDAO = new PlanosDAO();
            return planosDAO.Buscar(codigo);
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
            PlanosDAO planosDAO = new PlanosDAO();
            return planosDAO.Listar(tipoDados);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}