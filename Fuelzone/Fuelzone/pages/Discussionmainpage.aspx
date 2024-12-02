<%@ Page Title="Discussions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussionmainpage.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4 game-icon-section" aria-labelledby="title">
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>Game list</h2>
            </div>
        </section>

        <div class="row mt-4">
            <!-- Game Icons/Categories -->
            <section class="col-md-8">
                <div class="p-4">
                    <div class="row">
                        <!-- Example Game Icons -->
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/discussion/CODBlackOps6page">
                                <img src="/Assets/GameArtwork/CODBlackOps6.jpg" class="img-fluid" alt="Call of Duty: Black Ops 6" />
                            </a>
                            <h5>Call of Duty: Black Ops 6</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/discussion/Fortnitepage">
                                <img src="/Assets/GameArtwork/Fortnite.jpg" class="img-fluid" alt="Fortnite" />
                            </a>
                            <h5>Fortnite</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/discussion/Valorantpage">
                                <img src="/Assets/GameArtwork/Valorant.jpg" class="img-fluid" alt="Valorant" />
                            </a>
                            <h5>Valorant</h5>
                        </div>
                        <!-- Add more games here -->
                    </div>
                </div>
            </section>
            <hr>
            <section class="community-guidelines-section">
                <!-- Community Chatting Guidelines Section -->
                <h2>Community Chatting Guidelines</h2>
                <p>To keep our community safe and friendly, at Fuelzone we encourage all members to adhere to the following guidelines:</p>
                <p><strong>Respect Others:</strong></p>
                <p>Please be respectful when participating in discussions...</p>

                <p><strong>No Spamming:</strong></p>
                <p>Keep your contributions meaningful...</p>

                <p><strong>Stay On-Topic:</strong></p>
                <p>Ensure that your contributions remain relevant to the ongoing discussion...</p>

                <p><strong>Use Appropriate Language:</strong></p>
                <p>Maintain a respectful and family-friendly tone...</p>

                <p><strong>Be Helpful:</strong></p>
                <p>If you have knowledge that can help others...</p>

                <p><strong>Report Issues:</strong></p>
                <p>If you come across posts or behaviors that violate these guidelines...</p>
            </section>
        </div>
    </main>
</asp:Content>
