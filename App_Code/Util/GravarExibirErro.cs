using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.Configuration;

/// <summary>
/// Summary description for GravarExibirErro
/// </summary>
public class GravarExibirErro 
{
	public GravarExibirErro()
	{
		// TODO: Add constructor logic here
    }

    #region Método para gravar Log
    /// <summary>
    /// Gravar erro no arquivo de Log.
    /// </summary>
    /// <param name="strMessage">Mensagem a ser gravada (string).</param>
    /// <param name="objPagina">Página de referência System.Web.UI.Page)</param>
    public static void Log(string strMessage, System.Web.UI.Page objPagina)
    {
        string diretorio = System.AppDomain.CurrentDomain.BaseDirectory + "\\Erros";
        if (!Directory.Exists(diretorio))
            Directory.CreateDirectory(diretorio);

        string arquivo = diretorio + "\\Log_Erro.txt";

        StreamWriter text = new StreamWriter(arquivo, true);
        text.Write("\r\n" + DateTime.Now.ToString("dd/MM/yyyy - HH:mm") + "\r\n" + strMessage + "\r\n");
        text.Close();
    }
    #endregion
}
