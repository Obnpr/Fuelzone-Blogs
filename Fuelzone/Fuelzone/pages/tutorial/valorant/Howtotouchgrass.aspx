<%@ Page Title="Valorant Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorials.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        
        <!-- Section 1: Title, Game, Author, and Additional Information -->
        <section class="row mb-4">
            <div class="col-12">
                <div class="bg-secondary text-white p-4">
                    <h2>How to Touch Grass</h2>
                    <p><strong>Game:</strong> Valorant</p>
                    <p><strong>Author:</strong> Obed Negron</p>
                    <p>
                        This guide will help you explore the benefits of "touching grass", different situations where you might need to touch grass, and how this can benefit your overall well-being while gaming.
                    </p>
                </div>
            </div>
        </section>

        <!-- Section 2: Guide Content -->
        <section class="row mb-4">
            <div class="col-12">
                <div class="bg-light p-4">
                    <h3>Guide Content</h3>
                    <p>
                        Welcome to the "Touching Grass" guide! Sometimes, we all need a little reminder to step away from the screen and get some fresh air.
                        In this guide, you'll learn:
                    </p>
                    <ul>
                        <li>Why stepping outside and touching grass is beneficial.</li>
                        <li>How to integrate short breaks into your gaming routine.</li>
                        <li>Specific exercises and stretches to complement this activity.</li>
                    </ul>
                    <p>Whether you're struggling with a difficult ranked game or just need a mental reset, these tips will help you refresh and return to the game stronger.</p>
                </div>
            </div>
        </section>

        <!-- Section 3: Comments -->
        <section class="row">
            <div class="col-12">
                <div class="bg-secondary text-white p-4">
                    <h3>Comments</h3>
                    <div class="mb-3">
                        <label for="userComment" class="form-label">Leave a Comment</label>
                        <textarea class="form-control" id="userComment" rows="4"></textarea>
                    </div>
                    <button type="submit" class="btn btn-primary">Submit Comment</button>
                    
                    <!-- Example Comments -->
                    <div class="mt-4">
                        <p><strong>Roberto_Gamer264:</strong> Thanks, this really helped me take much-needed breaks between games!</p>
                        <p><strong>Tadidity2024:</strong> Great advice! Never knew the power of touching grass until now!</p>
                    </div>
                </div>
            </div>
        </section>

    </main>
</asp:Content>
