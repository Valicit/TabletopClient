<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayerView.aspx.cs" Inherits="TabletopClient.Pages.PlayerView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="TabletopDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TabletopConnectionString %>" SelectCommand="SELECT [name] FROM [Character]"></asp:SqlDataSource>
        <div>

            <div id="PCLoadListDiv">
                <asp:DropDownList ID="PCLoadList" runat="server" DataSourceID="TabletopDataSource" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
                <asp:Button ID="LoadPC" runat="server" OnClick="LoadPC_Click" Text="Add Member" />
                <asp:Button ID="RemovePC" runat="server" OnClick="RemovePartyMember" Text="Remove Member" />
            </div>
            
            <div id="pcDiv0" runat="server"></div>
            <div id="pcDiv1" runat="server"></div>
            <div id="pcDiv2" runat="server"></div>
            <div id="pcDiv3" runat="server"></div>
            <div id="pcDiv4" runat="server"></div>
            <div id="pcDiv5" runat="server"></div>
        </div>
    </form>
</body>
</html>
