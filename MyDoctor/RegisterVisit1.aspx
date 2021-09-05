<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterVisit1.aspx.cs" Inherits="MyDoctor.RegisterVisit1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.js"></script>

    <script type="text/javascript">
        $(function () {

            $("#<%= tbPESEL.ClientID %>").mask("99999999999");

        });
    </script>
    <h3>Nowa wizyta</h3>
    <table class="table">
        <tr>
            <td>Imię</td>
            <td>
                <asp:TextBox ID="tbFName" Width="250px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Podaj imię" ForeColor="Red"
                    ControlToValidate="tbFName"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Nazwisko</td>
            <td>
                <asp:TextBox ID="tbLName" Width="250px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Podaj nazwisko" ForeColor="Red"
                    ControlToValidate="tbLName"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>PESEL</td>
            <td>
                <asp:TextBox ID="tbPESEL" Width="250px" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                     ErrorMessage="Podaj PESEL" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"
                    ControlToValidate="tbPESEL" ValidateEmptyText="True"></asp:CustomValidator>

                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Podaj PESEL" ForeColor="Red"
                    ControlToValidate="tbPESEL"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>

        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="tbEmail" Width="250px" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="tbEmail" ForeColor="Red" 
                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                    ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Podaj email"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Podaj email" ForeColor="Red"
                    ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Lekarz</td>
            <td>
                <asp:DropDownList ID="ddDoctor" runat="server">
                    <asp:ListItem Value="-1">------</asp:ListItem>
                    <asp:ListItem Value="1">Jan Kowalski - pediatra</asp:ListItem>
                    <asp:ListItem Value="2">Janina Zientek - Dermatolog</asp:ListItem>
                    <asp:ListItem Value="3">Mirosław Baka - Kardiolog</asp:ListItem>
                </asp:DropDownList><asp:RangeValidator 
                    ID="RangeValidator1" runat="server" ForeColor="Red" ControlToValidate="ddDoctor"
                    ErrorMessage="Wybierz lekarza" Type="Integer" MinimumValue="1" MaximumValue="3"></asp:RangeValidator>
            </td>
        </tr>

        <tr>
            <td>Data wizyty</td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="250px" ShowGridLines="True" Width="250px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Red" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
        </tr>

        <tr>
            <td>Klient VIP</td>
            <td>
                <asp:CheckBox ID="cbVIP" runat="server" AutoPostBack="True" OnCheckedChanged="cbVIP_CheckedChanged" />
                <br />
                <asp:TextBox ID="tbVIPNumber" Width="250px" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="btnOK" runat="server" Text="Dalej" /></td>
        </tr>


    </table>

</asp:Content>
