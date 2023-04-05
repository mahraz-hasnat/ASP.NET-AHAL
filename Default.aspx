<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspWebapp2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div>
            <h3 class="text-center">ASP.NET Task</h3>
        </div>
        <div class="text-center">

            <asp:Button ID="show" runat="server" Text="SHOW" OnClick="show_Click" />
            <asp:Button ID="insert" runat="server" Text="INSERT" OnClick="insert_Click" />
            <asp:Button ID="update" runat="server" Text="UPDATE" OnClick="update_Click" />
            <asp:Button ID="delete" runat="server" Text="DELETE" OnClick="delete_Click" />

            <br />
            <br />

        </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" Width="1083px">
            </asp:GridView>

        </div>

        <div>

        </div>
    </div>

</asp:Content>
