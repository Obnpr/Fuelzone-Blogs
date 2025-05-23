﻿<%@ Page Title="Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorialmainpage.aspx.cs" Inherits="Fuelzone.pages.Tutorialmainpage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>Game List</h2>
            </div>
        </section>

        <!-- Main Content Section -->
        <div class="row mt-4">
            <!-- Game Icons/Categories Section -->
            <section class="col-md-8">
                <div class="p-4">
                    <div class="row">
                        <!-- BO6 -->
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorial/CODBlackOps6page">
                                <img src="/Assets/GameArtwork/CODBlackOps6.jpg" class="img-fluid" alt="Call of Duty: Black Ops 6" />
                            </a>
                            <h5>Call of Duty: Black Ops 6</h5>
                        </div>
                        <!-- Fortnite -->
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorial/Fortnitepage">
                                <img src="/Assets/GameArtwork/Fortnite.jpg" class="img-fluid" alt="Fortnite" />
                            </a>
                            <h5>Fortnite</h5>
                        </div>
                        <!-- Valorant -->
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorial/Valorantpage">
                                <img src="/Assets/GameArtwork/Valorant.jpg" class="img-fluid" alt="Valorant" />
                            </a>
                            <h5>Valorant</h5>
                        </div>
                        

                    </div>
                </div>
            </section>

            <!-- Featured-Game Section -->
            <aside class="col-md-4">
                <div class="bg-custom text-white p-4 d-flex flex-column align-items-center justify-content-center text-center">
                    <h4>Featured game</h4>
                    <ul class="list-unstyled">
                        <li>
                            <a id="featuredGameLink" runat="server" class="text-white">
                                <img src="featuredGameImage" id="featuredGameImage" runat="server" style="max-width: 100%; height: auto;" />
                                <span id="featuredGameTitle" runat="server"></span>
                            </a>
                        </li>
                    </ul>
                </div>
            </aside>
            
        </div>
    </main>

    <!-- Styles -->
    <style>
        .bg-custom {
            background-color: #5a2b91;
        }

        /* Flexbox to center content */
        .d-flex {
            display: flex;
        }

        .flex-column {
            flex-direction: column;
        }

        .align-items-center {
            align-items: center;
        }

        .justify-content-center {
            justify-content: center;
        }

        .text-center {
            text-align: center;
        }
    </style>
</asp:Content>
