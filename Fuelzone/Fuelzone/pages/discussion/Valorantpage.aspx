<%@ Page Title="Valorant Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Valorantpage.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>Valorant Discussion Board</h2>
            </div>
        </section>

        <!-- Comment Section -->
        <section class="row mt-4">
            <div class="col-12">
                <h3>Discussion Forum</h3>
                <!-- Comment Form -->
                <div id="commentForm">
                    <div class="form-group">
                        <label for="commentInput">Leave a comment:</label>
                        <asp:TextBox ID="commentInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Share your thoughts..."></asp:TextBox>
                    </div>
                    <asp:Button ID="SubmitCommentButton" runat="server" CssClass="btn btn-primary mt-2" Text="Post Comment" OnClick="SubmitCommentButton_Click" />
                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2"></asp:Label> <!-- Added to display messages -->
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
                        <div class="d-flex align-items-start mb-3" style="background-color: #f9f9f9; border-radius: 8px; padding: 15px;">
                            <!-- Profile Image -->
                            <img src='<%# ResolveUrl(((bool)Eval("IsAdmin")) ? "~/Assets/user/admin_user_image.png" : "~/Assets/user/default_user_image.png") %>' 
                                 alt="Profile IMG" class="rounded-circle" style="width: 64px; height: 64px;">

                            <!-- Comment Content -->
                            <div class="flex-grow-1">
                                <div class="d-flex justify-content-between align-items-center">
                                    <!-- Username and timestamp -->
                                    <div>
                                        <strong class="text-primary"><%# Eval("Username") %></strong> <br />
                                        <small class="text-muted"><%# Eval("Timestamp") %></small>
                                    </div>
                                    <!-- Like button -->
                                    <asp:Button ID="LikeButton" runat="server" CssClass="btn btn-outline-primary btn-sm" 
                                                Text='<%# "👍 Like (" + Eval("LikeCount") + ")" %>' 
                                                CommandArgument='<%# Eval("CommentId") %>' 
                                                OnClick="LikeButton_Click" />
                                </div>
                                <!-- Comment Text -->
                                <p class="mt-2 mb-0"><%# Eval("CommentText") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                </div>
            </div>
        </section>
    </main>
</asp:Content>
