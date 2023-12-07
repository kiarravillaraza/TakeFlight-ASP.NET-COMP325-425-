<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightsPage.aspx.cs" Inherits="TakeFlight_ASP.NET_.FlightsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Take Flight - Flights</title>
       <style>
        /* Center the container horizontally and vertically */
#Username {
    display: block;
    margin-left: 425px; 
    margin-bottom: 40px;

}
    </style>
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

            <asp:Literal ID="LiteralFlightInfo" runat="server" />

            <br />
            <div class="divider"></div>
            <br />

            <ul> Enter your username to see previously created flights.</ul>
                
            <asp:TextBox ID="Username" Text="" runat="server" Width="400px" Height= "25px"></asp:TextBox>
     
 
        <div class="flex-container">
        <div class="flex-item">
                <asp:Image ID="Image1" runat="server" ImageUrl="2p.png" Height="200px" Width="230px" />
        </div>
        <div class="flex-item">
                <p>
                    <asp:Button ID="CreateAccount" runat="server" Text="View History" onClick="button3_Click" Height="78px" Width="293px" OnClientClick="return ValidateForm();" />
                </p>
        </div>
        <div class="flex-item">
            <asp:Image ID="Image2" runat="server" ImageUrl="2p.png" Height="200px" Width="230px" />
        </div>
    </div>
    </form>
</body>
</html>
