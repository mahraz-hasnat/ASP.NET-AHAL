<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <table style="width: 100%; border-collapse: collapse">
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Student ID</td>
                <td>
                    <asp:TextBox ID="textID" runat="server" Width="272px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ErrorMessage="ID is required" ValidationGroup="validationToCRUD" ControlToValidate="textID" runat="server" />--%>
                    <asp:RequiredFieldValidator ErrorMessage="Enter ID to delete a student" ValidationGroup="validationToDelete" ControlToValidate="textID" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Name</td>
                <td>
                    <asp:TextBox ID="textName" runat="server" Width="272px"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Name Required" ValidationGroup="validationToCRUD" ControlToValidate="textName" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Age</td>
                <td>
                    <asp:TextBox ID="textAge" runat="server" Width="272px"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Age Missing" ValidationGroup="validationToCRUD" ControlToValidate="textAge" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">About</td>
                <td>
                    <asp:TextBox ID="textAbout" runat="server" Width="272px"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Student Info Required" ValidationGroup="validationToCRUD" ControlToValidate="textAbout" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 235px">&nbsp;</td>
                <td style="width: 248px">Course </td>
                <td>
                    <asp:DropDownList ID="crs_list" runat="server" DataSourceID="crs_id" DataTextField="course_name" DataValueField="ID" Width="278px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Choose One Course" ControlToValidate="crs_list" runat="server" />
                    <asp:SqlDataSource ID="crs_id" runat="server" ConnectionString="<%$ ConnectionStrings:test-mhConnectionString %>" SelectCommand="SELECT * FROM [course]"></asp:SqlDataSource>
                </td>
            </tr>
            
        </table>

    </div>
    <div class="text-center">

        <br />
        <br />
        <asp:Button ID="insertStudent" runat="server" ValidationGroup="validationToCRUD" OnClick="InsertStudent" Text="Insert " />
        <asp:Button ID="updateStudent" runat="server" ValidationGroup="validationToCRUD" OnClick="UpdateStudent" Text="Update" />
        <asp:Button ID="deleteStudent" runat="server" ValidationGroup="validationToDelete" OnClick="DeleteStudent" Text="Delete" />
        <br />
        <br />

    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" Width="1004px">
        </asp:GridView>

    </div>

</asp:Content>
