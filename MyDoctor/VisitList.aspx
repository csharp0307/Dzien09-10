<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisitList.aspx.cs" Inherits="MyDoctor.VisitList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3>Lista wizyt</h3>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
            <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
            <asp:BoundField DataField="pesel" HeaderText="pesel" SortExpression="pesel" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="doctor" HeaderText="doctor" SortExpression="doctor" />
            <asp:BoundField DataField="card" HeaderText="card" SortExpression="card" />
            <asp:BoundField DataField="visit_date" HeaderText="visit_date" SortExpression="visit_date" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="descr" HeaderText="descr" SortExpression="descr" />
            <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:edoctorConnectionString %>" ProviderName="<%$ ConnectionStrings:edoctorConnectionString.ProviderName %>" SelectCommand="SELECT * FROM visits"></asp:SqlDataSource>
</asp:Content>
