using BoplFixedMath;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfiniteDash.Patches
{
    [HarmonyPatch(typeof(Dash))]
    internal class DashPatch
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        static void Patch(ref Fix ___dashLength, ref Ability ___ability)
        {
            ___dashLength.m_rawValue *= 5;
            ___ability.Cooldown.m_rawValue = 0;
        }
    }
}
