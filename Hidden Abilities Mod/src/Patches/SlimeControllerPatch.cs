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
        static void Patch(ref AbilityReadyIndicator[] ___AbilityReadyIndicators, ref NamedSpriteList ___abilityIconsFull, ref int ___playerNumber)
        {
            //if abilityready indicators exists and the player is not a local player
            if (___AbilityReadyIndicators != null && !(PlayerHandler.Get().GetPlayer(___playerNumber).IsLocalPlayer))
            {
                foreach (AbilityReadyIndicator ari in ___AbilityReadyIndicators)
                {
                    ari.SetSprite(___abilityIconsFull.GetSprite(1), false);
                }
            }
        }
    }
}
