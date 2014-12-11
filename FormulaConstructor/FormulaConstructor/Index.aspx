<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FormulaConstructor.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 331px">
    <form id="mainForm" runat="server">
    <div>
    
        <asp:Label ID="title" runat="server" Text="Formula Constructor"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="Formula" runat="server" AutoPostBack="True" Height="118px" TextMode="MultiLine" Width="226px"></asp:TextBox>
        <br />
        <br />
        <asp:DropDownList ID="IndependentVariables" runat="server" OnSelectedIndexChanged="IndependentVariables_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="Responses" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="MathFunctions" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonHelp" runat="server" Text="Help" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonOk" runat="server" Text="OK" Width="42px" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
    
    </div>
    </form>
</body>
</html>
