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
using System.IO.Compression;
using System.Collections;
public class CompactarViewState : System.Web.UI.Page
{
	public CompactarViewState()
	{
	}
    public static byte[] CompactarViewStates(byte[] bytes)
    {
        MemoryStream MSsaida = new MemoryStream();
        GZipStream gzip = new GZipStream(MSsaida,
                          CompressionMode.Compress, true);
        gzip.Write(bytes, 0, bytes.Length);
        gzip.Close();
        return MSsaida.ToArray();
    }
    public static byte[] DescompactarViewState(byte[] bytes)
    {
        MemoryStream MSentrada = new MemoryStream();
        MSentrada.Write(bytes, 0, bytes.Length);
        MSentrada.Position = 0;
        GZipStream gzip = new GZipStream(MSentrada,
                          CompressionMode.Decompress, true);
        MemoryStream MSsaida = new MemoryStream();
        byte[]  buffer = new byte[64];
        int leitura = -1;
        leitura = gzip.Read(buffer, 0, buffer.Length);
        while (leitura > 0)
        {
            MSsaida.Write(buffer, 0, leitura);
            leitura = gzip.Read(buffer, 0, buffer.Length);
        }
        gzip.Close();
        return MSsaida.ToArray();
    }
    protected override object LoadPageStateFromPersistenceMedium()
    {
        string viewState = Request.Form["__VSTATE"];
        byte[] bytes = Convert.FromBase64String(viewState);
      // DESCOMPACTAR VIEWSTATE   
        bytes = CompactarViewState.DescompactarViewState(bytes);
        LosFormatter formatter = new LosFormatter();
        return formatter.Deserialize(Convert.ToBase64String(bytes));
    }
    protected override void SavePageStateToPersistenceMedium(object viewState)
    {
        LosFormatter formatter = new LosFormatter();
        StringWriter writer = new StringWriter();
        formatter.Serialize(writer, viewState);
        string viewStateString = writer.ToString();
        byte[] bytes = Convert.FromBase64String(viewStateString);
     // COMPACTAR VIEWSTATE
        bytes = CompactarViewState.CompactarViewStates(bytes);
        ClientScript.RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes));
    }
}