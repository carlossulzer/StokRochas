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
public class EspessurasDOM
{
    private int    codEspessura;
    private string descEspessura;
    private int codTipo;

    public EspessurasDOM(){}
    public EspessurasDOM(int codEspessura, string descEspessura)
    {
        this.codEspessura = codEspessura;
        this.descEspessura = descEspessura;
    }
    public int CodEspessura
    {
        get { return codEspessura; }
        set { codEspessura = value; }
    }
    public string DescEspessura
    {
        get { return descEspessura; }
        set { descEspessura = value; }
    }

    public int CodTipo
    {
        get { return codTipo; }
        set { codTipo = value; }

    }

}
