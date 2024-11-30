<%@ Page Title="Valorant Tutorials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Valorantpage.aspx.cs" Inherits="Fuelzone.Contact" %>

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
                </div>
            </div>
        </section>

        <!-- Comment List Section -->
        <section class="row mt-4">
            <div class="col-12">
                <h4>Comments</h4>
                <div id="commentsSection">
                    <!-- Example Template for Comments -->
                    <asp:Repeater ID="CommentsRepeater" runat="server">
                        <ItemTemplate>
                            <div class="card mb-3">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Username") %></h5>
                                    <p class="card-text"><%# Eval("CommentText") %></p>
                                    <div class="d-flex justify-content-between align-items-center">
                                        <small class="text-muted"><%# Eval("Timestamp") %></small>
                                        <button class="btn btn-outline-primary btn-sm" onclick="likeComment('<%# Eval("CommentId") %>')">
                                            👍 Like (<span id="likeCount_<%# Eval("CommentId") %>"><%# Eval("LikeCount") %></span>)
                                        </button>
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
