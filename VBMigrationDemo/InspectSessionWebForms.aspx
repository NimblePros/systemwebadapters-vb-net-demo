<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="InspectSessionWebForms.aspx.vb" Inherits="VBMigrationDemo.InspectSessionWebForms" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exploring Session for WebForms to .NET Core Migration</h1>    
    <div>
        <h1>Session Variables</h1>
        <asp:Label ID="lblContent" runat="server"></asp:Label>
        <hr />
        <asp:Button OnClick="UpdateSession_Click" runat="server" Text="Update Session" />
        <asp:Button OnClick="DisplaySession_Click" runat="server" Text="Display Session" />
        <asp:Button OnClick="ClearOutput_Click" runat="server" Text="Clear Output" />
    </div>
</asp:Content>
