<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationExample.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbText1" runat="server" 
                Text="Moja pierwsza labelka w ASP.NET" 
                Font-Bold="True" Font-Size="Medium" 
                ForeColor="Black"></asp:Label>

            <br /><br />

            <span style="font-size:large;color:lime">
                <b>Moja pierwsza labelka w ASP.NET</b></span>
        </div>

        <div>
            Podaj imię: <asp:TextBox  ID="tbName" runat="server" MaxLength="50" ToolTip="Wprowadź imię" Width="50%"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="OK" Width="150px" OnClick="Button1_Click" />
        </div>

        <div>
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
