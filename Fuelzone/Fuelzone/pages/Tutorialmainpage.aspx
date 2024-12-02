<%@ Page Title="Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorialmainpage.aspx.cs" Inherits="Fuelzone.pages.Tutorialmainpage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
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
                            <a href="/pages/tutorials/CODBlackOps6page">
                                <img src="/Assets/GameArtwork/CODBlackOps6.jpg" class="img-fluid" alt="Call of Duty: Black Ops 6" />
                            </a>
                            <h5>Call of Duty: Black Ops 6</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorials/Fortnitepage">
                                <img src="/Assets/GameArtwork/Fortnite.jpg" class="img-fluid" alt="Fortnite" />
                            </a>
                            <h5>Fortnite</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorial/Valorantpage">
                                <img src="/Assets/GameArtwork/Valorant.jpg" class="img-fluid" alt="Valorant" />
                            </a>
                            <h5>Valorant</h5>
                        </div>
                        <!-- Add more games here -->
                    </div>
                </div>
            </section>

            <!-- Featured Game Tut. -->
            <aside class="col-md-4">
                <div class="bg-secondary text-white p-4">
                    <h4>Featured game</h4>
                    <ul class="list-unstyled">
                        <li>
                            <a id="featuredGameLink" runat="server" class="text-white">
                                <img id="featuredGameImage" runat="server" style="max-width: 100%; height: auto;" />
                                <span id="featuredGameTitle" runat="server"></span>
                            </a>
                        </li>
                    </ul>
                </div>
            </aside>
        </div>
    </main>
</asp:Content>
