using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public class FornecedoresCTL
{
    public FornecedoresCTL(){}
    public DataSet Listar(string nome, ETipoConsulta tipoConsulta, ETipoDados tipoDados)
    {
        try
        {
            FornecedoresDAO fornecedoresDAO = new FornecedoresDAO();
            return fornecedoresDAO.Listar(nome, tipoConsulta, tipoDados);
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
            FornecedoresDAO fornecedoresDAO = new FornecedoresDAO();
            return fornecedoresDAO.BuscaLogotipo(codigo);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet FiltrarFornecedores(string codCor, string codMaterial, string codTipo, string codEspessura)
    {
        try
        {
            FornecedoresDAO fornecedoresDAO = new FornecedoresDAO();
            return fornecedoresDAO.FiltrarFornecedores(codCor, codMaterial, codTipo, codEspessura);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
