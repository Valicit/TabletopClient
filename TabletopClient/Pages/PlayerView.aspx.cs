using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TabletopClient.Pages
{
    public partial class PlayerView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pcDiv.InnerHtml = GetPCDiv();
            allyDivOne.InnerHtml = GetPCDiv();
        }

        //Return a div containing a view of a player character.
        public string GetPCDiv()
        {
            Character r = new TabletopEntities().Characters.FirstOrDefault();
            string path = HttpContext.Current.Server.MapPath("~/Embeds/PCUI.html");
            return String.Format(System.IO.File.ReadAllText(path), r.name, r.current_hp, "todo", "todo", "todo", "todo", "todo", "todo", "todo", r.strength, r.vitality, r.intelligence, r.imagination, r.dexterity, r.agility);
        }
    }
}