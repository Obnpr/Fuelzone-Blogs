<%@ Page Title="About Us - Fuelzone" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aboutus.aspx.cs" Inherits="Fuelzone.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>About Us</h2>
            </div>
        </section>

        <section class="row mt-4">
            <div class="col-md-8">
                <p>We are a small, passionate team of developers dedicated to enhancing the gaming community's experience. Our mission is to create a space where gamers can easily access tutorials, walkthroughs, and participate in lively discussions. Whether you're looking for tips to level up in your favorite game or want to share your own insights, our platform is built with you in mind.</p>
                <p>We aim to foster an environment that encourages collaboration and helps everyone enjoy gaming to its fullest.</p>
            </div>
            <aside class="col-md-4">
                <div class="bg-custom text-white p-4">
                    <h4>Join the Community</h4>
                    <p>Connect with fellow gamers on our discussion boards and become a part of our growing network.</p>
                </div>
            </aside>
        </section>
    </main>

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
