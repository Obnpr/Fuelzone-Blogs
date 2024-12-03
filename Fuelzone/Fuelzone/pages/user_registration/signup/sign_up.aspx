<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sign_up.aspx.cs" Inherits="Fuelzone.pages.user_registration.signup.sign_up" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <div class="row justify-content-center">
            <h2 class="text-center sign-up-heading">Sign Up</h2>

            <!-- Username Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Email Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Password Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Sign-Up Button -->
            <div class="form-group mb-3 text-center">
                <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" CssClass="btn btn-primary btn-block btn-signup" />
            </div>

            <!-- Message Label -->
            <div class="form-group text-center">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </main>
</asp:Content>
