<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSSDemo.aspx.cs" Inherits="C3_SimpleDemo.CSSDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>@import url(StyleSheet.css);</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" CssClass="label" Text="Label"></asp:Label>
    
    </div>
    </form>
    <p>
        Normal text</p>
</body>
</html>
