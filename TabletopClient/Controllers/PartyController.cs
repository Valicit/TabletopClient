using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletopClient.Controllers
{
    public static class PartyController
    {
        //This is a list that holds the current player party.
        private static List<CharaController> party = new List<CharaController>();

        //Get the party.
        public static List<CharaController> GetParty()
        {
            return party;
        }

        //Add a character to the party.
        public static void AddPartyMember(CharaController pc)
        {
            party.Add(pc);
        }
        public static void AddPartyMember(int id)
        {
            party.Add(new CharaController(id));
        }
        public static void AddPartyMember(string name)
        {
            party.Add(new CharaController(name));
        }

        //Remove a character from the party.
        public static void RemovePartyMember(string name)
        {
            party.Remove(party.Find(n => n.GetName() == name));
        }
    }
}