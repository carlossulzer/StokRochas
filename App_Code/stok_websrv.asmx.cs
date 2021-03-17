using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Text;
using System.IO;


[WebService(Namespace="http://www.stokrochas.com.br/websrv/", Description="WEBSERVICE STOKROCHAS<br />CRIADO POR: Carlos Sulzer Pêgo<br />EXCLUSIVO PARA USO DE STOK ROCHAS")] 
public class stok_websrv : System.Web.Services.WebService
{
    #region Construtor do WebService
    public stok_websrv()
    {
        //CODEGEN: This call is required by the ASP.NET Web Services Designer
        InitializeComponent();
    }
    #endregion

    #region Component Designer generated code

    //Required by the Web Services Designer 
    private IContainer components = null;

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #endregion


    public string DiretorioImg 
    { 
        get
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }
    }


    #region Autenticação de Usuários
    [WebMethod(Description = "Autenticação de Usuários")]
    public bool Autenticacao(string usuario, string senha)
    {
        return Acesso(usuario, senha);
    }

    #endregion

    #region Acesso do Usuário
    private static bool Acesso(string usuario, string senha)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Select login, senha, ativo ");
            sql.Append(" From clientes ");
            sql.Append(" where ");
            sql.Append("   login = '" + usuario + "' and ");
            sql.Append("   senha = '" + senha + "'");

            DataSet funcionariosTable = AcessoaBancoDados.BuscaDados(sql.ToString());

            if (funcionariosTable.Tables[0].Rows.Count > 0)
            {
                if (funcionariosTable.Tables[0].Rows[0]["ativo"].ToString().Trim().Equals("True"))
                     return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        finally
        {
            AcessoaBancoDados.FecharConexao();
        }

    }
    #endregion

    #region Download de Arquivo via WebService
    [WebMethod(Description = "Download de Arquivos")]
    public byte [] DownloadFile( string fName, string usuario, string senha) 
    {
        byte[] b1 = null;

        if (Acesso(usuario, senha).Equals(true))
        {
            System.IO.FileStream fs1 = null;
            fs1 = File.Open(fName, FileMode.Open, FileAccess.Read);
            b1 = new byte[fs1.Length];
            fs1.Read(b1, 0, (int)fs1.Length);
            fs1.Close();
        }
        return  b1; 
    }  
    #endregion

    #region Upload de Arquivo via WebService
    [WebMethod(Description = "Upload de Arquivos")]
    public void UpLoladFile(byte[] buffer, string nomeArquivo, string pasta, string usuario, string senha) 
    {
        try
        {
            if (Acesso(usuario, senha).Equals(true))
            {
                string diretorio = DiretorioImg + pasta;
                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                string arquivo = diretorio + "\\" + nomeArquivo;
                BinaryWriter binWriter = new BinaryWriter(File.Open(arquivo, FileMode.CreateNew, FileAccess.ReadWrite));
                binWriter.Write(buffer);
                binWriter.Close();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao enviar o arquivo " + nomeArquivo + " - " + ex.Message.ToString());
        }
    }

    #endregion

    #region Excluir Arquivo do WebService
    [WebMethod(Description = "Excluir Arquivo do WebService")]
    public void DeleteFile(string nomeArquivo, string pasta, string usuario, string senha) 
    {
        if (Acesso(usuario, senha).Equals(true))
        {
            string arquivo = DiretorioImg + pasta + "\\" + nomeArquivo;
            if (File.Exists(arquivo))
                File.Delete(arquivo);
        }
    }

    #endregion

    #region Tamanho do Arquivo
    [WebMethod(Description = "Tamanho do Arquivo")]
    public long GetFileSize(string nomeArquivo, string pasta, string usuario, string senha)
    {
        long tamanho = 0;
        if (Acesso(usuario, senha).Equals(true))
        {
           
            string arquivo = DiretorioImg + pasta + "\\" + nomeArquivo;
            if (File.Exists(arquivo))
            {
                FileInfo fiLocal = new FileInfo(arquivo);
                tamanho = fiLocal.Length;
            }
        }
        return tamanho;
    }

    #endregion



    #region Tamanho do Arquivo
    [WebMethod(Description = "Criar uma Pasta")]
    public void MakeDir(string pasta, string usuario, string senha)
    {
        if (Acesso(usuario, senha).Equals(true))
        {
            string novaPasta = DiretorioImg + pasta;
            if (!Directory.Exists(novaPasta))
            {
                Directory.CreateDirectory(novaPasta);
            }
        }
    }

    #endregion

    //#region Diretorio do WebService
    //[WebMethod(Description = "Diretorio do WebService")]
    //public string GetDir()
    //{
    //    return DiretorioImg;
    //}

    //#endregion





}

