using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletopClient.Controllers
{
    public class ClassController
    {
        //This is the class we reference.
        private Class myClass;
        public List<SkillController> mySkills;

        //Character specific variables.
        private int exp = 0;

        public ClassController(Class c, CharaController chara)
        {
            myClass = c;
            exp = chara.GetClassExp(myClass.id);
            mySkills = SkillController.GetSkills(myClass.skill_ids, chara.GetSkillRanks(myClass.id));
        }

        //Get an array of class controllers for each class a character has.
        public static List<ClassController> GetClasses(CharaController chara)
        {
            List<ClassController> r = new List<ClassController>();
            Class[] x = ContextController.ourContext.Classes.ToArray();
            for (int i = 0; i < x.Length; i++)
            {
                r.Add(new ClassController(x[i], chara));
            }
            return r;
        }

        //Get the class level.
        public int GetClassLevel()
        {
            return GetClassLevel(exp);
        }
        public static int GetClassLevel(int e)
        {
            int r = 1;
            while (e > GetExpToNext(r))
            {
                e -= GetExpToNext(r);
                r++;
            }
            return r;
        }

        //Get exp to next level
        public static int GetExpToNext(int l)
        {
            //CEILING((0.05 * (H19 ^ 3)) +  (H19 ^ 2))
            return (int)Math.Ceiling((0.05f * (Math.Pow(l, 3))) + (Math.Pow(l, 2)));
        }

        //Get stat mods.
        public float GetStrengthMod() { return (float)myClass.strength; }
        public float GetVitalityMod() { return (float)myClass.vitality; }
        public float GetIntelligenceMod() { return (float)myClass.intelligence; }
        public float GetImaginationMod() { return (float)myClass.imagination; }
        public float GetDexterityMod() { return (float)myClass.dexterity; }
        public float GetAgilityMod() { return (float)myClass.agility; }
    }
}