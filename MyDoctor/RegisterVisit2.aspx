<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterVisit2.aspx.cs" Inherits="MyDoctor.RegisterVisit2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h3>Nowa wizyta - informacje dodatkowe</h3>
    <table class="table">

        <tr>
            <td colspan="2">
                <asp:Label ID="lblInfo" runat="server" Text="AAAA CCC BBBB" Font-Bold="true" ></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Opis</td>
            <td>
                <asp:TextBox ID="tbDescr" Width="350px" runat="server" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Załaduj plik (PNG)</td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" Width="350px" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lblResult" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="btnOK" runat="server" Text="Zapisz" OnClick="btnOK_Click" /></td>
        </tr>

    </table>

</asp:Content>
