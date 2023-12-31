﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanelUpdate.aspx.cs" Inherits="FormProject2.AdminPanelUpdate" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/AdminPanel.css" rel="stylesheet" />
    <link rel="icon" href="/Images/Jubilee%20Logo%202.jpg" type="image/x-icon" />
    <title>Admin Panel</title>
</head>
<body>
    <div class="container-bg">
        <div class="image">
            <img src="Images/Jubilee_Logo_2-bgr.png" />
        </div>
    </div>
    <div class="login-form">
        <form id="signupForm" runat="server" class="signup-form">
            <h1>Edit Details</h1>
            <div class="input-container">
                <asp:TextBox ID="txtEmployeeID" runat="server" placeholder="Employee Code"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="EmployeeIdValidator" runat="server" ForeColor="#BA0C25" ControlToValidate="txtEmployeeID" Display="Dynamic" SetFocusOnError="True">*Required</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtEmployeeID" Display="Dynamic" ForeColor="#BA0C25" MaximumValue="99999999" MinimumValue="10000000" SetFocusOnError="True" Type="Integer">Employee ID Should be of Six digits</asp:RangeValidator>

            <div class="input-container">
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="UsernameValidator" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="#BA0C25" SetFocusOnError="True">*Required</asp:RequiredFieldValidator>
            <div class="input-container">
                <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="FullNameValidator" runat="server" ControlToValidate="txtFullName" Display="Dynamic" ForeColor="#BA0C25" SetFocusOnError="True">*Required</asp:RequiredFieldValidator>
            <div class="input-container">
                <asp:TextBox ID="txtemail" runat="server" placeholder="Email"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" Display="Dynamic" ForeColor="#BA0C25" SetFocusOnError="True">*Required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@jubileelife\.com$"
                ForeColor="#BA0C25" Display="Dynamic" SetFocusOnError="True">Invalid email format or domain.</asp:RegularExpressionValidator>
            <div class="input-container">
                <asp:TextBox ID="txtRole" runat="server" placeholder="Role"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RoleValidator" runat="server" ControlToValidate="txtRole" Display="Dynamic" ForeColor="#BA0C25" SetFocusOnError="True">*Required</asp:RequiredFieldValidator>
            <div class="input-container">
                <asp:TextBox ID="TxtDepartment" runat="server" placeholder="Department"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDepartment" Display="Dynamic" ForeColor="#BA0C25" SetFocusOnError="True">*Required</asp:RequiredFieldValidator>
            <div>
                <div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="submit-button" OnClick="btnSubmit_Click" />
                </div>
                <br />
                <div class="form-links">
                    <a href="LoginPage.aspx" class="signup-link" id="logoutLink2">Already have an account? Log In</a>
                </div>
                <div class="form-links">
                    <a href="RegisterPage.aspx" class="signup-link" style="margin-left: 60px;" id="logoutLink">Go To Details Page</a>
                </div>
                <div class="form-links">
                    <a href="AdminPanel.aspx" class="signup-link" style="margin-left: 45px;">Insert New Employees?</a>
                </div>
                <br />
                <asp:Label ID="RegisterLabel" runat="server" ForeColor="#BA0C25" Visible="false"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>

<script>
    document.getElementById("logoutLink").addEventListener("click", function () {
                // Clear session
                <%= "Session.Clear();" %>
                <%= "Session.Abandon();" %>

        // Clear authentication cookies
        var cookie = document.cookie = "FormsAuthenticationCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";

        // Redirect to login page
        window.location.href = "/RegisterPage.aspx";
    });
    document.getElementById("logoutLink2").addEventListener("click", function () {
           // Clear session
           <%= "Session.Clear();" %>
           <%= "Session.Abandon();" %>


        // Clear authentication cookies
        var cookie = document.cookie = "FormsAuthenticationCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";

        // Redirect to login page
        window.location.href = "/LoginPage.aspx";
    });
</script>
