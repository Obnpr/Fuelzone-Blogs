<%@ Page Title="Call of Duty: Black Ops 6 Discussion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="CODBlackOps6page.aspx.cs" Inherits="Fuelzone.CODBlackOps6page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">

        <!-- Title -->
        <section class="row">
            <div class="col-12">
                <h2>Call of Duty: Black Ops 6 - Discussion Board</h2>
            </div>
        </section>

        <!-- Comment Section -->
        <section class="row mt-4">
            <div class="col-12">
                <hr>
                
                <!-- Comment Form -->
                <div id="commentForm">
                    <% if (Session["UserId"] != null) { %>
                        <!-- Logged-in User Label -->
                        <asp:Label ID="lblLoggedInAs" runat="server">Logged in as: <strong><%= Session["Username"] != null ? Session["Username"].ToString() : "Guest" %></strong></asp:Label>
                    <% } else { %>
                        <!-- Guest User Label -->
                        <asp:Label ID="Label1" runat="server">Logged in as: <strong>Guest</strong></asp:Label>
                    <% } %>

                    <!-- Empty Label for Potential Message Display -->
                    <div class="form-group mb-2">
                        <asp:Label ID="Label2" runat="server" CssClass="fw-bold"></asp:Label>
                    </div>

                    <% if (Session["UserId"] != null) { %>
                        <!-- Comment Input Form for Logged-in Users -->
                        <div class="form-group">
                            <label for="commentInput">Leave a comment:</label>
                            <asp:TextBox ID="commentInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Share your thoughts..." style="resize: none;"></asp:TextBox>
                        </div>
                        <!-- Submit Comment Button for Logged-in Users -->
                        <asp:Button ID="SubmitCommentButton" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" OnClick="SubmitCommentButton_Click" />
                    <% } else { %>
                        <!-- Disabled Comment Button for Guests -->
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" Enabled="false" Style="cursor: not-allowed; opacity: 0.5;" />
                    <% } %>
                    <!-- Message Label for Success/Error Messaging -->
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
                                    
                                    <!-- Profile Image and Admin/User Status -->
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
                                            <!-- Like Button -->
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
