<%@ Page Title="Fortnite Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fortnitepage.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>Fortnite Tutorials</h2>
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
                            <div class="card-body d-flex flex-column">
                                <h3 class="card-title">How to Improve Your Building Skills</h3>
                                <p class="card-text">
                                    This guide teaches you the essential building techniques in Fortnite to enhance your defense, mobility, and overall gameplay strategy.
                                </p>
                                <p class="card-text text-muted"><small>⏰ 5 minutes</small></p>
                                <div class="mt-auto text-left">
                                    <a href="/pages/tutorial/Fortnite/BasicBuildingTechniques" class="btn btn-primary">Read Tutorial</a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Tutorial Example 2 -->
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body d-flex flex-column">
                                <h3 class="card-title">How to Improve Your Aim</h3>
                                <p class="card-text">
                                    Learn how to improve your aiming skills in Fortnite, enhancing accuracy and reaction times for better performance in combat.
                                </p>
                                <p class="card-text text-muted"><small>⏰ 4 minutes</small></p>
                                <div class="mt-auto text-left">
                                    <a href="/pages/tutorial/Fortnite/FortniteAimImprovement" class="btn btn-primary">Read Tutorial</a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Add more tutorials as needed -->
                </div>
            </div>
        </div>
    </main>
</asp:Content>
