using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public class CoresCTL
{
    public CoresCTL(){}

    public void ManterDados(CoresDOM dados, EOperacao operacao)
    {
        try
        {
            CoresDAO coresDAO = new CoresDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                coresDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                coresDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                coresDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message);
        }
    }


    public CoresDOM Buscar(int codigo)
    {
        try
        {
            CoresDAO coresDAO = new CoresDAO();
            return coresDAO.Buscar(codigo);

        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message);
        }
    }

    public DataSet Listar(string nome, ETipoConsulta tipoConsulta, EIdioma idioma, ETipoDados tipoDados)
    {
        try
        {
            CoresDAO coresDAO = new CoresDAO();
            return coresDAO.Listar(nome, tipoConsulta, idioma, tipoDados);

        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }


    public DataSet CoresdoFornecedor(string codFornecedor, string codMaterial, string codTipo, string codEspessura)
    {
        try
        {
            CoresDAO coresDAO = new CoresDAO();
            return coresDAO.CoresdoFornecedor(codFornecedor, codMaterial, codTipo, codEspessura);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
