using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for FornecedoresDOM
/// </summary>
/// 
[Serializable]
public class ClientesDOM
{
    private int    codCliente;
    private string razaoSocial;
    private string nomeFantasia;
    private string cnpj;
    private string email;
    private string email2;
    private string telefone1;
    private string telefone2;
    private string enderecoCom;
    private string bairroCom;
    private string cidadeCom;
    private string ufCom;
    private string cepCom; 
    private string enderecoCob;
    private string bairroCob;
    private string cidadeCob;
    private string ufCob;
    private string cepCob;
    private int ativo;
    private string login;
    private int anuncio;
    private DateTime validade;
    private string site;
    private string logotipo;
    private int codCategoria;
    private int codPlano;
    private int numProdPromocao;
    private int numProdLancamento;
    private string observacao;


    private int movEstoque;

    public ClientesDOM()
    {
    }

   
    public int CodCliente
    {
        get { return codCliente; }
        set { codCliente = value; }
    }

    public string RazaoSocial
    {
        get { return razaoSocial; }
        set { razaoSocial = value; }
    }

    public string NomeFantasia
    {
        get { return nomeFantasia; }
        set { nomeFantasia = value; }
    }

    public string Cnpj
    {
        get { return cnpj; }
        set { cnpj = value; }
    }
	
    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Email2
    {
        get { return email2; }
        set { email2 = value; }
    }

    public string Telefone1
    {
        get { return telefone1; }
        set { telefone1 = value; }
    }

    public string Telefone2
    {
        get { return telefone2; }
        set { telefone2 = value; }
    }

    public string EnderecoCom
    {
        get { return enderecoCom; }
        set { enderecoCom = value; }
    }

    public string BairroCom
    {
        get { return bairroCom; }
        set { bairroCom = value; }
    }

    public string CidadeCom
    {
        get { return cidadeCom; }
        set { cidadeCom = value; }
    }

    public string UfCom
    {
        get { return ufCom; }
        set { ufCom = value; }
    }

    public string CepCom
    {
        get { return cepCom; }
        set { cepCom = value; }
    }

    public string EnderecoCob
    {
        get { return enderecoCob; }
        set { enderecoCob = value; }
    }

    public string BairroCob
    {
        get { return bairroCob; }
        set { bairroCob = value; }
    }

    public string CidadeCob
    {
        get { return cidadeCob; }
        set { cidadeCob = value; }
    }

    public string UfCob
    {
        get { return ufCob; }
        set { ufCob = value; }
    }

    public string CepCob
    {
        get { return cepCob; }
        set { cepCob = value; }
    }


    public int Ativo
    {
        get { return ativo; }
        set { ativo = value; }
    }

    public string Login
    {
        get { return login; }
        set { login = value; }
    }

    public int Anuncio
    {
        get { return anuncio; }
        set { anuncio = value; }
    }

    public DateTime Validade
    {
        get { return validade; }
        set { validade = value; }
    }

    public string Site
    {
        get { return site; }
        set { site = value; }
    }

    public string Logotipo
    {
        get { return logotipo; }
        set { logotipo = value; }
    }

    public int MovEstoque
    {
        get { return movEstoque; }
        set { movEstoque = value; }
    }

    public int CodCategoria
    {
        get { return codCategoria; }
        set { codCategoria = value; }
    }

    public int CodPlano
    {
        get { return codPlano; }
        set { codPlano = value; }
    }

    public int NumProdPromocao
    {
        get { return numProdPromocao; }
        set { numProdPromocao = value; }
    }

    public int NumProdLancamento
    {
        get { return numProdLancamento; }
        set { numProdLancamento = value; }
    }

    public string Observacao
    {
        get { return observacao; }
        set { observacao = value; }
    }

}
