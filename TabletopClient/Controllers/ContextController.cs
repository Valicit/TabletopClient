using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletopClient.Controllers
{
    public static class ContextController
    {
        //This is a reference to our context for this session.
        public static TabletopEntities ourContext = new TabletopEntities();

        //Update the context.
        public static void SaveContext()
        {
            ourContext.SaveChanges();
        }
    }
}