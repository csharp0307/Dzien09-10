<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVisit.aspx.cs" Inherits="MyDoctor.EditVisit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Zmiana statusu wizyty</h3>
    <table class="table">

        <tr>
            <td>Zmiana statusu                
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="0">---</asp:ListItem>
                    <asp:ListItem Value="1">AKCEPTACJA</asp:ListItem>
                    <asp:ListItem Value="-1">ANULOWANO</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lblResult" ForeColor="Red" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <asp:HiddenField ID="tbHiddenId" runat="server" />
        <tr>
            <td colspan="2">
                <asp:Button ID="btnOK" runat="server" Text="Zapisz" OnClick="btnOK_Click" /></td>
        </tr>
    </table>

</asp:Content>
