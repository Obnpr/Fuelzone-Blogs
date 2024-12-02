<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sign_in.aspx.cs" Inherits="Fuelzone.pages.user_registration.signin.Sign_in" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <div class="row justify-content-center">
            <h2 class="text-center sign-up-heading">Sign In</h2>

            <!-- Email Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Email Address" CssClass="form-label" ClientIDMode="Static"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Password Input -->
            <div class="form-group mb-3">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label" ClientIDMode="Static"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Sign-In Button -->
            <div class="form-group mb-3 text-center">
                <asp:Button ID="btnSignin" runat="server" Text="Sign In" OnClick="btnSignin_Click" CssClass="btn btn-primary btn-block btn-signup"></asp:Button>
            </div>

            <!-- Message Label -->
            <div class="form-group text-center">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </main>

    <style>
        .dark-mode-label {
            color: #ffffff;
        }

        .light-mode-label {
            color: #000000;
        }
        /* Light Mode Styles (Default) */
        body {
            /* Background color for better readability */
        }

        .sign-up-heading {
            color: #333333; /* Darker shade of black for better contrast */
        }

        .form-label {
            color: #000000; /* Dark text for form labels */
        }

        .form-control {
            /* Light background for input fields */
            color: #000000; /* Dark text for input fields */
            border: 1px solid #ced4da; /* Standard border for input fields in light mode */
        }

        .btn-primary {
            color: #ffffff; /* White text for better contrast */
        }

        /* Dark Mode Styles */
        body.dark-mode {
            /* Darker background for better contrast */
            color: #f1f1f1; /* Light text for better readability */
        }

        body.dark-mode .sign-up-heading {
            color: #f1f1f1; /* Light heading text for better visibility in dark mode */
        }

        body.dark-mode .form-label {
            color: #ffffff; /* White color for form labels in dark mode */
        }

        body.dark-mode .form-control {
            /* Darker background for input fields */
            color: #f1f1f1; /* Light text for input fields */
            border: 1px solid #555555; /* Slightly lighter border for input fields */
        }

        body.dark-mode .btn-primary {
            /* Dark green button background suitable for dark mode */
            /* Border color for dark mode button */
            color: #f1f1f1; /* Light text on the button for readability */
        }

        body.dark-mode .text-danger {
            color: #ff4d4d; /* Bright red for error messages in dark mode */
        }
    </style>

    <script>
        // JavaScript to toggle dark mode by adding/removing the 'dark-mode' class from the body element
        document.addEventListener("DOMContentLoaded", function () {
            const body = document.body;
            if (localStorage.getItem("theme") === "dark") {
                body.classList.add("dark-mode");
            }

            const toggleDarkMode = document.querySelector('.dark-mode-toggle');
            if (toggleDarkMode) {
                toggleDarkMode.addEventListener('click', () => {
                    document.body.classList.toggle('dark-mode');
                    localStorage.setItem("theme", document.body.classList.contains('dark-mode') ? 'dark' : 'light');
                });
            }
        });
    </script>
</asp:Content>
