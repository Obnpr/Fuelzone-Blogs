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
                    <h2>Artículos recomendados, guías, etc.</h2>
                    <p>Here you could have guides, articles, or general information about the services or topics related to your site.</p>
                    <p>
                        <a class="btn btn-primary" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                    </p>
                </div>
            </section>

            <!-- Sidebar Section (Featured Posts and Trending Games) -->
<aside class="col-md-4">
    <div class="bg-secondary text-white p-4">
        <p>Total registered members: 0</p>
        <h2>Articulo más destacado</h2>
        <h2>Juego más destacado</h2>

        <!-- Shows current featured games -->
        <div class="row">
            <div class="col-sm-6 mb-3 text-center">
                <a href="/pages/tutorials/valorantpage">
                    <img src="/Assets/GameArtwork/Valorant.jpg" class="img-fluid" alt="Valorant" />
                </a>
                <h5>Valorant</h5>
            </div>
            <div class="col-sm-6 mb-3 text-center">
                <a href="/pages/tutorials/valorantpage">
                    <img src="/Assets/GameArtwork/Valorant.jpg" class="img-fluid" alt="Valorant" />
                </a>
                <h5>Valorant</h5>
            </div>

        </div>
    </div>
</aside>

        </div>
    </main>
</asp:Content>
