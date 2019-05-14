using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletopClient.Controllers
{
    public static class HTMLModuleController
    {
        //Get a PCUI module.
        public static string GetPCUI(CharaController r)
        {
            string path = HttpContext.Current.Server.MapPath("~/Embeds/PCUI.html");
            return String.Format(System.IO.File.ReadAllText(path), r.GetName(), r.GetCurrentHP(), "todo", "todo", "todo", "todo", "todo", "todo", "todo", r.GetBaseStrength(), r.GetBaseVitality(), r.GetBaseIntelligence(), r.GetBaseImagination(), r.GetBaseDexterity(), r.GetBaseAgility());
        }
    }
}