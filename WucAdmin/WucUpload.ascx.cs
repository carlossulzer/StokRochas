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

public partial class WucAdmin_WucUpload : System.Web.UI.UserControl
{
    //protected void Page_Init()
    //{
    //    AsyncPostBackTrigger aptLogotipo = new AsyncPostBackTrigger();
    //    aptLogotipo.EventName = "Click";
    //    aptLogotipo.ControlID = ibtnConfirmarLogo.ClientID.ToString();

    //}



    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(ibtnConfirmarLogo);

        //base.OnInit(e);

        if (ViewState["inicio"] == null)
        {
            //AsyncPostBackTrigger aptLogotipo = new AsyncPostBackTrigger();
            //aptLogotipo.EventName = "Click";
            //aptLogotipo.ControlID = ibtnConfirmarLogo.ClientID.ToString();


            //ScriptManager sm = ScriptManager.GetCurrent(Page);
            //sm.RegisterAsyncPostBackControl(ibtnConfirmarLogo);





            ViewState["inicio"] = "1";
        }
    }
    protected void ibtnConfirmarLogo_Click(object sender, ImageClickEventArgs e)
    {
        //ibtnConfirmarLogo.Attributes.Add("OnClick", "javascript:document.forms[0].encoding = \"multipart/form-data\";");

        if (fuplLogotipo.HasFile)
            TextBox1.Text = fuplLogotipo.PostedFile.FileName;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
}
