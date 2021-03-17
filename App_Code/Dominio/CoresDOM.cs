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
public class CoresDOM
{
    private int    codCor;
    private string nomeCorPor;
    private string nomeCorIng;
    private string nomeCorEsp;
    public CoresDOM(){}
    public CoresDOM(int codCor, string nomeCorPor, string nomeCorIng, string nomeCorEsp)
    {
        this.codCor = codCor;
        this.nomeCorPor = nomeCorPor;
        this.nomeCorIng = nomeCorIng;
        this.nomeCorEsp = nomeCorEsp;
    }
    public int CodCor
    {
        get { return codCor; }
        set { codCor = value; }
    }
    public string NomeCorPor
    {
        get { return nomeCorPor; }
        set { nomeCorPor = value; }
    }
    public string NomeCorIng
    {
        get { return nomeCorIng; }
        set { nomeCorIng = value; }
    }
    public string NomeCorEsp
    {
        get { return nomeCorEsp; }
        set { nomeCorEsp = value; }
    }
}
