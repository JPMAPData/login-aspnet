<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Login.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Escolha o projeto pertinente entre os dispostos abaixo:</h1>
            <asp:TreeView ID="treProjetos" runat="server" OnSelectedNodeChanged="treProjetos_SelectedNodeChanged" ShowCheckBoxes="All"></asp:TreeView>
            <%--<asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>--%>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
            <asp:Button ID="Button1" runat="server" Text="Upload" />
        </div>
    </form>
</body>
</html>
