<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fuelzone.Profile" %>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">
        
        <!-- User Information -->
        <section class="row mt-3">
            <div class="col-12">
                <div class="bg-secondary text-white p-4">
                    <h1>Profile</h1>
                    <p class="lead">View your account information and activity.</p>
                    <p><strong>Username:</strong> <asp:Literal ID="UsernameLiteral" runat="server" /></p>
                    <p><strong>Email:</strong> <asp:Literal ID="EmailLiteral" runat="server" /></p>
                </div>
            </div>
        </section>

        <div class="row mt-4">
            <!-- User Comments History -->
            <section class="col-md-12">
                <div class="bg-secondary text-white p-4">
                    <h2>Your Comments History</h2>
                    <div>
                        <asp:Literal ID="UserCommentsLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
            </section>

        </div>
    </main>

</asp:Content>
