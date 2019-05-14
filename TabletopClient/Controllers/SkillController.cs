using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TabletopClient.Controllers;

public delegate void skillDelegate(CharaController chara, List<CharaController> targets, TabletopClient.Skill mySkill, float rollOffset);

namespace TabletopClient.Controllers
{
    public class SkillController
    {
        //This is a reference to our skill.
        private Skill mySkill;

        //These are variables derived from a specific character.
        private int skillRank = 0;

        //The constructor takes a skill id.
        public SkillController(int id, int rank)
        {
            mySkill = ContextController.ourContext.Skills.FirstOrDefault(n => n.id == id);
            skillRank = rank;
        }

        //When supplied with a string of skill ids, returns a list of those skills.
        public static List<SkillController> GetSkills(string idString, string[] ranks)
        {
            List<SkillController> r = new List<SkillController>();
            string[] ids = idString.Split(',');

            for (int i = 0; i < ids.Length; i++)
            {
                try
                {
                    r.Add(new SkillController(Convert.ToInt32(ids[i]), Convert.ToInt32(ranks[i])));
                }
                catch
                {
                    r.Add(new SkillController(Convert.ToInt32(ids[i]), 0));
                }
            }
            return r;
        }

        //This is a hardcoded dictionary that contains all of the skill logic. I'll be thinking of if there is a better way to do this without a million files.
        private Dictionary<int, skillDelegate> skllDict = new Dictionary<int, skillDelegate>()
        {
            {0, SkillController.WeaponAttack}
        };
        private static void WeaponAttack(CharaController attacker, List<CharaController> targets, Skill mySkill, float rollOffset)
        {
            //For each target.
            for (int i = 0; i < targets.Count(); i++)
            {
                targets[i].TakeDamage(GameMath.CalculateDamage(attacker.GetDerivedStrength(), (float)mySkill.potency, rollOffset));
            }
        }
    }
}