using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace TabletopClient.Controllers
{
    public class CharaController
    {
        //References
        private Character chara;
        private List<ClassController> myClasses;
        public string[] tableNames = new string[] { "HP", "STR" };

        //Constructor takes a character ID or name for finding the proper one and holding a reference.
        public CharaController(int cid)
        {
            chara = ContextController.ourContext.Characters.FirstOrDefault(n => n.id == cid);
            myClasses = ClassController.GetClasses(this);
        }
        public CharaController(string name)
        {
            chara = ContextController.ourContext.Characters.FirstOrDefault(n => n.name == name);
            myClasses = ClassController.GetClasses(this);
        }

        //Reset the characters stat placements.
        public void ResetStatPlacement()
        {
            chara.strength = 0;
            chara.vitality = 0;
            chara.intelligence = 0;
            chara.imagination = 0;
            chara.dexterity = 0;
            chara.agility = 0;
            ContextController.SaveContext();
        }

        //Add to base stat values.
        public void AddStatPoint(string stat, int i)
        {
            switch (stat)
            {
                case "str":
                    chara.strength += i;
                    break;
                case "vit":
                    chara.vitality += i;
                    break;
                case "int":
                    chara.intelligence += i;
                    break;
                case "ima":
                    chara.imagination += i;
                    break;
                case "dex":
                    chara.dexterity += i;
                    break;
                case "agi":
                    chara.agility += i;
                    break;
                case "luk":
                    chara.luck += i;
                    break;
            }
            ContextController.SaveContext();
        }

        //Acting Methods
        public void TakeDamage(int d)
        {
            chara.current_hp -= d;
            if (chara.current_hp < 0) chara.current_hp = 0;
            ContextController.SaveContext();
        }

        //Get stat methods.

        //Get Misc values.
        public string GetName() { return chara.name; }
        public int GetStatPoints() { return 100 - (GetBaseStrength() + GetBaseVitality() + GetBaseIntelligence() + GetBaseImagination() + GetBaseDexterity() + GetBaseAgility()); }
        public int GetClassLevel(int id)
        {
            return myClasses[id].GetClassLevel();
        }
        public int GetClassExp(int id)
        {
            return Convert.ToInt32(GetClassExp(chara.class_exp)[id]);
        }
        public string[] GetClassExp(string cs)
        {
            string[] r = new string[0];
            try
            {
                r = cs.Split(',');
            }
            catch { }
            return r;
        }
        public string[] GetSkillRanks(int classId)
        {
            string[] classSkillRanks = chara.skill_ranks.Split('|');
            try
            {
                string r = classSkillRanks[classId];
                return r.Split(',');
            }
            catch { return new string[0]; }
        }

        //Get Current Values.
        public int GetCurrentHP() { return (int)chara.current_hp; }
        public int GetCurrentMP() { return (int)chara.current_mp; }
        public int GetCurrentAP() { return (int)chara.current_ap; }
        public int GetClassResource() { return (int)chara.class_resource; }
        public int GetSubclassResource() { return (int)chara.subclass_resource; }

        //Get Base Stats
        public int GetBaseStrength(){ return (int)chara.strength; }
        public int GetBaseVitality() { return (int)chara.vitality; }
        public int GetBaseIntelligence() { return (int)chara.intelligence; }
        public int GetBaseImagination() { return (int)chara.imagination; }
        public int GetBaseDexterity() { return (int)chara.dexterity; }
        public int GetBaseAgility() { return (int)chara.agility; }
        public int GetBaseLuck() { return (int)chara.luck; }

        //Get Derived Stats
        public int GetDerivedStrength() { return (int)((chara.strength * (myClasses[chara.current_class_id].GetClassLevel() - 1) * myClasses[chara.current_class_id].GetStrengthMod()) + chara.strength); }
        public int GetDerivedVitality() { return (int)((chara.vitality * (myClasses[chara.current_class_id].GetClassLevel() - 1) * myClasses[chara.current_class_id].GetVitalityMod()) + chara.vitality); }
        public int GetDerivedIntelligence() { return (int)((chara.intelligence * (myClasses[chara.current_class_id].GetClassLevel() - 1) * myClasses[chara.current_class_id].GetIntelligenceMod()) + chara.intelligence); }
        public int GetDerivedImagination() { return (int)((chara.imagination * (myClasses[chara.current_class_id].GetClassLevel() - 1) * myClasses[chara.current_class_id].GetImaginationMod()) + chara.imagination); }
        public int GetDerivedDexterity() { return (int)((chara.dexterity * (myClasses[chara.current_class_id].GetClassLevel() - 1) * myClasses[chara.current_class_id].GetDexterityMod()) + chara.dexterity); }
        public int GetDerivedAgility() { return (int)((chara.agility * (myClasses[chara.current_class_id].GetClassLevel() - 1) * myClasses[chara.current_class_id].GetAgilityMod()) + chara.agility); }
        public int GetDerivedLuck() { return (int)(chara.luck); }
    }
}