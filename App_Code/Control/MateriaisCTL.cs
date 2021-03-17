using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class MateriaisCTL
{
    public MateriaisCTL(){}
    public void ManterDados(MateriaisDOM dados, EOperacao operacao)
    {
        try
        {
            MateriaisDAO materiaisDAO = new MateriaisDAO();

            if (operacao.Equals(EOperacao.Incluir))
            {
                materiaisDAO.Inserir(dados);
            }
            else if (operacao.Equals(EOperacao.Alterar))
            {
                materiaisDAO.Alterar(dados);
            }
            else if (operacao.Equals(EOperacao.Excluir))
            {
                materiaisDAO.Excluir(dados);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public MateriaisDOM Buscar(int codigo)
    {
        try
        {
            MateriaisDAO materiaisDAO = new MateriaisDAO();
            return materiaisDAO.Buscar(codigo);
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
            MateriaisDAO materiaisDAO = new MateriaisDAO();
            return materiaisDAO.Listar(nome, tipoConsulta, tipoDados);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
    public DataSet MateriaisdoFornecedor(string codFornecedor, string codCor, string codTipo, string codEspessura)
    {
        try
        {
            MateriaisDAO materiaisDAO = new MateriaisDAO();
            return materiaisDAO.MateriaisdoFornecedor(codFornecedor, codCor, codTipo, codEspessura);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}