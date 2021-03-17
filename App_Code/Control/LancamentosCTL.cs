using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class LancamentosCTL
{
    public LancamentosCTL(){}

    public DataSet LancamentosProdutos(int codForncedor)
    {
        try
        {
            LancamentosDAO lancamentosDAO = new LancamentosDAO();
            return lancamentosDAO.LancamentosProdutos(codForncedor);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public LancamentosDOM LancamentosFornecedor(int codForncedor)
    {
        try
        {
            LancamentosDAO lancamentosDAO = new LancamentosDAO();
            return lancamentosDAO.LancamentosFornecedor(codForncedor);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }


    public DataSet LancamentosMenu(int codFornecedor)
    {
        try
        {
            LancamentosDAO lancamentosDAO = new LancamentosDAO();
            return lancamentosDAO.LancamentosMenu(codFornecedor);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

}