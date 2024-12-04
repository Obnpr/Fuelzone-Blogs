<%@ Page Title="Valorant Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Valorantpage.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">

        <!-- Title -->
        <section class="row">
            <div class="col-12">
                <h2>Valorant - Discussion Board</h2>
            </div>
        </section>

        <!-- Comment Section -->
        <section class="row mt-4">
            <div class="col-12">
                <hr>

                <!-- Comment Form -->
                <div id="commentForm">
                    <% if (Session["UserId"] != null) { %>
                        <!-- Display Logged-in User Info -->
                        <asp:Label ID="lblLoggedInAs" runat="server">
                            Logged in as: <strong><%= Session["Username"] != null ? Session["Username"].ToString() : "Guest" %></strong>
                        </asp:Label>
                    <% } else { %>
                        <!-- Display Guest Info for Non-logged Users -->
                        <asp:Label ID="Label1" runat="server">
                            Logged in as: <strong>Guest</strong>
                        </asp:Label>
                    <% } %>

                    <div class="form-group mb-2">
                        <!-- Label for the Comment Form -->
                        <asp:Label ID="Label2" runat="server" CssClass="fw-bold"></asp:Label>
                    </div>

                    <% if (Session["UserId"] != null) { %>
                        <!-- Comment Input Box for Logged-in Users -->
                        <div class="form-group">
                            <label for="commentInput">Leave a comment:</label>
                            <asp:TextBox ID="commentInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Share your thoughts..." style="resize: none;"></asp:TextBox>
                        </div>
                        <!-- Post Comment Button for Logged-in Users -->
                        <asp:Button ID="SubmitCommentButton" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" OnClick="SubmitCommentButton_Click" />
                    <% } else { %>
                        <!-- Disabled Post Comment Button for Guests -->
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" Enabled="false" Style="cursor: not-allowed; opacity: 0.5;" />
                    <% } %>

                    <!-- Message Label for any errors -->
                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2"></asp:Label>
                </div>
            </div>
        </section>

        <!-- Comment List Section -->
        <section class="row mt-4">
            <div class="col-12">
                <h4>Comments</h4>

                <!-- Comment List Container -->
                <div id="commentsSection">
                    <asp:Repeater ID="CommentsRepeater" runat="server">
                        <ItemTemplate>
                            <!-- Card for Each Comment -->
                            <div class="card mb-3 comment-card">
                                <div class="card-body d-flex">

                                    <!-- Profile Image and Admin/User Name -->
                                    <div class="d-flex flex-column align-items-center me-3" style="text-align: center;">
                                        <img src='<%# ResolveUrl(((bool)Eval("IsAdmin")) ? "~/Assets/user/admin_user_image.png" : "~/Assets/user/default_user_image.png") %>' 
                                             alt="Profile IMG" class="rounded-circle" style="width: 64px; height: 64px;">
                                        <small class="mt-2"><%# (bool)Eval("IsAdmin") ? "Admin" : "User" %></small>
                                    </div>

                                    <!-- Comment Content Section -->
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
