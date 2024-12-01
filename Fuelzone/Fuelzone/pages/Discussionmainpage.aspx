<%@ Page Title="Discussions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussionmainpage.aspx.cs" Inherits="Fuelzone.Contact" %>

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
                            <a href="/pages/tutorials/Minecraftpage">
                                <img src="/Assets/GameArtwork/Minecraft.jpg" class="img-fluid" alt="Minecraft" />
                            </a>
                            <h5>Minecraft</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorials/Destiny2page">
                                <img src="/Assets/GameArtwork/Destiny2.jpg" class="img-fluid" alt="Destiny 2" />
                            </a>
                            <h5>Destiny 2</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorials/Oldschoolrunescapepage">
                                <img src="/Assets/GameArtwork/Oldschoolrunescape.jpg" class="img-fluid" alt="Old School Runescape" />
                            </a>
                            <h5>Old School Runescape</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorials/Valorantpage">
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
                    <h4>Most Talked Discussions</h4>
                    <ul class="list-unstyled">
                        <li>
                            <a href="/Tutorials/Featured1" class="text-white">Valorant</a>
                        </li>
                        <li>
                            <a href="/Tutorials/Featured2" class="text-white">Featured Game Tutorial 2</a>
                        </li>
                        <li>
                            <a href="/Tutorials/Featured3" class="text-white">Featured Game Tutorial 3</a>
                        </li>
                        <!-- Add more features -->
                    </ul>
                </div>
            </aside>
        </div>
    </main>
</asp:Content>
