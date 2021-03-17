using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ibtnFornecedores_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/frmFornecedores.aspx");
    }
    protected void ibtnPromocoes_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/frmPromocoes.aspx?codFornecedor=0");
    }
    protected void ibtnUtilidades_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/frmServicos.aspx");
    }
    protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/frmLancamentos.aspx?codFornecedor=0");
    }
}
