<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="TakeFlight_ASP.NET_.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Take Flight - Create Account</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Raleway:wght@400;700&display=swap"/>
    <link rel="stylesheet" type="text/css" href="UserStyle.css"/>
<script>
    function ValidateForm() {
        // Your client-side validation logic here
        var fullName = document.getElementById('<%= FullName.ClientID %>').value;
        var username = document.getElementById('<%= Username.ClientID %>').value;
        var password = document.getElementById('<%= Password.ClientID %>').value;
        var birthday = document.getElementById('<%= Birthday.ClientID %>').value;


        // Checks if any of the fields are empty
        if (fullName === '' || username === '' || password === '') {
            alert('All fields must be filled out.');
            return false;
        }

        // If passes, proceed with server-side logic
        return true;
    }
</script>
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
</head>
<body class="back">

        <form id="form2" runat="server" class="form">

<div class="flex-container">
    <div class="flex-item">
        <asp:ImageButton ID="ProfileButton" runat="server" ImageUrl="profile.png" PostBackUrl="~/UserForm.aspx" Height="150px" Width="230px" />
        <p>PROFILE</p>
    </div>
    <div class="flex-item">
        <asp:ImageButton ID="CreateButton" runat="server" ImageUrl="create.png" PostBackUrl="~/FlightForm.aspx" Height="150px" Width="230px" />
        <p>CREATE</p>
    </div>
    <div class="flex-item">
        <asp:ImageButton ID="FlightsButton" runat="server" ImageUrl="flights.png" NavigateUrl="Flights.html" Height="150px" Width="230px" />
        <p>FLIGHTS</p>
    </div>
    <div class="flex-item">
        <a href="https://localhost:44324/Drinks.html" style="text-decoration: none;">
            <asp:ImageButton ID="DrinksButton" runat="server" ImageUrl="drinks.png" Height="150px" Width="230px" />
            <p>DRINKS</p>
        </a>
    </div>
</div>

    <div class="divider"></div>
<div class="image-and-text">
    <h2 class="h2">PREPARE TO TAKE FLIGHT</h2>
</div>
    <h4 class ="h4">Please fill in all of the fields below.</h4>
    <table class="auto-style9">
        
        <!-- Email -->
        <tr>
            <td class="auto-style4">
                <br />
                Enter your email
                <br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="FullName" Text="" runat="server" Width="705px" CssClass="auto-style8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FullNameValidator" runat="server"
                    ControlToValidate="FullName"
                    Display="Dynamic"
                    ErrorMessage="Full name is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <!-- Username -->
        <tr>
            <td class="auto-style4">
                <br />
                Create a username
                <br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="Username" Text="" runat="server" Width="705px" CssClass="auto-style8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UsernameValidator" runat="server"
                    ControlToValidate="Username"
                    Display="Dynamic"
                    ErrorMessage="Username is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <!-- Password -->
        <tr>
            <td class="auto-style4">
                <br />
                Create a password
                <br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="Password" Text="" runat="server" Width="705px" CssClass="auto-style8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordValidator" runat="server"
                    ControlToValidate="Password"
                    Display="Dynamic"
                    ErrorMessage="Password is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr> 
            <td class="auto-style4">
                <br />
                Enter your birthday 
                <br />
                (MM-DD-YYY)
                <br />
                <br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="Birthday" Text="" runat="server" Width="705px" CssClass="auto-style8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="BirthdayValidator" runat="server"
                    ControlToValidate="Birthday"
                    Display="Dynamic"
                    ErrorMessage="Password is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>

    </table>
        <div class="flex-container">
    <div class="flex-item">
        <asp:Image ID="Image1" runat="server" ImageUrl="2p.png" Height="200px" Width="230px" />
    </div>
    <div class="flex-item">
        <p>
            <asp:Button ID="CreateAccount" runat="server" Text="Create Account" onClick="button1_Click" Height="78px" Width="293px" OnClientClick="return ValidateForm();" />
        </p>
    </div>
    <div class="flex-item">
        <asp:Image ID="Image2" runat="server" ImageUrl="2p.png" Height="200px" Width="230px" />
    </div>
</div>
   </form>
</body>
</html>