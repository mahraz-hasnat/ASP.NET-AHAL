<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <table style="width: 100%; border-collapse: collapse">
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Student ID</td>
                <td>
                    <asp:TextBox ID="id" runat="server" Width="272px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Name</td>
                <td>
                    <asp:TextBox ID="name" runat="server" Width="272px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Age</td>
                <td>
                    <asp:TextBox ID="age" runat="server" Width="272px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">About</td>
                <td>
                    <asp:TextBox ID="about" runat="server" Width="272px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Course </td>
                <td>
                    <asp:DropDownList ID="crs_list" runat="server" DataSourceID="crs_id" DataTextField="course_name" DataValueField="ID" Width="278px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="crs_id" runat="server" ConnectionString="<%$ ConnectionStrings:test-mhConnectionString %>" SelectCommand="SELECT * FROM [course]"></asp:SqlDataSource>
                </td>
            </tr>
            
        </table>

    </div>
    <div class="text-center">

        <br />
        <br />
        <asp:Button ID="insertStudent" runat="server" OnClick="InsertStudent" Text="Insert " />
        <asp:Button ID="updateStudent" runat="server" OnClick="UpdateStudent" Text="Update" />
        <asp:Button ID="deleteStudent" runat="server" OnClick="DeleteStudent" Text="Delete" />
        <br />
        <br />

    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" Width="1004px">
        </asp:GridView>

    </div>

</asp:Content>
