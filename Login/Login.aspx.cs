using MAPDataClassLib.DAO;
using MAPDataClassLib.Funcoes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TutorialLoginDAO;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.InicializarDb();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            bool logado = usuarioDAO.GetByLoginSenha(txtLogin.Text, txtSenha.Text);

            if (logado)
            {
                //Server.Transfer("pagina.aspx");
                Session["Usuario"] = txtLogin.Text;
                Response.Redirect("Principal.aspx");
                //lblResultado.Text = "Bem Vindo";
            }
            else
                lblResultado.Text = "Usuário ou Senha Inválido";
        }
    }
}