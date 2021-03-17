using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Pagina
/// </summary>
public class Pagina
{

	public static string Atual
	{
		get
		{
			return HttpContext.Current.Session["paginaAtual"].ToString();
		}
		set
		{
            HttpContext.Current.Session["paginaAtual"] = value;
		}
	}
}

