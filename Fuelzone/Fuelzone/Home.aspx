<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Fuelzone._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <!-- Top Section: Welcome Message -->
        <section class="row mt-3">
            <div class="col-12">
                <div class="bg-secondary text-white p-4">
                    <h1>Welcome to Fuelzone!</h1>
                    <p class="lead">Most comprehensive, well-documented, easy to follow tutorials for the most exciting games today!</p>
                </div>
            </div>
        </section>

        <!-- Main Content Section -->
        <div class="row mt-4">
            <!-- Articles Section (Main Area) -->
            <section class="col-md-8">
                <div class="bg-secondary text-white p-4">
                    <h2>What we provide?</h2>
                    <p>We provide high quality tutorial guides, a very in-depth discussions, and more to come!</p>
                    <p>
                        <a class="btn btn-primary" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                    </p>
                </div>
            </section>
            <!-- Sidebar Section (Featured Posts and Trending Games) -->
            <aside class="col-md-4">
                <div class="bg-secondary text-white p-4">
                    <p><asp:Literal ID="RegisteredUserCountLiteral" runat="server" /></p>
                    <h2>Most discussed games</h2>
                    <!-- Shows current featured games -->
                    <asp:Literal ID="MostDiscussedGameLiteral" runat="server" />
                </div>
            </aside>
        </div>
    </main>
</asp:Content>
