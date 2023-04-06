<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspWebapp2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div style="height: 64px">
            <h3 class="text-center">ASP.NET Task</h3>
            <br />
            <br />
        </div>
        
        <div>
            
            
            
            <table class="w-100" style="width: 105%">
                <tr>
                    <td class="text-start" style="width: 488px">
                    <formview>
                        <p><label>Courrse ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>&nbsp;&nbsp; <input id="cid" type="number" name="cid" value="" /></p>
                        <p><label>Courrse Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </label>
                            <input id="cname" type="text" name="cname" value="" /></p>
                        <p><label>Courrse Instructor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label><input id="instructor" type="text" name="instructor" value="" /></p>
                        <p><label>Courrse Credit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>
                            <input id="credit" type="number" name="credit" value="" /></p>
                        <asp:Button ID="insert_course" runat="server" Text="INSERT COURSE" OnClick="insert_course_Click" />
                    </formview> &nbsp;</td>
                    <td class="text-start">
                        
                    <formview>
                        <p><label>Student ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>&nbsp;&nbsp; <input id="id" type="number" name="id" value="" /></p>
                        <p><label>Student Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </label>
                            <input id="name" type="text" name="name" value="" /></p>
                        <p><label>Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>
                            <input id="age" type="number" name="age" value="" /></p>
                        <p><label>About&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>
                            <input id="about" type="text" name="about" value="" /></p>
                        <p><label>Course ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>&nbsp;&nbsp;&nbsp; <input id="id0" type="number" name="id0" value="" /></p>
                        <asp:Button ID="insert" runat="server" Text="INSERT STUDENT" OnClick="insert_Click" />
                    </formview> &nbsp;</td>
                </tr>
            </table>
        </div>
        
        <br />
        <br />
        
        <div class="text-center">


            <asp:Button ID="show" runat="server" Text="SHOW" OnClick="show_Click" />
            
            <asp:Button ID="update" runat="server" Text="UPDATE" OnClick="update_Click" />
            <asp:Button ID="delete" runat="server" Text="DELETE" OnClick="delete_Click" />

            <br />
            <br />

        </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" Width="1083px">
            </asp:GridView>

        </div>


    </div>

</asp:Content>
