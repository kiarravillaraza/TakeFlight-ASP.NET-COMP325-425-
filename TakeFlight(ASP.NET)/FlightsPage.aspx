<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightsPage.aspx.cs" Inherits="TakeFlight_ASP.NET_.FlightsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Take Flight - Flights</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Raleway:wght@400;700&display=swap"/>
    <link rel="stylesheet" type="text/css" href="FlightsPageStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
        
            <nav>
            <a href="https://localhost:44324/UserForm.aspx#"><img src="profile.png" alt="Profile"/> PROFILE</a>
            <a href="https://localhost:44324/FlightsPage.aspx#"><img src="flights.png" alt="Flights"/> FLIGHTS</a>
            <a href="https://localhost:44324/FlightForm.aspx#"><img src="create.png" alt="Create"/> CREATE</a>
            <a href="https://localhost:44324/Drinks.html#"><img src="drinks.png" alt="Drinks"/> DRINKS</a>
          </nav>
    <div class="divider"></div>
    <h2 class="h2">FLIGHTS</h2>
            <div class="divider"></div>

        <div>


            <asp:Literal ID="LiteralFlightInfo" runat="server" />

            <br />
            <div class="divider"></div>
            <br />

            <h2 class="h3">Enter Username to View Historical Flights</h2>

                        <td class="auto-style2">
                <asp:TextBox ID="Username" Text="" runat="server" Width="705px" CssClass="auto-style8"></asp:TextBox>
            </td>
                <div class="flex-item">
        <p>
            <asp:Button ID="CreateAccount" runat="server" Text="View History" onClick="button3_Click" Height="78px" Width="293px" OnClientClick="return ValidateForm();" />
        </p>
    </div>

        </div>
    </form>
</body>
</html>
