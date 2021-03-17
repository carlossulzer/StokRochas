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
public class PlanosDOM
{
    private int    de;
    private int ate;
    private double valor;

    public PlanosDOM()
    {
    }


    public int CodPlano { get; set; }

    public PlanosDOM(int de, int ate, double valor)
    {
        this.de = de;
        this.ate = ate;
        this.valor = valor;
    }

    public int De
    {
        get { return de; }
        set 
        {
            if (value.Equals(0))
                throw new Exception("O campo (De) deve ser informada.");
            else
                de = value; 
        }
    }

    public int Ate
    {
        get { return ate; }
        set
        {
            if (value.Equals(0))
                throw new Exception("O campo (Até) deve ser informada.");
            else
                ate = value;
        }
    }    

    public double Valor
    {
        get { return valor; }
        set
        {
            if (value.Equals(0))
                throw new Exception("O campo (Valor) deve ser informada.");
            else
                valor = value;
        }
    }
	

}
