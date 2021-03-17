using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

[Serializable]
public class LancamentosDOM
{
    private int    codCliente;
    private string nomeFantasia;
    private string endCliente;
    private string telefones;
    private string emails;
    private string siteCli;
    private string observacao;
    private string logotipo;


    public LancamentosDOM()
    {
    }

   
    public int CodCliente
    {
        get { return codCliente; }
        set { codCliente = value; }
    }

    public string NomeFantasia
    {
        get { return nomeFantasia; }
        set { nomeFantasia = value; }
    }

    public string EndCliente
    {
        get { return endCliente; }
        set { endCliente = value; }
    }
	
    public string Telefones
    {
        get { return telefones; }
        set { telefones = value; }
    }

    public string Emails
    {
        get { return emails; }
        set { emails = value; }
    }

    public string SiteCli
    {
        get { return siteCli; }
        set { siteCli = value; }
    }
    
    public string Observacao
    {
        get { return observacao; }
        set { observacao = value; }
    }

    public string Logotipo
    {
        get { return logotipo; }
        set { logotipo = value; }
    }
}
