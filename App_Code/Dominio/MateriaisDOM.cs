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
public class MateriaisDOM
{
    private int    codMaterial;
    private string descMaterial;
    private int codCor;

    public MateriaisDOM()
    {
    }

    public MateriaisDOM(int codMaterial, string descMaterial, int codCor)
    {
        this.codMaterial = codMaterial;
        this.descMaterial = descMaterial;
        this.codCor = codCor;
    }

    public int CodMaterial
    {
        get { return codMaterial; }
        set { codMaterial = value; }
    }

    public string DescMaterial
    {
        get { return descMaterial; }
        set 
        {
            if (value.Trim().Equals(string.Empty))
                throw new Exception("A descrição do material deve ser informada.");
            else
                descMaterial = value; 
        }
    }

    public int CodCor
    {
        get { return codCor; }
        set { codCor = value; }
    }
	

}
