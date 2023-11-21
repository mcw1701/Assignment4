<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Assignment4.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">
                Members
            </asp:TableHeaderCell>
            <asp:TableHeaderCell runat="server">
                Instructors
            </asp:TableHeaderCell>
            <asp:TableHeaderCell runat="server">
                Add Member To Section
            </asp:TableHeaderCell>
            <asp:TableHeaderCell runat="server">
                Create New Member Or Instructor
            </asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell>
                <asp:GridView ID="MembersGridView" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:CommandField ShowSelectButton="true" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                    <asp:GridView ID="InstructorsGridView" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                            <asp:CommandField ShowSelectButton="true" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                Section: <asp:DropDownList ID="ddlSections" runat="server" DataSourceID="SqlDataSource1" DataTextField="SectionName" DataValueField="SectionID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchool_1_ConnectionString %>" SelectCommand="SELECT [SectionID], [SectionName] FROM [Section]"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlSections" Text="Please Select A Section" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />Section Fee: <asp:TextBox ID="tbxFee" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddMemberToSection" runat="server" Text="Add Member To Section" OnClick="btnAddMemberToSection_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <br />User Type:
                <asp:DropDownList ID="ddlUserType" runat="server" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
                    <asp:ListItem Text="Instructor" Value="Instructor"></asp:ListItem>
                </asp:DropDownList>
                <br />Username: <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbxUsername" Text="Please Enter Username" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />Password: <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbxPassword" Text="Please Enter Password" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />First Name: <asp:TextBox ID="tbxFirst" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" ControlToValidate="tbxFirst" Text="Please Enter First Name"></asp:RequiredFieldValidator>
                <br />Last Name: <asp:TextBox ID="tbxLast" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" Text="Please Enter Last Name" Display="Dynamic" ControlToValidate="tbxLast"></asp:RequiredFieldValidator>
                <br />Phone Number: <asp:TextBox ID="tbxPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbxPhone" Text="Please Enter Phone Number" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Panel ID="Panel1" runat="server" Visible="True">
                    Email: <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbxEmail" Text="Please Enter Email" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:Panel>
                <asp:Button ID="btnCreateNewUser" runat="server" Text="Create New User" OnClick="btnCreateNewUser_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </asp:Content>
