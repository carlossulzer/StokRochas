using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text.RegularExpressions;
//using AjaxControlToolkit;

/// <summary>
/// Summary description for Validacao
/// </summary>


public class Validacao
{
    public Validacao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Validações

    #region ValidaCampoVazio
    
    private ETipoObjeto tipoObjeto;

    public ETipoObjeto TipoObjeto
    {
        get { return tipoObjeto; }
        set { tipoObjeto = value; }
    }


    public enum ETipoObjeto
    {
        textbox,
        maskedtextbox,
        dropdown
    }


//------------------------

    public bool DesabilitarCampos(Control controle, ref object campoFoco, ref int preencher, Page paginaAtual)
    {
        bool v = true;
        foreach (Control mObjeto in controle.Controls)
        {
            if (mObjeto.GetType() == typeof(TextBox))
            {
                if (((TextBox)mObjeto).AccessKey.Equals("?"))
                {
                    v = Validacao.ValidaTextBox(paginaAtual , ((TextBox)mObjeto));
                    if (!v)
                    {
                        preencher++;
                        if (preencher.Equals(1))
                        {
                            campoFoco = ((TextBox)mObjeto);
                            TipoObjeto = ETipoObjeto.textbox;
                        }
                    }
                }
            }

            if (mObjeto.GetType() == typeof(WebCtrlMascara.MascaraEntrada))
            {
                if (((WebCtrlMascara.MascaraEntrada)mObjeto).AccessKey.Equals("?"))
                {
                    v = Validacao.ValidaMaskedTextBox(paginaAtual, ((WebCtrlMascara.MascaraEntrada)mObjeto));
                    if (!v)
                    {
                        preencher++;
                        if (preencher.Equals(1))
                        {
                            campoFoco = ((WebCtrlMascara.MascaraEntrada)mObjeto);
                            TipoObjeto = ETipoObjeto.textbox;
                        }
                    }
                }
            }

            if (mObjeto.GetType() == typeof(DropDownList))
            {
                if (((DropDownList)mObjeto).AccessKey.Equals("?"))
                {
                    v = Validacao.ValidaListBox(paginaAtual, ((DropDownList)mObjeto));
                    if (!v)
                    {
                        preencher++;
                        if (preencher.Equals(1))
                        {
                            campoFoco = ((DropDownList)mObjeto);
                            TipoObjeto = ETipoObjeto.dropdown;
                        }
                    }
                }
            }
            DesabilitarCampos(mObjeto, ref campoFoco, ref preencher, paginaAtual);
        }
        return v;
    }

    public bool CampoVazio(Page paginaAtual)
    {
        bool v = true;
        int preencher = 0;
        object campoFoco = null;
        //ContentPlaceHolder meuForm = (ContentPlaceHolder)paginaAtual.Master.FindControl("ContentPlaceHolder1");

        foreach (Control mObjeto in paginaAtual.Form.Controls)
        {
            v = DesabilitarCampos(mObjeto, ref campoFoco, ref preencher, paginaAtual);
        } 

        if (campoFoco != null)
        {
            if (TipoObjeto.Equals(ETipoObjeto.textbox))
                ((TextBox)campoFoco).Focus();
            else if (TipoObjeto.Equals(ETipoObjeto.maskedtextbox))
                ((WebCtrlMascara.MascaraEntrada)campoFoco).Focus();
            else if (TipoObjeto.Equals(ETipoObjeto.dropdown))
                ((DropDownList)campoFoco).Focus();
        }

        if (preencher > 0)
        {
            ExibirMensagem.Padrao("Favor preecher os campos em destaque.", paginaAtual);
            return false;
        }
        else
        {
            return true;
        }
    }

    #endregion

    #region ValidaTextBox
    public static bool ValidaTextBox(Page pg, TextBox txt)
    {
        txt.BackColor = Color.White;
        if (txt.Text == "")
        {
            txt.BackColor = Color.FromArgb(255, 255, 153);
            txt.ToolTip = "Campo obrigatório.";
            return false;
        }
        else
        {
            txt.BackColor = Color.White;
            txt.ToolTip = "";
            return true;
        }
    }
    #endregion

    #region ValidaMaskedTextBox
    public static bool ValidaMaskedTextBox(Page pg, WebCtrlMascara.MascaraEntrada txt)
    {
        txt.BackColor = Color.White;
        if (txt.Text == "")
        {
            txt.BackColor = Color.FromArgb(255, 255, 153);
            txt.ToolTip = "Campo obrigatório.";
            return false;
        }
        else
        {
            txt.BackColor = Color.White;
            txt.ToolTip = "";
            return true;
        }
    }
    #endregion

    #region ValidaListBox
    public static bool ValidaListBox(Page pg, ListBox lst)
    {
        lst.BackColor = Color.White;
        if (lst.SelectedValue == "-1")
        {
            lst.BackColor = Color.FromArgb(255, 255, 153);
            return false;
        }
        else
        {
            lst.BackColor = Color.White;
            return true;
        }
    }
    #endregion

    #region ValidaDropDown
    public static bool ValidaListBox(Page pg, DropDownList ddl)
    {
        ddl.BackColor = Color.White;
        if (ddl.SelectedValue == "-1")
        {
            ddl.BackColor = Color.FromArgb(255, 255, 153);
            return false;
        }
        else
        {
            ddl.BackColor = Color.White;
            return true;
        }
    }
    #endregion

    #region ValidaRadioButtonList
    public static bool ValidaRadioButtonList(Page pg, RadioButtonList rbllst)
    {
        bool v = false;

        rbllst.BackColor = Color.White;

        for (int i = 0; i < rbllst.Items.Count; i++)
            if (rbllst.Items[i].Selected)
                v = true;

        if (!v)
        {
            rbllst.BackColor = Color.FromArgb(255, 255, 153);
            return false;
        }
        else
        {
            rbllst.BackColor = Color.FromArgb(241, 241, 241);
            return true;
        }
    }
    #endregion

    #region ValidaData
    public static bool ValidaData(Page pg, TextBox txt, ref bool v)
    {
        txt.BackColor = Color.White;
        if (txt.Text != "")
        {
            try
            {
                txt.BackColor = Color.White;
                Convert.ToDateTime(txt.Text);
                return true;
            }
            catch
            {
                txt.BackColor = Color.FromArgb(255, 255, 153);
                return false;
            }
        }
        else
            return v;
    }
    #endregion

    #region ValidaDecimal
    public static bool ValidaDecimal(Page pg, TextBox txt, ref bool v)
    {
        txt.BackColor = Color.White;
        if (txt.Text != "")
        {
            try
            {
                txt.BackColor = Color.White;
                Convert.ToDecimal(txt.Text);
                txt.ToolTip = "";
                return true;
            }
            catch
            {
                txt.BackColor = Color.FromArgb(255, 255, 153);
                txt.ToolTip = "Valor inválido.";
                return false;
            }
        }
        else
            return v;
    }
    #endregion

    #region ValidaHorario
    public static bool ValidaHorario(Page pg, TextBox txt, ref bool v)
    {
        txt.BackColor = Color.White;
        if (txt.Text != "")
        {
            Regex regExHor = new Regex("[0-1][0-9]:[0-5][0-9]|2[0-3]:[0-5][0-9]");
            if (regExHor.IsMatch(txt.Text))
            {
                txt.BackColor = Color.White;
                return true;
            }
            else
            {
                txt.BackColor = Color.FromArgb(255, 255, 153);
                return false;
            }
        }
        else
        {
            if (!v)
            {
                txt.BackColor = Color.FromArgb(255, 255, 153);
            }
            return v;
        }
    }

    
    #endregion

    #endregion
}
