using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ProdutosDOM
/// </summary>
public class ProdutosDOM
{
	public ProdutosDOM(){}

	public string NomeProduto { get; set; }
    public int Quantidade { get; set; }
    public int CodMaterial { get; set; }

}
