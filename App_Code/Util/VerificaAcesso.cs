using System;
using System.Configuration;

/// <summary>
/// Summary description for Login.
/// </summary>
public class VerificaAcesso
{
	private string mensagemdeRetorno;
	private string usuarioLogado;
	private string tipodeUsuario;
	private int foco;

	public VerificaAcesso()
	{
	}

	public bool Verifica_Senha(string login, string senha, string senhaNova, string senhaConf, bool verificarTroca)
	{
		string usuarioAdm = ConfigurationManager.AppSettings["usuario"];
		string senhaAdm   = ConfigurationManager.AppSettings["senha"];

		string usuarioDigitado = Criptografia.encriptar(login);
		string senhaDigitada   = Criptografia.encriptar(senha);

		if (usuarioAdm.Equals(usuarioDigitado) && senhaAdm.Equals(senhaDigitada))
		{
			UsuarioLogado = login;
			TipodeUsuario = "S";

			return true;
		}
		else
		{

            mensagemdeRetorno = "Usuário inválido";
            foco = 1;
            return false;

        }
	}

	public string MensagemdeRetorno
	{
		get { return mensagemdeRetorno; }
		set { mensagemdeRetorno = value; }
	}

    public string UsuarioLogado
	{
		get { return usuarioLogado; }
		set { usuarioLogado = value; }
	}

	public string TipodeUsuario
	{
		get { return tipodeUsuario; }
		set { tipodeUsuario = value; }
	}

	public int SetarFoco
	{
		get { return foco; }
		set { foco = value; }
	}

}




