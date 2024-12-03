<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sign_in.aspx.cs" Inherits="Fuelzone.pages.user_registration.signin.Sign_in" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <div class="row justify-content-center">
            <h2 class="text-center sign-up-heading">Sign In</h2>

            <!-- Email Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Email Address" CssClass="form-label" ClientIDMode="Static"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Password Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label" ClientIDMode="Static"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Sign-In Button -->
            <div class="form-group mb-3 text-center">
                <asp:Button ID="btnSignin" runat="server" Text="Sign In" OnClick="btnSignin_Click" CssClass="btn btn-primary btn-block btn-signup"></asp:Button>
            </div>

            <!-- Message Label -->
            <div class="form-group text-center">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </main>
</asp:Content>
