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
using System.IO;
using System.Text;
using System.Net.Mail;

public partial class WucAdmin_WucGerarSenha : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["inicio"] == null)
        {
            CarregarDados();
            ViewState["inicio"] = "1";
            ViewState["codCliente"] = string.Empty;
            ViewState["nomeCliente"] = string.Empty;
            ViewState["emailCliente"] = string.Empty;
            ViewState["login"] = string.Empty;
        }
    }

    protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ViewState["codCliente"].ToString().Equals(string.Empty) || ViewState["emailCliente"].ToString().Equals(string.Empty))
            {
                ExibirMensagem.Padrao("Favor selecionar o cliente para enviar a senha.", this.Page);
            }
            else
            {
                string arquivoXML = System.AppDomain.CurrentDomain.BaseDirectory + "\\Senhas";
                if (!Directory.Exists(arquivoXML))
                    Directory.CreateDirectory(arquivoXML);

                string arquivoSenha = arquivoXML + "\\Senha.xml";
                string emailCliente = ViewState["emailCliente"].ToString();
                string login = ViewState["login"].ToString();
                string senha = SenhaAleatoria.GerarSenha();


                ClientesCTL clientesCTL = new ClientesCTL();
                clientesCTL.AlterarSenha(Conversor.ConverterParaInteiro(ViewState["codCliente"].ToString()), senha);


                string _fim = "\r";
                StringBuilder gravarXML = new StringBuilder();

                gravarXML.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" + _fim);
                gravarXML.Append("<usuario>" + _fim);
                gravarXML.Append("		<acesso>" + _fim);
                gravarXML.Append("         <login>" + login.Trim() + "</login>" + _fim);
                gravarXML.Append("         <senha>" + senha.Trim() + "</senha>" + _fim);
                gravarXML.Append("     </acesso>" + _fim);
                gravarXML.Append("</usuario>" + _fim);

                StreamWriter arquivo = new StreamWriter(arquivoSenha);
                arquivo.Write(gravarXML.ToString());
                arquivo.Close();


                if (File.Exists(arquivoSenha))
                {
                    if (!emailCliente.Trim().Equals(string.Empty))
                    {
                        SmtpClient smtpMail = new SmtpClient();
                        smtpMail.Host = ConfigurationManager.AppSettings["smtpEmail"];

                        MailMessage email = new MailMessage();
                        email.From = new MailAddress(ConfigurationManager.AppSettings["emailOrigem"]);
                        //email.To.Add(emailCliente);
                        email.To.Add(ConfigurationManager.AppSettings["emailOrigem"].ToString());
                        email.Subject = "STOK ROCHAS - SENHA";
                        email.IsBodyHtml = true;

                        StringBuilder corpoEmail = new StringBuilder();

                        corpoEmail.Append("Olá " + ViewState["nomeCliente"].ToString() + ",<br><br>");
                        corpoEmail.Append("Enviado Por : STOK ROCHAS LTDA" + "<br>");
                        corpoEmail.Append("Telefone : +55 28 3518-6666" + "<br>");
                        corpoEmail.Append("Assunto : Senha para enviar dados (Gerenciador)" + "<br>");
                        corpoEmail.Append("E-Mail enviado através do site, favor não responder.");

                        email.Body = corpoEmail.ToString();
                        email.Attachments.Add(new Attachment(arquivoSenha));
                        email.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                        email.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                        try
                        {
                            smtpMail.Send(email);
                            ExibirMensagem.Padrao("Mensagem enviada com sucesso.", this.Page);
                        }
                        catch(Exception ex)
                        {
                            ExibirMensagem.Padrao("Ocorreu um erro ao enviar a senha para o cliente."+ex.Message.ToString(), this.Page);
                        }
                    }
                    else
                    {
                        ExibirMensagem.Padrao("Favor cadastrar um e-mail para o cliente.", this.Page);
                    }
                }
            }

        }
        catch (ApplicationException ex)
        {
            ExibirMensagem.Padrao("Ocorreu um erro ao enviar a senha para o cliente. " + ex.Message, this.Page);
        }

    }
    protected void ibtnVoltar_Click(object sender, ImageClickEventArgs e)
    {

    }

    public void CarregarDados()
    {
        ClientesCTL clientesCTL = new ClientesCTL();
        grvClientes.DataSource = clientesCTL.ClientesGeraSenhas();
        grvClientes.DataBind();
    }

    protected void grvClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["codCliente"] = grvClientes.SelectedRow.Cells[0].Text.ToString();
        ViewState["nomeCliente"] = grvClientes.SelectedRow.Cells[1].Text.ToString();
        ViewState["login"] = grvClientes.SelectedRow.Cells[2].Text.ToString();
        ViewState["emailCliente"] = grvClientes.SelectedRow.Cells[3].Text.ToString();
    }
}
