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
using System.IO;
using System.Text;

public partial class WucAdmin_WucEnviar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            string diretorio = System.AppDomain.CurrentDomain.BaseDirectory + "\\Exportacao";
            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);

            string arquivoEspessuras = diretorio + "\\Espessuras.xml";
            string arquivoCores = diretorio + "\\Cores.xml";
            string arquivoTipodeProdutos = diretorio + "\\TiposdeProdutos.xml";
            string arquivoMateriais = diretorio + "\\Materiais.xml";


            EspessurasCTL espessurasCTL = new EspessurasCTL();
            DataSet dsEspessuras = espessurasCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.Exportacao);
            dsEspessuras.WriteXml(arquivoEspessuras);


            CoresCTL coresCTL = new CoresCTL();
            DataSet dsCores = coresCTL.Listar(string.Empty, ETipoConsulta.Iniciando, EIdioma.Portugues, ETipoDados.Exportacao);
            dsCores.WriteXml(arquivoCores);

            TiposdeProdutosCTL tiposdeProdutosCTL = new TiposdeProdutosCTL();
            DataSet dsTiposdeProdutos = tiposdeProdutosCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.Exportacao);
            dsTiposdeProdutos.WriteXml(arquivoTipodeProdutos);

            MateriaisCTL materiaisCTL = new MateriaisCTL();
            DataSet dsMateriais = materiaisCTL.Listar(string.Empty, ETipoConsulta.Iniciando, ETipoDados.Exportacao);
            dsMateriais.WriteXml(arquivoMateriais);

            EnviarArquivo enviar = new EnviarArquivo();
            ArrayList arquivos = new ArrayList();
            arquivos.Add(arquivoEspessuras);
            arquivos.Add(arquivoCores);
            arquivos.Add(arquivoTipodeProdutos);
            arquivos.Add(arquivoMateriais);
            enviar.Enviar(arquivos, "dados");

            ExibirMensagem.Padrao("Arquivo exportado com sucesso.", this.Page);
        }
        catch (ApplicationException ex)
        {
            ExibirMensagem.Padrao("Erro ao exportar dados. " + ex.Message, this.Page);
        }

    }
}
