using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class PromocoesCTL
{
    public PromocoesCTL(){}

    public DataSet PromocoesProdutos(int codForncedor)
    {
        try
        {
            PromocoesDAO promocoesDAO = new PromocoesDAO();
            return promocoesDAO.PromocoesProdutos(codForncedor);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public PromocoesDOM PromocoesFornecedor(int codForncedor)
    {
        try
        {
            PromocoesDAO promocoesDAO = new PromocoesDAO();
            return promocoesDAO.PromocoesFornecedor(codForncedor);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }


    public DataSet PromocoesMenu(int codFornecedor)
    {
        try
        {
            PromocoesDAO promocoesDAO = new PromocoesDAO();
            return promocoesDAO.PromocoesMenu(codFornecedor);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

}