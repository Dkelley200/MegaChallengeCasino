<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/Images/" />
            <asp:Image ID="Image2" runat="server" Height="150px" ImageUrl="~/Images/" />
            <asp:Image ID="Image3" runat="server" Height="150px" ImageUrl="~/Images/" />
        </div>
        <p>
            Your Bet:&nbsp; <asp:TextBox ID="yourBetTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="placeBetWarningLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="pullButton" runat="server" OnClick="pullButton_Click" Text="Pull The Lever" />
        </p>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="winningsLabel" runat="server"></asp:Label>
        </p>
        <p>
            1 Cherry - x2 Your Bet</p>
        <p>
            2 Cherries - x3 Your Bet</p>
        <p>
            3 Cherries - x4 Your Bet</p>
        <p>
            3 7&#39;s - Jackpot - x100 Your Bet</p>
        <p>
            HOWEVER ... if there&#39;s even one BAR you win Nothing</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
