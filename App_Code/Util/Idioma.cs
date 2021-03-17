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
/// Summary description for Idioma
/// </summary>
public class Idioma
{
	public static EIdioma IdiomaAtual
	{
		get
		{
            return (EIdioma)HttpContext.Current.Session["idiomaAtual"];
		}
		set
		{
			HttpContext.Current.Session["idiomaAtual"] = value;
		}
	}
}

