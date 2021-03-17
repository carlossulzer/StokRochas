using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

[Serializable]
public class CategoriasDOM
{

    public CategoriasDOM()
    {
    }

    private string descCategoria;
    public int CodCategoria { get; set; }
  
    public string DescCategoria
    {
        get { return descCategoria; }
        set 
        {
            if (value.Equals(0))
                throw new Exception("O campo (Descrição da Categoria) deve ser informado.");
            else
                descCategoria = value; 
        }
    }
}
