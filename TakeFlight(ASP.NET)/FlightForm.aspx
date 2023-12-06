<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightForm.aspx.cs" Inherits="TakeFlight_ASP.NET_.FlightForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Take Flight - Create Flight</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Raleway:wght@400;700&display=swap"/>
    <link rel="stylesheet" type="text/css" href="FlightStyle.css"/>
</head>
<body class="back">
        <form id="form1" runat="server" class="form">

            <nav>
            <a href="https://localhost:44324/UserForm.aspx#"><img src="profile.png" alt="Profile"/> PROFILE</a>
            <a href="#"><img src="flights.png" alt="Flights"/> FLIGHTS</a>
            <a href="https://localhost:44324/FlightForm.aspx#"><img src="create.png" alt="Create"/> CREATE</a>
            <a href="https://localhost:44324/Drinks.html#"><img src="drinks.png" alt="Drinks"/> DRINKS</a>
          </nav>

         
 

    <div class="divider"></div>
            

<div class="image-and-text">
    <h2 class="h2">ARE YOU READY TO <br /> &nbsp;&nbsp;&nbsp;&nbsp; TAKE FLIGHT?</h2>
</div>
    <h4 class ="h4">Please fill in all of the fields below.</h4>
    <table class="auto-style10">
        
        <!-- Username -->
        <tr>
            <td class="auto-style4">
                <br />
                Enter your Username
                <br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="UserID" Text="" runat="server" Width="463px" CssClass="auto-style8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UsernameValidator" runat="server"
                    ControlToValidate="UserID"
                    Display="Dynamic"
                    ErrorMessage="User ID is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
        
        <!-- Flight name -->
        <tr>
            <td class="auto-style4">
                <br />
                Create a name for your flight
                <br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="FlightName" Text="" runat="server" Width="466px" CssClass="auto-style8"></asp:TextBox>
            </td>
        </tr>
        
        <!-- Number of drinks -->
        <tr>
            <td class="auto-style4">
                <br />
                Select the number of
                <br />
                drinks in your flight<br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddlNumDrinks" runat="server" Width="483px" CssClass="auto-style8">
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <!-- Strength of drinks -->
        <tr>
            <td class="auto-style4">
                <br />
                Choose the strength of<br />
                your drinks<br />
&nbsp;<br />

            </td>
            <td class="auto-style2">
                <asp:RadioButtonList ID="DrinkStrength" runat="server" CssClass="auto-style8" Width="506px">
                    <asp:ListItem Text=" Weak" Value="weak"></asp:ListItem>
                    <asp:ListItem Text=" Normal" Value="normal"></asp:ListItem>
                    <asp:ListItem Text=" Strong" Value="strong"></asp:ListItem>
                    <asp:ListItem Text=" Very Strong" Value="veryStrong"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td class="auto-style5">
                Select your base <br />
                liquor(s)</td>
            <td class="auto-style6">
                <asp:CheckBox ID="Vodka" runat="server" CssClass="auto-style9" Text=" Vodka" /> <br />
                <asp:CheckBox ID="Whiskey" runat="server" CssClass="auto-style9" Text=" Whiskey" /> <br />
                <asp:CheckBox ID="Rum" runat="server" CssClass="auto-style9" Text=" Rum" />  <br />
                <asp:CheckBox ID="Gin" runat="server" CssClass="auto-style9" Text=" Gin" /> <br />
                <asp:CheckBox ID="Brandy" runat="server" CssClass="auto-style9" Text=" Brandy" /> <br />
                <asp:CheckBox ID="Tequila" runat="server" CssClass="auto-style9" Text=" Tequila" /> <br />
            </td>
        </tr>
    </table>
        <div class="flex-container">
    <div class="flex-item">
        <asp:Image ID="Image1" runat="server" ImageUrl="2p.png" Height="200px" Width="230px" />
    </div>
    <div class="flex-item">
        <p>
            <asp:Button ID="button1" runat="server" Text="Take Flight" onClick="button1_Click" Height="78px" Width="293px" />
        </p>
    </div>
    <div class="flex-item">
        <asp:Image ID="Image2" runat="server" ImageUrl="2p.png" Height="200px" Width="230px" />
    </div>
</div>
   </form>
</body>
</html>