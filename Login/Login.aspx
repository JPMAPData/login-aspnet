<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login: <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox> <br />
            Senha: <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox> <br />
            <asp:Button ID="btnLogin" runat="server" Text="Button" OnClick="btnLogin_Click" />
            <br />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
