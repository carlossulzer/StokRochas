using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Global
/// </summary>
public class Utilitarios
{
	public Utilitarios()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string RetiraAcentos(string strTexto)
    {
        if (strTexto == null)
            strTexto = string.Empty;

        if (!strTexto.Equals(string.Empty))
        {
            string strComAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string strSemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
            for (int i = 0; i < strComAcentos.Length; i++)
            {
                strTexto = strTexto.Replace(strComAcentos[i].ToString(), strSemAcentos[i].ToString()).ToUpper();
            }
        }
        return strTexto;
    }

    public static string iif(string par1, string par2)
    {
        if (par1.Equals(string.Empty))
            return par2;
        else
            return par1;
    }

    public static bool ValidaEmail(Page pg, TextBox email)
    {
        if (!email.Text.Equals(string.Empty))
        {
            Regex regexEmail = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (regexEmail.IsMatch(email.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
    }


}
