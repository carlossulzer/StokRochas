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
public class TiposdeProdutosDOM
{
    private int    codTipo;
    private string descTipo;
    public TiposdeProdutosDOM(){}
    public TiposdeProdutosDOM(int codTipo, string descTipo)
    {
        this.codTipo = codTipo;
        this.descTipo = descTipo;
    }
    public int CodTipo
    {
        get { return codTipo; }
        set { codTipo = value; }
    }
    public string DescTipo
    {
        get { return descTipo; }
        set { descTipo = value; }
    }
}