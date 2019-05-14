using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletopClient.Controllers
{
    public static class GameMath
    {
        //Damage Calculation Stuff
        public static int CalculateDamage(int atk, float potency, float rollOffset)
        {
            int r = (int)Math.Round((atk * potency));
            r = (int)(r * (1.0f + rollOffset));
            return r;
        }

        //Get the roll offset based on the number and style of dice used.
        public static float GetRollOffset(int roll, int faces, int number, float magnitude)
        {
            float r = roll;
            r -= (number * faces) / 2;
            r *= magnitude;
            return r;
        }
    }
}