using BoplFixedMath;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoCooldownsMod.Patches
{
    [HarmonyPatch(typeof(Ability))]
    internal class CooldownPatch
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        static void Patch(ref Fix ___Cooldown)
        {
            ___Cooldown.m_rawValue = 0;
        }
    }
}
