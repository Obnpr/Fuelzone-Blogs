<%@ Page Title="Discussions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussionmainpage.aspx.cs" Inherits="Fuelzone.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4" aria-labelledby="title">
        <!-- Title Section -->
        <section class="row">
            <div class="col-12">
                <h2>Game list</h2>
            </div>
        </section>

        <div class="row mt-4">
            <!-- Game Icons/Categories -->
            <section class="col-md-8">
                <div class="p-4">
                    <div class="row">
                        <!-- Example Game Icons -->
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/tutorials/CODBlackOps6page">
                                <img src="/Assets/GameArtwork/CODBlackOps6.jpg" class="img-fluid" alt="Call of Duty: Black Ops 6" />
                            </a>
                            <h5>Call of Duty: Black Ops 6</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/discussion/Fortnitepage">
                                <img src="/Assets/GameArtwork/Fortnite.jpg" class="img-fluid" alt="Fortnite" />
                            </a>
                            <h5>Fortnite</h5>
                        </div>
                        <div class="col-sm-4 mb-3 text-center">
                            <a href="/pages/discussion/Valorantpage">
                                <img src="/Assets/GameArtwork/Valorant.jpg" class="img-fluid" alt="Valorant" />
                            </a>
                            <h5>Valorant</h5>
                        </div>
                        <!-- Add more games here -->
                    </div>
                </div>
            </section>
            <section>
            <!-- Featured Game Tut. -->
                <!-- Community Chatting Guidelines Section -->
                <div class="bg-light text-dark p-4 mt-4">
                    <h2>Community Chatting Guidelines</h2>
                    <p>To keep our community safe and friendly, at Fuelzone we encourage all members to adhere to the following guidelines:</p>
                    <hr>
                    <p><strong>Respect Others:</strong></p>
                    <p>Please be respectful when participating in discussions. This means treating every member with dignity, regardless of differing opinions. Personal attacks, insults, or attempts to discredit and antagonize others will not be tolerated. Avoid shaming others based on their profile, preferences, or contributions. If another member's behavior is causing problems, report it to the moderators instead of retaliating. A respectful environment ensures everyone can share their views comfortably.</p>

                    <p><strong>No Spamming:</strong></p>
                    <p>Keep your contributions meaningful. Refrain from making repetitive posts or promoting products and services unrelated to the discussions. Spamming creates a poor experience for others and disrupts the conversation flow. Please contribute thoughtfully and avoid excessive use of emojis or large fonts, which can be visually distracting and make discussions harder to follow.</p>

                    <p><strong>Stay On-Topic:</strong></p>
                    <p>Ensure that your contributions remain relevant to the ongoing discussion. Each topic has a specific purpose, and keeping the conversation focused helps everyone better understand and participate. If you have a different topic in mind, please find or create the appropriate discussion space. Staying on-topic makes conversations more valuable for everyone involved.</p>

                    <p><strong>Use Appropriate Language:</strong></p>
                    <p>Maintain a respectful and family-friendly tone in all your posts. Avoid using offensive language, vulgar expressions, or terms that could be considered derogatory towards others. Remember that we have a diverse audience, including individuals of different ages, backgrounds, and cultures. Keeping language appropriate helps maintain a welcoming environment for everyone. Remember this is a English only page, we will expand it to various language throught time.</p>

                    <p><strong>Be Helpful:</strong></p>
                    <p>If you have knowledge that can help others, please share it. Answering questions, providing useful information, or even just offering encouragement can go a long way toward fostering a supportive community. This discussion board thrives on members helping each other, so be proactive in assisting others whenever you can. Let's work together to create a welcoming and informative space.</p>

                    <p><strong>Report Issues:</strong></p>
                    <p>If you come across posts or behaviors that violate these guidelines, please report them to the moderators. You can use our reporting tools or contact us via our public email. Reporting helps us maintain a healthy environment where everyone feels comfortable participating. Remember, if you see something wrong, don't engage—report it, and let the moderators handle it. You can contact the moderators using the email in the About us section of the webpage.</p>

                </div>
            </section>

        </div>
    </main>
</asp:Content>
