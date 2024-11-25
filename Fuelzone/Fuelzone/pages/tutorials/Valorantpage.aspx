<%@ Page Title="Valorant Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorials.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>Valorant Tutorials</h2>
            </div>
        </section>

        <!-- Tutorial List Section -->
        <div class="row mt-4">
            <!-- Replace Images with Tutorial Cards -->
            <div class="col-12">
                <div class="row">
                    <!-- Tutorial Example 1 -->
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body">
                                <h3 class="card-title">Basic Tips and Tricks</h3>
                                <p class="card-text">
                                    Learn the essential tips to improve your Valorant gameplay, including aiming techniques, map awareness, and agent abilities.
                                </p>
                                <p class="card-text text-muted"><small>⏰ 5 minutes</small></p>
                                <a href="/Webpages/ValorantTips" class="btn btn-primary">Read Tutorial</a>
                            </div>
                        </div>
                    </div>

                    <!-- Tutorial Example 2 -->
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body">
                                <h3 class="card-title">Advanced Strategies</h3>
                                <p class="card-text">
                                    Take your Valorant skills to the next level with advanced team coordination, map control tactics, and proper agent utility use.
                                </p>
                                <p class="card-text text-muted"><small>⏰ 10 minutes</small></p>
                                <a href="/Webpages/ValorantAdvanced" class="btn btn-primary">Read Tutorial</a>
                            </div>
                        </div>
                    </div>

                    <!-- Tutorial Example 3 -->
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body">
                                <h3 class="card-title">How to touch grass</h3>
                                <p class="card-text">
                                    Learn all about touching grass, it's benefits, diferent situations where you might need to touch some grass, and more.
                                </p>
                                <p class="card-text text-muted"><small>⏰ 8 minutes</small></p>
                                <a href="/pages/tutorials/valorant/Howtotouchgrass" class="btn btn-primary">Read Tutorial</a>
                            </div>
                        </div>
                    </div>

                    <!-- Add more tutorials as needed -->
                </div>
            </div>
        </div>
    </main>
</asp:Content>
