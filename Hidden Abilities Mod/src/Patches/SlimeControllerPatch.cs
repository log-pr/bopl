using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HiddenAbilitiesMod.Patches
{
    [HarmonyPatch(typeof(SlimeController))]
    internal class SlimeControllerPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void Patch(ref AbilityReadyIndicator[] ___AbilityReadyIndicators, ref NamedSpriteList ___abilityIconsFull)
        {
            if (___AbilityReadyIndicators != null)
            {
                foreach (AbilityReadyIndicator ari in ___AbilityReadyIndicators)
                {
                    ari.SetSprite(___abilityIconsFull.GetSprite(1), false);
                }
            }
        }
    }
}
