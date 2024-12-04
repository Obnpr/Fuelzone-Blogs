<%@ Page Title="Valorant Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Valorantpage.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        
        <!-- Title  -->
        <section class="row">
            <div class="col-12">
                <h2>Valorant Tutorials</h2>
            </div>
        </section>

        <!-- Tutorials Listings -->
        <div class="row mt-4">
            <div class="col-12">
                <div class="row">
                    
                    <!-- Basic Tips and Tricks Tutorial -->
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body">
                                <h3 class="card-title">Basic Tips and Tricks</h3>
                                <p class="card-text">
                                    Get essential tips for improving your Valorant gameplay, covering aiming techniques, map awareness, and agent abilities.
                                </p>
                                <img src="/Assets/Tutorial/Valorant/Basictipsandtricks/preview.jpg" alt="Basic Tips and Tricks" class="img-fluid mb-3" />
                                <p class="card-text text-muted"><small>⏰ 13 minutes</small></p>
                                <a href="/pages/tutorial/valorant/basictipsandtricks" class="btn btn-primary">Read Tutorial</a>
                            </div>
                        </div>
                    </div>

                    <!-- How to Touch Grass Tutorial -->
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body">
                                <h3 class="card-title">How to Touch Grass</h3>
                                <p class="card-text">
                                    Learn all about touching grass, its benefits, different situations where you might need to touch some grass, and more.
                                </p>
                                <img src="/Assets/Tutorial/Valorant/Howtotouchgrass/preview.jpg" alt="Hand touching grass image" class="img-fluid mb-3" />
                                <p class="card-text text-muted"><small>⏰ 8 minutes</small></p>
                                <a href="/pages/tutorial/valorant/howtotouchgrass" class="btn btn-primary">Read Tutorial</a>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </main>
</asp:Content>
