using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

/// <summary>
/// Summary description for EnviarArquivo
/// </summary>
public class EnviarArquivo
{
	public EnviarArquivo()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string Enviar(ArrayList arquivos, string pasta)
    {
        string retorno = "";
        string arquivoAtual = string.Empty;
        try
        {
            FtpClient enviar = new FtpClient();
            enviar.Server = "ftp.stokrochas.com.br";
            enviar.Username = "stokrochas";
            enviar.Password = "stok0063";
            enviar.Port = 21;
            enviar.Login();
            enviar.Timeout = 120;
            enviar.BinaryMode = false;
            enviar.MakeDir("Web/"+pasta);
            enviar.ChangeDir("Web/"+pasta);

            foreach (string arquivo in arquivos)
            {
                enviar.Upload(arquivo);
            }
            enviar.Close();
        }
        catch(Exception ex)
        {
            if (!arquivoAtual.Equals(string.Empty))
            {
                throw new ApplicationException("Erro ao tentar enviar arquivo " + arquivoAtual.Trim());
                retorno = ex.Message.ToString();
            }
            else
            {
                throw new ApplicationException("Erro ao tentar conectar ao FTP ");
                retorno = ex.Message.ToString();
            }
        }

        return retorno;
    }


}
