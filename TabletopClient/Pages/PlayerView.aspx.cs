using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TabletopClient.Controllers;

namespace TabletopClient.Pages
{
    public partial class PlayerView : Page
    {
        //This is a list of all our PC divs.
        public List<HtmlGenericControl> divList = new List<HtmlGenericControl>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Populate our lists.
            divList.Add(pcDiv0);
            divList.Add(pcDiv1);
            divList.Add(pcDiv2);
            divList.Add(pcDiv3);
            divList.Add(pcDiv4);
            divList.Add(pcDiv5);

            //Update the party UI if there is already a party.
            UpdatePartyUI();
        }

        protected void LoadPC_Click(object sender, EventArgs e)
        {
            string name = PCLoadList.SelectedValue;
            PartyController.AddPartyMember(name);
            UpdatePartyUI();
        }
        
        protected void RemovePartyMember(object sender, EventArgs e)
        {
            string name = PCLoadList.SelectedValue;
            PartyController.RemovePartyMember(name);
            UpdatePartyUI();
        }


        //Update the party UI.
        public void UpdatePartyUI()
        {
            for (int i = 0; i < divList.Count(); i++)
            {
                try
                {
                    divList[i].InnerHtml = HTMLModuleController.GetPCUI(PartyController.GetParty()[i]);
                }
                catch
                {
                    divList[i].InnerHtml = "<p>Empty Slot</p>";
                }
            }
        }
    }
}