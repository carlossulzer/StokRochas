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

public partial class DefaultADM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // - Evita cache no servidor
            // - O valor "-1" representa o tempo em minutos, neste caso a 
            //   p�gina nunca ficar� em cache
            Response.Expires = -1;

            //Indica no cabecalho do navegador que que ele n�o deve UTILIZAR o cache do Browser
            Response.AddHeader("pragma", "no-cache");
            Response.CacheControl = "no-cache";

            // - Indica no cabecalho do navegador que que ele n�o deve GRAVAR no cache do Browser
            // - "Private" a p�gina n�o ser� salva pelos servidores proxy
            Response.AddHeader("cache-control", "private");

            // A diretiva "cache-control:no-cache" tem a mesma fun��o de 
            // "pragma:no-cache". O ideal quando se usa essa instru��o � 
            // utilizar ambas as formas caso n�o se saiba se o servidor 
            // � ou n�o compat�vel com o HTTP 1.1.

            ViewState["paginaAdm"] = "";
            if (Request["wucFormAdm"] != null)
                ViewState["paginaAdm"] = Request["wucFormAdm"];

        }

        if (!ViewState["paginaAdm"].ToString().Equals(string.Empty))
            LoadUserControlAdm(ViewState["paginaAdm"].ToString());
    }

    #region LoadUserControlAdm
    public void LoadUserControlAdm(string wucName)
    {
        ViewState["paginaAdm"] = wucName;
        string opcao = "~/WucAdmin/" + wucName;
        PlaceHolderADM.Controls.Clear();
        UserControl principal = (UserControl)LoadControl(opcao);
        principal.ID = "formPrincipal";
        PlaceHolderADM.Controls.Add(principal);
    }
    #endregion


    protected void ibtnClientes_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucClientes.ascx");
    }
    protected void ibtnCores_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucCores.ascx");
    }
    protected void ibtnEspessura_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucEspMedDim.ascx");
    }
    protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucCategorias.ascx");
    }
    protected void ibtnTiposdeProdutos_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucTipodeProdutos.ascx");
    }
    protected void ibtnMateriais_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucMateriais.ascx");
    }

    protected void ibtnPrincipal_Click(object sender, ImageClickEventArgs e)
    {
        if (Session.Count > 0)
        {
            FormsAuthentication.SignOut();
        }
        Response.Redirect("Default.aspx?wucForm=WucForms/WucInicial.ascx");
    }
    protected void ibtnSenha_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucGerarSenha.ascx");
    }
    protected void ibtnPlanos_Click(object sender, ImageClickEventArgs e)
    {
        LoadUserControlAdm("WucPlanos.ascx");
    }
}
