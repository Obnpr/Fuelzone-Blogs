<%@ Page Title="Fortnite Discussion Board" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="FortnitePage.aspx.cs" Inherits="Fuelzone.FortnitePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">

        <!-- Title -->
        <section class="row">
            <div class="col-12">
                <h2>Fortnite - Discussion Board</h2>
            </div>
        </section>

        <!-- Comment Section -->
        <section class="row mt-4">
            <div class="col-12">
                <hr>
                <!-- Comment Box -->
                <div id="commentForm">

                    <!-- Display User Login Status -->
                    <% if (Session["UserId"] != null) { %>
                        <asp:Label ID="lblLoggedInAs" runat="server">Logged in as: <strong><%= Session["Username"] != null ? Session["Username"].ToString() : "Guest" %></strong></asp:Label>
                    <% } else { %>
                        <asp:Label ID="Label1" runat="server">Logged in as: <strong>Guest</strong></asp:Label>
                    <% } %>

                    <!-- Placeholder for User Interaction -->
                    <div class="form-group mb-2">
                        <asp:Label ID="Label2" runat="server" CssClass="fw-bold"></asp:Label>
                    </div>

                    <!-- Comment Input Field for Logged-in Users -->
                    <% if (Session["UserId"] != null) { %>
                        <div class="form-group">
                            <label for="commentInput">Leave a comment:</label>
                            <asp:TextBox ID="commentInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Share your thoughts..." style="resize: none;"></asp:TextBox>
                        </div>
                        <asp:Button ID="SubmitCommentButton" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" OnClick="SubmitCommentButton_Click" />
                    <% } else { %>
                        <!-- Button Disabled for Guests -->
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" Enabled="false" Style="cursor: not-allowed; opacity: 0.5;" />
                    <% } %>

                    <!-- Display Message to User -->
                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2"></asp:Label>
                </div>
            </div>
        </section>

        <!-- Comment List Section -->
        <section class="row mt-4">
            <div class="col-12">
                <h4>Comments</h4>
                <div id="commentsSection">
                    
                    <asp:Repeater ID="CommentsRepeater" runat="server">
                        <ItemTemplate>
                            <!-- Card for Each Comment -->
                            <div class="card mb-3 comment-card">
                                <div class="card-body d-flex">

                                    <!-- Profile Image and Admin/User Accounts -->
                                    <div class="d-flex flex-column align-items-center me-3" style="text-align: center;">
                                        <img src='<%# ResolveUrl(((bool)Eval("IsAdmin")) ? "~/Assets/user/admin_user_image.png" : "~/Assets/user/default_user_image.png") %>' 
                                             alt="Profile IMG" class="rounded-circle" style="width: 64px; height: 64px;">
                                        <small class="mt-2"><%# (bool)Eval("IsAdmin") ? "Admin" : "User" %></small>
                                    </div>

                                    <!-- Comment Content -->
                                    <div class="flex-grow-1">
                                        <!-- Username and Timestamp -->
                                        <div class="d-flex justify-content-between">
                                            <div>
                                                <strong class="text-primary"><%# Eval("Username") %></strong><br />
                                                <small class="text-muted"><%# Eval("Timestamp") %></small>
                                            </div>

                                            <!-- Like Button Aligned to the Right -->
                                            <asp:Button ID="LikeButton" runat="server" CssClass="btn btn-outline-primary btn-sm ms-auto" 
                                                        Text='<%# "👍 Like (" + Eval("LikeCount") + ")" %>' 
                                                        CommandArgument='<%# Eval("CommentId") %>' 
                                                        OnClick="LikeButton_Click" />
                                        </div>
                                        
                                        <!-- Comment Text -->
                                        <p class="mt-2 mb-0 comment-text"><%# Eval("CommentText") %></p>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </section>
    </main>
</asp:Content>
