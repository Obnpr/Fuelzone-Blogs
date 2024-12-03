<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Fuelzone._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <!-- Top Section: Welcome Message -->
        <section class="row mt-3">
            <div class="col-12">
                <div class="text-white p-4" style="background-color: #3a1d5a;">
                    <h1>Welcome to Fuelzone!</h1>
                    <p class="lead">Most comprehensive, well-documented, easy to follow tutorials for the most exciting games today!</p>
                </div>
            </div>
        </section>

        <!-- Main Content Section -->
        <div class="row mt-4">
            <!-- Articles Section (Main Area) -->
            <section class="col-md-8">
                <div class="text-white p-4" style="background-color: #3a1d5a;">
                    <h2>What we provide?</h2>
                    <p>We provide high quality tutorial guides, a very in-depth discussions, and more to come!</p>
                </div>

                <!-- New User Sign Up Box -->
                <div id="newUserBox" class="text-white p-4" style="background-color: #3a1d5a; margin-top: 30px;" runat="server">
                    <h2>New User?</h2>
                    <p>Create an account to enjoy all the benefits of our platform, including discussions and tutorials!</p>
                    <p>
                        <a class="btn btn-primary" href="/pages/user_registration/signup/sign_up.aspx">Sign Up &raquo;</a>
                    </p>
                </div>

                <div class="row mt-4">
                    <!-- Top Comments Section Expanded -->
                    <div class="col-md-12">
                        <div class="text-white p-4" style="background-color: #3a1d5a;">
                            <h2>Top Comments</h2>
                            <div>
                                <asp:Literal ID="TopCommentsLiteral" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <!-- Sidebar Section (Featured Posts and Trending Games) -->
            <aside class="col-md-4">
                <div class="text-white p-4" style="background-color: #3a1d5a;">
                    <p><asp:Literal ID="RegisteredUserCountLiteral" runat="server" /></p>
                    <h2>Most discussed games</h2>
                    <!-- Shows current featured games -->
                    <div class="row">
                        <asp:Literal ID="MostDiscussedGameLiteral" runat="server" />
                    </div>
                </div>

                <!-- Games You May Like Section -->
                <div id="gamesYouMayLikeBox" class="text-white p-4 mt-4" style="background-color: #3a1d5a;" runat="server">
                    <h2>Games You May Like</h2>
                    <div class="row" id="games-container">
                        <asp:Literal ID="RecommendedGamesLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
            </aside>
        </div>
    </main>
</asp:Content>
