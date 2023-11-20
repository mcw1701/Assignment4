<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="Assignment4.member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Hello
    <asp:LoginName ID="LoginName1" runat="server" />
&nbsp;&nbsp;
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SectionID" DataSourceID="SqlDataSource1" Width="874px">
        <Columns>
            <asp:BoundField DataField="SectionID" HeaderText="SectionID" InsertVisible="False" ReadOnly="True" SortExpression="SectionID" />
            <asp:BoundField DataField="SectionName" HeaderText="SectionName" SortExpression="SectionName" />
            <asp:BoundField DataField="SectionStartDate" HeaderText="SectionStartDate" SortExpression="SectionStartDate" />
            <asp:BoundField DataField="Member_ID" HeaderText="Member_ID" SortExpression="Member_ID" />
            <asp:BoundField DataField="Instructor_ID" HeaderText="Instructor_ID" SortExpression="Instructor_ID" />
            <asp:BoundField DataField="SectionFee" HeaderText="SectionFee" SortExpression="SectionFee" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Section]"></asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
