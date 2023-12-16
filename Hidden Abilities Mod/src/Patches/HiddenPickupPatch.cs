using BepInEx.Logging;
using BoplFixedMath;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HiddenAbilities.Patches
{
    [HarmonyPatch(typeof(SlimeController))]
    internal class HiddenPickupPatch
    {
        [HarmonyPatch("LateUpdate")]
        [HarmonyPostfix]
        static void Patch(ref int ___playerNumber)
        {
            PlayerHandler.Get().GetPlayer(___playerNumber).AbilityIcons = new List<Sprite>();
        }
    }
}
