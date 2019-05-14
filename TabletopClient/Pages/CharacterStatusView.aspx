<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharacterStatusView.aspx.cs" Inherits="TabletopClient.Pages.CharacterStatusView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate runat="server">
                    <div id="stat-block-div">
                        <div id="level-block">
                            <label id="levelBlockLabel" runat="server">Level: (level)</label>
                        </div>
                        <label id="statPointsLabel" runat="server">Stat Points: 0</label>
                        <div id="stat-block-str">
                            <label id="strBlockLabel" runat="server">Strength: Base (derived)</label>
                            <asp:Button ID="addStrButton" runat="server" Text="+" OnClick="AddStrength" />
                        </div>
                        <div id="stat-block-vit">
                            <label id="vitBlockLabel" runat="server">Vitality: Base (derived)</label>
                            <asp:Button ID="addVitButton" runat="server" OnClick="AddVitality" Text="+" />
                        </div>
                        <div id="stat-block-int">
                            <label id="intBlockLabel" runat="server">Intelligence: Base (derived)</label>
                            <asp:Button ID="addIntButton" runat="server" OnClick="AddIntelligence" Text="+" />
                        </div>
                        <div id="stat-block-ima">
                            <label id="imaBlockLabel" runat="server">Imagination: Base (derived)</label>
                            <asp:Button ID="addImaButton" runat="server" OnClick="AddImagination" Text="+" />
                        </div>
                        <div id="stat-block-dex">
                            <label id="dexBlockLabel" runat="server">Dexterity: Base (derived)</label>
                            <asp:Button ID="addDexButton" runat="server" OnClick="AddDexterity" Text="+" />
                        </div>
                        <div id="stat-block-agi">
                            <label id="agiBlockLabel" runat="server">Agility: Base (derived)</label>
                            <asp:Button ID="addAgiButton" runat="server" OnClick="AddAgility" Text="+" />
                        </div>
                        <div id="stat-block-luk">
                            <label id="lukBlockLabel" runat="server">Luck: Base (derived)</label>
                        </div>
                        <asp:Timer ID="UpdateTimer" runat="server" Interval="1000" OnTick="TimerTick">
                        </asp:Timer>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
