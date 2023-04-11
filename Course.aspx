<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3 class="text-center">Course info</h3>
        <div>

            <table style="width: 1099px; border-collapse: collapse">
                <tr>
                    <td style="width: 274px">&nbsp;</td>
                    <td style="width: 202px">Course ID</td>
                    <td>
                        <asp:TextBox ID="text_crsID" runat="server" Width="331px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 274px">&nbsp;</td>
                    <td style="width: 202px">Course Name</td>
                    <td>
                        <asp:TextBox ID="text_crsName" runat="server" Width="331px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 274px">&nbsp;</td>
                    <td style="width: 202px">Course Instructor</td>
                    <td>
                        <asp:TextBox ID="text_crsInstructor" runat="server" Width="331px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 274px">&nbsp;</td>
                    <td style="width: 202px">Credit</td>
                    <td>
                        <asp:TextBox ID="text_credit" runat="server" Width="331px"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

        <br />
        <div class="text-center">
            <asp:Button ID="show_course" runat="server" Text="Courses" OnClick="show_course_Click" />
            <asp:Button ID="insert_course" runat="server" Text="Insert Course" OnClick="insert_course_Click"/>
        </div>
        <div class="text-center">
            <asp:GridView ID="grid_course" runat="server" Width="1099px"></asp:GridView>
        </div>
    </main>
</asp:Content>
