using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TabletopClient.Controllers;

namespace TabletopClient.Pages
{
    public partial class CharacterStatusView : System.Web.UI.Page
    {
        //This is a reference to the character we are viewing.
        public static CharaController myChar;
        public static int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (myChar == null) myChar = new CharaController(0);
            UpdateUI();
        }

        //Reset Stats.
        public void ResetStats(object sender, EventArgs e)
        {
            myChar.ResetStatPlacement();
        }

        //Update UI
        public void UpdateUI()
        {
            levelBlockLabel.InnerText = string.Format("Level: {0} (Needs to load class ID properly)", myChar.GetClassLevel(0));
            statPointsLabel.InnerText = string.Format("Stat Points: {0}", myChar.GetStatPoints());
            strBlockLabel.InnerText = string.Format("Strength: {0} ({1})", myChar.GetBaseStrength(), myChar.GetDerivedStrength());
            vitBlockLabel.InnerText = string.Format("Vitality: {0} ({1})", myChar.GetBaseVitality(), myChar.GetDerivedVitality());
            intBlockLabel.InnerText = string.Format("Intelligence: {0} ({1})", myChar.GetBaseIntelligence(), myChar.GetDerivedIntelligence());
            imaBlockLabel.InnerText = string.Format("Imagination: {0} ({1})", myChar.GetBaseImagination(), myChar.GetDerivedImagination());
            dexBlockLabel.InnerText = string.Format("Dexterity: {0} ({1})", myChar.GetBaseDexterity(), myChar.GetDerivedDexterity());
            agiBlockLabel.InnerText = string.Format("Agility: {0} ({1})", myChar.GetBaseAgility(), myChar.GetDerivedAgility());
            lukBlockLabel.InnerText = string.Format("Luck: {0} ({1})", myChar.GetBaseLuck(), myChar.GetDerivedLuck());
        }
        public void TimerTick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        //Add to stats.
        public void AddStrength(object sender, EventArgs e) { myChar.AddStatPoint("str", 1); UpdateUI(); }
        public void AddVitality(object sender, EventArgs e) { myChar.AddStatPoint("vit", 1); UpdateUI(); }
        public void AddIntelligence(object sender, EventArgs e) { myChar.AddStatPoint("int", 1); UpdateUI(); }
        public void AddImagination(object sender, EventArgs e) { myChar.AddStatPoint("ima", 1); UpdateUI(); }
        public void AddDexterity(object sender, EventArgs e) { myChar.AddStatPoint("dex", 1); UpdateUI(); }
        public void AddAgility(object sender, EventArgs e) { myChar.AddStatPoint("agi", 1); UpdateUI(); }
    }
}