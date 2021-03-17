using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ExibirMensagemErro
/// </summary>
public class ExibirMensagem
{
	public ExibirMensagem()
	{
	}

    public static void Padrao(string mensagem, System.Web.UI.Page objPagina)
    {
        //ScriptManager.RegisterClientScriptBlock(objPagina, objPagina.GetType(), "@MSG", "<script>alert('" + mensagem + "');</script>", false);   

        ScriptManager.RegisterClientScriptBlock(objPagina, objPagina.GetType(), "@MSG", "<script>alert('" + mensagem + "');</script>", false);
    }

    public static void FecharFormulario(System.Web.UI.Page objPagina)
    {
        ScriptManager.RegisterClientScriptBlock(objPagina, objPagina.GetType(), "@MSG", "<script>window.opener = ''; window.close()</script>", false);

    }

    public static void Redirecionar(string mensagem, System.Web.UI.Page objPagina, string destino)
    {
        ScriptManager.RegisterClientScriptBlock(objPagina, objPagina.GetType(), "@MSG", "<script>alert('" + mensagem + "');window.location='" + destino + "';</script>", false);
    }



}
