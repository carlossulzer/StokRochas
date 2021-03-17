using System;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for clsObjetosBanco.
/// </summary>


public class AcessoaBancoDados
{

    static MySqlConnection cn;
    static MySqlCommand cmd;
    static MySqlDataAdapter da;
    static MySqlDataReader dr;
    static string cString = string.Empty;

    public AcessoaBancoDados()
    {
        //o constructor da classe faz a leitura do tipo de banco
    }

    // Gera uma conexão conforme especificado no web.config


    public static MySqlConnection AbrirConexao()
    {
        cString = ConfigurationManager.ConnectionStrings["StokRochas"].ConnectionString;

        if (cn == null)
        {
            cn = new MySqlConnection(cString);
        }
        else
        {
            cn.Close();
        }

        cn.Open();
        return cn;
    }



    //public static MySqlConnection AbrirConexao()
    //{
    //    try
    //    {
    //        cString = ConfigurationManager.ConnectionStrings["StokRochas"].ConnectionString;

    //        if (cn == null)
    //        {
    //            cn = new MySqlConnection(cString);
    //            cn.Open();
    //        }
    //        else if (cn.State.Equals(ConnectionState.Closed))
    //        {
    //            //AcessoaBancoDados.FecharConexao();
    //            cn.Open();
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException(ex.Message.ToString());
    //    }

    //    return cn;
    //}

    public static void FecharConexao()
    {

        if (cn != null)
        {
            if (cn.State.Equals(ConnectionState.Open))
            {
                cn.Close();
            }

            cn.Dispose();
        }
    }


    // Criação de todos os objetos de banco para um acesso simples e os interliga
    public static void CriarCommand(string MySql)
    {
        cn = AbrirConexao();
        cmd = new MySqlCommand(MySql, cn);
    }

    // Devolve o objeto de conexão armazenado nesta instância
    public MySqlConnection conexao
    {
        get{ return (cn); }
    }

    // Devolve o objeto command armazenado nesta instância
    public MySqlCommand command
    {
        get{ return (cmd); }
    }

    // Devolve o objeto adapter armazenado nesta instância
    public MySqlDataAdapter DataAdapter
    {
        get{ return (da); }
    }

    // Devolve o objeto DataRedaer armazenado nesta instância
    public MySqlDataReader DataReader
    {
        get{ return (dr); }
    }

    // Cria um DataSet Genérico
    public static DataSet BuscaDados(string MySql)
    {
        try
        {
            AbrirConexao();
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(MySql, cn);
            da.Fill(ds);
            FecharConexao();
            return ds;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao tentar obter dados."+e.Message.ToString()); 
        }
    }

    public MySqlDataReader MontaDataReader(string MySql)
    {
        CriarCommand(MySql);
        dr = (MySqlDataReader)cmd.ExecuteReader();
        return dr;
    }

    public static object ManterDados(string MySql)
    {
        CriarCommand(MySql);
        object retorno = cmd.ExecuteScalar();
        if (retorno == null)
            retorno = String.Empty;
        FecharConexao();
        return retorno;
    }

    public int ObterValorInteiro(string MySql)
    {
        return Convert.ToInt32("0" + ManterDados(MySql));
    }

    public decimal ObterValorDecimal(string MySql)
    {
        return Convert.ToDecimal("0" + ManterDados(MySql));
    }

    public string ObterValorString(string MySql)
    {
        return ManterDados(MySql).ToString();
    }

    public int IncluirRegistro(string MySql)
    {
        return ObterValorInteiro(MySql);
    }

   
    public static int ExecutarNonQuery(string MySql)
    {
        int count = 0;
        try
        {
            CriarCommand(MySql);
            count = cmd.ExecuteNonQuery();
            FecharConexao();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao tentar obter dados." + ex.Message.ToString()); 

        }
        return count;
    }
  
}
